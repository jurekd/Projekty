using System;
using System.Collections.Generic;
using System.Text;

namespace Projekty
{
    [Serializable]
    public class KierownikZespołu:Osoba
    {
        int doświadczenie;

        public KierownikZespołu()
        {
        }

        public KierownikZespołu(string imie, string nazwisko, DateTime dataUrodzenia, string pESEL, Płcie plec, int doświadczenie) : base(imie, nazwisko, dataUrodzenia, pESEL, plec)
        {
            this.doświadczenie = doświadczenie;
        }

        public int Doświadczenie { get => doświadczenie; set => doświadczenie = value; }

    }
}
