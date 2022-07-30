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
    /// Логика взаимодействия для Del.xaml
    /// </summary>
    public partial class Del : Window
    {
        bool t;
        public Del(bool IsT)
        {
            InitializeComponent();
            t = IsT;
        }
        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DELbut_Click(object sender, RoutedEventArgs e)
        {
            if(DELBox.Text == "")
            {
                Errors er = new Errors(11);
                er.Show();
            }
            else
            {
                if(t == true)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
                    connection.Open();
                    DELBox.Text = DELBox.Text.Replace(" ", string.Empty);
                    string cmd = $"SELECT ID_Вчителя FROM Teachers WHERE ID_Вчителя ='{DELBox.Text}'";
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    SqlDataReader dr = createCommand.ExecuteReader();
                    bool HasLine3 = false;
                    do
                    {
                        HasLine3 = dr.Read();
                        if (HasLine3 == true)
                        {
                            connection.Close();
                            DeleteT();
                            break;
                        }
                        else
                        {
                            Errors er = new Errors(14);
                            er.Show();
                            connection.Close();
                            break;
                        }
                    }
                    while (HasLine3);
                    try
                    {
                        connection.Close();
                    }
                    catch
                    {

                    }



                }
                else
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
                    connection.Open();
                    DELBox.Text = DELBox.Text.Replace(" ", string.Empty);
                    string cmd = $"SELECT ID_Студента FROM Students WHERE ID_Студента ='{DELBox.Text}'";
                    SqlCommand createCommand = new SqlCommand(cmd, connection);
                    SqlDataReader dr = createCommand.ExecuteReader();
                    bool HasLine3 = false;
                    do
                    {
                        HasLine3 = dr.Read();
                        if (HasLine3 == true)
                        {
                            connection.Close();
                            DeleteS();
                            break;
                        }
                        else
                        {
                            Errors er = new Errors(14);
                            er.Show();
                            connection.Close();
                            break;
                        }
                    }
                    while (HasLine3);

                    try
                    {
                        connection.Close();
                    }
                    catch
                    {

                    }
                    
                }
            }
              
        }
        private void DeleteS()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand($"DELETE FROM Students WHERE ID_Студента = '{DELBox.Text}'", connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            connection.Close();
        }
        private void DeleteT()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand($"DELETE FROM Teachers WHERE ID_Вчителя = '{DELBox.Text}'", connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            connection.Close();

        }
    }
}
