using System.Collections.ObjectModel;
using System.Windows;
using Projekty;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zespół zespół;
        ObservableCollection<CzłonekZespołu> lista;


        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listbox_czlonkowie.SelectedIndex;
            lista.RemoveAt(zaznaczony);
            zespół.członkowie.RemoveAt(zaznaczony);
        }

        private void button_zmien_Click(object sender, RoutedEventArgs e)
        {
            OsobaWIndow okno = new OsobaWIndow(zespół.Kierownik);   
            okno.ShowDialog();
            textBox_kierownik.Text = zespół.Kierownik.ToString();
        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                bool? result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                zespół = Zespół.OdczytajXML(filename);
                //zespół = new Zespół("Ala ma kota",null);

                textBox_nazwa.Text = zespół.Nazwa;
                textBox_kierownik.Text = zespół.Kierownik.ToString();
                lista = lista = new ObservableCollection<CzłonekZespołu>(zespół.członkowie);
                listbox_czlonkowie.ItemsSource = lista;
            }

        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
