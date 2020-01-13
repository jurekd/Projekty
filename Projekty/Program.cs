using System;

namespace Projekty
{
    class Program
    {
        static void Main()
        {
            #region zaremowane
            //Osoba o = new Osoba();

            //o.Nazwisko = "Nowak";
            //Console.WriteLine(o.Plec);
            //Console.WriteLine(o.PESEL1);

            //Osoba o2 = new Osoba("Jan", "Nowak");
            //// Osoba o3 = new Osoba { Nazwisko = "Duda", Imie = "Jerzy" };
            //Osoba o3 = new Osoba("Adam", "Maj", "aaaa", "12345678", Osoba.Płcie.M);
            //Console.WriteLine(o3);

            #endregion
            CzłonekZespołu członek1=null;
            KierownikZespołu kierownik=null;
            try
            {

                członek1 = new CzłonekZespołu("Beata", "Nowak", new DateTime(1992, 10, 22), "92102201347", Osoba.Płcie.K, "projektant");
                kierownik = new KierownikZespołu("Adam", "Kowalski", DateTime.Parse("1990-07-01"), "90070100211", Osoba.Płcie.M, 5);
            }
            catch (WrongPESELException e)
            {
                Console.WriteLine("Zły PESEL!!!");
            }


            Zespół zespół1 = new Zespół("zespół1",kierownik);
            zespół1.DodajCzłonka(członek1);
            zespół1.DodajCzłonka(new CzłonekZespołu("Jan", "Nowak","00000000001"));
            Console.WriteLine(zespół1);
            zespół1.SortujCzłonków();
            Console.WriteLine(zespół1);

            //zespół1.ZapiszBIN("zespol.bin");
            //Zespół zespół2 = zespół1.OdczytajBIN("zespol.bin") as Zespół;
            //if (zespół2 != null)
            //    Console.WriteLine(zespół2);
            Zespół.ZapiszXML("zespol.xml", zespół1);
            //Zespół zespół3 = Zespół.OdczytajXML("zespol.xml");
            //Console.WriteLine(zespół1.Equals(zespół3));
            Console.WriteLine(zespół1.JestCzłonkiem(new CzłonekZespołu("Jan", "Nowak", "00000000001")));

            Console.ReadKey();
        }


    }
}

