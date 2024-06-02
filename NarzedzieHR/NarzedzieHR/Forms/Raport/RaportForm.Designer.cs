namespace NarzedzieHR.Forms.Raport
{
    partial class RaportForm
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
            this.cbxDzial = new System.Windows.Forms.ComboBox();
            this.cbxPracownik = new System.Windows.Forms.ComboBox();
            this.nudPrzepracowaneGodziny = new System.Windows.Forms.NumericUpDown();
            this.txtWynagrodzenie = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridViewRaporty = new System.Windows.Forms.DataGridView();
            this.cbxStanowisko = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrzepracowaneGodziny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaporty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxDzial
            // 
            this.cbxDzial.FormattingEnabled = true;
            this.cbxDzial.Location = new System.Drawing.Point(184, 40);
            this.cbxDzial.Name = "cbxDzial";
            this.cbxDzial.Size = new System.Drawing.Size(121, 24);
            this.cbxDzial.TabIndex = 0;
            // 
            // cbxPracownik
            // 
            this.cbxPracownik.FormattingEnabled = true;
            this.cbxPracownik.Location = new System.Drawing.Point(184, 87);
            this.cbxPracownik.Name = "cbxPracownik";
            this.cbxPracownik.Size = new System.Drawing.Size(121, 24);
            this.cbxPracownik.TabIndex = 1;
            // 
            // nudPrzepracowaneGodziny
            // 
            this.nudPrzepracowaneGodziny.Location = new System.Drawing.Point(535, 89);
            this.nudPrzepracowaneGodziny.Name = "nudPrzepracowaneGodziny";
            this.nudPrzepracowaneGodziny.Size = new System.Drawing.Size(120, 22);
            this.nudPrzepracowaneGodziny.TabIndex = 2;
            // 
            // txtWynagrodzenie
            // 
            this.txtWynagrodzenie.Location = new System.Drawing.Point(184, 141);
            this.txtWynagrodzenie.Name = "txtWynagrodzenie";
            this.txtWynagrodzenie.ReadOnly = true;
            this.txtWynagrodzenie.Size = new System.Drawing.Size(121, 22);
            this.txtWynagrodzenie.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.Location = new System.Drawing.Point(372, 128);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(284, 35);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Zaksięguj";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // dataGridViewRaporty
            // 
            this.dataGridViewRaporty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRaporty.Location = new System.Drawing.Point(29, 208);
            this.dataGridViewRaporty.Name = "dataGridViewRaporty";
            this.dataGridViewRaporty.RowHeadersWidth = 51;
            this.dataGridViewRaporty.RowTemplate.Height = 24;
            this.dataGridViewRaporty.Size = new System.Drawing.Size(856, 280);
            this.dataGridViewRaporty.TabIndex = 5;
            // 
            // cbxStanowisko
            // 
            this.cbxStanowisko.FormattingEnabled = true;
            this.cbxStanowisko.Location = new System.Drawing.Point(535, 40);
            this.cbxStanowisko.Name = "cbxStanowisko";
            this.cbxStanowisko.Size = new System.Drawing.Size(121, 24);
            this.cbxStanowisko.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Wybierz dział";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Wybierz stanowisko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pracownik";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Przepracowane godziny";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Wynagrodzenie ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::NarzedzieHR.Properties.Resources._6883538;
            this.pictureBox4.Location = new System.Drawing.Point(725, 29);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(126, 134);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // RaportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 527);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxStanowisko);
            this.Controls.Add(this.dataGridViewRaporty);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtWynagrodzenie);
            this.Controls.Add(this.nudPrzepracowaneGodziny);
            this.Controls.Add(this.cbxPracownik);
            this.Controls.Add(this.cbxDzial);
            this.Name = "RaportForm";
            this.Text = "RaportForm";
            this.Load += new System.EventHandler(this.RaportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrzepracowaneGodziny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaporty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxDzial;
        private System.Windows.Forms.ComboBox cbxPracownik;
        private System.Windows.Forms.NumericUpDown nudPrzepracowaneGodziny;
        private System.Windows.Forms.TextBox txtWynagrodzenie;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridViewRaporty;
        private System.Windows.Forms.ComboBox cbxStanowisko;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}