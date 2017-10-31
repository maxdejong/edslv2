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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EDSL_Admin.Views
{
    public class Team
    {
        public int teamID { get; set; }
        public int clubPID { get; set; }
        public string teamName { get; set; }
        public int contact { get; set; }
    }

    /// <summary>
    /// Interaction logic for TeamsView.xaml
    /// </summary>
    public partial class TeamsView : Page
    {


        public TeamsView()
        {
            InitializeComponent();
            populateList();
        }

        public void populateList()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://edsl1.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("/api/Teams").Result;

            if (response.IsSuccessStatusCode)
            {
                TeamList.ItemsSource = response.Content.ReadAsAsync<IEnumerable<Team>>().Result;
            }
        }

        private void TeamList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditBtn.IsEnabled = true;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            EDSLToolbox.Reff.Display.Content = new TeamAddEdit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EDSLToolbox.Reff.Display.Content = new TeamAddEdit();
        }
    }
}
