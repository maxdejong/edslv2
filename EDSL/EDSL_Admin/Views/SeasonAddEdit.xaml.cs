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
    /// <summary>
    /// Interaction logic for SeasonAddEdit.xaml
    /// </summary>
    public partial class SeasonAddEdit : Page
    {
        public SeasonAddEdit()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Add calender to list
            BreakDateList.Items.Add(new DatePicker());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BreakDateList.Items.RemoveAt(BreakDateList.SelectedIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Add to database
            private const string URL = "https://sub.domain.com/objects.json?api_key=123";
            private const string DATA = @"{""object"":{""name"":""Name""}}";

            HttpClient client = new HttpClient();





            EDSLToolbox.Reff.Title.Content = "Seasons (season added)";
            EDSLToolbox.Reff.Display.Content = new Season();
        }

        private void BreakDateList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Removebtn.IsEnabled = true;
            if (BreakDateList.SelectedItem == null)
                Removebtn.IsEnabled = false;
        }
    }
}
