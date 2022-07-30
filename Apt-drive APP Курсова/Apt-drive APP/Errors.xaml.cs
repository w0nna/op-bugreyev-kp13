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
using System.Windows.Shapes;

namespace Apt_drive_APP
{
    /// <summary>
    /// Логика взаимодействия для Errors.xaml
    /// </summary>
    public partial class Errors : Window
    {
        public Errors(int ErrorNum)
        {
            InitializeComponent();
            switch (ErrorNum)
            {
                case 0:
                    ErrCon.Content = "НЕ ВЕРНЫЙ ЛОГИН!";
                    break;
                case 1:
                    ErrCon.Content = "НЕ ВЕРНЫЙ ПАРОЛЬ!";
                    break;
                case 2:
                    ErrCon.Content = "ВЫ НЕ ВЫБРАЛИ ГРУППУ!";
                    break;
                case 3:
                    ErrCon.Content = "ТАКИЙ ID ВЖЕ Є.";
                    break;
                case 5:
                    ErrCon.Content = "ПОЛЕ ID ПОРОЖНЄ..";
                    break;
                case 6:
                    ErrCon.Content = "ТАКОГО ID_Group НЕМАЄ.";
                    break;
                case 7:
                    ErrCon.Content = "ПОЛЕ ПОСАДА ПОРОЖНЄ.";
                    break;
                case 8:
                    ErrCon.Content = "ТАКОЇ ПОСАДИ НЕМАЄ.";
                    break;
                case 9:
                    ErrCon.Content = "ПОМИЛКА ПІДКЛЮЧЕННЯ БД!";
                    break;
                case 10:
                    ErrCon.Content = "ПОМИЛКА, ПРИ ВИКОНАННІ ЗАПИТУВАННЯ НА ДОДАВАННЯ ЗАПИСУ.";
                    break;
                case 11:
                    ErrCon.Content = "ПОМИЛКА, ОДНЕ З ПОЛЕЙ ПОРОЖНЄ.";
                    break;
                case 12:
                    ErrCon.Content = "ПОМИЛКА, В ПОЛІ ДНЯ НАРОДЖЕННЯ НЕВІРНА ДАТА.";
                    break;
                case 13:
                    ErrCon.Content = "ПОМИЛКА, ЛЮДИНІ МЕНШ 18 НЕВІРНА ДАТА.";
                    break;
                case 14:
                    ErrCon.Content = "ТАКОГО ID НЕМАЄ.";
                    break;
            }
        }

        private void ErrorGif_MediaEnded(object sender, RoutedEventArgs e)
        {
            ErrorGif.Position = TimeSpan.FromSeconds(0);
        }

        private void oke_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
