namespace NarzedzieHR.Forms.Main
{
    partial class LandingPage
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
            this.btnDzial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDzial
            // 
            this.btnDzial.Location = new System.Drawing.Point(12, 12);
            this.btnDzial.Name = "btnDzial";
            this.btnDzial.Size = new System.Drawing.Size(113, 44);
            this.btnDzial.TabIndex = 0;
            this.btnDzial.Text = "Dzial";
            this.btnDzial.UseVisualStyleBackColor = true;
            this.btnDzial.Click += new System.EventHandler(this.btnDzial_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDzial);
            this.Name = "LandingPage";
            this.Text = "LandingPage";
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDzial;
    }
}