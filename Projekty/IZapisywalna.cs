using System;
using System.Collections.Generic;
using System.Text;

namespace Projekty
{
    interface IZapisywalna
    {
        void ZapiszBIN(string nazwaPliku);
        object OdczytajBIN(string nazwaPliku);
    }
}
