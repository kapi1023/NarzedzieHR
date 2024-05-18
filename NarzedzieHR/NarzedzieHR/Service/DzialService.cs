using NarzedzieHR.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarzedzieHR.Service
{
    public class DzialService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public IEnumerable<DzialModel> GetAllDzialy()
        {
            List<DzialModel> dzialy = new List<DzialModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Dzial", connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        DzialModel dzial = new DzialModel
                        {
                            Id = (int)reader["Id"],
                            Nazwa = (string)reader["Nazwa"],
                            Opis = (string)reader["Opis"]
                        };

                        dzialy.Add(dzial);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dzialy;
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
                // Check if the Dzial has associated Pracownik
                SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Stanowisko WHERE DzialId = @DzialId", connection);
                checkCommand.Parameters.AddWithValue("@DzialId", dzialId);

                try
                {
                    connection.Open();
                    int employeeCount = (int)checkCommand.ExecuteScalar();

                    if (employeeCount > 0)
                        return false; // Cannot delete Dzial with associated Pracownik

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
