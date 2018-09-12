namespace ZipPassword
{
    partial class Form_ZIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ZIP));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenfile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxClosed = new System.Windows.Forms.CheckBox();
            this.tbxPathToFile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtSpecial = new System.Windows.Forms.RadioButton();
            this.rbtNumbers = new System.Windows.Forms.RadioButton();
            this.rbtLetters = new System.Windows.Forms.RadioButton();
            this.rbtRandom = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtPrecision4 = new System.Windows.Forms.RadioButton();
            this.rbtPrecision3 = new System.Windows.Forms.RadioButton();
            this.rbtPrecision2 = new System.Windows.Forms.RadioButton();
            this.rbtPrecision1 = new System.Windows.Forms.RadioButton();
            this.btnZip = new System.Windows.Forms.Button();
            this.rbtFile = new System.Windows.Forms.RadioButton();
            this.rbtDictionary = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenfile
            // 
            this.btnOpenfile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenfile.Image")));
            this.btnOpenfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenfile.Location = new System.Drawing.Point(246, 19);
            this.btnOpenfile.Name = "btnOpenfile";
            this.btnOpenfile.Size = new System.Drawing.Size(75, 37);
            this.btnOpenfile.TabIndex = 0;
            this.btnOpenfile.Text = "Wybierz";
            this.btnOpenfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenfile.UseVisualStyleBackColor = true;
            this.btnOpenfile.Click += new System.EventHandler(this.btnOpenfile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtDictionary);
            this.groupBox1.Controls.Add(this.rbtFile);
            this.groupBox1.Controls.Add(this.checkBoxClosed);
            this.groupBox1.Controls.Add(this.tbxPathToFile);
            this.groupBox1.Controls.Add(this.btnOpenfile);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 105);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ścieżka do pliku lub folderu";
            // 
            // checkBoxClosed
            // 
            this.checkBoxClosed.AutoSize = true;
            this.checkBoxClosed.Location = new System.Drawing.Point(69, 64);
            this.checkBoxClosed.Name = "checkBoxClosed";
            this.checkBoxClosed.Size = new System.Drawing.Size(263, 17);
            this.checkBoxClosed.TabIndex = 4;
            this.checkBoxClosed.Text = "Zamknij program po skompresowaniu pliku/folderu";
            this.checkBoxClosed.UseVisualStyleBackColor = true;
            // 
            // tbxPathToFile
            // 
            this.tbxPathToFile.Location = new System.Drawing.Point(7, 20);
            this.tbxPathToFile.Multiline = true;
            this.tbxPathToFile.Name = "tbxPathToFile";
            this.tbxPathToFile.ReadOnly = true;
            this.tbxPathToFile.Size = new System.Drawing.Size(227, 36);
            this.tbxPathToFile.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtSpecial);
            this.groupBox2.Controls.Add(this.rbtNumbers);
            this.groupBox2.Controls.Add(this.rbtLetters);
            this.groupBox2.Controls.Add(this.rbtRandom);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 120);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wybór rodzaju szyfrowania";
            // 
            // rbtSpecial
            // 
            this.rbtSpecial.AutoSize = true;
            this.rbtSpecial.Location = new System.Drawing.Point(7, 90);
            this.rbtSpecial.Name = "rbtSpecial";
            this.rbtSpecial.Size = new System.Drawing.Size(66, 17);
            this.rbtSpecial.TabIndex = 3;
            this.rbtSpecial.TabStop = true;
            this.rbtSpecial.Text = "Specjale";
            this.rbtSpecial.UseVisualStyleBackColor = true;
            // 
            // rbtNumbers
            // 
            this.rbtNumbers.AutoSize = true;
            this.rbtNumbers.Location = new System.Drawing.Point(7, 67);
            this.rbtNumbers.Name = "rbtNumbers";
            this.rbtNumbers.Size = new System.Drawing.Size(48, 17);
            this.rbtNumbers.TabIndex = 2;
            this.rbtNumbers.TabStop = true;
            this.rbtNumbers.Text = "Cyfry";
            this.rbtNumbers.UseVisualStyleBackColor = true;
            // 
            // rbtLetters
            // 
            this.rbtLetters.AutoSize = true;
            this.rbtLetters.Location = new System.Drawing.Point(7, 44);
            this.rbtLetters.Name = "rbtLetters";
            this.rbtLetters.Size = new System.Drawing.Size(50, 17);
            this.rbtLetters.TabIndex = 1;
            this.rbtLetters.TabStop = true;
            this.rbtLetters.Text = "Litery";
            this.rbtLetters.UseVisualStyleBackColor = true;
            // 
            // rbtRandom
            // 
            this.rbtRandom.AutoSize = true;
            this.rbtRandom.Location = new System.Drawing.Point(7, 19);
            this.rbtRandom.Name = "rbtRandom";
            this.rbtRandom.Size = new System.Drawing.Size(62, 17);
            this.rbtRandom.TabIndex = 0;
            this.rbtRandom.TabStop = true;
            this.rbtRandom.Text = "Losowe";
            this.rbtRandom.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtPrecision4);
            this.groupBox3.Controls.Add(this.rbtPrecision3);
            this.groupBox3.Controls.Add(this.rbtPrecision2);
            this.groupBox3.Controls.Add(this.rbtPrecision1);
            this.groupBox3.Location = new System.Drawing.Point(170, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(76, 120);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Siła hasła";
            // 
            // rbtPrecision4
            // 
            this.rbtPrecision4.AutoSize = true;
            this.rbtPrecision4.Location = new System.Drawing.Point(15, 92);
            this.rbtPrecision4.Name = "rbtPrecision4";
            this.rbtPrecision4.Size = new System.Drawing.Size(31, 17);
            this.rbtPrecision4.TabIndex = 3;
            this.rbtPrecision4.TabStop = true;
            this.rbtPrecision4.Text = "4";
            this.rbtPrecision4.UseVisualStyleBackColor = true;
            // 
            // rbtPrecision3
            // 
            this.rbtPrecision3.AutoSize = true;
            this.rbtPrecision3.Location = new System.Drawing.Point(15, 68);
            this.rbtPrecision3.Name = "rbtPrecision3";
            this.rbtPrecision3.Size = new System.Drawing.Size(31, 17);
            this.rbtPrecision3.TabIndex = 2;
            this.rbtPrecision3.TabStop = true;
            this.rbtPrecision3.Text = "3";
            this.rbtPrecision3.UseVisualStyleBackColor = true;
            // 
            // rbtPrecision2
            // 
            this.rbtPrecision2.AutoSize = true;
            this.rbtPrecision2.Location = new System.Drawing.Point(15, 44);
            this.rbtPrecision2.Name = "rbtPrecision2";
            this.rbtPrecision2.Size = new System.Drawing.Size(31, 17);
            this.rbtPrecision2.TabIndex = 1;
            this.rbtPrecision2.TabStop = true;
            this.rbtPrecision2.Text = "2";
            this.rbtPrecision2.UseVisualStyleBackColor = true;
            // 
            // rbtPrecision1
            // 
            this.rbtPrecision1.AutoSize = true;
            this.rbtPrecision1.Location = new System.Drawing.Point(15, 20);
            this.rbtPrecision1.Name = "rbtPrecision1";
            this.rbtPrecision1.Size = new System.Drawing.Size(31, 17);
            this.rbtPrecision1.TabIndex = 0;
            this.rbtPrecision1.TabStop = true;
            this.rbtPrecision1.Text = "1";
            this.rbtPrecision1.UseVisualStyleBackColor = true;
            // 
            // btnZip
            // 
            this.btnZip.Image = ((System.Drawing.Image)(resources.GetObject("btnZip.Image")));
            this.btnZip.Location = new System.Drawing.Point(258, 129);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(75, 110);
            this.btnZip.TabIndex = 4;
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // rbtFile
            // 
            this.rbtFile.AutoSize = true;
            this.rbtFile.Location = new System.Drawing.Point(7, 63);
            this.rbtFile.Name = "rbtFile";
            this.rbtFile.Size = new System.Drawing.Size(42, 17);
            this.rbtFile.TabIndex = 5;
            this.rbtFile.TabStop = true;
            this.rbtFile.Text = "Plik";
            this.rbtFile.UseVisualStyleBackColor = true;
            // 
            // rbtDictionary
            // 
            this.rbtDictionary.AutoSize = true;
            this.rbtDictionary.Location = new System.Drawing.Point(7, 82);
            this.rbtDictionary.Name = "rbtDictionary";
            this.rbtDictionary.Size = new System.Drawing.Size(54, 17);
            this.rbtDictionary.TabIndex = 6;
            this.rbtDictionary.TabStop = true;
            this.rbtDictionary.Text = "Folder";
            this.rbtDictionary.UseVisualStyleBackColor = true;
            // 
            // Form_ZIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 249);
            this.Controls.Add(this.btnZip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ZIP";
            this.Text = "ZIP z hasłem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenfile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxPathToFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtSpecial;
        private System.Windows.Forms.RadioButton rbtNumbers;
        private System.Windows.Forms.RadioButton rbtLetters;
        private System.Windows.Forms.RadioButton rbtRandom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtPrecision4;
        private System.Windows.Forms.RadioButton rbtPrecision3;
        private System.Windows.Forms.RadioButton rbtPrecision2;
        private System.Windows.Forms.RadioButton rbtPrecision1;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.CheckBox checkBoxClosed;
        private System.Windows.Forms.RadioButton rbtDictionary;
        private System.Windows.Forms.RadioButton rbtFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

