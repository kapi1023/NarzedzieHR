namespace NarzedzieHR.Forms.Stanowisko
{
    partial class StanowiskoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StanowiskoForm));
            this.dataGridViewStanowiska = new System.Windows.Forms.DataGridView();
            this.cbxDepartments = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.txtNazwa = new System.Windows.Forms.TextBox();
            this.bindingNavigatorStanowisko = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSourceStanowisko = new System.Windows.Forms.BindingSource(this.components);
            this.cbxBenefits = new System.Windows.Forms.CheckedListBox();
            this.nupStawka = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanowiska)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorStanowisko)).BeginInit();
            this.bindingNavigatorStanowisko.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStanowisko)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStawka)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStanowiska
            // 
            this.dataGridViewStanowiska.AllowUserToAddRows = false;
            this.dataGridViewStanowiska.AllowUserToDeleteRows = false;
            this.dataGridViewStanowiska.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStanowiska.Location = new System.Drawing.Point(35, 27);
            this.dataGridViewStanowiska.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewStanowiska.Name = "dataGridViewStanowiska";
            this.dataGridViewStanowiska.ReadOnly = true;
            this.dataGridViewStanowiska.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridViewStanowiska.RowHeadersWidth = 51;
            this.dataGridViewStanowiska.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStanowiska.Size = new System.Drawing.Size(741, 512);
            this.dataGridViewStanowiska.TabIndex = 0;
            this.dataGridViewStanowiska.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDepartments_CellClick);
            this.dataGridViewStanowiska.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStanowiska_CellContentClick);
            // 
            // cbxDepartments
            // 
            this.cbxDepartments.FormattingEnabled = true;
            this.cbxDepartments.Location = new System.Drawing.Point(873, 288);
            this.cbxDepartments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxDepartments.Name = "cbxDepartments";
            this.cbxDepartments.Size = new System.Drawing.Size(254, 72);
            this.cbxDepartments.TabIndex = 1;
            this.cbxDepartments.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxDepartments_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(808, 200);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Opis";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(808, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nazwa";
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(873, 197);
            this.txtOpis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(256, 22);
            this.txtOpis.TabIndex = 9;
            // 
            // txtNazwa
            // 
            this.txtNazwa.Location = new System.Drawing.Point(873, 162);
            this.txtNazwa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNazwa.Name = "txtNazwa";
            this.txtNazwa.Size = new System.Drawing.Size(254, 22);
            this.txtNazwa.TabIndex = 8;
           // this.txtNazwa.TextChanged += new System.EventHandler(this.txtNazwa_TextChanged);
            // 
            // bindingNavigatorStanowisko
            // 
            this.bindingNavigatorStanowisko.AddNewItem = null;
            this.bindingNavigatorStanowisko.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorStanowisko.DeleteItem = null;
            this.bindingNavigatorStanowisko.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigatorStanowisko.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.deleteButton,
            this.bindingNavigatorSaveItem,
            this.bindingNavigatorAddNewItem});
            this.bindingNavigatorStanowisko.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorStanowisko.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorStanowisko.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorStanowisko.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorStanowisko.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorStanowisko.Name = "bindingNavigatorStanowisko";
            this.bindingNavigatorStanowisko.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorStanowisko.Size = new System.Drawing.Size(1176, 27);
            this.bindingNavigatorStanowisko.TabIndex = 14;
            this.bindingNavigatorStanowisko.Text = "bindingNavigator1";
            this.bindingNavigatorStanowisko.RefreshItems += new System.EventHandler(this.bindingNavigatorStanowisko_RefreshItems);
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
            // cbxBenefits
            // 
            this.cbxBenefits.FormattingEnabled = true;
            this.cbxBenefits.Location = new System.Drawing.Point(873, 383);
            this.cbxBenefits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxBenefits.Name = "cbxBenefits";
            this.cbxBenefits.Size = new System.Drawing.Size(254, 72);
            this.cbxBenefits.TabIndex = 17;
            // 
            // nupStawka
            // 
            this.nupStawka.DecimalPlaces = 2;
            this.nupStawka.Location = new System.Drawing.Point(873, 239);
            this.nupStawka.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nupStawka.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nupStawka.Name = "nupStawka";
            this.nupStawka.Size = new System.Drawing.Size(254, 22);
            this.nupStawka.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(809, 245);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Stawka";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::NarzedzieHR.Properties.Resources._4185473;
            this.pictureBox2.Location = new System.Drawing.Point(930, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 115);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(810, 288);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Dział";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(810, 383);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Dodatek";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(810, 399);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "płacowy";
            // 
            // StanowiskoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 554);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbxBenefits);
            this.Controls.Add(this.bindingNavigatorStanowisko);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nupStawka);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.txtNazwa);
            this.Controls.Add(this.cbxDepartments);
            this.Controls.Add(this.dataGridViewStanowiska);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StanowiskoForm";
            this.Text = "Stanowisko";
            this.Load += new System.EventHandler(this.Stanowisko_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStanowiska)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorStanowisko)).EndInit();
            this.bindingNavigatorStanowisko.ResumeLayout(false);
            this.bindingNavigatorStanowisko.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStanowisko)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupStawka)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStanowiska;
        private System.Windows.Forms.CheckedListBox cbxDepartments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.TextBox txtNazwa;
        private System.Windows.Forms.BindingNavigator bindingNavigatorStanowisko;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource bindingSourceStanowisko;
        private System.Windows.Forms.ToolStripButton bindingNavigatorSaveItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.CheckedListBox cbxBenefits;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.NumericUpDown nupStawka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}