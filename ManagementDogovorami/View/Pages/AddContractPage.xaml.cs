using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Messaging;
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
    /// Логика взаимодействия для AddContractPage.xaml
    /// </summary>
    public partial class AddContractPage : Page
    {
        public decimal first, second, third, fourth, price, avance;
        private Contracts _currentContranct = new Contracts();
        public AddContractPage(Contracts contract = null)
        {
            InitializeComponent();
            ComboParts.Items.Add("1");
            ComboParts.Items.Add("2");
            ComboParts.Items.Add("3");
            ComboParts.Items.Add("4");

            second = 0;
            third = 0;
            fourth = 0;

            TypeDogovora.SelectedIndex = 0;

            ComboClients.ItemsSource = CM_Entitiess.GetContext().Clients.ToList();

            TypeDogovora.ItemsSource = CM_Entitiess.GetContext().Types.ToList();

            ComboCurrencies.ItemsSource = CM_Entitiess.GetContext().Currencies.ToList();

            TBManager.ItemsSource = CM_Entitiess.GetContext().Manager.Where(x => x.ID == ManagerSaver.ID).ToList();

            TBManager.SelectedIndex = 0;

            TBStatus.ItemsSource = CM_Entitiess.GetContext().Statuses.ToList();

            TBStatus.SelectedIndex = 0;

            ComboClients.SelectedIndex = 0;

            ComboCurrencies.SelectedIndex = 0;

            AvanceDate.BlackoutDates.AddDatesInPast();

            First_part_date.BlackoutDates.AddDatesInPast();

            Second_part_date.BlackoutDates.AddDatesInPast();

            Third_part_date.BlackoutDates.AddDatesInPast();

            Fourth_part_date.BlackoutDates.AddDatesInPast();


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

        private void TBPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(TBPrice.Text)))
            {
                MessageBox.Show("Заполните сумму по договору");
            }
            else avance = decimal.Parse(TBPrice.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
        }

        private void partssummary(object sender, TextChangedEventArgs e)
        {

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

            price = decimal.Parse(TBPrice.Text);

            if (ComboClients.SelectedIndex <= -1)
            {
                MessageBox.Show("Выберете клиента!");
                return;
            }
            else if (ComboCurrencies.SelectedIndex <= -1)
            {
                MessageBox.Show("Выберете валюту контракта!");
                return;
            }
            else if (ComboParts.SelectedIndex <= -1)
            {
                MessageBox.Show("Выберите количество частей оплаты!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TBPrice.Text))
            {
                MessageBox.Show("Введите сумму по контракту!");
                return;
            }
            else if (TypeDogovora.SelectedIndex <= -1)
            {
                MessageBox.Show("Выберите тип договора!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TBAvance.Text))
            {
                MessageBox.Show("Введите сумму аванса");
            }
            else if (string.IsNullOrWhiteSpace(TBFirstpart.Text))
            {
                MessageBox.Show("Введите сумму первой части!");
                return;
            }
            else if ((string.IsNullOrWhiteSpace(TBSecondpart.Text)) && (ComboParts.SelectedIndex >= 1))
            {
                MessageBox.Show("Введите сумму второй части!");
                return;
            }
            else if ((string.IsNullOrWhiteSpace(TBThirdpart.Text)) && (ComboParts.SelectedIndex >= 2))
            {
                MessageBox.Show("Введите сумму третьей части!");
                return;
            }
            else if ((string.IsNullOrWhiteSpace(TBFourthpart.Text)) && (ComboParts.SelectedIndex >= 3))
            {
                MessageBox.Show("Введите сумму четвертой части");
                return;
            }
            else if ((string.IsNullOrWhiteSpace(TBProcent.Text)))
            {
                MessageBox.Show("Введите процент штрафных ссанкций");
                return;
            }
            else if (AvanceDate.SelectedDate > First_part_date.SelectedDate)
            {
                MessageBox.Show("Дата оплаты аванса не может быть позже чем дата оплаты первой части");
                return;
            }
            else if(price == 0)
            {
                MessageBox.Show("Сумма по договору не может быть равна нулю!");
                return;
            }
            else if (((AvanceDate.SelectedDate > Second_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 1))
                || ((First_part_date.SelectedDate > Second_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 1)) || ((First_part_date.SelectedDate > Third_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 2))
                || ((First_part_date.SelectedDate > Fourth_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 3)) || ((Second_part_date.SelectedDate > Third_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 2))
                || ((Second_part_date.SelectedDate > Fourth_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 3)) || (AvanceDate.SelectedDate > First_part_date.SelectedDate) || ((AvanceDate.SelectedDate > Third_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 2))
                || ((AvanceDate.SelectedDate > Fourth_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 3)) || ((Third_part_date.SelectedDate > Fourth_part_date.SelectedDate) && (ComboParts.SelectedIndex >= 3)))
            {
                MessageBox.Show("Не верно указанны даты! Дата первой части не может быть позже второй и т.д.");
                return;
            }
            else
            {
                price = decimal.Parse(TBPrice.Text);
                avance = decimal.Parse(TBAvance.Text);
                first = decimal.Parse(TBFirstpart.Text);
                if (ComboParts.Text == "2")
                {
                    second = decimal.Parse(TBSecondpart.Text);
                }
                if (ComboParts.Text == "3")
                {
                    second = decimal.Parse(TBSecondpart.Text);
                    third = decimal.Parse(TBThirdpart.Text);
                }
                if (ComboParts.Text == "4")
                {
                    second = decimal.Parse(TBSecondpart.Text);
                    third = decimal.Parse(TBThirdpart.Text);
                    fourth = decimal.Parse(TBFourthpart.Text);
                }
                if (price != avance + first + second + third + fourth)
                {
                    MessageBox.Show("Сумма всех частей не может быть больше или меньше суммы по договору!");
                    return;
                }

                int index = ComboParts.SelectedIndex;
                TBStatus.SelectedIndex = 0;
                TBManager.SelectedIndex = 0;
                _currentContranct.Avance_date = (DateTime)AvanceDate.SelectedDate;
                Contracts currentContract = CM_Entitiess.GetContext().Contracts.Add(_currentContranct);

                switch (index)
                {
                    case 0:
                        Parts part = new Parts();
                        part.Pay_day = First_part_date.SelectedDate;
                        part.Price = Convert.ToInt32(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part.Contract_id = currentContract.ID;

                        CM_Entitiess.GetContext().Parts.Add(part);
                        break;
                    case 1:
                        Parts part1 = new Parts();
                        Parts part2 = new Parts();

                        part1.Pay_day = First_part_date.SelectedDate;
                        part1.Price = Convert.ToInt32(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part1.Contract_id = currentContract.ID;

                        part2.Pay_day = Second_part_date.SelectedDate;
                        part2.Price = Convert.ToInt32(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part2.Contract_id = currentContract.ID;

                        CM_Entitiess.GetContext().Parts.Add(part1);
                        CM_Entitiess.GetContext().Parts.Add(part2);
                        break;
                    case 2:
                        Parts part3 = new Parts();
                        Parts part4 = new Parts();
                        Parts part5 = new Parts();

                        part3.Pay_day = First_part_date.SelectedDate;
                        part3.Price = Convert.ToInt32(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part3.Contract_id = currentContract.ID;

                        part4.Pay_day = Second_part_date.SelectedDate;
                        part4.Price = Convert.ToInt32(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part4.Contract_id = currentContract.ID;

                        part5.Pay_day = Third_part_date.SelectedDate;
                        part5.Price = Convert.ToInt32(TBThirdpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part5.Contract_id = currentContract.ID;

                        CM_Entitiess.GetContext().Parts.Add(part3);
                        CM_Entitiess.GetContext().Parts.Add(part4);
                        CM_Entitiess.GetContext().Parts.Add(part5);
                        break;
                    case 3:
                        Parts part6 = new Parts();
                        Parts part7 = new Parts();
                        Parts part8 = new Parts();
                        Parts part9 = new Parts();

                        part6.Pay_day = First_part_date.SelectedDate;
                        part6.Price = Convert.ToInt32(TBFirstpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part6.Contract_id = currentContract.ID;

                        part7.Pay_day = Second_part_date.SelectedDate;
                        part7.Price = Convert.ToInt32(TBSecondpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part7.Contract_id = currentContract.ID;

                        part8.Pay_day = Third_part_date.SelectedDate;
                        part8.Price = Convert.ToInt32(TBThirdpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part8.Contract_id = currentContract.ID;

                        part9.Pay_day = Fourth_part_date.SelectedDate;
                        part9.Price = Convert.ToInt32(TBFourthpart.Text.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                        part9.Contract_id = currentContract.ID;


                        CM_Entitiess.GetContext().Parts.Add(part6);
                        CM_Entitiess.GetContext().Parts.Add(part7);
                        CM_Entitiess.GetContext().Parts.Add(part8);
                        CM_Entitiess.GetContext().Parts.Add(part9);
                        break;
                }


                CM_Entitiess.GetContext().SaveChanges();
                MessageBox.Show("Договор успешно создан!");

                FrameManager.MainFrame.Navigate(new DogovoraPage());
            }       
        }

        private void charcheck(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789.".IndexOf(e.Text) < 0;
        }

    }
}
