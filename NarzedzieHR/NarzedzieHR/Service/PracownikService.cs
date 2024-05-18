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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Pracownik", connection);
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

        public bool AddPracownik(PracownikModel pracownik)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Pracownik (Imie, Nazwisko, Email, DataZatrudnienia, StanowiskoId) VALUES (@Imie, @Nazwisko, @Email, @DataZatrudnienia, @StanowiskoId)", connection);
                command.Parameters.AddWithValue("@Imie", pracownik.Imie);
                command.Parameters.AddWithValue("@Nazwisko", pracownik.Nazwisko);
                command.Parameters.AddWithValue("@Email", pracownik.Email);
                command.Parameters.AddWithValue("@DataZatrudnienia", pracownik.DataZatrudnienia);
                command.Parameters.AddWithValue("@StanowiskoId", pracownik.StanowiskoId);

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

        public bool UpdatePracownik(PracownikModel pracownik)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Pracownik SET Imie = @Imie, Nazwisko = @Nazwisko, Email = @Email, DataZatrudnienia = @DataZatrudnienia, StanowiskoId = @StanowiskoId WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Imie", pracownik.Imie);
                command.Parameters.AddWithValue("@Nazwisko", pracownik.Nazwisko);
                command.Parameters.AddWithValue("@Email", pracownik.Email);
                command.Parameters.AddWithValue("@DataZatrudnienia", pracownik.DataZatrudnienia);
                command.Parameters.AddWithValue("@StanowiskoId", pracownik.StanowiskoId);
                command.Parameters.AddWithValue("@Id", pracownik.Id);

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

        public bool ChangePracownikDzial(int pracownikId, int nowyDzialId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Pracownik SET DzialId = @NowyDzialId WHERE Id = @PracownikId", connection);
                command.Parameters.AddWithValue("@NowyDzialId", nowyDzialId);
                command.Parameters.AddWithValue("@PracownikId", pracownikId);

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

        public bool DeletePracownik(int pracownikId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Pracownik WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", pracownikId);

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
    }
}
