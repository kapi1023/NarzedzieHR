using System;
using System.Data;
using System.Windows.Forms;
using NarzedzieHR.Service;

namespace NarzedzieHR.Forms.Raport
{
    public partial class RaportForm : Form
    {
        private readonly PracownikService _pracownikService;
        private readonly DzialService _dzialService;
        private readonly StanowiskoService _stanowiskoService;
        private readonly ReportService _reportService;

        public RaportForm()
        {
            InitializeComponent();
            _pracownikService = new PracownikService();
            _dzialService = new DzialService();
            _stanowiskoService = new StanowiskoService();
            _reportService = new ReportService();
        }

        private void RaportForm_Load(object sender, EventArgs e)
        {
            LoadDzialy();
        }

        private void LoadDzialy()
        {
            DataSet dataSet = _dzialService.GetAllDzialy();
            cbxDzial.DataSource = dataSet.Tables["Dzial"];
            cbxDzial.DisplayMember = "Nazwa";
            cbxDzial.ValueMember = "Id";
            cbxDzial.SelectedIndex = -1;
        }

        private void cbxDzial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDzial.SelectedValue != null)
            {
                int dzialId = (int)cbxDzial.SelectedValue;
                LoadStanowiska(dzialId);
            }
        }

        private void LoadStanowiska(int dzialId)
        {
            DataSet dataSet = _stanowiskoService.GetStanowiskaByDzial(dzialId);
            cbxStanowisko.DataSource = dataSet.Tables["Stanowisko"];
            cbxStanowisko.DisplayMember = "Nazwa";
            cbxStanowisko.ValueMember = "Id";
            cbxStanowisko.SelectedIndex = -1;
        }

        private void cbxStanowisko_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStanowisko.SelectedValue != null)
            {
                int stanowiskoId = (int)cbxStanowisko.SelectedValue;
                LoadPracownicy(stanowiskoId);
            }
        }

        private void LoadPracownicy(int stanowiskoId)
        {
            DataSet dataSet = _pracownikService.GetPracownicyByStanowisko(stanowiskoId);
            cbxPracownik.DataSource = dataSet.Tables["Pracownik"];
            cbxPracownik.DisplayMember = "Nazwisko";
            cbxPracownik.ValueMember = "Id";
            cbxPracownik.SelectedIndex = -1;
        }

        private void nudPrzepracowaneGodziny_ValueChanged(object sender, EventArgs e)
        {
            CalculateWynagrodzenie();
        }

        private void CalculateWynagrodzenie()
        {
            if (cbxPracownik.SelectedValue == null) return;

            int pracownikId = (int)cbxPracownik.SelectedValue;
            int przepracowaneGodziny = (int)nudPrzepracowaneGodziny.Value;

            decimal stawka = _pracownikService.GetStawkaByPracownikId(pracownikId);
            decimal wynagrodzenie = przepracowaneGodziny * stawka;

            txtWynagrodzenie.Text = wynagrodzenie.ToString("C2");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxPracownik.SelectedValue == null || nudPrzepracowaneGodziny.Value <= 0)
            {
                MessageBox.Show("Proszę wybrać pracownika i wprowadzić liczbę przepracowanych godzin.");
                return;
            }

            int pracownikId = (int)cbxPracownik.SelectedValue;
            int przepracowaneGodziny = (int)nudPrzepracowaneGodziny.Value;
            decimal stawkaWynagrodzenia = decimal.Parse(txtWynagrodzenie.Text, System.Globalization.NumberStyles.Currency);

            bool success = _reportService.AddReport(pracownikId, DateTime.Now, przepracowaneGodziny, stawkaWynagrodzenia);

            if (success)
            {
                MessageBox.Show("Raport zapisany pomyślnie.");
                LoadRaporty();
            }
            else
            {
                MessageBox.Show("Błąd podczas zapisywania raportu.");
            }
        }

        private void LoadRaporty()
        {
            DataTable dataTable = _reportService.GetAllRaporty();
            dataGridViewRaporty.DataSource = dataTable;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
