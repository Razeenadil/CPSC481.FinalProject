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
    /// Interaction logic for RoutineStartScreen.xaml
    /// </summary>
    public partial class RoutineStartScreen : Page
    {
        private bool navigationIsClicked;
        public RoutineStartScreen()
        {
            InitializeComponent();
            this.DataContext = this;

            navigationIsClicked = false;

            // hardcoded dummy data - this is usually already set in create routine screen - REMOVE LATER**
            if (!Global_Data.routine_dict.ContainsKey(Global_Data.routine_chosen))
            {
                Global_Data.Add_routine(Global_Data.routine_chosen);
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 1, "Dumbbell Curls", 5, 8);
                Global_Data.Add_timed_exercise(Global_Data.routine_chosen, 2, "Farmer's Walk");
                
                
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 3, "Hammer Curls", 8, 8);
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 4, "Concentrated Biceps Curls", 8, 8);
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 5, "Dumbbell Curls", 8, 8);
                Global_Data.Add_timed_exercise(Global_Data.routine_chosen, 6, "Farmer's Walk");
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 7, "Hammer Curls", 8, 8);
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 8, "Concentrated Biceps Curls", 8, 8);
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 9, "Dumbbell Curls", 8, 8);
                Global_Data.Add_timed_exercise(Global_Data.routine_chosen, 10, "Farmer's Walk");
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 11, "Hammer Curls", 8, 8);
                Global_Data.Add_rep_exercise(Global_Data.routine_chosen, 12, "Concentrated Biceps Curls EX", 8, 8);
            }
            
            List<ExerciseItem> exercises = new List<ExerciseItem>();

            foreach (KeyValuePair<int, Global_Data.exercise_info> entry in Global_Data.routine_dict[Global_Data.routine_chosen])
            {
                exercises.Add(new ExerciseItem() { Num = entry.Key, Name = entry.Value.exercise_name });
            }

            routineListBox.ItemsSource = exercises;
            routineLabel.Content = Global_Data.routine_chosen;
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

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ViewRoutines());
        }

        //this is the logout button was to lazy to rename
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
            //mainWindow?.ChangeView(new ViewRoutines());
            mainWindow?.ChangeView(new RoutineStartScreen());
        }

        private void StartRoutine(object sender, RoutedEventArgs e)
        {
            Global_Data.exercise_number = 1;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            // if first exercise is rep based
            if (Global_Data.routine_dict[Global_Data.routine_chosen][Global_Data.exercise_number].exercise_type == 0)
            {
                mainWindow?.ChangeView(new ExerciseRepScreen());
            }
            // else it must be time based
            else
            {
                mainWindow?.ChangeView(new ExerciseTimerScreen());
            }
        }
    }

    public class ExerciseItem
    {
        public int Num { get; set; }
        public string? Name { get; set; }
    }
}
