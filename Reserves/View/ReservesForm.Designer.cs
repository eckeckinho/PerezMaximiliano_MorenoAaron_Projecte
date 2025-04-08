namespace Reserves
{
    partial class ReservesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_afegir = new System.Windows.Forms.Button();
            this.dataGridView_reserves = new System.Windows.Forms.DataGridView();
            this.button_finalitzar = new System.Windows.Forms.Button();
            this.dateTimePicker_diareserva_desde = new System.Windows.Forms.DateTimePicker();
            this.comboBox_estatreserva = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_diareserva_hasta = new System.Windows.Forms.DateTimePicker();
            this.button_cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reserves)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "RESERVES";
            // 
            // button_afegir
            // 
            this.button_afegir.Location = new System.Drawing.Point(589, 41);
            this.button_afegir.Name = "button_afegir";
            this.button_afegir.Size = new System.Drawing.Size(71, 31);
            this.button_afegir.TabIndex = 51;
            this.button_afegir.Text = "AFEGIR";
            this.button_afegir.UseVisualStyleBackColor = true;
            // 
            // dataGridView_reserves
            // 
            this.dataGridView_reserves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_reserves.Location = new System.Drawing.Point(39, 148);
            this.dataGridView_reserves.Name = "dataGridView_reserves";
            this.dataGridView_reserves.ReadOnly = true;
            this.dataGridView_reserves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_reserves.Size = new System.Drawing.Size(621, 305);
            this.dataGridView_reserves.TabIndex = 53;
            // 
            // button_finalitzar
            // 
            this.button_finalitzar.Location = new System.Drawing.Point(493, 491);
            this.button_finalitzar.Name = "button_finalitzar";
            this.button_finalitzar.Size = new System.Drawing.Size(80, 36);
            this.button_finalitzar.TabIndex = 54;
            this.button_finalitzar.Text = "FINALITZAR";
            this.button_finalitzar.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_diareserva_desde
            // 
            this.dateTimePicker_diareserva_desde.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_diareserva_desde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_diareserva_desde.Location = new System.Drawing.Point(39, 109);
            this.dateTimePicker_diareserva_desde.Name = "dateTimePicker_diareserva_desde";
            this.dateTimePicker_diareserva_desde.Size = new System.Drawing.Size(164, 20);
            this.dateTimePicker_diareserva_desde.TabIndex = 55;
            // 
            // comboBox_estatreserva
            // 
            this.comboBox_estatreserva.FormattingEnabled = true;
            this.comboBox_estatreserva.Location = new System.Drawing.Point(539, 112);
            this.comboBox_estatreserva.Name = "comboBox_estatreserva";
            this.comboBox_estatreserva.Size = new System.Drawing.Size(121, 21);
            this.comboBox_estatreserva.TabIndex = 56;
            // 
            // dateTimePicker_diareserva_hasta
            // 
            this.dateTimePicker_diareserva_hasta.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_diareserva_hasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_diareserva_hasta.Location = new System.Drawing.Point(209, 109);
            this.dateTimePicker_diareserva_hasta.Name = "dateTimePicker_diareserva_hasta";
            this.dateTimePicker_diareserva_hasta.Size = new System.Drawing.Size(164, 20);
            this.dateTimePicker_diareserva_hasta.TabIndex = 57;
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(580, 491);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(80, 36);
            this.button_cancelar.TabIndex = 58;
            this.button_cancelar.Text = "CANCELAR";
            this.button_cancelar.UseVisualStyleBackColor = true;
            // 
            // ReservesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 579);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.dateTimePicker_diareserva_hasta);
            this.Controls.Add(this.comboBox_estatreserva);
            this.Controls.Add(this.dateTimePicker_diareserva_desde);
            this.Controls.Add(this.button_finalitzar);
            this.Controls.Add(this.dataGridView_reserves);
            this.Controls.Add(this.button_afegir);
            this.Controls.Add(this.label1);
            this.Name = "ReservesForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_reserves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_afegir;
        public System.Windows.Forms.DataGridView dataGridView_reserves;
        public System.Windows.Forms.Button button_finalitzar;
        public System.Windows.Forms.DateTimePicker dateTimePicker_diareserva_desde;
        public System.Windows.Forms.ComboBox comboBox_estatreserva;
        public System.Windows.Forms.DateTimePicker dateTimePicker_diareserva_hasta;
        public System.Windows.Forms.Button button_cancelar;
    }
}

