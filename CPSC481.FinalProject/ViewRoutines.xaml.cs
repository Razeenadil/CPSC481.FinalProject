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
using System.Diagnostics;

namespace CPSC481.FinalProject
{
    /// <summary>
    /// Interaction logic for ViewRoutines.xaml
    /// </summary>
    public partial class ViewRoutines : Page
    {

        private bool navigationIsClicked;


        public ViewRoutines()
        {
            InitializeComponent();
            navigationIsClicked = false;
            /*
            routineLabel1Date.Content = "Today";
            routineLabel1Name.Content = Global_Data.routine_chosen;
            */

            // Test Data
            string[,] routines_and_dates = new string[8, 2]
            {
                { "Arm Day", "Apr 11\n2023" },
                { "Back Day", "Apr 12\n2023" },
                { "Leg Day", "Apr 13\n2023" },
                { "Rest Day", "Apr 14\n2023" },
                { "Arm Day 2", "Apr 15\n2023" },
                { "Back Day 2", "Apr 16\n2023" },
                { "Leg Day 2", "Apr 17\n2023" },
                { "A Very Long Workout Day Today", "Apr 18\n2023" }
            };

            for (int i = 0; i < routines_and_dates.GetLength(0); i++)
            {
                if (!Global_Data.routine_schedule.ContainsKey(routines_and_dates[i, 0]))
                {
                    Global_Data.Add_routine(routines_and_dates[i, 0], routines_and_dates[i, 1]);
                }
            }

            // hardcoded dummy data - this is usually already set in create routine screen - REMOVE LATER**
            string aRoutine = "My Routine!";

            if (!Global_Data.routine_dict.ContainsKey(aRoutine))
            {
                Global_Data.Add_routine(aRoutine, "No Date");
                Global_Data.Add_rep_exercise(aRoutine, 1, "Dumbbell Curls", 1, 1);
                Global_Data.Add_timed_exercise(aRoutine, 2, "Farmer's Walk");

                Global_Data.Add_rep_exercise(aRoutine, 3, "Hammer Curls", 2, 2);
                Global_Data.Add_rep_exercise(aRoutine, 4, "Barbell Curls", 3, 3);
                Global_Data.Add_rep_exercise(aRoutine, 5, "Dumbbell Curls", 4, 4);
                Global_Data.Add_timed_exercise(aRoutine, 6, "Farmer's Walk");
                Global_Data.Add_rep_exercise(aRoutine, 7, "Hammer Curls", 5, 5);
                Global_Data.Add_rep_exercise(aRoutine, 8, "Barbell Curls", 8, 8);              
            }

            foreach (KeyValuePair<string, string> entry in Global_Data.routine_schedule)
            {
                RoutineListPanel.Children.Add(new RoutineItem() { RoutineName = entry.Key, RoutineDate = entry.Value });
            }
            // end of test data

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
                ellipseHack2.Visibility = Visibility.Visible;
                ellipseHack3.Visibility = Visibility.Visible;

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
                ellipseHack2.Visibility = Visibility.Hidden;
                ellipseHack3.Visibility = Visibility.Hidden;
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

        private void Create_Workout_Routine_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new CreateWorkoutRoutine());

        }
    }
}
