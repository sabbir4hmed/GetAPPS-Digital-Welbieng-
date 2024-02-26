namespace GetAPPS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            comboBoxDistrict = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            comboBox = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(290, 90);
            button1.Name = "button1";
            button1.Size = new Size(44, 40);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Tomato;
            label1.Location = new Point(361, 88);
            label1.Name = "label1";
            label1.Size = new Size(225, 39);
            label1.TabIndex = 2;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ButtonFace;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(13, 8);
            label2.Name = "label2";
            label2.Size = new Size(623, 57);
            label2.TabIndex = 3;
            label2.Text = "Please enable USB debugging mode before use this tool   First select your Region then click the play button";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(602, 96);
            button2.Name = "button2";
            button2.Size = new Size(34, 33);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBoxDistrict
            // 
            comboBoxDistrict.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDistrict.FormattingEnabled = true;
            comboBoxDistrict.ImeMode = ImeMode.On;
            comboBoxDistrict.Items.AddRange(new object[] { "Bagerhat                           ", "Bandarban                          ", "Barguna                       ", "Barisal                       ", "Bhola                              ", "Bogra                              ", "Brahmanbaria                       ", "Chandpur                           ", "Chittagong                         ", "Chuadanga                          ", "Comilla                            ", "Cox''s Bazar                       ", "Dhaka", "Dinajpur                           ", "Faridpur", "Feni                               ", "Gaibandha                          ", "Gazipur", "Gopalganj", "Habiganj                           ", "Jamalpur", "Jessore                            ", "Jhalokati                          ", "Jhenaidah                          ", "Joypurhat                         ", "Khagrachari                        ", "Khulna                             ", "Kishoreganj", "Kurigram                           ", "Kushtia                             ", "Lakshmipur                         ", "Lalmonirhat                        ", "Madaripur", "Magura                             ", "Manikganj", "Maulvibazar                        ", "Meherpur                           ", "Munshiganj", "Mymensingh", "Naogaon                      ", "Narail                             ", "Narayanganj", "Narsingdi", "Natore                             ", "Nawabganj                          ", "Netrokona", "Nilphamari                         ", "Noakhali                           ", "Pabna                              ", "Panchagarh                         ", "Patuakhali                         ", "Pirojpur                          ", "Rajbari", "Rajshahi                         ", "Rangamati                          ", "Rangpur                            ", "Satkhira", "Shariatpur", "Sherpur", "Sirajgonj                           ", "Sunamganj                          ", "Sylhet                             ", "Tangail                         ", "Thakurgaon                         " });
            comboBoxDistrict.Location = new Point(12, 101);
            comboBoxDistrict.Name = "comboBoxDistrict";
            comboBoxDistrict.Size = new Size(121, 23);
            comboBoxDistrict.Sorted = true;
            comboBoxDistrict.TabIndex = 5;
            comboBoxDistrict.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 75);
            label3.Name = "label3";
            label3.Size = new Size(59, 21);
            label3.TabIndex = 6;
            label3.Text = "Region";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(156, 77);
            label4.Name = "label4";
            label4.Size = new Size(37, 21);
            label4.TabIndex = 8;
            label4.Text = "Age";
            // 
            // comboBox
            // 
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FormattingEnabled = true;
            comboBox.ImeMode = ImeMode.On;
            comboBox.Location = new Point(156, 102);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(121, 23);
            comboBox.Sorted = true;
            comboBox.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(648, 137);
            Controls.Add(comboBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxDistrict);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digital Welbing Data";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Button button2;
        private ComboBox comboBoxDistrict;
        private Label label3;
        private Label label4;
        private ComboBox comboBox;
    }
}
