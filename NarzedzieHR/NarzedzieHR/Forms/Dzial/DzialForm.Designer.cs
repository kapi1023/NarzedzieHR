namespace NarzedzieHR.Forms.Dzial
{
    partial class DzialForm
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
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.txtNazwa = new System.Windows.Forms.TextBox();
            this.btnUsun = new System.Windows.Forms.Button();
            this.btnEdytuj = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.dataGridViewDepartments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Opis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nazwa";
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(539, 127);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(237, 20);
            this.txtOpis.TabIndex = 17;
            // 
            // txtNazwa
            // 
            this.txtNazwa.Location = new System.Drawing.Point(539, 85);
            this.txtNazwa.Name = "txtNazwa";
            this.txtNazwa.Size = new System.Drawing.Size(237, 20);
            this.txtNazwa.TabIndex = 16;
            // 
            // btnUsun
            // 
            this.btnUsun.Location = new System.Drawing.Point(701, 26);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(75, 23);
            this.btnUsun.TabIndex = 15;
            this.btnUsun.Text = "Usun";
            this.btnUsun.UseVisualStyleBackColor = true;
            // 
            // btnEdytuj
            // 
            this.btnEdytuj.Location = new System.Drawing.Point(620, 26);
            this.btnEdytuj.Name = "btnEdytuj";
            this.btnEdytuj.Size = new System.Drawing.Size(75, 23);
            this.btnEdytuj.TabIndex = 14;
            this.btnEdytuj.Text = "Edytuj";
            this.btnEdytuj.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(539, 26);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 13;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDepartments
            // 
            this.dataGridViewDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartments.Location = new System.Drawing.Point(24, 17);
            this.dataGridViewDepartments.Name = "dataGridViewDepartments";
            this.dataGridViewDepartments.ReadOnly = true;
            this.dataGridViewDepartments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridViewDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDepartments.Size = new System.Drawing.Size(507, 416);
            this.dataGridViewDepartments.TabIndex = 12;
            this.dataGridViewDepartments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDepartments_CellClick_1);
            // 
            // DzialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.txtNazwa);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.btnEdytuj);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dataGridViewDepartments);
            this.Name = "DzialForm";
            this.Text = "Dzial2Form";
            this.Load += new System.EventHandler(this.Dzial2Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.TextBox txtNazwa;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.Button btnEdytuj;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dataGridViewDepartments;
    }
}