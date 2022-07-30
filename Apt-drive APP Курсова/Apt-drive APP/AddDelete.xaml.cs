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
    /// Логика взаимодействия для AddDelete.xaml
    /// </summary>
    public partial class AddDelete : Window
    {
        bool t;
        bool ad;
        string usernow;
        int ind;
        string CBTT;
        bool PoleG = false;
        bool PaspG = false;
        bool IDG = false;
        bool GroupG = false;
        bool PosadaG = false;
        bool IDTG = false;
        public AddDelete(string user, int index, string CBTText, bool IsT, bool Add)
        {
            CBTT = CBTText;
            InitializeComponent();
            t = IsT;
            ad = Add;
            ind = index;
            usernow = user;
            VisibilityLast(t);
        }
        private void But_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void VisibilityLast(bool IsT)
        {
            if(IsT == true)
            {
                PosadaBox.Visibility = Visibility.Visible;
                PosadaLabel.Visibility = Visibility.Visible;
                GroupLab.Visibility = Visibility.Hidden;
                Group.Visibility = Visibility.Hidden;
            }
            else
            {
                PosadaBox.Visibility = Visibility.Hidden;
                PosadaLabel.Visibility = Visibility.Hidden;
                GroupLab.Visibility = Visibility.Visible;
                Group.Visibility = Visibility.Visible;
            }
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }

        private void Pasport_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox a = (TextBox)sender;
            if ((e.Key < Key.D0 || e.Key >= Key.A) || (e.Key < Key.Delete || e.Key >= Key.D))
                e.Handled = true;
        }

        private void Pol_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Pol.Text == "М" || Pol.Text == "Ж" || Pol.Text == "м" || Pol.Text == "ж")
                PoleG = true;
        }

        private void ID_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox a = (TextBox)sender;
            if ((e.Key < Key.D0 || e.Key >= Key.A) || (e.Key < Key.Delete || e.Key >= Key.D))
                e.Handled = true;
        }

        private void DenRoghdeniya_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox a = (TextBox)sender;
            if ((e.Key < Key.D0 || e.Key >= Key.A) && e.Key != Key.OemPeriod)
                e.Handled = true;
        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(t != true)
            {
                if (ID.Text == null || ID.Text == "")
                {
                    Errors er = new Errors(5);
                    er.Show();
                }
                else
                {
                    if (Group.Text == null || Group.Text == "")
                    {
                        Errors er = new Errors(6);
                        er.Show();
                    }
                    else
                    {
                        if (NePusto() == true)
                            ProverkaSushS();

                    }
                }
            }
            else
            {
                if (ID.Text == null || ID.Text == "")
                {
                    Errors er = new Errors(5);
                    er.Show();
                }
                else
                {
                    if (PosadaBox.Text == null || PosadaBox.Text == "")
                    {
                        Errors er = new Errors(7);
                        er.Show();
                    }
                    else
                    {
                        if (NePusto() == true)
                            ProverkaSushT();
                    }
                }
            }
            




        }
        private void AddBD()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
            try
            {
                connection.Open();
            }
            catch 
            {
                Errors er = new Errors(9);
                er.Show();
                return;
            }

            if(t == true)
            {
                SqlCommand cmd = new SqlCommand("Insert into Teachers (ID_Вчителя, Прізвище, Імя, По_Батькові, Дата_Народження, Стать, Номер_Паспорту, Місце_Прописки, Номер_Телефону, Посада) Values (@ID, @F, @I, @O, @DR, @P, @NP, @MP, @NT, @POSADA)", connection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = ID.Text;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@F";
                param.Value = Famil.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@I";
                param.Value = Imya.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@O";
                param.Value = PoBatkovi.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@DR";
                param.Value = DenRoghdeniya.Text;
                param.SqlDbType = SqlDbType.NChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@P";
                param.Value = Pol.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@NP";
                param.Value = Pasport.Text;
                param.SqlDbType = SqlDbType.NChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@MP";
                param.Value = Propiska.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@NT";
                param.Value = Telephon.Text;
                param.SqlDbType = SqlDbType.NChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@POSADA";
                param.Value = PosadaBox.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Errors er = new Errors(10);
                    return;
                }
                connection.Close();


                    connection.Open();
                    string cmd2 = "Select * From Teachers";
                    SqlCommand createCommand = new SqlCommand(cmd2, connection);
                    createCommand.ExecuteNonQuery();
                    SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                    DataTable dt = new DataTable("Teachers");
                    dataAdp.Fill(dt);
                    SqlDataAdapter myData = new SqlDataAdapter("SELECT * FROM Teachers", connection);
                    DataSet ds = new DataSet();
                    myData.Fill(ds);

                    connection.Close();
   


            }
            else
            {
                SqlCommand cmd = new SqlCommand("Insert into Students (ID_Студента, Прізвище, Імя, По_Батькові, Дата_Народження, Стать, Номер_Паспорту, Місце_Прописки, Номер_Телефону, ID_Групи) Values (@ID, @F, @I, @O, @DR, @P, @NP, @MP, @NT, @Group)", connection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@ID";
                param.Value = ID.Text;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@F";
                param.Value = Famil.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);


                param = new SqlParameter();
                param.ParameterName = "@I";
                param.Value = Imya.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@O";
                param.Value = PoBatkovi.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@DR";
                param.Value = DenRoghdeniya.Text;
                param.SqlDbType = SqlDbType.NChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@P";
                param.Value = Pol.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@NP";
                param.Value = Pasport.Text;
                param.SqlDbType = SqlDbType.NChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@MP";
                param.Value = Propiska.Text;
                param.SqlDbType = SqlDbType.Text;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@NT";
                param.Value = Telephon.Text;
                param.SqlDbType = SqlDbType.NChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Group";
                param.Value = Group.Text;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    Errors er = new Errors(10);
                    return;
                }
                connection.Close();


                connection.Open();
                string cmd2 = "Select * From Students";
                SqlCommand createCommand = new SqlCommand(cmd2, connection);
                createCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Students");
                dataAdp.Fill(dt);
                SqlDataAdapter myData = new SqlDataAdapter("SELECT * FROM Students", connection);
                DataSet ds = new DataSet();
                myData.Fill(ds);

                connection.Close();

            }
        }
        private bool NePusto()
        {
            if(Famil.Text == "" || Famil.Text == null || Imya.Text == "" || PoBatkovi.Text == "" || DenRoghdeniya.Text == "" || Pol.Text == "" || Pasport.Text == "" || Propiska.Text == "" || Telephon.Text == "")
            {
                Errors errors = new Errors(11);
                errors.Show();
                return false;
            }
            else
            {
                if (DenRoghNorm() == false)
                    return false;
                else
                    return true;
            }
        }

        private bool DenRoghNorm()
        {
            var dateFormat = "dd.MM.yyyy";
            DateTime scheduleDate;
            try
            {
                scheduleDate = DateTime.ParseExact(DenRoghdeniya.Text, dateFormat, null);
                if(!(scheduleDate.Year <= 2002 || scheduleDate.Year >= 1900 ))
                {
                    Errors er = new Errors(13);
                    er.Show();
                    return false;
                }
            }
            catch
            {
                Errors er = new Errors(12);
                er.Show();
                return false;
            }
            return true;
            
        }
        private void ProverkaSushT()
        {
            bool HasLine = false;
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
            connection.Open();
            ID.Text = ID.Text.Replace(" ", string.Empty);
            string cmd = $"SELECT ID_Вчителя FROM Teachers WHERE ID_Вчителя ='{ID.Text}'"; 
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            SqlDataReader dr = createCommand.ExecuteReader();
            do
            {
                HasLine = dr.Read();
                if(HasLine == true)
                {
                    if(IDTG != true)
                    {
                        Errors er = new Errors(3);
                        er.Show();
                        connection.Close();
                        break;
                    }
                    
                   
                }
                else
                {
                    IDTG = true;
                    break;

                }

            }
            while (HasLine);
            connection.Close();

            connection.Open();
            bool HasLine2 = false;
            string cmd2 = $"SELECT Посада FROM Teachers WHERE Cast(Посада as varchar)='{PosadaBox.Text}'";
            SqlCommand cc = new SqlCommand(cmd2, connection);
            SqlDataReader dar = cc.ExecuteReader();
            do
            {
                HasLine2 = dar.Read();
                if (HasLine2 == true)
                {
                    PosadaG = true;
                    break;
                }
                else
                {
                    if (PosadaG != true)
                    {
                        Errors er = new Errors(8);
                        er.Show();
                        connection.Close();
                        break;
                    }
                }

            }
            while (HasLine2);

            connection.Close();
            AddBD();
        }
        private void ProverkaSushS()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=W0NNA; Initial Catalog=AppDrive; Integrated Security=True");
            connection.Open();
            ID.Text = ID.Text.Replace(" ", string.Empty);
            string cmd = $"SELECT ID_Студента FROM Students WHERE ID_Студента ='{ID.Text}'"; 
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            SqlDataReader dr = createCommand.ExecuteReader();
            bool HasLine3 = false;
            while(dr.Read())
            {
                HasLine3 = dr.Read();
                if (HasLine3 == true)
                {
                    IDG = true;
                    break;
                }
                else
                {
                    if (IDG != true)
                    {
                        Errors er = new Errors(3);
                        er.Show();
                        connection.Close();
                        break;
                    }


                }
            }

           
            connection.Close();

            connection.Open();
            bool HasLine4 = false;
            string cmd2 = $"SELECT ID_Групи FROM Students WHERE Cast(ID_Групи as varchar) ='{Group.Text}'";
            SqlCommand cc = new SqlCommand(cmd2, connection);
            SqlDataReader dar = cc.ExecuteReader();
            
            do
            {
                HasLine4 = dar.Read();
                if (HasLine4 == true)
                {
                    GroupG = true;
                    break;

                }
                else
                {
                    if (GroupG != true)
                    {
                        Errors er = new Errors(6);
                        er.Show();
                        connection.Close();
                        break;
                    }
                   
                }

            }
            while (HasLine3);
           
            connection.Close();
            AddBD();
        }

        private void Telephon_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox a = (TextBox)sender;
            if ((e.Key < Key.D0 || e.Key >= Key.A) || (e.Key < Key.Delete || e.Key >= Key.D))
                e.Handled = true;
        }

        private void Group_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox a = (TextBox)sender;
            if ((e.Key < Key.D0 || e.Key >= Key.A) || (e.Key < Key.Delete || e.Key >= Key.D))
                e.Handled = true;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2(usernow, CBTT, ind);
            w2.Show();
            this.Hide();
        }
    }
}
