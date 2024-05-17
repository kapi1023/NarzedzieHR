using NarzedzieHR.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarzedzieHR.Service
{
    internal class PracownikService
    {
        private readonly string _connectionString;

        public PracownikService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Pracownik> GetAllPracownicy()
        {
            List<Pracownik> pracownicy = new List<Pracownik>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Pracownik", connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Pracownik pracownik = new Pracownik
                        {
                            Id = (int)reader["Id"],
                            Imie = (string)reader["Imie"],
                            Nazwisko = (string)reader["Nazwisko"],
                            Email = (string)reader["Email"],
                            DataZatrudnienia = (DateTime)reader["DataZatrudnienia"],
                            StanowiskoId = (int)reader["StanowiskoId"]
                        };

                        pracownicy.Add(pracownik);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return pracownicy;
        }

        public bool AddPracownik(Pracownik pracownik)
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

        public bool UpdatePracownik(Pracownik pracownik)
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
