using System;
using System.Collections.Generic;
using System.Globalization;
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
    public enum RechenZeichen
    {
        Plus,
        Minus,
        Mal,
        Geteilt,
        Gleich,

    }

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Tuple<ICalcFactor, RechenZeichen>> _zahlen = new List<Tuple<ICalcFactor, RechenZeichen>>();




        public MainWindow()
        {
            InitializeComponent();
        }
        List<decimal> zahlenErinnern = new List<decimal>();


        void MethodeZahlenTippen(decimal z)
        {
            if (_isResult)
            {
                txtDisplay.Text = string.Empty;
                _isResult = false;
            }

            txtDisplay.Text += z.ToString();
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
            _zahlen.Clear();
            GenerateHistory();

        }
        private void buttonGeteilt_Click(object sender, RoutedEventArgs e)
        {
            decimal value = decimal.Parse(txtDisplay.Text);
            Tuple<ICalcFactor, RechenZeichen> item = new Tuple<ICalcFactor, RechenZeichen>(new SimpleCalcFactor(value), RechenZeichen.Geteilt);

            _zahlen.Add(item);
            GenerateHistory();
        }

        private void GenerateHistory()
        {
            txtDisplay.Text = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (Tuple<ICalcFactor, RechenZeichen> item in _zahlen)
            {
                sb.AppendFormat(CultureInfo.CurrentCulture, "{0} ", item.Item1.ValuePresentation);
                switch (item.Item2)
                {
                    case RechenZeichen.Plus:
                        sb.Append(" + ");
                        break;
                    case RechenZeichen.Minus:
                        sb.Append(" - ");
                        break;
                    case RechenZeichen.Mal:
                        sb.Append(" * ");
                        break;
                    case RechenZeichen.Geteilt:
                        sb.Append(" / ");
                        break;
                    case RechenZeichen.Gleich:
                        sb.Append(" =");
                        break;
                    default:
                        break;
                }

            }

            txtHistory.Text = sb.ToString();

            decimal val = 0m;
            RechenZeichen? zeichen = null;
            foreach (Tuple<ICalcFactor, RechenZeichen> item in _zahlen)
            {
                if (zeichen.HasValue)
                {
                    switch (zeichen.Value)
                    {
                        case RechenZeichen.Plus:
                            val += item.Item1.Value;
                            break;
                        case RechenZeichen.Minus:
                            val -= item.Item1.Value;
                            break;
                        case RechenZeichen.Mal:
                            val *= item.Item1.Value;
                            break;
                        case RechenZeichen.Geteilt:
                            val /= item.Item1.Value;
                            break;

                    }
                }
                else
                    val = item.Item1.Value;
                zeichen = item.Item2;

            }

            txtDisplay.Text = val.ToString();
            _isResult = true;
        }

        private bool _isResult;

        private void buttonMal_Click(object sender, RoutedEventArgs e)
        {
            decimal value = decimal.Parse(txtDisplay.Text);
            Tuple<ICalcFactor, RechenZeichen> item = new Tuple<ICalcFactor, RechenZeichen>(new SimpleCalcFactor(value), RechenZeichen.Mal);

            _zahlen.Add(item);
            GenerateHistory();

        }
        private void buttonPlus_Click(object sender, RoutedEventArgs e)
        {
            decimal value = decimal.Parse(txtDisplay.Text);
            Tuple<ICalcFactor, RechenZeichen> item = new Tuple<ICalcFactor, RechenZeichen>(new SimpleCalcFactor(value), RechenZeichen.Plus);

            _zahlen.Add(item);
            GenerateHistory();


        }
        private void buttonMinus_Click(object sender, RoutedEventArgs e)
        {
            decimal value = decimal.Parse(txtDisplay.Text);
            Tuple<ICalcFactor, RechenZeichen> item = new Tuple<ICalcFactor, RechenZeichen>(new SimpleCalcFactor(value), RechenZeichen.Minus);

            _zahlen.Add(item);
            GenerateHistory();

        }

        private void buttonGleich_Click(object sender, RoutedEventArgs e)
        {
            decimal value = decimal.Parse(txtDisplay.Text);
            Tuple<ICalcFactor, RechenZeichen> item = new Tuple<ICalcFactor, RechenZeichen>(new SimpleCalcFactor(value), RechenZeichen.Gleich);

            _zahlen.Add(item);
            GenerateHistory();
            _zahlen.Clear();
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

