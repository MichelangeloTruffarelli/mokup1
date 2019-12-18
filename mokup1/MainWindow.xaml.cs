using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mokup1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string file_name = "mokup.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nome = TxtNome.Text;
            string cognome = TxtCognome.Text;
            string data = dtpCompleanno.SelectedDate.ToString();
            if (nome == "" || cognome == "")
            {
                MessageBox.Show($"Error! Insert name and surname.");
            }
            else
            {
                MessageBox.Show($"Hi {nome} {cognome}");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            btnprint.IsEnabled = true;
        }

        private void btnprint_Click(object sender, RoutedEventArgs e)
        {
            string nome = TxtNome.Text;
            string cognome = TxtCognome.Text;
            string data = dtpCompleanno.SelectedDate.ToString();
            try
            {
                using (StreamWriter w = new StreamWriter(file_name, true))
                {
                    w.WriteLine($"{nome} {cognome} {data}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
