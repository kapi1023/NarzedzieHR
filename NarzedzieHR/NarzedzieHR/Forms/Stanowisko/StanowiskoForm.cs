using NarzedzieHR.Models;
using NarzedzieHR.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NarzedzieHR.Forms.Stanowisko
{
    public partial class StanowiskoForm : Form
    {
        private readonly StanowiskoService _stanowiskoService;
        private readonly DzialService _dzialService;
        private int selectedPositionId = -1;
        public StanowiskoForm()
        {
            InitializeComponent();
            _stanowiskoService = new StanowiskoService();
            _dzialService = new DzialService();
            LoadDepartments();
            LoadStanowiska();
        }
        private void LoadDepartments()
        {
            IEnumerable<DzialModel> departments = ConvertToDzialModels(_dzialService.GetAllDzialy());
            cbxDepartments.DataSource = departments;
            cbxDepartments.DisplayMember = "Nazwa";
            cbxDepartments.ValueMember = "Id";
        }

        private void LoadStanowiska()
        {
            DataTable stanowiska = _stanowiskoService.GetAllStanowiska();
            dataGridViewDepartments.DataSource = stanowiska;
        }

        private IEnumerable<DzialModel> ConvertToDzialModels(DataTable table)
        {
            List<DzialModel> departments = new List<DzialModel>();

            foreach (DataRow row in table.Rows)
            {
                DzialModel department = new DzialModel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nazwa = Convert.ToString(row["Nazwa"]),
                    Opis = Convert.ToString(row["Opis"])
                };

                departments.Add(department);
            }

            return departments;
        }
        private void dataGridViewPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDepartments.Rows[e.RowIndex];
                selectedPositionId = Convert.ToInt32(row.Cells["Id"].Value);
                txtNazwa.Text = row.Cells["Nazwa"].Value.ToString();
                txtOpis.Text = row.Cells["Opis"].Value.ToString();
            }
        }
        private void Stanowisko_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBoxDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string nazwa = txtNazwa.Text;
            string opis = txtOpis.Text;
            decimal stawkaWynagrodzenia = nupStawka.Value;
            int dzialId = (int)cbxDepartments.SelectedValue; // Pobranie wartości zaznaczonego działu

            // Utworzenie obiektu StanowiskoModel
            StanowiskoModel stanowisko = new StanowiskoModel
            {
                Nazwa = nazwa,
                Opis = opis,
                StawkaWynagrodzenia = stawkaWynagrodzenia,
                DzialId = dzialId
            };

            // Dodanie stanowiska
            bool success = _stanowiskoService.AddStanowisko(stanowisko);

            if (success)
            {
                MessageBox.Show("Stanowisko dodane pomyślnie.");
            }
            else
            {
                MessageBox.Show("Błąd podczas dodawania stanowiska.");
            }
            LoadStanowiska();
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count > 0)
            {
                int stanowiskoId = Convert.ToInt32(dataGridViewDepartments.SelectedRows[0].Cells["Id"].Value);
                string nazwa = txtNazwa.Text;
                string opis = txtOpis.Text;
                decimal stawkaWynagrodzenia = Convert.ToDecimal(nupStawka.Value);
                int selectedDzialId = cbxDepartments.CheckedItems.Cast<Models.DzialModel>().Select(d => d.Id).ToList()[0];

                Models.StanowiskoModel stanowisko = new Models.StanowiskoModel
                {
                    Id = stanowiskoId,
                    Nazwa = nazwa,
                    Opis = opis,
                    StawkaWynagrodzenia = stawkaWynagrodzenia,
                    DzialId = selectedDzialId
                };

                bool success = _stanowiskoService.UpdateStanowisko(stanowisko);

                if (success)
                {
                    MessageBox.Show("Stanowisko zaktualizowane pomyślnie.");
                    LoadDepartments();
                }
                else
                {
                    MessageBox.Show("Błąd aktualizacji stanowiska.");
                }
            }
            else
            {
                MessageBox.Show("Wybierz stanowisko do edycji.");
            }
            LoadStanowiska();
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count > 0)
            {
                int stanowiskoId = Convert.ToInt32(dataGridViewDepartments.SelectedRows[0].Cells["Id"].Value);

                bool success = _stanowiskoService.DeleteStanowisko(stanowiskoId);

                if (success)
                {
                    MessageBox.Show("Stanowisko usunięte pomyślnie.");
                    LoadDepartments();
                }
                else
                {
                    MessageBox.Show("Błąd usuwania stanowiska. Stanowisko może mieć przypisanych pracowników.");
                }
            }
            else
            {
                MessageBox.Show("Wybierz stanowisko do usunięcia.");
            }
            LoadStanowiska();
        }

        private void dataGridViewDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDepartments.Rows[e.RowIndex];
                txtNazwa.Text = row.Cells["Nazwa"].Value.ToString();
                txtOpis.Text = row.Cells["Opis"].Value.ToString();
                nupStawka.Value = Convert.ToDecimal(row.Cells["StawkaWynagrodzenia"].Value);

                for (int i = 0; i < cbxDepartments.Items.Count; i++)
                {
                    cbxDepartments.SetItemChecked(i, false);
                }

                int selectedDepartmentId = Convert.ToInt32(row.Cells["DzialId"].Value);

                foreach (DzialModel item in cbxDepartments.Items)
                {
                    if (item.Id.ToString() == selectedDepartmentId.ToString())
                    {
                        int index = cbxDepartments.Items.IndexOf(item);
                        cbxDepartments.SetItemChecked(index, true);
                        break;
                    }
                }
            }
        }

    }
}
