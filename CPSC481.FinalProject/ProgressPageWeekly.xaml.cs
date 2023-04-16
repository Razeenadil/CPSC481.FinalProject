using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ProgressPageWeekly : Page, INotifyPropertyChanged
    {
        private bool navigationIsClicked;
        public event PropertyChangedEventHandler PropertyChanged;
        private List<string> data = new();
        private string? comboBoxSelection;



        public ProgressPageWeekly()
        {
            InitializeComponent();
            this.DataContext = this;
            navigationIsClicked = false;

          
            // Test Data
            string[,] routines_and_dates = new string[7, 2]
            {
                { "Arm Day", "Apr 11" },
                { "Back Day", "Apr 12" },
                { "Leg Day", "Apr 13" },
                { "Rest Day", "Apr 14" },
                { "Arm Day 2", "Apr 15" },
                { "Back Day 2", "Apr 16" },
                { "Leg Day 2", "Apr 17" }
            };

            for (int i = 0; i < routines_and_dates.GetLength(0); i++)
            {
                if (!Global_Data.routine_schedule.ContainsKey(routines_and_dates[i, 0]))
                {
                    Global_Data.Add_routine(routines_and_dates[i, 0], routines_and_dates[i, 1]);
                }
            }

            data = Global_Data.routine_names;
            routineCombo.ItemsSource = data;
            comboBoxSelection = null;
        }






        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!navigationIsClicked)
            {
                InfoButton.IsEnabled = true;
                DemoButton.IsEnabled = true;
                ProgressButton.IsEnabled = true;
                RoutineButton.IsEnabled = true;


                InfoButton.Visibility = Visibility.Visible;
                DemoButton.Visibility = Visibility.Visible;
                ProgressButton.Visibility = Visibility.Visible;
                RoutineButton.Visibility = Visibility.Visible;
                ellipseHack.Visibility = Visibility.Visible;
                ellipseHack1.Visibility = Visibility.Visible;


                navigationIsClicked = true;
            }
            else
            {
                InfoButton.IsEnabled = false;
                DemoButton.IsEnabled = false;
                ProgressButton.IsEnabled = false;
                RoutineButton.IsEnabled = false;

                InfoButton.Visibility = Visibility.Hidden;
                DemoButton.Visibility = Visibility.Hidden;
                ProgressButton.Visibility = Visibility.Hidden;
                RoutineButton.Visibility = Visibility.Hidden;
                ellipseHack.Visibility = Visibility.Hidden;
                ellipseHack1.Visibility = Visibility.Hidden;



                navigationIsClicked = false;
            }

        }


        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Welcome());
        }

        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ProgressPageWeekly());
        }

        private void DemoButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new BodyPartSelectorPage());
        }

        private void RoutineButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ViewRoutines());
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new LandingScreen());
        }

        private void routineCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dic key this is the routine name Ex. "Arm Day"
            comboBoxSelection = routineCombo.SelectedItem.ToString();
        }
    }
}
