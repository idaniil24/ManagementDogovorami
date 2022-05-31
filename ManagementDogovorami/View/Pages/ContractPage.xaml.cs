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
using ManagementDogovorami.View.Pages;

namespace ManagementDogovorami.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        Contracts contract;
        public ContractPage(Contracts contract)
        {
            InitializeComponent();
            DataContext = contract;
            this.contract = contract;
        }

        private void MoveToDogovoraPage(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }

        private void MoveToEditContractPage(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new EditContractPage((sender as Border).DataContext as Contracts));
        }
    }
}
