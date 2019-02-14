using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ClassLibrary1
{
    public class Databaze
    {
        SQLiteConnection db;
        public List<Predmet> Predmety;
        public Databaze(string dbPath)
        {
            db = new SQLiteConnection(dbPath);          
            db.CreateTable<Znamka>();
            var znamkaList = db.Table<Znamka>();
        }
        public List<Znamka> GetItems()
        {
            return db.Table<Znamka>().ToList();
        }

        public List<Znamka> GetItemsNotDone()
        {
            return db.Query<Znamka>("SELECT * FROM [Znamka] WHERE [Done] = 0");
        }

        public Znamka GetItem(int id)
        {
            return db.Table<Znamka>().Where(i => i.ID == id).FirstOrDefault();
        }

        public int SaveItemAsync(Znamka item)
        {
            if (item.ID != 0)
            {
                return db.Update(item);
            }
            else
            {
                return db.Insert(item);
            }
        }

        public int DeleteItem(Znamka item)
        {
            return db.Delete(item);
        }

        public int prumerPredmetu(string predmet)
        {
            if (GetItems() != null)
            {
                int pocetznamek = 0;
                int soucetznamek = 0;
                foreach (Znamka z in db.Query<Znamka>("SELECT * FROM [Znamka] WHERE [Predmet] =" + predmet))
                {
                    pocetznamek++;
                    soucetznamek = soucetznamek + z.znamka;
                }

                return soucetznamek / pocetznamek;
            }
            else
            {
                return 0;
            }
        }


        public List<Znamka> GetItemsFromSubject(string predmet)
        {
            if (GetItems() != null)
            {
                return db.Query<Znamka>("SELECT * FROM [Znamka] WHERE [Predmet] =" + predmet);
            }
            else
            {
                return null;
            }
        }
    }
}
