namespace PerezMaximiliano_MorenoAaron_Projecte.View
{
    partial class IniciarSessioForm
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
            this.textBox_usuari = new System.Windows.Forms.TextBox();
            this.textBox_contrasenya = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_entrar = new System.Windows.Forms.Button();
            this.button_regisrest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(109, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "INICIAR SESSIÓ";
            // 
            // textBox_usuari
            // 
            this.textBox_usuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox_usuari.Location = new System.Drawing.Point(100, 125);
            this.textBox_usuari.Multiline = true;
            this.textBox_usuari.Name = "textBox_usuari";
            this.textBox_usuari.Size = new System.Drawing.Size(191, 27);
            this.textBox_usuari.TabIndex = 1;
            // 
            // textBox_contrasenya
            // 
            this.textBox_contrasenya.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.textBox_contrasenya.Location = new System.Drawing.Point(100, 201);
            this.textBox_contrasenya.Multiline = true;
            this.textBox_contrasenya.Name = "textBox_contrasenya";
            this.textBox_contrasenya.Size = new System.Drawing.Size(191, 27);
            this.textBox_contrasenya.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuari";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contrasenya";
            // 
            // button_entrar
            // 
            this.button_entrar.Location = new System.Drawing.Point(138, 260);
            this.button_entrar.Name = "button_entrar";
            this.button_entrar.Size = new System.Drawing.Size(97, 32);
            this.button_entrar.TabIndex = 5;
            this.button_entrar.Text = "ENTRAR";
            this.button_entrar.UseVisualStyleBackColor = true;
            // 
            // button_regisrest
            // 
            this.button_regisrest.Location = new System.Drawing.Point(138, 350);
            this.button_regisrest.Name = "button_regisrest";
            this.button_regisrest.Size = new System.Drawing.Size(97, 61);
            this.button_regisrest.TabIndex = 6;
            this.button_regisrest.Text = "REGISTRAR RESTAURANT";
            this.button_regisrest.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "O";
            // 
            // IniciarSessioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 475);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_regisrest);
            this.Controls.Add(this.button_entrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_contrasenya);
            this.Controls.Add(this.textBox_usuari);
            this.Controls.Add(this.label1);
            this.Name = "IniciarSessioForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button_entrar;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox_contrasenya;
        public System.Windows.Forms.Button button_regisrest;
        public System.Windows.Forms.TextBox textBox_usuari;
    }
}

