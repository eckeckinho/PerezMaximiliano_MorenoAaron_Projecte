using Entitats.AuthClasses;
using Entitats.HorariClasses;
using Entitats.ReservaClasses;
using Pabo.Calendar;
using PerezMaximiliano_MorenoAaron_Projecte.Reserves.View;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Reserves.Controller
{
    public class ReservesController
    {
        private MenuForm fm;
        private AfegirReservaForm fr;
        private readonly IReservaService _reservaService;
        private readonly ITipusService _tipusService;
        private readonly ITaulaService _taulaService;
        private readonly IUsuariService _usuariService;
        private readonly IHorariService _horariService;
        private Reserva reserva;
        private DateTime? ultimaDataSeleccionadaValida = null;

        public ReservesController(IReservaService reservaService, ITipusService tipusService, ITaulaService taulaService, IUsuariService usuariService, IHorariService horariService)
        {
            _reservaService = reservaService;
            _tipusService = tipusService;
            _taulaService = taulaService;
            _usuariService = usuariService;
            _horariService = horariService;
        }

        public void Inicialitzar()
        {
            if (fr == null)
            {
                fr = new AfegirReservaForm();
                fr.monthCalendarReserva_horari.MinDate = DateTime.Today;
                fr.monthCalendarReserva_horari.MaxDate = DateTime.Today.AddYears(1);
                SetListeners();
            }
            LoadData();
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        }

        private void SetListeners()
        {
            fm.buttonReserva_finalitzar.Click += Button_finalitzar_Click;
            fm.buttonReserva_cancelar.Click += Button_cancelar_Click;
            fm.buttonReserva_enProces.Click += Button_enProces_Click;
            fm.buttonReserva_afegir.Click += Button_afegir_Click;
            fm.comboBoxReserva_estat.SelectedIndexChanged += ComboBox_estatreserva_SelectedIndexChanged;
            fm.dateTimePickerReserva_desde.ValueChanged += DateTimePicker_diareserva_desde_ValueChanged;
            fm.dateTimePickerReserva_hasta.ValueChanged += DateTimePicker_diareserva_hasta_ValueChanged;
            fm.dataGridViewReserva_reserves.SelectionChanged += DataGridView_reserves_SelectionChanged;
            fm.comboBoxReserva_usuari.SelectedIndexChanged += ComboBoxReserva_usuari_SelectedIndexChanged;
            fm.buttonReserva_actualitzar.Click += ButtonReserva_actualitzar_Click;

            fr.buttonAfegirReserva_reservar.Click += ButtonAfegirReserva_reservar_Click;
            fr.buttonAfegirReserva_actualitzar.Click += ButtonAfegirReserva_actualitzar_Click;
            fr.comboBoxAfegirReserva_franjaHoraria.SelectedIndexChanged += ComboBoxAfegirReserva_franjaHoraria_SelectedIndexChanged;
            fr.comboBoxAfegirReserva_taula.SelectedIndexChanged += ComboBoxAfegirReserva_taula_SelectedIndexChanged;
            fr.monthCalendarReserva_horari.DaySelected += MonthCalendarReserva_horari_DaySelected;
            fr.comboBoxAfegirReserva_durada.SelectedIndexChanged += ComboBoxAfegirReserva_durada_SelectedIndexChanged;
        }

        private void LoadData()
        {
            CarregarUsuarisAmbReserva();

            var desde = fm.dateTimePickerReserva_desde.Value;
            var hasta = fm.dateTimePickerReserva_hasta.Value;

            ActualitzarEstatsAmbCompte(-1, desde, hasta);

            var capacitatsTaules = _taulaService.GetCapacitatsDisponibles();
            fr.comboBoxAfegirReserva_taula.DataSource = capacitatsTaules;

            List<int> duradesReserves = new List<int> { 60, 90, 120 };
            fr.comboBoxAfegirReserva_durada.DataSource = duradesReserves;

            LoadDgvReservas();

            fm.dataGridViewReserva_reserves.Columns["id"].Visible = false;
            fm.dataGridViewReserva_reserves.Columns["taulaId"].Visible = false;
            fm.dataGridViewReserva_reserves.Columns["usuariId"].Visible = false;
            fm.dataGridViewReserva_reserves.Columns["estatId"].Visible = false;
            fm.dataGridViewReserva_reserves.Columns["restaurantid"].Visible = false;
            fm.dataGridViewReserva_reserves.Columns["valorat"].Visible = false;
        }

        private void LoadDgvReservas()
        {
            try
            {
                if (fm.comboBoxReserva_estat.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un estat de reserva.", "Advertència.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var estatReserva = fm.comboBoxReserva_estat.SelectedItem as EstatAmbCompte;
                var dataReservaDesde = fm.dateTimePickerReserva_desde.Value;
                var dataReservaHasta = fm.dateTimePickerReserva_hasta.Value;
                var usuari = fm.comboBoxReserva_usuari.SelectedItem as Usuari;

                fm.dataGridViewReserva_reserves.DataSource = _reservaService.GetReservesRestaurant(estatReserva.id, dataReservaDesde, dataReservaHasta, usuari);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error carregant reserves: {ex.Message}", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualitzarEstatsAmbCompte(int usuariId, DateTime desde, DateTime hasta)
        {
            var estats = _tipusService.GetTipusEstats();

            var estatsAmbCompte = estats.Select(estat => new EstatAmbCompte
            {
                id = estat.id,
                descripcio = estat.descripcio,
                compte = _reservaService.GetCountReservesByEstatUsuari(estat.id, usuariId, desde, hasta)
            }).ToList();

            fm.comboBoxReserva_estat.DataSource = estatsAmbCompte;
            fm.comboBoxReserva_estat.DisplayMember = "mostrarText"; 
        }

        private void RefrescarComboBoxEstats()
        {
            int usuariId = -1;
            var usuariSeleccionat = fm.comboBoxReserva_usuari.SelectedItem as Usuari;
            if (usuariSeleccionat != null) usuariId = usuariSeleccionat.id;

            var desde = fm.dateTimePickerReserva_desde.Value;
            var hasta = fm.dateTimePickerReserva_hasta.Value;

            ActualitzarEstatsAmbCompte(usuariId, desde, hasta);
        }

        private void CarregarUsuarisAmbReserva()
        {
            var usuaris = _usuariService.GetUsuarisAmbReserva();

            // Crear y añadir opción "Tots"
            var usuariTots = new Usuari
            {
                id = -1,
                nom = "Tots",
                cognoms = "",
            };
            usuaris.Insert(0, usuariTots);

            fm.comboBoxReserva_usuari.DataSource = usuaris;
            fm.comboBoxReserva_usuari.DisplayMember = "ToString";
        }


        private void PintarDiesAmbHorari()
        {
            var diesAmbHorari = _horariService.GetDiesAmbHorari();
            var excepcions = _horariService.GetHorariExcepcions();

            if (diesAmbHorari == null || diesAmbHorari.Count == 0) return;

            DateTime avui = DateTime.Today;
            DateTime fi = avui.AddMonths(12);

            // Recorrer cada día desde hoy hasta dentro de 12 meses
            for (DateTime data = avui; data <= fi; data = data.AddDays(1))
            {
                int diaSetmana = (int)data.DayOfWeek;

                // Si es domingo (0), se asigna 7 para que la semana empiece en lunes
                if (diaSetmana == 0)
                {
                    diaSetmana = 7;
                }

                bool esLaborable = diesAmbHorari.Contains(diaSetmana); // Comprobar si el día es laborable 
                bool esFestiu = excepcions.Any(e => e.data_inici.Date <= data && data <= e.data_final.Date); // Comprobar si el día es festivo 

                // Quitar cualquier información previa del calendario para ese día
                fr.monthCalendarReserva_horari.RemoveDateInfo(data);

                if (esLaborable && !esFestiu)
                {
                    // Si es laborable y no festivo, colorear de verde claro
                    var item = new DateItem
                    {
                        Date = data,
                        BackColor1 = Color.LightGreen
                    };
                    fr.monthCalendarReserva_horari.AddDateInfo(item);
                }
                else if (esFestiu)
                {
                    // Si es festivo, colorear de gris
                    var item = new DateItem
                    {
                        Date = data,
                        BackColor1 = Color.Gray
                    };
                    fr.monthCalendarReserva_horari.AddDateInfo(item);
                }
            }

            // Refrescar el calendario para mostrar los cambios
            fr.monthCalendarReserva_horari.Refresh();
        }

        private void SeleccionarPrimeraDataLaborable()
        {
            DateTime data = DateTime.Today;
            DateTime fi = data.AddYears(1);

            while (data <= fi)
            {
                // Buscar si la fecha seleccionada está pintada de verde (es decir: que es laborable y por lo tanto seleccionable para reservar)
                var dateInfos = fr.monthCalendarReserva_horari.GetDateInfo(data);
                var dateInfo = dateInfos?.FirstOrDefault();

                if (dateInfo != null && dateInfo.BackColor1 == Color.LightGreen)
                {
                    // Seleccionamos la fecha en el calendario
                    fr.monthCalendarReserva_horari.ClearSelection();
                    fr.monthCalendarReserva_horari.SelectDate(data);

                    // Seleccionar seleccionar el número de comensals per carregar les dades
                    ComboBoxAfegirReserva_taula_SelectedIndexChanged(fr.comboBoxAfegirReserva_taula, EventArgs.Empty);
                    break;
                }   

                // Següent día
                data = data.AddDays(1);
            }
        }

        private void ComboBoxAfegirReserva_durada_SelectedIndexChanged(object sender, EventArgs e)
        {
            var franjaSeleccionada = fr.comboBoxAfegirReserva_franjaHoraria.SelectedItem as Horari;

            if (franjaSeleccionada != null)
            {
                DateTime data = fr.monthCalendarReserva_horari.SelectedDates.Cast<DateTime>().FirstOrDefault().Date;

                // Cargar las horas disponibles para esa fecha y franja
                CarregarHoresDisponibles(data, franjaSeleccionada);
            }
        }

        // Abrir el form de modificar reserva y cargar los componentes
        private void ButtonReserva_actualitzar_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count != 1)
            {
                MessageBox.Show("Selecciona una única reserva per modificar.", "Atenció.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reserva = fm.dataGridViewReserva_reserves.SelectedRows[0].DataBoundItem as Reserva;

            if (reserva == null)
            {
                MessageBox.Show("Reserva no vàlida.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            fr.Text = "Modificar reserva";
            fr.buttonAfegirReserva_actualitzar.Visible = true;
            fr.buttonAfegirReserva_reservar.Visible = false;

            PintarDiesAmbHorari();

            // Cargar el formulario con los datos de la reserva y seleccionando los elementos de la reserva a modificar
            fr.comboBoxAfegirReserva_usuari.DataSource = _usuariService.GetUsuaris();
            fr.comboBoxAfegirReserva_usuari.DisplayMember = "correu";
            fr.comboBoxAfegirReserva_usuari.SelectedItem = _reservaService.GetUsuariReserva(reserva.usuariId);

            var capacitatsTaules = _taulaService.GetCapacitatsDisponibles();
            fr.comboBoxAfegirReserva_taula.DataSource = capacitatsTaules;
            fr.comboBoxAfegirReserva_taula.SelectedItem = reserva.numcomensals;

            fr.monthCalendarReserva_horari.ClearSelection();
            fr.monthCalendarReserva_horari.SelectDate(reserva.datareserva);
            ComboBoxAfegirReserva_taula_SelectedIndexChanged(fr.comboBoxAfegirReserva_taula, EventArgs.Empty);

            var franjes = _horariService.GetHorarisDia(reserva.datareserva);
            fr.comboBoxAfegirReserva_franjaHoraria.DataSource = franjes;
            var franjaSeleccionada = franjes.FirstOrDefault(f => reserva.hora >= f.hora_inici && reserva.hora < f.hora_final);

            if (franjaSeleccionada != null)
            {
                fr.comboBoxAfegirReserva_franjaHoraria.SelectedItem = franjaSeleccionada;
            }

            fr.comboBoxAfegirReserva_hora.SelectedItem = reserva.hora;

            fr.comboBoxAfegirReserva_durada.DataSource = new List<int> { 60, 90, 120 }; 
            fr.comboBoxAfegirReserva_durada.SelectedItem = reserva.durada;

            fr.ShowDialog();
        }

        // Modificar la reserva seleccionada
        private void ButtonAfegirReserva_actualitzar_Click(object sender, EventArgs e)
        {
            if (reserva == null)
            {
                MessageBox.Show("No hi ha cap reserva seleccionada per actualitzar.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fr.monthCalendarReserva_horari.SelectedDates.Count == 0)
            {
                MessageBox.Show("Selecciona una data abans d'actualitzar la reserva.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fr.comboBoxAfegirReserva_usuari.SelectedItem == null ||
                fr.comboBoxAfegirReserva_taula.SelectedItem == null ||
                fr.comboBoxAfegirReserva_hora.SelectedItem == null ||
                fr.comboBoxAfegirReserva_durada.SelectedItem == null)            
            {
                MessageBox.Show("Ompli tots els camps abans d'actualitzar la reserva.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener los valores seleccionados en los combos
            int numComensals = (int)fr.comboBoxAfegirReserva_taula.SelectedItem;
            DateTime dataReserva = fr.monthCalendarReserva_horari.SelectedDates[0];
            TimeSpan horaReserva = (TimeSpan)fr.comboBoxAfegirReserva_hora.SelectedItem;
            int duradaReserva = (int)fr.comboBoxAfegirReserva_durada.SelectedItem;
            var usuari = (Usuari)fr.comboBoxAfegirReserva_usuari.SelectedItem;

            var taulaDisponible = _reservaService.GetTaulaDisponible(numComensals, dataReserva, horaReserva, duradaReserva);

            if (taulaDisponible == null)
            {
                MessageBox.Show("No hi ha cap taula disponible per a aquest horari.", "Sense disponibilitat.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mostrar resumen y pedir confirmación
            string resum = $"Confirmar actualització de la reserva:\n\n" +
                           $"Usuari: {usuari.nom}\n" +
                           $"Data: {dataReserva:dd/MM/yyyy}\n" +
                           $"Hora: {horaReserva:hh\\:mm}\n" +
                           $"Durada: {duradaReserva} minuts\n" +
                           $"Comensals: {numComensals}\n\n" +
                           "Vols confirmar els canvis?";

            var confirmResult = MessageBox.Show(resum, "Confirmar modificació.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No) return; 

            Reserva reservaModificada = new Reserva
            {
                id = reserva.id,
                taulaid = taulaDisponible.id,
                usuariId = usuari.id,
                datareserva = dataReserva,
                numcomensals = numComensals,
                hora = horaReserva,
                durada = duradaReserva,
                estatid = reserva.estatid,
                restaurantid = reserva.restaurantid
            };

            bool resultat = _reservaService.ActualitzarReserva(reservaModificada);

            if (resultat)
            {
                reserva = null;
                fr.Close();
                MessageBox.Show("Reserva modificada correctament.", "Reserva modificada.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarUsuarisAmbReserva();
                RefrescarComboBoxEstats();
                LoadDgvReservas(); 
            }
            else
            {
                MessageBox.Show("Error al modificar la reserva.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MonthCalendarReserva_horari_DaySelected(object sender, DaySelectedEventArgs e)
        {
            var dataSeleccionada = fr.monthCalendarReserva_horari.SelectedDates.Cast<DateTime>().Select(d => d.Date).FirstOrDefault();

            // Buscar si la fecha seleccionada está pintada de verde (es decir: que es laborable y por lo tanto seleccionable para reservar)
            var dateInfoArray = fr.monthCalendarReserva_horari.GetDateInfo(dataSeleccionada);
            var dateInfo = dateInfoArray?.FirstOrDefault();

            if (dateInfo == null || dateInfo.BackColor1 != Color.LightGreen)
            {
                // Día no permitido, cancelar / no permitir que se seleccione
                MessageBox.Show("Aquest día no està disponible per a reserves.", "Data no vàlida.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (ultimaDataSeleccionadaValida.HasValue)
                {
                    // Volver a seleccionar la última fecha válida
                    fr.monthCalendarReserva_horari.ClearSelection();
                    fr.monthCalendarReserva_horari.SelectDate(ultimaDataSeleccionadaValida.Value);

                    // Actualizar el combo con la última fecha válida
                    ComboBoxAfegirReserva_taula_SelectedIndexChanged(fr.comboBoxAfegirReserva_taula, EventArgs.Empty);
                }
                else
                {
                    // Si no hay última fecha válida guardada, seleccionar la primera fecha laborable
                    SeleccionarPrimeraDataLaborable();
                }
            }
            else
            {
                // Día válido, actualizar la última fecha válida seleccionada
                ultimaDataSeleccionadaValida = dataSeleccionada;

                // Cargar franjas horarias para esta fecha (seleccionar primera mesa)
                ComboBoxAfegirReserva_taula_SelectedIndexChanged(fr.comboBoxAfegirReserva_taula, EventArgs.Empty);
            }
        }

        private void ComboBoxAfegirReserva_taula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fr.comboBoxAfegirReserva_taula.SelectedItem == null) return;

            int capacitatSeleccionada = (int)fr.comboBoxAfegirReserva_taula.SelectedItem;

            var data = fr.monthCalendarReserva_horari.SelectedDates.Cast<DateTime>().Select(d => d.Date).FirstOrDefault();

            var franges = _horariService.GetHorarisDia(data);

            // Evitar que salte el evento mientras se actualiza el DataSource
            fr.comboBoxAfegirReserva_franjaHoraria.SelectedIndexChanged -= ComboBoxAfegirReserva_franjaHoraria_SelectedIndexChanged;

            // Limpiar las franjas horarias
            fr.comboBoxAfegirReserva_franjaHoraria.DataSource = null;

            // Cargar las franjas horarias en caso de que hayan
            if (franges != null && franges.Any())
            {
                fr.comboBoxAfegirReserva_franjaHoraria.DataSource = franges;
                fr.comboBoxAfegirReserva_franjaHoraria.DisplayMember = "ToString";
                fr.comboBoxAfegirReserva_franjaHoraria.SelectedIndex = 0;
            }
            else
            {
                // Limpiar las horas si no hay franjas horarias
                fr.comboBoxAfegirReserva_hora.DataSource = null;
            }

            // Volver a activar el evento
            fr.comboBoxAfegirReserva_franjaHoraria.SelectedIndexChanged += ComboBoxAfegirReserva_franjaHoraria_SelectedIndexChanged;

            // Llamar manualmente al evento si hay elementos para que cargue directamente las horas disponibles de la franja en concreto
            if (franges != null && franges.Any())
            {
                ComboBoxAfegirReserva_franjaHoraria_SelectedIndexChanged(fr.comboBoxAfegirReserva_franjaHoraria, EventArgs.Empty);
            }
        }

        private void ComboBoxAfegirReserva_franjaHoraria_SelectedIndexChanged(object sender, EventArgs e)
        {
            var franjaSeleccionada = fr.comboBoxAfegirReserva_franjaHoraria.SelectedItem as Horari;

            if (franjaSeleccionada != null)
            {
                DateTime data = fr.monthCalendarReserva_horari.SelectedDates.Cast<DateTime>().FirstOrDefault().Date;

                // Cargar las horas disponibles para esa fecha y franja
                CarregarHoresDisponibles(data, franjaSeleccionada);
            }
        }

        private void CarregarHoresDisponibles(DateTime data, Horari franjaSeleccionada)
        {
            int capacitatSeleccionada = (int)fr.comboBoxAfegirReserva_taula.SelectedItem;

            if (fr.comboBoxAfegirReserva_durada.SelectedItem == null) return; 

            int duradaSeleccionada = (int)fr.comboBoxAfegirReserva_durada.SelectedItem;

            var taulesDisponibles = _taulaService.GetTaules().Where(t => t.numComensals == capacitatSeleccionada).ToList();

            List<Reserva> reservesDelDia = new List<Reserva>();

            // Si estamos añadiendo será nulo y por tanto cogeremos todas las reservas disponibles 
            if (reserva == null)
            {
                reservesDelDia = _reservaService.GetReservesDia(data).Where(r =>
                r.estatid == (int)EstatReserva.EnProces &&
                taulesDisponibles.Any(t => t.id == r.taulaid))
                .ToList();
            } else // Si estamos modificando tendrá una reserva almacenada y la excluiremos, para así poder escoger las horas sin contar que esa mesa para esa hora esté ya reservada
            {
                reservesDelDia = _reservaService.GetReservesDia(data).Where(r =>
                r.estatid == (int)EstatReserva.EnProces &&
                taulesDisponibles.Any(t => t.id == r.taulaid) &&
                r.id != reserva?.id) // Excluir la reserva que se modifica
                .ToList();
            }

            List<TimeSpan> horesDisponibles = new List<TimeSpan>();

            // Vamos probando horas dentro de la franja horaria, desde el inicio hasta el final, moviéndonos en intervalos de 15 minutos.
            // Cada 'hora' representa un posible inicio para una nueva reserva.

            for (TimeSpan hora = franjaSeleccionada.hora_inici;
                 hora.Add(TimeSpan.FromMinutes(duradaSeleccionada)) <= franjaSeleccionada.hora_final; // La nueva reserva debe terminar antes o justo al final de la franja
                 hora = hora.Add(TimeSpan.FromMinutes(15))) // Avanzamos 15 minutos para probar la siguiente hora posible
            {
                TimeSpan horaActual = TimeSpan.Zero;

                // Comprobar y descartar las horas que ya hayan pasado en el día de hoy para que no se muestren como reservables
                if (data.Date == DateTime.Now.Date)
                {
                    DateTime horaCompleta = data.Date + hora; 

                    if (horaCompleta < DateTime.Now) continue; // Descarta esta hora porque ya ha pasado
                }

                int taulesOcupades = 0; 

                // Revisamos todas las reservas existentes para ver si alguna se solapa con esta hora
                foreach (var reserva in reservesDelDia)
                {
                    if (reserva.hora.HasValue)
                    {
                        // Hora de inicio y fin de la reserva ya existente
                        TimeSpan horaIniciReserva = reserva.hora.Value;
                        TimeSpan horaFiReserva = horaIniciReserva.Add(TimeSpan.FromMinutes(reserva.durada)); // Sumamos la duracion para saber cuando acabará la reserva

                        // Hora de fin si la nueva reserva empieza en 'hora'
                        TimeSpan horaNovaFi = hora.Add(TimeSpan.FromMinutes(duradaSeleccionada));  // Sumamos la duracion para saber cuando acabará la reserva

                        // Verificamos si la nueva reserva y la existente se solapan en el tiempo
                        bool solapen = hora < horaFiReserva && horaNovaFi > horaIniciReserva;

                        if (solapen) taulesOcupades++; // En caso de solaparse, contamos esta mesa como ocupada
                    }
                }

                // Si hay mesas libres para esta hora, la añadimos a la lista de horas disponibles
                if (taulesOcupades < taulesDisponibles.Count)
                {
                    horesDisponibles.Add(hora);
                }
            }

            fr.comboBoxAfegirReserva_hora.DataSource = horesDisponibles;
        }

        // Reservar una nueva reserva 
        private void ButtonAfegirReserva_reservar_Click(object sender, EventArgs e)
        {
            if (fr.monthCalendarReserva_horari.SelectedDates.Count == 0)
            {
                MessageBox.Show("Selecciona una data abans d'afegir la reserva.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fr.comboBoxAfegirReserva_usuari.SelectedItem == null ||
                    fr.comboBoxAfegirReserva_taula.SelectedItem == null ||
                    fr.comboBoxAfegirReserva_hora.SelectedItem == null ||
                    fr.comboBoxAfegirReserva_durada.SelectedItem == null)
            {
                MessageBox.Show("Ompli tots els camps abans d'afegir la reserva", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Coger el usuario
            var usuari = fr.comboBoxAfegirReserva_usuari.SelectedItem as Usuari;

                // Coger el número de comensales
                int? numComensals = null;
                if (fr.comboBoxAfegirReserva_taula.SelectedItem != null)
                {
                    numComensals = (int)fr.comboBoxAfegirReserva_taula.SelectedItem;
                }

                // Coger la fecha
                var data = fr.monthCalendarReserva_horari.SelectedDates.Cast<DateTime>().Select(d => d.Date).FirstOrDefault();

                // Coger la hora
                TimeSpan? hora = null;
                if (fr.comboBoxAfegirReserva_hora.SelectedItem != null)
                {
                    hora = (TimeSpan)fr.comboBoxAfegirReserva_hora.SelectedItem;
                }

                // Coger la duración
                int durada = (int)fr.comboBoxAfegirReserva_durada.SelectedItem;

                if (usuari != null && numComensals != null && hora.HasValue)
                {
                    // Construir resumen
                    string resumen = $"Confirmar reserva:\n\n" +
                                     $"Usuari: {usuari.nom}\n" +
                                     $"Data: {data:dd/MM/yyyy}\n" +
                                     $"Hora: {hora.Value:hh\\:mm}\n" +
                                     $"Durada: {durada} minuts\n" +
                                     $"Comensals: {numComensals}\n\n" +
                                     "Vols confirmar la reserva?";

                    var confirmResult = MessageBox.Show(resumen, "Confirmar reserva.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        var taulaDisponible = _reservaService.GetTaulaDisponible(numComensals, data, hora, durada);

                        if (taulaDisponible != null)
                        {
                            Reserva novaReserva = new Reserva
                            {
                                taulaid = taulaDisponible.id,
                                usuariId = usuari.id,
                                datareserva = data.Date,
                                numcomensals = numComensals,
                                hora = hora.Value,
                                estatid = (int)EstatReserva.EnProces,
                                durada = durada,
                                restaurantid = 0
                            };

                            var resultat = _reservaService.AfegirReserva(novaReserva);

                            if (resultat)
                            {
                                fr.Close();
                                MessageBox.Show("Reserva afegida amb èxit.", "Reserva completada.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                CarregarUsuarisAmbReserva();
                                RefrescarComboBoxEstats();
                                LoadDgvReservas();
                            }
                            else
                            {
                                MessageBox.Show("Error al afegir la reserva.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No hi ha cap taula disponible per a aquest horari.", "Sense disponibilitat.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
            }
            else
            {
                MessageBox.Show("Ompli tots els camps.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DataGridView_reserves_SelectionChanged(object sender, EventArgs e)
        {
            ActivarBotonGuardar();
            CargarInfoUsuari();
        }

        private void ActivarBotonGuardar()
        {
            var estatReserva = fm.comboBoxReserva_estat.SelectedItem as EstatAmbCompte;
            Reserva reservaSeleccionada = null;

            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                reservaSeleccionada = fm.dataGridViewReserva_reserves.SelectedRows[0].DataBoundItem as Reserva;

                // Combinar fecha + hora y calcular hora de fin de la reserva
                DateTime fechaHoraInicio = (DateTime)(reservaSeleccionada.datareserva.Date + reservaSeleccionada.hora);
                // Calcular hora final de la reserva
                DateTime fechaHoraFin = fechaHoraInicio.AddMinutes(reservaSeleccionada.durada);

                // Guardar si la reserva es igual o posterior al día de hoy para no permitir poner reservas en "proceso" antiguas
                bool reservaActivaOFutura = fechaHoraFin >= DateTime.Now;

                if (estatReserva.id == (int)EstatReserva.EnProces)
                {
                    fm.buttonReserva_finalitzar.Enabled = true;
                    fm.buttonReserva_cancelar.Enabled = true;
                    fm.buttonReserva_enProces.Enabled = false;
                    fm.buttonReserva_actualitzar.Enabled = true;
                }
                else if (estatReserva.id == (int)EstatReserva.Cancelada)
                {
                    fm.buttonReserva_finalitzar.Enabled = true;
                    fm.buttonReserva_cancelar.Enabled = false;
                    fm.buttonReserva_enProces.Enabled = reservaActivaOFutura;
                    fm.buttonReserva_actualitzar.Enabled = false;
                }
                else if (estatReserva.id == (int)EstatReserva.Finalitzada)
                {
                    fm.buttonReserva_finalitzar.Enabled = false;
                    fm.buttonReserva_cancelar.Enabled = true;
                    fm.buttonReserva_enProces.Enabled = reservaActivaOFutura;
                    fm.buttonReserva_actualitzar.Enabled = false;
                }
                else
                {
                    fm.buttonReserva_finalitzar.Enabled = false;
                    fm.buttonReserva_cancelar.Enabled = false;
                    fm.buttonReserva_enProces.Enabled = false;
                    fm.buttonReserva_actualitzar.Enabled = false;
                }
            }
            else
            {
                fm.buttonReserva_finalitzar.Enabled = false;
                fm.buttonReserva_cancelar.Enabled = false;
                fm.buttonReserva_enProces.Enabled = false;
                fm.buttonReserva_actualitzar.Enabled = false;
            }
        }

        private void CargarInfoUsuari()
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                var reservaSeleccionada = fm.dataGridViewReserva_reserves.SelectedRows[0].DataBoundItem as Reserva;

                var usuariReserva = _reservaService.GetUsuariReserva(reservaSeleccionada.usuariId);
                fm.textBoxReserva_idUsuari.Text = usuariReserva.id.ToString();
                fm.textBoxReserva_correuUsuari.Text = usuariReserva.correu;
                fm.textBoxReserva_nomUsuari.Text = usuariReserva.nom;
                fm.textBoxReserva_cognomsUsuari.Text = usuariReserva.cognoms;
                fm.textBoxReserva_telefonUsuari.Text = usuariReserva.telefon;
            }
            else
            {
                fm.textBoxReserva_idUsuari.Text = "";
                fm.textBoxReserva_correuUsuari.Text = "";
                fm.textBoxReserva_nomUsuari.Text = "";
                fm.textBoxReserva_cognomsUsuari.Text = "";
                fm.textBoxReserva_telefonUsuari.Text = "";
            }
        }

        // Controlar bien los cambios de fecha y cargar las reservas al cambiarlos
        private void DateTimePicker_diareserva_desde_ValueChanged(object sender, EventArgs e)
        {
            if (fm.dateTimePickerReserva_desde.Value > fm.dateTimePickerReserva_hasta.Value)
            {
                fm.dateTimePickerReserva_desde.Value = fm.dateTimePickerReserva_hasta.Value;
                MessageBox.Show("La data 'Des de' no pot ser posterior a la data 'Fins a'.", "Data invàlida.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RefrescarComboBoxEstats();
            LoadDgvReservas();
        }

        private void DateTimePicker_diareserva_hasta_ValueChanged(object sender, EventArgs e)
        {
            if (fm.dateTimePickerReserva_hasta.Value < fm.dateTimePickerReserva_desde.Value)
            {
                fm.dateTimePickerReserva_hasta.Value = fm.dateTimePickerReserva_desde.Value;
                MessageBox.Show("La data 'Fins a' no pot ser anterior a la data 'Des de'.", "Data invàlida.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RefrescarComboBoxEstats();
            LoadDgvReservas();
        }

        private void ComboBox_estatreserva_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDgvReservas();
        }

        private void ComboBoxReserva_usuari_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usuari = fm.comboBoxReserva_usuari.SelectedItem as Usuari;

            int usuariId;
            if (usuari != null) usuariId = usuari.id;
            else usuariId = -1;

            var desde = fm.dateTimePickerReserva_desde.Value;
            var hasta = fm.dateTimePickerReserva_hasta.Value;

            ActualitzarEstatsAmbCompte(usuariId, desde, hasta);
            LoadDgvReservas();
        }


        // Abrir form de añadir reserva y actualizar campos
        private void Button_afegir_Click(object sender, EventArgs e)
        {
            // Refrescar usuarios
            fr.comboBoxAfegirReserva_usuari.DataSource = _usuariService.GetUsuaris();
            fr.comboBoxAfegirReserva_usuari.DisplayMember = "correu";
            fr.comboBoxAfegirReserva_usuari.SelectedIndex = 0;

            // Refrescar capacidades disponibles
            var capacitatsTaules = _taulaService.GetCapacitatsDisponibles();
            fr.comboBoxAfegirReserva_taula.DataSource = capacitatsTaules;
            if (capacitatsTaules.Any())fr.comboBoxAfegirReserva_taula.SelectedIndex = 0;

            // Limpiar franja horaria y hora
            fr.comboBoxAfegirReserva_franjaHoraria.DataSource = null;
            fr.comboBoxAfegirReserva_hora.DataSource = null;

            PintarDiesAmbHorari();
            SeleccionarPrimeraDataLaborable();

            fr.Text = "Afegir reserva";
            fr.buttonAfegirReserva_actualitzar.Visible = false;
            fr.buttonAfegirReserva_reservar.Visible = true;

            // Limpiar reserva para así mostrar las horas sin excluir las horas de la reserva guardada en memoria (en caso de haber modificado una reserva antes)
            if (reserva != null)
            {
                reserva = null;
            }

            fr.ShowDialog();
        }

        // Poner en proceso la reserva seleccionada
        private void Button_enProces_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                List<Reserva> reservasSeleccionadas = new List<Reserva>();

                foreach (DataGridViewRow row in fm.dataGridViewReserva_reserves.SelectedRows)
                {
                    var reserva = row.DataBoundItem as Reserva;

                    if (reserva != null)
                    {
                        reservasSeleccionadas.Add(reserva);
                    }
                }

                var nouEstat = (int)EstatReserva.EnProces;
                bool resultatEnProces = _reservaService.CanviarEstatReserva(reservasSeleccionadas, nouEstat);

                if (resultatEnProces)
                {
                    MessageBox.Show("Reserves canviades a 'En procés'.", "Canvi d'estat completat. ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefrescarComboBoxEstats();
                    LoadDgvReservas();
                }
                else
                {
                    MessageBox.Show("No és possible possar en procés les reserves seleccionades ja que es solapen amb reserves ja existents.", "Canvi d'estat denegat.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha reserves seleccionades.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Finalizar la reserva seleccionada
        private void Button_finalitzar_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                List<Reserva> reservasSeleccionadas = new List<Reserva>();

                foreach (DataGridViewRow row in fm.dataGridViewReserva_reserves.SelectedRows)
                {
                    var reserva = row.DataBoundItem as Reserva;

                    if (reserva != null)
                    {
                        reservasSeleccionadas.Add(reserva);
                    }
                }

                var nouEstat = (int)EstatReserva.Finalitzada;
                bool resultatFinalitzacio = _reservaService.CanviarEstatReserva(reservasSeleccionadas, nouEstat);

                if (resultatFinalitzacio)
                {
                    MessageBox.Show("Reserves canviades a 'Finalitzades'.", "Canvi d'estat completat. ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefrescarComboBoxEstats();
                    LoadDgvReservas();
                }
                else
                {
                    MessageBox.Show("No és possible finalitzar les reserves seleccionades.", "Canvi d'estat denegat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha reserves seleccionades.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Cancelar la reserva seleccionada
        private void Button_cancelar_Click(object sender, EventArgs e)
        {
            if (fm.dataGridViewReserva_reserves.SelectedRows.Count > 0)
            {
                List<Reserva> reservasSeleccionadas = new List<Reserva>();

                foreach (DataGridViewRow row in fm.dataGridViewReserva_reserves.SelectedRows)
                {
                    var reserva = row.DataBoundItem as Reserva;

                    if (reserva != null)
                    {
                        reservasSeleccionadas.Add(reserva);
                    }
                }

                var nouEstat = (int)EstatReserva.Cancelada;
                bool resultatCancelacio = _reservaService.CanviarEstatReserva(reservasSeleccionadas, nouEstat);

                if (resultatCancelacio)
                {
                    MessageBox.Show("Reserves canviades a 'Cancel.lades'.", "Canvi d'estat completat. ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefrescarComboBoxEstats();
                    LoadDgvReservas();
                }
                else
                {
                    MessageBox.Show("No és possible cancelar les reserves seleccionades.", "Canvi d'estat denegat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hi ha reserves seleccionades.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
