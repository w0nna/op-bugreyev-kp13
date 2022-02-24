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
        List<User> users = new List<User>();

        public string path = @"\Users\Iwni D\Documents\op-bugreyev-kp13\lab01\StudentList.txt";
        public Window1()
        {
            InitializeComponent();
        }
        Stream mystream;



        private void GoToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User("",""))

            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }


        private void Open_Click(object sender, RoutedEventArgs e)
        {
                StreamReader read = new StreamReader(path);
                string AllInFile = read.ReadLine();
                if (String.IsNullOrEmpty(AllInFile))
                {
                    MessageBox.Show("Файл пуст!");
                }
                else
                {

                    MessageBox.Show("Файл успешно открыт!");
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
            else
            {
                int DlinnaSpiska;
                

                string[] lines = { ListImya[DlinnaSpiska - 1], ListFamil[DlinnaSpiska - 1], ListOtches[DlinnaSpiska - 1], ListZalik[DlinnaSpiska - 1] };
                using (StreamWriter outputFile = new StreamWriter(path))
                {
                    foreach (string line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                }



                MessageBox.Show("Запис успішно збережено!");
            }

            if (String.IsNullOrWhiteSpace(Convert.ToString(saveZalik_in_file)) || String.IsNullOrEmpty(Convert.ToString(saveZalik_in_file)))
            {
                MessageBox.Show("Поле введення Номеру Залікової Книжки – порожнє!");
            }






        }
      
        private void Pole_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}


