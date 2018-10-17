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


namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double zahl1 = 0;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void numbers_Only(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

        }

        private void btnClick1(object sender, RoutedEventArgs e)
        {
            displayAnzeigen("1");
        }
        private void btnClick2(object sender, RoutedEventArgs e)
        {
            displayAnzeigen("2");
        }
        private void btnClick3(object sender, RoutedEventArgs e)
        {
            displayAnzeigen("3");
        }

        public void displayAnzeigen(string z)
        {
            z = txtDisplay.Text + z;
            txtDisplay.Text = z;
         
        }
        //public void ops(string op)
        //{
        //    op =
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private double btn_plus(object sender, RoutedEventArgs e)
        {
            
            txtHistory.Text = txtHistory.Text + txtDisplay.Text + "+";
            zahl1 = double.Parse(txtDisplay.Text) + zahl1;
            txtDisplay.Text = "";
            txtZahl1.Text = Convert.ToString(zahl1);
            Convert.ToDouble(zahl1);
            return zahl1;
            
        }

        private double btn_minus(object sender, RoutedEventArgs e)
        {
            txtHistory.Text = txtHistory.Text + txtDisplay.Text + "-";
            zahl1 = double.Parse(txtDisplay.Text) - zahl1;
            txtDisplay.Text = "";
            txtZahl1.Text = Convert.ToString(zahl1);
            Convert.ToDouble(zahl1);
            return zahl1;
        }

        private void btn_gleich(object sender, RoutedEventArgs e)
        {

        }
    }


    }

