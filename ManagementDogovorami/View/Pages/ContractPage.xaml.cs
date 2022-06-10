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
using ManagementDogovorami.View.Pages;

namespace ManagementDogovorami.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractPage.xaml
    /// </summary>
    public partial class ContractPage : Page
    {
        Contracts contract;

        double shtraf_first_part;
        double shtraf_second_part;
        double shtraf_third_part;
        double shtrad_fourth_part;

        double sumfirstpart;
        double sumsecondpart;
        double sumthirdpart;
        double sumfourthpart;

        double oplacheno;
        double itogsumm;

        private Payded[] paydeds;
        private Parts[] parts;

        public ContractPage(Contracts contract)
        {
            InitializeComponent();
            DataContext = contract;
            AvanceDate.Text = contract.Avance_date.ToString();
            this.contract = contract;

            paydeds = contract.Payded.ToArray();



            for (int i = 0; i < paydeds.Length; i++)
            {
                double s = (double)paydeds[i].Sum;
                oplacheno = s + oplacheno;
            }
            TBPayded.Text = oplacheno.ToString();

            double secondpartprocent = 0;
            double thirdpartprocent = 0;
            double fourthpartprocent = 0;

            //заполняем масив частей
            parts = contract.Parts.ToArray();

            //находим и присваиваем сумму первой части
            sumfirstpart = (double)parts[0].Price;


            //находим 1 процент от первой части
            double firstpartprocent = sumfirstpart / 100;

            if (parts.Length >= 2)
            {
                sumsecondpart = (double)parts[1].Price;
                secondpartprocent = sumsecondpart / 100;
            }       
            
            if (parts.Length >= 3)
            {
                sumthirdpart = (double)parts[2].Price;
                thirdpartprocent = sumthirdpart / 100;
            }
            
            if (parts.Length >= 4)
            {
                sumfourthpart = (double)parts[3].Price;
                fourthpartprocent = sumthirdpart / 100;
            }

            //изначально штраф по части равен нулю
            shtraf_first_part = 0;
            shtraf_second_part = 0;
            shtraf_third_part = 0;
            shtrad_fourth_part = 0;

            double summadvuh = 0;
            double summatreh = 0;
            double summachetireh = 0;

            DataContext = contract;

            DateTime startfirst = Convert.ToDateTime(parts[0].Pay_day);



            //заполнение штрафов по 1 части
            for (DateTime i = startfirst; i.Date < DateTime.Today.Date; i = i.AddDays(1))
            {
                if (oplacheno < Convert.ToDouble(parts[0].Price))
                {
                    shtraf_first_part = shtraf_first_part + firstpartprocent;
                }
            }

            

            //заполнение штрафов по 2 части
            if (parts.Length == 2)
            {
                summadvuh = (Convert.ToDouble(parts[0].Price) + Convert.ToDouble(parts[1].Price));
                DateTime startsecond = Convert.ToDateTime(parts[1].Pay_day);
                for (DateTime i = startsecond; i.Date < DateTime.Today.Date; i = i.AddDays(1))
                {
                    if (oplacheno < summadvuh)
                    {
                        shtraf_second_part = shtraf_second_part + secondpartprocent;
                    }
                }
            }


            //заполнение штрафов по 3 части
            if (parts.Length == 3)
            {

                summadvuh = (Convert.ToDouble(parts[0].Price) + Convert.ToDouble(parts[1].Price));
                DateTime startsecond = Convert.ToDateTime(parts[1].Pay_day);
                for (DateTime i = startsecond; i.Date < DateTime.Today.Date; i = i.AddDays(1))
                {
                    if (oplacheno < summadvuh)
                    {
                        shtraf_second_part = shtraf_second_part + secondpartprocent;
                    }
                }

                summatreh = (Convert.ToDouble(parts[0].Price) + Convert.ToDouble(parts[1].Price) + Convert.ToDouble(parts[2].Price));
                DateTime startthird = Convert.ToDateTime(parts[2].Pay_day);
                for (DateTime i = startthird; i.Date < DateTime.Today.Date; i = i.AddDays(1))
                {
                    if (oplacheno < summatreh)
                    {
                        shtraf_third_part = shtraf_third_part + thirdpartprocent;
                    }
                }
            }


            //заполнение штрафов по 4 части
            if (parts.Length == 4)
            {

                summadvuh = (Convert.ToDouble(parts[0].Price) + Convert.ToDouble(parts[1].Price));
                DateTime startsecond = Convert.ToDateTime(parts[1].Pay_day);
                for (DateTime i = startsecond; i.Date < DateTime.Today.Date; i = i.AddDays(1))
                {
                    if (oplacheno < summadvuh)
                    {
                        shtraf_second_part = shtraf_second_part + secondpartprocent;
                    }
                }

                summatreh = (Convert.ToDouble(parts[0].Price) + Convert.ToDouble(parts[1].Price) + Convert.ToDouble(parts[2].Price));
                DateTime startthird = Convert.ToDateTime(parts[2].Pay_day);
                for (DateTime i = startthird; i.Date < DateTime.Today.Date; i = i.AddDays(1))
                {
                    if (oplacheno < summatreh)
                    {
                        shtraf_third_part = shtraf_third_part + thirdpartprocent;
                    }
                }

                summachetireh = (Convert.ToDouble(parts[0].Price) + Convert.ToDouble(parts[1].Price) + Convert.ToDouble(parts[2].Price) + Convert.ToDouble(parts[3].Price));
                DateTime startfourth = Convert.ToDateTime(parts[3].Pay_day);
                for (DateTime i = startfourth; i.Date < DateTime.Today.Date; i = i.AddDays(1))
                {
                    if (oplacheno < summachetireh)
                    {
                        shtrad_fourth_part = shtrad_fourth_part + fourthpartprocent;
                    }
                }
            }

            double shtraf_count = shtrad_fourth_part + shtraf_first_part + shtraf_second_part + shtraf_third_part;
            double summ = Convert.ToDouble(contract.Price);
            itogsumm = shtraf_count + summ;

            //MessageBox.Show("Штраф по 1 части = " + shtraf_first_part);
            //MessageBox.Show("Штраф по 2 части = " + shtraf_second_part);
            //MessageBox.Show("Штраф по 3 части = " + shtraf_third_part);
            //MessageBox.Show("Штраф по 4 части = " + shtrad_fourth_part);





            switch (parts.Count())
            {
                case 1:
                    first_part_date.Text = parts[0].Pay_day.ToString();
                    first_part.Text = parts[0].Price.ToString();
                    break;
                case 2:

                    first_part_date.Text = parts[0].Pay_day.ToString();
                    first_part.Text = parts[0].Price.ToString();

                    secondpartdate.Text = parts[1].Pay_day.ToString();
                    secondpart.Text = parts[1].Price.ToString();
                    break;
                case 3:
                    first_part_date.Text = parts[0].Pay_day.ToString();
                    first_part.Text = parts[0].Price.ToString();

                    secondpartdate.Text= parts[1].Pay_day.ToString();
                    secondpart.Text = parts[1].Price.ToString();

                    thirdpartdate.Text = parts[2].Pay_day.ToString();
                    thirdpart.Text = parts[2].Price.ToString();
                    break;
                case 4:
                    first_part_date.Text = parts[0].Pay_day.ToString();
                    first_part.Text = parts[0].Price.ToString();

                    secondpartdate.Text = parts[1].Pay_day.ToString();
                    secondpart.Text = parts[1].Price.ToString();

                    thirdpartdate.Text = parts[2].Pay_day.ToString();
                    thirdpart.Text = parts[2].Price.ToString();

                    fourthpartdate.Text = parts[3].Pay_day.ToString();
                    fourthpart.Text = parts[3].Price.ToString();
                    break;
            }

            if (parts.Count() == 1)
            {
                seconndvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (parts.Count() == 2)
            {
                seconndvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (parts.Count() == 3)
            {
                fourthvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Visible;
                seconndvisibility.Visibility = Visibility.Visible;
            }

            if (parts.Count() == 4)
            {
                fourthvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Visible;
                seconndvisibility.Visibility = Visibility.Visible;
            }
            
        }

        

        private void MoveToDogovoraPage(object sender, RoutedEventArgs e)
        {
            if(ManagerSaver.ID == 3)
            {
                FrameManager.MainFrame.Navigate(new LayerContractsPage());
            }
            else
            {
                FrameManager.MainFrame.Navigate(new DogovoraPage());
            }
        }

        private void MoveToEditContractPage(object sender, MouseButtonEventArgs e)
        {
            if (ManagerSaver.ID == 3)
            {
                FrameManager.MainFrame.Navigate(new StatusEditLayer((sender as Border).DataContext as Contracts));
            }
            else if (contract.Stasus_id == 1)
            {
                FrameManager.MainFrame.Navigate(new EditContractPage((sender as Border).DataContext as Contracts));
            }
            else MessageBox.Show("Данный договор уже утвержден!");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Сумма оплаты по договору: " + contract.Price + " " + contract.Currencies.Name + "\nОплаченно: " + oplacheno + " " + contract.Currencies.Name + " \nШтраф за неоплату первой части: " + shtraf_first_part + " " + contract.Currencies.Name + "\nШтраф за неуплату второй части: " + shtraf_second_part + " " + contract.Currencies.Name + "\nШтраф за неуплату третьей части: " + shtraf_third_part + " " + contract.Currencies.Name + "\nШтраф за неуплату четвертой части: " + shtrad_fourth_part + " " + contract.Currencies.Name + "\nИтоговая сумма с учетом штрафов: " + itogsumm + " " + contract.Currencies.Name);
        }
    }
}
