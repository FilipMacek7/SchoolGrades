using ClassLibrary1;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug();
            Console.ReadLine();          
        }

        public static void Debug()
        {
            PristupTabulka pristup = new PristupTabulka();        
            Databaze databaze = new Databaze(pristup.DataAccess());   

            Znamka znamka = new Znamka();
            znamka.znamka = 5;
            znamka.Vaha = 60;
            databaze.SaveItemZnamka(znamka);

            Predmet vah = new Predmet();
            vah.Nazev = "VAH";
            vah.Znamky = new List<Znamka> { znamka };
            databaze.SaveItemPredmet(vah);

            Znamka znamka2 = new Znamka();
            znamka2.znamka = 5;
            znamka2.Vaha = 30;
            znamka2.PredmetID = 1;
            databaze.SaveItemZnamka(znamka2);

            Predmet psi = new Predmet();
            psi.Nazev = "PSI";
            psi.Znamky = new List<Znamka> { znamka2 };
            databaze.SaveItemPredmet(psi);

            List<Znamka> list = databaze.GetZnamky(0);
            foreach(Znamka z in list)
            {
                Console.WriteLine();
                Console.WriteLine("ID - " + z.ID);
                Console.WriteLine("Známka - " + z.znamka);
                Console.WriteLine("Váha - " + z.Vaha);
                Console.WriteLine();               
                //databaze.DeleteItem(z);
            }
            Console.WriteLine(databaze.prumerPredmetu(0));
        }
    }
}
