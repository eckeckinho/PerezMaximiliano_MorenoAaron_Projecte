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
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.label_nomrestaurant = new System.Windows.Forms.Label();
            this.button_reserves = new System.Windows.Forms.Button();
            this.button_taules = new System.Windows.Forms.Button();
            this.button_configuracio = new System.Windows.Forms.Button();
            this.button_contacte = new System.Windows.Forms.Button();
            this.button_horari = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.Location = new System.Drawing.Point(255, 26);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(259, 112);
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // label_nomrestaurant
            // 
            this.label_nomrestaurant.AutoSize = true;
            this.label_nomrestaurant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label_nomrestaurant.Location = new System.Drawing.Point(298, 154);
            this.label_nomrestaurant.Name = "label_nomrestaurant";
            this.label_nomrestaurant.Size = new System.Drawing.Size(165, 20);
            this.label_nomrestaurant.TabIndex = 1;
            this.label_nomrestaurant.Text = "NOM RESTAURANT";
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
            this.Controls.Add(this.label_nomrestaurant);
            this.Controls.Add(this.pictureBox_logo);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox pictureBox_logo;
        public System.Windows.Forms.Label label_nomrestaurant;
        public System.Windows.Forms.Button button_reserves;
        public System.Windows.Forms.Button button_taules;
        public System.Windows.Forms.Button button_contacte;
        public System.Windows.Forms.Button button_configuracio;
        public System.Windows.Forms.Button button_horari;
    }
}