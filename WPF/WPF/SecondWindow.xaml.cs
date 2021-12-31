using System;
using System.Collections.Generic;
using System.Windows;
using static WPF.Models.SecondWindowViewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
            ComboBoxes(Szerelonevek(OpenConnection()), Megrendelonevek(OpenConnection()), Szamok());
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Insert();
        }
        public void Insert()
        {
            string szerelonev = cb1.SelectedItem.ToString();
            string megrendelonev = cb2.SelectedItem.ToString();
            DateTime date = calendar1.SelectedDate.Value;
            int javido = int.Parse(cb3.SelectedItem.ToString());
            Command(OpenConnection(), szerelonev, megrendelonev, date, javido);
        }
        public void ComboBoxes(List<string> szerelonevek, List<string> megrendelonevek, List<int> szamok)
        {
            cb1.ItemsSource = szerelonevek;
            cb2.ItemsSource = megrendelonevek;
            cb3.ItemsSource = szamok;
        }

    }
}
