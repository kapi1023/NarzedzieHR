namespace NarzedzieHR.Forms.Pracownik
{
    partial class CredentialsForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHaslo = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.btnUsun = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Haslo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Login";
            // 
            // txtHaslo
            // 
            this.txtHaslo.Location = new System.Drawing.Point(12, 72);
            this.txtHaslo.Name = "txtHaslo";
            this.txtHaslo.Size = new System.Drawing.Size(237, 20);
            this.txtHaslo.TabIndex = 13;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(12, 30);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(237, 20);
            this.txtLogin.TabIndex = 12;
            // 
            // btnUsun
            // 
            this.btnUsun.Location = new System.Drawing.Point(124, 113);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(75, 23);
            this.btnUsun.TabIndex = 16;
            this.btnUsun.Text = "Usun";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(43, 113);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 18;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click_1);
            // 
            // CredentialsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 148);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHaslo);
            this.Controls.Add(this.txtLogin);
            this.Name = "CredentialsForm";
            this.Text = "ZalozKontoForm";
            this.Load += new System.EventHandler(this.CredentialsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHaslo;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.Button btnDodaj;
    }
}