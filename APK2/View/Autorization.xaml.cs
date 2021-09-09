using APK2.Data;
using System;
using System.Data;
using APK2.Entitys;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using APK2.ViewModel;
using APK2.View;

namespace APK2._0.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseBatton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinBatton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Tullbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        private void logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        private void SittingServer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //new SittingsServerWindow().ShowDialog();
        }

        private void BtnCensel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
     
        private void Autorization_Loaded(object sender, RoutedEventArgs e)

        {
            
            try
            { 

                // подключение
                // если норм отображаем что БД доступна
                StateServ.Content = "ON";
                StateServ.Foreground = Brushes.Green;
            }
            catch (Exception x)
            {
             
                Server.Source = BitmapFrame.Create(new Uri(@"C:\Users\Георгий\YandexDisk\APK2\APK2\APK2\Source\circleRed.png"));
                StateServ.Content = "OFF";
                StateServ.Foreground = Brushes.Red;
                Mass.Text = x.Message;
                //throw;
            }

        }

        private void BtnAutorization_Click(object sender, RoutedEventArgs e)
        {
            StatusView StatusView = new StatusView();
            StatusView.Show();
            Close();
        }

        private void TbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            MassAutoriz.Text = "";
        }

        private void PbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            MassAutoriz.Text = "";
        }
    }
}
