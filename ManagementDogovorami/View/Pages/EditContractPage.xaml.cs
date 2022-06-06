using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
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
        private Parts[] parts;
        public EditContractPage(Contracts contract)
        {
            InitializeComponent();


            ComboPartsEdit.Items.Add("1");
            ComboPartsEdit.Items.Add("2");
            ComboPartsEdit.Items.Add("3");
            ComboPartsEdit.Items.Add("4");
            TypeDogovoraEdit.SelectedIndex = 0;

            ComboPartsEdit.SelectedIndex = (int)contract.Parts_count-1;

            ComboClientsEdit.ItemsSource = CM_Entities.GetContext().Clients.ToList();

            TypeDogovoraEdit.ItemsSource = CM_Entities.GetContext().Types.ToList();

            TBManagerEdit.ItemsSource = CM_Entities.GetContext().Manager.Where(x => x.ID == ManagerSaver.ID).ToList();

            TBManagerEdit.SelectedIndex = 0;

            DataContext = contract;
            _currentContranct = contract;

            parts = contract.Parts.ToArray();
            MessageBox.Show(parts.Count().ToString());
            MessageBox.Show(parts.ToString());
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

                    Fourth_part_edit.SelectedDate = parts[3].Pay_day;
                    TBFourthpart.Text = parts[3].Price.ToString();
                    break;
            }
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
                int index = ComboPartsEdit.SelectedIndex;
                _currentContranct.Avance_date = (DateTime)AvanceDate.SelectedDate;

                switch (index)
                {
                    case 0:
                        ////_currentContranct.Parts[0].Pay_day = First_part_date.SelectedDate;
                        parts[0].Price = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        break;
                    case 1:
                        parts[0].Pay_day = First_part_date.SelectedDate;
                        parts[0].Price = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                        parts[1].Pay_day = Second_part_date.SelectedDate;
                        parts[1].Price = decimal.Parse(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        break;
                    case 2:
                        parts[0].Pay_day = First_part_date.SelectedDate;
                        parts[0].Price = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                        parts[1].Pay_day = Second_part_date.SelectedDate;
                        parts[1].Price = decimal.Parse(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                        parts[2].Pay_day = Third_part_date.SelectedDate;
                        parts[2].Price = decimal.Parse(TBThirdpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        break;
                    case 3:

                        parts[0].Pay_day = First_part_date.SelectedDate;
                        parts[0].Price = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                        parts[1].Pay_day = Second_part_date.SelectedDate;
                        parts[1].Price = decimal.Parse(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                        parts[2].Pay_day = Third_part_date.SelectedDate;
                        parts[2].Price = decimal.Parse(TBThirdpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                        parts[3].Pay_day = Fourth_part_edit.SelectedDate;
                        parts[3].Price = decimal.Parse(TBFourthpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        break;
            }

            CM_Entities.GetContext().SaveChanges();

            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }
        
    }
}
