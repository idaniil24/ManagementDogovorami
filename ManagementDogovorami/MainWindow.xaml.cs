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

namespace ManagementDogovorami
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string login;
        public string password;        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            login = LoginTextBox.Text;
            password = PasswordTextBox.Text;
        }

        private void MoveToMainScreen(object sender, RoutedEventArgs e)
        {
            login = LoginTextBox.Text;
            password = PasswordTextBox.Text;
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
            else if (ydodbEntities.GetContext().Manager.Where(x => x.Login == login && x.Password == password).Count() == 0)
            {
                MessageBox.Show("Такого пользователя не существует!");
                return;
            }
            else
            {
                manager = ydodbEntities.GetContext().Manager.Where(x => x.Login == login && x.Password == password).First();
                ManagerSaver.Login = login;
                ManagerSaver.First_name = manager.First_name.ToString();
                ManagerSaver.Second_name = manager.Second_name.ToString();
                ManagerSaver.Last_name = manager.Last_name.ToString();
                ManagerSaver.Phone_number = manager.Phone.ToString();

                MainScreen mainScreen = new MainScreen();
                mainScreen.Show();
                this.Hide();
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
            if(PasswordTextBox.Text == "Пароль")
                PasswordTextBox.Clear();
        }

        private void passwordclear(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Text == "")
                PasswordTextBox.Text = "Пароль";
        }
    }
}
