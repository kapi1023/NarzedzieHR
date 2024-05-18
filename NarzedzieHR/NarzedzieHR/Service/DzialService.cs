using NarzedzieHR.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace NarzedzieHR.Service
{
    public class DzialService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataTable GetAllDzialy()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Dzial", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dataTable;
        }

        public bool AddDzial(DzialModel dzial)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Dzial (Nazwa, Opis) VALUES (@Nazwa, @Opis)", connection);
                command.Parameters.AddWithValue("@Nazwa", dzial.Nazwa);
                command.Parameters.AddWithValue("@Opis", dzial.Opis);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateDzial(DzialModel dzial)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Dzial SET Nazwa = @Nazwa, Opis = @Opis WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Nazwa", dzial.Nazwa);
                command.Parameters.AddWithValue("@Opis", dzial.Opis);
                command.Parameters.AddWithValue("@Id", dzial.Id);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteDzial(int dzialId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Check if the Dzial has associated Stanowisko
                SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Stanowisko WHERE DzialId = @DzialId", connection);
                checkCommand.Parameters.AddWithValue("@DzialId", dzialId);

                try
                {
                    connection.Open();
                    int stanowiskoCount = (int)checkCommand.ExecuteScalar();

                    if (stanowiskoCount > 0)
                        return false; // Cannot delete Dzial with associated Stanowisko

                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM Dzial WHERE Id = @Id", connection);
                    deleteCommand.Parameters.AddWithValue("@Id", dzialId);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
