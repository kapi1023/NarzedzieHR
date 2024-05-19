using NarzedzieHR.Forms.Dzial;
using NarzedzieHR.Forms.Pracownik;
using NarzedzieHR.Forms.Stanowisko;
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

        private void btnStanowisko_Click(object sender, EventArgs e)
        {
            StanowiskoForm stanowisko = new StanowiskoForm();
            stanowisko.Show();
        }

        private void btnPracownicy_Click(object sender, EventArgs e)
        {
            PracownikForms pracownik = new PracownikForms();
            pracownik.Show();
        }
    }
}
