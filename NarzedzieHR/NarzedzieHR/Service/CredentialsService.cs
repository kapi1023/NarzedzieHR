using System;
using System.Data;
using System.Data.SqlClient;

namespace NarzedzieHR.Service
{
    public class CredentialsService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public bool AddCredentials(string login, string haslo, int pracownikId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.InsertCommand = new SqlCommand("INSERT INTO Credentials (Login, Haslo, PracownikId) VALUES (@Login, @Haslo, @PracownikId)", connection);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@Login", login);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@Haslo", haslo);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@PracownikId", pracownikId);
                    connection.Open();
                    int rowsAffected = dataAdapter.InsertCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteCredentials(int credentialsId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Credentials WHERE PracownikId = @Id", connection);
                    dataAdapter.DeleteCommand.Parameters.AddWithValue("@Id", credentialsId);
                    connection.Open();
                    int rowsAffected = dataAdapter.DeleteCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public DataSet GetAllCredentialsForPracownik(int pracownikId)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Credentials WHERE PracownikId = @PracownikId", connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@PracownikId", pracownikId);
                    dataAdapter.Fill(dataSet, "Credentials");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataSet;
        }
    }
}
