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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Reports WHERE EmployeeId = @EmployeeId", connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
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

        public bool AddReport(int employeeId, string reportText)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Reports (EmployeeId, ReportText) VALUES (@EmployeeId, @ReportText)", connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@ReportText", reportText);

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

        public bool UpdateReport(int reportId, string reportText)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Reports SET ReportText = @ReportText WHERE Id = @ReportId", connection);
                command.Parameters.AddWithValue("@ReportText", reportText);
                command.Parameters.AddWithValue("@ReportId", reportId);

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

        public bool DeleteReport(int reportId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand deleteCommand = new SqlCommand("DELETE FROM Reports WHERE Id = @ReportId", connection);
                deleteCommand.Parameters.AddWithValue("@ReportId", reportId);

                try
                {
                    connection.Open();
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
