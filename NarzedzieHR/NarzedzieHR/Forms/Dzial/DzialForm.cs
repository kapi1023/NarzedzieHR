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
        public DzialForm()
        {
            InitializeComponent();
            _dzialService = new DzialService();
            LoadDepartments();
        }
        private readonly DzialService _dzialService;


        private void LoadDepartments()
        {
            DataTable departmentsTable = _dzialService.GetAllDzialy();
            dataGridViewDepartments.DataSource = departmentsTable;
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

        private void Dzial2Form_Load(object sender, EventArgs e)
        {

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
    }
}
