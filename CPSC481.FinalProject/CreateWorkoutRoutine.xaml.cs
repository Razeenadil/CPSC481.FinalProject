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
    /// Interaction logic for CreateWorkoutRoutine.xaml
    /// </summary>
    public partial class CreateWorkoutRoutine : Page
    {

        private bool navigationIsClicked;
        public static string newRoutineName = "";
        public static DateTime newRoutineDateTime = new();
        public static string newRoutineOccurence = "Choose occurrence";
        public static string newRoutineBodyParts = "Choose Body Part";

        public bool arms, legs, chest, back, abs;

        public CreateWorkoutRoutine()
        {
            InitializeComponent();
            navigationIsClicked = false;
            routineNameTextBox.Text = newRoutineName;
            if (newRoutineDateTime != new DateTime())
            {
                dateLabel.Content = newRoutineDateTime.ToString().Split(' ')[0];
            }
            if (newRoutineOccurence != "Choose occurrence")
            {
                occurrenceLabel.Content = newRoutineOccurence;
            }
            if (newRoutineBodyParts != "Choose Body Part")
            {
                bodyPartLabel.Text = newRoutineBodyParts;
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
            Reset_Fields();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Welcome());
        }

        private void ProgressButton_Click(object sender, RoutedEventArgs e)
        {
            Reset_Fields();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ProgressPageWeekly());
        }

        private void DemoButton_Click(object sender, RoutedEventArgs e)
        {

            Reset_Fields();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new BodyPartSelectorPage());
        }

        private void RoutineButton_Click(object sender, RoutedEventArgs e)
        {
            Reset_Fields();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ViewRoutines());
        }


        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            Reset_Fields();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new ViewRoutines());
        }

        private void Reset_Fields()
        {
            newRoutineName = "";
            newRoutineDateTime = new();
            newRoutineOccurence = "Choose Occurrence";
            newRoutineBodyParts = "Choose Body Part";
        }

        private void AddExercises_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new AddExercise(newRoutineBodyParts, arms, legs, back, chest, abs));
        }

        private void routineNameChange(object sender, TextChangedEventArgs e)
        {
            newRoutineName = routineNameTextBox.Text;
            Debug.WriteLine(newRoutineName);
        }


        private void DateTimeButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new RoutineCalendar());
        }

        private void OccurenceButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new RoutineOccurence());
        }

        private void BodyPartButton_Click(object sender, RoutedEventArgs e)
        {
            // Connect to razeen page

            
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new BodyPartSelectorPage(true, this));
        }
    }
}
