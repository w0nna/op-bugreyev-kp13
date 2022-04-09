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

        public string path = @"C:\Users\1wni Work\Documents\op-bugreyev-kp13\lab01\StudentList.txt";
        public Window1()
        {
            InitializeComponent();
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
                    txt.Close();
                }
        }
                


    


        private void Save_Click(object sender, RoutedEventArgs e)
        {

            string saveImya_in_file = PoleImya.Text;
            string saveFamil_in_file = PoleFamil.Text;
            string saveOtches_in_file = PoleOtchest.Text;
            string saveZalik_in_file =  PoleZalik.Text;
            

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
            string DeleteStudent = PoleDelete.Text;
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


