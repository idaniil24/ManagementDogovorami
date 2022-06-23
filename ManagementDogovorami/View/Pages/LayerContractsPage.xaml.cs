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
            var currentContracts = CM_Entitiess.GetContext().Contracts.ToList();
            InitializeComponent();

            combotypes.Items.Add("Все статусы");
            combotypes.Items.Add("На рассмотрении");
            combotypes.Items.Add("Утвержден");
            combotypes.Items.Add("Отклонен");
            combotypes.SelectedItem = 1;
            combotypes.SelectedIndex = 0;


            LWContractsLayer.ItemsSource = currentContracts;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ContractPage((sender as Border).DataContext as Contracts));
        }

        private void updateContracts()
        {
            var currentContracts = CM_Entitiess.GetContext().Contracts.ToList();

            int search = 0;
            if (CustomTextBoxLayer.Text != "")
            {
                search = Convert.ToInt32(CustomTextBoxLayer.Text);
            }

            LWContractsLayer.ItemsSource = currentContracts.Where(x => x.ID == search).ToList();
            if (LWContractsLayer.Items.Count == 0)
            {
                LWContractsLayer.ItemsSource = currentContracts;
            }

            if (combotypes.SelectedIndex == 0)
            {
                LWContractsLayer.ItemsSource = currentContracts.Where(x => x.ID == search);
                if (LWContractsLayer.Items.Count == 0)
                {
                    LWContractsLayer.ItemsSource = currentContracts;
                }
            }

            if (combotypes.SelectedIndex == 1)
            {
                LWContractsLayer.ItemsSource = currentContracts.Where(x => x.Stasus_id == 1 && x.ID == search);
                if (LWContractsLayer.Items.Count == 0)
                {
                    LWContractsLayer.ItemsSource = currentContracts.Where(x => x.Stasus_id == 1);
                }
            }
            if (combotypes.SelectedIndex == 2)
            {
                LWContractsLayer.ItemsSource = currentContracts.Where(x => x.Stasus_id == 2 && x.ID == search);
                if (LWContractsLayer.Items.Count == 0)
                {
                    LWContractsLayer.ItemsSource = currentContracts.Where(x => x.Stasus_id == 2);
                }
            }
            if (combotypes.SelectedIndex == 3)
            {
                LWContractsLayer.ItemsSource = currentContracts.Where(x => x.Stasus_id == 3 && x.ID == search);
                if (LWContractsLayer.Items.Count == 0)
                {
                    LWContractsLayer.ItemsSource = currentContracts.Where(x => x.Stasus_id == 3);
                }
            }
        }

        private void CustomTextBoxLayer_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateContracts();
        }

        private void itemfilter(object sender, SelectionChangedEventArgs e)
        {
            updateContracts();
        }
    }
}
