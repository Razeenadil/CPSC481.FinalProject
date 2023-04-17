using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AddExercise.xaml
    /// </summary>
    public partial class AddExercise : Page
    {

        private bool navigationIsClicked;

        private string newRoutineBodyParts;
        private bool arms, legs, chest, back, abs;
        public List<AddExerciseItem> exerciseList = new List<AddExerciseItem>();

        public AddExercise(string newRoutineBodyParts, bool arms, bool legs, bool back, bool chest, bool abs)
        {
            InitializeComponent();
            navigationIsClicked = false;

            this.newRoutineBodyParts = newRoutineBodyParts;
            this.arms = arms;
            this.legs = legs;
            this.back = back;
            this.chest = chest;
            this.abs = abs;
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
            mainWindow?.ChangeView(new CreateWorkoutRoutine());
        }

        private void AddExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            if (newRoutineBodyParts == "Choose Body Part")
            {
                mainWindow?.ChangeView(new DemoVideoPage("Selection: No filters applied", arms, legs, back, chest, abs, true, this, ExercisesStackPanel));
            }
            else
            {
                mainWindow?.ChangeView(new DemoVideoPage(newRoutineBodyParts, arms, legs, back, chest, abs, true, this, ExercisesStackPanel));
            }

            //ExercisesStackPanel.Children.Add(new AddExerciseItem(ExercisesStackPanel, "test"));
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            string[] formattedDate = CreateWorkoutRoutine.newRoutineDateTime.ToString("m").Split(" ");
            string formattedMonth = formattedDate[0].Substring(0, 3);
            string finalFormattedDate = formattedMonth + " " + formattedDate[1];

            Global_Data.Add_routine(CreateWorkoutRoutine.newRoutineName, finalFormattedDate);


            for (int i = 0; i < exerciseList.Count; i++)
            {
                Global_Data.Add_rep_exercise(CreateWorkoutRoutine.newRoutineName, i + 1, exerciseList[i].name, exerciseList[i].sets, exerciseList[i].reps);
            }

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ViewRoutines());
        }

    }
}
