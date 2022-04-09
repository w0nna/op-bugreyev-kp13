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

namespace lab01
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>


    public partial class Window1 : Window
    {
        List<User> usersList = new List<User>();
        int p = 0;
        int bt = 0;


        TextBox PoleImya = new TextBox();
        TextBox PoleFamil = new TextBox();
        TextBox PoleOtchest = new TextBox();
        TextBox PoleZalik = new TextBox();
        TextBox PoleZalikDel = new TextBox();

        public string path = @"C:\Users\1wni Work\Desktop\op-bugreyev-kp13\lab02\StudentList.txt";
        public Window1()
        {
            InitializeComponent();
            InitControls();
        }
        

        private void InitControls()
        {

            this.ResizeMode = ResizeMode.CanResize;
            this.Width = 500;
            this.Height = 650;
            this.Title = "Login in System";

            Brush Gradient = new LinearGradientBrush(Color.FromRgb(255,255,255), Color.FromRgb(225, 225, 225), 35);
            this.Background = Gradient;

            Grid Gridw1 = new Grid();
            Gridw1.Height = 650;
            Gridw1.Width = 500;
            Gridw1.HorizontalAlignment = HorizontalAlignment.Center;
            Gridw1.VerticalAlignment = VerticalAlignment.Center;    
            Gridw1.ShowGridLines = false;

            RowDefinition[] row = new RowDefinition[11];
            ColumnDefinition[] columns = new ColumnDefinition[3];
            TextBlock[] tbs = new TextBlock[5]; 
            TextBox[] tbxs = new TextBox[5];



            for (int i = 0; i < 11; i++)
            {
                row[i] = new RowDefinition();
                Gridw1.RowDefinitions.Add(row[i]); 
            }

            for (int i = 0; i < 3; i++)
            {
                columns[i] = new ColumnDefinition();
                Gridw1.ColumnDefinitions.Add(columns[i]);
            }



           /* for (int i = 0; i <= 4; i++)
            {
                tbs[i] = new TextBlock();
                TextBlock tbfn = tbs[i];
                ForNadpis(i, tbs[i]);
                Grid.SetRow(tbs[i], i);
                Grid.SetColumn(tbs[i], 2);
            }

            for (int i = 0; i <= 4; i++)
            {
                tbxs[i] = new TextBox();
                ForTextBox(tbxs[i]);
                tbxs[i].HorizontalAlignment = HorizontalAlignment.Center;
                tbxs[i].VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(tbxs[i], i);
                Grid.SetColumn(tbxs[i], 2);

            } */



            TextBlock Imya = new TextBlock();
            p = ForNadpis(Imya, p);
            Grid.SetRow(Imya, 2);
            Grid.SetColumn(Imya, 0);
            Grid.SetColumnSpan(Imya, 3);
            Gridw1.Children.Add(Imya);

            TextBlock Famil = new TextBlock();
            p = ForNadpis(Famil, p);
            Grid.SetRow(Famil, 3);
            Grid.SetColumn(Famil, 0);
            Grid.SetColumnSpan(Famil, 3);
            Gridw1.Children.Add(Famil);

            TextBlock Otchest = new TextBlock();
            p = ForNadpis(Otchest, p);
            Grid.SetRow(Otchest, 4);
            Grid.SetColumn(Otchest, 0);
            Grid.SetColumnSpan(Otchest, 3);
            Gridw1.Children.Add(Otchest);

            TextBlock Zalik = new TextBlock();
            p = ForNadpis(Zalik, p);
            Grid.SetRow(Zalik, 5);
            Grid.SetColumn (Zalik, 0);
            Grid.SetColumnSpan(Zalik, 3);
            Gridw1.Children.Add(Zalik);

            TextBlock ZalikDel = new TextBlock();
            p = ForNadpis(ZalikDel, p);
            Grid.SetRow(ZalikDel, 8);
            Grid.SetColumn(ZalikDel, 0);
            Grid.SetColumnSpan(ZalikDel, 3);
            Gridw1.Children.Add(ZalikDel);


            ForTextBox(PoleImya);
            PoleImya.Width = 100; 
            Grid.SetRow(PoleImya, 2);
            Grid.SetColumn(PoleImya, 0);
            Grid.SetColumnSpan(PoleImya, 3);
            PoleImya.MaxLength = 15;
            Gridw1.Children.Add(PoleImya);


            ForTextBox(PoleFamil);
            Grid.SetRow(PoleFamil, 3);
            Grid.SetColumn(PoleFamil, 0);
            Grid.SetColumnSpan(PoleFamil, 3);
            PoleFamil.MaxLength = 20;
            Gridw1.Children.Add(PoleFamil);


            ForTextBox(PoleOtchest);
            PoleOtchest.Width = 300;
            Grid.SetRow(PoleOtchest, 4);
            Grid.SetColumn(PoleOtchest, 0);
            Grid.SetColumnSpan(PoleOtchest, 3);
            PoleOtchest.MaxLength = 20;
            Gridw1.Children.Add(PoleOtchest);


            ForTextBox(PoleZalik);
            Grid.SetRow(PoleZalik, 5);
            Grid.SetColumn(PoleZalik, 0);
            Grid.SetColumnSpan(PoleZalik, 3);
            PoleZalik.MaxLength = 8;
            Gridw1.Children.Add(PoleZalik);


            ForTextBox(PoleZalikDel);
            Grid.SetRow(PoleZalikDel, 8);
            Grid.SetColumn(PoleZalikDel, 0);
            Grid.SetColumnSpan(PoleZalikDel, 3);
            PoleZalikDel.MaxLength = 8;
            Gridw1.Children.Add(PoleZalikDel);



            Button SaveBtn = new Button();
            SaveBtn.Click += Save_Click;
            Grid.SetRow(SaveBtn, 6);
            Grid.SetColumn(SaveBtn, 0);
            Grid.SetColumnSpan(SaveBtn, 3);
            bt = ForButtonMain(SaveBtn, bt);
            Gridw1.Children.Add(SaveBtn);

            Button OpenBtn = new Button();
            OpenBtn.Click += Open_Click;
            Grid.SetRow(OpenBtn, 7);
            Grid.SetColumn(OpenBtn, 0);
            Grid.SetColumnSpan(OpenBtn, 3);
            bt = ForButtonMain(OpenBtn, bt);
            Gridw1.Children.Add(OpenBtn);

            Button DelBtn = new Button();
            DelBtn.Click += DeleteStudent_Click;
            Grid.SetRow(DelBtn, 9);
            Grid.SetColumn(DelBtn, 0);
            Grid.SetColumnSpan(DelBtn, 3);
            bt = ForButtonMain(DelBtn, bt);
            Gridw1.Children.Add(DelBtn);

            Button NoBtn = new Button();
            NoBtn.Click += GoToMainMenu_Click;
            Grid.SetRow(NoBtn, 1);
            Grid.SetColumn(NoBtn, 0);
            Grid.SetColumnSpan(NoBtn, 3);
            bt = ForButtonMain(NoBtn, bt);
            NoBtn.Width = 50;
            NoBtn.HorizontalAlignment = HorizontalAlignment.Center;
            NoBtn.VerticalAlignment = VerticalAlignment.Center;
            Gridw1.Children.Add(NoBtn);

            TextBlock Hi = new TextBlock();
            Hi.HorizontalAlignment = HorizontalAlignment.Center;
            Hi.VerticalAlignment = VerticalAlignment.Bottom;
            Grid.SetRow(Hi, 0);
            Grid.SetRowSpan(Hi, 1);
            Grid.SetColumn(Hi, 0);
            Grid.SetColumnSpan(Hi, 3);
            Hi.FontFamily = new FontFamily("Bahnschrift Condensed");
            Hi.FontSize = 35;
            Hi.FontWeight = FontWeights.Bold;
            Hi.Width = 322;
            Hi.Text = "ВПИСАТИ ТЕБЕ В СИСТЕМУ?";
            Gridw1.Children.Add(Hi);




            this.Content = Gridw1;
            this.Show();
        }


        private int ForButtonMain(Button Btn, int bt)
        {
            Btn.Background = new SolidColorBrush(Colors.White);
            Btn.Foreground = new SolidColorBrush(Colors.Black);
            Btn.BorderBrush = new SolidColorBrush(Color.FromRgb(132,43,154));
            Btn.Height = 30;
            Btn.Width = 320;
            Btn.FontSize = 12;
            Btn.FontFamily = new FontFamily("Bahnschrift Condense");
            Btn.FontWeight = FontWeights.Bold;
            Btn.VerticalAlignment = VerticalAlignment.Top;

            switch (bt)
            {
                case 0:
                    Btn.Content = "ЗАНЕСТИ СТУДЕНТА ДО СПИСКУ";
                    bt++;
                    break;
                case 1:
                    Btn.Content = "ВІДКРИТИ СПИСОК СТУДЕНТІВ";
                    bt++;
                    break;
                case 2:
                    Btn.Content = "ВИДАЛИТИ СТУДЕНТА З СПИСКУ";
                    bt++;
                    break;
                case 3:
                    Btn.Content = "НІ";
                    Btn.Foreground = new SolidColorBrush(Color.FromRgb(132, 43, 154));
                    break;
            }


            return bt;
        }
        private int ForNadpis(TextBlock tbfn, int p)
        {
            Brush bb = new LinearGradientBrush(Color.FromRgb(0, 0, 0), Color.FromRgb(15, 15, 15), 35);
            tbfn.FontSize = 10;

            switch (p)
            {
                case 0:
                    tbfn.Text = "Ім'я";
                    tbfn.TextAlignment = TextAlignment.Center;
                    p++;
                    break;
                case 1:
                    tbfn.Text = "Прізвище";
                    tbfn.TextAlignment = TextAlignment.Center;
                    p++;
                    break ;
                case 2:
                    tbfn.Text = "По-Батькові";
                    tbfn.TextAlignment = TextAlignment.Center;
                    p++;
                    break;
                case 3:
                    tbfn.Text = "№ Залікової книжки [БЕЗ КВ№ !]";
                    tbfn.TextAlignment = TextAlignment.Center;
                    break;
            }
            tbfn.HorizontalAlignment = HorizontalAlignment.Center;
            tbfn.VerticalAlignment = VerticalAlignment.Top;
            tbfn.Width = 250;
            tbfn.Height = 25;
            tbfn.Foreground = bb;
            tbfn.Visibility = Visibility.Visible;
            return p;
        }

        private void ForTextBox(TextBox Pole)
        {
            Pole.Width = 200;
            Pole.Height = 25;
            Brush bg = new  LinearGradientBrush(Color.FromRgb(255,255,255), Color.FromRgb(254, 254, 254), 35);
            Brush bb = new LinearGradientBrush(Color.FromRgb(0, 0, 0), Color.FromRgb(15, 15, 15), 35);
            Pole.Background = bg;
            Pole.BorderBrush = bb;
            Pole.VerticalAlignment = VerticalAlignment.Center;
            Pole.HorizontalAlignment = HorizontalAlignment.Center;
            Pole.Visibility = Visibility.Visible;
        }

        private void GoToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }



        private void Open_Click(object sender, RoutedEventArgs e)
        {
                using (StreamWriter SW = new StreamWriter(path))
                {
                    foreach (User user in usersList)
                    {
                        SW.WriteLine(user.ToString());
                    }
                }
                StreamReader read = new StreamReader(path);
                string AllInFile = read.ReadLine();


                if (String.IsNullOrEmpty(AllInFile))
                {
                    MessageBox.Show("Файл пуст!");
                }
                else
                {
                    System.Diagnostics.Process txt = new System.Diagnostics.Process();
                    txt.StartInfo.FileName = "notepad.exe";
                    txt.StartInfo.Arguments = path;
                    txt.Start();
                    MessageBox.Show("Файл успешно открыт!");
                }
        }
                


    


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string saveImya_in_file = PoleImya.Text;
            string saveFamil_in_file = PoleFamil.Text;
            string saveOtches_in_file = PoleOtchest.Text;
            string saveZalik_in_file = PoleZalik.Text;

            if (String.IsNullOrWhiteSpace(saveImya_in_file) || String.IsNullOrEmpty(saveImya_in_file))
            {
                MessageBox.Show("Поле введення Ім'я – порожнє!");
            }
            else if (String.IsNullOrWhiteSpace(saveFamil_in_file) || String.IsNullOrEmpty(saveFamil_in_file))
            {
                MessageBox.Show("Поле введення Прізвище – порожнє!");
            }
            else if (String.IsNullOrWhiteSpace(saveOtches_in_file) || String.IsNullOrEmpty(saveOtches_in_file))
            {
                MessageBox.Show("Поле введення По-Батькові – порожнє!");
            }
            else if(String.IsNullOrWhiteSpace(Convert.ToString(saveZalik_in_file)) || String.IsNullOrEmpty(Convert.ToString(saveZalik_in_file)))
            {
                MessageBox.Show("Поле введення Номеру Залікової Книжки – порожнє!");

            }
            else
            {
                usersList.Add(new User(saveImya_in_file, saveFamil_in_file, saveOtches_in_file, saveZalik_in_file));
                MessageBox.Show("Студента успішно добавлено!");
            }


        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            string DeleteStudent = PoleZalikDel.Text;
            if(String.IsNullOrWhiteSpace(DeleteStudent) || String.IsNullOrEmpty(DeleteStudent))
            {
                MessageBox.Show("Поле введення - пусте!");
            }
            else
            {
                int DeleteInx = usersList.FindIndex(x => x.Zalik == DeleteStudent);
                if(DeleteInx == -1)
                {
                    MessageBox.Show("Студента не знайдено!");
                }
                else
                {
                    usersList.RemoveAt(DeleteInx);
                    MessageBox.Show("Студента видалено!");
                }

            }

            
        }
    }
}


