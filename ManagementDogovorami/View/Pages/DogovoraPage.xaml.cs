using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ManagementDogovorami.View.Pages;
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
    /// Логика взаимодействия для DogovoraPage.xaml
    /// </summary>
    public partial class DogovoraPage : Page
    {
        public DogovoraPage()
        {
            var currentContracts = CM_Entities.GetContext().Contracts.Where(x => x.Manager_id == ManagerSaver.ID).ToList();
            InitializeComponent();
            LWContracts.ItemsSource = currentContracts; 
        }

        private void moveToAddContract(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddContractPage());
        }

        private void MoveToShowContract(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ContractPage((sender as Border).DataContext as Contracts));
        }
    }
}
