using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Debug();
            Console.ReadLine();          
        }

        public static void Debug()
        {
            ClassLibrary1.PristupTabulka pristup = new ClassLibrary1.PristupTabulka();        
            ClassLibrary1.DatabazeZnamek databaze = new ClassLibrary1.DatabazeZnamek(pristup.DataAccess());
            ClassLibrary1.Znamka znamka = new ClassLibrary1.Znamka();
            znamka.znamka = 1;
            znamka.Vaha = 30;

            ClassLibrary1.Znamka znamka2 = new ClassLibrary1.Znamka();
            znamka2.znamka = 3;
            znamka2.Vaha = 40;

            databaze.SaveItemAsync(znamka);
            databaze.SaveItemAsync(znamka2);

            List<ClassLibrary1.Znamka> list = databaze.GetItems();
            foreach(ClassLibrary1.Znamka z in list)
            {
                Console.WriteLine();
                Console.WriteLine("ID - " + z.ID);
                Console.WriteLine("Známka - " + z.znamka);
                Console.WriteLine("Váha - " + z.Vaha);
                Console.WriteLine();
                //Console.WriteLine(databaze.prumerPredmetu(z.Predmet));
                //databaze.DeleteItem(z);
            }
        }
    }
}
