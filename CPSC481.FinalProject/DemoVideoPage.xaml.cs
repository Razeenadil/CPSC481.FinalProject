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
        ObservableCollection<Exercises> exercises = new();


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
                    TargetMuscleGroup = "Biceps",
                    Name = "Dumbbell Curls",
                    Description = "Also known as the bicep curls or arm curls, dumbbell curls are an isolation exercise that is aimed at strengthening your upper arms.",
                    Level = "Beginner",
                    Equipment = "Dumbells"
                });

                exercises.Add(new Exercises()
                {
                    BodyPart = "Arms",
                    TargetMuscleGroup = "Triceps",
                    Name = "Triceps PushDown",
                    Description = "The triceps pushdown can help to increase upper body arm size, enhance general pressing strength, and ultimately improve performance of the shoulders and chest muscles as they are often the secondary muscle group for most mass building movements.",
                    Level = "Beginner",
                    Equipment = "Cable Pulley Machine"
                });
            }

            if(legs)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Legs",
                    TargetMuscleGroup = "Glutes and Quadriceps",
                    Name = "Barbell Squats",
                    Description = "Whether you’re an experienced powerlifter or a novice lifter, the barbell squat is a comprehensive squat variation to include in your strength training. As you exercise, the movement strengthens your tendons, bones, and ligaments around the leg muscles.",
                    Level = "Advance",
                    Equipment = "Barbell, Squat Rack, Weight Plates"
                });

                exercises.Add(new Exercises()
                {
                    BodyPart = "Legs",
                    TargetMuscleGroup = "Quadriceps, Hamstrings, Glutes and Calves",
                    Name = "Lunges",
                    Description = "The lunge is a multi-joint exercise that can help tone and strengthen many muscles in the lower body. This includes the quads (front of the thighs), hamstrings (back of the thighs), glutes (buttocks), and calves (back of the lower leg).",
                    Level = "Beginner",
                    Equipment = "None"
                });
            }

            if(chest)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Chest",
                    TargetMuscleGroup = "Pectorals, Arms, and Shoulders",
                    Name = "Bench Press",
                    Description = "A bench press is an exercise that can be used to strengthen the muscles of the upper body, including the pectorals, arms, and shoulders. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells. During a bench press, you lower the weight down to chest level and then press upwards while extending your arms. This movement is considered one repetition, or rep.",
                    Level = "Intermediate",
                    Equipment = "Barbell, Weight Bench, Weight Plates"
                });

                exercises.Add(new Exercises()
                {
                    BodyPart = "Chest",
                    TargetMuscleGroup = "Pectorals and Triceps",
                    Name = "Dips",
                    Description = "Dips are a compound exercise meaning they work multiple muscle groups at a time. This can be beneficial for building upper body strength and building muscle mass. This effective upper body workout targets the muscles in your arms, chest, and back and can be adjusted to target one specific area to a greater degree.",
                    Level = "Beginner",
                    Equipment = "Dip Bar"
                });
            }

            if(abs)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Abs",
                    TargetMuscleGroup = "Lower abdomen",
                    Name = "Flutter Kicks",
                    Description = "Flutter kicks are an exercise that works the muscles of your core, specifically the lower rectus abdominal muscles, plus the hip flexors. They mimic a swimming stroke, but are performed on dry land.",
                    Level = "Beginner",
                    Equipment = "None"
                });

                 exercises.Add(new Exercises()
                {
                    BodyPart = "Abs",
                    TargetMuscleGroup = "Oblique, Pelvis, Lower Back, and Hips",
                    Name = "Crunches",
                    Description = "The crunch is a classic core exercise. It specifically trains your abdominal muscles, which are part of your core. Your core consists not only of your abs. It also includes your oblique muscles on the sides of your trunk, as well as the muscles in your pelvis, lower back, and hips. Together, these muscles help stabilize your body.",
                    Level = "Beginner",
                    Equipment = "None"
                });
            }

            if(back)
            {
                exercises.Add(new Exercises()
                {
                    BodyPart = "Back",
                    TargetMuscleGroup = "Upper Back, Latissimus Dorsi, and Teres Major",
                    Name = "Lat Pull Down",
                    Description = "The lat pulldown is a fantastic exercise to strengthen the latissimus dorsi muscle, the broadest muscle in your back, which promotes good postures and spinal stability. Form is crucial when performing a lat pulldown to prevent injury and reap the best results.",
                    Level = "Beginner",
                    Equipment = "Cable Pulley Machine"
                });

                exercises.Add(new Exercises()
                {
                    BodyPart = "Back",
                    TargetMuscleGroup = "Lower Back, Glutes, and Hamstrings",
                    Name = "Deadlift",
                    Description = "Dead lifts are considered a compound exercise, meaning they involve the use of multiple, large muscle groups. They can be excellent for improving strength, power, and improving lean muscle mass. Due to the involvement of multiple body areas they are also excellent for increasing heart rate and can be ideal for a cardiovascular focused weight circuits.",
                    Level = "Advance",
                    Equipment = "Barbell, Weight Plates"
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

            MessageBox.Show(ss.Name);
        }
    }
}
