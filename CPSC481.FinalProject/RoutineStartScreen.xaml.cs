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
    public static class Global_Data
    {
        public struct exercise_info
        {
            public string exercise_name;
            public int exercise_type;  // rep = 0, timed = 1
            public int set_count;
            public int rep_count;
            public int set_total;
            public int rep_total;

            public exercise_info()
            {
                exercise_name = "";
                exercise_type = 0;
                set_count = 0;
                rep_count = 0;
                set_total = 0;
                rep_total = 0;
            }
        }

        public static Dictionary<int, exercise_info> exercise_dict = new Dictionary<int, exercise_info>();

        public static Dictionary<string, Dictionary<int, exercise_info>> routine_dict = new Dictionary<string, Dictionary<int, exercise_info>>();

        public static void Add_routine(string routine_name)
        {

        }

    }
    /// <summary>
    /// Interaction logic for RoutineStartScreen.xaml
    /// </summary>
    public partial class RoutineStartScreen : Page
    {
        private bool navigationIsClicked;
        int num_of_exercises = 0;
        public RoutineStartScreen()
        {
            InitializeComponent();
            this.DataContext = this;

            navigationIsClicked = false;



            List<ExerciseItem> exercises = new List<ExerciseItem>();
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Dumbbell Curls" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Farmer's Walk" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Hammer Curls" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Concentrated Biceps Curls" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Dumbbell Curls" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Farmer's Walk" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Hammer Curls" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Concentrated Biceps Curls" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Dumbbell Curls" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Farmer's Walk" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Hammer Curls" });
            exercises.Add(new ExerciseItem() { Num = ++num_of_exercises, Name = "Concentrated Biceps Curls" });

            routineListBox.ItemsSource = exercises;
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
            //mainWindow?.ChangeView(new ViewRoutines());
            mainWindow?.ChangeView(new RoutineStartScreen());
        }

        private void StartRoutine(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ExerciseRepScreen());
        }
    }

    public class ExerciseItem
    {
        public int Num { get; set; }
        public string? Name { get; set; }
    }
}
