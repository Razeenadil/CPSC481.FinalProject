using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CPSC481.FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool navigationIsClicked;
        private bool armIsClicked;
        private bool legIsClicked;
        private bool absIsClicked;
        private bool chestIsClicked;
        private bool backIsClicked;
        private string _selection;
        public event PropertyChangedEventHandler PropertyChanged;

      


        public MainWindow()
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

        public string Selection
        {
            get { return _selection; }
            set
            {
                if(value != _selection)
                {
                    _selection = value;
                    OnPropertyChanged(nameof(Selection));
                }
            }
        }

        private void SetSelection()
        {
            Selection = "";
            if (armIsClicked)
            {
                Selection = "Arms\n";
            }

            if(legIsClicked)
            {
                Selection = Selection + "Legs\n";
            }

            if (absIsClicked)
            {
                Selection = Selection + "Abs\n";
            }

            if (chestIsClicked)
            {
                Selection = Selection + "Chest\n";
            }

            if (backIsClicked)
            {
                Selection = Selection + "Back\n";
            }
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if (!navigationIsClicked)
            {
                InfoButton.Visibility = Visibility.Visible;
                DemoButton.Visibility = Visibility.Visible;
                ProgressButton.Visibility = Visibility.Visible;
                RoutineButton.Visibility = Visibility.Visible;
                navigationIsClicked = true;
            }
            else
            {
                InfoButton.Visibility = Visibility.Hidden;
                DemoButton.Visibility = Visibility.Hidden;
                ProgressButton.Visibility = Visibility.Hidden;
                RoutineButton.Visibility = Visibility.Hidden;
                navigationIsClicked = false;
            }

        }

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(!backIsClicked)
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
            if(!chestIsClicked)
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
            if(!BackButton.IsEnabled && NextButton.IsEnabled)
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

                if(backIsClicked)
                {
                    Back.Opacity = 0.29;
                }


            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(!NextButton.IsEnabled && BackButton.IsEnabled)
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

                if(armIsClicked)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LandingScreen demo = new();
            this.Content = demo;
        }
    }
}
