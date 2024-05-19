using NarzedzieHR.Service;
using System;
using System.Data;
using System.Windows.Forms;

namespace NarzedzieHR.Forms.Pracownik
{
    public partial class CredentialsForm : Form
    {
        private readonly int _pracownikId;
        private readonly CredentialsService _credentialsService;

        public CredentialsForm(int pracownikId)
        {
            InitializeComponent();
            _pracownikId = pracownikId;
            _credentialsService = new CredentialsService();
            LoadCredentials();
        }

        private void LoadCredentials()
        {
            DataSet dataSet = _credentialsService.GetAllCredentialsForPracownik(_pracownikId);
            DataTable dataTable = dataSet.Tables["Credentials"];
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                txtLogin.Text = row["Login"].ToString();
                txtHaslo.Text = "**********";
                btnDodaj.Enabled = false;
                btnUsun.Enabled = true;
                return;
            }
                btnDodaj.Enabled = true;
                btnUsun.Enabled = false;
        }

        private void btnDodaj_Click_1(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string haslo = txtHaslo.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Login i hasło są wymagane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            bool success = _credentialsService.AddCredentials(login, Helper.PasswordHelper.HashPassword(haslo), _pracownikId);
            if (success)
            {
                MessageBox.Show("Dane uwierzytelniające dodane pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCredentials();
            }
            else
            {
                MessageBox.Show("Błąd podczas dodawania danych uwierzytelniających.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz usunąć dane uwierzytelniające?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool success = _credentialsService.DeleteCredentials(_pracownikId);
                if (success)
                {
                    MessageBox.Show("Dane uwierzytelniające usunięte pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCredentials();
                }
                else
                {
                    MessageBox.Show("Błąd podczas usuwania danych uwierzytelniających.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CredentialsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
