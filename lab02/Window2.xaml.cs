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
using System.Windows.Shapes;
using System.Data;

namespace lab01
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public static bool DelIsClicked;
        public Window2()
        {
            InitializeComponent();

            foreach(UIElement el in RootW2.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
               
            }
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if(PoleCalc.Text.Length == 0)
            {
                DelIsClicked = false;
            }
            else
            {
                DelIsClicked = true;
            }


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool HaveSymAtStart = false;
            string BtnText = (string)((Button)(e.OriginalSource)).Content;

            if (BtnText == "C")
            {
                PoleCalc.Text = "";
            }
            else if(BtnText == "=")
            {
                string ValCalc = new DataTable().Compute(PoleCalc.Text, null).ToString();
                PoleCalc.Text = ValCalc;
            }
            else if(DelIsClicked == true)
            {
                if (PoleCalc.Text.Length <= 0)
                {
                    PoleCalc.Text = "";
                    DelIsClicked=false;
                }
                else
                {
                    do
                    {
                        PoleCalc.Text = PoleCalc.Text.Remove(PoleCalc.Text.Length - 1);
                        DelIsClicked = false;
                    }
                    while (DelIsClicked == true);
                    
                }
                

            }
            else
            {
                PoleCalc.Text += BtnText;
            }
            if(PoleCalc.Text.Length == 1)
            {
                HaveSymAtStart = StringSymbolsStart(BtnText, HaveSymAtStart);
                if (HaveSymAtStart == true)
                {
                    PoleCalc.Text = "";
                    HaveSymAtStart = false; 
                }
                
            }
           


        }
        private bool StringSymbolsStart(string BtnText, bool HaveSymAtStart)
        {
 
                if (BtnText == "/")
                {
                    MessageBox.Show("Спочатку введи цифри!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    HaveSymAtStart = true;
                }
                else if (BtnText == "-")
                {
                    MessageBox.Show("Спочатку введи цифри!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    HaveSymAtStart = true;
                }
                else if (BtnText == "+")
                {
                    MessageBox.Show("Спочатку введи цифри!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    HaveSymAtStart = true;
                }
                else if (BtnText == "*")
                {
                    MessageBox.Show("Спочатку введи цифри!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    HaveSymAtStart = true;
                }

            return HaveSymAtStart;
            
        }
        private void GoToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }


    }
}
