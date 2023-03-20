using System;
using System.Collections.Generic;
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
using System.IO;

namespace WpfAppKivetelKezeles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool SzamokHelyesekE()
        {
            double aSzam = 0;
            try
            {
                aSzam = Convert.ToDouble(txtInputA.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Nem jó a számformátum!");
                txtInputA.Text = "";
                txtInputA.Focus();
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Túl nagy vagy túl kicsi a szám!");
                txtInputA.Text = "";
                txtInputA.Focus();
                return false;
            }
            double bSzam = 0;
            try
            {
                bSzam = Convert.ToDouble(txtInputB.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Nem jó a számformátum!");
                txtInputB.Text = "";
                txtInputB.Focus();
                return false;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Túl nagy vagy túl kicsi a szám!");
                txtInputB.Text = "";
                txtInputB.Focus();
                return false;
            }
            return true;
        }

        private void btnOsztás_Click(object sender, RoutedEventArgs e)
        {
            if (SzamokHelyesekE())
            {
                double aSzam = Convert.ToDouble(txtInputA.Text);
                double bSzam = Convert.ToDouble(txtInputB.Text);
                if (bSzam == 0)
                {
                    MessageBox.Show("0-val nem lehet osztani!");
                }
                else
                {
                    lblEredmeny.Content = Math.Round(aSzam / bSzam, 4);
                }
            }
        }

        private void btnOsszead_Click(object sender, RoutedEventArgs e)
        {
            if (SzamokHelyesekE())
            {
                double aSzam = Convert.ToDouble(txtInputA.Text);
                double bSzam = Convert.ToDouble(txtInputB.Text);
                lblEredmeny.Content = Math.Round(aSzam + bSzam, 4);
            }
        }

        private void btnKivon_Click(object sender, RoutedEventArgs e)
        {
            if (SzamokHelyesekE())
            {
                double aSzam = Convert.ToDouble(txtInputA.Text);
                double bSzam = Convert.ToDouble(txtInputB.Text);
                lblEredmeny.Content = Math.Round(aSzam - bSzam, 4);
            }

        }

        private void btnSzoroz_Click(object sender, RoutedEventArgs e)
        {
            if (SzamokHelyesekE())
            {
                double aSzam = Convert.ToDouble(txtInputA.Text);
                double bSzam = Convert.ToDouble(txtInputB.Text);
                lblEredmeny.Content = Math.Round(aSzam * bSzam, 4);
            }
        }

        private void btnBetolt_Click(object sender, RoutedEventArgs e)
        {
            StreamReader fájlOlvasás;
            try
            {
                fájlOlvasás = new StreamReader(txtFileName.Text);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Nncs ilyen fájl!");
                txtFileName.Text = "";
                txtFileName.Focus();
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Egyéb I/O hiba!");
                txtFileName.Text = "";
                txtFileName.Focus();
                return;
            }
            while (!fájlOlvasás.EndOfStream)
            {
                string sor = fájlOlvasás.ReadLine();
                lbFileList.Items.Add(sor);
            }
            fájlOlvasás.Close();
        }
    }
}