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

namespace EDSL_Admin.Views
{
    /// <summary>
    /// Interaction logic for Season.xaml
    /// </summary>
    public partial class Season : Page
    {
        public Season()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EDSLToolbox.Reff.Title.Content = "Add Season";
            EDSLToolbox.Reff.Display.Content = new SeasonAddEdit();
        }
    }
}
