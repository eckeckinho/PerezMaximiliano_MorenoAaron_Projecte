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
            this.dataGridView_taules = new System.Windows.Forms.DataGridView();
            this.button_guardar = new System.Windows.Forms.Button();
            this.dateTimePicker_diareserva = new System.Windows.Forms.DateTimePicker();
            this.comboBox_estatreserva = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_taules)).BeginInit();
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
            // dataGridView_taules
            // 
            this.dataGridView_taules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_taules.Location = new System.Drawing.Point(39, 148);
            this.dataGridView_taules.Name = "dataGridView_taules";
            this.dataGridView_taules.Size = new System.Drawing.Size(621, 305);
            this.dataGridView_taules.TabIndex = 53;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(580, 491);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(80, 36);
            this.button_guardar.TabIndex = 54;
            this.button_guardar.Text = "GUARDAR";
            this.button_guardar.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_diareserva
            // 
            this.dateTimePicker_diareserva.Location = new System.Drawing.Point(496, 110);
            this.dateTimePicker_diareserva.Name = "dateTimePicker_diareserva";
            this.dateTimePicker_diareserva.Size = new System.Drawing.Size(164, 20);
            this.dateTimePicker_diareserva.TabIndex = 55;
            // 
            // comboBox_estatreserva
            // 
            this.comboBox_estatreserva.FormattingEnabled = true;
            this.comboBox_estatreserva.Location = new System.Drawing.Point(336, 110);
            this.comboBox_estatreserva.Name = "comboBox_estatreserva";
            this.comboBox_estatreserva.Size = new System.Drawing.Size(121, 21);
            this.comboBox_estatreserva.TabIndex = 56;
            // 
            // ReservesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 579);
            this.Controls.Add(this.comboBox_estatreserva);
            this.Controls.Add(this.dateTimePicker_diareserva);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.dataGridView_taules);
            this.Controls.Add(this.button_afegir);
            this.Controls.Add(this.label1);
            this.Name = "ReservesForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_taules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_afegir;
        public System.Windows.Forms.DataGridView dataGridView_taules;
        public System.Windows.Forms.Button button_guardar;
        public System.Windows.Forms.DateTimePicker dateTimePicker_diareserva;
        public System.Windows.Forms.ComboBox comboBox_estatreserva;
    }
}

