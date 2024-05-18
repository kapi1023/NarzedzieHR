using NarzedzieHR.Forms.Dzial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NarzedzieHR.Forms.Main
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void btnDzial_Click(object sender, EventArgs e)
        {
            DzialForm dzialForm = new DzialForm();
            dzialForm.Show();
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {

        }
    }
}
