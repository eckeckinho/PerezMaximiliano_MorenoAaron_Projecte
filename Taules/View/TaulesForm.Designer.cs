namespace Taules
{
    partial class TaulesForm
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
            this.button_editar = new System.Windows.Forms.Button();
            this.textBox_aforamentActual = new System.Windows.Forms.TextBox();
            this.textBox_aforamentMaxim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_taules = new System.Windows.Forms.DataGridView();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.button_afegir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_taules)).BeginInit();
            this.SuspendLayout();
            // 
            // button_editar
            // 
            this.button_editar.Location = new System.Drawing.Point(437, 46);
            this.button_editar.Name = "button_editar";
            this.button_editar.Size = new System.Drawing.Size(67, 31);
            this.button_editar.TabIndex = 67;
            this.button_editar.Text = "EDITAR";
            this.button_editar.UseVisualStyleBackColor = true;
            // 
            // textBox_aforamentActual
            // 
            this.textBox_aforamentActual.Location = new System.Drawing.Point(544, 372);
            this.textBox_aforamentActual.Name = "textBox_aforamentActual";
            this.textBox_aforamentActual.ReadOnly = true;
            this.textBox_aforamentActual.Size = new System.Drawing.Size(58, 20);
            this.textBox_aforamentActual.TabIndex = 66;
            // 
            // textBox_aforamentMaxim
            // 
            this.textBox_aforamentMaxim.Location = new System.Drawing.Point(544, 402);
            this.textBox_aforamentMaxim.Name = "textBox_aforamentMaxim";
            this.textBox_aforamentMaxim.ReadOnly = true;
            this.textBox_aforamentMaxim.Size = new System.Drawing.Size(58, 20);
            this.textBox_aforamentMaxim.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "AFORAMEN ACTUAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "AFORAMENT MÀXIM";
            // 
            // dataGridView_taules
            // 
            this.dataGridView_taules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_taules.Location = new System.Drawing.Point(42, 83);
            this.dataGridView_taules.Name = "dataGridView_taules";
            this.dataGridView_taules.ReadOnly = true;
            this.dataGridView_taules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_taules.Size = new System.Drawing.Size(560, 262);
            this.dataGridView_taules.TabIndex = 62;
            // 
            // button_eliminar
            // 
            this.button_eliminar.Location = new System.Drawing.Point(510, 46);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(73, 31);
            this.button_eliminar.TabIndex = 61;
            this.button_eliminar.Text = "ELIMINAR";
            this.button_eliminar.UseVisualStyleBackColor = true;
            // 
            // button_afegir
            // 
            this.button_afegir.Location = new System.Drawing.Point(360, 46);
            this.button_afegir.Name = "button_afegir";
            this.button_afegir.Size = new System.Drawing.Size(71, 31);
            this.button_afegir.TabIndex = 60;
            this.button_afegir.Text = "AFEGIR";
            this.button_afegir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "TAULES";
            // 
            // TaulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 450);
            this.Controls.Add(this.button_editar);
            this.Controls.Add(this.textBox_aforamentActual);
            this.Controls.Add(this.textBox_aforamentMaxim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView_taules);
            this.Controls.Add(this.button_eliminar);
            this.Controls.Add(this.button_afegir);
            this.Controls.Add(this.label1);
            this.Name = "TaulesForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_taules)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_editar;
        public System.Windows.Forms.TextBox textBox_aforamentActual;
        public System.Windows.Forms.TextBox textBox_aforamentMaxim;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dataGridView_taules;
        public System.Windows.Forms.Button button_eliminar;
        public System.Windows.Forms.Button button_afegir;
    }
}

