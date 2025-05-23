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
            this.numericUpDownTaula_numcomensals = new System.Windows.Forms.NumericUpDown();
            this.buttonTaula_afegir_editar = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTaula_numcomensals)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownTaula_numcomensals
            // 
            this.numericUpDownTaula_numcomensals.Location = new System.Drawing.Point(222, 114);
            this.numericUpDownTaula_numcomensals.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTaula_numcomensals.Name = "numericUpDownTaula_numcomensals";
            this.numericUpDownTaula_numcomensals.Size = new System.Drawing.Size(114, 20);
            this.numericUpDownTaula_numcomensals.TabIndex = 2;
            this.numericUpDownTaula_numcomensals.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonTaula_afegir_editar
            // 
            this.buttonTaula_afegir_editar.AutoSize = false;
            this.buttonTaula_afegir_editar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonTaula_afegir_editar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonTaula_afegir_editar.Depth = 0;
            this.buttonTaula_afegir_editar.HighEmphasis = true;
            this.buttonTaula_afegir_editar.Icon = null;
            this.buttonTaula_afegir_editar.Location = new System.Drawing.Point(222, 171);
            this.buttonTaula_afegir_editar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonTaula_afegir_editar.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonTaula_afegir_editar.Name = "buttonTaula_afegir_editar";
            this.buttonTaula_afegir_editar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonTaula_afegir_editar.Size = new System.Drawing.Size(114, 20);
            this.buttonTaula_afegir_editar.TabIndex = 4;
            this.buttonTaula_afegir_editar.Text = "AFEGIR";
            this.buttonTaula_afegir_editar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonTaula_afegir_editar.UseAccentColor = false;
            this.buttonTaula_afegir_editar.UseVisualStyleBackColor = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(47, 114);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(159, 19);
            this.materialLabel5.TabIndex = 81;
            this.materialLabel5.Text = "Número de comensals";
            // 
            // AfegirTaulaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 229);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.buttonTaula_afegir_editar);
            this.Controls.Add(this.numericUpDownTaula_numcomensals);
            this.MaximizeBox = false;
            this.Name = "AfegirTaulaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Afegir taula";
            this.Load += new System.EventHandler(this.AfegirTaulaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTaula_numcomensals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.NumericUpDown numericUpDownTaula_numcomensals;
        public MaterialSkin.Controls.MaterialButton buttonTaula_afegir_editar;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}