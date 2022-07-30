using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;

namespace Apt_drive_APP
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public bool IsTeacherUser;
        string CBTText;
        int selectedIndex;

        bool Selected = false;
        string user;


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        public Window1(string usernow, int SelctedIndexa)
        {
            InitializeComponent();
            user = usernow;
            switch (user)
            {
                case "Teacher":
                    accStat.Content = "TEACHER";
                    AccAv.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"C:\Users\1wni Work\source\repos\Apt-drive APP\Apt-drive APP\Source\teaccher.png", UriKind.RelativeOrAbsolute)) };
                    nughno.Visibility = Visibility.Visible;
                    CBT.Visibility = Visibility.Visible;    
                    break; 
                case "Admin":
                    accStat.Content = "ADMIN";
                    nughno.Visibility = Visibility.Hidden;
                    CBT.Visibility = Visibility.Hidden;

                    AccAv.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"C:\Users\1wni Work\source\repos\Apt-drive APP\Apt-drive APP\Source\administrator.png", UriKind.RelativeOrAbsolute)) };
                    break;
                case "Student":
                    AccAv.Background = new ImageBrush { ImageSource = new BitmapImage(new Uri(@"C:\Users\1wni Work\source\repos\Apt-drive APP\Apt-drive APP\Source\students.png", UriKind.RelativeOrAbsolute)) };
                    nughno.Visibility = Visibility.Hidden;
                    CBT.Visibility = Visibility.Hidden;
                    accStat.Content = "STUDENT";
                    break;
            }
        }



        private void Info_click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Users\1wni Work\source\repos\Apt-drive APP\Apt-drive APP\Info.txt";
            StreamReader read = new StreamReader(path);
            string AllInFile = read.ReadLine();


            if (String.IsNullOrEmpty(AllInFile))
            {
                MessageBox.Show("Файл Info.txt пуст!");
            }
            else
            {
                System.Diagnostics.Process txt = new System.Diagnostics.Process();
                txt.StartInfo.FileName = "notepad.exe";
                txt.StartInfo.Arguments = path;
                txt.Start();
            }
        }

        private void Spisok_Click(object sender, RoutedEventArgs e)
        {
            if(SelestedCheck(Selected, user) == true)
            {
                Window2 w2 = new Window2(user, CBTText, selectedIndex);
                Hide();
                w2.Show();
            }
                
        }


        private void BtnPod_Click(object sender, RoutedEventArgs e)
        {
            if (user == "Student")
            {
                MoneyBtn.Visibility = Visibility.Hidden;
            }

        }

        private void CBGroup_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (user == "Admin")
            {
                MoneyBtn.Visibility = Visibility.Hidden;
            }
        }

        private void Raspis_Click(object sender, RoutedEventArgs e)
        {
            if (SelestedCheck(Selected, user) == true)
            {
                Window3 w3 = new Window3(user, selectedIndex);
                this.Hide();
                w3.Show();
            }

        }

        private void Dengi_Click(object sender, RoutedEventArgs e)
        {
            if (SelestedCheck(Selected, user) == true)
            {
                Window4 w4 = new Window4(user, selectedIndex, CBTText);
                this.Hide();
                w4.Show();
            }
                
        }

        private void Cars_Click(object sender, RoutedEventArgs e)
        {
            if (SelestedCheck(Selected, user) == true)
            {
                Window5 w5 = new Window5(user, selectedIndex);
                this.Hide();
                w5.Show();
            }

        }

        private void AccAv_Click(object sender, RoutedEventArgs e)
        {
            Login log =new Login();
            this.Close();
            log.Show();
        }

        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            nughno.Visibility = Visibility.Hidden;
            Selected = true;
            
        }
        public bool SelestedCheck(bool Selected, string user)
        {
            if(user == "Teacher")
            {
                selectedIndex = CBT.SelectedIndex;
                CBTText = CBT.Text.ToString();
                if (Selected != true)
                {
                    Errors er = new Errors(2);
                    er.Show();
                    return false;
                }
            }
            return true;
        }

        private void EXIT_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

