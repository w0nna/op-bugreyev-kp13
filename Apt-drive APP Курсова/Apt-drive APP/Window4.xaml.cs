using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Apt_drive_APP
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        int maxKol = 0;
        int ind;
        string usernow;
        string grup;
        double kolvostud;
        double zarob;

        public Window4(string user, int index, string group)
        {
            usernow = user;
            grup = group;
            InitializeComponent();
            if(usernow != "Teacher")
                LoadData();
            else
                Forteach();
        }


        private void Forteach()
        {
            DG.Visibility = Visibility.Hidden;
            Obyas.Visibility = Visibility.Visible;
            Obyas2.Visibility = Visibility.Visible;
            Dataa.Visibility = Visibility.Visible;
            Plata.Visibility = Visibility.Visible;

            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

            
            string cmd = $"SELECT COUNT(*) FROM dbo.Students WHERE ID_Групи = '{grup}'";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            connection.Open();
            SqlDataReader reader = createCommand.ExecuteReader();
            
            while (reader.Read())
            {
                    string Res = reader.GetValue(0).ToString();
                    kolvostud = Convert.ToDouble(Res);
            }
            connection.Close();
            zarob = (kolvostud * 1600) * 0.8;
            Plata.Content = zarob;
        }
        private void LoadData()
        {

            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

            connection.Open();
            string cmd = "SELECT * FROM Payment";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Payment");
            dataAdp.Fill(dt);
            DG.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
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
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(usernow, ind);
            this.Hide();
            w1.Show();
        }


        private void Maximaze_Click(object sender, RoutedEventArgs e)
        {
            if (maxKol != 0 && maxKol != 1)
            {
                if (maxKol % 2 == 0)
                    this.WindowState = WindowState.Maximized;
                else
                    this.WindowState = WindowState.Normal;

            }
            else
                switch (maxKol)
                {
                    case 0:
                        this.WindowState = WindowState.Maximized;
                        break;
                    case 1:
                        this.WindowState = WindowState.Normal;
                        break;
                }

            maxKol++;

        }
    }
}
