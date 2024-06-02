using NarzedzieHR.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NarzedzieHR.Service
{
    public class StanowiskoService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataSet GetAllStanowiska()
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Stanowisko", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dataSet;
        }

        public DataSet GetStanowiskaByDzial(int dzialId)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Stanowisko WHERE DzialId = @DzialId", connection);
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

        public bool AddStanowisko(StanowiskoModel stanowisko)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Stanowisko (Nazwa, Opis, DzialId, StawkaWynagrodzenia) VALUES (@Nazwa, @Opis, @DzialId, @StawkaWynagrodzenia); SELECT SCOPE_IDENTITY();", connection);
                    command.Parameters.AddWithValue("@Nazwa", stanowisko.Nazwa);
                    command.Parameters.AddWithValue("@Opis", stanowisko.Opis);
                    command.Parameters.AddWithValue("@DzialId", stanowisko.DzialId);
                    command.Parameters.AddWithValue("@StawkaWynagrodzenia", stanowisko.StawkaWynagrodzenia);

                    int insertedStanowiskoId = Convert.ToInt32(command.ExecuteScalar());
                    if (stanowisko.Benefits != null)
                    {
                        foreach (var benefit in stanowisko.Benefits)
                        {
                            SqlCommand addBenefitCommand = new SqlCommand("INSERT INTO BenefitStanowisko (BenefitId, StanowiskoId) VALUES (@BenefitId, @StanowiskoId)", connection);
                            addBenefitCommand.Parameters.AddWithValue("@BenefitId", benefit.Id);
                            addBenefitCommand.Parameters.AddWithValue("@StanowiskoId", insertedStanowiskoId);
                            addBenefitCommand.ExecuteNonQuery();
                        }
                    }

                    return insertedStanowiskoId > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateStanowisko(StanowiskoModel stanowisko)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand updateCommand = new SqlCommand("UPDATE Stanowisko SET Nazwa = @Nazwa, Opis = @Opis, DzialId = @DzialId, StawkaWynagrodzenia = @StawkaWynagrodzenia WHERE Id = @Id", connection);
                    updateCommand.Parameters.AddWithValue("@Nazwa", stanowisko.Nazwa);
                    updateCommand.Parameters.AddWithValue("@Opis", stanowisko.Opis);
                    updateCommand.Parameters.AddWithValue("@DzialId", stanowisko.DzialId);
                    updateCommand.Parameters.AddWithValue("@StawkaWynagrodzenia", stanowisko.StawkaWynagrodzenia);
                    updateCommand.Parameters.AddWithValue("@Id", stanowisko.Id);

                    int rowsUpdated = updateCommand.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                    {
                        SqlCommand deleteBenefitsCommand = new SqlCommand("DELETE FROM BenefitStanowisko WHERE StanowiskoId = @StanowiskoId", connection);
                        deleteBenefitsCommand.Parameters.AddWithValue("@StanowiskoId", stanowisko.Id);
                        deleteBenefitsCommand.ExecuteNonQuery();

                        if (stanowisko.Benefits != null && stanowisko.Benefits.Count > 0)
                        {
                            SqlCommand insertBenefitCommand = new SqlCommand("INSERT INTO BenefitStanowisko (BenefitId, StanowiskoId) VALUES (@BenefitId, @StanowiskoId)", connection);

                            insertBenefitCommand.Parameters.Add("@BenefitId", SqlDbType.Int);
                            insertBenefitCommand.Parameters.Add("@StanowiskoId", SqlDbType.Int);

                            foreach (var benefit in stanowisko.Benefits)
                            {
                                insertBenefitCommand.Parameters["@BenefitId"].Value = benefit.Id;
                                insertBenefitCommand.Parameters["@StanowiskoId"].Value = stanowisko.Id;
                                insertBenefitCommand.ExecuteNonQuery();
                            }
                        }

                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public int GetDzialIdForStanowisko(int stanowiskoId)
        {
            int dzialId = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT DzialId FROM Stanowisko WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", stanowiskoId);
                    adapter.SelectCommand = command;
                    object result = adapter.SelectCommand.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        dzialId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dzialId;
        }

        public bool DeleteStanowisko(int stanowiskoId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand checkBenefitCommand = new SqlCommand("SELECT COUNT(*) FROM BenefitStanowisko WHERE StanowiskoId = @StanowiskoId", connection);
                    checkBenefitCommand.Parameters.AddWithValue("@StanowiskoId", stanowiskoId);
                    adapter.SelectCommand = checkBenefitCommand;

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    int benefitCount = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);

                    if (benefitCount > 0)
                    {
                        MessageBox.Show("Nie można usunąć stanowiska, które ma przypisane benefity.");
                        return false;
                    }

                    SqlCommand deleteCommand = new SqlCommand("DELETE FROM Stanowisko WHERE Id = @Id", connection);
                    deleteCommand.Parameters.AddWithValue("@Id", stanowiskoId);
                    adapter.DeleteCommand = deleteCommand;

                    int rowsAffected = adapter.DeleteCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetBenefitsForStanowisko(int stanowiskoId)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT b.*, CASE WHEN bs.StanowiskoId IS NOT NULL THEN 1 ELSE 0 END AS czyWybrana FROM Benefit b LEFT JOIN BenefitStanowisko bs ON b.Id = bs.BenefitId AND bs.StanowiskoId = @StanowiskoId", connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@StanowiskoId", stanowiskoId);

                try
                {
                    connection.Open();
                    dataAdapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dataSet;
        }
    }
}
