﻿using NarzedzieHR.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace NarzedzieHR.Service
{
    public class DzialService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataSet GetAllDzialy()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Dzial", connection);
                    dataAdapter.Fill(dataSet, "Dzial");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataSet;
        }

        public bool AddDzial(DzialModel dzial)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.InsertCommand = new SqlCommand("INSERT INTO Dzial (Nazwa, Opis) VALUES (@Nazwa, @Opis)", connection);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@Nazwa", dzial.Nazwa);
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@Opis", dzial.Opis);
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

        public bool UpdateDzial(DzialModel dzial)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.UpdateCommand = new SqlCommand("UPDATE Dzial SET Nazwa = @Nazwa, Opis = @Opis WHERE Id = @Id", connection);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@Nazwa", dzial.Nazwa);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@Opis", dzial.Opis);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@Id", dzial.Id);
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

        public bool DeleteDzial(int dzialId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Stanowisko WHERE DzialId = @DzialId", connection);
                    command.Parameters.AddWithValue("@DzialId", dzialId);
                    connection.Open();
                    int stanowiskoCount = (int)command.ExecuteScalar();

                    if (stanowiskoCount > 0)
                    {
                        return false;
                    }

                    command = new SqlCommand("DELETE FROM Dzial WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", dzialId);
                    int rowsAffected = command.ExecuteNonQuery();

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
