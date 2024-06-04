using NarzedzieHR.Models;
using NarzedzieHR.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NarzedzieHR.Forms.Stanowisko
{
    public partial class StanowiskoForm : Form
    {
        private readonly StanowiskoService _stanowiskoService;
        private readonly DzialService _dzialService;
        private readonly BenefitService _benefitService;

        public StanowiskoForm()
        {
            InitializeComponent();
            _stanowiskoService = new StanowiskoService();
            _dzialService = new DzialService();
            _benefitService = new BenefitService();
            LoadDepartments();
            LoadStanowiska();
            LoadBenefits();

            ConfigureBindingNavigator();
        }

        private void LoadDepartments()
        {
            DataSet dataSet = _dzialService.GetAllDzialy();
            DataTable departmentsTable = dataSet.Tables["Dzial"];
            cbxDepartments.DataSource = ConvertToDzialModels(departmentsTable);
            cbxDepartments.DisplayMember = "Nazwa";
            cbxDepartments.ValueMember = "Id";
        }

        private void LoadStanowiska()
        {
            DataSet dataSet = _stanowiskoService.GetAllStanowiska();
            bindingSourceStanowisko.DataSource = dataSet.Tables["Table"];
            dataGridViewStanowiska.DataSource = bindingSourceStanowisko;
        }

        private void LoadBenefits() // Dodane
        {
            DataSet dataSet = _benefitService.GetAllBenefits();
            List<BenefitModel> benefits = ConvertToBenefitModels(dataSet);
            cbxBenefits.DataSource = benefits;
            cbxBenefits.DisplayMember = "Nazwa";
            cbxBenefits.ValueMember = "Id";
        }

        private void ConfigureBindingNavigator()
        {
            bindingNavigatorStanowisko.BindingSource = bindingSourceStanowisko;
        }

        private IEnumerable<DzialModel> ConvertToDzialModels(DataTable table)
        {
            return table.AsEnumerable().Select(row => new DzialModel
            {
                Id = Convert.ToInt32(row["Id"]),
                Nazwa = Convert.ToString(row["Nazwa"]),
                Opis = Convert.ToString(row["Opis"])
            }).ToList();
        }

        private List<BenefitModel> ConvertToBenefitModels(DataSet dataSet)
        {
            DataTable benefitsTable = dataSet.Tables[0];
            List<BenefitModel> benefits = new List<BenefitModel>();

            foreach (DataRow row in benefitsTable.Rows)
            {
                BenefitModel benefit = new BenefitModel
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nazwa = Convert.ToString(row["Nazwa"]),
                    Opis = Convert.ToString(row["Opis"])
                };

                benefits.Add(benefit);
            }

            return benefits;
        }

        private void dataGridViewDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewStanowiska.Rows[e.RowIndex];
                int stanowiskoId = Convert.ToInt32(row.Cells["Id"].Value);

                // Pobierz DataSet z benefity dla danego stanowiska
                DataSet dataSetBenefits = _stanowiskoService.GetBenefitsForStanowisko(stanowiskoId);

                // Konwertuj DataSet na listę BenefitModel
                List<BenefitModel> benefits = ConvertToBenefitModels(dataSetBenefits);
                txtNazwa.Text = row.Cells["Nazwa"].Value.ToString();
                txtOpis.Text = row.Cells["Opis"].Value.ToString();
                nupStawka.Value = Convert.ToDecimal(row.Cells["StawkaWynagrodzenia"].Value);

                // Zaktualizuj źródło danych dla cbxBenefits tylko jeśli lista beneficjentów nie jest pusta
                if (benefits.Any())
                {
                    cbxBenefits.DataSource = benefits;
                    cbxBenefits.DisplayMember = "Nazwa";
                    cbxBenefits.ValueMember = "Id";

                    // Zaznacz odpowiednie benefity w cbxBenefits
                    foreach (DataRow benefitRow in dataSetBenefits.Tables["Table"].Rows)
                    {
                        bool isSelected = Convert.ToBoolean(benefitRow["czyWybrana"]);

                        if (isSelected)
                        {
                            cbxBenefits.SetItemChecked(cbxBenefits.FindStringExact(benefitRow["Nazwa"].ToString()), true);
                            continue;
                        }
                        cbxBenefits.SetItemChecked(cbxBenefits.FindStringExact(benefitRow["Nazwa"].ToString()), false);
                    }
                }
                else
                {
                    cbxBenefits.DataSource = null;
                }

                int selectedDepartmentId = Convert.ToInt32(row.Cells["DzialId"].Value);
                for (int i = 0; i < cbxDepartments.Items.Count; i++)
                {
                    DzialModel item = (DzialModel)cbxDepartments.Items[i];
                    if (item.Id == selectedDepartmentId)
                    {
                        cbxDepartments.SetItemChecked(i, true);
                    }
                    else
                    {
                        cbxDepartments.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewStanowiska.CurrentRow == null)
            {
                MessageBox.Show("Wybierz stanowisko do usunięcia.");
                return;
            }
            int rowIndex = dataGridViewStanowiska.CurrentRow.Index;
            int stanowiskoId = Convert.ToInt32(dataGridViewStanowiska.Rows[rowIndex].Cells["Id"].Value);

            bool success = _stanowiskoService.DeleteStanowisko(stanowiskoId);

            if (success)
            {
                MessageBox.Show("Stanowisko usunięte pomyślnie.");
            }
            else
            {
                MessageBox.Show("Błąd usuwania stanowiska. Stanowisko może mieć przypisanych pracowników.");
            }
            LoadStanowiska();
        }

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewStanowiska.CurrentRow == null)
            {
                MessageBox.Show("Wybierz stanowisko do edycji.");
                return;
            }

            int rowIndex = dataGridViewStanowiska.CurrentRow.Index;
            int stanowiskoId = Convert.ToInt32(dataGridViewStanowiska.Rows[rowIndex].Cells["Id"].Value);
            string nazwa = txtNazwa.Text;
            string opis = txtOpis.Text;
            decimal stawkaWynagrodzenia = Convert.ToDecimal(nupStawka.Value);
            int selectedDzialId = (int)cbxDepartments.SelectedValue;

            // Walidacja wynagrodzenia
            if (stawkaWynagrodzenia <= 0)
            {
                MessageBox.Show("Stawka wynagrodzenia musi być większa od zera.");
                return;
            }

            // Walidacja działu
            if (cbxDepartments.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz dział dla stanowiska.");
                return;
            }

            // Sprawdzenie, czy stanowisko o takiej samej nazwie już istnieje
            foreach (DataGridViewRow row in dataGridViewStanowiska.Rows)
            {
                if (row.Index != rowIndex && row.Cells["Nazwa"].Value != null && row.Cells["Nazwa"].Value.ToString().Equals(nazwa, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Stanowisko o takiej nazwie już istnieje.");
                    return;
                }
            }

            List<BenefitModel> selectedBenefits = new List<BenefitModel>();
            foreach (int index in cbxBenefits.CheckedIndices)
            {
                selectedBenefits.Add((BenefitModel)cbxBenefits.Items[index]);
            }

            StanowiskoModel stanowisko = new StanowiskoModel
            {
                Id = stanowiskoId,
                Nazwa = nazwa,
                Opis = opis,
                StawkaWynagrodzenia = stawkaWynagrodzenia,
                DzialId = selectedDzialId,
                Benefits = selectedBenefits
            };

            bool success = _stanowiskoService.UpdateStanowisko(stanowisko);

            if (success)
            {
                MessageBox.Show("Stanowisko zaktualizowane pomyślnie.");
                LoadStanowiska();
            }
            else
            {
                MessageBox.Show("Błąd aktualizacji stanowiska.");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazwa.Text) || string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                MessageBox.Show("Nazwa i opis stanowiska są wymagane.");
                return;
            }

            decimal stawkaWynagrodzenia = nupStawka.Value;
            if (stawkaWynagrodzenia <= 0)
            {
                MessageBox.Show("Stawka wynagrodzenia musi być większa od zera.");
                return;
            }

            if (cbxDepartments.SelectedIndex == -1)
            {
                MessageBox.Show("Wybierz dział dla stanowiska.");
                return;
            }

            // Sprawdzenie, czy stanowisko o takiej samej nazwie już istnieje
            foreach (DataGridViewRow row in dataGridViewStanowiska.Rows)
            {
                if (row.Cells["Nazwa"].Value != null && row.Cells["Nazwa"].Value.ToString().Equals(txtNazwa.Text, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Stanowisko o takiej nazwie już istnieje.");
                    return;
                }
            }

            int dzialId = (int)cbxDepartments.SelectedValue;

            StanowiskoModel stanowisko = new StanowiskoModel
            {
                Nazwa = txtNazwa.Text,
                Opis = txtOpis.Text,
                StawkaWynagrodzenia = stawkaWynagrodzenia,
                DzialId = dzialId
            };

            bool success = _stanowiskoService.AddStanowisko(stanowisko);

            if (success)
            {
                MessageBox.Show("Stanowisko dodane pomyślnie.");
                LoadStanowiska();
            }
            else
            {
                MessageBox.Show("Błąd podczas dodawania stanowiska.");
            }
        }

        private void checkedListBoxDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Stanowisko_Load(object sender, EventArgs e)
        {
        }

        private void bindingNavigatorStanowisko_RefreshItems(object sender, EventArgs e)
        {
        }

        private void dataGridViewStanowiska_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
