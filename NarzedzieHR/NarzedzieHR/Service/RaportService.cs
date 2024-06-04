using System;
using System.Data;
using System.Data.SqlClient;

namespace NarzedzieHR.Service
{
    public class RaportService
    {
        private readonly string _connectionString = "data source=sql.bsite.net\\MSSQL2016;initial catalog=kapi1023_;user id=kapi1023_;password=Haslo123#$";

        public DataTable GetAllRaporty()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Raport", connection);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataTable;
        }


        public DataTable GetRaportyByDzial(int dzialId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT Raport.Id,Pracownik.Id,Imie,Nazwisko,DateTime, PrzepracowaneGodziny, Wynagrodzenie FROM Raport JOIN Pracownik ON Pracownik.Id = Raport.PracownikId  WHERE Raport.StanowiskoId IN (SELECT Id FROM Stanowisko WHERE DzialId = @DzialId)", connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@DzialId", dzialId);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable GetRaportyByStanowisko(int stanowiskoId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT Raport.Id,Pracownik.Id,Imie, Nazwisko,DateTime, PrzepracowaneGodziny, Wynagrodzenie FROM Raport JOIN Pracownik ON Pracownik.Id = Raport.PracownikId  WHERE Raport.StanowiskoId = @StanowiskoId", connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@StanowiskoId", stanowiskoId);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable GetRaportyByPracownik(int pracownikId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT Raport.Id,Pracownik.Id,Imie,Nazwisko,DateTime, PrzepracowaneGodziny, Wynagrodzenie FROM Raport JOIN Pracownik ON Pracownik.Id = Raport.PracownikId  WHERE Raport.PracownikId = @PracownikId", connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@PracownikId", pracownikId);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
