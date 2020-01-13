using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Projekty
{
    [Serializable]
   public class Zespół : IZapisywalna,IEquatable<Zespół>
    {
        int liczbaCzłonków;
        string nazwa;
        KierownikZespołu kierownik;
        public List<CzłonekZespołu> członkowie; //= new List<CzłonekZespołu>();

        public Zespół()
        {
            //liczbaCzłonków = 0;
            //nazwa = null;
            //kierownik = null;
            członkowie = new List<CzłonekZespołu>(); 
        }

        public Zespół(string nazwa, KierownikZespołu kierownik):this()
        {
            this.nazwa = nazwa;
            this.kierownik = kierownik;
        }

        public int LiczbaCzłonków { get => liczbaCzłonków; set => liczbaCzłonków = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public KierownikZespołu Kierownik { get => kierownik; set => kierownik = value; }

        public void DodajCzłonka(CzłonekZespołu członekZespołu)
        {
            członkowie.Add(członekZespołu);
            liczbaCzłonków++;
        }

        public override string ToString()
        {
            StringBuilder wynik = new StringBuilder(nazwa + "\n");
            wynik.Append("kierownik: " + kierownik + Environment.NewLine);
            wynik.Append("liczba członków zespołu: " + liczbaCzłonków + Environment.NewLine); ;
            foreach (CzłonekZespołu cz in członkowie)
                wynik.AppendLine(cz?.ToString());
            return wynik.ToString();
        }

        public bool JestCzłonkiem(string PESEL)
        {
            foreach (CzłonekZespołu cz in członkowie)
                if (cz.PESEL == PESEL)
                    return true;
            return false;
            //return członkowie.Exists(cz => cz.PESEL == PESEL);
        }


        public bool JestCzłonkiem(CzłonekZespołu członekZespołu)
        {
            foreach (CzłonekZespołu cz in członkowie)
                if (cz.Equals(członekZespołu)) return true;
            return false;
            //return członkowie.Exists(cz => cz.Equals(członekZespołu));
        }
        public void ZapiszBIN(string nazwaPliku)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(nazwaPliku, FileMode.Create))
            {
                formatter.Serialize(stream, this);
                //stream.Close();
            }
        }

        public object OdczytajBIN(string nazwaPliku)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            object wynik;
            using (Stream stream = new FileStream(nazwaPliku, FileMode.Open))
            {
                wynik = formatter.Deserialize(stream);
                //stream.Close();
            }
            return wynik;
        }

        public static void ZapiszXML(string nazwa, Zespół z)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Zespół));
            StreamWriter writer = new StreamWriter(nazwa);
            serializer.Serialize(writer, z);
            writer.Close();
        }

        public void SortujCzłonków()
        {
            //List<CzłonekZespołu> lista = new List<CzłonekZespołu>(członkowie);
            członkowie.Sort();
            //członkowie = new LinkedList<CzłonekZespołu>(lista);
        }
        public static Zespół OdczytajXML(string nazwa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Zespół));
            StreamReader reader = new StreamReader(nazwa);
            Zespół zespół = serializer.Deserialize(reader) as Zespół;
            reader.Close();
            return zespół;
        }

        public bool Equals(Zespół other)
        {
            return this.nazwa == other.nazwa && this.kierownik.Equals(other.kierownik) && this.liczbaCzłonków == other.liczbaCzłonków;
        }
    }
}
