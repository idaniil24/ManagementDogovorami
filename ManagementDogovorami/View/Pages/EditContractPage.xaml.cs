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
    /// Логика взаимодействия для EditContractPage.xaml
    /// </summary>
    public partial class EditContractPage : Page
    {
        private Contracts _currentContranct = new Contracts();
        public EditContractPage(Contracts contract)
        {
            InitializeComponent();


            ComboPartsEdit.Items.Add("1");
            ComboPartsEdit.Items.Add("2");
            ComboPartsEdit.Items.Add("3");
            ComboPartsEdit.Items.Add("4");
            TypeDogovoraEdit.SelectedIndex = 0;

            ComboClientsEdit.ItemsSource = ydodbEntities1.GetContext().Clients.ToList();

            TypeDogovoraEdit.ItemsSource = ydodbEntities1.GetContext().Types.ToList();

            TBManagerEdit.ItemsSource = ydodbEntities1.GetContext().Manager.Where(x => x.ID == ManagerSaver.ID).ToList();

            TBManagerEdit.SelectedIndex = 0;

            if (contract == null)
                DataContext = _currentContranct;
            else
                DataContext = contract;


            if (contract.Parts_count.ToString() == "1")
                ComboPartsEdit.SelectedIndex = 0;
            if (contract.Parts_count.ToString() == "2")
                ComboPartsEdit.SelectedIndex = 1;
            if (contract.Parts_count.ToString() == "3")
                ComboPartsEdit.SelectedIndex = 2;
            if (contract.Parts_count.ToString() == "4")
                ComboPartsEdit.SelectedIndex = 3;
        }

        private void MoveToDogovoraPage(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }
        private void visibilitychanged(object sender, SelectionChangedEventArgs e)
        {

            if (ComboPartsEdit.SelectedIndex == 0)
            {
                seconndvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (ComboPartsEdit.SelectedIndex == 1)
            {
                seconndvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (ComboPartsEdit.SelectedIndex == 2)
            {
                fourthvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Visible;
                seconndvisibility.Visibility = Visibility.Visible;
            }

            if (ComboPartsEdit.SelectedIndex == 3)
            {
                seconndvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Visible;
                fourthvisibility.Visibility = Visibility.Visible;
            }
        }
        private void EditContract_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }
        
    }
}
