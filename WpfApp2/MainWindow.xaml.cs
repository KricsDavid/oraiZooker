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
using WpfAppSnooker;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Versenyzo> versenyzokListaja;
        public MainWindow()
        {
            InitializeComponent();
            versenyzokListaja = LoadFromCSV("snooker.txt");
            dgTablazat.ItemsSource = versenyzokListaja;
            cbOrszag.ItemsSource = versenyzokListaja.Select(x => x.Orszag).Distinct().OrderBy(x => x);
            cbOrszag.SelectedIndex = 0;

        }

        private List<Versenyzo>? LoadFromCSV(string filename)
        {
            var newList = new List<Versenyzo>();
            foreach (var CSV_line in File.ReadAllLines(filename).Skip(1))
            {
                newList.Add(new Versenyzo(CSV_line));
            }
            return newList;
        }

        private void btnF3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A világranglistán" + versenyzokListaja.Count() + "db versenyző szerepel.");
        }

        private void btnF4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Átlagos bevétel: " + Math.Round(versenyzokListaja.Average(x => x.Nyeremeny),2));
        }

        private void btnF5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A legjobban kereső kínai játékos: " );
        }

        private void btnF6_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }

    
}
