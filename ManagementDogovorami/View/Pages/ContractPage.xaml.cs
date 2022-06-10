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
        int pCounts;
        double sum;
        double oplacheno;
        private Payded[] paydeds;
        private Parts[] parts;
        double procent = 2.4;

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


            //DateTime dateTime = new DateTime();
            //dateTime = Convert.ToDateTime(first_part_date);

            //if(DateTime.Now>dateTime)
            //{
            //    sum = sum * 2;
            //}


            //MessageBox.Show(sum.ToString());

            sum = Convert.ToDouble(contract.Price);

            DataContext = contract;
            parts = contract.Parts.ToArray();

            if (DateTime.Today > Convert.ToDateTime(parts[0].Pay_day) && oplacheno < Convert.ToDouble(parts[0].Price))
            {
                sum = sum * 1.2;
            }
            MessageBox.Show(sum.ToString());

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
            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }

        private void MoveToEditContractPage(object sender, MouseButtonEventArgs e)
        {
            if (contract.Stasus_id == 1)
            {
                FrameManager.MainFrame.Navigate(new EditContractPage((sender as Border).DataContext as Contracts));
            }
            else MessageBox.Show("Данный договор уже утвержден!");
        }
    }
}
