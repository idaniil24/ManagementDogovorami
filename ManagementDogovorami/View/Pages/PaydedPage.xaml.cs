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
using ManagementDogovorami.View;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementDogovorami.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PaydedPage.xaml
    /// </summary>
    public partial class PaydedPage : Page
    {

        Contracts contract;
        public PaydedPage(Contracts contract)
        {
            InitializeComponent();
            DataContext = contract;
            this.contract = contract;
            DGridPaydeds.ItemsSource = contract.Payded1.ToList();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ManagerSaver.ID == 3)
            {
                FrameManager.MainFrame.GoBack();
            }
            else
            {
                FrameManager.MainFrame.GoBack();
            }

        }
    }
}
