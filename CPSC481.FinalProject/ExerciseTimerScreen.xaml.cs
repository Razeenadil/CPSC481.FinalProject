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
    /// Interaction logic for ExerciseTimerScreen.xaml
    /// </summary>
    public partial class ExerciseTimerScreen : Page
    {
        private bool navigationIsClicked;
        public ExerciseTimerScreen()
        {
            InitializeComponent();
            this.DataContext = this;

            navigationIsClicked = false;

            routineName.Content = Global_Data.routine_chosen;
            exerciseName.Content = Global_Data.routine_dict[Global_Data.routine_chosen][Global_Data.exercise_number].exercise_name;
            exerciseCount.Content = Global_Data.exercise_number.ToString() + "/" + Global_Data.routine_dict[Global_Data.routine_chosen].Count.ToString();

            if (Global_Data.exercise_number == Global_Data.routine_dict[Global_Data.routine_chosen].Count)
            {
                TransitionButton.Content = "Done";
            }
            else
            {
                TransitionButton.Content = "Next";
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
            mainWindow?.ChangeView(new ViewRoutines());
        }

        private void TransitionButton_Click(object sender, RoutedEventArgs e)
        {
            Global_Data.exercise_number++;
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            // check what type of exercise then go to next exercise
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
}
