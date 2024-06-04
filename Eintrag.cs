﻿using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class Eintrag
    {
        public int ID;
        public int fkUserID;
        public DateTime Datum;
        public double Betrag;
        public string Beschreibung;

        public Eintrag(int id, int fkuserid, DateTime datum, double betrag, string beschreibung)
        {
            ID = id;
            Datum = datum;
            Betrag = betrag;
            Beschreibung = beschreibung;
        }

        public static List<Eintrag> GetEinträge()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=Assets/bank.db"))
            {

                connection.Open();

                SqliteCommand command = connection.CreateCommand();

                command.CommandText = @"SELECT * FROM tblEintrag";

                List<Eintrag> Einträge = new List<Eintrag>();

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Eintrag eintrag = new Eintrag(reader.GetInt16(1), reader.GetInt16(2), reader.GetDateTime(3), reader.GetDouble(4), reader.GetString(5));
                        Einträge.Add(eintrag);
                    }
                }
                return Einträge;
            }
        }
    }
}
