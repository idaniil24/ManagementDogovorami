using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ManagementDogovorami.View.Pages;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagementDogovorami
{
    /// <summary>
    /// Логика взаимодействия для MainScreen.xaml
    /// </summary>
    public partial class MainScreen : Window
    {
        public MainScreen()
        {
            InitializeComponent();
            FrameManager.MainFrame = MainFrame;
            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }

        private void MoveToProfilePage(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ProfilePage());
        }

        private void MoveToDogovoraPage(object sender, RoutedEventArgs e)
        {
            if(ManagerSaver.ID == 3)
            {
                FrameManager.MainFrame.Navigate(new LayerContractsPage());
            }
            else
            {
                FrameManager.MainFrame.Navigate(new DogovoraPage());
            }

        }

        private void MoveToClientsPage(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ClientsPage());
        }

        private void MoveToDolgiPage (object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new DolgiPage());
        }

        public static void CloseApp()
        {

        }

    }
}
