using NarzedzieHR.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;

namespace NarzedzieHR.Service
{
    public class AuthService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public bool AuthenticateUser(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Credentials WHERE Login = @Login", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Login", login);
                DataSet dataSet = new DataSet();

                try
                {
                    connection.Open();
                    adapter.Fill(dataSet, "Credentials");

                    if (dataSet.Tables["Credentials"].Rows.Count != 1)
                        return false; // User not found

                    string storedPassword = dataSet.Tables["Credentials"].Rows[0]["Haslo"].ToString();

                    // Compare stored hashed password with the provided password
                    if (Helper.PasswordHelper.VerifyHashedPassword(storedPassword, password))
                        return true; // Authentication successful
                    else
                        return false; // Incorrect password
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false; // Error occurred during authentication
                }
            }
        }
    }
}
