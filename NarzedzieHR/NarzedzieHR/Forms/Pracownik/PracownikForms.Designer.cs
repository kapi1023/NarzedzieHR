﻿namespace NarzedzieHR.Forms.Pracownik
{
    partial class PracownikForms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PracownikForms));
            this.bindingNavigatorPracownicy = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.pomocToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNazwisko = new System.Windows.Forms.TextBox();
            this.txtImie = new System.Windows.Forms.TextBox();
            this.cbxPosition = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dtpDataZatrudnienia = new System.Windows.Forms.DateTimePicker();
            this.bindingSourcePracownicy = new System.Windows.Forms.BindingSource(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorPracownicy)).BeginInit();
            this.bindingNavigatorPracownicy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePracownicy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigatorPracownicy
            // 
            this.bindingNavigatorPracownicy.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigatorPracownicy.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorPracownicy.DeleteItem = null;
            this.bindingNavigatorPracownicy.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigatorPracownicy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorSaveItem,
            this.deleteButton,
            this.pomocToolStripButton});
            this.bindingNavigatorPracownicy.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorPracownicy.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorPracownicy.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorPracownicy.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorPracownicy.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorPracownicy.Name = "bindingNavigatorPracownicy";
            this.bindingNavigatorPracownicy.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorPracownicy.Size = new System.Drawing.Size(1067, 27);
            this.bindingNavigatorPracownicy.TabIndex = 0;
            this.bindingNavigatorPracownicy.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Dodaj nowy";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 24);
            this.bindingNavigatorCountItem.Text = "z {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Suma elementów";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Przenieś pierwszy";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Przenieś poprzedni";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Pozycja";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(65, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Bieżąca pozycja";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Przenieś następny";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Przenieś ostatni";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorSaveItem
            // 
            this.bindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorSaveItem.Image")));
            this.bindingNavigatorSaveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bindingNavigatorSaveItem.Name = "bindingNavigatorSaveItem";
            this.bindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorSaveItem.Text = "&Zapisz";
            this.bindingNavigatorSaveItem.Click += new System.EventHandler(this.bindingNavigatorSaveItem_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.RightToLeftAutoMirrorImage = true;
            this.deleteButton.Size = new System.Drawing.Size(29, 24);
            this.deleteButton.Text = "Usuń";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // pomocToolStripButton
            // 
            this.pomocToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pomocToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pomocToolStripButton.Image")));
            this.pomocToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pomocToolStripButton.Name = "pomocToolStripButton";
            this.pomocToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.pomocToolStripButton.Text = "&Pomoc";
            this.pomocToolStripButton.Click += new System.EventHandler(this.pomocToolStripButton_Click);
            // 
            // dataGridViewEmployees
            // 
            this.dataGridViewEmployees.AllowUserToAddRows = false;
            this.dataGridViewEmployees.AllowUserToDeleteRows = false;
            this.dataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployees.Location = new System.Drawing.Point(13, 27);
            this.dataGridViewEmployees.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewEmployees.MultiSelect = false;
            this.dataGridViewEmployees.Name = "dataGridViewEmployees";
            this.dataGridViewEmployees.ReadOnly = true;
            this.dataGridViewEmployees.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridViewEmployees.RowHeadersVisible = false;
            this.dataGridViewEmployees.RowHeadersWidth = 51;
            this.dataGridViewEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployees.Size = new System.Drawing.Size(663, 512);
            this.dataGridViewEmployees.TabIndex = 13;
            this.dataGridViewEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployees_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(688, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nazwisko";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(688, 173);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Imie";
            // 
            // txtNazwisko
            // 
            this.txtNazwisko.Location = new System.Drawing.Point(770, 206);
            this.txtNazwisko.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNazwisko.Name = "txtNazwisko";
            this.txtNazwisko.Size = new System.Drawing.Size(268, 22);
            this.txtNazwisko.TabIndex = 16;
            // 
            // txtImie
            // 
            this.txtImie.Location = new System.Drawing.Point(770, 170);
            this.txtImie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtImie.Name = "txtImie";
            this.txtImie.Size = new System.Drawing.Size(268, 22);
            this.txtImie.TabIndex = 15;
            // 
            // cbxPosition
            // 
            this.cbxPosition.FormattingEnabled = true;
            this.cbxPosition.Location = new System.Drawing.Point(800, 332);
            this.cbxPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxPosition.Name = "cbxPosition";
            this.cbxPosition.Size = new System.Drawing.Size(235, 106);
            this.cbxPosition.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(684, 297);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Data zatrudnienia";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(688, 254);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Email";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(770, 251);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(268, 22);
            this.txtEmail.TabIndex = 19;
            this.txtEmail.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // dtpDataZatrudnienia
            // 
            this.dtpDataZatrudnienia.Location = new System.Drawing.Point(800, 292);
            this.dtpDataZatrudnienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDataZatrudnienia.Name = "dtpDataZatrudnienia";
            this.dtpDataZatrudnienia.Size = new System.Drawing.Size(235, 22);
            this.dtpDataZatrudnienia.TabIndex = 23;
            this.dtpDataZatrudnienia.Value = new System.DateTime(2024, 5, 19, 0, 0, 0, 0);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::NarzedzieHR.Properties.Resources._5818407;
            this.pictureBox3.Location = new System.Drawing.Point(827, 30);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(124, 121);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(684, 332);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "Stanowisko";
            // 
            // PracownikForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.dtpDataZatrudnienia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNazwisko);
            this.Controls.Add(this.txtImie);
            this.Controls.Add(this.cbxPosition);
            this.Controls.Add(this.dataGridViewEmployees);
            this.Controls.Add(this.bindingNavigatorPracownicy);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PracownikForms";
            this.Text = "PracownikForms";
            this.Load += new System.EventHandler(this.PracownikForms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorPracownicy)).EndInit();
            this.bindingNavigatorPracownicy.ResumeLayout(false);
            this.bindingNavigatorPracownicy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePracownicy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigatorPracownicy;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView dataGridViewEmployees;
        private System.Windows.Forms.ToolStripButton bindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.BindingSource bindingSourcePracownicy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNazwisko;
        private System.Windows.Forms.TextBox txtImie;
        private System.Windows.Forms.CheckedListBox cbxPosition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dtpDataZatrudnienia;
        private System.Windows.Forms.ToolStripButton pomocToolStripButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
    }
}