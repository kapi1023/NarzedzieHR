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


namespace NarzedzieHR.Forms.Login
{
    public partial class Login : Form
    {
        private AuthService _authService;
        public Login()
        {
            InitializeComponent();
            _authService = new Service.AuthService();
        }

        private void Login_Load(object sender, EventArgs e)
        {
                
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Wywołanie metody autoryzacji z AuthService
            bool isAuthenticated = _authService.AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                MessageBox.Show("Login successful!");
                // Przekierowanie do innego formularza po pomyślnym zalogowaniu
                LandingPage landingPageForm = new LandingPage();
                landingPageForm.Show();
                this.Hide(); // Ukrycie formularza logowania
            }
            else
            {
                MessageBox.Show("Login failed. Invalid username or password.");
            }
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {

            // Wywołanie metody autoryzacji z AuthService
            bool isAuthenticated = _authService.AuthenticateUser("admin", "admin");

            if (isAuthenticated)
            {
                MessageBox.Show("Login successful!");
                // Przekierowanie do innego formularza po pomyślnym zalogowaniu
                LandingPage landingPageForm = new LandingPage();
                landingPageForm.Show();
                this.Hide(); // Ukrycie formularza logowania
            }
            else
            {
                MessageBox.Show("Login failed. Invalid username or password.");
            }
        }
    }
}
