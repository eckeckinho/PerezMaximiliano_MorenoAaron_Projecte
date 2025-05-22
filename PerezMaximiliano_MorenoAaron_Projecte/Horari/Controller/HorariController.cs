using Entitats.HorariClasses;
using Pabo.Calendar;
using PerezMaximiliano_MorenoAaron_Projecte.Horari.Model;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Contacte.Controller
{
    public class HorariController
    {
        private MenuForm fm;
        private readonly IHorariService _horariService;
        private bool inicialitzat = false;
        private const int totalFranjas = 5; 
        private const int diesSetmana = 7;

        // Almacena las franjas por día (1 = Dilluns, ..., 7 = Diumenge)
        private Dictionary<int, List<FranjaHoraria>> franjasPerDia;

        public HorariController(IHorariService horariService)
        {
            _horariService = horariService;
            franjasPerDia = new Dictionary<int, List<FranjaHoraria>>();
        }

        public void SetForm(MenuForm menuForm)
        {
            fm = menuForm;
        } 

        public void Inicialitzar()
        {
            if (inicialitzat) return;
            inicialitzat = true;

            // Inicializar las franjas para cada día de la semana
            for (int dia = 1; dia <= diesSetmana; dia++)
            {
                franjasPerDia[dia] = new List<FranjaHoraria>();
            }

            // Limitar el rango del calendario a un año a partir de hoy
            fm.monthCalendarHorari_horari.MinDate = DateTime.Today;
            fm.monthCalendarHorari_horari.MaxDate = DateTime.Today.AddYears(1);

            SetListeners();
            SetDeleteButtonListeners();
            LoadData();
            PintarDiesAmbHorari();
        }

        private void SetListeners()
        {
            fm.buttonHorari_configurar.Click += ButtonConfigurarHorari_Click;
            fm.buttonHorari_assignarFestiu.Click += ButtonAssignarHorari_assignar_Click;
            fm.buttonHorari_desassignarFestiu.Click += ButtonAssignarHorari_desassignar_Click;

            fm.buttonHorari_addFranjaDilluns.Click += (s, e) => AddFranjaVisual(1);
            fm.buttonHorari_addFranjaDimarts.Click += (s, e) => AddFranjaVisual(2);
            fm.buttonHorari_addFranjaDimecres.Click += (s, e) => AddFranjaVisual(3);
            fm.buttonHorari_addFranjaDijous.Click += (s, e) => AddFranjaVisual(4);
            fm.buttonHorari_addFranjaDivendres.Click += (s, e) => AddFranjaVisual(5);
            fm.buttonHorari_addFranjaDissabte.Click += (s, e) => AddFranjaVisual(6);
            fm.buttonHorari_addFranjaDiumenge.Click += (s, e) => AddFranjaVisual(7);
        }

        private void SetDeleteButtonListeners()
        {
            fm.buttonHorari_deleteFranjaDilluns.Click += (s, e) => RemoveFranja(1);
            fm.buttonHorari_deleteFranjaDimarts.Click += (s, e) => RemoveFranja(2);
            fm.buttonHorari_deleteFranjaDimecres.Click += (s, e) => RemoveFranja(3);
            fm.buttonHorari_deleteFranjaDijous.Click += (s, e) => RemoveFranja(4);
            fm.buttonHorari_deleteFranjaDivendres.Click += (s, e) => RemoveFranja(5);
            fm.buttonHorari_deleteFranjaDissabte.Click += (s, e) => RemoveFranja(6);
            fm.buttonHorari_deleteFranjaDiumenge.Click += (s, e) => RemoveFranja(7);
        }

        private void LoadData()
        {
            for (int dia = 1; dia <= diesSetmana; dia++)
            {
                List<Horari> horaris = _horariService.GetHorarisDia(dia);

                foreach (var h in horaris)
                {
                    AddFranjaVisual(dia);

                    // Asigna los valores de inicio y fin a los pickers
                    var franja = franjasPerDia[dia][franjasPerDia[dia].Count - 1];
                    franja.pickerInici.Value = DateTime.Today.Add(h.hora_inici);
                    franja.pickerFinal.Value = DateTime.Today.Add(h.hora_final);
                }
            }
        }

        private void ButtonAssignarHorari_assignar_Click(object sender, EventArgs e)
        {
            if (fm.monthCalendarHorari_horari.SelectedDates.Count == 0)
            {
                MessageBox.Show("Selecciona almenys una data al calendari per marcar com a festiu.");
                return;
            }

            var datesSeleccionades = fm.monthCalendarHorari_horari.SelectedDates.Cast<DateTime>().Select(d => d.Date).OrderBy(d => d).ToList();

            // Filtrar solo las fechas habilitadas (serán de este mes y mayores o iguales a hoy)
            var datesSeleccionadesHabilitades = datesSeleccionades.Where(d => FechaActivadaCalendari(d)).ToList();

            if (datesSeleccionadesHabilitades.Count == 0)
            {
                MessageBox.Show("Les dates seleccionades no estan habilitades per assignar com a festius.");
                return;
            }

            if (!DiesConsecutius(datesSeleccionadesHabilitades))
            {
                MessageBox.Show("Només pots assignar dies festius consecutius.");
                return;
            }

            var primerDia = datesSeleccionadesHabilitades.First();
            var ultimDia = datesSeleccionadesHabilitades.Last();

            HorariExcepcions excepcio = new HorariExcepcions
            {
                data_inici = primerDia,
                data_final = ultimDia
            };

            var result = _horariService.AddHorariExcepcions(excepcio);

            if (result)
            {
                foreach (var data in datesSeleccionadesHabilitades)
                {
                    var item = new DateItem
                    {
                        Date = data,
                        BackColor1 = Color.Gray
                    };
                    fm.monthCalendarHorari_horari.AddDateInfo(item);
                }

                fm.monthCalendarHorari_horari.Refresh();
                PintarDiesAmbHorari();
                MessageBox.Show("Dies festius assignats correctament.");
            }
            else
            {
                MessageBox.Show("No s'han pogut assignar els dies festius.");
            }
        }

        private void ButtonAssignarHorari_desassignar_Click(object sender, EventArgs e)
        {
            if (fm.monthCalendarHorari_horari.SelectedDates.Count == 0)
            {
                MessageBox.Show("Selecciona almenys una data al calendari per desmarcar com a festiu.");
                return;
            }

            var datesSeleccionades = fm.monthCalendarHorari_horari.SelectedDates.Cast<DateTime>().Select(d => d.Date).OrderBy(d => d).ToList();

            if (!DiesConsecutius(datesSeleccionades))
            {
                MessageBox.Show("Només pots desassignar dies festius consecutius.");
                return;
            }

            bool canvisFets = false;

            foreach (var data in datesSeleccionades)
            {
                // Buscamos si la fecha seleccionada corresponde a un día festivo registrado en base de datos
                var excepcio = _horariService.GetHorariExcepcions().Where(ex => data >= ex.data_inici.Date && data <= ex.data_final.Date).FirstOrDefault();

                if (excepcio != null)
                {
                    canvisFets = true;

                    // Eliminamos la excepción original 
                    _horariService.DeleteHorariExcepcions(excepcio);

                    // Si la fecha está después del inicio del rango, creamos una excepción parcial antes de la fecha a desasignar
                    if (data > excepcio.data_inici)
                    {
                        var novaEsquerra = new HorariExcepcions
                        {
                            data_inici = excepcio.data_inici,        // desde el inicio original
                            data_final = data.AddDays(-1),           // hasta el día anterior de la fecha a desasignar
                            restaurantid = excepcio.restaurantid
                        };

                        _horariService.AddHorariExcepcions(novaEsquerra);
                    }

                    // Si la fecha está antes del final del rango, creamos una excepción parcial después de la fecha a desasignar
                    if (data < excepcio.data_final)
                    {
                        // Verificamos que el nuevo inicio esté dentro del rango válido
                        if (data.AddDays(1) <= excepcio.data_final)
                        {
                            var novaDreta = new HorariExcepcions
                            {
                                data_inici = data.AddDays(1),          // desde el día siguiente a la fecha a desasignar
                                data_final = excepcio.data_final,     // hasta el final original
                                restaurantid = excepcio.restaurantid
                            };

                            _horariService.AddHorariExcepcions(novaDreta);
                        }
                    }
                }
            }

            // Si se han hecho cambios, actualizamos el calendario
            if (canvisFets)
            {
                foreach (var data in datesSeleccionades)
                {
                    fm.monthCalendarHorari_horari.RemoveDateInfo(data);
                }

                fm.monthCalendarHorari_horari.Refresh();
                PintarDiesAmbHorari();
                MessageBox.Show("Dies festius desassignats correctament.");
            }
            else
            {
                MessageBox.Show("Cap dels dies seleccionats és festiu.");
            }
        }

        // Comprueba si la fecha está activada en el calendario
        private bool FechaActivadaCalendari(DateTime date)
        {
            var today = DateTime.Today;

            // Solo fechas del mes actual y >= hoy
            if (date.Month != today.Month) return false;
            if (date < today) return false;

            return true;
        }

        // Comprobar si los días son seguidos. (para evitar problemas como por ejemplo poder seleccionar fechas no activadas en el calendario
        // o solapamiento de fechas ya registradas. etc)
        private bool DiesConsecutius(List<DateTime> dates)
        {
            dates = dates.OrderBy(d => d).ToList();
            for (int i = 1; i < dates.Count; i++)
            {
                var diaActual = dates[i];
                var diaAnterior = dates[i - 1];

                // Siempre será 1 en caso de ser consecutivo
                if ((diaActual - diaAnterior).Days != 1) return false;
            }
            return true;
        }

        // Configurar el horario
        private void ButtonConfigurarHorari_Click(object sender, EventArgs e)
        {
            var totsElsHoraris = new List<Horari>();

            for (int dia = 1; dia <= diesSetmana; dia++)
            {
                foreach (var franja in franjasPerDia[dia])
                {
                    TimeSpan inici = franja.pickerInici.Value.TimeOfDay;
                    TimeSpan fi = franja.pickerFinal.Value.TimeOfDay;

                    if (inici >= fi)
                    {
                        MessageBox.Show($"Franja invàlida al dia {dia}. La hora de inici no pot ser igual o posterior a la de fi.");
                        return;
                    }

                    // Almacenar cada franja horaria de todos los días de la semana
                    totsElsHoraris.Add(new Horari
                    {
                        dia = dia,
                        hora_inici = inici,
                        hora_final = fi
                    });
                }
            }

            bool result = _horariService.SetHoraris(totsElsHoraris);

            if (result)
            {
                fm.monthCalendarHorari_horari.Refresh();
                PintarDiesAmbHorari();

                MessageBox.Show("Tots els horaris s'han guardat correctament.");
            }
            else
            {
                MessageBox.Show("Error al guardar els horaris.");
            }
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
                fm.monthCalendarHorari_horari.RemoveDateInfo(data);

                if (esLaborable && !esFestiu)
                {
                    // Si es laborable y no festivo, colorear de verde claro
                    var item = new DateItem
                    {
                        Date = data,
                        BackColor1 = Color.LightGreen
                    };
                    fm.monthCalendarHorari_horari.AddDateInfo(item);
                }
                else if (esFestiu)
                {
                    // Si es festivo, colorear de gris
                    var item = new DateItem
                    {
                        Date = data,
                        BackColor1 = Color.Gray
                    };
                    fm.monthCalendarHorari_horari.AddDateInfo(item);
                }
            }

            // Refrescar el calendario para mostrar los cambios
            fm.monthCalendarHorari_horari.Refresh();
        }

        // Añadir la franja al dia (visualmente hablando)
        private void AddFranjaVisual(int dia)
        {
            DateTimePicker pickerInici = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                Size = new System.Drawing.Size(65, 20),
                ShowUpDown = true,
                Value = DateTime.Today.AddHours(0).AddMinutes(0)
            };

            DateTimePicker pickerFinal = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "HH:mm",
                Size = new System.Drawing.Size(65, 20),
                ShowUpDown = true,
                Value = DateTime.Today.AddHours(0).AddMinutes(0)
            };

            Label separador = new Label
            {
                Text = "-",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            int offsetY = franjasPerDia[dia].Count * 35;

            pickerInici.Location = new Point(10, offsetY);
            separador.Location = new Point(80, offsetY + 5);
            pickerFinal.Location = new Point(95, offsetY);

            Panel panel = GetPanelByDia(dia);
            panel.Controls.Add(pickerInici);
            panel.Controls.Add(separador);
            panel.Controls.Add(pickerFinal);

            franjasPerDia[dia].Add(new FranjaHoraria
            {
                pickerInici = pickerInici,
                pickerFinal = pickerFinal,
                guio = separador,
            });

            UpdateEstatBotons();
        }

        // Elimina la última franja del día
        private void RemoveFranja(int dia)
        {
            var franja = franjasPerDia[dia][franjasPerDia[dia].Count - 1];
            Panel panel = GetPanelByDia(dia);
            panel.Controls.Remove(franja.pickerInici);
            panel.Controls.Remove(franja.pickerFinal);
            panel.Controls.Remove(franja.guio);

            // Elimina la franja de la lista
            franjasPerDia[dia].RemoveAt(franjasPerDia[dia].Count - 1);

            // Activar/desactivar el botón según corresponda
            UpdateEstatBotons();
        }

        // Coger panel por día
        private Panel GetPanelByDia(int dia)
        {
            switch (dia)
            {
                case 1: return fm.panelHorari_dilluns;
                case 2: return fm.panelHorari_dimarts;
                case 3: return fm.panelHorari_dimecres;
                case 4: return fm.panelHorari_dijous;
                case 5: return fm.panelHorari_divendres;
                case 6: return fm.panelHorari_dissabte;
                case 7: return fm.panelHorari_diumenge;
                default: throw new ArgumentException("Dia invàlid.");
            }
        }

        private void UpdateEstatBotons()
        {
            // Verificar cuántas franjas tiene cada día y activar/desactivar los botones correspondientes
            for (int dia = 1; dia <= diesSetmana; dia++)
            {
                // Comprobar el número de franjas para cada día
                if (franjasPerDia[dia].Count >= totalFranjas)
                {
                    // Desactivar el botón de añadir si ya se alcanzó el máximo de franjas
                    DesactivarBotonAddByDia(dia);
                }
                else
                {
                    // Si hay menos de 5 franjas, reactivar el botón de añadir
                    ActivarBotonByDia(dia);
                }

                // Activar/desactivar el botón de eliminar dependiendo de si hay franjas
                if (franjasPerDia[dia].Count == 0)
                {
                    // Desactivar el botón de eliminar si no hay franjas
                    DesactivarBotonDeleteByDia(dia);
                }
                else
                {
                    // Activar el botón de eliminar si hay franjas
                    ActivarBotonDeleteByDia(dia);
                }
            }
        }

        // Activar el botón del día correspondiente
        private void ActivarBotonByDia(int dia)
        {
            switch (dia)
            {
                case 1: fm.buttonHorari_addFranjaDilluns.Enabled = true; break;
                case 2: fm.buttonHorari_addFranjaDimarts.Enabled = true; break;
                case 3: fm.buttonHorari_addFranjaDimecres.Enabled = true; break;
                case 4: fm.buttonHorari_addFranjaDijous.Enabled = true; break;
                case 5: fm.buttonHorari_addFranjaDivendres.Enabled = true; break;
                case 6: fm.buttonHorari_addFranjaDissabte.Enabled = true; break;
                case 7: fm.buttonHorari_addFranjaDiumenge.Enabled = true; break;
            }
        }


        // Desactivar el botón del día correspondiente
        private void DesactivarBotonAddByDia(int dia)
        {
            switch (dia)
            {
                case 1: fm.buttonHorari_addFranjaDilluns.Enabled = false; break;
                case 2: fm.buttonHorari_addFranjaDimarts.Enabled = false; break;
                case 3: fm.buttonHorari_addFranjaDimecres.Enabled = false; break;
                case 4: fm.buttonHorari_addFranjaDijous.Enabled = false; break;
                case 5: fm.buttonHorari_addFranjaDivendres.Enabled = false; break;
                case 6: fm.buttonHorari_addFranjaDissabte.Enabled = false; break;
                case 7: fm.buttonHorari_addFranjaDiumenge.Enabled = false; break;
            }
        }

        // Activar el botón de eliminar para el día correspondiente
        private void ActivarBotonDeleteByDia(int dia)
        {
            switch (dia)
            {
                case 1: fm.buttonHorari_deleteFranjaDilluns.Enabled = true; break;
                case 2: fm.buttonHorari_deleteFranjaDimarts.Enabled = true; break;
                case 3: fm.buttonHorari_deleteFranjaDimecres.Enabled = true; break;
                case 4: fm.buttonHorari_deleteFranjaDijous.Enabled = true; break;
                case 5: fm.buttonHorari_deleteFranjaDivendres.Enabled = true; break;
                case 6: fm.buttonHorari_deleteFranjaDissabte.Enabled = true; break;
                case 7: fm.buttonHorari_deleteFranjaDiumenge.Enabled = true; break;
            }
        }

        // Desactivar el botón de eliminar para el día correspondiente
        private void DesactivarBotonDeleteByDia(int dia)
        {
            switch (dia)
            {
                case 1: fm.buttonHorari_deleteFranjaDilluns.Enabled = false; break;
                case 2: fm.buttonHorari_deleteFranjaDimarts.Enabled = false; break;
                case 3: fm.buttonHorari_deleteFranjaDimecres.Enabled = false; break;
                case 4: fm.buttonHorari_deleteFranjaDijous.Enabled = false; break;
                case 5: fm.buttonHorari_deleteFranjaDivendres.Enabled = false; break;
                case 6: fm.buttonHorari_deleteFranjaDissabte.Enabled = false; break;
                case 7: fm.buttonHorari_deleteFranjaDiumenge.Enabled = false; break;
            }
        }
    }
}
