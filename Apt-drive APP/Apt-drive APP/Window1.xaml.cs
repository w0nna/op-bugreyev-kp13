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

namespace Apt_drive_APP
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public bool IsTeacherUser;
        string CBItemPod;
        bool IsOkey;


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        public Window1(bool IsTeacherUsers, string Groups)
        {
            IsTeacherUser = IsTeacherUsers;
            CBItemPod = Groups;
            InitializeComponent();
            if (IsTeacherUser == true)
                CheckIfBack();

        }

        public void CheckIfBack()
        {

            Thread.Sleep(1000);
            MessageBox.Show("Будь ласка, зробите ще раз аутендифiкацiю!", "WARNING!", MessageBoxButton.OK, MessageBoxImage.Information);
            CBTeach.IsChecked = false;
            CBTeach.IsEnabled = true;
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
            IsOkey = CheckChecker();
            if (IsOkey == true)
            {
                Window2 w2 = new Window2(IsTeacherUser, CBItemPod);
                Hide();
                w2.Show();
            }
        }


        private void CBTeach_Unchecked(object sender, RoutedEventArgs e)
        {
            HideCheck();
        }

        private void HideCheck()
        {
            Podtverd.Visibility = Visibility.Hidden;
            BtnPod.Visibility = Visibility.Hidden;
            CBGroup.Visibility = Visibility.Hidden;
            BtnCancel.Visibility = Visibility.Hidden;
        }
        private bool CheckChecker()
        {
            if (CBTeach.IsChecked == true && CBTeach.IsEnabled == true)
            {
                MessageBox.Show("Або знiмiть галочку, або пiдтвердите вибiр.", "!ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                if (CBTeach.IsEnabled == false)
                {
                    IsTeacherUser = true;
                    CBItemPod = CBGroup.Text;
                }
                return true;
            }
        }

        private void CBTeach_Checked(object sender, RoutedEventArgs e)
        {
            Visible();
        }

        private void Visible()
        {
            Podtverd.Visibility = Visibility.Visible;
            BtnPod.Visibility = Visibility.Visible;
            CBGroup.Visibility = Visibility.Visible;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            CBTeach.IsChecked = false;
            CBTeach.IsEnabled = true;
            HideCheck();
        }

        private void BtnPod_Click(object sender, RoutedEventArgs e)
        {
            CBItemPod = CBGroup.SelectedItem.ToString();

            if (CBItemPod == "Admin")
            {
                MoneyBtn.Visibility = Visibility.Hidden;
            }
        
            CBTeach.IsEnabled = false;
            BtnPod.Visibility = Visibility.Hidden;
            BtnPod.IsEnabled = false;
            HideCheck();
            BtnCancel.Visibility = Visibility.Visible;
        }

        private void CBGroup_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnPod.IsEnabled = true;
            CBItemPod = CBGroup.SelectedItem.ToString();

            if (CBItemPod == "Admin")
            {
                MoneyBtn.Visibility = Visibility.Hidden;
            }
        }

        private void Raspis_Click(object sender, RoutedEventArgs e)
        {
            Window3 w3 = new Window3(IsTeacherUser, CBItemPod);
            Hide();
            w3.Show();
        }

        private void Dengi_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4 = new Window4(IsTeacherUser, CBItemPod);
            Hide();
            w4.Show();
        }

        private void Cars_Click(object sender, RoutedEventArgs e)
        {
            Window5 w5 = new Window5(IsTeacherUser, CBItemPod);
            Hide();
            w5.Show();
        }

    }
}

