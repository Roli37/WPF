using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using Ookii.Dialogs.Wpf;

namespace WPF.Models
{
    public class MainWindowViewModel
    {
        public class Adat
        {
            public string Megrendelo_neve { get; set; }
            public string Megrendelo_cime { get; set; }
            public string Munka_tipusa { get; set; }
            public string Megrendelo_telefonszama { get; set; }
            public string Szerelo_neve { get; set; }
            public DateTime Karbantartas_datuma { get; set; }

            public string Karbantartas_ara { get; set; }
        }
        public static void Exportal(List<Adat> alldata)
        {
            var dialog = new VistaFolderBrowserDialog();
            bool? success = dialog.ShowDialog();
            if (success == true)
            {
                string filename = Path.Combine(
                    dialog.SelectedPath,
                    $"karbantartasok_{DateTime.Now:yyyy-MM-dd_HH-mm}.csv");

                File.WriteAllLines(filename,
                    alldata.Select(x => String.Join(";",
                        x.Megrendelo_neve,
                        x.Megrendelo_cime,
                        x.Munka_tipusa,
                        x.Megrendelo_telefonszama,
                        x.Szerelo_neve,
                        x.Karbantartas_datuma,
                        x.Karbantartas_ara))
                    );
            }
        }
        public static List<Adat> FilterData(List<Adat> AllData, string nev, int ar)
        {
            List<Adat> lista = new List<Adat>();
            foreach (var item in AllData)
            {
                item.Karbantartas_ara = new String(item.Karbantartas_ara.Where(Char.IsDigit).ToArray());
                lista.Add(item);
            }
            List<Adat> lista2 = new List<Adat>();
            if ((AllData.Any(x => x.Szerelo_neve == nev) == true) && (ar > 5000 && ar % 1000 == 0))
            {
                lista2 = lista.Where(x => x.Szerelo_neve == nev).Where(x => int.Parse(x.Karbantartas_ara) > ar).OrderBy(x => int.Parse(x.Karbantartas_ara)).ToList();
            }
            else
            {
                string message = "Csak olyan szerelőt adhatsz meg, aki már fent van a listán! Csak 5000-nél nagyobb, és 1000-el osztható számot adhatsz meg!";
                string title = "Warning";
                MessageBox.Show(message, title);
            }
            return lista2;
        }
        public static List<Adat> AllData(IDbConnection connection)
        {
            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT megrendelok.nev as 'Név', " +
                "megrendelok.cim as 'Cím', " +
                "szakteruletek.megnevezes as 'Munka típusa', " +
                "megrendelok.telefon as 'Telefonszám', " +
                "szerelok.nev as 'Szerelő neve', " +
                "karbantartasok.datum as 'Dátum', " +
                "CONCAT(FORMAT((karbantartasok.javido*szerelok.oradij*(100-megrendelok.kedvezmeny)/100), '#,#'), ' Ft') as 'Ár' " +
                "FROM karbantartasok " +
                "INNER JOIN megrendelok on karbantartasok.megrendelo_id = megrendelok.megrendelo_id " +
                "INNER JOIN szerelok on karbantartasok.szerelo_id = szerelok.szerelo_id " +
                "INNER JOIN szakteruletek on szerelok.szakterulet_id = szakteruletek.szakterulet_id " +
                "ORDER BY szerelok.nev ASC, karbantartasok.datum ASC";

            using var reader = command.ExecuteReader();
            List<Adat> adatok = new List<Adat>();
            while (reader.Read())
            {
                Adat adat = new Adat()
                {
                    Megrendelo_neve = (string)reader["Név"],
                    Megrendelo_cime = (string)reader["Cím"],
                    Munka_tipusa = (string)reader["Munka típusa"],
                    Megrendelo_telefonszama = (string)reader["Telefonszám"],
                    Szerelo_neve = (string)reader["Szerelő neve"],
                    Karbantartas_datuma = (DateTime)reader["Dátum"],
                    Karbantartas_ara = (string)reader["Ár"]
                };
                adatok.Add(adat);
            }
            return adatok;
        }
        public static IDbConnection OpenConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Database = "karbantarto";
            builder.Password = "";
            IDbConnection connection = new MySqlConnection(builder.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
