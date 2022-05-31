using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
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
    /// Логика взаимодействия для AddContractPage.xaml
    /// </summary>
    public partial class AddContractPage : Page
    {
        private Contracts _currentContranct = new Contracts();
        public AddContractPage(Contracts contract = null)
        {
            InitializeComponent();
            ComboParts.Items.Add("1");
            ComboParts.Items.Add("2");
            ComboParts.Items.Add("3");
            ComboParts.Items.Add("4");
            TypeDogovora.SelectedIndex = 0;

            ComboClients.ItemsSource = ydodbEntities1.GetContext().Clients.ToList();

            TypeDogovora.ItemsSource = ydodbEntities1.GetContext().Types.ToList();

            TBManager.ItemsSource = ydodbEntities1.GetContext().Manager.Where(x => x.ID == ManagerSaver.ID).ToList();

            TBManager.SelectedIndex = 0;

            if (contract == null)
                DataContext = _currentContranct;
            else
                DataContext = contract;

            //if (contract.Parts_count.ToString() == "1")
            //    ComboParts.SelectedIndex = 0;
            //if (contract.Parts_count.ToString() == "2")
            //    ComboParts.SelectedIndex = 1;
            //if (contract.Parts_count.ToString() == "3")
            //    ComboParts.SelectedIndex = 2;
            //if (contract.Parts_count.ToString() == "4")
            //    ComboParts.SelectedIndex = 3;
        }
        private void MoveToDogovoraPage(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }

        private void visibilitychanged(object sender, SelectionChangedEventArgs e)
        {

            if (ComboParts.SelectedIndex == 0)
            {
                seconndvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (ComboParts.SelectedIndex == 1)
            {
                seconndvisibility.Visibility= Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (ComboParts.SelectedIndex == 2)
            {
                fourthvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Visible;
                seconndvisibility.Visibility = Visibility.Visible;
            }

            if (ComboParts.SelectedIndex == 3)
            {
                seconndvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Visible;
                fourthvisibility.Visibility = Visibility.Visible;
            }
        }

        private void CreateContract_Click(object sender, RoutedEventArgs e)
        {
            TBManager.SelectedIndex = 0;
            ydodbEntities1.GetContext().Contracts.Add(_currentContranct);
            ydodbEntities1.GetContext().SaveChanges();

            MessageBox.Show("Данные успешно сохранены!");

            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }
    }
}
