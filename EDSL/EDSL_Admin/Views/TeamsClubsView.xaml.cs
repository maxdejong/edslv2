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
    /// Interaction logic for TeamsClubsView.xaml
    /// </summary>
    public partial class TeamsClubsView : Page
    {
        public TeamsClubsView()
        {
            InitializeComponent();
        }

        private void AllTeamsbtn_Click(object sender, RoutedEventArgs e)
        {
            EDSLToolbox.Reff.Display.Content = new TeamsView();
            EDSLToolbox.Reff.Title.Content = "Teams";
        }
    }
}
