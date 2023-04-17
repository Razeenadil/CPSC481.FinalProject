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

            // Premade Data
            string routine1 = "Arm Day";
            if (!Global_Data.routine_dict.ContainsKey(routine1))
            {
                Global_Data.Add_routine(routine1, "Apr 20");
                Global_Data.Add_rep_exercise(routine1, 1, "Dumbbell Curls", 2, 5);
                Global_Data.Add_rep_exercise(routine1, 2, "Hammer Curls", 3, 5);
                Global_Data.Add_rep_exercise(routine1, 3, "Barbell Curls", 4, 5);
                Global_Data.Add_rep_exercise(routine1, 4, "Dumbbell Curls", 5, 5);
                Global_Data.Add_rep_exercise(routine1, 5, "Hammer Curls", 6, 5);
                Global_Data.Add_rep_exercise(routine1, 6, "Barbell Curls", 8, 5);
            }

            string routine2 = "Leg Day";
            if (!Global_Data.routine_dict.ContainsKey(routine2))
            {
                Global_Data.Add_routine(routine2, "Apr 21");
                Global_Data.Add_rep_exercise(routine2, 1, "Lunges", 8, 10);
                Global_Data.Add_rep_exercise(routine2, 2, "Barbell Squats", 5, 8);
                Global_Data.Add_rep_exercise(routine2, 3, "Dumbbell Squats", 5, 8);
                Global_Data.Add_rep_exercise(routine2, 4, "Calf Raises", 5, 10);
                Global_Data.Add_rep_exercise(routine2, 5, "Barbell Squats", 5, 8);
                Global_Data.Add_rep_exercise(routine2, 6, "Dumbbell Squats", 5, 8);
                Global_Data.Add_rep_exercise(routine2, 7, "Calf Raises", 5, 10);
                Global_Data.Add_rep_exercise(routine2, 8, "Lunges", 5, 5);
                Global_Data.Add_timed_exercise(routine2, 9, "Quad Stretch");
                Global_Data.Add_timed_exercise(routine2, 10, "Calf Stretch");
                Global_Data.Add_timed_exercise(routine2, 11, "Lunge Stretch");
            }

            string routine3 = "Week-Ender";
            if (!Global_Data.routine_dict.ContainsKey(routine3))
            {
                Global_Data.Add_routine(routine3, "Apr 22");
                Global_Data.Add_timed_exercise(routine3, 1, "Farmer's Walk");
                Global_Data.Add_rep_exercise(routine3, 2, "Dumbbell Curls", 4, 5);
                Global_Data.Add_rep_exercise(routine3, 3, "Hammer Curls", 4, 5);
                Global_Data.Add_rep_exercise(routine3, 4, "Barbell Curls", 4, 5);
                Global_Data.Add_rep_exercise(routine3, 5, "Dumbbell Curls", 4, 5);
                Global_Data.Add_rep_exercise(routine3, 6, "Hammer Curls", 5, 5);
                Global_Data.Add_rep_exercise(routine3, 7, "Barbell Curls", 8, 8);
                Global_Data.Add_timed_exercise(routine3, 8, "Farmer's Walk");
            }

            foreach (KeyValuePair<string, string> entry in Global_Data.routine_schedule)
            {
                RoutineListPanel.Children.Add(new RoutineItem() { RoutineName = entry.Key, RoutineDate = entry.Value });
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
            CreateWorkoutRoutine.Reset_Fields();
            mainWindow?.ChangeView(new CreateWorkoutRoutine());
        }
    }
}
