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
            var currentContracts = CM_Entitiess.GetContext().Contracts.Where(x => x.Manager_id == ManagerSaver.ID).ToList();
            InitializeComponent();
            LWContracts.ItemsSource = currentContracts;
            combotypes.Items.Add("Все статусы");
            combotypes.Items.Add("На рассмотрении");
            combotypes.Items.Add("Утвержден");
            combotypes.Items.Add("Отклонен");
            combotypes.SelectedItem = 1;
            combotypes.SelectedIndex = 0;

        }

        private void moveToAddContract(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new AddContractPage());
        }

        private void MoveToShowContract(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ContractPage((sender as Border).DataContext as Contracts));
        }

        private void updateContracts()
        {
            var currentContracts = CM_Entitiess.GetContext().Contracts.Where(x => x.Manager_id == ManagerSaver.ID).ToList();

            int search = 0;
            if (CustomTextBoxLayer.Text != "")
            {
                search = Convert.ToInt32(CustomTextBoxLayer.Text);
            }

            LWContracts.ItemsSource = currentContracts.Where(x => (x.ID == search) && (x.Manager_id == ManagerSaver.ID)).ToList();
            if (LWContracts.Items.Count == 0)
            {
                LWContracts.ItemsSource = currentContracts;
            }

            if (combotypes.SelectedIndex == 0)
            {
                LWContracts.ItemsSource = currentContracts.Where(x => (x.ID == search) && (x.Manager_id == ManagerSaver.ID)).ToList();
                if (LWContracts.Items.Count == 0)
                {
                    LWContracts.ItemsSource = currentContracts;
                }
            }

            if (combotypes.SelectedIndex == 1)
            {
                LWContracts.ItemsSource = currentContracts.Where(x => x.Stasus_id == 1 && x.ID == search && x.Manager_id == ManagerSaver.ID);
                if (LWContracts.Items.Count == 0)
                {
                    LWContracts.ItemsSource = currentContracts.Where(x => x.Stasus_id == 1 && x.Manager_id == ManagerSaver.ID);
                }
            }
            if (combotypes.SelectedIndex == 2)
            {
                LWContracts.ItemsSource = currentContracts.Where(x => x.Stasus_id == 2 && x.ID == search && x.Manager_id == ManagerSaver.ID);
                if (LWContracts.Items.Count == 0)
                {
                    LWContracts.ItemsSource = currentContracts.Where(x => x.Stasus_id == 2 && x.Manager_id == ManagerSaver.ID);
                }
            }
            if (combotypes.SelectedIndex == 3)
            {
                LWContracts.ItemsSource = currentContracts.Where(x => x.Stasus_id == 3 && x.ID == search && x.Manager_id == ManagerSaver.ID);
                if (LWContracts.Items.Count == 0)
                {
                    LWContracts.ItemsSource = currentContracts.Where(x => x.Stasus_id == 3 && x.Manager_id == ManagerSaver.ID);
                }
            }
        }

        private void textupdate(object sender, TextChangedEventArgs e)
        {
            updateContracts();
        }

        private void onlycifri(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }

        private void combotypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateContracts();
        }
    }
}
