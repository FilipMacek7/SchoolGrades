using SQLite;
using System;
using System.IO;

namespace ClassLibrary1
{
    public class PristupTabulka
    {
        static DatabazeZnamek database;

        public static DatabazeZnamek Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabazeZnamek(
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
            var db = new SQLiteConnection(dbPath);
            var table = db.Table<Znamka>();

            return dbPath;
        }
    }
}
