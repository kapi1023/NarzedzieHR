using NarzedzieHR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarzedzieHR.Service
{
    public class AuthService
    {
        private readonly YourDbContext _context;
        public AuthService(YourDbContext context)
        {
            _context = context;
        }

        public bool RegisterUser(string login, string password, string email)
        {
            // Check if user with the same login or email already exists
            if (_context.Credentials.Any(c => c.Login == login) || _context.Pracownik.Any(p => p.Email == email))
            {
                return false; // User already exists
            }

            // Hash the password before storing it
            string hashedPassword = PasswordHasher.HashPassword(password);

            // Create new user credentials
            var credentials = new Credentials
            {
                Login = login,
                Haslo = hashedPassword
            };

            // Create new employee with the provided email
            var employee = new Pracownik
            {
                Email = email
            };

            // Add user credentials and employee to the database
            _context.Credentials.Add(credentials);
            _context.Pracownik.Add(employee);
            _context.SaveChanges();

            return true; // Registration successful
        }

        public bool AuthenticateUser(string login, string password)
        {
            // Retrieve user credentials based on login
            var credentials = _context.Credentials.FirstOrDefault(c => c.Login == login);

            // Check if credentials were found and compare hashed passwords
            if (credentials != null && credentials.Haslo == PasswordHasher.HashPassword(password))
            {
                return true; // Authentication successful
            }

            return false; // Authentication failed
        }
    }
