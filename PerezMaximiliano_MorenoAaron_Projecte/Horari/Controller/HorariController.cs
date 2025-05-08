using Entitats.HorariClasses;
using MaterialSkin.Controls;
using PerezMaximiliano_MorenoAaron_Projecte.Horari.Model;
using PerezMaximiliano_MorenoAaron_Projecte.View;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacte.Controller
{
    public class HorariController
    {
        private MenuForm fm;
        private readonly IHorariService _horariService;

        private const int MAX_FRANJAS = 5;
        private const int TOTAL_DIES = 7;

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
            for (int dia = 1; dia <= TOTAL_DIES; dia++)
            {
                franjasPerDia[dia] = new List<FranjaHoraria>();
            }

            SetListeners();
            SetDeleteButtonListeners();
            LoadData();
        }

        private void SetListeners()
        {
            fm.buttonHorari_configurar.Click += ButtonConfigurarHorari_Click;

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
            // Asocia el evento Click de cada botón de eliminar a la función correspondiente para cada día
            fm.buttonHorari_deleteFranjaDilluns.Click += (s, e) => RemoveFranja(1);
            fm.buttonHorari_deleteFranjaDimarts.Click += (s, e) => RemoveFranja(2);
            fm.buttonHorari_deleteFranjaDimecres.Click += (s, e) => RemoveFranja(3);
            fm.buttonHorari_deleteFranjaDijous.Click += (s, e) => RemoveFranja(4);
            fm.buttonHorari_deleteFranjaDivendres.Click += (s, e) => RemoveFranja(5);
            fm.buttonHorari_deleteFranjaDissabte.Click += (s, e) => RemoveFranja(6);
            fm.buttonHorari_deleteFranjaDiumenge.Click += (s, e) => RemoveFranja(7);
        }

        private void RemoveFranja(int dia)
        {
            // Elimina la última franja del día
            var franja = franjasPerDia[dia][franjasPerDia[dia].Count - 1];
            Panel panel = GetPanelByDia(dia);
            panel.Controls.Remove(franja.pickerInici);
            panel.Controls.Remove(franja.pickerFinal);
            panel.Controls.Remove(franja.guio);

            // Elimina la franja de la lista
            franjasPerDia[dia].RemoveAt(franjasPerDia[dia].Count - 1);

            // Actualiza el estado de los botones (activar/desactivar el botón de añadir según corresponda)
            UpdateButtonsState();
        }


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
            separador.Location = new Point(80, offsetY + 5); // Acercar separador al inicio
            pickerFinal.Location = new Point(95, offsetY);   // Acercar pickerFinal al separador

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

            UpdateButtonsState();
        }

        private void DisableButtonForDay(int dia)
        {
            // Desactivar el botón del día correspondiente
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

        private void EnableButtonForDay(int dia)
        {
            // Activar el botón del día correspondiente
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
        private void UpdateButtonsState()
        {
            // Verificar cuántas franjas tiene cada día y activar/desactivar los botones correspondientes
            for (int dia = 1; dia <= TOTAL_DIES; dia++)
            {
                // Comprobar el número de franjas para cada día
                if (franjasPerDia[dia].Count >= MAX_FRANJAS)
                {
                    // Desactivar el botón de añadir si ya se alcanzó el máximo de franjas
                    DisableButtonForDay(dia);
                }
                else
                {
                    // Si hay menos de 5 franjas, reactivar el botón de añadir
                    EnableButtonForDay(dia);
                }

                // Activar/desactivar el botón de eliminar dependiendo de si hay franjas
                if (franjasPerDia[dia].Count == 0)
                {
                    // Desactivar el botón de eliminar si no hay franjas
                    DisableDeleteButtonForDay(dia);
                }
                else
                {
                    // Activar el botón de eliminar si hay franjas
                    EnableDeleteButtonForDay(dia);
                }
            }
        }

        private void DisableDeleteButtonForDay(int dia)
        {
            // Desactivar el botón de eliminar para el día correspondiente
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

        private void EnableDeleteButtonForDay(int dia)
        {
            // Activar el botón de eliminar para el día correspondiente
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


        private void LoadData()
        {
            for (int dia = 1; dia <= TOTAL_DIES; dia++)
            {
                List<Horari> horaris = _horariService.GetHorarisDia(dia);

                foreach (var h in horaris)
                {
                    AddFranjaVisual(dia);

                    var franja = franjasPerDia[dia][franjasPerDia[dia].Count - 1];
                    franja.pickerInici.Value = DateTime.Today.Add(h.hora_inici);
                    franja.pickerFinal.Value = DateTime.Today.Add(h.hora_final);
                }
            }
        }

        private void ButtonConfigurarHorari_Click(object sender, EventArgs e)
        {
            var totsElsHoraris = new List<Horari>();

            for (int dia = 1; dia <= TOTAL_DIES; dia++)
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

                    totsElsHoraris.Add(new Horari
                    {
                        dia = dia,
                        hora_inici = inici,
                        hora_final = fi
                    });
                }
            }

            // Llamamos al nuevo método para guardar todos los horarios
            bool result = _horariService.SetHoraris(totsElsHoraris);

            if (result)
            {
                MessageBox.Show("Tots els horaris s'han guardat correctament.");
            }
            else
            {
                MessageBox.Show("Error al guardar els horaris.");
            }
        }

    }
}
