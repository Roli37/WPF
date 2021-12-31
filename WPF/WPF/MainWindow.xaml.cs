using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using static WPF.Models.MainWindowViewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Figyelmeztet _figyelmeztet = new Figyelmeztet();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_megjelenit_Click(object sender, RoutedEventArgs e)
        {
            Megjelenit(AllData(OpenConnection()));
        }

        private void btn_exportal_Click(object sender, RoutedEventArgs e)
        {
            Exportal(AllData(OpenConnection()));
            Warning();
        }

        private void btn_szures_Click(object sender, RoutedEventArgs e)
        {
            Megjelenit(FilteredData());
        }

        private void btn_ujadat_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow secondWindow = new SecondWindow();
            secondWindow.Show();
        }
        public void Megjelenit(List<Adat> data)
        {
            dataGrid1.ItemsSource = data;
            dataGrid1.Visibility = Visibility.Visible;
        }
        public void Warning()
        {
            _figyelmeztet.Str = "Karbantartások exportálása (A fájl felül lett írva)";
            btn_exportal.Content = _figyelmeztet.Str;
        }
        public List<Adat> FilteredData()
        {
            List<Adat> lista = new List<Adat>();
            if (tb_nev.Text == "" || tb_ar.Text == "")
            {
                string message = "Írj be egy szerelő nevet és egy árat!";
                string title = "Warning";
                System.Windows.MessageBox.Show(message, title);
                return lista;
            }
            string nev = tb_nev.Text;
            int ar = int.Parse(tb_ar.Text);
            lista = FilterData(AllData(OpenConnection()), nev, ar);
            return lista;
        }
        public class Figyelmeztet : INotifyPropertyChanged
        {
            private string str;
            public string Str
            {
                get { return str; }
                set
                {
                    str = value;
                    OnPropertyChanged("Str");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;


            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

    }
}
