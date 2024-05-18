﻿using NarzedzieHR.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NarzedzieHR.Service
{
    public class StanowiskoService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataTable GetAllStanowiska()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Stanowisko", connection);
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

        public bool AddStanowisko(StanowiskoModel stanowisko)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("INSERT INTO Stanowisko (Nazwa, Opis, DzialId, StawkaWynagrodzenia) VALUES (@Nazwa, @Opis, @DzialId, @StawkaWynagrodzenia)", connection);
                    command.Parameters.AddWithValue("@Nazwa", stanowisko.Nazwa);
                    command.Parameters.AddWithValue("@Opis", stanowisko.Opis);
                    command.Parameters.AddWithValue("@DzialId", stanowisko.DzialId);
                    command.Parameters.AddWithValue("@StawkaWynagrodzenia", stanowisko.StawkaWynagrodzenia);
                    adapter.InsertCommand = command;
                    int rowsAffected = adapter.InsertCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
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
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("UPDATE Stanowisko SET Nazwa = @Nazwa, Opis = @Opis, DzialId = @DzialId, StawkaWynagrodzenia = @StawkaWynagrodzenia WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Nazwa", stanowisko.Nazwa);
                    command.Parameters.AddWithValue("@Opis", stanowisko.Opis);
                    command.Parameters.AddWithValue("@DzialId", stanowisko.DzialId);
                    command.Parameters.AddWithValue("@StawkaWynagrodzenia", stanowisko.StawkaWynagrodzenia);
                    command.Parameters.AddWithValue("@Id", stanowisko.Id);
                    adapter.UpdateCommand = command;
                    int rowsAffected = adapter.UpdateCommand.ExecuteNonQuery();

                    return rowsAffected > 0;
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
            }
        }
    }
}
