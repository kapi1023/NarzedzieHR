using NarzedzieHR.Models;
using NarzedzieHR.Service;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NarzedzieHR.Forms.Pracownik
{
    public partial class PracownikForms : Form
    {
        private readonly PracownikService _pracownikService;
        private readonly StanowiskoService _stanowiskoService;
        private readonly BindingSource _bindingSourcePracownicy;
        public PracownikForms()
        {
            InitializeComponent();
            _pracownikService = new PracownikService();
            _stanowiskoService = new StanowiskoService();
            _bindingSourcePracownicy = new BindingSource();

            LoadStanowiska();
            ConfigureBindingNavigator();
            LoadPracownicy();
        }

        private void LoadStanowiska()
        {
            DataSet dataSet = _stanowiskoService.GetAllStanowiska();
            cbxPosition.DataSource = dataSet.Tables["Table"];
            cbxPosition.DisplayMember = "Nazwa";
            cbxPosition.ValueMember = "Id";
        }

        private void ConfigureBindingNavigator()
        {
            bindingNavigatorPracownicy.BindingSource = _bindingSourcePracownicy;
        }

        private void LoadPracownicy()
        {
            DataSet dataSet = _pracownikService.GetAllPracownicy();
            _bindingSourcePracownicy.DataSource = dataSet.Tables["Table"];
            dataGridViewEmployees.DataSource = _bindingSourcePracownicy;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridViewEmployees.SelectedRows[0].Index;
                int pracownikId = Convert.ToInt32(dataGridViewEmployees.Rows[selectedRowIndex].Cells["Id"].Value);

                DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć tego pracownika?", "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (_pracownikService.DeletePracownik(pracownikId))
                    {
                        MessageBox.Show("Pracownik został pomyślnie usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPracownicy();
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas usuwania pracownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz pracownika do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImie.Text) || string.IsNullOrWhiteSpace(txtNazwisko.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Imię, nazwisko i email są wymagane.");
                return;
            }

            if (cbxPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz stanowisko pracownika.");
                return;
            }

            DateTime dataZatrudnienia = dtpDataZatrudnienia.Value;
            if (dataZatrudnienia > DateTime.Now)
            {
                MessageBox.Show("Data zatrudnienia nie może być późniejsza niż dzisiaj.");
                return;
            }

            // Sprawdź, czy istnieje już pracownik o takim samym imieniu i nazwisku
            foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
            {
                if (row.Cells["Imie"].Value != null && row.Cells["Nazwisko"].Value != null &&
                    row.Cells["Imie"].Value.ToString().Equals(txtImie.Text, StringComparison.OrdinalIgnoreCase) &&
                    row.Cells["Nazwisko"].Value.ToString().Equals(txtNazwisko.Text, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Pracownik o takim imieniu i nazwisku już istnieje.");
                    return;
                }
            }

            PracownikModel pracownik = new PracownikModel
            {
                Imie = txtImie.Text,
                Nazwisko = txtNazwisko.Text,
                Email = txtEmail.Text,
                DataZatrudnienia = dataZatrudnienia,
                StanowiskoId = (int)cbxPosition.SelectedValue
            };

            bool success = _pracownikService.AddPracownik(pracownik);

            if (success)
            {
                MessageBox.Show("Pracownik dodany pomyślnie.");
                LoadPracownicy();
            }
            else
            {
                MessageBox.Show("Błąd dodawania pracownika.");
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow == null)
            {
                MessageBox.Show("Wybierz pracownika do edycji.");
                return;
            }

            int rowIndex = dataGridViewEmployees.CurrentRow.Index;
            int pracownikId = Convert.ToInt32(dataGridViewEmployees.Rows[rowIndex].Cells["Id"].Value);

            if (string.IsNullOrWhiteSpace(txtImie.Text) || string.IsNullOrWhiteSpace(txtNazwisko.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Imię, nazwisko i email są wymagane.");
                return;
            }

            if (cbxPosition.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz stanowisko pracownika.");
                return;
            }

            DateTime dataZatrudnienia = dtpDataZatrudnienia.Value;
            if (dataZatrudnienia > DateTime.Now)
            {
                MessageBox.Show("Data zatrudnienia nie może być późniejsza niż dzisiaj.");
                return;
            }

            // Sprawdź, czy istnieje już pracownik o takim samym imieniu i nazwisku
            foreach (DataGridViewRow row in dataGridViewEmployees.Rows)
            {
                if (row.Index != rowIndex && row.Cells["Imie"].Value != null && row.Cells["Nazwisko"].Value != null &&
                    row.Cells["Imie"].Value.ToString().Equals(txtImie.Text, StringComparison.OrdinalIgnoreCase) &&
                    row.Cells["Nazwisko"].Value.ToString().Equals(txtNazwisko.Text, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Pracownik o takim imieniu i nazwisku już istnieje.");
                    return;
                }
            }

            PracownikModel pracownik = new PracownikModel
            {
                Id = pracownikId,
                Imie = txtImie.Text,
                Nazwisko = txtNazwisko.Text,
                Email = txtEmail.Text,
                DataZatrudnienia = dataZatrudnienia,
                StanowiskoId = (int)cbxPosition.SelectedValue
            };

            bool success = _pracownikService.UpdatePracownik(pracownik);

            if (success)
            {
                MessageBox.Show("Pracownik zaktualizowany pomyślnie.");
                LoadPracownicy();
            }
            else
            {
                MessageBox.Show("Błąd aktualizacji pracownika.");
            }
        }

        private void dataGridViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridViewEmployees.Rows[e.RowIndex];

                txtImie.Text = row.Cells["Imie"].Value.ToString();
                txtNazwisko.Text = row.Cells["Nazwisko"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                dtpDataZatrudnienia.Value = Convert.ToDateTime(row.Cells["DataZatrudnienia"].Value);

                int stanowiskoId = Convert.ToInt32(row.Cells["StanowiskoId"].Value);
                for (int i = 0; i < cbxPosition.Items.Count; i++)
                {
                    DataRowView item = (DataRowView)cbxPosition.Items[i];
                    if (Convert.ToInt32(item["Id"]) == stanowiskoId)
                    {
                        cbxPosition.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void PracownikForms_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pomocToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmployees.CurrentRow != null)
            {
                CredentialsForm pracownik = new CredentialsForm(Convert.ToInt32(dataGridViewEmployees.CurrentRow.Cells["Id"].Value));
                pracownik.Show();
            }
            else
            {
                MessageBox.Show("Wybierz pracownika, któremu chcesz dodać dane uwierzytelniające.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
