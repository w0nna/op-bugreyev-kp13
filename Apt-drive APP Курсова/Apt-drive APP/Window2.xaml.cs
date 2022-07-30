using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
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
        string usernow;
        int ind;
        bool Adm = false;
        bool Teach = false;
        bool Student = false;
        bool IsT = false;
        bool Add;
        string CBTt;
        public Window2(string usernext, string CBTText, int Selected)
        {
            InitializeComponent();
            usernow = usernext;
            CBTt = CBTText;
            ind = Selected;
            switch (usernow)
            {
                case "Admin":
                    MainBorder.Visibility = Visibility.Visible;
                    DG.IsReadOnly = false;
                    Adm = true;
                    break;
                case "Teacher":
                    MainBorder.Visibility = Visibility.Hidden;
                    Teach = true;
                    isTeacher();
                    break;
                case "Student":
                    MainBorder.Visibility= Visibility.Hidden;
                    Student = true;
                    break;
            }
            LoadData();
        }

        private void LoadData()
        {
            string cmd;
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

            connection.Open();
            if (Adm == true)
            {
                cmd = "SELECT * FROM Students";
            }
            else if (Teach == true)
            {
                cmd = $"SELECT Прізвище, Імя, По_Батькові, Дата_Народження, ID_Групи, Номер_Телефону, Місце_Прописки FROM Students WHERE ID_Групи LIKE '{CBTt}'";
            }
            else
            {
                cmd = "SELECT Прізвище, Імя, По_Батькові, Дата_Народження, ID_Групи FROM Students";
            }
                
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
            Application.Current.Shutdown();
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
                InfoForTeacher();
                DG.IsReadOnly = false;
        }

        private void InfoForTeacher()
        {
            string cmd;
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

            connection.Open();
            cmd = "SELECT * FROM Students";
            if (Adm == true)
            {
                cmd = "SELECT * FROM Students";
            }
            else if(Teach == true)
            {
                cmd = "SELECT * FROM Students WHERE ID_Групи LIKE '" + CBTt + "'";
            }

            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Students");
            dataAdp.Fill(dt);
            DG.ItemsSource = dt.DefaultView;
            connection.Close();
            if(usernow != "Admin")
            {
                Teacher.Visibility = Visibility.Hidden;
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
            Window1 w1 = new Window1(usernow,0);
            this.Hide();
            w1.Show();
        }

        private void Teacher_Click(object sender, RoutedEventArgs e)
        {
            Stud.IsEnabled = true;
            Teacher.IsEnabled = false;
            IsT = true;
            string cmd;

            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
            connection.Open();
            if(Adm == true)
                cmd = "SELECT * FROM Teachers";
            else 
                cmd = "SELECT Прізвище, Імя, По_Батькові, Дата_Народження, Номер_Телефону FROM Teachers";
            
            
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
            IsT = false;
//
                InfoForTeacher();
            
            if(usernow == "Student" || usernow == "Teacher")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");

                connection.Open();
                string cmd = "SELECT Прізвище, Імя, По_Батькові, Дата_Народження, ID_Групи FROM Students";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Students");
                dataAdp.Fill(dt);
                SqlDataAdapter myData = new SqlDataAdapter("SELECT Прізвище, Імя, По_Батькові, Дата_Народження, ID_Групи FROM Students" , connection);;
                DataSet ds = new DataSet();
                myData.Fill(ds);

                connection.Close();
            }
        }

        private void DG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
        }



        private void Border_TouchEnter(object sender, MouseEventArgs e)
        {
            ThicknessAnimation myThicknessAnimation = new ThicknessAnimation();
            myThicknessAnimation.Duration = TimeSpan.FromSeconds(0.5);
            myThicknessAnimation.FillBehavior = FillBehavior.HoldEnd;
            myThicknessAnimation.From = new Thickness(-49, 154, 791, 154);
            myThicknessAnimation.To = new Thickness(0, 154, 742, 154);
            MainBorder.BeginAnimation(ContentControl.MarginProperty, myThicknessAnimation);
            MainBorder.Margin = new Thickness(0, 154, 742, 154);
        }

        private void MainBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            ThicknessAnimation myThicknessAnimation2 = new ThicknessAnimation();
            myThicknessAnimation2.Duration = TimeSpan.FromSeconds(0.5);
            myThicknessAnimation2.FillBehavior = FillBehavior.HoldEnd;
            myThicknessAnimation2.From = new Thickness(0, 154, 742, 154);
            myThicknessAnimation2.To = new Thickness(-49, 154, 791, 154);
            MainBorder.BeginAnimation(ContentControl.MarginProperty, myThicknessAnimation2);
            MainBorder.Margin = new Thickness(-49, 154, 791, 154);
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            Add = true;
            AddDelete ad = new AddDelete(usernow, ind,CBTt, IsT, Add);;
            ad.Show();
        }

        private void Upd_Click(object sender, RoutedEventArgs e)
        {
            if(IsT == true)
            {
                string cmd;

                SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
                connection.Open();

                    cmd = "SELECT * FROM Teachers";
               


                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Teachers");
                dataAdp.Fill(dt);
                DG.ItemsSource = dt.DefaultView;
                connection.Close();
            }
            else
            {
                LoadData();
            }
        }

        private void DG_CellEditEnding_1(object sender, DataGridCellEditEndingEventArgs e)
        {
            

            
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Del dl = new Del(IsT);
            dl.Show();
        }
    }
}
 