using NarzedzieHR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NarzedzieHR.Service
{
    public class BenefitService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataSet GetAllBenefits()
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Benefit", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    dataAdapter.Fill(dataSet, "Benefit");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return dataSet;
        }

        public bool AddBenefit(BenefitModel benefit)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM Benefit WHERE 1=0", connection);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    DataRow newRow = table.NewRow();
                    newRow["Nazwa"] = benefit.Nazwa;
                    newRow["Opis"] = benefit.Opis;
                    newRow["Wartosc"] = benefit.Wartosc;
                    table.Rows.Add(newRow);

                    adapter.Update(table);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        public bool UpdateBenefit(BenefitModel benefit)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM Benefit WHERE Id = @Id", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", benefit.Id);

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Benefit");
                    DataTable table = dataSet.Tables["Benefit"];

                    DataRow row = table.Rows.Find(benefit.Id);
                    if (row != null)
                    {
                        row["Nazwa"] = benefit.Nazwa;
                        row["Opis"] = benefit.Opis;
                        row["Wartosc"] = benefit.Wartosc;

                        adapter.Update(dataSet, "Benefit");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteBenefit(int benefitId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM Benefit WHERE Id = @Id", connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Id", benefitId);

                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Benefit");
                    DataTable table = dataSet.Tables["Benefit"];

                    DataRow row = table.Rows.Find(benefitId);
                    if (row != null)
                    {
                        row.Delete();

                        adapter.Update(dataSet, "Benefit");
                        return true;
                    }
                    else
                    {
                        return false;
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
}
