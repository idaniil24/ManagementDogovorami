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
        decimal first, second, third, fourth, price, avance;
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

            ComboCurrencies.ItemsSource = CM_Entities.GetContext().Currencies.ToList();

            TypeDogovoraEdit.ItemsSource = CM_Entities.GetContext().Types.ToList();

            TBManagerEdit.ItemsSource = CM_Entities.GetContext().Manager.Where(x => x.ID == ManagerSaver.ID).ToList();

            TBManagerEdit.SelectedIndex = 0;


            //AvanceDate.BlackoutDates.AddDatesInPast();

            //First_part_date.BlackoutDates.AddDatesInPast();

            //Second_part_date.BlackoutDates.AddDatesInPast();

            //Third_part_date.BlackoutDates.AddDatesInPast();

            //Fourth_part_edit.BlackoutDates.AddDatesInPast();

            DataContext = contract;
            _currentContranct = contract;

            parts = contract.Parts.ToArray();

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
        private void partssummary(object sender, TextChangedEventArgs e)
        {
            if (((string.IsNullOrEmpty(TBAvanceEdit.Text)) == false) && ((string.IsNullOrEmpty(TBFirstpart.Text)) == false) && ((string.IsNullOrEmpty(TBPriceEdit.Text))
                == false) && (ComboPartsEdit.SelectedIndex == 0))
            {
                avance = decimal.Parse(TBAvanceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                price = decimal.Parse(TBPriceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                first = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            }
            if (((string.IsNullOrEmpty(TBAvanceEdit.Text)) == false) && ((string.IsNullOrEmpty(TBFirstpart.Text)) == false) && ((string.IsNullOrEmpty(TBPriceEdit.Text))
                 == false) && ((string.IsNullOrEmpty(TBSecondpart.Text)) == false) && (ComboPartsEdit.SelectedIndex == 1))
            {
                avance = decimal.Parse(TBAvanceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                price = decimal.Parse(TBPriceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                first = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                second = decimal.Parse(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            }

            if (((string.IsNullOrEmpty(TBAvanceEdit.Text)) == false) && ((string.IsNullOrEmpty(TBFirstpart.Text)) == false) && ((string.IsNullOrEmpty(TBPriceEdit.Text))
                  == false) && ((string.IsNullOrEmpty(TBSecondpart.Text)) == false) && ((string.IsNullOrEmpty(TBThirdpart.Text)) == false) && (ComboPartsEdit.SelectedIndex == 1))
            {
                avance = decimal.Parse(TBAvanceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                price = decimal.Parse(TBPriceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                first = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                second = decimal.Parse(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                third = decimal.Parse(TBThirdpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            }

            if (((string.IsNullOrEmpty(TBAvanceEdit.Text)) == false) && ((string.IsNullOrEmpty(TBFirstpart.Text)) == false) && ((string.IsNullOrEmpty(TBPriceEdit.Text))
                 == false) && ((string.IsNullOrEmpty(TBSecondpart.Text)) == false)
                 && ((string.IsNullOrEmpty(TBThirdpart.Text)) == false) && ((string.IsNullOrEmpty(TBFourthpart.Text)) == false) && (ComboPartsEdit.SelectedIndex == 1))
            {
                avance = decimal.Parse(TBAvanceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                price = decimal.Parse(TBPriceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                first = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                second = decimal.Parse(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                third = decimal.Parse(TBThirdpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                fourth = decimal.Parse(TBFourthpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
            }

        }
        private void charcheck(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }

        private void EditContract_Click(object sender, RoutedEventArgs e)
        {


            if (ComboClientsEdit.SelectedIndex <= -1)
            {
                MessageBox.Show("Выберете клиента!");
                return;
            }
            else if (ComboCurrencies.SelectedIndex <= -1)
            {
                MessageBox.Show("Выберете валюту контракта!");
                return;
            }
            else if (ComboPartsEdit.SelectedIndex <= -1)
            {
                MessageBox.Show("Выберите количество частей оплаты!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TBPriceEdit.Text))
            {
                MessageBox.Show("Введите сумму по контракту!");
                return;
            }
            else if (TypeDogovoraEdit.SelectedIndex <= -1)
            {
                MessageBox.Show("Выберите тип договора!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TBAvanceEdit.Text))
            {
                MessageBox.Show("Введите сумму аванса");
            }
            else if (string.IsNullOrWhiteSpace(TBFirstpart.Text))
            {
                MessageBox.Show("Введите сумму первой части!");
                return;
            }
            else if ((string.IsNullOrWhiteSpace(TBSecondpart.Text)) && (ComboPartsEdit.SelectedIndex >= 1))
            {
                MessageBox.Show("Введите сумму второй части!");
                return;
            }
            else if ((string.IsNullOrWhiteSpace(TBThirdpart.Text)) && (ComboPartsEdit.SelectedIndex >= 2))
            {
                MessageBox.Show("Введите сумму третьей части!");
                return;
            }
            else if ((string.IsNullOrWhiteSpace(TBFourthpart.Text)) && (ComboPartsEdit.SelectedIndex >= 3))
            {
                MessageBox.Show("Введите сумму четвертой части");
                return;
            }
            else if ((first + second + third + fourth) > price)
            {
                avance = decimal.Parse(TBAvanceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                price = decimal.Parse(TBPriceEdit.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                first = decimal.Parse(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                MessageBox.Show("Сумма всех частей не может быть больше суммы по договору!");
                return;
            }
            else if ((first + second + third + fourth + avance) < price)
            {
                MessageBox.Show("Сумма всех частей не может быть меньше суммы по договору!");
            }
            else if (AvanceDate.SelectedDate > First_part_date.SelectedDate)
            {
                MessageBox.Show("Дата оплаты аванса не может быть позже чем дата оплаты первой части");
            }
            else if (((AvanceDate.SelectedDate > Second_part_date.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 1))
                || ((First_part_date.SelectedDate > Second_part_date.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 1)) || ((First_part_date.SelectedDate > Third_part_date.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 2))
                || ((First_part_date.SelectedDate > Fourth_part_edit.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 3)) || ((Second_part_date.SelectedDate > Third_part_date.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 2))
                || ((Second_part_date.SelectedDate > Fourth_part_edit.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 3)) || (AvanceDate.SelectedDate > First_part_date.SelectedDate) || ((AvanceDate.SelectedDate > Third_part_date.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 2))
                || ((AvanceDate.SelectedDate > Fourth_part_edit.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 3)) || ((Third_part_date.SelectedDate > Fourth_part_edit.SelectedDate) && (ComboPartsEdit.SelectedIndex >= 3)))
            {
                MessageBox.Show("Не верно указанны даты! Дата первой части не может быть позже второй и т.д.");
            }
            else
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
                MessageBox.Show("Данные успешно изменены");
                FrameManager.MainFrame.Navigate(new DogovoraPage());
            }

           
        }
        
    }
}
