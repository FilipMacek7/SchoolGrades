using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ClassLibrary1
{
    public class Databaze
    {
        SQLiteConnection db;

        public Databaze(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Predmet>();
            db.CreateTable<Znamka>();

        }
        public List<Znamka> GetZnamky(int predmetID)
        {
            return db.Query<Znamka>("SELECT * FROM [Znamky] WHERE [PredmetID] =" + predmetID);
        }
        public List<Predmet> GetAllPredmety()
        {
            return db.Table<Predmet>().ToList();
        }
        public List<Znamka> GetAllZnamky()
        {
            return db.Table<Znamka>().ToList();
        }
        public Znamka GetItemZnamka(int id)
        {
            return db.Table<Znamka>().Where(i => i.ID == id).FirstOrDefault();
        }

        public Predmet GetItemPredmet(int id)
        {
            return db.Table<Predmet>().Where(i => i.Id == id).FirstOrDefault();
        }

        public int SaveItemPredmet(Predmet item)
        {
                return db.Insert(item);
        }

        public int SaveItemZnamka(Znamka item)
        {
                return db.Insert(item);
        }

        public int DeleteItemZnamka(Znamka item)
        {
            return db.Delete(item);
        }

        public int DeleteItemPredmet(Predmet item)
        {
            return db.Delete(item);
        }

        public double prumerPredmetu(int predmetID)
        {
            double soucetznamek = 0;
            double soucetvahy = 0;
            foreach (Znamka z in db.Query<Znamka>("SELECT * FROM [Znamky] WHERE [PredmetID] =" + predmetID))
            {               
                soucetznamek = soucetznamek + z.znamka * z.Vaha;
                soucetvahy = soucetvahy + z.Vaha;
            }
            double result = soucetznamek / soucetvahy;

            return Math.Round(result, 2); 

        }
    }
}
