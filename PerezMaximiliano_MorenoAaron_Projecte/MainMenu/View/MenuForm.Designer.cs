using System.Drawing;
using System.Windows.Forms;

namespace PerezMaximiliano_MorenoAaron_Projecte.View
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPageConfiguracio = new System.Windows.Forms.TabPage();
            this.materialLabel37 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonConfiguracio_newContrasenya = new MaterialSkin.Controls.MaterialButton();
            this.textBoxConfiguracio_paginaweb = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel18 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_descripcio = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel17 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel16 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_aforament = new MaterialSkin.Controls.MaterialTextBox2();
            this.comboBoxConfiguracio_tipuspreu = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxConfiguracio_tipuscuina = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel14 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_correu = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_carrer = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_codipostal = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_poblacio = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_pais = new MaterialSkin.Controls.MaterialTextBox2();
            this.textBoxConfiguracio_telefon = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_nom = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxConfiguracio_usuari = new MaterialSkin.Controls.MaterialTextBox2();
            this.buttonConfiguracio_editar = new MaterialSkin.Controls.MaterialButton();
            this.buttonConfiguracio_imatgeRestaurant = new System.Windows.Forms.Button();
            this.pictureBoxConfiguracio_imatgeRestaurant = new System.Windows.Forms.PictureBox();
            this.pictureBoxConfiguracio_logo = new System.Windows.Forms.PictureBox();
            this.buttonConfiguracio_logo = new System.Windows.Forms.Button();
            this.tabPageContacte = new System.Windows.Forms.TabPage();
            this.materialLabel50 = new MaterialSkin.Controls.MaterialLabel();
            this.checkBoxContacte_veureLlegits = new MaterialSkin.Controls.MaterialCheckbox();
            this.textBoxContacte_llegits = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxContacte_noLlegits = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel35 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel36 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxContacte_usuari = new System.Windows.Forms.ComboBox();
            this.materialLabel34 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel30 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel29 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonContacte_obrir = new MaterialSkin.Controls.MaterialButton();
            this.textBoxContacte_filtre = new MaterialSkin.Controls.MaterialTextBox();
            this.dateTimePickerContacte_hasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerContacte_desde = new System.Windows.Forms.DateTimePicker();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dataGridViewContacte_missatges = new System.Windows.Forms.DataGridView();
            this.tabPageTaules = new System.Windows.Forms.TabPage();
            this.materialLabel48 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel33 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxTaula_comensals = new MaterialSkin.Controls.MaterialComboBox();
            this.dataGridViewTaula_taules = new System.Windows.Forms.DataGridView();
            this.textBoxTaula_aforamentMaxim = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxTaula_aforamentActual = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonTaula_eliminar = new MaterialSkin.Controls.MaterialButton();
            this.buttonTaula_editar = new MaterialSkin.Controls.MaterialButton();
            this.buttonTaula_afegir = new MaterialSkin.Controls.MaterialButton();
            this.tabPageReserves = new System.Windows.Forms.TabPage();
            this.materialLabel47 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel46 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel45 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel44 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel38 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxReserva_usuari = new System.Windows.Forms.ComboBox();
            this.materialLabel32 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel27 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel28 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonReserva_actualitzar = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel25 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonReserva_enProces = new MaterialSkin.Controls.MaterialButton();
            this.textBoxReserva_idUsuari = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel31 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonReserva_finalitzar = new MaterialSkin.Controls.MaterialButton();
            this.buttonReserva_cancelar = new MaterialSkin.Controls.MaterialButton();
            this.buttonReserva_afegir = new MaterialSkin.Controls.MaterialButton();
            this.textBoxReserva_correuUsuari = new MaterialSkin.Controls.MaterialTextBox2();
            this.textBoxReserva_telefonUsuari = new MaterialSkin.Controls.MaterialTextBox2();
            this.textBoxReserva_cognomsUsuari = new MaterialSkin.Controls.MaterialTextBox2();
            this.textBoxReserva_nomUsuari = new MaterialSkin.Controls.MaterialTextBox2();
            this.comboBoxReserva_estat = new MaterialSkin.Controls.MaterialComboBox();
            this.dateTimePickerReserva_hasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerReserva_desde = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewReserva_reserves = new System.Windows.Forms.DataGridView();
            this.materialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageHorari = new System.Windows.Forms.TabPage();
            this.materialLabel43 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel42 = new MaterialSkin.Controls.MaterialLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelHorari_dilluns = new System.Windows.Forms.Panel();
            this.buttonHorari_addFranjaDilluns = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonHorari_deleteFranjaDilluns = new MaterialSkin.Controls.MaterialButton();
            this.panelHorari_dimarts = new System.Windows.Forms.Panel();
            this.buttonHorari_addFranjaDimarts = new MaterialSkin.Controls.MaterialButton();
            this.buttonHorari_addFranjaDimecres = new MaterialSkin.Controls.MaterialButton();
            this.buttonHorari_addFranjaDijous = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel19 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel20 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel21 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonHorari_deleteFranjaDiumenge = new MaterialSkin.Controls.MaterialButton();
            this.panelHorari_dimecres = new System.Windows.Forms.Panel();
            this.buttonHorari_deleteFranjaDissabte = new MaterialSkin.Controls.MaterialButton();
            this.panelHorari_dijous = new System.Windows.Forms.Panel();
            this.buttonHorari_deleteFranjaDivendres = new MaterialSkin.Controls.MaterialButton();
            this.buttonHorari_deleteFranjaDimarts = new MaterialSkin.Controls.MaterialButton();
            this.panelHorari_divendres = new System.Windows.Forms.Panel();
            this.buttonHorari_deleteFranjaDijous = new MaterialSkin.Controls.MaterialButton();
            this.panelHorari_dissabte = new System.Windows.Forms.Panel();
            this.buttonHorari_deleteFranjaDimecres = new MaterialSkin.Controls.MaterialButton();
            this.panelHorari_diumenge = new System.Windows.Forms.Panel();
            this.buttonHorari_addFranjaDivendres = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel24 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonHorari_addFranjaDiumenge = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel23 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonHorari_addFranjaDissabte = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel22 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel41 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel40 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel39 = new MaterialSkin.Controls.MaterialLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthCalendarHorari_horari = new Pabo.Calendar.MonthCalendar();
            this.buttonHorari_desassignarFestiu = new MaterialSkin.Controls.MaterialButton();
            this.buttonHorari_assignarFestiu = new MaterialSkin.Controls.MaterialButton();
            this.buttonHorari_configurar = new MaterialSkin.Controls.MaterialButton();
            this.tabPagePlats = new System.Windows.Forms.TabPage();
            this.materialLabel49 = new MaterialSkin.Controls.MaterialLabel();
            this.buttonMenu_eliminar = new MaterialSkin.Controls.MaterialButton();
            this.buttonMenu_editar = new MaterialSkin.Controls.MaterialButton();
            this.buttonMenu_afegir = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel26 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxMenu_tipusPlats = new MaterialSkin.Controls.MaterialComboBox();
            this.dataGridViewMenu_plats = new System.Windows.Forms.DataGridView();
            this.buttonMain_tancarSessio = new System.Windows.Forms.Button();
            this.tabPageConfiguracio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfiguracio_imatgeRestaurant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfiguracio_logo)).BeginInit();
            this.tabPageContacte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContacte_missatges)).BeginInit();
            this.tabPageTaules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaula_taules)).BeginInit();
            this.tabPageReserves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReserva_reserves)).BeginInit();
            this.materialTabControl.SuspendLayout();
            this.tabPageHorari.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPagePlats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu_plats)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-cierre-de-sesión-redondeado-hacia-la-izquierda-32.png");
            this.imageList1.Images.SetKeyName(1, "icons8-calendario-32.png");
            this.imageList1.Images.SetKeyName(2, "icons8-ajustes-32.png");
            this.imageList1.Images.SetKeyName(3, "icons8-contacto-32.png");
            this.imageList1.Images.SetKeyName(4, "icons8-mesa-de-restaurante-32.png");
            this.imageList1.Images.SetKeyName(5, "icons8-reserva-2-32.png");
            this.imageList1.Images.SetKeyName(6, "icons8-comida-32.png");
            // 
            // tabPageConfiguracio
            // 
            this.tabPageConfiguracio.BackColor = System.Drawing.Color.White;
            this.tabPageConfiguracio.Controls.Add(this.materialLabel37);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel6);
            this.tabPageConfiguracio.Controls.Add(this.buttonConfiguracio_newContrasenya);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_paginaweb);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel18);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_descripcio);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel17);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel16);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_aforament);
            this.tabPageConfiguracio.Controls.Add(this.comboBoxConfiguracio_tipuspreu);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel15);
            this.tabPageConfiguracio.Controls.Add(this.comboBoxConfiguracio_tipuscuina);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel14);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_correu);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel13);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_carrer);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel12);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_codipostal);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel11);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel10);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_poblacio);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel9);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_pais);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_telefon);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel8);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_nom);
            this.tabPageConfiguracio.Controls.Add(this.materialLabel7);
            this.tabPageConfiguracio.Controls.Add(this.textBoxConfiguracio_usuari);
            this.tabPageConfiguracio.Controls.Add(this.buttonConfiguracio_editar);
            this.tabPageConfiguracio.Controls.Add(this.buttonConfiguracio_imatgeRestaurant);
            this.tabPageConfiguracio.Controls.Add(this.pictureBoxConfiguracio_imatgeRestaurant);
            this.tabPageConfiguracio.Controls.Add(this.pictureBoxConfiguracio_logo);
            this.tabPageConfiguracio.Controls.Add(this.buttonConfiguracio_logo);
            this.tabPageConfiguracio.ImageKey = "icons8-ajustes-32.png";
            this.tabPageConfiguracio.Location = new System.Drawing.Point(4, 39);
            this.tabPageConfiguracio.Name = "tabPageConfiguracio";
            this.tabPageConfiguracio.Size = new System.Drawing.Size(1730, 520);
            this.tabPageConfiguracio.TabIndex = 3;
            this.tabPageConfiguracio.Text = "Configuració";
            this.tabPageConfiguracio.UseVisualStyleBackColor = true;
            // 
            // materialLabel37
            // 
            this.materialLabel37.AutoSize = true;
            this.materialLabel37.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel37.Depth = 0;
            this.materialLabel37.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel37.Location = new System.Drawing.Point(36, 66);
            this.materialLabel37.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel37.Name = "materialLabel37";
            this.materialLabel37.Size = new System.Drawing.Size(46, 19);
            this.materialLabel37.TabIndex = 139;
            this.materialLabel37.Text = "Usuari";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(58, 276);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(197, 19);
            this.materialLabel6.TabIndex = 136;
            this.materialLabel6.Text = "Recomanació: 150 x 150 px";
            // 
            // buttonConfiguracio_newContrasenya
            // 
            this.buttonConfiguracio_newContrasenya.AutoSize = false;
            this.buttonConfiguracio_newContrasenya.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonConfiguracio_newContrasenya.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonConfiguracio_newContrasenya.Depth = 0;
            this.buttonConfiguracio_newContrasenya.HighEmphasis = true;
            this.buttonConfiguracio_newContrasenya.Icon = null;
            this.buttonConfiguracio_newContrasenya.Location = new System.Drawing.Point(80, 152);
            this.buttonConfiguracio_newContrasenya.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonConfiguracio_newContrasenya.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonConfiguracio_newContrasenya.Name = "buttonConfiguracio_newContrasenya";
            this.buttonConfiguracio_newContrasenya.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonConfiguracio_newContrasenya.Size = new System.Drawing.Size(156, 46);
            this.buttonConfiguracio_newContrasenya.TabIndex = 133;
            this.buttonConfiguracio_newContrasenya.Text = "NOVA CONTRASENYA";
            this.buttonConfiguracio_newContrasenya.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonConfiguracio_newContrasenya.UseAccentColor = false;
            this.buttonConfiguracio_newContrasenya.UseVisualStyleBackColor = true;
            // 
            // textBoxConfiguracio_paginaweb
            // 
            this.textBoxConfiguracio_paginaweb.AnimateReadOnly = false;
            this.textBoxConfiguracio_paginaweb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_paginaweb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_paginaweb.Depth = 0;
            this.textBoxConfiguracio_paginaweb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_paginaweb.HideSelection = true;
            this.textBoxConfiguracio_paginaweb.LeadingIcon = null;
            this.textBoxConfiguracio_paginaweb.Location = new System.Drawing.Point(658, 412);
            this.textBoxConfiguracio_paginaweb.MaxLength = 32767;
            this.textBoxConfiguracio_paginaweb.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_paginaweb.Name = "textBoxConfiguracio_paginaweb";
            this.textBoxConfiguracio_paginaweb.PasswordChar = '\0';
            this.textBoxConfiguracio_paginaweb.PrefixSuffixText = null;
            this.textBoxConfiguracio_paginaweb.ReadOnly = false;
            this.textBoxConfiguracio_paginaweb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_paginaweb.SelectedText = "";
            this.textBoxConfiguracio_paginaweb.SelectionLength = 0;
            this.textBoxConfiguracio_paginaweb.SelectionStart = 0;
            this.textBoxConfiguracio_paginaweb.ShortcutsEnabled = true;
            this.textBoxConfiguracio_paginaweb.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_paginaweb.TabIndex = 131;
            this.textBoxConfiguracio_paginaweb.TabStop = false;
            this.textBoxConfiguracio_paginaweb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_paginaweb.TrailingIcon = null;
            this.textBoxConfiguracio_paginaweb.UseSystemPasswordChar = false;
            // 
            // materialLabel18
            // 
            this.materialLabel18.AutoSize = true;
            this.materialLabel18.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel18.Depth = 0;
            this.materialLabel18.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel18.Location = new System.Drawing.Point(657, 390);
            this.materialLabel18.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel18.Name = "materialLabel18";
            this.materialLabel18.Size = new System.Drawing.Size(84, 19);
            this.materialLabel18.TabIndex = 130;
            this.materialLabel18.Text = "Pàgina web";
            // 
            // textBoxConfiguracio_descripcio
            // 
            this.textBoxConfiguracio_descripcio.AnimateReadOnly = false;
            this.textBoxConfiguracio_descripcio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_descripcio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_descripcio.Depth = 0;
            this.textBoxConfiguracio_descripcio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_descripcio.HideSelection = true;
            this.textBoxConfiguracio_descripcio.LeadingIcon = null;
            this.textBoxConfiguracio_descripcio.Location = new System.Drawing.Point(658, 331);
            this.textBoxConfiguracio_descripcio.MaxLength = 32767;
            this.textBoxConfiguracio_descripcio.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_descripcio.Name = "textBoxConfiguracio_descripcio";
            this.textBoxConfiguracio_descripcio.PasswordChar = '\0';
            this.textBoxConfiguracio_descripcio.PrefixSuffixText = null;
            this.textBoxConfiguracio_descripcio.ReadOnly = false;
            this.textBoxConfiguracio_descripcio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_descripcio.SelectedText = "";
            this.textBoxConfiguracio_descripcio.SelectionLength = 0;
            this.textBoxConfiguracio_descripcio.SelectionStart = 0;
            this.textBoxConfiguracio_descripcio.ShortcutsEnabled = true;
            this.textBoxConfiguracio_descripcio.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_descripcio.TabIndex = 129;
            this.textBoxConfiguracio_descripcio.TabStop = false;
            this.textBoxConfiguracio_descripcio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_descripcio.TrailingIcon = null;
            this.textBoxConfiguracio_descripcio.UseSystemPasswordChar = false;
            // 
            // materialLabel17
            // 
            this.materialLabel17.AutoSize = true;
            this.materialLabel17.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel17.Depth = 0;
            this.materialLabel17.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel17.Location = new System.Drawing.Point(657, 309);
            this.materialLabel17.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel17.Name = "materialLabel17";
            this.materialLabel17.Size = new System.Drawing.Size(75, 19);
            this.materialLabel17.TabIndex = 128;
            this.materialLabel17.Text = "Descripció";
            // 
            // materialLabel16
            // 
            this.materialLabel16.AutoSize = true;
            this.materialLabel16.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel16.Depth = 0;
            this.materialLabel16.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel16.Location = new System.Drawing.Point(659, 229);
            this.materialLabel16.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel16.Name = "materialLabel16";
            this.materialLabel16.Size = new System.Drawing.Size(76, 19);
            this.materialLabel16.TabIndex = 127;
            this.materialLabel16.Text = "Aforament";
            // 
            // textBoxConfiguracio_aforament
            // 
            this.textBoxConfiguracio_aforament.AnimateReadOnly = false;
            this.textBoxConfiguracio_aforament.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_aforament.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_aforament.Depth = 0;
            this.textBoxConfiguracio_aforament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_aforament.HideSelection = true;
            this.textBoxConfiguracio_aforament.LeadingIcon = null;
            this.textBoxConfiguracio_aforament.Location = new System.Drawing.Point(660, 247);
            this.textBoxConfiguracio_aforament.MaxLength = 32767;
            this.textBoxConfiguracio_aforament.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_aforament.Name = "textBoxConfiguracio_aforament";
            this.textBoxConfiguracio_aforament.PasswordChar = '\0';
            this.textBoxConfiguracio_aforament.PrefixSuffixText = null;
            this.textBoxConfiguracio_aforament.ReadOnly = false;
            this.textBoxConfiguracio_aforament.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_aforament.SelectedText = "";
            this.textBoxConfiguracio_aforament.SelectionLength = 0;
            this.textBoxConfiguracio_aforament.SelectionStart = 0;
            this.textBoxConfiguracio_aforament.ShortcutsEnabled = true;
            this.textBoxConfiguracio_aforament.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_aforament.TabIndex = 126;
            this.textBoxConfiguracio_aforament.TabStop = false;
            this.textBoxConfiguracio_aforament.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_aforament.TrailingIcon = null;
            this.textBoxConfiguracio_aforament.UseSystemPasswordChar = false;
            // 
            // comboBoxConfiguracio_tipuspreu
            // 
            this.comboBoxConfiguracio_tipuspreu.AutoResize = false;
            this.comboBoxConfiguracio_tipuspreu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxConfiguracio_tipuspreu.Depth = 0;
            this.comboBoxConfiguracio_tipuspreu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxConfiguracio_tipuspreu.DropDownHeight = 174;
            this.comboBoxConfiguracio_tipuspreu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfiguracio_tipuspreu.DropDownWidth = 121;
            this.comboBoxConfiguracio_tipuspreu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxConfiguracio_tipuspreu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxConfiguracio_tipuspreu.FormattingEnabled = true;
            this.comboBoxConfiguracio_tipuspreu.IntegralHeight = false;
            this.comboBoxConfiguracio_tipuspreu.ItemHeight = 43;
            this.comboBoxConfiguracio_tipuspreu.Location = new System.Drawing.Point(974, 89);
            this.comboBoxConfiguracio_tipuspreu.MaxDropDownItems = 4;
            this.comboBoxConfiguracio_tipuspreu.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxConfiguracio_tipuspreu.Name = "comboBoxConfiguracio_tipuspreu";
            this.comboBoxConfiguracio_tipuspreu.Size = new System.Drawing.Size(121, 49);
            this.comboBoxConfiguracio_tipuspreu.StartIndex = 0;
            this.comboBoxConfiguracio_tipuspreu.TabIndex = 125;
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel15.Location = new System.Drawing.Point(972, 67);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(97, 19);
            this.materialLabel15.TabIndex = 124;
            this.materialLabel15.Text = "Tipus de preu";
            // 
            // comboBoxConfiguracio_tipuscuina
            // 
            this.comboBoxConfiguracio_tipuscuina.AutoResize = false;
            this.comboBoxConfiguracio_tipuscuina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxConfiguracio_tipuscuina.Depth = 0;
            this.comboBoxConfiguracio_tipuscuina.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxConfiguracio_tipuscuina.DropDownHeight = 174;
            this.comboBoxConfiguracio_tipuscuina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfiguracio_tipuscuina.DropDownWidth = 121;
            this.comboBoxConfiguracio_tipuscuina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxConfiguracio_tipuscuina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxConfiguracio_tipuscuina.FormattingEnabled = true;
            this.comboBoxConfiguracio_tipuscuina.IntegralHeight = false;
            this.comboBoxConfiguracio_tipuscuina.ItemHeight = 43;
            this.comboBoxConfiguracio_tipuscuina.Location = new System.Drawing.Point(1197, 87);
            this.comboBoxConfiguracio_tipuscuina.MaxDropDownItems = 4;
            this.comboBoxConfiguracio_tipuscuina.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxConfiguracio_tipuscuina.Name = "comboBoxConfiguracio_tipuscuina";
            this.comboBoxConfiguracio_tipuscuina.Size = new System.Drawing.Size(121, 49);
            this.comboBoxConfiguracio_tipuscuina.StartIndex = 0;
            this.comboBoxConfiguracio_tipuscuina.TabIndex = 123;
            // 
            // materialLabel14
            // 
            this.materialLabel14.AutoSize = true;
            this.materialLabel14.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel14.Depth = 0;
            this.materialLabel14.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel14.Location = new System.Drawing.Point(1196, 66);
            this.materialLabel14.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel14.Name = "materialLabel14";
            this.materialLabel14.Size = new System.Drawing.Size(105, 19);
            this.materialLabel14.TabIndex = 122;
            this.materialLabel14.Text = "Tipus de cuina";
            // 
            // textBoxConfiguracio_correu
            // 
            this.textBoxConfiguracio_correu.AnimateReadOnly = false;
            this.textBoxConfiguracio_correu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_correu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_correu.Depth = 0;
            this.textBoxConfiguracio_correu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_correu.HideSelection = true;
            this.textBoxConfiguracio_correu.LeadingIcon = null;
            this.textBoxConfiguracio_correu.Location = new System.Drawing.Point(662, 174);
            this.textBoxConfiguracio_correu.MaxLength = 32767;
            this.textBoxConfiguracio_correu.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_correu.Name = "textBoxConfiguracio_correu";
            this.textBoxConfiguracio_correu.PasswordChar = '\0';
            this.textBoxConfiguracio_correu.PrefixSuffixText = null;
            this.textBoxConfiguracio_correu.ReadOnly = true;
            this.textBoxConfiguracio_correu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_correu.SelectedText = "";
            this.textBoxConfiguracio_correu.SelectionLength = 0;
            this.textBoxConfiguracio_correu.SelectionStart = 0;
            this.textBoxConfiguracio_correu.ShortcutsEnabled = true;
            this.textBoxConfiguracio_correu.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_correu.TabIndex = 121;
            this.textBoxConfiguracio_correu.TabStop = false;
            this.textBoxConfiguracio_correu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_correu.TrailingIcon = null;
            this.textBoxConfiguracio_correu.UseSystemPasswordChar = false;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel13.Location = new System.Drawing.Point(661, 152);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(119, 19);
            this.materialLabel13.TabIndex = 120;
            this.materialLabel13.Text = "Correu electrònic";
            // 
            // textBoxConfiguracio_carrer
            // 
            this.textBoxConfiguracio_carrer.AnimateReadOnly = false;
            this.textBoxConfiguracio_carrer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_carrer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_carrer.Depth = 0;
            this.textBoxConfiguracio_carrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_carrer.HideSelection = true;
            this.textBoxConfiguracio_carrer.LeadingIcon = null;
            this.textBoxConfiguracio_carrer.Location = new System.Drawing.Point(345, 412);
            this.textBoxConfiguracio_carrer.MaxLength = 32767;
            this.textBoxConfiguracio_carrer.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_carrer.Name = "textBoxConfiguracio_carrer";
            this.textBoxConfiguracio_carrer.PasswordChar = '\0';
            this.textBoxConfiguracio_carrer.PrefixSuffixText = null;
            this.textBoxConfiguracio_carrer.ReadOnly = false;
            this.textBoxConfiguracio_carrer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_carrer.SelectedText = "";
            this.textBoxConfiguracio_carrer.SelectionLength = 0;
            this.textBoxConfiguracio_carrer.SelectionStart = 0;
            this.textBoxConfiguracio_carrer.ShortcutsEnabled = true;
            this.textBoxConfiguracio_carrer.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_carrer.TabIndex = 119;
            this.textBoxConfiguracio_carrer.TabStop = false;
            this.textBoxConfiguracio_carrer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_carrer.TrailingIcon = null;
            this.textBoxConfiguracio_carrer.UseSystemPasswordChar = false;
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel12.Location = new System.Drawing.Point(344, 390);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Size = new System.Drawing.Size(43, 19);
            this.materialLabel12.TabIndex = 118;
            this.materialLabel12.Text = "Carrer";
            // 
            // textBoxConfiguracio_codipostal
            // 
            this.textBoxConfiguracio_codipostal.AnimateReadOnly = false;
            this.textBoxConfiguracio_codipostal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_codipostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_codipostal.Depth = 0;
            this.textBoxConfiguracio_codipostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_codipostal.HideSelection = true;
            this.textBoxConfiguracio_codipostal.LeadingIcon = null;
            this.textBoxConfiguracio_codipostal.Location = new System.Drawing.Point(345, 331);
            this.textBoxConfiguracio_codipostal.MaxLength = 32767;
            this.textBoxConfiguracio_codipostal.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_codipostal.Name = "textBoxConfiguracio_codipostal";
            this.textBoxConfiguracio_codipostal.PasswordChar = '\0';
            this.textBoxConfiguracio_codipostal.PrefixSuffixText = null;
            this.textBoxConfiguracio_codipostal.ReadOnly = false;
            this.textBoxConfiguracio_codipostal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_codipostal.SelectedText = "";
            this.textBoxConfiguracio_codipostal.SelectionLength = 0;
            this.textBoxConfiguracio_codipostal.SelectionStart = 0;
            this.textBoxConfiguracio_codipostal.ShortcutsEnabled = true;
            this.textBoxConfiguracio_codipostal.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_codipostal.TabIndex = 117;
            this.textBoxConfiguracio_codipostal.TabStop = false;
            this.textBoxConfiguracio_codipostal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_codipostal.TrailingIcon = null;
            this.textBoxConfiguracio_codipostal.UseSystemPasswordChar = false;
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel11.Location = new System.Drawing.Point(344, 309);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Size = new System.Drawing.Size(81, 19);
            this.materialLabel11.TabIndex = 116;
            this.materialLabel11.Text = "Codi postal";
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel10.Location = new System.Drawing.Point(347, 229);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Size = new System.Drawing.Size(63, 19);
            this.materialLabel10.TabIndex = 115;
            this.materialLabel10.Text = "Població";
            // 
            // textBoxConfiguracio_poblacio
            // 
            this.textBoxConfiguracio_poblacio.AnimateReadOnly = false;
            this.textBoxConfiguracio_poblacio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_poblacio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_poblacio.Depth = 0;
            this.textBoxConfiguracio_poblacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_poblacio.HideSelection = true;
            this.textBoxConfiguracio_poblacio.LeadingIcon = null;
            this.textBoxConfiguracio_poblacio.Location = new System.Drawing.Point(347, 247);
            this.textBoxConfiguracio_poblacio.MaxLength = 32767;
            this.textBoxConfiguracio_poblacio.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_poblacio.Name = "textBoxConfiguracio_poblacio";
            this.textBoxConfiguracio_poblacio.PasswordChar = '\0';
            this.textBoxConfiguracio_poblacio.PrefixSuffixText = null;
            this.textBoxConfiguracio_poblacio.ReadOnly = false;
            this.textBoxConfiguracio_poblacio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_poblacio.SelectedText = "";
            this.textBoxConfiguracio_poblacio.SelectionLength = 0;
            this.textBoxConfiguracio_poblacio.SelectionStart = 0;
            this.textBoxConfiguracio_poblacio.ShortcutsEnabled = true;
            this.textBoxConfiguracio_poblacio.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_poblacio.TabIndex = 114;
            this.textBoxConfiguracio_poblacio.TabStop = false;
            this.textBoxConfiguracio_poblacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_poblacio.TrailingIcon = null;
            this.textBoxConfiguracio_poblacio.UseSystemPasswordChar = false;
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel9.Location = new System.Drawing.Point(347, 152);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Size = new System.Drawing.Size(32, 19);
            this.materialLabel9.TabIndex = 113;
            this.materialLabel9.Text = "Pais";
            // 
            // textBoxConfiguracio_pais
            // 
            this.textBoxConfiguracio_pais.AnimateReadOnly = false;
            this.textBoxConfiguracio_pais.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_pais.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_pais.Depth = 0;
            this.textBoxConfiguracio_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_pais.HideSelection = true;
            this.textBoxConfiguracio_pais.LeadingIcon = null;
            this.textBoxConfiguracio_pais.Location = new System.Drawing.Point(347, 170);
            this.textBoxConfiguracio_pais.MaxLength = 32767;
            this.textBoxConfiguracio_pais.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_pais.Name = "textBoxConfiguracio_pais";
            this.textBoxConfiguracio_pais.PasswordChar = '\0';
            this.textBoxConfiguracio_pais.PrefixSuffixText = null;
            this.textBoxConfiguracio_pais.ReadOnly = false;
            this.textBoxConfiguracio_pais.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_pais.SelectedText = "";
            this.textBoxConfiguracio_pais.SelectionLength = 0;
            this.textBoxConfiguracio_pais.SelectionStart = 0;
            this.textBoxConfiguracio_pais.ShortcutsEnabled = true;
            this.textBoxConfiguracio_pais.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_pais.TabIndex = 112;
            this.textBoxConfiguracio_pais.TabStop = false;
            this.textBoxConfiguracio_pais.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_pais.TrailingIcon = null;
            this.textBoxConfiguracio_pais.UseSystemPasswordChar = false;
            // 
            // textBoxConfiguracio_telefon
            // 
            this.textBoxConfiguracio_telefon.AnimateReadOnly = false;
            this.textBoxConfiguracio_telefon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_telefon.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_telefon.Depth = 0;
            this.textBoxConfiguracio_telefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_telefon.HideSelection = true;
            this.textBoxConfiguracio_telefon.LeadingIcon = null;
            this.textBoxConfiguracio_telefon.Location = new System.Drawing.Point(662, 88);
            this.textBoxConfiguracio_telefon.MaxLength = 32767;
            this.textBoxConfiguracio_telefon.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_telefon.Name = "textBoxConfiguracio_telefon";
            this.textBoxConfiguracio_telefon.PasswordChar = '\0';
            this.textBoxConfiguracio_telefon.PrefixSuffixText = null;
            this.textBoxConfiguracio_telefon.ReadOnly = false;
            this.textBoxConfiguracio_telefon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_telefon.SelectedText = "";
            this.textBoxConfiguracio_telefon.SelectionLength = 0;
            this.textBoxConfiguracio_telefon.SelectionStart = 0;
            this.textBoxConfiguracio_telefon.ShortcutsEnabled = true;
            this.textBoxConfiguracio_telefon.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_telefon.TabIndex = 111;
            this.textBoxConfiguracio_telefon.TabStop = false;
            this.textBoxConfiguracio_telefon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_telefon.TrailingIcon = null;
            this.textBoxConfiguracio_telefon.UseSystemPasswordChar = false;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.Location = new System.Drawing.Point(661, 67);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(55, 19);
            this.materialLabel8.TabIndex = 110;
            this.materialLabel8.Text = "Telèfon";
            // 
            // textBoxConfiguracio_nom
            // 
            this.textBoxConfiguracio_nom.AnimateReadOnly = false;
            this.textBoxConfiguracio_nom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_nom.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_nom.Depth = 0;
            this.textBoxConfiguracio_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_nom.HideSelection = true;
            this.textBoxConfiguracio_nom.LeadingIcon = null;
            this.textBoxConfiguracio_nom.Location = new System.Drawing.Point(345, 88);
            this.textBoxConfiguracio_nom.MaxLength = 32767;
            this.textBoxConfiguracio_nom.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_nom.Name = "textBoxConfiguracio_nom";
            this.textBoxConfiguracio_nom.PasswordChar = '\0';
            this.textBoxConfiguracio_nom.PrefixSuffixText = null;
            this.textBoxConfiguracio_nom.ReadOnly = false;
            this.textBoxConfiguracio_nom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_nom.SelectedText = "";
            this.textBoxConfiguracio_nom.SelectionLength = 0;
            this.textBoxConfiguracio_nom.SelectionStart = 0;
            this.textBoxConfiguracio_nom.ShortcutsEnabled = true;
            this.textBoxConfiguracio_nom.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_nom.TabIndex = 109;
            this.textBoxConfiguracio_nom.TabStop = false;
            this.textBoxConfiguracio_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_nom.TrailingIcon = null;
            this.textBoxConfiguracio_nom.UseSystemPasswordChar = false;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(347, 67);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(35, 19);
            this.materialLabel7.TabIndex = 108;
            this.materialLabel7.Text = "Nom";
            // 
            // textBoxConfiguracio_usuari
            // 
            this.textBoxConfiguracio_usuari.AnimateReadOnly = false;
            this.textBoxConfiguracio_usuari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxConfiguracio_usuari.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxConfiguracio_usuari.Depth = 0;
            this.textBoxConfiguracio_usuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfiguracio_usuari.HideSelection = true;
            this.textBoxConfiguracio_usuari.LeadingIcon = null;
            this.textBoxConfiguracio_usuari.Location = new System.Drawing.Point(38, 87);
            this.textBoxConfiguracio_usuari.MaxLength = 32767;
            this.textBoxConfiguracio_usuari.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfiguracio_usuari.Name = "textBoxConfiguracio_usuari";
            this.textBoxConfiguracio_usuari.PasswordChar = '\0';
            this.textBoxConfiguracio_usuari.PrefixSuffixText = null;
            this.textBoxConfiguracio_usuari.ReadOnly = false;
            this.textBoxConfiguracio_usuari.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxConfiguracio_usuari.SelectedText = "";
            this.textBoxConfiguracio_usuari.SelectionLength = 0;
            this.textBoxConfiguracio_usuari.SelectionStart = 0;
            this.textBoxConfiguracio_usuari.ShortcutsEnabled = true;
            this.textBoxConfiguracio_usuari.Size = new System.Drawing.Size(239, 48);
            this.textBoxConfiguracio_usuari.TabIndex = 104;
            this.textBoxConfiguracio_usuari.TabStop = false;
            this.textBoxConfiguracio_usuari.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxConfiguracio_usuari.TrailingIcon = null;
            this.textBoxConfiguracio_usuari.UseSystemPasswordChar = false;
            // 
            // buttonConfiguracio_editar
            // 
            this.buttonConfiguracio_editar.AutoSize = false;
            this.buttonConfiguracio_editar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonConfiguracio_editar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonConfiguracio_editar.Depth = 0;
            this.buttonConfiguracio_editar.HighEmphasis = true;
            this.buttonConfiguracio_editar.Icon = null;
            this.buttonConfiguracio_editar.Location = new System.Drawing.Point(1508, 247);
            this.buttonConfiguracio_editar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonConfiguracio_editar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonConfiguracio_editar.Name = "buttonConfiguracio_editar";
            this.buttonConfiguracio_editar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonConfiguracio_editar.Size = new System.Drawing.Size(120, 46);
            this.buttonConfiguracio_editar.TabIndex = 83;
            this.buttonConfiguracio_editar.Text = "GUARDAR CONFIGURACIÓ";
            this.buttonConfiguracio_editar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonConfiguracio_editar.UseAccentColor = false;
            this.buttonConfiguracio_editar.UseVisualStyleBackColor = true;
            // 
            // buttonConfiguracio_imatgeRestaurant
            // 
            this.buttonConfiguracio_imatgeRestaurant.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfiguracio_imatgeRestaurant.Image")));
            this.buttonConfiguracio_imatgeRestaurant.Location = new System.Drawing.Point(1440, 89);
            this.buttonConfiguracio_imatgeRestaurant.Name = "buttonConfiguracio_imatgeRestaurant";
            this.buttonConfiguracio_imatgeRestaurant.Size = new System.Drawing.Size(35, 35);
            this.buttonConfiguracio_imatgeRestaurant.TabIndex = 138;
            this.buttonConfiguracio_imatgeRestaurant.UseVisualStyleBackColor = true;
            // 
            // pictureBoxConfiguracio_imatgeRestaurant
            // 
            this.pictureBoxConfiguracio_imatgeRestaurant.Location = new System.Drawing.Point(974, 160);
            this.pictureBoxConfiguracio_imatgeRestaurant.Name = "pictureBoxConfiguracio_imatgeRestaurant";
            this.pictureBoxConfiguracio_imatgeRestaurant.Size = new System.Drawing.Size(500, 300);
            this.pictureBoxConfiguracio_imatgeRestaurant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxConfiguracio_imatgeRestaurant.TabIndex = 137;
            this.pictureBoxConfiguracio_imatgeRestaurant.TabStop = false;
            // 
            // pictureBoxConfiguracio_logo
            // 
            this.pictureBoxConfiguracio_logo.Location = new System.Drawing.Point(80, 309);
            this.pictureBoxConfiguracio_logo.Name = "pictureBoxConfiguracio_logo";
            this.pictureBoxConfiguracio_logo.Size = new System.Drawing.Size(156, 156);
            this.pictureBoxConfiguracio_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxConfiguracio_logo.TabIndex = 102;
            this.pictureBoxConfiguracio_logo.TabStop = false;
            // 
            // buttonConfiguracio_logo
            // 
            this.buttonConfiguracio_logo.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfiguracio_logo.Image")));
            this.buttonConfiguracio_logo.Location = new System.Drawing.Point(138, 238);
            this.buttonConfiguracio_logo.Name = "buttonConfiguracio_logo";
            this.buttonConfiguracio_logo.Size = new System.Drawing.Size(35, 35);
            this.buttonConfiguracio_logo.TabIndex = 82;
            this.buttonConfiguracio_logo.UseVisualStyleBackColor = true;
            // 
            // tabPageContacte
            // 
            this.tabPageContacte.BackColor = System.Drawing.Color.White;
            this.tabPageContacte.Controls.Add(this.materialLabel50);
            this.tabPageContacte.Controls.Add(this.checkBoxContacte_veureLlegits);
            this.tabPageContacte.Controls.Add(this.textBoxContacte_llegits);
            this.tabPageContacte.Controls.Add(this.textBoxContacte_noLlegits);
            this.tabPageContacte.Controls.Add(this.materialLabel35);
            this.tabPageContacte.Controls.Add(this.materialLabel36);
            this.tabPageContacte.Controls.Add(this.comboBoxContacte_usuari);
            this.tabPageContacte.Controls.Add(this.materialLabel34);
            this.tabPageContacte.Controls.Add(this.materialLabel30);
            this.tabPageContacte.Controls.Add(this.materialLabel29);
            this.tabPageContacte.Controls.Add(this.buttonContacte_obrir);
            this.tabPageContacte.Controls.Add(this.textBoxContacte_filtre);
            this.tabPageContacte.Controls.Add(this.dateTimePickerContacte_hasta);
            this.tabPageContacte.Controls.Add(this.dateTimePickerContacte_desde);
            this.tabPageContacte.Controls.Add(this.materialLabel2);
            this.tabPageContacte.Controls.Add(this.dataGridViewContacte_missatges);
            this.tabPageContacte.ImageKey = "icons8-contacto-32.png";
            this.tabPageContacte.Location = new System.Drawing.Point(4, 39);
            this.tabPageContacte.Name = "tabPageContacte";
            this.tabPageContacte.Size = new System.Drawing.Size(1730, 520);
            this.tabPageContacte.TabIndex = 2;
            this.tabPageContacte.Text = "Contacte";
            // 
            // materialLabel50
            // 
            this.materialLabel50.AutoSize = true;
            this.materialLabel50.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel50.Depth = 0;
            this.materialLabel50.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel50.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel50.Location = new System.Drawing.Point(176, 42);
            this.materialLabel50.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel50.Name = "materialLabel50";
            this.materialLabel50.Size = new System.Drawing.Size(111, 24);
            this.materialLabel50.TabIndex = 208;
            this.materialLabel50.Text = "MISSATGES";
            // 
            // checkBoxContacte_veureLlegits
            // 
            this.checkBoxContacte_veureLlegits.AutoSize = true;
            this.checkBoxContacte_veureLlegits.Depth = 0;
            this.checkBoxContacte_veureLlegits.Location = new System.Drawing.Point(640, 91);
            this.checkBoxContacte_veureLlegits.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxContacte_veureLlegits.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxContacte_veureLlegits.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxContacte_veureLlegits.Name = "checkBoxContacte_veureLlegits";
            this.checkBoxContacte_veureLlegits.ReadOnly = false;
            this.checkBoxContacte_veureLlegits.Ripple = true;
            this.checkBoxContacte_veureLlegits.Size = new System.Drawing.Size(101, 37);
            this.checkBoxContacte_veureLlegits.TabIndex = 130;
            this.checkBoxContacte_veureLlegits.Text = "No llegits";
            this.checkBoxContacte_veureLlegits.UseVisualStyleBackColor = true;
            // 
            // textBoxContacte_llegits
            // 
            this.textBoxContacte_llegits.AnimateReadOnly = true;
            this.textBoxContacte_llegits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxContacte_llegits.Depth = 0;
            this.textBoxContacte_llegits.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxContacte_llegits.LeadingIcon = null;
            this.textBoxContacte_llegits.Location = new System.Drawing.Point(1382, 312);
            this.textBoxContacte_llegits.MaxLength = 50;
            this.textBoxContacte_llegits.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxContacte_llegits.Multiline = false;
            this.textBoxContacte_llegits.Name = "textBoxContacte_llegits";
            this.textBoxContacte_llegits.ReadOnly = true;
            this.textBoxContacte_llegits.Size = new System.Drawing.Size(100, 50);
            this.textBoxContacte_llegits.TabIndex = 129;
            this.textBoxContacte_llegits.Text = "";
            this.textBoxContacte_llegits.TrailingIcon = null;
            // 
            // textBoxContacte_noLlegits
            // 
            this.textBoxContacte_noLlegits.AnimateReadOnly = true;
            this.textBoxContacte_noLlegits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxContacte_noLlegits.Depth = 0;
            this.textBoxContacte_noLlegits.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxContacte_noLlegits.LeadingIcon = null;
            this.textBoxContacte_noLlegits.Location = new System.Drawing.Point(1382, 239);
            this.textBoxContacte_noLlegits.MaxLength = 50;
            this.textBoxContacte_noLlegits.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxContacte_noLlegits.Multiline = false;
            this.textBoxContacte_noLlegits.Name = "textBoxContacte_noLlegits";
            this.textBoxContacte_noLlegits.ReadOnly = true;
            this.textBoxContacte_noLlegits.Size = new System.Drawing.Size(100, 50);
            this.textBoxContacte_noLlegits.TabIndex = 128;
            this.textBoxContacte_noLlegits.Text = "";
            this.textBoxContacte_noLlegits.TrailingIcon = null;
            // 
            // materialLabel35
            // 
            this.materialLabel35.AutoSize = true;
            this.materialLabel35.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel35.Depth = 0;
            this.materialLabel35.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel35.Location = new System.Drawing.Point(1287, 329);
            this.materialLabel35.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel35.Name = "materialLabel35";
            this.materialLabel35.Size = new System.Drawing.Size(63, 19);
            this.materialLabel35.TabIndex = 127;
            this.materialLabel35.Text = "LLEGITS";
            // 
            // materialLabel36
            // 
            this.materialLabel36.AutoSize = true;
            this.materialLabel36.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel36.Depth = 0;
            this.materialLabel36.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel36.Location = new System.Drawing.Point(1287, 257);
            this.materialLabel36.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel36.Name = "materialLabel36";
            this.materialLabel36.Size = new System.Drawing.Size(89, 19);
            this.materialLabel36.TabIndex = 126;
            this.materialLabel36.Text = "NO LLEGITS";
            // 
            // comboBoxContacte_usuari
            // 
            this.comboBoxContacte_usuari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxContacte_usuari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxContacte_usuari.FormattingEnabled = true;
            this.comboBoxContacte_usuari.Location = new System.Drawing.Point(889, 115);
            this.comboBoxContacte_usuari.Name = "comboBoxContacte_usuari";
            this.comboBoxContacte_usuari.Size = new System.Drawing.Size(121, 21);
            this.comboBoxContacte_usuari.TabIndex = 125;
            // 
            // materialLabel34
            // 
            this.materialLabel34.AutoSize = true;
            this.materialLabel34.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel34.Depth = 0;
            this.materialLabel34.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel34.Location = new System.Drawing.Point(833, 115);
            this.materialLabel34.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel34.Name = "materialLabel34";
            this.materialLabel34.Size = new System.Drawing.Size(50, 19);
            this.materialLabel34.TabIndex = 124;
            this.materialLabel34.Text = "Usuari:";
            // 
            // materialLabel30
            // 
            this.materialLabel30.AutoSize = true;
            this.materialLabel30.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel30.Depth = 0;
            this.materialLabel30.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel30.Location = new System.Drawing.Point(1142, 88);
            this.materialLabel30.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel30.Name = "materialLabel30";
            this.materialLabel30.Size = new System.Drawing.Size(44, 19);
            this.materialLabel30.TabIndex = 102;
            this.materialLabel30.Text = "Fins a";
            // 
            // materialLabel29
            // 
            this.materialLabel29.AutoSize = true;
            this.materialLabel29.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel29.Depth = 0;
            this.materialLabel29.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel29.Location = new System.Drawing.Point(1015, 88);
            this.materialLabel29.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel29.Name = "materialLabel29";
            this.materialLabel29.Size = new System.Drawing.Size(49, 19);
            this.materialLabel29.TabIndex = 101;
            this.materialLabel29.Text = "Des de";
            // 
            // buttonContacte_obrir
            // 
            this.buttonContacte_obrir.AutoSize = false;
            this.buttonContacte_obrir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonContacte_obrir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonContacte_obrir.Depth = 0;
            this.buttonContacte_obrir.HighEmphasis = true;
            this.buttonContacte_obrir.Icon = null;
            this.buttonContacte_obrir.Location = new System.Drawing.Point(1143, 55);
            this.buttonContacte_obrir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonContacte_obrir.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonContacte_obrir.Name = "buttonContacte_obrir";
            this.buttonContacte_obrir.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonContacte_obrir.Size = new System.Drawing.Size(121, 20);
            this.buttonContacte_obrir.TabIndex = 98;
            this.buttonContacte_obrir.Text = "OBRIR";
            this.buttonContacte_obrir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonContacte_obrir.UseAccentColor = false;
            this.buttonContacte_obrir.UseVisualStyleBackColor = true;
            // 
            // textBoxContacte_filtre
            // 
            this.textBoxContacte_filtre.AnimateReadOnly = false;
            this.textBoxContacte_filtre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxContacte_filtre.Depth = 0;
            this.textBoxContacte_filtre.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxContacte_filtre.LeadingIcon = null;
            this.textBoxContacte_filtre.Location = new System.Drawing.Point(293, 86);
            this.textBoxContacte_filtre.MaxLength = 50;
            this.textBoxContacte_filtre.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxContacte_filtre.Multiline = false;
            this.textBoxContacte_filtre.Name = "textBoxContacte_filtre";
            this.textBoxContacte_filtre.Size = new System.Drawing.Size(344, 50);
            this.textBoxContacte_filtre.TabIndex = 97;
            this.textBoxContacte_filtre.Text = "";
            this.textBoxContacte_filtre.TrailingIcon = null;
            // 
            // dateTimePickerContacte_hasta
            // 
            this.dateTimePickerContacte_hasta.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerContacte_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerContacte_hasta.Location = new System.Drawing.Point(1143, 116);
            this.dateTimePickerContacte_hasta.Name = "dateTimePickerContacte_hasta";
            this.dateTimePickerContacte_hasta.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerContacte_hasta.TabIndex = 100;
            // 
            // dateTimePickerContacte_desde
            // 
            this.dateTimePickerContacte_desde.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerContacte_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerContacte_desde.Location = new System.Drawing.Point(1016, 116);
            this.dateTimePickerContacte_desde.Name = "dateTimePickerContacte_desde";
            this.dateTimePickerContacte_desde.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerContacte_desde.TabIndex = 99;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel2.Location = new System.Drawing.Point(177, 100);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(110, 17);
            this.materialLabel2.TabIndex = 96;
            this.materialLabel2.Text = "Filtrar assumpte:";
            // 
            // dataGridViewContacte_missatges
            // 
            this.dataGridViewContacte_missatges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewContacte_missatges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContacte_missatges.Location = new System.Drawing.Point(179, 142);
            this.dataGridViewContacte_missatges.MultiSelect = false;
            this.dataGridViewContacte_missatges.Name = "dataGridViewContacte_missatges";
            this.dataGridViewContacte_missatges.ReadOnly = true;
            this.dataGridViewContacte_missatges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContacte_missatges.Size = new System.Drawing.Size(1085, 345);
            this.dataGridViewContacte_missatges.TabIndex = 63;
            // 
            // tabPageTaules
            // 
            this.tabPageTaules.BackColor = System.Drawing.Color.White;
            this.tabPageTaules.Controls.Add(this.materialLabel48);
            this.tabPageTaules.Controls.Add(this.materialLabel33);
            this.tabPageTaules.Controls.Add(this.comboBoxTaula_comensals);
            this.tabPageTaules.Controls.Add(this.dataGridViewTaula_taules);
            this.tabPageTaules.Controls.Add(this.textBoxTaula_aforamentMaxim);
            this.tabPageTaules.Controls.Add(this.textBoxTaula_aforamentActual);
            this.tabPageTaules.Controls.Add(this.materialLabel1);
            this.tabPageTaules.Controls.Add(this.materialLabel5);
            this.tabPageTaules.Controls.Add(this.buttonTaula_eliminar);
            this.tabPageTaules.Controls.Add(this.buttonTaula_editar);
            this.tabPageTaules.Controls.Add(this.buttonTaula_afegir);
            this.tabPageTaules.ImageKey = "icons8-mesa-de-restaurante-32.png";
            this.tabPageTaules.Location = new System.Drawing.Point(4, 39);
            this.tabPageTaules.Name = "tabPageTaules";
            this.tabPageTaules.Size = new System.Drawing.Size(1730, 520);
            this.tabPageTaules.TabIndex = 1;
            this.tabPageTaules.Text = "Taules";
            // 
            // materialLabel48
            // 
            this.materialLabel48.AutoSize = true;
            this.materialLabel48.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel48.Depth = 0;
            this.materialLabel48.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel48.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel48.Location = new System.Drawing.Point(411, 92);
            this.materialLabel48.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel48.Name = "materialLabel48";
            this.materialLabel48.Size = new System.Drawing.Size(73, 24);
            this.materialLabel48.TabIndex = 207;
            this.materialLabel48.Text = "TAULES";
            // 
            // materialLabel33
            // 
            this.materialLabel33.AutoSize = true;
            this.materialLabel33.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel33.Depth = 0;
            this.materialLabel33.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel33.Location = new System.Drawing.Point(712, 92);
            this.materialLabel33.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel33.Name = "materialLabel33";
            this.materialLabel33.Size = new System.Drawing.Size(163, 19);
            this.materialLabel33.TabIndex = 119;
            this.materialLabel33.Text = "Número de comensals:";
            // 
            // comboBoxTaula_comensals
            // 
            this.comboBoxTaula_comensals.AutoResize = false;
            this.comboBoxTaula_comensals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxTaula_comensals.Depth = 0;
            this.comboBoxTaula_comensals.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxTaula_comensals.DropDownHeight = 174;
            this.comboBoxTaula_comensals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTaula_comensals.DropDownWidth = 121;
            this.comboBoxTaula_comensals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxTaula_comensals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxTaula_comensals.FormattingEnabled = true;
            this.comboBoxTaula_comensals.IntegralHeight = false;
            this.comboBoxTaula_comensals.ItemHeight = 43;
            this.comboBoxTaula_comensals.Location = new System.Drawing.Point(881, 77);
            this.comboBoxTaula_comensals.MaxDropDownItems = 4;
            this.comboBoxTaula_comensals.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxTaula_comensals.Name = "comboBoxTaula_comensals";
            this.comboBoxTaula_comensals.Size = new System.Drawing.Size(187, 49);
            this.comboBoxTaula_comensals.StartIndex = 0;
            this.comboBoxTaula_comensals.TabIndex = 118;
            // 
            // dataGridViewTaula_taules
            // 
            this.dataGridViewTaula_taules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTaula_taules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaula_taules.Location = new System.Drawing.Point(415, 132);
            this.dataGridViewTaula_taules.Name = "dataGridViewTaula_taules";
            this.dataGridViewTaula_taules.ReadOnly = true;
            this.dataGridViewTaula_taules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTaula_taules.Size = new System.Drawing.Size(653, 262);
            this.dataGridViewTaula_taules.TabIndex = 84;
            // 
            // textBoxTaula_aforamentMaxim
            // 
            this.textBoxTaula_aforamentMaxim.AnimateReadOnly = true;
            this.textBoxTaula_aforamentMaxim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTaula_aforamentMaxim.Depth = 0;
            this.textBoxTaula_aforamentMaxim.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxTaula_aforamentMaxim.LeadingIcon = null;
            this.textBoxTaula_aforamentMaxim.Location = new System.Drawing.Point(968, 456);
            this.textBoxTaula_aforamentMaxim.MaxLength = 50;
            this.textBoxTaula_aforamentMaxim.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxTaula_aforamentMaxim.Multiline = false;
            this.textBoxTaula_aforamentMaxim.Name = "textBoxTaula_aforamentMaxim";
            this.textBoxTaula_aforamentMaxim.ReadOnly = true;
            this.textBoxTaula_aforamentMaxim.Size = new System.Drawing.Size(100, 50);
            this.textBoxTaula_aforamentMaxim.TabIndex = 83;
            this.textBoxTaula_aforamentMaxim.Text = "";
            this.textBoxTaula_aforamentMaxim.TrailingIcon = null;
            // 
            // textBoxTaula_aforamentActual
            // 
            this.textBoxTaula_aforamentActual.AnimateReadOnly = true;
            this.textBoxTaula_aforamentActual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTaula_aforamentActual.Depth = 0;
            this.textBoxTaula_aforamentActual.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxTaula_aforamentActual.LeadingIcon = null;
            this.textBoxTaula_aforamentActual.Location = new System.Drawing.Point(968, 400);
            this.textBoxTaula_aforamentActual.MaxLength = 50;
            this.textBoxTaula_aforamentActual.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxTaula_aforamentActual.Multiline = false;
            this.textBoxTaula_aforamentActual.Name = "textBoxTaula_aforamentActual";
            this.textBoxTaula_aforamentActual.ReadOnly = true;
            this.textBoxTaula_aforamentActual.Size = new System.Drawing.Size(100, 50);
            this.textBoxTaula_aforamentActual.TabIndex = 82;
            this.textBoxTaula_aforamentActual.Text = "";
            this.textBoxTaula_aforamentActual.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(804, 471);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(151, 19);
            this.materialLabel1.TabIndex = 81;
            this.materialLabel1.Text = "AFORAMENT MÀXIM";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(804, 415);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(158, 19);
            this.materialLabel5.TabIndex = 80;
            this.materialLabel5.Text = "AFORAMENT ACTUAL";
            // 
            // buttonTaula_eliminar
            // 
            this.buttonTaula_eliminar.AutoSize = false;
            this.buttonTaula_eliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonTaula_eliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonTaula_eliminar.Depth = 0;
            this.buttonTaula_eliminar.HighEmphasis = true;
            this.buttonTaula_eliminar.Icon = null;
            this.buttonTaula_eliminar.Location = new System.Drawing.Point(954, 48);
            this.buttonTaula_eliminar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonTaula_eliminar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonTaula_eliminar.Name = "buttonTaula_eliminar";
            this.buttonTaula_eliminar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonTaula_eliminar.Size = new System.Drawing.Size(114, 20);
            this.buttonTaula_eliminar.TabIndex = 79;
            this.buttonTaula_eliminar.Text = "ELIMINAR";
            this.buttonTaula_eliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonTaula_eliminar.UseAccentColor = false;
            this.buttonTaula_eliminar.UseVisualStyleBackColor = true;
            // 
            // buttonTaula_editar
            // 
            this.buttonTaula_editar.AutoSize = false;
            this.buttonTaula_editar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonTaula_editar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonTaula_editar.Depth = 0;
            this.buttonTaula_editar.HighEmphasis = true;
            this.buttonTaula_editar.Icon = null;
            this.buttonTaula_editar.Location = new System.Drawing.Point(832, 48);
            this.buttonTaula_editar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonTaula_editar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonTaula_editar.Name = "buttonTaula_editar";
            this.buttonTaula_editar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonTaula_editar.Size = new System.Drawing.Size(114, 20);
            this.buttonTaula_editar.TabIndex = 78;
            this.buttonTaula_editar.Text = "MODIFICAR";
            this.buttonTaula_editar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonTaula_editar.UseAccentColor = false;
            this.buttonTaula_editar.UseVisualStyleBackColor = true;
            // 
            // buttonTaula_afegir
            // 
            this.buttonTaula_afegir.AutoSize = false;
            this.buttonTaula_afegir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonTaula_afegir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonTaula_afegir.Depth = 0;
            this.buttonTaula_afegir.HighEmphasis = true;
            this.buttonTaula_afegir.Icon = null;
            this.buttonTaula_afegir.Location = new System.Drawing.Point(715, 48);
            this.buttonTaula_afegir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonTaula_afegir.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonTaula_afegir.Name = "buttonTaula_afegir";
            this.buttonTaula_afegir.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonTaula_afegir.Size = new System.Drawing.Size(109, 20);
            this.buttonTaula_afegir.TabIndex = 77;
            this.buttonTaula_afegir.Text = "AFEGIR";
            this.buttonTaula_afegir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonTaula_afegir.UseAccentColor = false;
            this.buttonTaula_afegir.UseVisualStyleBackColor = true;
            // 
            // tabPageReserves
            // 
            this.tabPageReserves.BackColor = System.Drawing.Color.White;
            this.tabPageReserves.Controls.Add(this.materialLabel47);
            this.tabPageReserves.Controls.Add(this.materialLabel46);
            this.tabPageReserves.Controls.Add(this.materialLabel45);
            this.tabPageReserves.Controls.Add(this.materialLabel44);
            this.tabPageReserves.Controls.Add(this.materialLabel38);
            this.tabPageReserves.Controls.Add(this.materialLabel3);
            this.tabPageReserves.Controls.Add(this.comboBoxReserva_usuari);
            this.tabPageReserves.Controls.Add(this.materialLabel32);
            this.tabPageReserves.Controls.Add(this.materialLabel27);
            this.tabPageReserves.Controls.Add(this.materialLabel28);
            this.tabPageReserves.Controls.Add(this.buttonReserva_actualitzar);
            this.tabPageReserves.Controls.Add(this.materialLabel25);
            this.tabPageReserves.Controls.Add(this.buttonReserva_enProces);
            this.tabPageReserves.Controls.Add(this.textBoxReserva_idUsuari);
            this.tabPageReserves.Controls.Add(this.materialLabel31);
            this.tabPageReserves.Controls.Add(this.buttonReserva_finalitzar);
            this.tabPageReserves.Controls.Add(this.buttonReserva_cancelar);
            this.tabPageReserves.Controls.Add(this.buttonReserva_afegir);
            this.tabPageReserves.Controls.Add(this.textBoxReserva_correuUsuari);
            this.tabPageReserves.Controls.Add(this.textBoxReserva_telefonUsuari);
            this.tabPageReserves.Controls.Add(this.textBoxReserva_cognomsUsuari);
            this.tabPageReserves.Controls.Add(this.textBoxReserva_nomUsuari);
            this.tabPageReserves.Controls.Add(this.comboBoxReserva_estat);
            this.tabPageReserves.Controls.Add(this.dateTimePickerReserva_hasta);
            this.tabPageReserves.Controls.Add(this.dateTimePickerReserva_desde);
            this.tabPageReserves.Controls.Add(this.dataGridViewReserva_reserves);
            this.tabPageReserves.ImageKey = "icons8-reserva-2-32.png";
            this.tabPageReserves.Location = new System.Drawing.Point(4, 39);
            this.tabPageReserves.Name = "tabPageReserves";
            this.tabPageReserves.Size = new System.Drawing.Size(1730, 520);
            this.tabPageReserves.TabIndex = 6;
            this.tabPageReserves.Text = "Reserves";
            // 
            // materialLabel47
            // 
            this.materialLabel47.AutoSize = true;
            this.materialLabel47.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel47.Depth = 0;
            this.materialLabel47.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel47.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel47.Location = new System.Drawing.Point(198, 14);
            this.materialLabel47.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel47.Name = "materialLabel47";
            this.materialLabel47.Size = new System.Drawing.Size(95, 24);
            this.materialLabel47.TabIndex = 206;
            this.materialLabel47.Text = "RESERVES";
            // 
            // materialLabel46
            // 
            this.materialLabel46.AutoSize = true;
            this.materialLabel46.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel46.Depth = 0;
            this.materialLabel46.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel46.Location = new System.Drawing.Point(1125, 405);
            this.materialLabel46.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel46.Name = "materialLabel46";
            this.materialLabel46.Size = new System.Drawing.Size(59, 19);
            this.materialLabel46.TabIndex = 128;
            this.materialLabel46.Text = "Telèfon:";
            // 
            // materialLabel45
            // 
            this.materialLabel45.AutoSize = true;
            this.materialLabel45.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel45.Depth = 0;
            this.materialLabel45.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel45.Location = new System.Drawing.Point(1112, 353);
            this.materialLabel45.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel45.Name = "materialLabel45";
            this.materialLabel45.Size = new System.Drawing.Size(73, 19);
            this.materialLabel45.TabIndex = 127;
            this.materialLabel45.Text = "Cognoms:";
            // 
            // materialLabel44
            // 
            this.materialLabel44.AutoSize = true;
            this.materialLabel44.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel44.Depth = 0;
            this.materialLabel44.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel44.Location = new System.Drawing.Point(1145, 298);
            this.materialLabel44.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel44.Name = "materialLabel44";
            this.materialLabel44.Size = new System.Drawing.Size(39, 19);
            this.materialLabel44.TabIndex = 126;
            this.materialLabel44.Text = "Nom:";
            // 
            // materialLabel38
            // 
            this.materialLabel38.AutoSize = true;
            this.materialLabel38.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel38.Depth = 0;
            this.materialLabel38.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel38.Location = new System.Drawing.Point(1134, 241);
            this.materialLabel38.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel38.Name = "materialLabel38";
            this.materialLabel38.Size = new System.Drawing.Size(51, 19);
            this.materialLabel38.TabIndex = 125;
            this.materialLabel38.Text = "Correu:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(1164, 186);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(20, 19);
            this.materialLabel3.TabIndex = 124;
            this.materialLabel3.Text = "ID:";
            // 
            // comboBoxReserva_usuari
            // 
            this.comboBoxReserva_usuari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxReserva_usuari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxReserva_usuari.FormattingEnabled = true;
            this.comboBoxReserva_usuari.Location = new System.Drawing.Point(713, 70);
            this.comboBoxReserva_usuari.Name = "comboBoxReserva_usuari";
            this.comboBoxReserva_usuari.Size = new System.Drawing.Size(121, 21);
            this.comboBoxReserva_usuari.TabIndex = 123;
            // 
            // materialLabel32
            // 
            this.materialLabel32.AutoSize = true;
            this.materialLabel32.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel32.Depth = 0;
            this.materialLabel32.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel32.Location = new System.Drawing.Point(657, 71);
            this.materialLabel32.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel32.Name = "materialLabel32";
            this.materialLabel32.Size = new System.Drawing.Size(50, 19);
            this.materialLabel32.TabIndex = 122;
            this.materialLabel32.Text = "Usuari:";
            // 
            // materialLabel27
            // 
            this.materialLabel27.AutoSize = true;
            this.materialLabel27.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel27.Depth = 0;
            this.materialLabel27.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel27.Location = new System.Drawing.Point(328, 47);
            this.materialLabel27.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel27.Name = "materialLabel27";
            this.materialLabel27.Size = new System.Drawing.Size(44, 19);
            this.materialLabel27.TabIndex = 120;
            this.materialLabel27.Text = "Fins a";
            // 
            // materialLabel28
            // 
            this.materialLabel28.AutoSize = true;
            this.materialLabel28.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel28.Depth = 0;
            this.materialLabel28.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel28.Location = new System.Drawing.Point(199, 47);
            this.materialLabel28.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel28.Name = "materialLabel28";
            this.materialLabel28.Size = new System.Drawing.Size(49, 19);
            this.materialLabel28.TabIndex = 119;
            this.materialLabel28.Text = "Des de";
            // 
            // buttonReserva_actualitzar
            // 
            this.buttonReserva_actualitzar.AutoSize = false;
            this.buttonReserva_actualitzar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReserva_actualitzar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonReserva_actualitzar.Depth = 0;
            this.buttonReserva_actualitzar.Enabled = false;
            this.buttonReserva_actualitzar.HighEmphasis = true;
            this.buttonReserva_actualitzar.Icon = null;
            this.buttonReserva_actualitzar.Location = new System.Drawing.Point(970, 28);
            this.buttonReserva_actualitzar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonReserva_actualitzar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReserva_actualitzar.Name = "buttonReserva_actualitzar";
            this.buttonReserva_actualitzar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonReserva_actualitzar.Size = new System.Drawing.Size(114, 20);
            this.buttonReserva_actualitzar.TabIndex = 118;
            this.buttonReserva_actualitzar.Text = "MODIFICAR";
            this.buttonReserva_actualitzar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonReserva_actualitzar.UseAccentColor = false;
            this.buttonReserva_actualitzar.UseVisualStyleBackColor = true;
            // 
            // materialLabel25
            // 
            this.materialLabel25.AutoSize = true;
            this.materialLabel25.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel25.Depth = 0;
            this.materialLabel25.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel25.Location = new System.Drawing.Point(850, 70);
            this.materialLabel25.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel25.Name = "materialLabel25";
            this.materialLabel25.Size = new System.Drawing.Size(41, 19);
            this.materialLabel25.TabIndex = 117;
            this.materialLabel25.Text = "Estat:";
            // 
            // buttonReserva_enProces
            // 
            this.buttonReserva_enProces.AutoSize = false;
            this.buttonReserva_enProces.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReserva_enProces.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonReserva_enProces.Depth = 0;
            this.buttonReserva_enProces.Enabled = false;
            this.buttonReserva_enProces.HighEmphasis = true;
            this.buttonReserva_enProces.Icon = null;
            this.buttonReserva_enProces.Location = new System.Drawing.Point(726, 494);
            this.buttonReserva_enProces.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonReserva_enProces.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReserva_enProces.Name = "buttonReserva_enProces";
            this.buttonReserva_enProces.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonReserva_enProces.Size = new System.Drawing.Size(114, 20);
            this.buttonReserva_enProces.TabIndex = 116;
            this.buttonReserva_enProces.Text = "EN PROCES";
            this.buttonReserva_enProces.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonReserva_enProces.UseAccentColor = false;
            this.buttonReserva_enProces.UseVisualStyleBackColor = true;
            // 
            // textBoxReserva_idUsuari
            // 
            this.textBoxReserva_idUsuari.AnimateReadOnly = false;
            this.textBoxReserva_idUsuari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxReserva_idUsuari.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxReserva_idUsuari.Depth = 0;
            this.textBoxReserva_idUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxReserva_idUsuari.HideSelection = true;
            this.textBoxReserva_idUsuari.LeadingIcon = null;
            this.textBoxReserva_idUsuari.Location = new System.Drawing.Point(1190, 172);
            this.textBoxReserva_idUsuari.MaxLength = 32767;
            this.textBoxReserva_idUsuari.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxReserva_idUsuari.Name = "textBoxReserva_idUsuari";
            this.textBoxReserva_idUsuari.PasswordChar = '\0';
            this.textBoxReserva_idUsuari.PrefixSuffixText = null;
            this.textBoxReserva_idUsuari.ReadOnly = true;
            this.textBoxReserva_idUsuari.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxReserva_idUsuari.SelectedText = "";
            this.textBoxReserva_idUsuari.SelectionLength = 0;
            this.textBoxReserva_idUsuari.SelectionStart = 0;
            this.textBoxReserva_idUsuari.ShortcutsEnabled = true;
            this.textBoxReserva_idUsuari.Size = new System.Drawing.Size(239, 48);
            this.textBoxReserva_idUsuari.TabIndex = 115;
            this.textBoxReserva_idUsuari.TabStop = false;
            this.textBoxReserva_idUsuari.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxReserva_idUsuari.TrailingIcon = null;
            this.textBoxReserva_idUsuari.UseSystemPasswordChar = false;
            // 
            // materialLabel31
            // 
            this.materialLabel31.AutoSize = true;
            this.materialLabel31.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel31.Depth = 0;
            this.materialLabel31.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel31.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel31.Location = new System.Drawing.Point(1207, 137);
            this.materialLabel31.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel31.Name = "materialLabel31";
            this.materialLabel31.Size = new System.Drawing.Size(198, 17);
            this.materialLabel31.TabIndex = 114;
            this.materialLabel31.Text = "Dades de l\'usuari de la reserva:";
            // 
            // buttonReserva_finalitzar
            // 
            this.buttonReserva_finalitzar.AutoSize = false;
            this.buttonReserva_finalitzar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReserva_finalitzar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonReserva_finalitzar.Depth = 0;
            this.buttonReserva_finalitzar.Enabled = false;
            this.buttonReserva_finalitzar.HighEmphasis = true;
            this.buttonReserva_finalitzar.Icon = null;
            this.buttonReserva_finalitzar.Location = new System.Drawing.Point(848, 494);
            this.buttonReserva_finalitzar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonReserva_finalitzar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReserva_finalitzar.Name = "buttonReserva_finalitzar";
            this.buttonReserva_finalitzar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonReserva_finalitzar.Size = new System.Drawing.Size(114, 20);
            this.buttonReserva_finalitzar.TabIndex = 6;
            this.buttonReserva_finalitzar.Text = "FINALITZAR";
            this.buttonReserva_finalitzar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonReserva_finalitzar.UseAccentColor = false;
            this.buttonReserva_finalitzar.UseVisualStyleBackColor = true;
            // 
            // buttonReserva_cancelar
            // 
            this.buttonReserva_cancelar.AutoSize = false;
            this.buttonReserva_cancelar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReserva_cancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonReserva_cancelar.Depth = 0;
            this.buttonReserva_cancelar.Enabled = false;
            this.buttonReserva_cancelar.HighEmphasis = true;
            this.buttonReserva_cancelar.Icon = null;
            this.buttonReserva_cancelar.Location = new System.Drawing.Point(970, 494);
            this.buttonReserva_cancelar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonReserva_cancelar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReserva_cancelar.Name = "buttonReserva_cancelar";
            this.buttonReserva_cancelar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonReserva_cancelar.Size = new System.Drawing.Size(114, 20);
            this.buttonReserva_cancelar.TabIndex = 5;
            this.buttonReserva_cancelar.Text = "CANCELAR";
            this.buttonReserva_cancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonReserva_cancelar.UseAccentColor = false;
            this.buttonReserva_cancelar.UseVisualStyleBackColor = true;
            // 
            // buttonReserva_afegir
            // 
            this.buttonReserva_afegir.AutoSize = false;
            this.buttonReserva_afegir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReserva_afegir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonReserva_afegir.Depth = 0;
            this.buttonReserva_afegir.HighEmphasis = true;
            this.buttonReserva_afegir.Icon = null;
            this.buttonReserva_afegir.Location = new System.Drawing.Point(853, 28);
            this.buttonReserva_afegir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonReserva_afegir.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReserva_afegir.Name = "buttonReserva_afegir";
            this.buttonReserva_afegir.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonReserva_afegir.Size = new System.Drawing.Size(109, 20);
            this.buttonReserva_afegir.TabIndex = 1;
            this.buttonReserva_afegir.Text = "AFEGIR";
            this.buttonReserva_afegir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonReserva_afegir.UseAccentColor = false;
            this.buttonReserva_afegir.UseVisualStyleBackColor = true;
            // 
            // textBoxReserva_correuUsuari
            // 
            this.textBoxReserva_correuUsuari.AnimateReadOnly = false;
            this.textBoxReserva_correuUsuari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxReserva_correuUsuari.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxReserva_correuUsuari.Depth = 0;
            this.textBoxReserva_correuUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxReserva_correuUsuari.HideSelection = true;
            this.textBoxReserva_correuUsuari.LeadingIcon = null;
            this.textBoxReserva_correuUsuari.Location = new System.Drawing.Point(1190, 226);
            this.textBoxReserva_correuUsuari.MaxLength = 32767;
            this.textBoxReserva_correuUsuari.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxReserva_correuUsuari.Name = "textBoxReserva_correuUsuari";
            this.textBoxReserva_correuUsuari.PasswordChar = '\0';
            this.textBoxReserva_correuUsuari.PrefixSuffixText = null;
            this.textBoxReserva_correuUsuari.ReadOnly = true;
            this.textBoxReserva_correuUsuari.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxReserva_correuUsuari.SelectedText = "";
            this.textBoxReserva_correuUsuari.SelectionLength = 0;
            this.textBoxReserva_correuUsuari.SelectionStart = 0;
            this.textBoxReserva_correuUsuari.ShortcutsEnabled = true;
            this.textBoxReserva_correuUsuari.Size = new System.Drawing.Size(239, 48);
            this.textBoxReserva_correuUsuari.TabIndex = 113;
            this.textBoxReserva_correuUsuari.TabStop = false;
            this.textBoxReserva_correuUsuari.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxReserva_correuUsuari.TrailingIcon = null;
            this.textBoxReserva_correuUsuari.UseSystemPasswordChar = false;
            // 
            // textBoxReserva_telefonUsuari
            // 
            this.textBoxReserva_telefonUsuari.AnimateReadOnly = false;
            this.textBoxReserva_telefonUsuari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxReserva_telefonUsuari.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxReserva_telefonUsuari.Depth = 0;
            this.textBoxReserva_telefonUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxReserva_telefonUsuari.HideSelection = true;
            this.textBoxReserva_telefonUsuari.LeadingIcon = null;
            this.textBoxReserva_telefonUsuari.Location = new System.Drawing.Point(1190, 388);
            this.textBoxReserva_telefonUsuari.MaxLength = 32767;
            this.textBoxReserva_telefonUsuari.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxReserva_telefonUsuari.Name = "textBoxReserva_telefonUsuari";
            this.textBoxReserva_telefonUsuari.PasswordChar = '\0';
            this.textBoxReserva_telefonUsuari.PrefixSuffixText = null;
            this.textBoxReserva_telefonUsuari.ReadOnly = true;
            this.textBoxReserva_telefonUsuari.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxReserva_telefonUsuari.SelectedText = "";
            this.textBoxReserva_telefonUsuari.SelectionLength = 0;
            this.textBoxReserva_telefonUsuari.SelectionStart = 0;
            this.textBoxReserva_telefonUsuari.ShortcutsEnabled = true;
            this.textBoxReserva_telefonUsuari.Size = new System.Drawing.Size(239, 48);
            this.textBoxReserva_telefonUsuari.TabIndex = 112;
            this.textBoxReserva_telefonUsuari.TabStop = false;
            this.textBoxReserva_telefonUsuari.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxReserva_telefonUsuari.TrailingIcon = null;
            this.textBoxReserva_telefonUsuari.UseSystemPasswordChar = false;
            // 
            // textBoxReserva_cognomsUsuari
            // 
            this.textBoxReserva_cognomsUsuari.AnimateReadOnly = false;
            this.textBoxReserva_cognomsUsuari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxReserva_cognomsUsuari.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxReserva_cognomsUsuari.Depth = 0;
            this.textBoxReserva_cognomsUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxReserva_cognomsUsuari.HideSelection = true;
            this.textBoxReserva_cognomsUsuari.LeadingIcon = null;
            this.textBoxReserva_cognomsUsuari.Location = new System.Drawing.Point(1190, 334);
            this.textBoxReserva_cognomsUsuari.MaxLength = 32767;
            this.textBoxReserva_cognomsUsuari.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxReserva_cognomsUsuari.Name = "textBoxReserva_cognomsUsuari";
            this.textBoxReserva_cognomsUsuari.PasswordChar = '\0';
            this.textBoxReserva_cognomsUsuari.PrefixSuffixText = null;
            this.textBoxReserva_cognomsUsuari.ReadOnly = true;
            this.textBoxReserva_cognomsUsuari.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxReserva_cognomsUsuari.SelectedText = "";
            this.textBoxReserva_cognomsUsuari.SelectionLength = 0;
            this.textBoxReserva_cognomsUsuari.SelectionStart = 0;
            this.textBoxReserva_cognomsUsuari.ShortcutsEnabled = true;
            this.textBoxReserva_cognomsUsuari.Size = new System.Drawing.Size(239, 48);
            this.textBoxReserva_cognomsUsuari.TabIndex = 111;
            this.textBoxReserva_cognomsUsuari.TabStop = false;
            this.textBoxReserva_cognomsUsuari.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxReserva_cognomsUsuari.TrailingIcon = null;
            this.textBoxReserva_cognomsUsuari.UseSystemPasswordChar = false;
            // 
            // textBoxReserva_nomUsuari
            // 
            this.textBoxReserva_nomUsuari.AnimateReadOnly = false;
            this.textBoxReserva_nomUsuari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textBoxReserva_nomUsuari.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxReserva_nomUsuari.Depth = 0;
            this.textBoxReserva_nomUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxReserva_nomUsuari.HideSelection = true;
            this.textBoxReserva_nomUsuari.LeadingIcon = null;
            this.textBoxReserva_nomUsuari.Location = new System.Drawing.Point(1190, 280);
            this.textBoxReserva_nomUsuari.MaxLength = 32767;
            this.textBoxReserva_nomUsuari.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxReserva_nomUsuari.Name = "textBoxReserva_nomUsuari";
            this.textBoxReserva_nomUsuari.PasswordChar = '\0';
            this.textBoxReserva_nomUsuari.PrefixSuffixText = null;
            this.textBoxReserva_nomUsuari.ReadOnly = true;
            this.textBoxReserva_nomUsuari.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxReserva_nomUsuari.SelectedText = "";
            this.textBoxReserva_nomUsuari.SelectionLength = 0;
            this.textBoxReserva_nomUsuari.SelectionStart = 0;
            this.textBoxReserva_nomUsuari.ShortcutsEnabled = true;
            this.textBoxReserva_nomUsuari.Size = new System.Drawing.Size(239, 48);
            this.textBoxReserva_nomUsuari.TabIndex = 110;
            this.textBoxReserva_nomUsuari.TabStop = false;
            this.textBoxReserva_nomUsuari.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxReserva_nomUsuari.TrailingIcon = null;
            this.textBoxReserva_nomUsuari.UseSystemPasswordChar = false;
            // 
            // comboBoxReserva_estat
            // 
            this.comboBoxReserva_estat.AutoResize = false;
            this.comboBoxReserva_estat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxReserva_estat.Depth = 0;
            this.comboBoxReserva_estat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxReserva_estat.DropDownHeight = 174;
            this.comboBoxReserva_estat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReserva_estat.DropDownWidth = 121;
            this.comboBoxReserva_estat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxReserva_estat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxReserva_estat.FormattingEnabled = true;
            this.comboBoxReserva_estat.IntegralHeight = false;
            this.comboBoxReserva_estat.ItemHeight = 43;
            this.comboBoxReserva_estat.Location = new System.Drawing.Point(897, 57);
            this.comboBoxReserva_estat.MaxDropDownItems = 4;
            this.comboBoxReserva_estat.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxReserva_estat.Name = "comboBoxReserva_estat";
            this.comboBoxReserva_estat.Size = new System.Drawing.Size(187, 49);
            this.comboBoxReserva_estat.StartIndex = 0;
            this.comboBoxReserva_estat.TabIndex = 4;
            // 
            // dateTimePickerReserva_hasta
            // 
            this.dateTimePickerReserva_hasta.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerReserva_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReserva_hasta.Location = new System.Drawing.Point(329, 69);
            this.dateTimePickerReserva_hasta.Name = "dateTimePickerReserva_hasta";
            this.dateTimePickerReserva_hasta.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerReserva_hasta.TabIndex = 3;
            // 
            // dateTimePickerReserva_desde
            // 
            this.dateTimePickerReserva_desde.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerReserva_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReserva_desde.Location = new System.Drawing.Point(202, 69);
            this.dateTimePickerReserva_desde.Name = "dateTimePickerReserva_desde";
            this.dateTimePickerReserva_desde.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerReserva_desde.TabIndex = 2;
            // 
            // dataGridViewReserva_reserves
            // 
            this.dataGridViewReserva_reserves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReserva_reserves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReserva_reserves.Location = new System.Drawing.Point(202, 112);
            this.dataGridViewReserva_reserves.Name = "dataGridViewReserva_reserves";
            this.dataGridViewReserva_reserves.ReadOnly = true;
            this.dataGridViewReserva_reserves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReserva_reserves.Size = new System.Drawing.Size(882, 371);
            this.dataGridViewReserva_reserves.TabIndex = 0;
            // 
            // materialTabControl
            // 
            this.materialTabControl.Controls.Add(this.tabPageReserves);
            this.materialTabControl.Controls.Add(this.tabPageTaules);
            this.materialTabControl.Controls.Add(this.tabPageHorari);
            this.materialTabControl.Controls.Add(this.tabPagePlats);
            this.materialTabControl.Controls.Add(this.tabPageContacte);
            this.materialTabControl.Controls.Add(this.tabPageConfiguracio);
            this.materialTabControl.Depth = 0;
            this.materialTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl.ImageList = this.imageList1;
            this.materialTabControl.Location = new System.Drawing.Point(3, 64);
            this.materialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl.Multiline = true;
            this.materialTabControl.Name = "materialTabControl";
            this.materialTabControl.SelectedIndex = 0;
            this.materialTabControl.Size = new System.Drawing.Size(1738, 563);
            this.materialTabControl.TabIndex = 0;
            // 
            // tabPageHorari
            // 
            this.tabPageHorari.BackColor = System.Drawing.Color.White;
            this.tabPageHorari.Controls.Add(this.materialLabel43);
            this.tabPageHorari.Controls.Add(this.materialLabel42);
            this.tabPageHorari.Controls.Add(this.panel4);
            this.tabPageHorari.Controls.Add(this.materialLabel41);
            this.tabPageHorari.Controls.Add(this.materialLabel40);
            this.tabPageHorari.Controls.Add(this.materialLabel39);
            this.tabPageHorari.Controls.Add(this.panel3);
            this.tabPageHorari.Controls.Add(this.panel2);
            this.tabPageHorari.Controls.Add(this.panel1);
            this.tabPageHorari.Controls.Add(this.monthCalendarHorari_horari);
            this.tabPageHorari.Controls.Add(this.buttonHorari_desassignarFestiu);
            this.tabPageHorari.Controls.Add(this.buttonHorari_assignarFestiu);
            this.tabPageHorari.Controls.Add(this.buttonHorari_configurar);
            this.tabPageHorari.ImageKey = "icons8-calendario-32.png";
            this.tabPageHorari.Location = new System.Drawing.Point(4, 39);
            this.tabPageHorari.Name = "tabPageHorari";
            this.tabPageHorari.Size = new System.Drawing.Size(1730, 520);
            this.tabPageHorari.TabIndex = 4;
            this.tabPageHorari.Text = "Horari";
            // 
            // materialLabel43
            // 
            this.materialLabel43.AutoSize = true;
            this.materialLabel43.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel43.Depth = 0;
            this.materialLabel43.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel43.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel43.Location = new System.Drawing.Point(1091, 60);
            this.materialLabel43.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel43.Name = "materialLabel43";
            this.materialLabel43.Size = new System.Drawing.Size(317, 24);
            this.materialLabel43.TabIndex = 205;
            this.materialLabel43.Text = "Assigna díes festius personalitzats:";
            // 
            // materialLabel42
            // 
            this.materialLabel42.AutoSize = true;
            this.materialLabel42.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel42.Depth = 0;
            this.materialLabel42.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel42.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel42.Location = new System.Drawing.Point(166, 60);
            this.materialLabel42.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel42.Name = "materialLabel42";
            this.materialLabel42.Size = new System.Drawing.Size(616, 24);
            this.materialLabel42.TabIndex = 204;
            this.materialLabel42.Text = "Configura el teu horari amb les franges horàries que vulguis (5 màx.):";
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Controls.Add(this.panelHorari_dilluns);
            this.panel4.Controls.Add(this.buttonHorari_addFranjaDilluns);
            this.panel4.Controls.Add(this.materialLabel4);
            this.panel4.Controls.Add(this.buttonHorari_deleteFranjaDilluns);
            this.panel4.Controls.Add(this.panelHorari_dimarts);
            this.panel4.Controls.Add(this.buttonHorari_addFranjaDimarts);
            this.panel4.Controls.Add(this.buttonHorari_addFranjaDimecres);
            this.panel4.Controls.Add(this.buttonHorari_addFranjaDijous);
            this.panel4.Controls.Add(this.materialLabel19);
            this.panel4.Controls.Add(this.materialLabel20);
            this.panel4.Controls.Add(this.materialLabel21);
            this.panel4.Controls.Add(this.buttonHorari_deleteFranjaDiumenge);
            this.panel4.Controls.Add(this.panelHorari_dimecres);
            this.panel4.Controls.Add(this.buttonHorari_deleteFranjaDissabte);
            this.panel4.Controls.Add(this.panelHorari_dijous);
            this.panel4.Controls.Add(this.buttonHorari_deleteFranjaDivendres);
            this.panel4.Controls.Add(this.buttonHorari_deleteFranjaDimarts);
            this.panel4.Controls.Add(this.panelHorari_divendres);
            this.panel4.Controls.Add(this.buttonHorari_deleteFranjaDijous);
            this.panel4.Controls.Add(this.panelHorari_dissabte);
            this.panel4.Controls.Add(this.buttonHorari_deleteFranjaDimecres);
            this.panel4.Controls.Add(this.panelHorari_diumenge);
            this.panel4.Controls.Add(this.buttonHorari_addFranjaDivendres);
            this.panel4.Controls.Add(this.materialLabel24);
            this.panel4.Controls.Add(this.buttonHorari_addFranjaDiumenge);
            this.panel4.Controls.Add(this.materialLabel23);
            this.panel4.Controls.Add(this.buttonHorari_addFranjaDissabte);
            this.panel4.Controls.Add(this.materialLabel22);
            this.panel4.Location = new System.Drawing.Point(40, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(898, 290);
            this.panel4.TabIndex = 203;
            // 
            // panelHorari_dilluns
            // 
            this.panelHorari_dilluns.Location = new System.Drawing.Point(1, 70);
            this.panelHorari_dilluns.Name = "panelHorari_dilluns";
            this.panelHorari_dilluns.Size = new System.Drawing.Size(169, 195);
            this.panelHorari_dilluns.TabIndex = 181;
            // 
            // buttonHorari_addFranjaDilluns
            // 
            this.buttonHorari_addFranjaDilluns.AutoSize = false;
            this.buttonHorari_addFranjaDilluns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_addFranjaDilluns.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_addFranjaDilluns.Depth = 0;
            this.buttonHorari_addFranjaDilluns.HighEmphasis = true;
            this.buttonHorari_addFranjaDilluns.Icon = null;
            this.buttonHorari_addFranjaDilluns.Location = new System.Drawing.Point(35, 33);
            this.buttonHorari_addFranjaDilluns.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_addFranjaDilluns.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_addFranjaDilluns.Name = "buttonHorari_addFranjaDilluns";
            this.buttonHorari_addFranjaDilluns.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_addFranjaDilluns.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_addFranjaDilluns.TabIndex = 167;
            this.buttonHorari_addFranjaDilluns.Text = "+";
            this.buttonHorari_addFranjaDilluns.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_addFranjaDilluns.UseAccentColor = false;
            this.buttonHorari_addFranjaDilluns.UseVisualStyleBackColor = true;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel4.Location = new System.Drawing.Point(50, 10);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(45, 17);
            this.materialLabel4.TabIndex = 174;
            this.materialLabel4.Text = "Dilluns";
            // 
            // buttonHorari_deleteFranjaDilluns
            // 
            this.buttonHorari_deleteFranjaDilluns.AutoSize = false;
            this.buttonHorari_deleteFranjaDilluns.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_deleteFranjaDilluns.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_deleteFranjaDilluns.Depth = 0;
            this.buttonHorari_deleteFranjaDilluns.HighEmphasis = true;
            this.buttonHorari_deleteFranjaDilluns.Icon = null;
            this.buttonHorari_deleteFranjaDilluns.Location = new System.Drawing.Point(81, 33);
            this.buttonHorari_deleteFranjaDilluns.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_deleteFranjaDilluns.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_deleteFranjaDilluns.Name = "buttonHorari_deleteFranjaDilluns";
            this.buttonHorari_deleteFranjaDilluns.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_deleteFranjaDilluns.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_deleteFranjaDilluns.TabIndex = 185;
            this.buttonHorari_deleteFranjaDilluns.Text = "-";
            this.buttonHorari_deleteFranjaDilluns.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_deleteFranjaDilluns.UseAccentColor = false;
            this.buttonHorari_deleteFranjaDilluns.UseVisualStyleBackColor = true;
            // 
            // panelHorari_dimarts
            // 
            this.panelHorari_dimarts.Location = new System.Drawing.Point(239, 70);
            this.panelHorari_dimarts.Name = "panelHorari_dimarts";
            this.panelHorari_dimarts.Size = new System.Drawing.Size(169, 195);
            this.panelHorari_dimarts.TabIndex = 182;
            // 
            // buttonHorari_addFranjaDimarts
            // 
            this.buttonHorari_addFranjaDimarts.AutoSize = false;
            this.buttonHorari_addFranjaDimarts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_addFranjaDimarts.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_addFranjaDimarts.Depth = 0;
            this.buttonHorari_addFranjaDimarts.HighEmphasis = true;
            this.buttonHorari_addFranjaDimarts.Icon = null;
            this.buttonHorari_addFranjaDimarts.Location = new System.Drawing.Point(287, 33);
            this.buttonHorari_addFranjaDimarts.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_addFranjaDimarts.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_addFranjaDimarts.Name = "buttonHorari_addFranjaDimarts";
            this.buttonHorari_addFranjaDimarts.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_addFranjaDimarts.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_addFranjaDimarts.TabIndex = 168;
            this.buttonHorari_addFranjaDimarts.Text = "+";
            this.buttonHorari_addFranjaDimarts.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_addFranjaDimarts.UseAccentColor = false;
            this.buttonHorari_addFranjaDimarts.UseVisualStyleBackColor = true;
            // 
            // buttonHorari_addFranjaDimecres
            // 
            this.buttonHorari_addFranjaDimecres.AutoSize = false;
            this.buttonHorari_addFranjaDimecres.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_addFranjaDimecres.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_addFranjaDimecres.Depth = 0;
            this.buttonHorari_addFranjaDimecres.HighEmphasis = true;
            this.buttonHorari_addFranjaDimecres.Icon = null;
            this.buttonHorari_addFranjaDimecres.Location = new System.Drawing.Point(511, 33);
            this.buttonHorari_addFranjaDimecres.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_addFranjaDimecres.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_addFranjaDimecres.Name = "buttonHorari_addFranjaDimecres";
            this.buttonHorari_addFranjaDimecres.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_addFranjaDimecres.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_addFranjaDimecres.TabIndex = 169;
            this.buttonHorari_addFranjaDimecres.Text = "+";
            this.buttonHorari_addFranjaDimecres.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_addFranjaDimecres.UseAccentColor = false;
            this.buttonHorari_addFranjaDimecres.UseVisualStyleBackColor = true;
            // 
            // buttonHorari_addFranjaDijous
            // 
            this.buttonHorari_addFranjaDijous.AutoSize = false;
            this.buttonHorari_addFranjaDijous.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_addFranjaDijous.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_addFranjaDijous.Depth = 0;
            this.buttonHorari_addFranjaDijous.HighEmphasis = true;
            this.buttonHorari_addFranjaDijous.Icon = null;
            this.buttonHorari_addFranjaDijous.Location = new System.Drawing.Point(744, 33);
            this.buttonHorari_addFranjaDijous.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_addFranjaDijous.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_addFranjaDijous.Name = "buttonHorari_addFranjaDijous";
            this.buttonHorari_addFranjaDijous.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_addFranjaDijous.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_addFranjaDijous.TabIndex = 172;
            this.buttonHorari_addFranjaDijous.Text = "+";
            this.buttonHorari_addFranjaDijous.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_addFranjaDijous.UseAccentColor = false;
            this.buttonHorari_addFranjaDijous.UseVisualStyleBackColor = true;
            // 
            // materialLabel19
            // 
            this.materialLabel19.AutoSize = true;
            this.materialLabel19.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel19.Depth = 0;
            this.materialLabel19.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel19.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel19.Location = new System.Drawing.Point(296, 8);
            this.materialLabel19.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel19.Name = "materialLabel19";
            this.materialLabel19.Size = new System.Drawing.Size(51, 17);
            this.materialLabel19.TabIndex = 175;
            this.materialLabel19.Text = "Dimarts";
            // 
            // materialLabel20
            // 
            this.materialLabel20.AutoSize = true;
            this.materialLabel20.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel20.Depth = 0;
            this.materialLabel20.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel20.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel20.Location = new System.Drawing.Point(518, 8);
            this.materialLabel20.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel20.Name = "materialLabel20";
            this.materialLabel20.Size = new System.Drawing.Size(61, 17);
            this.materialLabel20.TabIndex = 176;
            this.materialLabel20.Text = "Dimecres";
            // 
            // materialLabel21
            // 
            this.materialLabel21.AutoSize = true;
            this.materialLabel21.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel21.Depth = 0;
            this.materialLabel21.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel21.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel21.Location = new System.Drawing.Point(758, 8);
            this.materialLabel21.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel21.Name = "materialLabel21";
            this.materialLabel21.Size = new System.Drawing.Size(41, 17);
            this.materialLabel21.TabIndex = 177;
            this.materialLabel21.Text = "Dijous";
            // 
            // buttonHorari_deleteFranjaDiumenge
            // 
            this.buttonHorari_deleteFranjaDiumenge.AutoSize = false;
            this.buttonHorari_deleteFranjaDiumenge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_deleteFranjaDiumenge.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_deleteFranjaDiumenge.Depth = 0;
            this.buttonHorari_deleteFranjaDiumenge.HighEmphasis = true;
            this.buttonHorari_deleteFranjaDiumenge.Icon = null;
            this.buttonHorari_deleteFranjaDiumenge.Location = new System.Drawing.Point(1458, 33);
            this.buttonHorari_deleteFranjaDiumenge.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_deleteFranjaDiumenge.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_deleteFranjaDiumenge.Name = "buttonHorari_deleteFranjaDiumenge";
            this.buttonHorari_deleteFranjaDiumenge.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_deleteFranjaDiumenge.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_deleteFranjaDiumenge.TabIndex = 191;
            this.buttonHorari_deleteFranjaDiumenge.Text = "-";
            this.buttonHorari_deleteFranjaDiumenge.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_deleteFranjaDiumenge.UseAccentColor = false;
            this.buttonHorari_deleteFranjaDiumenge.UseVisualStyleBackColor = true;
            // 
            // panelHorari_dimecres
            // 
            this.panelHorari_dimecres.Location = new System.Drawing.Point(469, 70);
            this.panelHorari_dimecres.Name = "panelHorari_dimecres";
            this.panelHorari_dimecres.Size = new System.Drawing.Size(169, 195);
            this.panelHorari_dimecres.TabIndex = 183;
            // 
            // buttonHorari_deleteFranjaDissabte
            // 
            this.buttonHorari_deleteFranjaDissabte.AutoSize = false;
            this.buttonHorari_deleteFranjaDissabte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_deleteFranjaDissabte.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_deleteFranjaDissabte.Depth = 0;
            this.buttonHorari_deleteFranjaDissabte.HighEmphasis = true;
            this.buttonHorari_deleteFranjaDissabte.Icon = null;
            this.buttonHorari_deleteFranjaDissabte.Location = new System.Drawing.Point(1240, 31);
            this.buttonHorari_deleteFranjaDissabte.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_deleteFranjaDissabte.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_deleteFranjaDissabte.Name = "buttonHorari_deleteFranjaDissabte";
            this.buttonHorari_deleteFranjaDissabte.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_deleteFranjaDissabte.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_deleteFranjaDissabte.TabIndex = 190;
            this.buttonHorari_deleteFranjaDissabte.Text = "-";
            this.buttonHorari_deleteFranjaDissabte.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_deleteFranjaDissabte.UseAccentColor = false;
            this.buttonHorari_deleteFranjaDissabte.UseVisualStyleBackColor = true;
            // 
            // panelHorari_dijous
            // 
            this.panelHorari_dijous.Location = new System.Drawing.Point(698, 70);
            this.panelHorari_dijous.Name = "panelHorari_dijous";
            this.panelHorari_dijous.Size = new System.Drawing.Size(169, 195);
            this.panelHorari_dijous.TabIndex = 184;
            // 
            // buttonHorari_deleteFranjaDivendres
            // 
            this.buttonHorari_deleteFranjaDivendres.AutoSize = false;
            this.buttonHorari_deleteFranjaDivendres.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_deleteFranjaDivendres.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_deleteFranjaDivendres.Depth = 0;
            this.buttonHorari_deleteFranjaDivendres.HighEmphasis = true;
            this.buttonHorari_deleteFranjaDivendres.Icon = null;
            this.buttonHorari_deleteFranjaDivendres.Location = new System.Drawing.Point(1010, 33);
            this.buttonHorari_deleteFranjaDivendres.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_deleteFranjaDivendres.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_deleteFranjaDivendres.Name = "buttonHorari_deleteFranjaDivendres";
            this.buttonHorari_deleteFranjaDivendres.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_deleteFranjaDivendres.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_deleteFranjaDivendres.TabIndex = 189;
            this.buttonHorari_deleteFranjaDivendres.Text = "-";
            this.buttonHorari_deleteFranjaDivendres.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_deleteFranjaDivendres.UseAccentColor = false;
            this.buttonHorari_deleteFranjaDivendres.UseVisualStyleBackColor = true;
            // 
            // buttonHorari_deleteFranjaDimarts
            // 
            this.buttonHorari_deleteFranjaDimarts.AutoSize = false;
            this.buttonHorari_deleteFranjaDimarts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_deleteFranjaDimarts.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_deleteFranjaDimarts.Depth = 0;
            this.buttonHorari_deleteFranjaDimarts.HighEmphasis = true;
            this.buttonHorari_deleteFranjaDimarts.Icon = null;
            this.buttonHorari_deleteFranjaDimarts.Location = new System.Drawing.Point(337, 33);
            this.buttonHorari_deleteFranjaDimarts.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_deleteFranjaDimarts.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_deleteFranjaDimarts.Name = "buttonHorari_deleteFranjaDimarts";
            this.buttonHorari_deleteFranjaDimarts.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_deleteFranjaDimarts.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_deleteFranjaDimarts.TabIndex = 186;
            this.buttonHorari_deleteFranjaDimarts.Text = "-";
            this.buttonHorari_deleteFranjaDimarts.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_deleteFranjaDimarts.UseAccentColor = false;
            this.buttonHorari_deleteFranjaDimarts.UseVisualStyleBackColor = true;
            // 
            // panelHorari_divendres
            // 
            this.panelHorari_divendres.Location = new System.Drawing.Point(917, 70);
            this.panelHorari_divendres.Name = "panelHorari_divendres";
            this.panelHorari_divendres.Size = new System.Drawing.Size(169, 195);
            this.panelHorari_divendres.TabIndex = 184;
            // 
            // buttonHorari_deleteFranjaDijous
            // 
            this.buttonHorari_deleteFranjaDijous.AutoSize = false;
            this.buttonHorari_deleteFranjaDijous.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_deleteFranjaDijous.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_deleteFranjaDijous.Depth = 0;
            this.buttonHorari_deleteFranjaDijous.HighEmphasis = true;
            this.buttonHorari_deleteFranjaDijous.Icon = null;
            this.buttonHorari_deleteFranjaDijous.Location = new System.Drawing.Point(792, 33);
            this.buttonHorari_deleteFranjaDijous.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_deleteFranjaDijous.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_deleteFranjaDijous.Name = "buttonHorari_deleteFranjaDijous";
            this.buttonHorari_deleteFranjaDijous.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_deleteFranjaDijous.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_deleteFranjaDijous.TabIndex = 188;
            this.buttonHorari_deleteFranjaDijous.Text = "-";
            this.buttonHorari_deleteFranjaDijous.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_deleteFranjaDijous.UseAccentColor = false;
            this.buttonHorari_deleteFranjaDijous.UseVisualStyleBackColor = true;
            // 
            // panelHorari_dissabte
            // 
            this.panelHorari_dissabte.Location = new System.Drawing.Point(1135, 70);
            this.panelHorari_dissabte.Name = "panelHorari_dissabte";
            this.panelHorari_dissabte.Size = new System.Drawing.Size(169, 195);
            this.panelHorari_dissabte.TabIndex = 184;
            // 
            // buttonHorari_deleteFranjaDimecres
            // 
            this.buttonHorari_deleteFranjaDimecres.AutoSize = false;
            this.buttonHorari_deleteFranjaDimecres.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_deleteFranjaDimecres.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_deleteFranjaDimecres.Depth = 0;
            this.buttonHorari_deleteFranjaDimecres.HighEmphasis = true;
            this.buttonHorari_deleteFranjaDimecres.Icon = null;
            this.buttonHorari_deleteFranjaDimecres.Location = new System.Drawing.Point(568, 33);
            this.buttonHorari_deleteFranjaDimecres.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_deleteFranjaDimecres.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_deleteFranjaDimecres.Name = "buttonHorari_deleteFranjaDimecres";
            this.buttonHorari_deleteFranjaDimecres.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_deleteFranjaDimecres.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_deleteFranjaDimecres.TabIndex = 187;
            this.buttonHorari_deleteFranjaDimecres.Text = "-";
            this.buttonHorari_deleteFranjaDimecres.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_deleteFranjaDimecres.UseAccentColor = false;
            this.buttonHorari_deleteFranjaDimecres.UseVisualStyleBackColor = true;
            // 
            // panelHorari_diumenge
            // 
            this.panelHorari_diumenge.Location = new System.Drawing.Point(1363, 70);
            this.panelHorari_diumenge.Name = "panelHorari_diumenge";
            this.panelHorari_diumenge.Size = new System.Drawing.Size(169, 195);
            this.panelHorari_diumenge.TabIndex = 184;
            // 
            // buttonHorari_addFranjaDivendres
            // 
            this.buttonHorari_addFranjaDivendres.AutoSize = false;
            this.buttonHorari_addFranjaDivendres.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_addFranjaDivendres.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_addFranjaDivendres.Depth = 0;
            this.buttonHorari_addFranjaDivendres.HighEmphasis = true;
            this.buttonHorari_addFranjaDivendres.Icon = null;
            this.buttonHorari_addFranjaDivendres.Location = new System.Drawing.Point(948, 33);
            this.buttonHorari_addFranjaDivendres.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_addFranjaDivendres.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_addFranjaDivendres.Name = "buttonHorari_addFranjaDivendres";
            this.buttonHorari_addFranjaDivendres.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_addFranjaDivendres.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_addFranjaDivendres.TabIndex = 173;
            this.buttonHorari_addFranjaDivendres.Text = "+";
            this.buttonHorari_addFranjaDivendres.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_addFranjaDivendres.UseAccentColor = false;
            this.buttonHorari_addFranjaDivendres.UseVisualStyleBackColor = true;
            // 
            // materialLabel24
            // 
            this.materialLabel24.AutoSize = true;
            this.materialLabel24.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel24.Depth = 0;
            this.materialLabel24.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel24.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel24.Location = new System.Drawing.Point(1409, 8);
            this.materialLabel24.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel24.Name = "materialLabel24";
            this.materialLabel24.Size = new System.Drawing.Size(66, 17);
            this.materialLabel24.TabIndex = 180;
            this.materialLabel24.Text = "Diumenge";
            // 
            // buttonHorari_addFranjaDiumenge
            // 
            this.buttonHorari_addFranjaDiumenge.AutoSize = false;
            this.buttonHorari_addFranjaDiumenge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_addFranjaDiumenge.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_addFranjaDiumenge.Depth = 0;
            this.buttonHorari_addFranjaDiumenge.HighEmphasis = true;
            this.buttonHorari_addFranjaDiumenge.Icon = null;
            this.buttonHorari_addFranjaDiumenge.Location = new System.Drawing.Point(1403, 33);
            this.buttonHorari_addFranjaDiumenge.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_addFranjaDiumenge.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_addFranjaDiumenge.Name = "buttonHorari_addFranjaDiumenge";
            this.buttonHorari_addFranjaDiumenge.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_addFranjaDiumenge.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_addFranjaDiumenge.TabIndex = 170;
            this.buttonHorari_addFranjaDiumenge.Text = "+";
            this.buttonHorari_addFranjaDiumenge.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_addFranjaDiumenge.UseAccentColor = false;
            this.buttonHorari_addFranjaDiumenge.UseVisualStyleBackColor = true;
            // 
            // materialLabel23
            // 
            this.materialLabel23.AutoSize = true;
            this.materialLabel23.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel23.Depth = 0;
            this.materialLabel23.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel23.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel23.Location = new System.Drawing.Point(958, 8);
            this.materialLabel23.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel23.Name = "materialLabel23";
            this.materialLabel23.Size = new System.Drawing.Size(65, 17);
            this.materialLabel23.TabIndex = 179;
            this.materialLabel23.Text = "Divendres";
            // 
            // buttonHorari_addFranjaDissabte
            // 
            this.buttonHorari_addFranjaDissabte.AutoSize = false;
            this.buttonHorari_addFranjaDissabte.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_addFranjaDissabte.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_addFranjaDissabte.Depth = 0;
            this.buttonHorari_addFranjaDissabte.HighEmphasis = true;
            this.buttonHorari_addFranjaDissabte.Icon = null;
            this.buttonHorari_addFranjaDissabte.Location = new System.Drawing.Point(1174, 31);
            this.buttonHorari_addFranjaDissabte.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_addFranjaDissabte.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_addFranjaDissabte.Name = "buttonHorari_addFranjaDissabte";
            this.buttonHorari_addFranjaDissabte.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_addFranjaDissabte.Size = new System.Drawing.Size(26, 20);
            this.buttonHorari_addFranjaDissabte.TabIndex = 171;
            this.buttonHorari_addFranjaDissabte.Text = "+";
            this.buttonHorari_addFranjaDissabte.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_addFranjaDissabte.UseAccentColor = false;
            this.buttonHorari_addFranjaDissabte.UseVisualStyleBackColor = true;
            // 
            // materialLabel22
            // 
            this.materialLabel22.AutoSize = true;
            this.materialLabel22.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel22.Depth = 0;
            this.materialLabel22.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel22.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel22.Location = new System.Drawing.Point(1189, 8);
            this.materialLabel22.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel22.Name = "materialLabel22";
            this.materialLabel22.Size = new System.Drawing.Size(57, 17);
            this.materialLabel22.TabIndex = 178;
            this.materialLabel22.Text = "Dissabte";
            this.materialLabel22.Click += new System.EventHandler(this.materialLabel22_Click);
            // 
            // materialLabel41
            // 
            this.materialLabel41.AutoSize = true;
            this.materialLabel41.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel41.Depth = 0;
            this.materialLabel41.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel41.Location = new System.Drawing.Point(1534, 265);
            this.materialLabel41.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel41.Name = "materialLabel41";
            this.materialLabel41.Size = new System.Drawing.Size(44, 19);
            this.materialLabel41.TabIndex = 202;
            this.materialLabel41.Text = "Festiu";
            // 
            // materialLabel40
            // 
            this.materialLabel40.AutoSize = true;
            this.materialLabel40.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel40.Depth = 0;
            this.materialLabel40.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel40.Location = new System.Drawing.Point(1534, 239);
            this.materialLabel40.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel40.Name = "materialLabel40";
            this.materialLabel40.Size = new System.Drawing.Size(74, 19);
            this.materialLabel40.TabIndex = 201;
            this.materialLabel40.Text = "No laboral";
            // 
            // materialLabel39
            // 
            this.materialLabel39.AutoSize = true;
            this.materialLabel39.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel39.Depth = 0;
            this.materialLabel39.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel39.Location = new System.Drawing.Point(1534, 213);
            this.materialLabel39.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel39.Name = "materialLabel39";
            this.materialLabel39.Size = new System.Drawing.Size(55, 19);
            this.materialLabel39.TabIndex = 200;
            this.materialLabel39.Text = "Laboral";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(1508, 237);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 20);
            this.panel3.TabIndex = 199;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(1508, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 198;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Location = new System.Drawing.Point(1508, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            this.panel1.TabIndex = 197;
            // 
            // monthCalendarHorari_horari
            // 
            this.monthCalendarHorari_horari.ActiveMonth.Month = 5;
            this.monthCalendarHorari_horari.ActiveMonth.Year = 2025;
            this.monthCalendarHorari_horari.Culture = new System.Globalization.CultureInfo("en-US");
            this.monthCalendarHorari_horari.Footer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendarHorari_horari.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.monthCalendarHorari_horari.Header.TextColor = System.Drawing.Color.White;
            this.monthCalendarHorari_horari.ImageList = null;
            this.monthCalendarHorari_horari.Location = new System.Drawing.Point(1024, 107);
            this.monthCalendarHorari_horari.MaxDate = new System.DateTime(2026, 5, 14, 0, 0, 0, 0);
            this.monthCalendarHorari_horari.MinDate = new System.DateTime(2025, 5, 14, 0, 0, 0, 0);
            this.monthCalendarHorari_horari.Month.BackgroundImage = null;
            this.monthCalendarHorari_horari.Month.DateFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendarHorari_horari.Month.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendarHorari_horari.Name = "monthCalendarHorari_horari";
            this.monthCalendarHorari_horari.Size = new System.Drawing.Size(464, 275);
            this.monthCalendarHorari_horari.TabIndex = 195;
            this.monthCalendarHorari_horari.Weekdays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.monthCalendarHorari_horari.Weeknumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            // 
            // buttonHorari_desassignarFestiu
            // 
            this.buttonHorari_desassignarFestiu.AutoSize = false;
            this.buttonHorari_desassignarFestiu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_desassignarFestiu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_desassignarFestiu.Depth = 0;
            this.buttonHorari_desassignarFestiu.HighEmphasis = true;
            this.buttonHorari_desassignarFestiu.Icon = null;
            this.buttonHorari_desassignarFestiu.Location = new System.Drawing.Point(1377, 411);
            this.buttonHorari_desassignarFestiu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_desassignarFestiu.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_desassignarFestiu.Name = "buttonHorari_desassignarFestiu";
            this.buttonHorari_desassignarFestiu.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_desassignarFestiu.Size = new System.Drawing.Size(111, 35);
            this.buttonHorari_desassignarFestiu.TabIndex = 194;
            this.buttonHorari_desassignarFestiu.Text = "TREURE";
            this.buttonHorari_desassignarFestiu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_desassignarFestiu.UseAccentColor = false;
            this.buttonHorari_desassignarFestiu.UseVisualStyleBackColor = true;
            // 
            // buttonHorari_assignarFestiu
            // 
            this.buttonHorari_assignarFestiu.AutoSize = false;
            this.buttonHorari_assignarFestiu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_assignarFestiu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_assignarFestiu.Depth = 0;
            this.buttonHorari_assignarFestiu.HighEmphasis = true;
            this.buttonHorari_assignarFestiu.Icon = null;
            this.buttonHorari_assignarFestiu.Location = new System.Drawing.Point(1024, 411);
            this.buttonHorari_assignarFestiu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_assignarFestiu.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_assignarFestiu.Name = "buttonHorari_assignarFestiu";
            this.buttonHorari_assignarFestiu.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_assignarFestiu.Size = new System.Drawing.Size(111, 35);
            this.buttonHorari_assignarFestiu.TabIndex = 193;
            this.buttonHorari_assignarFestiu.Text = "ASSIGNAR";
            this.buttonHorari_assignarFestiu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_assignarFestiu.UseAccentColor = false;
            this.buttonHorari_assignarFestiu.UseVisualStyleBackColor = true;
            // 
            // buttonHorari_configurar
            // 
            this.buttonHorari_configurar.AutoSize = false;
            this.buttonHorari_configurar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHorari_configurar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonHorari_configurar.Depth = 0;
            this.buttonHorari_configurar.HighEmphasis = true;
            this.buttonHorari_configurar.Icon = null;
            this.buttonHorari_configurar.Location = new System.Drawing.Point(405, 411);
            this.buttonHorari_configurar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonHorari_configurar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonHorari_configurar.Name = "buttonHorari_configurar";
            this.buttonHorari_configurar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonHorari_configurar.Size = new System.Drawing.Size(152, 35);
            this.buttonHorari_configurar.TabIndex = 108;
            this.buttonHorari_configurar.Text = "CONFIGURAR HORARI";
            this.buttonHorari_configurar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonHorari_configurar.UseAccentColor = false;
            this.buttonHorari_configurar.UseVisualStyleBackColor = true;
            // 
            // tabPagePlats
            // 
            this.tabPagePlats.BackColor = System.Drawing.Color.White;
            this.tabPagePlats.Controls.Add(this.materialLabel49);
            this.tabPagePlats.Controls.Add(this.buttonMenu_eliminar);
            this.tabPagePlats.Controls.Add(this.buttonMenu_editar);
            this.tabPagePlats.Controls.Add(this.buttonMenu_afegir);
            this.tabPagePlats.Controls.Add(this.materialLabel26);
            this.tabPagePlats.Controls.Add(this.comboBoxMenu_tipusPlats);
            this.tabPagePlats.Controls.Add(this.dataGridViewMenu_plats);
            this.tabPagePlats.ImageKey = "icons8-comida-32.png";
            this.tabPagePlats.Location = new System.Drawing.Point(4, 39);
            this.tabPagePlats.Name = "tabPagePlats";
            this.tabPagePlats.Size = new System.Drawing.Size(1730, 520);
            this.tabPagePlats.TabIndex = 7;
            this.tabPagePlats.Text = "Plats";
            // 
            // materialLabel49
            // 
            this.materialLabel49.AutoSize = true;
            this.materialLabel49.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel49.Depth = 0;
            this.materialLabel49.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel49.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel49.Location = new System.Drawing.Point(406, 79);
            this.materialLabel49.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel49.Name = "materialLabel49";
            this.materialLabel49.Size = new System.Drawing.Size(62, 24);
            this.materialLabel49.TabIndex = 208;
            this.materialLabel49.Text = "PLATS";
            // 
            // buttonMenu_eliminar
            // 
            this.buttonMenu_eliminar.AutoSize = false;
            this.buttonMenu_eliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMenu_eliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonMenu_eliminar.Depth = 0;
            this.buttonMenu_eliminar.HighEmphasis = true;
            this.buttonMenu_eliminar.Icon = null;
            this.buttonMenu_eliminar.Location = new System.Drawing.Point(1015, 36);
            this.buttonMenu_eliminar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonMenu_eliminar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonMenu_eliminar.Name = "buttonMenu_eliminar";
            this.buttonMenu_eliminar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonMenu_eliminar.Size = new System.Drawing.Size(86, 20);
            this.buttonMenu_eliminar.TabIndex = 122;
            this.buttonMenu_eliminar.Text = "ELIMINAR";
            this.buttonMenu_eliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonMenu_eliminar.UseAccentColor = false;
            this.buttonMenu_eliminar.UseVisualStyleBackColor = true;
            // 
            // buttonMenu_editar
            // 
            this.buttonMenu_editar.AutoSize = false;
            this.buttonMenu_editar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMenu_editar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonMenu_editar.Depth = 0;
            this.buttonMenu_editar.HighEmphasis = true;
            this.buttonMenu_editar.Icon = null;
            this.buttonMenu_editar.Location = new System.Drawing.Point(922, 36);
            this.buttonMenu_editar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonMenu_editar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonMenu_editar.Name = "buttonMenu_editar";
            this.buttonMenu_editar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonMenu_editar.Size = new System.Drawing.Size(85, 20);
            this.buttonMenu_editar.TabIndex = 121;
            this.buttonMenu_editar.Text = "MODIFICAR";
            this.buttonMenu_editar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonMenu_editar.UseAccentColor = false;
            this.buttonMenu_editar.UseVisualStyleBackColor = true;
            // 
            // buttonMenu_afegir
            // 
            this.buttonMenu_afegir.AutoSize = false;
            this.buttonMenu_afegir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMenu_afegir.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonMenu_afegir.Depth = 0;
            this.buttonMenu_afegir.HighEmphasis = true;
            this.buttonMenu_afegir.Icon = null;
            this.buttonMenu_afegir.Location = new System.Drawing.Point(824, 36);
            this.buttonMenu_afegir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonMenu_afegir.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonMenu_afegir.Name = "buttonMenu_afegir";
            this.buttonMenu_afegir.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonMenu_afegir.Size = new System.Drawing.Size(90, 20);
            this.buttonMenu_afegir.TabIndex = 120;
            this.buttonMenu_afegir.Text = "AFEGIR";
            this.buttonMenu_afegir.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonMenu_afegir.UseAccentColor = false;
            this.buttonMenu_afegir.UseVisualStyleBackColor = true;
            // 
            // materialLabel26
            // 
            this.materialLabel26.AutoSize = true;
            this.materialLabel26.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel26.Depth = 0;
            this.materialLabel26.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel26.Location = new System.Drawing.Point(821, 79);
            this.materialLabel26.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel26.Name = "materialLabel26";
            this.materialLabel26.Size = new System.Drawing.Size(84, 19);
            this.materialLabel26.TabIndex = 119;
            this.materialLabel26.Text = "Tipus plats:";
            // 
            // comboBoxMenu_tipusPlats
            // 
            this.comboBoxMenu_tipusPlats.AutoResize = false;
            this.comboBoxMenu_tipusPlats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxMenu_tipusPlats.Depth = 0;
            this.comboBoxMenu_tipusPlats.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxMenu_tipusPlats.DropDownHeight = 174;
            this.comboBoxMenu_tipusPlats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMenu_tipusPlats.DropDownWidth = 121;
            this.comboBoxMenu_tipusPlats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxMenu_tipusPlats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxMenu_tipusPlats.FormattingEnabled = true;
            this.comboBoxMenu_tipusPlats.IntegralHeight = false;
            this.comboBoxMenu_tipusPlats.ItemHeight = 43;
            this.comboBoxMenu_tipusPlats.Location = new System.Drawing.Point(911, 64);
            this.comboBoxMenu_tipusPlats.MaxDropDownItems = 4;
            this.comboBoxMenu_tipusPlats.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxMenu_tipusPlats.Name = "comboBoxMenu_tipusPlats";
            this.comboBoxMenu_tipusPlats.Size = new System.Drawing.Size(191, 49);
            this.comboBoxMenu_tipusPlats.StartIndex = 0;
            this.comboBoxMenu_tipusPlats.TabIndex = 118;
            // 
            // dataGridViewMenu_plats
            // 
            this.dataGridViewMenu_plats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMenu_plats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenu_plats.Location = new System.Drawing.Point(410, 119);
            this.dataGridViewMenu_plats.Name = "dataGridViewMenu_plats";
            this.dataGridViewMenu_plats.ReadOnly = true;
            this.dataGridViewMenu_plats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMenu_plats.Size = new System.Drawing.Size(692, 371);
            this.dataGridViewMenu_plats.TabIndex = 1;
            // 
            // buttonMain_tancarSessio
            // 
            this.buttonMain_tancarSessio.BackColor = System.Drawing.Color.Transparent;
            this.buttonMain_tancarSessio.FlatAppearance.BorderSize = 0;
            this.buttonMain_tancarSessio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMain_tancarSessio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(113)))), ((int)(((byte)(80)))));
            this.buttonMain_tancarSessio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMain_tancarSessio.Image = global::PerezMaximiliano_MorenoAaron_Projecte.Properties.Resources.icons8_cerrar_sesión_30;
            this.buttonMain_tancarSessio.Location = new System.Drawing.Point(1700, 24);
            this.buttonMain_tancarSessio.Name = "buttonMain_tancarSessio";
            this.buttonMain_tancarSessio.Size = new System.Drawing.Size(45, 40);
            this.buttonMain_tancarSessio.TabIndex = 85;
            this.buttonMain_tancarSessio.UseVisualStyleBackColor = false;
            this.buttonMain_tancarSessio.Click += new System.EventHandler(this.buttonMain_tancarSessio_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 630);
            this.Controls.Add(this.buttonMain_tancarSessio);
            this.Controls.Add(this.materialTabControl);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.tabPageConfiguracio.ResumeLayout(false);
            this.tabPageConfiguracio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfiguracio_imatgeRestaurant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfiguracio_logo)).EndInit();
            this.tabPageContacte.ResumeLayout(false);
            this.tabPageContacte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContacte_missatges)).EndInit();
            this.tabPageTaules.ResumeLayout(false);
            this.tabPageTaules.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaula_taules)).EndInit();
            this.tabPageReserves.ResumeLayout(false);
            this.tabPageReserves.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReserva_reserves)).EndInit();
            this.materialTabControl.ResumeLayout(false);
            this.tabPageHorari.ResumeLayout(false);
            this.tabPageHorari.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPagePlats.ResumeLayout(false);
            this.tabPagePlats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu_plats)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Button buttonMain_tancarSessio;
        public System.Windows.Forms.TabPage tabPageConfiguracio;
        public MaterialSkin.Controls.MaterialButton buttonConfiguracio_newContrasenya;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_paginaweb;
        private MaterialSkin.Controls.MaterialLabel materialLabel18;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_descripcio;
        private MaterialSkin.Controls.MaterialLabel materialLabel17;
        private MaterialSkin.Controls.MaterialLabel materialLabel16;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_aforament;
        public MaterialSkin.Controls.MaterialComboBox comboBoxConfiguracio_tipuspreu;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        public MaterialSkin.Controls.MaterialComboBox comboBoxConfiguracio_tipuscuina;
        private MaterialSkin.Controls.MaterialLabel materialLabel14;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_correu;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_carrer;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_codipostal;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_poblacio;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_pais;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_telefon;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_nom;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxConfiguracio_usuari;
        public MaterialSkin.Controls.MaterialButton buttonConfiguracio_editar;
        public System.Windows.Forms.PictureBox pictureBoxConfiguracio_logo;
        public System.Windows.Forms.TabPage tabPageContacte;
        private MaterialSkin.Controls.MaterialLabel materialLabel30;
        private MaterialSkin.Controls.MaterialLabel materialLabel29;
        public MaterialSkin.Controls.MaterialButton buttonContacte_obrir;
        public MaterialSkin.Controls.MaterialTextBox textBoxContacte_filtre;
        public System.Windows.Forms.DateTimePicker dateTimePickerContacte_hasta;
        public System.Windows.Forms.DateTimePicker dateTimePickerContacte_desde;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        public System.Windows.Forms.DataGridView dataGridViewContacte_missatges;
        public System.Windows.Forms.TabPage tabPageTaules;
        public MaterialSkin.Controls.MaterialTextBox textBoxTaula_aforamentMaxim;
        public MaterialSkin.Controls.MaterialTextBox textBoxTaula_aforamentActual;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        public MaterialSkin.Controls.MaterialButton buttonTaula_eliminar;
        public MaterialSkin.Controls.MaterialButton buttonTaula_editar;
        public MaterialSkin.Controls.MaterialButton buttonTaula_afegir;
        public System.Windows.Forms.TabPage tabPageReserves;
        public MaterialSkin.Controls.MaterialButton buttonReserva_enProces;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxReserva_idUsuari;
        private MaterialSkin.Controls.MaterialLabel materialLabel31;
        public MaterialSkin.Controls.MaterialButton buttonReserva_finalitzar;
        public MaterialSkin.Controls.MaterialButton buttonReserva_cancelar;
        public MaterialSkin.Controls.MaterialButton buttonReserva_afegir;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxReserva_correuUsuari;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxReserva_telefonUsuari;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxReserva_cognomsUsuari;
        public MaterialSkin.Controls.MaterialTextBox2 textBoxReserva_nomUsuari;
        public MaterialSkin.Controls.MaterialComboBox comboBoxReserva_estat;
        public System.Windows.Forms.DateTimePicker dateTimePickerReserva_hasta;
        public System.Windows.Forms.DateTimePicker dateTimePickerReserva_desde;
        public System.Windows.Forms.DataGridView dataGridViewReserva_reserves;
        public MaterialSkin.Controls.MaterialTabControl materialTabControl;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        public System.Windows.Forms.Button buttonConfiguracio_logo;
        public System.Windows.Forms.TabPage tabPageHorari;
        public MaterialSkin.Controls.MaterialLabel materialLabel23;
        public MaterialSkin.Controls.MaterialLabel materialLabel22;
        public MaterialSkin.Controls.MaterialLabel materialLabel21;
        public MaterialSkin.Controls.MaterialLabel materialLabel20;
        public MaterialSkin.Controls.MaterialLabel materialLabel19;
        public MaterialSkin.Controls.MaterialLabel materialLabel4;
        public MaterialSkin.Controls.MaterialButton buttonHorari_addFranjaDivendres;
        public MaterialSkin.Controls.MaterialButton buttonHorari_addFranjaDijous;
        public MaterialSkin.Controls.MaterialButton buttonHorari_addFranjaDissabte;
        public MaterialSkin.Controls.MaterialButton buttonHorari_addFranjaDimecres;
        public MaterialSkin.Controls.MaterialButton buttonHorari_addFranjaDimarts;
        public MaterialSkin.Controls.MaterialButton buttonHorari_addFranjaDilluns;
        public MaterialSkin.Controls.MaterialButton buttonHorari_configurar;
        public System.Windows.Forms.Panel panelHorari_dijous;
        public System.Windows.Forms.Panel panelHorari_divendres;
        public System.Windows.Forms.Panel panelHorari_dissabte;
        public System.Windows.Forms.Panel panelHorari_dimecres;
        public System.Windows.Forms.Panel panelHorari_dimarts;
        public System.Windows.Forms.Panel panelHorari_dilluns;
        public MaterialSkin.Controls.MaterialButton buttonHorari_deleteFranjaDiumenge;
        public MaterialSkin.Controls.MaterialButton buttonHorari_deleteFranjaDissabte;
        public MaterialSkin.Controls.MaterialButton buttonHorari_deleteFranjaDivendres;
        public MaterialSkin.Controls.MaterialButton buttonHorari_deleteFranjaDijous;
        public MaterialSkin.Controls.MaterialButton buttonHorari_deleteFranjaDimecres;
        public MaterialSkin.Controls.MaterialButton buttonHorari_deleteFranjaDimarts;
        public MaterialSkin.Controls.MaterialButton buttonHorari_deleteFranjaDilluns;
        private MaterialSkin.Controls.MaterialLabel materialLabel25;
        public System.Windows.Forms.DataGridView dataGridViewTaula_taules;
        public MaterialSkin.Controls.MaterialButton buttonHorari_desassignarFestiu;
        public MaterialSkin.Controls.MaterialButton buttonHorari_assignarFestiu;
        public Pabo.Calendar.MonthCalendar monthCalendarHorari_horari;
        public MaterialSkin.Controls.MaterialButton buttonReserva_actualitzar;
        public System.Windows.Forms.PictureBox pictureBoxConfiguracio_imatgeRestaurant;
        public System.Windows.Forms.Button buttonConfiguracio_imatgeRestaurant;
        public System.Windows.Forms.TabPage tabPagePlats;
        public System.Windows.Forms.DataGridView dataGridViewMenu_plats;
        private MaterialSkin.Controls.MaterialLabel materialLabel26;
        public MaterialSkin.Controls.MaterialComboBox comboBoxMenu_tipusPlats;
        public MaterialSkin.Controls.MaterialButton buttonMenu_eliminar;
        public MaterialSkin.Controls.MaterialButton buttonMenu_editar;
        public MaterialSkin.Controls.MaterialButton buttonMenu_afegir;
        private MaterialSkin.Controls.MaterialLabel materialLabel27;
        private MaterialSkin.Controls.MaterialLabel materialLabel28;
        public MaterialSkin.Controls.MaterialLabel materialLabel32;
        public ComboBox comboBoxReserva_usuari;
        private MaterialSkin.Controls.MaterialLabel materialLabel33;
        public MaterialSkin.Controls.MaterialComboBox comboBoxTaula_comensals;
        public ComboBox comboBoxContacte_usuari;
        public MaterialSkin.Controls.MaterialLabel materialLabel34;
        private MaterialSkin.Controls.MaterialLabel materialLabel35;
        private MaterialSkin.Controls.MaterialLabel materialLabel36;
        public MaterialSkin.Controls.MaterialTextBox textBoxContacte_llegits;
        public MaterialSkin.Controls.MaterialTextBox textBoxContacte_noLlegits;
        public MaterialSkin.Controls.MaterialCheckbox checkBoxContacte_veureLlegits;
        private MaterialSkin.Controls.MaterialLabel materialLabel37;
        public MaterialSkin.Controls.MaterialLabel materialLabel39;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        public MaterialSkin.Controls.MaterialLabel materialLabel41;
        public MaterialSkin.Controls.MaterialLabel materialLabel40;
        private Panel panel4;
        public Panel panelHorari_diumenge;
        public MaterialSkin.Controls.MaterialLabel materialLabel24;
        public MaterialSkin.Controls.MaterialButton buttonHorari_addFranjaDiumenge;
        public MaterialSkin.Controls.MaterialLabel materialLabel42;
        public MaterialSkin.Controls.MaterialLabel materialLabel43;
        public MaterialSkin.Controls.MaterialLabel materialLabel38;
        public MaterialSkin.Controls.MaterialLabel materialLabel3;
        public MaterialSkin.Controls.MaterialLabel materialLabel44;
        public MaterialSkin.Controls.MaterialLabel materialLabel45;
        public MaterialSkin.Controls.MaterialLabel materialLabel46;
        public MaterialSkin.Controls.MaterialLabel materialLabel47;
        public MaterialSkin.Controls.MaterialLabel materialLabel48;
        public MaterialSkin.Controls.MaterialLabel materialLabel49;
        public MaterialSkin.Controls.MaterialLabel materialLabel50;
    }
}