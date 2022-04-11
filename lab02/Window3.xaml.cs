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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public int i = 1;
        public bool XodKrestika;
        public int[,] pole = new int[6, 6];
        string pathKrest = @"C:\Users\1wni Work\Desktop\op-bugreyev-kp13\lab02\krest.png";
        string pathNull = @"C:\Users\1wni Work\Desktop\op-bugreyev-kp13\lab02\nol.png";
        public bool PobedilKrestik;
        public bool UsersRestart;
        int bt = 0;


        public Window3()
        {
            InitializeComponent();
            InitControls();

        }
        public void InitControls()
        {
            this.ResizeMode = ResizeMode.CanResize;
            this.Width = 700;
            this.Height = 600;
            this.Title = "X O";

            Brush Gradient = new LinearGradientBrush(Color.FromRgb(255, 255, 255), Color.FromRgb(225, 225, 225), 35);
            this.Background = Gradient;
        
            Grid Gridw3 = new Grid();
            Gridw3.Height = 600;
            Gridw3.Width = 700;
            Gridw3.HorizontalAlignment = HorizontalAlignment.Center;
            Gridw3.VerticalAlignment = VerticalAlignment.Center;


            Button Back = new Button();
            bt = ForButtonMain(Back, bt);
            Back.Click += GoBack_Click;
            Gridw3.Children.Add(Back);
            Grid.SetRow(Back, 1);
            Grid.SetColumn(Back, 8);
            Back.HorizontalAlignment = HorizontalAlignment.Center;


            Button Res = new Button();
            bt = ForButtonMain(Res, bt);
            Res.Click += Restart_byUser;
            Gridw3.Children.Add(Res);
            Grid.SetRow(Res, 4);
            Grid.SetColumn(Res, 8);
            Res.HorizontalAlignment = HorizontalAlignment.Center;



            Button[,] btns = new Button[10, 10];
            RowDefinition[] row = new RowDefinition[10];
            ColumnDefinition[] columns = new ColumnDefinition[10];

            for (int i = 0; i < 10; i++)
            {
                row[i] = new RowDefinition();
                Gridw3.RowDefinitions.Add(row[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                columns[i] = new ColumnDefinition();
                Gridw3.ColumnDefinitions.Add(columns[i]);
            }

            for (int k = 0; k < 6; k++)
            {
                for (int l = 0; l < 6; l++)
                {
                    btns[k, l] = new Button();
                    btns[k, l].Background = new SolidColorBrush(Colors.LightYellow);
                    Grid.SetRow(btns[k, l], k+1);
                    Grid.SetColumn(btns[k, l],l+1);
                    switch (k)
                    {
                        case 0:
                            switch (l)
                            {
                                case 0: 
                                    btns[k, l].Click += bO_O;
                                    break;
                                case 1:
                                    btns[k, l].Click += bO_1;
                                    break;
                                case 2:
                                    btns[k, l].Click += bO_2;
                                    break;
                                case 3:
                                    btns[k, l].Click += bO_3;
                                    break;
                                case 4:
                                    btns[k, l].Click += bO_4;
                                    break;
                                case 5:
                                    btns[k, l].Click += bO_5;
                                    break;
                            }
                            break;
                        case 1:
                            switch (l)
                            {
                                case 0:
                                    btns[k, l].Click += b1_O;
                                    break;
                                case 1:
                                    btns[k, l].Click += b1_1;
                                    break;
                                case 2:
                                    btns[k, l].Click += b1_2;
                                    break;
                                case 3:
                                    btns[k, l].Click += b1_3;
                                    break;
                                case 4:
                                    btns[k, l].Click += b1_4;
                                    break;
                                case 5:
                                    btns[k, l].Click += b1_5;
                                    break;
                            }
                            break;
                        case 2:
                            switch (l)
                            {
                                case 0:
                                    btns[k, l].Click += b2_O;
                                    break;
                                case 1:
                                    btns[k, l].Click += b2_1;
                                    break;
                                case 2:
                                    btns[k, l].Click += b2_2;
                                    break;
                                case 3:
                                    btns[k, l].Click += b2_3;
                                    break;
                                case 4:
                                    btns[k, l].Click += b2_4;
                                    break;
                                case 5:
                                    btns[k, l].Click += b2_5;
                                    break;
                            }
                            break;
                        case 3:
                            switch (l)
                            {
                                case 0:
                                    btns[k, l].Click += b3_O;
                                    break;
                                case 1:
                                    btns[k, l].Click += b3_1;
                                    break;
                                case 2:
                                    btns[k, l].Click += b3_2;
                                    break;
                                case 3:
                                    btns[k, l].Click += b3_3;
                                    break;
                                case 4:
                                    btns[k, l].Click += b3_4;
                                    break;
                                case 5:
                                    btns[k, l].Click += b3_5;
                                    break;
                            }
                            break;
                        case 4:
                            switch (l)
                            {
                                case 0:
                                    btns[k, l].Click += b4_O;
                                    break;
                                case 1:
                                    btns[k, l].Click += b4_1;
                                    break;
                                case 2:
                                    btns[k, l].Click += b4_2;
                                    break;
                                case 3:
                                    btns[k, l].Click += b4_3;
                                    break;
                                case 4:
                                    btns[k, l].Click += b4_4;
                                    break;
                                case 5:
                                    btns[k, l].Click += b4_5;
                                    break;
                            }
                            break;
                        case 5:
                            switch (l)
                            {
                                case 0:
                                    btns[k, l].Click += b5_O;
                                    break;
                                case 1:
                                    btns[k, l].Click += b5_1;
                                    break;
                                case 2:
                                    btns[k, l].Click += b5_2;
                                    break;
                                case 3:
                                    btns[k, l].Click += b5_3;
                                    break;
                                case 4:
                                    btns[k, l].Click += b5_4;
                                    break;
                                case 5:
                                    btns[k, l].Click += b5_5;
                                    break;
                            }
                            break;
                    }
                    Gridw3.Children.Add(btns[k, l]);
                }
            }

            this.Content = Gridw3;
            this.Show();
        }
        public bool CheyXod(int i)
        {
            int DelI = i % 2;

            if (DelI == 0)
            {
                XodKrestika = false;
            }
            else
            {
                XodKrestika = true;
            }
            return XodKrestika;
        }
        public int PlusState(int i)
        {
            i++;

            //Не четное - крестик MatrixUpdate 1
            //Четное - нолик  MatrixUpdate 2

            return i;
        }
        private int ForButtonMain(Button Btn, int bt)
        {
            Btn.Background = new SolidColorBrush(Colors.White);
            Btn.Background.Opacity = 0;
            Btn.Foreground = new SolidColorBrush(Colors.Black);
            Btn.BorderBrush = new SolidColorBrush(Color.FromRgb(132, 43, 154));
            Btn.Height = 30;
            Btn.Width = 55;
            Btn.FontSize = 10;
            Btn.FontFamily = new FontFamily("Bahnschrift Condense");
            Btn.FontWeight = FontWeights.Bold;
            Btn.VerticalAlignment = VerticalAlignment.Center;

            switch (bt)
            {
                case 0:
                    Btn.Content = "НАЗАД";
                    bt++;
                    break;
                case 1:
                    Btn.Content = "RESET";
                    break;
              
            }


            return bt;
        }
        public void RestartGameAuto(bool UsersRestart)
        {
            bool KtotoPobedil = VivodPobeda();
            if (KtotoPobedil == true)
            {
                Window3 xo = new Window3();
                Hide();
                xo.Show();
            }
            else if(UsersRestart == true)
            {
                Window3 xo = new Window3();
                Hide();
                xo.Show();
                UsersRestart = false;
            }

        }
        public bool VivodPobeda()
        {
            int Vuigral = ProverkaPobeda();
            if (Vuigral == 1)
            {
                MessageBox.Show("Вийграв хрестик!");
                return true;
            }
            else if(Vuigral == 2)
            {
                MessageBox.Show("Вийграв нулик!");
                return true;
            }
            else if(Vuigral == -1)
            {
                return false;
            }
            return true;
            
        }

        public int ProverkaPobeda()
        {
            int RezProverki;
            for(int x = 0; x<= 5; x++)
            {
                for(int y=0; y<=5; y++)
                {
                    RezProverki = ProverkaPobedaForCheck(x, y);
                    if (RezProverki != -1)
                    {
                        return RezProverki;
                    }
                }
            }

            return -1;
        }

        public int ProverkaPobedaForCheck(int x, int y)
        {

            if (pole[x, y] != 0)
            {
                if (y != 0 && y != 5)
                {
                    if (pole[x, y] == pole[x, y - 1] && pole[x, y] == pole[x, y + 1])
                    {
                        return pole[x, y];
                    }
                }
                if (x != 0 && x != 5)
                {
                    if (pole[x, y] == pole[x - 1, y] && pole[x, y] == pole[x + 1, y])
                    {
                        return pole[x, y];
                    }
                }
                if (x != 0 && x != 5 && y != 0 && y != 5)
                {
                    if (pole[x, y] == pole[x - 1, y - 1] && pole[x, y] == pole[x + 1, y + 1])
                    {
                        return pole[x, y];
                    }
                }
                if (x != 0 && x != 5 && y != 0 && y != 5)
                {
                    if (pole[x, y] == pole[x - 1, y + 1] && pole[x, y] == pole[x + 1, y - 1])
                    {
                        return pole[x, y];
                    }
                }
            }              
            return -1;

        }

            private void bO_O(object sender, RoutedEventArgs e)
            {
                 if(CheyXod(i) == true)
                 {
                     pole[0, 0] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[0, 0] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void bO_1(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[0, 1] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[0, 1] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void bO_2(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[0, 2] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[0, 2] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);

             }
             private void bO_3(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[0, 3] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[0, 3] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void bO_4(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[0, 4] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[0, 4] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void bO_5(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[0, 5] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[0, 5] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }

             private void b1_O(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[1, 0] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[1, 0] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b1_1(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[1, 1] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[1, 1] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);

             }
             private void b1_2(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[1, 2] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[1, 2] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b1_3(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[1, 3] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[1, 3] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b1_4(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[1, 4] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[1, 4] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b1_5(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[1, 5] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[1, 5] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b2_O(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[2, 0] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[2, 0] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b2_1(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[2, 1] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[2, 1] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b2_2(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[2, 2] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[2, 2] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b2_3(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[2, 3] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[2, 3] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b2_4(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[2, 4] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[2, 4] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b2_5(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[2, 5] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[2, 5] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b3_O(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[3, 0] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[3, 0] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b3_1(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[3, 1] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[3, 1] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b3_2(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[3, 2] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[3, 2] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b3_3(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[3, 3] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[3, 3] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b3_4(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[3, 4] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[3, 4] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b3_5(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[3, 5] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[3, 5] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b4_O(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[4, 0] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[4, 0] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b4_1(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[4, 1] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[4, 1] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b4_2(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[4, 2] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[4, 2] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b4_3(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[4, 3] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[4, 3] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b4_4(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[4, 4] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[4, 4] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);

             }
             private void b4_5(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[4, 5] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[4, 5] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b5_O(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[5, 0] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[5, 0] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b5_1(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[5, 1] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[5, 1] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b5_2(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[5, 2] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[5, 2] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b5_3(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[5, 3] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[5, 3] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b5_4(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[5, 4] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[5, 4] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             }
             private void b5_5(object sender, RoutedEventArgs e)
             {
                 if (CheyXod(i) == true)
                 {
                     pole[5, 5] = 1;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathKrest)));

                 }
                 else
                 {
                     pole[5, 5] = 2;
                     (sender as Button).Background = new ImageBrush(new BitmapImage(new Uri(pathNull)));
                 }
                 i = PlusState(i);

                 RestartGameAuto(UsersRestart);
             } 

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(); 
            Hide();
            mw.Show();

        }

        private void Restart_byUser(object sender, RoutedEventArgs e)
        {
            UsersRestart = true;
            RestartGameAuto(UsersRestart);
        }
  
    }
}
