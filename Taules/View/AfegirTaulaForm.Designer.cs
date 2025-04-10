namespace Taules.View
{
    partial class AfegirTaulaForm
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
            this.numericUpDown_numcomensals = new System.Windows.Forms.NumericUpDown();
            this.button_afegir_editar_taula = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numcomensals)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de comensals";
            // 
            // numericUpDown_numcomensals
            // 
            this.numericUpDown_numcomensals.Location = new System.Drawing.Point(181, 37);
            this.numericUpDown_numcomensals.Name = "numericUpDown_numcomensals";
            this.numericUpDown_numcomensals.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_numcomensals.TabIndex = 2;
            // 
            // button_afegir_editar_taula
            // 
            this.button_afegir_editar_taula.Location = new System.Drawing.Point(226, 79);
            this.button_afegir_editar_taula.Name = "button_afegir_editar_taula";
            this.button_afegir_editar_taula.Size = new System.Drawing.Size(75, 23);
            this.button_afegir_editar_taula.TabIndex = 3;
            this.button_afegir_editar_taula.Text = "AFEGIR";
            this.button_afegir_editar_taula.UseVisualStyleBackColor = true;
            // 
            // AfegirTaulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 125);
            this.Controls.Add(this.button_afegir_editar_taula);
            this.Controls.Add(this.numericUpDown_numcomensals);
            this.Controls.Add(this.label1);
            this.Name = "AfegirTaulaForm";
            this.Text = "AfegirTaulaForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numcomensals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericUpDown_numcomensals;
        public System.Windows.Forms.Button button_afegir_editar_taula;
    }
}