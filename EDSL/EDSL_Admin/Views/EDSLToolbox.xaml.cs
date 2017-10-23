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
    /// Interaction logic for EDSLToolbox.xaml
    /// </summary>
    public partial class EDSLToolbox : Page
    {
        public EDSLToolbox()
        {
            InitializeComponent();
            Title.Content = "Home";
            Display.Navigate(new HomePage());
        }

        private void Homebtn_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Home";
            Display.Navigate(new HomePage());
        }

        private void SeasonBtn_Click(object sender, RoutedEventArgs e)
        {
            Title.Content = "Season";
            Display.Navigate(new Season());
        }
    }
}
