namespace Taules.View
{
    partial class ObrirMissatgeForm
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
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.multiLineContacte_missatge = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.SuspendLayout();
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.AliceBlue;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(68, 85);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(66, 19);
            this.materialLabel5.TabIndex = 81;
            this.materialLabel5.Text = "Missatge";
            // 
            // multiLineContacte_missatge
            // 
            this.multiLineContacte_missatge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.multiLineContacte_missatge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.multiLineContacte_missatge.Depth = 0;
            this.multiLineContacte_missatge.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.multiLineContacte_missatge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.multiLineContacte_missatge.Location = new System.Drawing.Point(69, 107);
            this.multiLineContacte_missatge.MouseState = MaterialSkin.MouseState.HOVER;
            this.multiLineContacte_missatge.Name = "multiLineContacte_missatge";
            this.multiLineContacte_missatge.ReadOnly = true;
            this.multiLineContacte_missatge.Size = new System.Drawing.Size(755, 320);
            this.multiLineContacte_missatge.TabIndex = 83;
            this.multiLineContacte_missatge.Text = "";
            // 
            // ObrirMissatgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 463);
            this.Controls.Add(this.multiLineContacte_missatge);
            this.Controls.Add(this.materialLabel5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObrirMissatgeForm";
            this.Load += new System.EventHandler(this.ObrirMissatgeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        public MaterialSkin.Controls.MaterialMultiLineTextBox multiLineContacte_missatge;
    }
}