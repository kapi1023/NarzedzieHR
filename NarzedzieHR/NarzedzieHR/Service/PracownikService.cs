using NarzedzieHR.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NarzedzieHR.Service
{
    public class PracownikService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataSet GetAllPracownicy()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Pracownik", connection);
                    dataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataSet;
        }

        public DataSet GetPracownicyByDzial(int dzialId)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Pracownik WHERE DzialId = @DzialId", connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@DzialId", dzialId);
                    dataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataSet;
        }

        public DataSet GetPracownicyByStanowisko(int stanowiskoId)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Pracownik WHERE StanowiskoId = @StanowiskoId", connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@StanowiskoId", stanowiskoId);
                    dataAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataSet;
        }

        public decimal GetStawkaByPracownikId(int pracownikId)
        {
            decimal stawka = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT s.StawkaWynagrodzenia FROM Stanowisko s JOIN Pracownik p ON s.Id = p.StanowiskoId WHERE p.Id = @PracownikId", connection);
                    command.Parameters.AddWithValue("@PracownikId", pracownikId);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        stawka = Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return stawka;
        }

        public int GetStanowiskoIdByPracownikId(int pracownikId)
        {
            int stanowiskoId = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT StanowiskoId FROM Pracownik WHERE Id = @PracownikId", connection);
                    command.Parameters.AddWithValue("@PracownikId", pracownikId);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        stanowiskoId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return stanowiskoId;
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
