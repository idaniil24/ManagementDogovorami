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

namespace ManagementDogovorami.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для LayerContractsPage.xaml
    /// </summary>
    public partial class LayerContractsPage : Page
    {
        public LayerContractsPage()
        {
            var currentContracts = CM_Entities.GetContext().Contracts.Where(x => x.Stasus_id == 1).ToList();
            InitializeComponent();
            LWContractsLayer.ItemsSource = currentContracts;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ContractPage((sender as Border).DataContext as Contracts));
        }
    }
}
