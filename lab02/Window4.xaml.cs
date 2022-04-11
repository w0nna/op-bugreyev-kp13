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

namespace lab01
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            this.ResizeMode = ResizeMode.NoResize;
            this.Width = 400;
            this.Height = 200;
            this.Title = "Info";

            Brush Gradient = new LinearGradientBrush(Color.FromRgb(255, 255, 255), Color.FromRgb(225, 225, 225), 35);
            this.Background = Gradient;

            Grid Gridw4 = new Grid();

            Gridw4.Height = 150;
            Gridw4.Width = 350;
            Gridw4.HorizontalAlignment = HorizontalAlignment.Center;
            Gridw4.VerticalAlignment = VerticalAlignment.Center;
            


            RowDefinition[] row = new RowDefinition[4];
            ColumnDefinition[] columns = new ColumnDefinition[5];

            for (int i = 0; i < 4; i++)
            {
                row[i] = new RowDefinition();
                Gridw4.RowDefinitions.Add(row[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                columns[i] = new ColumnDefinition();
                Gridw4.ColumnDefinitions.Add(columns[i]);
            }


            TextBlock fir = new TextBlock();
            fir.FontFamily = new FontFamily("Bahnschrift Condense");
            fir.FontWeight = FontWeights.Bold;
            fir.VerticalAlignment = VerticalAlignment.Center;
            fir.Text = "Творець: Бугреєв Гліб Артемович";
            Grid.SetRow(fir, 0);
            Grid.SetColumn(fir, 0);
            Grid.SetColumnSpan(fir, 4);
            Gridw4.Children.Add(fir);


            TextBlock Tw = new TextBlock();
            Tw.FontFamily = new FontFamily("Bahnschrift Condense");
            Tw.FontWeight = FontWeights.Bold;
            Tw.VerticalAlignment = VerticalAlignment.Center;
            Tw.Text = "Група: КП-13 ФПМ";
            Grid.SetRow(Tw, 1);
            Grid.SetColumn(Tw, 0);
            Grid.SetColumnSpan(Tw, 4);
            Gridw4.Children.Add(Tw);

            TextBlock Thr = new TextBlock();
            Thr.FontFamily = new FontFamily("Bahnschrift Condense");
            Thr.FontWeight = FontWeights.Bold;
            Thr.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRow(Thr, 2);
            Grid.SetColumn(Thr, 0);
            Grid.SetColumnSpan(Thr, 4);
            Thr.Text = "Дата створення: 23.03.2022";
            Gridw4.Children.Add(Thr);

            Button back = new Button();
            back.Content = "Назад";
            back.Background = new SolidColorBrush(Color.FromRgb(212, 212, 212));
            back.Background.Opacity = 0;
            back.BorderBrush = new SolidColorBrush(Color.FromRgb(132, 43, 154));
            back.Click += GoBack_Click;
            Grid.SetRow(back, 1);
            Grid.SetColumn(back, 5);
            Gridw4.Children.Add(back);


            this.Content = Gridw4;
            this.Show();

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
