using System;
using System.Data;
using System.Data.SqlClient;

namespace NarzedzieHR.Service
{
    public class ReportService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataTable GetEmployeeReports(int employeeId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Reports WHERE EmployeeId = @EmployeeId", connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataTable;
        }
        public bool AddReport(int employeeId, string reportText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.InsertCommand = new SqlCommand("INSERT INTO Reports (EmployeeId, ReportText) VALUES (@EmployeeId, @ReportText)", connection);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@ReportText", reportText);
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

        public bool UpdateReport(int reportId, string reportText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.UpdateCommand = new SqlCommand("UPDATE Reports SET ReportText = @ReportText WHERE Id = @ReportId", connection);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@ReportText", reportText);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@ReportId", reportId);
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

        public bool DeleteReport(int reportId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Reports WHERE Id = @ReportId", connection);
                    dataAdapter.DeleteCommand.Parameters.AddWithValue("@ReportId", reportId);
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
