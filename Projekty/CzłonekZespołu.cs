using System;
using System.Collections.Generic;
using System.Text;

namespace Projekty
{
    [Serializable]
    public class CzłonekZespołu : Osoba
    {
        private string funkcja;

        public CzłonekZespołu()
        { }

        public CzłonekZespołu(string imie, string nazwisko) : base(imie, nazwisko)
        {
        }
        public CzłonekZespołu(string imie, string nazwisko, string pesel) : base(imie, nazwisko)
        {
            this.PESEL = pesel;
        }

        public CzłonekZespołu(string imie, string nazwisko, DateTime dataUrodzenia, string pESEL, Płcie plec, string funkcja) : base(imie, nazwisko, dataUrodzenia, pESEL, plec)
        {
            this.funkcja = funkcja;
        }

        public string Funkcja { get => funkcja; set => funkcja = value; }

        public override string ToString()
        {
            return base.ToString()+" "+this.funkcja;
        }


    }
}
