using SQLite;
using System;
using System.IO;

namespace ClassLibrary1
{
    public class PristupTabulka
    {
        static Databaze database;

        public static Databaze Database
        {
            get
            {
                if (database == null)
                {
                    database = new Databaze(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLite.db3"));
                }
                return database;
            }
        }
        public string DataAccess()
        {
            string dbPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.Personal),
        "SQLite.db3");

            return dbPath;
        }
    }
}
