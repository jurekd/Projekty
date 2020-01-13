using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projekty;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWIndow.xaml
    /// </summary>
    public partial class OsobaWIndow : Window
    {
        Osoba osoba;
        public OsobaWIndow()
        {
            InitializeComponent();
        }

        public OsobaWIndow(Osoba osoba) : this()
        {
            this.osoba = osoba;
            if (osoba!=null)
            {
                textBox_PESEL.Text = osoba.PESEL;
                textBox_Imie.Text = osoba.Imie;
                textBox_Nazwisko.Text = osoba.Nazwisko;
                textBox_DataUr.Text = osoba.DataUrodzenia.ToShortDateString();
                if ((osoba.Plec) == Osoba.Płcie.K)
                    comboBox_plec.Text = "kobieta";
                else
                    comboBox_plec.Text = "mężczyzna";

            }
        }

        private void button_Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_PESEL.Text == "" || textBox_Imie.Text == "" || textBox_Nazwisko.Text == "")
            {
                MessageBox.Show("Złe dane!!!");
                return;
            }
            this.osoba.PESEL = textBox_PESEL.Text;
            this.osoba.Imie = textBox_Imie.Text;
            this.osoba.Nazwisko = textBox_Nazwisko.Text;
            DateTime date;
            DateTime.TryParseExact(textBox_DataUr.Text, new[] { "yyyy-MM-dd", "yyyy/MM/dd",
"MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out date);
            this.osoba.DataUrodzenia = date;
            if (comboBox_plec.Text == "kobieta")
                this.osoba.Plec = Osoba.Płcie.K;
            else
                this.osoba.Plec = Osoba.Płcie.M;
            this.Close();
        }
    }
}
