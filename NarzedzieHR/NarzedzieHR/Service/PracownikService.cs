using NarzedzieHR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NarzedzieHR.Service
{
    public class PracownikService
    {
        private readonly string _connectionString;

        public PracownikService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetAllPracownicy()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Pracownik", connection);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataTable;
        }

        public bool AddPracownik(PracownikModel pracownik)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.InsertCommand = new SqlCommand("INSERT INTO Pracownik (Imie, Nazwisko, Email, DataZatrudnienia, StanowiskoId) VALUES (@Imie, @Nazwisko, @Email, @DataZatrudnienia, @StanowiskoId)", connection);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@Imie", pracownik.Imie);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@Nazwisko", pracownik.Nazwisko);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@Email", pracownik.Email);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@DataZatrudnienia", pracownik.DataZatrudnienia);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@StanowiskoId", pracownik.StanowiskoId);
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

        public bool UpdatePracownik(PracownikModel pracownik)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.UpdateCommand = new SqlCommand("UPDATE Pracownik SET Imie = @Imie, Nazwisko = @Nazwisko, Email = @Email, DataZatrudnienia = @DataZatrudnienia, StanowiskoId = @StanowiskoId WHERE Id = @Id", connection);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@Imie", pracownik.Imie);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@Nazwisko", pracownik.Nazwisko);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@Email", pracownik.Email);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@DataZatrudnienia", pracownik.DataZatrudnienia);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@StanowiskoId", pracownik.StanowiskoId);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@Id", pracownik.Id);
                    connection.Open();
                    int rowsAffected = dataAdapter.UpdateCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool ChangePracownikDzial(int pracownikId, int nowyDzialId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.UpdateCommand = new SqlCommand("UPDATE Pracownik SET DzialId = @NowyDzialId WHERE Id = @PracownikId", connection);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@NowyDzialId", nowyDzialId);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@PracownikId", pracownikId);
                    connection.Open();
                    int rowsAffected = dataAdapter.UpdateCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeletePracownik(int pracownikId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Pracownik WHERE Id = @Id", connection);
                    dataAdapter.DeleteCommand.Parameters.AddWithValue("@Id", pracownikId);
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
    }
}
