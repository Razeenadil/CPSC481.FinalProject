using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using System.Data;

namespace CPSC481.FinalProject
{
    /// <summary>
    /// Interaction logic for DemoVideoPage.xaml
    /// </summary>
    public partial class DemoVideoPage : Page, INotifyPropertyChanged
    {

        private bool navigationIsClicked;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _selection;
        private ObservableCollection<Exercises> exercises = new();
        private string _filter;
        private bool _arms;
        private bool _legs;
        private bool _back;
        private bool _chest;
        private bool _abs;


        public class Exercises
        {
            public string? BodyPart { get; set; }
            public string? TargetMuscleGroup { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public string? Level { get; set; }
            public string? Equipment { get; set; }
        }
        public DemoVideoPage(string filterSelection, bool arms, bool legs, bool back, bool chest, bool abs)
        {
            InitializeComponent();
            this.DataContext = this;
            
            _filter = filterSelection;
            if(!arms && !legs && !back && !chest && !abs)
            {
                _arms = true;
                _legs = true;
                _back = true;
                _chest = true;
                _abs = true;
            }
            else
            {
                _arms = arms;
                _legs = legs;
                _back = back;   
                _chest = chest;
                _abs = abs;
            }

            SetSelection(filterSelection);
            navigationIsClicked = false;

            PopulateListBox(arms, legs, back, chest, abs);
        }

        private void PopulateListBox(bool arms, bool legs, bool back, bool chest, bool abs)
        {
            

            if(!arms && !legs && !back && !chest && !abs)
            {
                arms = true;
                legs = true;
                back = true;
                chest = true;
                abs = true;
            }

            if(arms)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Arms",
                    TargetMuscleGroup = "Target Body Part: Biceps",
                    Name = "Dumbbell Curls",
                    Description = "Also known as the bicep curls or arm curls, dumbbell curls are an isolation exercise that is aimed at strengthening your upper arms.",
                    Level = "Level: Beginner",
                    Equipment = "Equipment Required: Dumbells"
                });

                exercises.Add(new Exercises()
                {
                    BodyPart = "Arms",
                    TargetMuscleGroup = "Target Body Part: Triceps",
                    Name = "Triceps PushDown",
                    Description = "The triceps pushdown can help to increase upper body arm size, enhance general pressing strength.",
                    Level = "Level: Beginner",
                    Equipment = "Equipment Required: Cable Pulley Machine"
                });
            }

            if(legs)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Legs",
                    TargetMuscleGroup = "Target Body Part: Glutes and Quadriceps",
                    Name = "Barbell Squats",
                    Description = "Whether you’re an experienced powerlifter or a novice lifter, the barbell squat is a comprehensive squat variation to include in your strength training.",
                    Level = "Level: Advance",
                    Equipment = "Equipment Required: Barbell, Squat Rack, Weight Plates"
                });

                exercises.Add(new Exercises()
                {
                    BodyPart = "Legs",
                    TargetMuscleGroup = "Target Body Part: Quadriceps, Hamstrings, Glutes and Calves",
                    Name = "Lunges",
                    Description = "The lunge is a multi-joint exercise that can help tone and strengthen many muscles in the lower body. This includes the quads, hamstrings, glutes, and calves.",
                    Level = "Level: Beginner",
                    Equipment = "Equipment Required: None"
                });
            }

            if(chest)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Chest",
                    TargetMuscleGroup = "Target Body Part: Pectorals, Arms, and Shoulders",
                    Name = "Bench Press",
                    Description = "A bench press is an exercise that can be used to strengthen the muscles of the upper body, including the pectorals, arms, and shoulders.",
                    Level = "Level: Intermediate",
                    Equipment = "Equipment Required: Barbell, Weight Bench, Weight Plates"
                });

                exercises.Add(new Exercises()
                {
                    BodyPart = "Chest",
                    TargetMuscleGroup = "Target Body Part: Pectorals and Triceps",
                    Name = "Dips",
                    Description = "Dips are a compound exercise meaning they work multiple muscle groups at a time. This can be beneficial for building upper body strength and building muscle mass.",
                    Level = "Level: Beginner",
                    Equipment = "Equipment Required: Dip Bar"
                });
            }

            if(abs)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Abs",
                    TargetMuscleGroup = "Target Body Part: Lower abdomen",
                    Name = "Flutter Kicks",
                    Description = "Flutter kicks are an exercise that works the muscles of your core, specifically the lower rectus abdominal muscles, plus the hip flexors.",
                    Level = "Level: Beginner",
                    Equipment = "Equipment Required: None"
                });

                 exercises.Add(new Exercises()
                {
                    BodyPart = "Abs",
                    TargetMuscleGroup = "Target Body Part: Oblique, Pelvis, Lower Back, and Hips",
                    Name = "Crunches",
                    Description = "The crunch is a classic core exercise. It specifically trains your abdominal muscles, which are part of your core.",
                    Level = "Level: Beginner",
                    Equipment = "Equipment Required: None"
                 });
            }

            if(back)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Back",
                    TargetMuscleGroup = "Target Body Part: Upper Back, Latissimus Dorsi, and Teres Major",
                    Name = "Lat Pull Down",
                    Description = "The lat pulldown is a fantastic exercise to strengthen the latissimus dorsi muscle, the broadest muscle in your back, which promotes good postures and spinal stability.",
                    Level = "Level: Beginner",
                    Equipment = "Equipment Required: Cable Pulley Machine"
                });

                exercises.Add(new Exercises()
                {
                    BodyPart = "Back",
                    TargetMuscleGroup = "Target Body Part: Lower Back, Glutes, and Hamstrings",
                    Name = "Deadlift",
                    Description = "Dead lifts are considered a compound exercise, meaning they involve the use of multiple, large muscle groups. They can be excellent for improving strength and power.",
                    Level = "Level: Advance",
                    Equipment = "Equipment Required: Barbell, Weight Plates"
                });
            }


            exerciseListBox.ItemsSource = exercises;
            ICollectionView view = CollectionViewSource.GetDefaultView(exercises);
            view.GroupDescriptions.Add(new PropertyGroupDescription("BodyPart"));
            view.SortDescriptions.Add(new SortDescription("BodyPart", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            exerciseListBox.ItemsSource = view;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        public string Selection
        {
            get { return _selection; }
            set
            {
                if (value != _selection)
                {
                    _selection = value;
                    OnPropertyChanged(nameof(Selection));
                }
            }
        }

        private void SetSelection(string value)
        {
            Selection = value;
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
            mainWindow?.ChangeView(new BodyPartSelectorPage());
        }




        //https://stackoverflow.com/questions/5745349/get-name-of-selected-listbox-item-wpf-c

        private void exerciseListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(exercises);
            Exercises ss = (Exercises)view.CurrentItem;

            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new DemoExerciseScreen(_filter, _arms, _legs, _back, _chest, _abs, ss.Name, ss.Description, ss.Level, ss.TargetMuscleGroup, ss.Equipment));
        }
    }
}
