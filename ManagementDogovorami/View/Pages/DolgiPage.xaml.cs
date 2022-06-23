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
    /// Логика взаимодействия для DolgiPage.xaml
    /// </summary>
    public partial class DolgiPage : Page
    {
        public DolgiPage()
        {
            InitializeComponent();
            DGridDolgi.ItemsSource = CM_Entitiess.GetContext().Contracts.Where(x=> x.Manager_id == ManagerSaver.ID).ToList();
        }
    }
}
