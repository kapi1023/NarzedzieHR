using NarzedzieHR.Models;
using NarzedzieHR.Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace NarzedzieHR.Forms.Dzial
{
    public partial class DzialForm : Form
    {
        private readonly DzialService _dzialService;

        public DzialForm()
        {
            InitializeComponent();
            _dzialService = new DzialService();
            LoadDepartments();
            ConfigureBindingNavigator();
            dataGridViewDepartments.AllowUserToAddRows = false; // Ukrycie pustego wiersza
        }

        private void LoadDepartments()
        {
            DataSet dataSet = _dzialService.GetAllDzialy();
            bindingSourceDzialy.DataSource = dataSet.Tables["Dzial"];
            dataGridViewDepartments.DataSource = bindingSourceDzialy;
        }

        private void ConfigureBindingNavigator()
        {
            bindingNavigatorDzialy.BindingSource = bindingSourceDzialy;
        }

        private void dataGridViewDepartments_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDepartments.Rows[e.RowIndex];
                txtNazwa.Text = row.Cells["Nazwa"].Value.ToString();
                txtOpis.Text = row.Cells["Opis"].Value.ToString();
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz dział do usunięcia.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewDepartments.SelectedRows[0];
            int departmentId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            bool success = _dzialService.DeleteDzial(departmentId);

            if (success)
            {
                MessageBox.Show("Dział został pomyślnie usunięty.");
                LoadDepartments(); // Ponowne załadowanie danych po usunięciu
            }
            else
            {
                MessageBox.Show("Błąd podczas usuwania działu. Dział może mieć powiązanych pracowników.");
            }
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.CurrentRow == null)
            {
                MessageBox.Show("Wybierz dział do edycji.");
                return;
            }

            int rowIndex = dataGridViewDepartments.CurrentRow.Index;
            int departmentId = Convert.ToInt32(dataGridViewDepartments.Rows[rowIndex].Cells["Id"].Value);
            string nazwa = txtNazwa.Text;
            string opis = txtOpis.Text;

            if (string.IsNullOrEmpty(nazwa) || string.IsNullOrEmpty(opis))
            {
                MessageBox.Show("Nazwa i opis działu są wymagane.");
                return;
            }

            DzialModel dzial = new DzialModel
            {
                Id = departmentId,
                Nazwa = nazwa,
                Opis = opis
            };

            bool success = _dzialService.UpdateDzial(dzial);

            if (success)
            {
                MessageBox.Show("Dział został pomyślnie zaktualizowany.");
                LoadDepartments(); // Ponowne załadowanie danych po aktualizacji
            }
            else
            {
                MessageBox.Show("Błąd podczas aktualizacji działu.");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazwa.Text) || string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                MessageBox.Show("Nazwa i opis działu są wymagane.");
                return;
            }

            // Sprawdź, czy istnieje już dział o takiej samej nazwie
            foreach (DataGridViewRow row in dataGridViewDepartments.Rows)
            {
                if (row.Cells["Nazwa"].Value != null && row.Cells["Nazwa"].Value.ToString().Equals(txtNazwa.Text, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Dział o takiej nazwie już istnieje.");
                    return;
                }
            }

            DzialModel dzial = new DzialModel
            {
                Nazwa = txtNazwa.Text,
                Opis = txtOpis.Text
            };

            bool success = _dzialService.AddDzial(dzial);

            if (success)
            {
                MessageBox.Show("Dział został pomyślnie dodany.");
                LoadDepartments(); // Ponowne załadowanie danych po dodaniu
            }
            else
            {
                MessageBox.Show("Błąd podczas dodawania działu.");
            }
        }

        private void dataGridViewDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void bindingNavigatorDzialy_RefreshItems(object sender, EventArgs e)
        {
        }

        private void Dzial2Form_Load(object sender, EventArgs e)
        {
        }

        private void dataGridViewDepartments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Usunięto logikę dodawania działu z tej metody
        }
    }
}
