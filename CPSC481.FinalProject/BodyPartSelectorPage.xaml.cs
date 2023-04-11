using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace CPSC481.FinalProject
{
    /// <summary>
    /// Interaction logic for BodyPartSelectorPage.xaml
    /// </summary>
    public partial class BodyPartSelectorPage : Page, INotifyPropertyChanged
    {
        private bool navigationIsClicked;
        private bool armIsClicked;
        private bool legIsClicked;
        private bool absIsClicked;
        private bool chestIsClicked;
        private bool backIsClicked;
        private bool arms, legs, chest, back, abs;
        private string _selection;
        private string selectionParameter;

        public event PropertyChangedEventHandler PropertyChanged;

        public static bool cameFromCreateWorkout = false;

        public BodyPartSelectorPage()
        {
            InitializeComponent();
            this.DataContext = this;

            navigationIsClicked = false;
            armIsClicked = false;
            legIsClicked = false;
            absIsClicked = false;
            chestIsClicked = false;
            backIsClicked = false;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            if (cameFromCreateWorkout)
            {
                cameFromCreateWorkout = false;
                CreateWorkoutRoutine.newRoutineBodyParts = "Choose Body Part";
                mainWindow?.ChangeView(new CreateWorkoutRoutine());
            }
            else
            {
                mainWindow?.ChangeView(new LandingScreen());

            }

        }

        private void Apply_Filter_Button(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(selectionParameter))
            {
                selectionParameter = "Selection: No filters applied";
            }
            else
            {
                selectionParameter = selectionParameter.Trim();
                selectionParameter = selectionParameter.TrimEnd('/');
            }

            var mainWindow = (MainWindow)Application.Current.MainWindow;

            if (cameFromCreateWorkout)
            {
                cameFromCreateWorkout = false;
                CreateWorkoutRoutine.newRoutineBodyParts = selectionParameter;
                mainWindow?.ChangeView(new CreateWorkoutRoutine());
            }
            else
            {
                mainWindow?.ChangeView(new DemoVideoPage(selectionParameter, arms, legs, back, chest, abs));
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

        private void SetSelection()
        {
            Selection = "";
            selectionParameter = "Selection: ";
            arms = false;
            legs = false;
            chest = false;
            abs = false;
            back = false;

            if (armIsClicked)
            {
                arms = true;
                Selection = "Arms\n";
                selectionParameter = selectionParameter + "Arms / ";
            }

            if (legIsClicked)
            {
                legs = true;
                Selection = Selection + "Legs\n";
                selectionParameter = selectionParameter + "Legs / ";
            }

            if (absIsClicked)
            {
                abs = true;
                Selection = Selection + "Abs\n";
                selectionParameter = selectionParameter + "Abs / ";
            }

            if (chestIsClicked)
            {
                chest = true;
                Selection = Selection + "Chest\n";
                selectionParameter = selectionParameter + "Chest / ";
            }

            if (backIsClicked)
            {
                back = true;
                Selection = Selection + "Back\n";
                selectionParameter = selectionParameter + "Back / ";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (!backIsClicked)
            {
                Back.Opacity = 0.29;
                backIsClicked = true;
                SetSelection();

            }
            else
            {
                Back.Opacity = 0;
                backIsClicked = false;
                SetSelection();

            }
        }

        private void RightArm_Click(object sender, RoutedEventArgs e)
        {
            if (!armIsClicked)
            {
                RightArm.Opacity = 0.29;
                LeftArm.Opacity = 0.29;
                armIsClicked = true;
                SetSelection();

            }
            else
            {
                RightArm.Opacity = 0;
                LeftArm.Opacity = 0;
                armIsClicked = false;
                SetSelection();

            }

        }

        private void LeftArm_Click(object sender, RoutedEventArgs e)
        {
            if (!armIsClicked)
            {
                RightArm.Opacity = 0.29;
                LeftArm.Opacity = 0.29;
                armIsClicked = true;
                SetSelection();

            }
            else
            {
                RightArm.Opacity = 0;
                LeftArm.Opacity = 0;
                armIsClicked = false;
                SetSelection();

            }

        }

        private void RightLeg_Click(object sender, RoutedEventArgs e)
        {
            if (!legIsClicked)
            {
                RightLeg.Opacity = 0.29;
                LeftLeg.Opacity = 0.29;
                legIsClicked = true;
                SetSelection();

            }
            else
            {

                RightLeg.Opacity = 0;
                LeftLeg.Opacity = 0;
                legIsClicked = false;
                SetSelection();

            }
        }

        private void LeftLeg_Click(object sender, RoutedEventArgs e)
        {
            if (!legIsClicked)
            {
                RightLeg.Opacity = 0.29;
                LeftLeg.Opacity = 0.29;
                legIsClicked = true;
                SetSelection();

            }
            else
            {

                RightLeg.Opacity = 0;
                LeftLeg.Opacity = 0;
                legIsClicked = false;
                SetSelection();

            }
        }

        private void Abs_Click(object sender, RoutedEventArgs e)
        {
            if (!absIsClicked)
            {
                Abs.Opacity = 0.29;
                absIsClicked = true;
                SetSelection();

            }
            else
            {
                Abs.Opacity = 0;
                absIsClicked = false;
                SetSelection();

            }
        }

        private void Chest_Click(object sender, RoutedEventArgs e)
        {
            if (!chestIsClicked)
            {
                Chest.Opacity = 0.29;
                chestIsClicked = true;
                SetSelection();

            }
            else
            {
                Chest.Opacity = 0;
                chestIsClicked = false;
                SetSelection();

            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!BackButton.IsEnabled && NextButton.IsEnabled)
            {
                ImageHolder.Source = new BitmapImage(new Uri(@"Images/BodyPartSelector/BodyView2.jpg", UriKind.Relative));
                BackButton.IsEnabled = true;
                NextButton.IsEnabled = false;
                BackButton.Opacity = 1;
                NextButton.Opacity = 0.365;

                //set all the body buttons for the front to false 
                RightArm.Opacity = 0;
                LeftArm.Opacity = 0;
                RightLeg.Opacity = 0;
                LeftLeg.Opacity = 0;
                Abs.Opacity = 0;
                Chest.Opacity = 0;

                RightArm.IsEnabled = false;
                LeftArm.IsEnabled = false;
                RightLeg.IsEnabled = false;
                LeftLeg.IsEnabled = false;
                Abs.IsEnabled = false;
                Chest.IsEnabled = false;

                //set the back body parts to enables 
                Back.IsEnabled = true;

                if (backIsClicked)
                {
                    Back.Opacity = 0.29;
                }


            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (!NextButton.IsEnabled && BackButton.IsEnabled)
            {
                ImageHolder.Source = new BitmapImage(new Uri(@"Images/BodyPartSelector/BodyView1.jpg", UriKind.Relative));
                NextButton.IsEnabled = true;
                BackButton.IsEnabled = false;
                NextButton.Opacity = 1;
                BackButton.Opacity = 0.365;


                //set all the body buttons for the back to false 
                Back.IsEnabled = false;

                Back.Opacity = 0;

                //set all the body buttons for the front to enabled 
                RightArm.IsEnabled = true;
                LeftArm.IsEnabled = true;
                RightLeg.IsEnabled = true;
                LeftLeg.IsEnabled = true;
                Abs.IsEnabled = true;
                Chest.IsEnabled = true;

                if (armIsClicked)
                {
                    RightArm.Opacity = 0.29;
                    LeftArm.Opacity = 0.29;
                }

                if (legIsClicked)
                {
                    RightLeg.Opacity = 0.29;
                    LeftLeg.Opacity = 0.29;
                }

                if (absIsClicked)
                {
                    Abs.Opacity = 0.29;
                }

                if (chestIsClicked)
                {
                    Chest.Opacity = 0.29;
                }
            }
        }

        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            armIsClicked = false;
            legIsClicked = false;
            chestIsClicked = false;
            absIsClicked = false;
            backIsClicked = false;

            RightArm.Opacity = 0;
            LeftArm.Opacity = 0;
            RightLeg.Opacity = 0;
            LeftLeg.Opacity = 0;
            Chest.Opacity = 0;
            Abs.Opacity = 0;
            Back.Opacity = 0;

            SetSelection();
        }

    }
}