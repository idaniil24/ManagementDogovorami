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
    /// Логика взаимодействия для StatusEditLayer.xaml
    /// </summary>

    public partial class StatusEditLayer : Page
    {
        private Contracts _currentContranct = new Contracts();
        private Parts[] parts;
        public StatusEditLayer(Contracts contranct)
        {
            InitializeComponent();
            _currentContranct = contranct;
            DataContext = contranct;

            //ComboPartsEdit.Items.Add("1");
            //ComboPartsEdit.Items.Add("2");
            //ComboPartsEdit.Items.Add("3");
            //ComboPartsEdit.Items.Add("4");
            //TypeDogovoraEdit.SelectedIndex = 0;

            //ComboPartsEdit.SelectedIndex = (int)contranct.Parts_count - 1;

            //ComboClientsEdit.ItemsSource = CM_Entities.GetContext().Clients.ToList();

            //ComboCurrencies.ItemsSource = CM_Entities.GetContext().Currencies.ToList();

            //TypeDogovoraEdit.ItemsSource = CM_Entities.GetContext().Types.ToList();

            TBManagerEdit.ItemsSource = CM_Entitiess.GetContext().Manager.Where(x => x.ID == ManagerSaver.ID).ToList();

            TBManagerEdit.SelectedIndex = 0;

            ComboStatus.ItemsSource = CM_Entitiess.GetContext().Statuses.ToList();


            parts = contranct.Parts.ToArray();

            if (parts.Length == 1)
            {
                seconndvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (parts.Length == 2)
            {
                seconndvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (parts.Length == 3)
            {
                fourthvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Visible;
                seconndvisibility.Visibility = Visibility.Visible;
            }

            if (parts.Length == 4)
            {
                seconndvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Visible;
                fourthvisibility.Visibility = Visibility.Visible;
            }

            switch (parts.Count())
            {
                case 1:
                    First_part_date.SelectedDate = parts[0].Pay_day;
                    TBFirstpart.Text = parts[0].Price.ToString();
                    //part.Contract_id = currentContract.ID;
                    break;
                case 2:

                    First_part_date.SelectedDate = parts[0].Pay_day;
                    TBFirstpart.Text = parts[0].Price.ToString();

                    Second_part_date.SelectedDate = parts[1].Pay_day;
                    TBSecondpart.Text = parts[1].Price.ToString();
                    break;
                case 3:
                    First_part_date.SelectedDate = parts[0].Pay_day;
                    TBFirstpart.Text = parts[0].Price.ToString();

                    Second_part_date.SelectedDate = parts[1].Pay_day;
                    TBSecondpart.Text = parts[1].Price.ToString();

                    Third_part_date.SelectedDate = parts[2].Pay_day;
                    TBThirdpart.Text = parts[2].Price.ToString();
                    break;
                case 4:
                    First_part_date.SelectedDate = parts[0].Pay_day;
                    TBFirstpart.Text = parts[0].Price.ToString();

                    Second_part_date.SelectedDate = parts[1].Pay_day;
                    TBSecondpart.Text = parts[1].Price.ToString();

                    Third_part_date.SelectedDate = parts[2].Pay_day;
                    TBThirdpart.Text = parts[2].Price.ToString();

                    //Fourth_part_edit.SelectedDate = parts[3].Pay_day;
                    TBFourthpart.Text = parts[3].Price.ToString();
                    break;
            }
        }
    

        private void MoveToDogovoraPage(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new LayerContractsPage());
        }
        private void visibilitychanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        private void partssummary(object sender, TextChangedEventArgs e)
        {

        }
        private void charcheck(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }
        private void EditContract_Click(object sender, RoutedEventArgs e)
        {
            CM_Entitiess.GetContext().SaveChanges();
            MessageBox.Show("Данные успешно изменены");
            FrameManager.MainFrame.Navigate(new LayerContractsPage());
        }
    }
}
