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
        }


        private void LoadDepartments()
        {
            IEnumerable<Models.DzialModel> departments = _dzialService.GetAllDzialy();
            DataTable departmentsTable = ConvertToDataTable(departments);

            dataGridViewDepartments.DataSource = departmentsTable;

        }
        private DataTable ConvertToDataTable(IEnumerable<Models.DzialModel> dzialy)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nazwa", typeof(string));
            table.Columns.Add("Opis", typeof(string));

            foreach (Models.DzialModel dzial in dzialy)
            {
                table.Rows.Add(dzial.Id, dzial.Nazwa, dzial.Opis);
            }

            return table;
        }

        private void Dzial_Load(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string nazwa = txtNazwa.Text;
            string opis = txtOpis.Text;

            DzialModel dzial = new DzialModel { Nazwa = nazwa, Opis = opis };

            bool success = _dzialService.AddDzial(dzial);

            if (success)
            {
                MessageBox.Show("Department added successfully.");
                LoadDepartments();
            }
            else
            {
                MessageBox.Show("Error adding department.");
            }
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count > 0)
            {
                int departmentId = Convert.ToInt32(dataGridViewDepartments.SelectedRows[0].Cells["Id"].Value);
                string nazwa = txtNazwa.Text;
                string opis = txtOpis.Text;

                DzialModel dzial = new DzialModel { Id = departmentId, Nazwa = nazwa, Opis = opis };

                bool success = _dzialService.UpdateDzial(dzial);

                if (success)
                {
                    MessageBox.Show("Department updated successfully.");
                    LoadDepartments();
                }
                else
                {
                    MessageBox.Show("Error updating department.");
                }
            }
            else
            {
                MessageBox.Show("Select a department to update.");
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count > 0)
            {
                int departmentId = Convert.ToInt32(dataGridViewDepartments.SelectedRows[0].Cells["Id"].Value);

                bool success = _dzialService.DeleteDzial(departmentId);

                if (success)
                {
                    MessageBox.Show("Department deleted successfully.");
                    LoadDepartments();
                }
                else
                {
                    MessageBox.Show("Error deleting department. Department may have associated employees.");
                }
            }
            else
            {
                MessageBox.Show("Select a department to delete.");
            }
        }

        private void dataGridViewDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void dataGridViewDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDepartments.Rows[e.RowIndex];
                txtNazwa.Text = row.Cells["Nazwa"].Value.ToString();
                txtOpis.Text = row.Cells["Opis"].Value.ToString();
            }
        }
    }
}
