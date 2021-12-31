using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WPF.Models
{
    public class SecondWindowViewModel
    {

        public static void Command(IDbConnection connection, string szerelonev, string megrendelonev, DateTime datum, int javido)
        {
            if (datum < DateTime.Now)
            {
                string message = "Nem adhatsz meg már elmúlt dátumot!";
                string title = "Warning";
                MessageBox.Show(message, title);
            }
            else
            {
                string szereloid = SzereloID(OpenConnection(), szerelonev);
                string megrendeloid = MegrendeloID(OpenConnection(), megrendelonev);

                using var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO karbantartasok (szerelo_id, megrendelo_id, datum, javido) VALUES (@id, @id2, @datum, @javido)";

                var param = command.CreateParameter();
                param.ParameterName = "@id";
                param.Value = szereloid;

                var param2 = command.CreateParameter();
                param2.ParameterName = "@id2";
                param2.Value = megrendeloid;

                var param3 = command.CreateParameter();
                param3.ParameterName = "@datum";
                param3.Value = datum;

                var param4 = command.CreateParameter();
                param4.ParameterName = "@javido";
                param4.Value = javido;

                command.Parameters.Add(param);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.ExecuteNonQuery();
            }

        }
        public static string SzereloID(IDbConnection connection, string szerelonev)
        {
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT DISTINCT szerelok.szerelo_id " +
                "FROM szerelok " +
                "WHERE szerelok.nev like @Name";
            var param = command.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = szerelonev;
            command.Parameters.Add(param);
            using var reader = command.ExecuteReader();
            reader.Read();
            string result = reader["szerelo_id"].ToString();
            reader.Close();
            return result;
        }
        public static string MegrendeloID(IDbConnection connection, string megrendelonev)
        {
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT DISTINCT megrendelok.megrendelo_id " +
                "FROM megrendelok " +
                "WHERE megrendelok.nev like @Name";
            var param = command.CreateParameter();
            param.ParameterName = "@Name";
            param.Value = megrendelonev;
            command.Parameters.Add(param);
            using var reader = command.ExecuteReader();
            reader.Read();
            string result = reader["megrendelo_id"].ToString();
            reader.Close();
            return result;
        }
        public static List<string> Szerelonevek(IDbConnection connection)
        {
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT DISTINCT szerelok.nev as 'Szerelő nevek' FROM `szerelok`";
            using var reader = command.ExecuteReader();
            List<string> szerelok = new List<string>();
            while (reader.Read())
            {
                szerelok.Add((string)reader["Szerelő nevek"]);
            }
            return szerelok;
        }
        public static List<string> Megrendelonevek(IDbConnection connection)
        {
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT DISTINCT megrendelok.nev as 'Megrendelő nevek' FROM `megrendelok`";
            using var reader = command.ExecuteReader();
            List<string> megrendelok = new List<string>();
            while (reader.Read())
            {
                megrendelok.Add((string)reader["Megrendelő nevek"]);
            }
            return megrendelok;
        }
        public static List<int> Szamok()
        {
            List<int> szamok = new List<int>();
            for (int i = 1; i < 9; i++)
            {
                szamok.Add(i);
            }
            return szamok;
        }

        public static IDbConnection OpenConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Database = "karbantarto";
            builder.Password = "";
            builder.AllowUserVariables = true;
            IDbConnection connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
