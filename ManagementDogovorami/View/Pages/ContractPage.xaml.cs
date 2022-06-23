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

        double dolg;


        double oplacheno;

        private Payded[] paydeds;
        private Parts[] parts;

        double oplachenopostavance = 0;
        int prosrochkadaysavavnce = 0;
        double penipoavance = 0;
        double pastdolg = 0;

        double oplachenopostfirstpart = 0;
        int prosrochkadaysfp = 0;
        double penipfp = 0;
        double oplachenodofp = 0;

        double oplachenodosp = 0;
        double oplachenoposp = 0;
        int prosrochkadayssp = 0;
        double peniposp = 0;

        double oplachenodothp = 0;
        double oplachenopostthp = 0;
        int prosrochkaysthp = 0;
        double penipothp = 0;

        double oplachenodoforthp = 0;
        double oplachenopostfourthp = 0;
        int prosrochkadaysforthpart = 0;
        double penipofourthp = 0;

        double dolgitog = 0;
        double dolgpodog = 0;

        public ContractPage(Contracts contract)
        {
            InitializeComponent();
            DataContext = contract;
            AvanceDate.Text = contract.Avance_date.ToString();
            this.contract = contract;

            paydeds = contract.Payded1.ToArray();

            for (int i = 0; i < paydeds.Length; i++)
            {
                double s = (double)paydeds[i].Sum;
                oplacheno = s + oplacheno;
            }
            TBPayded.Text = oplacheno.ToString();



            PartsCount.Text = contract.Parts_count.ToString();
            

            //заполняем масив частей
            parts = contract.Parts.ToArray();

            //выводим их
            switch (contract.Parts_count)
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

                    secondpartdate.Text = parts[1].Pay_day.ToString();
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

            if (contract.Parts_count == 1)
            {
                seconndvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (contract.Parts_count == 2)
            {
                seconndvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Hidden;
                fourthvisibility.Visibility = Visibility.Hidden;
            }

            if (contract.Parts_count == 3)
            {
                fourthvisibility.Visibility = Visibility.Hidden;
                thirdvisibility.Visibility = Visibility.Visible;
                seconndvisibility.Visibility = Visibility.Visible;
            }

            if (contract.Parts_count == 4)
            {
                fourthvisibility.Visibility = Visibility.Visible;
                thirdvisibility.Visibility = Visibility.Visible;
                seconndvisibility.Visibility = Visibility.Visible;
            }




            //IHATESHARAGA
            //находим сколько оплачено до аванса
            double oplachenodoavance = 0;

            paydeds = contract.Payded1.Where(x => x.Pay_date < contract.Avance_date).ToArray();

            for (int i = 0; i < paydeds.Length; i++)
            {
                double s = (double)paydeds[i].Sum;
                oplachenodoavance = s + oplachenodoavance;
            }

            if (oplachenodoavance < Convert.ToDouble(contract.Avance))
            {
                DateTime avancedate = contract.Avance_date;
                for (DateTime i = avancedate; oplachenopostavance <= Convert.ToDouble(contract.Avance); i = i.AddDays(1))
                {

                    if (i > DateTime.Today)
                    {
                        break;
                    }

                    paydeds = contract.Payded1.Where(x => x.Pay_date < i).ToArray();

                    for (int j = 0; j < paydeds.Length; j++)
                    {
                        double s = (double)paydeds[j].Sum;
                        oplachenopostavance = s + oplachenopostavance;
                    }

                    if (oplachenopostavance < Convert.ToDouble(contract.Avance))
                    {
                        dolg = Convert.ToDouble(contract.Avance) - oplachenopostavance;
                        prosrochkadaysavavnce = prosrochkadaysavavnce + 1;

                        penipoavance = (double)(dolg * prosrochkadaysavavnce * (Convert.ToDouble(contract.Shtraf_procent) / 100));
                        if (pastdolg > penipoavance)
                        {
                            penipoavance = penipoavance + pastdolg;
                        }
                    }
                    else
                    {
                        dolg = 0;
                        break;
                    }

                    if (i == DateTime.Today && oplachenopostavance < Convert.ToDouble(contract.Avance))
                    {
                        //    MessageBox.Show("Договор просрочен на " + prosrochkadaysavavnce + " дней и до сих пор не оплачен" +
                        //        "\nПени по авансу на сегодняшний день: " + penipoavance + " " + contract.Currencies.Name);
                        break;
                    }

                    oplachenopostavance = 0;

                    pastdolg = penipoavance;
                }
            }
            //проверим подсчеты долга по авансу
            //MessageBox.Show("Оплаченно до аванса и после:" + oplachenodoavance + " " + oplachenopostavance
            //    + "\n Пени и просроченные дни: " + penipoavance + " " + prosrochkadaysavavnce + " " + dolg);



            //найдем долг по 1ч 


            //находим сколько оплаченно до даты 1 части
            paydeds = contract.Payded1.Where(x => x.Pay_date < parts[0].Pay_day).ToArray();
            for (int i = 0; i < paydeds.Length; i++)
            {
                double s = (double)paydeds[i].Sum;
                oplachenodofp = s + oplachenodofp;
            }


            //найдем сумму аванса и 1 части
            double sumafp = 0;
            sumafp = (double)(contract.Avance + parts[0].Price);

            //ищем долг по первой части
            if (oplachenodofp < sumafp)
            {
                DateTime fpdate = (DateTime)parts[0].Pay_day;
                for (DateTime i = fpdate; oplachenopostfirstpart <= sumafp; i = i.AddDays(1))
                {
                    paydeds = contract.Payded1.Where(x => x.Pay_date < i).ToArray();

                    if (i > DateTime.Today)
                    {

                        break;
                    }

                    for (int j = 0; j < paydeds.Length; j++)
                    {
                        double s = (double)paydeds[j].Sum;
                        oplachenopostfirstpart = s + oplachenopostfirstpart;
                    }

                    if (oplachenopostfirstpart < sumafp)
                    {
                        dolg = sumafp - oplachenopostfirstpart;
                        prosrochkadaysfp = prosrochkadaysfp + 1;

                        penipfp = (double)(dolg * prosrochkadaysfp * (Convert.ToDouble(contract.Shtraf_procent) / 100));
                        if (pastdolg > penipfp)
                        {
                            penipfp = penipfp + pastdolg;
                        }
                    }
                    else
                    {
                        dolg = 0;
                        break;
                    }

                    if (i == DateTime.Today && oplachenopostfirstpart < sumafp)
                    {
                        //MessageBox.Show("Договор просрочен на " + prosrochkadaysfp + " дней и до сих пор не оплачен" +
                        //    "\nПени по авансу на сегодняшний день: " + penipfp + " " + contract.Currencies.Name);
                        break;
                    }

                    oplachenopostfirstpart = 0;

                    pastdolg = penipfp;


                }
            }


            double sumasp = 0;
            //находим сколько оплаченно по 2 части
            if ((PartsCount.Text.ToString() == "4") || (PartsCount.Text.ToString() == "3") || (PartsCount.Text.ToString() == "2"))
            {
                paydeds = contract.Payded1.Where(x => x.Pay_date < parts[1].Pay_day).ToArray();
                for (int i = 0; i < paydeds.Length; i++)
                {
                    double s = (double)paydeds[i].Sum;
                    oplachenodosp = s + oplachenodosp;
                }


                //найдем сумму аванса и 1 2 части

                sumasp = (double)(contract.Avance + parts[0].Price + parts[1].Price);
                //ищем долг по первой части
                if (oplachenodosp < sumasp)
                {
                    DateTime spdate = (DateTime)parts[1].Pay_day;
                    for (DateTime i = spdate; oplachenoposp <= sumasp; i = i.AddDays(1))
                    {
                        paydeds = contract.Payded1.Where(x => x.Pay_date < i).ToArray();


                        if (i > DateTime.Today)
                        {
                            break;
                        }

                        for (int j = 0; j < paydeds.Length; j++)
                        {
                            double s = (double)paydeds[j].Sum;
                            oplachenoposp = s + oplachenoposp;
                        }

                        if (oplachenoposp < sumasp)
                        {
                            dolg = sumasp - oplachenoposp;
                            prosrochkadayssp = prosrochkadayssp + 1;

                            peniposp = (double)(dolg * prosrochkadayssp * (Convert.ToDouble(contract.Shtraf_procent) / 100));

                            if (pastdolg > peniposp)
                            {
                                peniposp = peniposp + pastdolg;
                            }
                        }
                        else
                        {
                            dolg = 0;
                            break;
                        }

                        if (i == DateTime.Today && oplachenoposp < sumasp)
                        {
                            //MessageBox.Show("Договор просрочен на " + prosrochkadaysfp + " дней и до сих пор не оплачен" +
                            //    "\nПени по авансу на сегодняшний день: " + penipfp + " " + contract.Currencies.Name);
                            break;
                        }
                        oplachenoposp = 0;

                        pastdolg = penipfp;

                    }
                }

            }


            double sumathp = 0;
            //находим сколько оплаченно по 3 части
            if ((PartsCount.Text == "4") || (PartsCount.Text == "3"))
            {
                paydeds = contract.Payded1.Where(x => x.Pay_date < parts[2].Pay_day).ToArray();
                for (int i = 0; i < paydeds.Length; i++)
                {
                    double s = (double)paydeds[i].Sum;
                    oplachenodothp = s + oplachenodothp;
                }


                //найдем сумму аванса и 1 2 части
                sumathp = (double)(contract.Avance + parts[0].Price + parts[1].Price + parts[2].Price);
                //ищем долг по первой части
                if (oplachenodosp < sumathp)
                {
                    DateTime thpdate = (DateTime)parts[2].Pay_day;
                    for (DateTime i = thpdate; oplachenopostthp <= sumathp; i = i.AddDays(1))
                    {
                        if (i > DateTime.Today)
                        {
                            break;
                        }

                        paydeds = contract.Payded1.Where(x => x.Pay_date < i).ToArray();

                        for (int j = 0; j < paydeds.Length; j++)
                        {
                            double s = (double)paydeds[j].Sum;
                            oplachenopostthp = s + oplachenopostthp;
                        }

                        if (oplachenopostthp < sumathp)
                        {
                            dolg = sumathp - oplachenopostthp;
                            prosrochkaysthp = prosrochkaysthp + 1;

                            penipothp = (double)(dolg * prosrochkaysthp * (Convert.ToDouble(contract.Shtraf_procent) / 100));

                            if (pastdolg > penipothp)
                            {
                                penipothp = penipothp + pastdolg;
                            }
                        }
                        else
                        {
                            dolg = 0;
                            break;
                        }

                        if (i == DateTime.Today && oplachenopostthp < sumathp)
                        {
                            break;
                        }


                        oplachenopostthp = 0;

                        pastdolg = penipfp;

                    }

                }

            }

            double sumafourp = 0;

            //находим сколько оплаченно по 4 части
            if (PartsCount.Text.ToString() == "4")
            {
                paydeds = contract.Payded1.Where(x => x.Pay_date < parts[3].Pay_day).ToArray();

                for (int i = 0; i < paydeds.Length; i++)
                {
                    double s = (double)paydeds[i].Sum;
                    oplachenodoforthp = s + oplachenodoforthp;
                }

                //найдем сумму аванса и 1 2 части

                sumafourp = (double)(contract.Avance + parts[0].Price + parts[1].Price + parts[2].Price + parts[3].Price);
                //ищем долг по первой части
                if (oplachenodoforthp < sumafourp)
                {
                    DateTime fourthpdate = (DateTime)parts[3].Pay_day;
                    for (DateTime i = fourthpdate; oplachenopostfourthp <= sumafourp; i = i.AddDays(1))
                    {


                        if (i > DateTime.Today)
                        {
                            break;
                        }

                        paydeds = contract.Payded1.Where(x => x.Pay_date < i).ToArray();

                        for (int j = 0; j < paydeds.Length; j++)
                        {
                            double s = (double)paydeds[j].Sum;
                            oplachenopostfourthp = s + oplachenopostfourthp;
                        }

                        MessageBox.Show(oplachenopostfourthp.ToString());
                        MessageBox.Show(sumafourp.ToString());

                        if (oplachenopostfourthp < sumafourp)
                        {
                            dolg = sumafourp - oplachenopostfourthp;
                            prosrochkadaysforthpart = prosrochkadaysforthpart + 1;

                            penipofourthp = (double)(dolg * prosrochkadaysforthpart * (Convert.ToDouble(contract.Shtraf_procent) / 100));

                            if (pastdolg > penipofourthp)
                            {
                                penipofourthp = penipofourthp + pastdolg;
                            }
                        }
                        else
                        {
                            dolg = 0;
                            break;
                        }

                        if (i == DateTime.Today && oplachenopostfourthp < sumafourp)
                        {
                            break;
                        }


                        oplachenopostfourthp = 0;

                        pastdolg = penipofourthp;

                    }
                }


            }

            if (oplacheno < sumafp && parts[0].Pay_day <= DateTime.Today)
            {
                dolgpodog = Convert.ToDouble(sumafp - oplacheno);
            }
            if (oplacheno < sumasp && parts[1].Pay_day <= DateTime.Today)
            {
                dolgpodog = Convert.ToDouble(sumasp - oplacheno);
            }

            if (oplacheno < sumathp && parts[2].Pay_day <= DateTime.Today)
            {
                dolgpodog = Convert.ToDouble(sumathp - oplacheno);
            }

            if (oplacheno < sumafourp && parts[3].Pay_day <= DateTime.Today)
            {
                dolgpodog = Convert.ToDouble(sumafourp - oplacheno);
            }

        }

       

          private void MoveToPaydedPage(object sender, RoutedEventArgs e)
          {
            FrameManager.MainFrame.Navigate(new PaydedPage((sender as Border).DataContext as Contracts));
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
            if (ManagerSaver.ID == 3 && (contract.Stasus_id == 1 || contract.Stasus_id == 3))
            {
                FrameManager.MainFrame.Navigate(new StatusEditLayer((sender as Border).DataContext as Contracts));
            }
            else if (contract.Stasus_id == 1 || contract.Stasus_id == 3)
            {
                FrameManager.MainFrame.Navigate(new EditContractPage((sender as Border).DataContext as Contracts));
            }
            else MessageBox.Show("Данный договор уже утвержден!");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PartsCount.Text.ToString() == "1")
            {
                dolgitog = dolgpodog + penipfp + penipoavance;
            }            
            
            if (PartsCount.Text.ToString() == "2")
            {
                dolgitog = dolgpodog + penipfp + penipoavance + peniposp;
            }

            if (PartsCount.Text.ToString() == "3")
            {
                dolgitog = dolgpodog + penipfp + penipoavance + peniposp + penipothp;
            }

            if (PartsCount.Text.ToString() == "4")
            {
                dolgitog = dolgpodog + penipfp + penipoavance + peniposp + penipothp + penipofourthp;
            }

            if (PartsCount.Text.ToString() == "1")
            {
                MessageBox.Show("Сумма по договору = " + contract.Price + " " + contract.Currencies.Name
                    + "\nОплаченно на данный момент = " + oplacheno + " " + contract.Currencies.Name
                    + "\nДолг по договору = " + dolgpodog + " " + contract.Currencies.Name
                    + "\nПени по авансу = " + penipoavance + " " + contract.Currencies.Name
                    + "\nПени по первой части = " + penipfp + " " + contract.Currencies.Name
                    + "\nДолг с учетом пени = " + dolgitog + " " + contract.Currencies.Name);

                contract.Avance_shtraf = penipoavance;
                contract.Payded = oplacheno;
                contract.Dolg = dolgpodog;
                contract.Shtraf = dolgitog;
                contract.FP_Peni = penipfp;
            }

            if (PartsCount.Text.ToString() == "2")
            {
                MessageBox.Show("Сумма по договору = " + contract.Price + " " + contract.Currencies.Name
                    + "\nОплаченно на данный момент = " + oplacheno + " " + contract.Currencies.Name
                    + "\nДолг по договору = " + dolgpodog + " " + contract.Currencies.Name
                    + "\nПени по авансу = " + penipoavance + " " + contract.Currencies.Name
                    + "\nПени по первой части = " + penipfp + " " + contract.Currencies.Name
                    + "\nПени по второй части = " + peniposp + " " + contract.Currencies.Name
                    + "\nДолг с учетом пени = " + dolgitog + " " + contract.Currencies.Name);

                contract.Avance_shtraf = penipoavance;
                contract.Payded = oplacheno;
                contract.SP_Peni = peniposp;
                contract.Dolg = dolgpodog;
                contract.Shtraf = dolgitog;
                contract.FP_Peni = penipfp;
            }

            if (PartsCount.Text.ToString() == "3")
            {
                MessageBox.Show("Сумма по договору = " + contract.Price + " " + contract.Currencies.Name
                    + "\nОплаченно на данный момент = " + oplacheno + " " + contract.Currencies.Name
                    + "\nДолг по договору = " + dolgpodog + " " + contract.Currencies.Name
                    + "\nПени по авансу = " + penipoavance + " " + contract.Currencies.Name
                    + "\nПени по первой части = " + penipfp + " " + contract.Currencies.Name
                    + "\nПени по второй части = " + peniposp + " " + contract.Currencies.Name
                    + "\nПени по третьей части = " + penipothp + " " + contract.Currencies.Name
                    + "\nДолг с учетом пени = " + dolgitog + " " + contract.Currencies.Name);

                contract.Avance_shtraf = penipoavance;
                contract.Payded = oplacheno;
                contract.SP_Peni = peniposp;
                contract.THP_Peni = penipothp;
                contract.Dolg = dolgpodog;
                contract.Shtraf = dolgitog;
                contract.FP_Peni = penipfp;
            }

            if (PartsCount.Text.ToString() == "4")
            {
                MessageBox.Show("Сумма по договору = " + contract.Price + " " + contract.Currencies.Name
                    + "\nОплаченно на данный момент = " + oplacheno + " " + contract.Currencies.Name
                    + "\nДолг по договору = " + dolgpodog + " " + contract.Currencies.Name
                    + "\nПени по авансу = " + penipoavance + " " + contract.Currencies.Name
                    + "\nПени по первой части = " + penipfp + " " + contract.Currencies.Name
                    + "\nПени по второй части = " + peniposp + " " + contract.Currencies.Name
                    + "\nПени по третьей части = " + penipothp + " " + contract.Currencies.Name
                    + "\nПени по четвертой части = " + penipofourthp + " " + contract.Currencies.Name
                    + "\nДолг с учетом пени = " + dolgitog + " " + contract.Currencies.Name);

                contract.Avance_shtraf = penipoavance;
                contract.Payded = oplacheno;
                contract.SP_Peni = peniposp;
                contract.THP_Peni = penipothp;
                contract.Dolg = dolgpodog;
                contract.Shtraf = dolgitog;
                contract.FP_Peni = penipfp;
                contract.FOURP_Peni = penipofourthp;
            }
            CM_Entitiess.GetContext().SaveChanges();
        }
    }
}
