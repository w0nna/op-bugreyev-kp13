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
        string pathDel = @"C:\Users\1wni Work\Desktop\op-bugreyev-kp13\lab02\DelIcoICOn.jpg";
        TextBlock PoleCalc = new TextBlock();
        public Window2()
        {
            InitializeComponent();
            InitControls();


        }

        private void InitControls()
        {
            this.ResizeMode = ResizeMode.CanResize;
            this.Width = 550;
            this.Height = 648;
            this.Title = "Calculator";

            Brush Gradient = new LinearGradientBrush(Color.FromRgb(255, 255, 255), Color.FromRgb(225, 225, 225), 35);
            this.Background = Gradient;

            Grid Gridw2 = new Grid();
            Gridw2.Height = 624;
            Gridw2.Width = 550;
            Gridw2.HorizontalAlignment = HorizontalAlignment.Center;
            Gridw2.VerticalAlignment = VerticalAlignment.Center;

            Button[,] btns = new Button[4,4];
            RowDefinition[] row = new RowDefinition[5];
            ColumnDefinition[] columns = new ColumnDefinition[4];



            for (int i = 0; i < 5; i++)
            {
                row[i] = new RowDefinition();
                Gridw2.RowDefinitions.Add(row[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                columns[i] = new ColumnDefinition();
                Gridw2.ColumnDefinitions.Add(columns[i]);
            }

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j <4; j++)
                {
                    btns[i,j] = new Button();
                    switch (i)
                    {
                        case 1:
                            switch (j)
                            {
                                case 0:
                                    btns[i, j].Content = "Назад";
                                    btns[i, j].Click += GoToMainMenu_Click;
                                    Grid.SetRow(btns[i,j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 1:
                                    btns[i, j].Content = "=";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(255,214,180));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 2:
                                    btns[i, j].Content = "C";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 3:
                                    btns[i, j].Content = "";
                                    btns[i, j].Background =  new ImageBrush(new BitmapImage(new Uri(pathDel)));
                                    btns[i, j].Click += Del_Click;
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;

                            }
                            break;
                        case 2:
                            switch (j)
                            {
                                case 0:
                                    btns[i, j].Content = "7";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 1:
                                    btns[i, j].Content = "8";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 2:
                                    btns[i, j].Content = "9";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 3:
                                    btns[i, j].Content = "/";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 247, 219));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;

                            }
                            break;
                        case 3:
                            switch (j)
                            {
                                case 0:
                                    btns[i, j].Content = "4";
                                    btns[i, j].Click += Button_Click;
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 1:
                                    btns[i, j].Content = "5";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 2:
                                    btns[i, j].Content = "6";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 3:
                                    btns[i, j].Content = "*";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 247, 219));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;

                            }
                            break;
                        case 4:
                            switch (j)
                            {
                                case 0:
                                    btns[i, j].Content = "1";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 1:
                                    btns[i, j].Content = "2";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 214, 180));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 2:
                                    btns[i, j].Content = "3";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;
                                case 3:
                                    btns[i, j].Content = "-";
                                    btns[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 247, 219));
                                    btns[i, j].Click += Button_Click;
                                    Grid.SetRow(btns[i, j], i);
                                    Grid.SetColumn(btns[i, j], j);
                                    Gridw2.Children.Add(btns[i, j]);
                                    break;

                            }
                            break;
                    }



                }
            }


            PoleCalc.Background = new SolidColorBrush(Colors.White);
            PoleCalc.VerticalAlignment = VerticalAlignment.Bottom;
            PoleCalc.HorizontalAlignment = HorizontalAlignment.Left;
            PoleCalc.Foreground = new SolidColorBrush(Colors.Black);
            PoleCalc.Height = 104;
            PoleCalc.FontSize = 80;
            PoleCalc.FontFamily = new FontFamily("Bahnschrift Condensed");
            PoleCalc.Visibility = Visibility.Visible;
            Grid.SetRow(PoleCalc, 0);
            Grid.SetRowSpan(PoleCalc, 1);
            Grid.SetColumn(PoleCalc, 0);
            Grid.SetColumnSpan(PoleCalc, 4);
            Gridw2.Children.Add(PoleCalc);

            Button nul = new Button();
            nul.Content = "0";
            nul.Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
            nul.Click += Button_Click;
            Grid.SetRow(nul, 4);
            Grid.SetColumn(nul, 1);
            Gridw2.Children.Add(nul);

            Button plus = new Button();
            plus.Content = "+";
            plus.Background = new SolidColorBrush(Color.FromRgb(255, 247, 219));
            plus.Click += Button_Click;
            Grid.SetRow(plus, 4);
            Grid.SetColumn(plus, 3);
            Gridw2.Children.Add(plus);



            this.Content = Gridw2;
            this.Show();
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
