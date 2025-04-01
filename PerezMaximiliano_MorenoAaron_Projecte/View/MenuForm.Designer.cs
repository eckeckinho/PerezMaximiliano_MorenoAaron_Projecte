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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_reserves = new System.Windows.Forms.Button();
            this.button_taules = new System.Windows.Forms.Button();
            this.button_configuracio = new System.Windows.Forms.Button();
            this.button_contacte = new System.Windows.Forms.Button();
            this.button_horari = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(255, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 112);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(298, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOM RESTAURANT";
            // 
            // button_reserves
            // 
            this.button_reserves.Location = new System.Drawing.Point(51, 199);
            this.button_reserves.Name = "button_reserves";
            this.button_reserves.Size = new System.Drawing.Size(119, 46);
            this.button_reserves.TabIndex = 2;
            this.button_reserves.Text = "RESERVES";
            this.button_reserves.UseVisualStyleBackColor = true;
            // 
            // button_taules
            // 
            this.button_taules.Location = new System.Drawing.Point(191, 199);
            this.button_taules.Name = "button_taules";
            this.button_taules.Size = new System.Drawing.Size(119, 46);
            this.button_taules.TabIndex = 3;
            this.button_taules.Text = "TAULES";
            this.button_taules.UseVisualStyleBackColor = true;
            // 
            // button_configuracio
            // 
            this.button_configuracio.Location = new System.Drawing.Point(472, 199);
            this.button_configuracio.Name = "button_configuracio";
            this.button_configuracio.Size = new System.Drawing.Size(119, 46);
            this.button_configuracio.TabIndex = 4;
            this.button_configuracio.Text = "CONFIGURACIÓ";
            this.button_configuracio.UseVisualStyleBackColor = true;
            // 
            // button_contacte
            // 
            this.button_contacte.Location = new System.Drawing.Point(332, 199);
            this.button_contacte.Name = "button_contacte";
            this.button_contacte.Size = new System.Drawing.Size(119, 46);
            this.button_contacte.TabIndex = 5;
            this.button_contacte.Text = "CONTACTE";
            this.button_contacte.UseVisualStyleBackColor = true;
            // 
            // button_horari
            // 
            this.button_horari.Location = new System.Drawing.Point(613, 199);
            this.button_horari.Name = "button_horari";
            this.button_horari.Size = new System.Drawing.Size(119, 46);
            this.button_horari.TabIndex = 6;
            this.button_horari.Text = "HORARI";
            this.button_horari.UseVisualStyleBackColor = true;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 290);
            this.Controls.Add(this.button_horari);
            this.Controls.Add(this.button_contacte);
            this.Controls.Add(this.button_configuracio);
            this.Controls.Add(this.button_taules);
            this.Controls.Add(this.button_reserves);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_reserves;
        private System.Windows.Forms.Button button_taules;
        private System.Windows.Forms.Button button_configuracio;
        private System.Windows.Forms.Button button_contacte;
        private System.Windows.Forms.Button button_horari;
    }
}