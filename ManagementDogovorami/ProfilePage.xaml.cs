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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            FirstNameLW.Text = ManagerSaver.First_name.ToString();
            SecondNameLW.Text = ManagerSaver.Second_name.ToString();
            LastNameLW.Text = ManagerSaver.Last_name.ToString();
            LoginLW.Text = ManagerSaver.Login.ToString();
            NumberLW.Text = ManagerSaver.Phone_number.ToString();
        }
        private void moveToLogin(object sender, MouseButtonEventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.Close();
            Application.Current.MainWindow.Close();
            //mainScreen.CloseApp();
            Application.Current.MainWindow = mainScreen;
            Application.Current.MainWindow.Close();
            mainScreen.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

    }
}
