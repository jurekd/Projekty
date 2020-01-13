using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Projekty
{
    [Serializable]
    public class Osoba : IEquatable<Osoba>, IComparable<Osoba>
    {
        public enum Płcie { K, M }
        private string imie;
        private string nazwisko;
        private DateTime dataUrodzenia;
        private string pesel;
        private Płcie plec;

        #region właściwości
        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        public string PESEL {
            get => pesel;
            set 
            {
                if (SprawdźPESEL(value))
                    pesel = value;
                else
                    throw new WrongPESELException();
            }
        }
        public Płcie Plec { get => plec; set => plec = value; }
        #endregion

        public Osoba()
        {
            imie = "";
            nazwisko = "";
            dataUrodzenia = DateTime.Now;
            PESEL = new string('0', 11);
        }

        public Osoba(string imie, string nazwisko):this()
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public Osoba(string imie, string nazwisko, DateTime dataUrodzenia, string pESEL, Płcie plec) : this(imie, nazwisko)
        {
            this.dataUrodzenia = dataUrodzenia;
            PESEL = pESEL;
            this.plec = plec;
        }

        public Osoba(string imie, string nazwisko, string dataUrodzenia, string pESEL, Płcie plec) : this(imie, nazwisko, new DateTime(), pESEL, plec)
        {
            DateTime data;
            if (DateTime.TryParse(dataUrodzenia, out data))
                this.dataUrodzenia = data;
            else
                this.dataUrodzenia = new DateTime();
        }

        public int Wiek()
        {
            return (DateTime.Now.Year - dataUrodzenia.Year);
        }

        private bool SprawdźPESEL(string PESEL)
        {
            if (Regex.IsMatch(PESEL, @"^\d{11}$"))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return this.imie + " " + this.nazwisko + " " + this.PESEL +" "+this.plec;
        }

        //public override bool Equals(object other)
        //{
        //    if (!(other is Osoba)) return false;
        //    return this.pesel == ((Osoba)other).pesel;
        //}

        public bool Equals(Osoba other)
        {
            return this.pesel == other.pesel;
        }

        public int CompareTo(Osoba other)
        {
            if (nazwisko != other.nazwisko)
                return nazwisko.CompareTo(other.nazwisko);
            else
                return imie.CompareTo(other.imie);
        }
    }
}
