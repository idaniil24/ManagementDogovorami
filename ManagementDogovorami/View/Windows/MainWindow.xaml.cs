using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementDogovorami.View.Pages;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementDogovorami
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string login;
        public string password;
        public int layer = 3;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            login = LoginTextBox.Text;
            password = PasswordTextBox.Password;
            FrameManager.MainWindow = this;
        }

        private void MoveToMainScreen(object sender, RoutedEventArgs e)
        {
            login = LoginTextBox.Text;
            password = PasswordTextBox.Password;
            Manager manager;
            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль!");
                return;
            }
            else if (CM_Entities.GetContext().Manager.Where(x => x.Login == login && x.Password == password).Count() == 0)
            {
                MessageBox.Show("Такого пользователя не существует!");
                return;
            }
            else
            {
                manager = CM_Entities.GetContext().Manager.Where(x => x.Login == login && x.Password == password).First();
                ManagerSaver.Login = login;
                ManagerSaver.First_name = manager.First_name.ToString();
                ManagerSaver.Second_name = manager.Second_name.ToString();
                ManagerSaver.Last_name = manager.Last_name.ToString();
                ManagerSaver.Phone_number = manager.Phone.ToString();
                ManagerSaver.ID = manager.ID;
                MainScreen mainScreen = new MainScreen();
                if(ManagerSaver.ID == 3)
                {
                    FrameManager.MainFrame.Navigate(new LayerContractsPage());

                    FrameManager.MainScreen = mainScreen;
                    FrameManager.MainScreen.Show();
                    FrameManager.MainWindow.Hide();
                }
                else
                {
                    FrameManager.MainFrame.Navigate(new DogovoraPage());

                    FrameManager.MainScreen = mainScreen;
                    FrameManager.MainScreen.Show();
                    FrameManager.MainWindow.Hide();
                }
              
                LoginTextBox.Text = "Логин";
                passwordlable.Text = "Пароль";
                PasswordTextBox.Password = null;
            }
        }

        private void nulltext(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "Логин")
                LoginTextBox.Clear();
        }

        private void ifclear(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "")
                LoginTextBox.Text = "Логин";
        }

        private void nullpassword(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password == null)
                passwordlable.Text = "Пароль";

            if (PasswordTextBox.Password != null)
                passwordlable.Text = "";
        }

        private void passwordclear(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password != null)
                passwordlable.Text = "";

            if (PasswordTextBox.Password == null)
                passwordlable.Text = "Пароль";
        }
    }
}
