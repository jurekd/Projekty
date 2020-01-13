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
            zespół = Zespół.OdczytajXML("zespol.xml");
            //zespół = new Zespół("Ala ma kota",null);
           
            textBox_nazwa.Text = zespół.Nazwa;
            textBox_kierownik.Text = zespół.Kierownik.ToString();
            lista = lista = new ObservableCollection<CzłonekZespołu>(zespół.członkowie);
            listbox_czlonkowie.ItemsSource = lista;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = listbox_czlonkowie.SelectedIndex;
            //lista.RemoveAt(zaznaczony);
            zespół.członkowie.RemoveAt(zaznaczony);
        }
    }
}
