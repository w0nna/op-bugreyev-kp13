using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
        string usernext;
        public Login()
        {
            InitializeComponent();
            connection.Open();
        }
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

        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            bool IsCorrect;
            string usernow = Loginn.Text;


            if (usernow.Length > 3)
            {
                IsCorrect = CheckDBL(usernow);
                if(IsCorrect == false)
                {
                    Errors er = new Errors(0);
                    er.Show();
                }
                else
                {
                    Loginn.Visibility = Visibility.Hidden;
                    LogLabel.Visibility = Visibility.Hidden;
                    PassLabel.Visibility = Visibility.Visible;
                    Pass.Visibility = Visibility.Visible;
                    Logon.Visibility = Visibility.Hidden;   
                    Logon2.Visibility = Visibility.Visible;
                    Backan.Visibility = Visibility.Visible;
                }
            }

        }

        public bool CheckDBL(string usernow) 
        {
            
            var cmd = new SqlCommand("SELECT login FROM Users", connection);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string userLogin = rd["login"].ToString();
                userLogin = userLogin.Replace(" ", string.Empty);
                if (usernow == userLogin)
                {
                    connection.Close();
                    usernext = usernow;
                    return true;
                }

            }


            return false;

            
        }
        public bool CheckDBp(string passnow)
        {
            connection.Open();
            var cmd = new SqlCommand("SELECT pswd FROM Users", connection);
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                string passUser = rd["pswd"].ToString();
                passUser = passUser.Replace(" ", string.Empty);
                if (passnow == passUser)
                {
                    connection.Close();
                    return true;
                }

            }
            connection.Close();

            return false;


        }
        private void Loginn_TextChanged(object sender, TextChangedEventArgs e)
        {
            Loginn.Text = Loginn.Text.Replace(" ", string.Empty);
        }

        private void Backan_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            Loginn.Visibility = Visibility.Visible;
            LogLabel.Visibility = Visibility.Visible;
            PassLabel.Visibility = Visibility.Hidden;
            Pass.Visibility = Visibility.Hidden;
            Logon.Visibility = Visibility.Visible;
            Logon2.Visibility= Visibility.Hidden;
            Backan.Visibility = Visibility.Hidden;
        }

        private void Logon2_Click(object sender, RoutedEventArgs e)
        {
            bool PIsCorrect;

            string passnow = Pass.Password;
            PIsCorrect = CheckDBp(passnow);
            if (PIsCorrect == false)
            {
                Errors er = new Errors(1);
                er.Show();
            }
            else
            {
                connection.Close();
                Window1 w1 = new Window1(usernext,0);
                this.Close();
                w1.Show();
            }


        }


    }
}

