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

namespace Kalkulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double equal;
        bool operandPressed;
        string action;
        double PI = Math.PI;
        //private static readonly string przecinek = ",";
        //double dot = Convert.ToInt32(przecinek);
        List<string> operands;
        double f = 0;
        public MainWindow()
        {
            InitializeComponent();
            equal = .0;
            operandPressed = false;
            action = "";
            operands = new List<string>();
            string[] tmp = { "+", "-", "×", "÷", "=", "x²", "%", "(", ")", "e", "log", "mod", "exp", "✓", "π" };
            operands.AddRange(tmp.ToList());
        }

        private void btnnumber_Click(object sender, RoutedEventArgs e)
        {
            var data = ((Button)sender).Content.ToString();
            if (operandPressed && !operands.Contains(data))
            {
                f = Convert.ToDouble(ekran.Text);
                operandPressed = false;
                ekran.Text = data;
                return;
            }
            if (operands.Contains(data))
            {
                switch (action)
                {
                    case "+": equal += f; break;
                    case "-": equal -= f; break;
                    case "×": equal *= Convert.ToDouble(ekran.Text); break;
                    case "÷": equal /= Convert.ToDouble(ekran.Text); break;
                    case "xª": equal *= Convert.ToDouble(ekran.Text); break;
                    case "%": equal *= (Convert.ToDouble(ekran.Text) * 0.01); break;
                    case ",": equal = Convert.ToDouble(ekran.Text);
                        //if (dot == true)
                        //{
                            
                        //}
                        break;
                    case "mod": equal = Convert.ToDouble(ekran.Text); break;
                    case "✓": equal = Math.Sqrt(Convert.ToDouble(ekran.Text)); break;
                    default: equal = Convert.ToDouble(ekran.Text); break;
                }
                if (data != "=") action = data;

                ekran.Text = equal.ToString(); 
                
                operandPressed = true;
            }
            else
            {
                ekran.Text += data.ToString();
            }
        }

        ///

        private void OK_Button_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.C)
            {
                ((Button)sender).Content = "WITAJ";
            }
            if (e.Key == Key.D)
            {
                ((Button)sender).Content = "ŻEGNAJ";
            }
        }

        ///

        private void Ten_x_Click(object sender, RoutedEventArgs e)
        {
            string d = ekran.Text.ToString();
            int n2 = Convert.ToInt32(d);
            double x = 0;

            if (((Button)sender).Content.ToString() == "10x")
            {
                x = Math.Pow(10, n2);
            }
            else
            {
                x = Math.Pow(n2, 2);
            }
            ekran.Text = x.ToString();
        }

        ///

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ekran.Text = "";
            action = "";
            operandPressed = false;
            equal = .0;
            f = 0;
        }

        ///

        private void etykieta1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (ekran.Text)
        }

        ///

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            double log = 0;
            string d = ekran.Text.ToString();
            if (((Button)sender).Content == "log")
            {
                log = Math.Log(Convert.ToDouble(d));
            }
            else
            {
                log = Math.Log10(Convert.ToDouble(d));
            }
            ekran.Text = log.ToString();
        }

        ///

        private void Mod_Click(object sender, RoutedEventArgs e)
        {
            //double mod = 0;
        }

        ///

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            //string d = ekran.Text.ToString();
            //int n2 = Convert.ToInt32(d);
            //double x = 0;

            //if (((Button)sender).Content.ToString() == "exp")
            //{
            //    x = Math.Pow(10, n2);
            //}
            //ekran.Text = x.ToString();
        }

        ///

        private void Tan_Click(object sender, RoutedEventArgs e)
        {
            string d = ekran.Text.ToString();
            double p = Convert.ToDouble(d) * (PI / 180);
            double p1 = Math.Tan(p);
            ekran.Text = p1.ToString();
        }

        ///

        private void Sin_Click(object sender, RoutedEventArgs e)
        {
            string d = ekran.Text.ToString();
            double p = Convert.ToDouble(d) * (PI / 180);
            double p1 = Math.Sin(p);
            ekran.Text = p1.ToString();
        }

        ///

        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            string d = ekran.Text.ToString();
            double p = Convert.ToDouble(d) * (PI / 180);
            double p1 = Math.Cos(p);
            ekran.Text = p1.ToString();
        }

        ///

        private void X1_Click(object sender, RoutedEventArgs e)
        {
            string d = ekran.Text.ToString();
            double p = Convert.ToDouble(d);
            double p1 = 1 / p;
            ekran.Text = p1.ToString();
        }

        ///

        private void XY_Click(object sender, RoutedEventArgs e)
        {
            string d = ekran.Text.ToString();
            string d1 = ekran.Text.ToString();
            double p = Convert.ToDouble(d);
            double p1 = Convert.ToDouble(d1);
        }

        ///

        private void Nawias_Click(object sender, RoutedEventArgs e)
        {
            ekran.Text += ((Button)sender).Content;
        }

        ///

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            string d = ekran.Text.ToString();
            if (ekran.Text != "")
            {
                string Return = d.Substring(0, d.Length - 1);
                ekran.Text = Return;
            }
        }

        ///

        private void E_Click(object sender, RoutedEventArgs e)
        {
            double _E = Math.E;
            string d = ekran.Text.ToString();
            char k = d[d.Length - 1];
            if (k == '+' || k == '-' || k == '*' || k == '/')
            {
                d += _E.ToString();
                ekran.Text = d;
            }
            else
            {
                ekran.Text = _E.ToString();
            }
        }

        ///

        private void PI_Click(object sender, RoutedEventArgs e)
        {
            string d = ekran.Text.ToString();
            char k = d[d.Length - 1];
            if (k == '+' || k == '-' || k == '*' || k == '/')
            {
                d += PI.ToString();
                ekran.Text = d;
            }
            else
            {
                ekran.Text = PI.ToString();
            }
        }
    }
}