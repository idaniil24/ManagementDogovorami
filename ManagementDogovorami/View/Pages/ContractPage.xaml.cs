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
        private Parts[] parts;
        public ContractPage(Contracts contract)
        {
            InitializeComponent();
            DataContext = contract;
            this.contract = contract;

            DataContext = contract;
            parts = contract.Parts.ToArray();
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
        }

        private void MoveToDogovoraPage(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new DogovoraPage());
        }

        private void MoveToEditContractPage(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new EditContractPage((sender as Border).DataContext as Contracts));
        }
    }
}
