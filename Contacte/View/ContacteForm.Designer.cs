namespace Contacte
{
    partial class ContacteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContacteForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_filtre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_filtre = new System.Windows.Forms.ComboBox();
            this.button_cercar = new System.Windows.Forms.Button();
            this.dateTimePicker_contacte = new System.Windows.Forms.DateTimePicker();
            this.dataGridView_contacte = new System.Windows.Forms.DataGridView();
            this.button_obrir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_contacte)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "CONTACTE";
            // 
            // textBox_filtre
            // 
            this.textBox_filtre.Location = new System.Drawing.Point(92, 70);
            this.textBox_filtre.Name = "textBox_filtre";
            this.textBox_filtre.Size = new System.Drawing.Size(282, 20);
            this.textBox_filtre.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Filtrar";
            // 
            // comboBox_filtre
            // 
            this.comboBox_filtre.FormattingEnabled = true;
            this.comboBox_filtre.Location = new System.Drawing.Point(400, 69);
            this.comboBox_filtre.Name = "comboBox_filtre";
            this.comboBox_filtre.Size = new System.Drawing.Size(121, 21);
            this.comboBox_filtre.TabIndex = 52;
            // 
            // button_cercar
            // 
            this.button_cercar.Image = ((System.Drawing.Image)(resources.GetObject("button_cercar.Image")));
            this.button_cercar.Location = new System.Drawing.Point(691, 62);
            this.button_cercar.Name = "button_cercar";
            this.button_cercar.Size = new System.Drawing.Size(42, 34);
            this.button_cercar.TabIndex = 53;
            this.button_cercar.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_contacte
            // 
            this.dateTimePicker_contacte.Location = new System.Drawing.Point(537, 70);
            this.dateTimePicker_contacte.Name = "dateTimePicker_contacte";
            this.dateTimePicker_contacte.Size = new System.Drawing.Size(133, 20);
            this.dateTimePicker_contacte.TabIndex = 54;
            // 
            // dataGridView_contacte
            // 
            this.dataGridView_contacte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_contacte.Location = new System.Drawing.Point(57, 111);
            this.dataGridView_contacte.Name = "dataGridView_contacte";
            this.dataGridView_contacte.Size = new System.Drawing.Size(676, 345);
            this.dataGridView_contacte.TabIndex = 55;
            // 
            // button_obrir
            // 
            this.button_obrir.Location = new System.Drawing.Point(657, 484);
            this.button_obrir.Name = "button_obrir";
            this.button_obrir.Size = new System.Drawing.Size(75, 23);
            this.button_obrir.TabIndex = 56;
            this.button_obrir.Text = "OBRIR";
            this.button_obrir.UseVisualStyleBackColor = true;
            // 
            // ContacteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.button_obrir);
            this.Controls.Add(this.dataGridView_contacte);
            this.Controls.Add(this.dateTimePicker_contacte);
            this.Controls.Add(this.button_cercar);
            this.Controls.Add(this.comboBox_filtre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_filtre);
            this.Controls.Add(this.label1);
            this.Name = "ContacteForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_contacte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox_filtre;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBox_filtre;
        public System.Windows.Forms.Button button_cercar;
        public System.Windows.Forms.DateTimePicker dateTimePicker_contacte;
        public System.Windows.Forms.DataGridView dataGridView_contacte;
        public System.Windows.Forms.Button button_obrir;
    }
}

