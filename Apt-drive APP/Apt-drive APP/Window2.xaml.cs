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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        int maxKol = 0;
        bool IsTeacherUsers;
        string WhaGroup;
        public Window2(bool isTeacherUser, string Group)
        {
            IsTeacherUsers = isTeacherUser;
            WhaGroup = Group;
            InitializeComponent();
            if(IsTeacherUsers == true)
                isTeacher();
            else
                LoadData();
        }

        private void LoadData()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

            connection.Open();
            string cmd = "SELECT Прізвище, Імя, По_Батькові, Дата_Народження, ID_Групи FROM Students";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Students"); 
            dataAdp.Fill(dt);
            DG.ItemsSource = dt.DefaultView; 
            connection.Close();

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
        private  void isTeacher()
        {
            if (IsTeacherUsers == false)
            {
                Teacher.Visibility = Visibility.Hidden;
            }
            else
            {
                InfoForTeacher();
                DG.IsReadOnly = false;

            }
        }

        private void InfoForTeacher()
        {
            string cmd;
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

            connection.Open();
            if (WhaGroup == "Admin")
            {
                cmd = "SELECT * FROM Students";
            }
            else
            {
                cmd = "SELECT * FROM Students WHERE ID_Групи LIKE '" + WhaGroup + "'";
            }

            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Students");
            dataAdp.Fill(dt);
            DG.ItemsSource = dt.DefaultView;
            connection.Close();
            if(IsTeacherUsers == true)
            {
                if(WhaGroup != "Admin")
                {
                    Teacher.Visibility = Visibility.Hidden;
                }
                    
            }
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void Maximaze_Click(object sender, RoutedEventArgs e)
        {
            if(maxKol != 0 && maxKol != 1)
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(IsTeacherUsers, WhaGroup);
            this.Hide();
            w1.Show();
        }

        private void Teacher_Click(object sender, RoutedEventArgs e)
        {
            Stud.IsEnabled = true;
            Teacher.IsEnabled = false;
            string cmd;

            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
            connection.Open();
            if(WhaGroup == "Admin")
            {
                cmd = "SELECT * FROM Teachers";
            }
            else
            {
                cmd = "SELECT Прізвище, Імя, По_Батькові, Дата_Народження, Номер_Телефону FROM Teachers";
            }
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Teachers");
            dataAdp.Fill(dt);
            DG.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void Stud_Click(object sender, RoutedEventArgs e)
        {
            Stud.IsEnabled = false;
            Teacher.IsEnabled = true;
            if(IsTeacherUsers == true)
            {
                InfoForTeacher();
            }
            else
            {
                SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

                connection.Open();
                string cmd = "SELECT Прізвище, Імя, По_Батькові, Дата_Народження, ID_Групи FROM Students";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Students");
                dataAdp.Fill(dt);
                SqlConnection myConn = new SqlConnection("server=localhost;uid=sa;pwd=;database=pubs");
                SqlDataAdapter myData = new SqlDataAdapter("select au_id, au_fname, au_lname, state, contract from authors", myConn);
                DataSet ds = new DataSet();
                myData.Fill(ds);

                connection.Close();
            }
        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

            connection.Open();
            objToAdd = DG.SelectedItem as Students;

            //Проверим если такой же в сущности:
            var conn = db.Sports.Where(c => c.sports_code == objToAdd.sports_code).FirstOrDefault();
            if (conn == null)
            {
                db.Sports.Add(objToAdd);
            }
            else
            {
                conn.sports_code = objToAdd.sports_code;
                conn.sport = objToAdd.sport;
                db.Entry(conn).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}
