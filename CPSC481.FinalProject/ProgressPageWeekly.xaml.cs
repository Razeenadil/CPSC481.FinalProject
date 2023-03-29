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

namespace CPSC481.FinalProject
{
    /// <summary>
    /// Interaction logic for ProgressPageWeekly.xaml
    /// </summary>
    public partial class ProgressPageWeekly : Page
    {
        private bool navigationIsClicked;

        public ProgressPageWeekly()
        {
            InitializeComponent();
            this.DataContext = this;

            navigationIsClicked = false;
        }

        /*You can uncomment the code inside once you created the rest of the buttons*/
        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
           // if (!navigationIsClicked)
            //{
                //InfoButton.IsEnabled = true;
                //DemoButton.IsEnabled = true;
                //ProgressButton.IsEnabled = true;
                //RoutineButton.IsEnabled = true;


               // InfoButton.Visibility = Visibility.Visible;
               // DemoButton.Visibility = Visibility.Visible;
                //ProgressButton.Visibility = Visibility.Visible;
               // RoutineButton.Visibility = Visibility.Visible;

               // navigationIsClicked = true;
           // }
           // else
            //{
               // InfoButton.IsEnabled = false;
               // DemoButton.IsEnabled = false;
               // ProgressButton.IsEnabled = false;
               // RoutineButton.IsEnabled = false;

              //  InfoButton.Visibility = Visibility.Hidden;
              //  DemoButton.Visibility = Visibility.Hidden;
              //  ProgressButton.Visibility = Visibility.Hidden;
              //  RoutineButton.Visibility = Visibility.Hidden;

              //  navigationIsClicked = false;
            //}

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
