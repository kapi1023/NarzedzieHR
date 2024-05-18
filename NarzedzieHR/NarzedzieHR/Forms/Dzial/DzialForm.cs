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
            bindingNavigatorDzialy.BindingSource = bindingSourceDzialy;
        }
        private DataGridViewRow _editedRow;

        private readonly DzialService _dzialService;


        private void LoadDepartments()
        {
            DataSet departmentsTable = _dzialService.GetAllDzialy();
            bindingSourceDzialy.DataSource = departmentsTable.Tables["Dzial"];
            dataGridViewDepartments.DataSource = bindingSourceDzialy;
        }

        private void Dzial2Form_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewDepartments_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a department to delete.");
                return;
            }
            if (dataGridViewDepartments.SelectedRows[0].Index == dataGridViewDepartments.Rows.Count - 1)
            {
                MessageBox.Show("Cannot delete the last row.");
                return;
            }

            DataRowView currentRow = (DataRowView)bindingSourceDzialy.Current;
            int departmentId = Convert.ToInt32(currentRow["Id"]);

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

        private void bindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridViewDepartments.SelectedRows;

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("No department is being edited.");
                return;
            }

            DataGridViewRow editedRow = selectedRows[0];

            string nazwa = editedRow.Cells["Nazwa"].Value.ToString();
            string opis = editedRow.Cells["Opis"].Value.ToString();

            if (string.IsNullOrEmpty(nazwa) || string.IsNullOrEmpty(opis))
            {
                MessageBox.Show("Department name and description are required.");
                return;
            }

            DataRowView currentRow = (DataRowView)editedRow.DataBoundItem;
            int departmentId = Convert.ToInt32(currentRow["Id"]);
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

        private void dataGridViewDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewDepartments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridViewDepartments.Rows.Count - 2 && e.ColumnIndex == dataGridViewDepartments.Columns.Count - 1)
            {
                string nazwa = dataGridViewDepartments.Rows[e.RowIndex].Cells["Nazwa"].Value.ToString();
                string opis = dataGridViewDepartments.Rows[e.RowIndex].Cells["Opis"].Value.ToString();

                if (string.IsNullOrEmpty(nazwa) || string.IsNullOrEmpty(opis))
                {
                    MessageBox.Show("Department name and description are required.");
                    return;
                }

                DzialModel dzial = new DzialModel { Nazwa = nazwa, Opis = opis };

                bool success = _dzialService.AddDzial(dzial);

                if (!success)
                {
                    MessageBox.Show("Error adding department.");
                    return;
                }

                MessageBox.Show("Department added successfully.");
                LoadDepartments();
            }

        }

        private void bindingNavigatorDzialy_RefreshItems(object sender, EventArgs e)
        {

        }



    }
}
