using System;
using System.Data;
using System.Data.SqlClient;

namespace NarzedzieHR.Service
{
    public class ReportService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataTable GetAllRaporty()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Raport", connection);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataTable;
        }

        public bool AddReport(int pracownikId, DateTime dateTime, int przepracowaneGodziny, decimal stawkaWynagrodzenia)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.InsertCommand = new SqlCommand("INSERT INTO Raport (PracownikId, DateTime, PrzepracowaneGodziny, StawkaWynagrodzenia, StanowiskoId) VALUES (@PracownikId, @DateTime, @PrzepracowaneGodziny, @StawkaWynagrodzenia, @StanowiskoId)", connection);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@PracownikId", pracownikId);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@DateTime", dateTime);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@PrzepracowaneGodziny", przepracowaneGodziny);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@StawkaWynagrodzenia", stawkaWynagrodzenia);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@StanowiskoId", GetStanowiskoIdByPracownikId(pracownikId));
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

        private int GetStanowiskoIdByPracownikId(int pracownikId)
        {
            // Implementacja metody zwracającej StanowiskoId na podstawie pracownikId
            // To powinno być zaimplementowane w PracownikService
            return new PracownikService().GetStanowiskoIdByPracownikId(pracownikId);
        }
    }
}
