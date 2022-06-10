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
        public StatusEditLayer(Contracts currentContranct)
        {
            InitializeComponent();
            _currentContranct = currentContranct;
        }

        private void MoveToDogovoraPage(object sender, MouseButtonEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new LayerContractsPage());
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

        }
        private void charcheck(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789 ,".IndexOf(e.Text) < 0;
        }
        private void EditContract_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
