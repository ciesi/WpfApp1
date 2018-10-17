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


        decimal x;
        decimal y = 0;
        string textMessage;
        //string anzeige;


        enum RechenZeichen
        {
            Plus,
            Minus,
            Mal,
            Geteilt,
            keinInput,
            Clear
        }
        RechenZeichen click = RechenZeichen.keinInput;

        public MainWindow()
        {
            InitializeComponent();
        }
        // List<int> zahlenAufzählen = new List<int>();


        void MethodeZahlenTippen(decimal z)
        {
            //List<int> zahlenAufzählen = new List<int>();
            //txtDisplay.Text = z.ToString();
            x = x * 10 + z;
            txtDisplay.Text = x.ToString();
            //txtDisplay.Text = txtDisplay.Text + z.ToString();
            //x = Convert.ToDecimal(txtDisplay);
          ///////////////////////////////////////////////////////Zahl
        }
        private void button0_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(0);
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(1);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(2);
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(3);

        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(4);
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(5);
        }
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(6);
        }
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(7);
        }
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(8);
        }
        private void button9_Click(object sender, RoutedEventArgs e)
        {
            MethodeZahlenTippen(9);
        }

        //////////////////////////////////////////////// RechnenButton
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            click = RechenZeichen.Clear;
            y = 0;
            x = 0;
            txtDisplay.Text = "";
            txtHistory.Text = "";
        }
        private void buttonGeteilt_Click(object sender, RoutedEventArgs e)
        {
            click = RechenZeichen.Geteilt;
            y = x;
            x = 0;
            txtHistory.Text = y.ToString() + " / ";
            //txtHistory.Text = textMessage;
        }
        private void buttonMal_Click(object sender, RoutedEventArgs e)
        {
            click = RechenZeichen.Mal;
            y = x;
            x = 0;
            txtHistory.Text = y.ToString() + " * ";
            //txtHistory.Text = textMessage;
        }
        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            click = RechenZeichen.Plus;
            y = x;
            x = 0;
            txtHistory.Text = y.ToString() + " + ";
            //txtHistory.Text = textMessage;
        }
        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            click = RechenZeichen.Minus;
            y = x;
            x = 0;
            txtHistory.Text = y.ToString() + " - ";
            //txtHistory.Text = textMessage;
        }

        private void buttonGleich_Click(object sender, RoutedEventArgs e)
        {
            // textMessage = y.ToString() + click + x.ToString();
            switch (click)
            {
                case RechenZeichen.Plus:
                    textMessage = y.ToString() + " + " + x.ToString() + " =";
                    x = y + x;
                    break;
                case RechenZeichen.Minus:
                    textMessage = y.ToString() + " - " + x.ToString() + " =";
                    x = y - x;
                    break;
                case RechenZeichen.Mal:
                    textMessage = y.ToString() + " * " + x.ToString() + " =";
                    x = y * x;
                    break;
                case RechenZeichen.Geteilt:
                    textMessage = y.ToString() + " / " + x.ToString() + " =";
                    x = y / x;
                    break;
                case RechenZeichen.keinInput:
                    break;
            }
            txtZahl1.Text = x.ToString();
            txtHistory.Text = textMessage;
            txtDisplay.Text = "";

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void txtDisplay_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

