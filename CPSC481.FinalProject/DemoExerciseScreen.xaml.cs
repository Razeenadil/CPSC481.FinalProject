using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CPSC481.FinalProject
{
    /// <summary>
    /// Interaction logic for DemoExerciseScreen.xaml
    /// </summary>
    public partial class DemoExerciseScreen : Page, INotifyPropertyChanged
    {
        private bool navigationIsClicked;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _filter;
        private bool _arms;
        private bool _legs;
        private bool _back;
        private bool _chest;
        private bool _abs;
        private string _exerciseName;
        private string _level;
        private string _targetMuscleGroup;
        private string _equipment;
        private string _description;

        public DemoExerciseScreen(string filterSelection, bool arms, bool legs, bool back, bool chest, bool abs, string Name, string Description, string Level, string TargetMuscleGroup, string Equipment)
        {
            InitializeComponent();
            this.DataContext = this;
            navigationIsClicked = false;

            SetExerciseDetails( Name,  Description,  Level,  TargetMuscleGroup,  Equipment);
            
            _filter = filterSelection;
            _arms = arms;
            _legs = legs;
            _back = back;
            _chest = chest;
            _abs = abs;
        }


        private void SetExerciseDetails(string name, string description, string level, string targetMuscleGroup, string equipment)
        {
            ExerciseName = name;
            Level = level;
            TargetMuscleGroup = targetMuscleGroup;
            Equipment = equipment;
            Description = description;
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
                ellipseHack1.Visibility = Visibility.Hidden;
                ellipseHack2.Visibility = Visibility.Hidden;
                ellipseHack3.Visibility = Visibility.Hidden;


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
            mainWindow?.ChangeView(new DemoVideoPage(_filter, _arms, _legs, _back, _chest, _abs));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        public string ExerciseName
        {
            get { return _exerciseName; }
            set
            {
                if (value != _exerciseName)
                {
                    _exerciseName = value;
                    OnPropertyChanged(nameof(ExerciseName));
                }
            }
        }

        public string Level
        {
            get { return _level; }
            set
            {
                if (value != _level)
                {
                    _level = value;
                    OnPropertyChanged(nameof(Level));
                }
            }
        }

        public string TargetMuscleGroup
        {
            get { return _targetMuscleGroup; }
            set
            {
                if (value != _targetMuscleGroup)
                {
                    _targetMuscleGroup = value;
                    OnPropertyChanged(nameof(TargetMuscleGroup));
                }
            }
        }

        public string Equipment
        {
            get { return _equipment; }
            set
            {
                if (value != _equipment)
                {
                    _equipment = value;
                    OnPropertyChanged(nameof(Equipment));
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
    }
}
