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
        private readonly RaportService _reportService;

        public RaportForm()
        {
            InitializeComponent();
            _pracownikService = new PracownikService();
            _dzialService = new DzialService();
            _stanowiskoService = new StanowiskoService();
            _reportService = new RaportService();
        }

        private void RaportForm_Load(object sender, EventArgs e)
        {
            LoadDzialy();
            DisableFields();
        }

        private void LoadDzialy()
        {
            DataSet dataSet = _dzialService.GetAllDzialy();
            cbxDzial.DataSource = dataSet.Tables["Dzial"];
            cbxDzial.DisplayMember = "Nazwa";
            cbxDzial.ValueMember = "Id";
            cbxDzial.SelectedIndex = -1;
        }

        private void LoadPracownicy(int stanowiskoId)
        {
            DataSet dataSet = _pracownikService.GetPracownicyByStanowisko(stanowiskoId);
            cbxPracownik.DataSource = dataSet.Tables["Pracownicy"];
            cbxPracownik.DisplayMember = "ImieNazwisko";
            cbxPracownik.ValueMember = "Id";
            cbxPracownik.SelectedIndex = -1;
        }

        private void DisableFields()
        {
            cbxStanowisko.Enabled = false;
            cbxPracownik.Enabled = false;
            nudPrzepracowaneGodziny.Enabled = false;
            btnSave.Enabled = false;
        }

        private void EnableFields()
        {
            cbxStanowisko.Enabled = true;
            cbxPracownik.Enabled = true;
            nudPrzepracowaneGodziny.Enabled = true;
            btnSave.Enabled = true;
        }

        private void LoadStanowiska(int dzialId)
        {
            DataSet dataSet = _stanowiskoService.GetStanowiskaByDzial(dzialId);
            cbxStanowisko.DataSource = dataSet.Tables["Stanowisko"];
            cbxStanowisko.DisplayMember = "Nazwa";
            cbxStanowisko.ValueMember = "Id";
            cbxStanowisko.SelectedIndex = -1;
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

            //txtWynagrodzenie.Text = wynagrodzenie.ToString("C2");
        }

        private void LoadRaporty()
        {
            DataTable dataTable = _reportService.GetAllRaporty();
            dataGridViewRaporty.DataSource = dataTable;
            CustomizeDataGridView();
        }

        private void LoadRaportyByDzial(int dzialId)
        {
            dataGridViewRaporty.DataSource = null;
            DataTable dataTable = _reportService.GetRaportyByDzial(dzialId);
            dataGridViewRaporty.DataSource = dataTable;
            CustomizeDataGridView();
        }

        private void LoadRaportyByStanowisko(int stanowiskoId)
        {
            dataGridViewRaporty.DataSource = null;
            DataTable dataTable = _reportService.GetRaportyByStanowisko(stanowiskoId);
            dataGridViewRaporty.DataSource = dataTable;
            CustomizeDataGridView();
        }

        private void LoadRaportyByPracownik(int pracownikId)
        {
            dataGridViewRaporty.DataSource = null;
            DataTable dataTable = _reportService.GetRaportyByPracownik(pracownikId);
            dataGridViewRaporty.DataSource = dataTable;
            CustomizeDataGridView();
        }

        private void CustomizeDataGridView()
        {
            // Ukrywanie kolumn ID
            if (dataGridViewRaporty.Columns.Contains("Id"))
            {
                dataGridViewRaporty.Columns["Id"].Visible = false;
            }
            if (dataGridViewRaporty.Columns.Contains("Id1"))
            {
                dataGridViewRaporty.Columns["Id1"].Visible = false;
            }

            if (dataGridViewRaporty.Columns.Contains("StanowiskoId"))
            {
                dataGridViewRaporty.Columns["StanowiskoId"].Visible = false;
            }

            if (dataGridViewRaporty.Columns.Contains("PracownikId"))
            {
                dataGridViewRaporty.Columns["PracownikId"].Visible = false;
            }

            // Zmiana nagłówków kolumn
            if (dataGridViewRaporty.Columns.Contains("DateTime"))
            {
                dataGridViewRaporty.Columns["DateTime"].HeaderText = "Data zaksięgowania";
            }

            if (dataGridViewRaporty.Columns.Contains("PrzepracowaneGodziny"))
            {
                dataGridViewRaporty.Columns["PrzepracowaneGodziny"].HeaderText = "Przepracowane Godziny";
            }

            if (dataGridViewRaporty.Columns.Contains("StawkaWynagrodzenia"))
            {
                dataGridViewRaporty.Columns["StawkaWynagrodzenia"].HeaderText = "Wynagrodzenie";
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (cbxPracownik.SelectedValue == null || nudPrzepracowaneGodziny.Value <= 0)
            {
                MessageBox.Show("Proszę wybrać pracownika i wprowadzić liczbę przepracowanych godzin.");
                return;
            }

            int pracownikId = (int)cbxPracownik.SelectedValue;
            int przepracowaneGodziny = (int)nudPrzepracowaneGodziny.Value;

            bool success = _pracownikService.AddReport(pracownikId, DateTime.Now, przepracowaneGodziny);

            if (success)
            {
                MessageBox.Show("Raport zapisany pomyślnie.");
                LoadRaportyByPracownik(pracownikId);
            }
            else
            {
                MessageBox.Show("Błąd podczas zapisywania raportu. Raport wynagrodzenia na dany miesiąc już istnieje dla tego pracownika.");
            }
        }

        private void cbxStanowisko_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int stanowiskoId;

            if (cbxStanowisko.SelectedValue != null && int.TryParse(cbxStanowisko.SelectedValue.ToString(), out stanowiskoId))
            {
                LoadPracownicy(stanowiskoId);
                LoadRaportyByStanowisko(stanowiskoId);
            }
        }

        private void cbxDzial_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int dzialId;
            if (cbxDzial.SelectedValue != null && int.TryParse(cbxDzial.SelectedValue.ToString(), out dzialId))
            {
                LoadStanowiska(dzialId);
                LoadRaportyByDzial(dzialId);
                EnableFields();
            }
        }

        private void cbxPracownik_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pracownikId;
            if (cbxPracownik.SelectedValue != null && int.TryParse(cbxPracownik.SelectedValue.ToString(), out pracownikId))
            {
                LoadRaportyByPracownik(pracownikId);
            }
        }

        private void dataGridViewRaporty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
