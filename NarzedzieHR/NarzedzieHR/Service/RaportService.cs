using NarzedzieHR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarzedzieHR.Service
{
    internal class RaportService
    {
        public class ReportService
        {
            private readonly string _connectionString;

            public ReportService(string connectionString)
            {
                _connectionString = connectionString;
            }

            public IEnumerable<Raport> GetAllReports()
            {
                List<Raport> reports = new List<Raport>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Raport", connection);
                    DataSet dataSet = new DataSet();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataSet, "Raport");

                        foreach (DataRow row in dataSet.Tables["Raport"].Rows)
                        {
                            Raport report = new Raport
                            {
                                Id = (int)row["Id"],
                                DateTime = (DateTime)row["DateTime"],
                                PrzepracowaneGodziny = (int)row["PrzepracowaneGodziny"],
                                StawkaWynagrodzenia = (decimal)row["StawkaWynagrodzenia"],
                                PracownikId = (int)row["PracownikId"],
                                StanowiskoId = (int)row["StanowiskoId"]
                            };

                            reports.Add(report);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                return reports;
            }

            public IEnumerable<Raport> GetUserReports(int pracownikId)
            {
                List<Raport> userReports = new List<Raport>();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Raport WHERE PracownikId = @PracownikId", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@PracownikId", pracownikId);
                    DataSet dataSet = new DataSet();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataSet, "Raport");

                        foreach (DataRow row in dataSet.Tables["Raport"].Rows)
                        {
                            Raport report = new Raport
                            {
                                Id = (int)row["Id"],
                                DateTime = (DateTime)row["DateTime"],
                                PrzepracowaneGodziny = (int)row["PrzepracowaneGodziny"],
                                StawkaWynagrodzenia = (decimal)row["StawkaWynagrodzenia"],
                                PracownikId = (int)row["PracownikId"],
                                StanowiskoId = (int)row["StanowiskoId"]
                            };

                            userReports.Add(report);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                return userReports;
            }

            public bool CreateReport(Raport report)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Raport", connection);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    DataSet dataSet = new DataSet();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataSet, "Raport");

                        DataRow newRow = dataSet.Tables["Raport"].NewRow();
                        newRow["DateTime"] = report.DateTime;
                        newRow["PrzepracowaneGodziny"] = report.PrzepracowaneGodziny;
                        newRow["StawkaWynagrodzenia"] = report.StawkaWynagrodzenia;
                        newRow["PracownikId"] = report.PracownikId;
                        newRow["StanowiskoId"] = report.StanowiskoId;

                        dataSet.Tables["Raport"].Rows.Add(newRow);
                        adapter.Update(dataSet, "Raport");

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }

            public bool UpdateReport(Raport report)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Raport WHERE Id = @Id", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", report.Id);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    DataSet dataSet = new DataSet();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataSet, "Raport");

                        if (dataSet.Tables["Raport"].Rows.Count == 0)
                            return false;

                        DataRow row = dataSet.Tables["Raport"].Rows[0];
                        row["DateTime"] = report.DateTime;
                        row["PrzepracowaneGodziny"] = report.PrzepracowaneGodziny;
                        row["StawkaWynagrodzenia"] = report.StawkaWynagrodzenia;
                        row["PracownikId"] = report.PracownikId;
                        row["StanowiskoId"] = report.StanowiskoId;

                        adapter.Update(dataSet, "Raport");

                        return true;
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
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Raport WHERE Id = @Id", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", reportId);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    DataSet dataSet = new DataSet();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataSet, "Raport");

                        if (dataSet.Tables["Raport"].Rows.Count == 0)
                            return false;

                        dataSet.Tables["Raport"].Rows[0].Delete();
                        adapter.Update(dataSet, "Raport");

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }

            // Other CRUD operations can be implemented similarly
        }
    }
}
