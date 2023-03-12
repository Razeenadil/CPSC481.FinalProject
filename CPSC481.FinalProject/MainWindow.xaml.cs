using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public event PropertyChangedEventHandler PropertyChanged;


        public MainWindow()
        {
            InitializeComponent();
            navigationIsClicked = false;
            armIsClicked = false;
            legIsClicked = false;
            absIsClicked = false;
            chestIsClicked = false;
            backIsClicked = false;
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(!backIsClicked)
            {
                Back.Opacity = 0.29;
                backIsClicked = true;
            }
            else
            {
                Back.Opacity = 0;
                backIsClicked = false;
            }
        }

        private void RightArm_Click(object sender, RoutedEventArgs e)
        {
            if (!armIsClicked)
            {
                RightArm.Opacity = 0.29;
                LeftArm.Opacity = 0.29;
                armIsClicked = true;
            }
            else
            {
                RightArm.Opacity = 0;
                LeftArm.Opacity = 0;
                armIsClicked = false;
            }
        }

        private void LeftArm_Click(object sender, RoutedEventArgs e)
        {
            if (!armIsClicked)
            {
                RightArm.Opacity = 0.29;
                LeftArm.Opacity = 0.29;
                armIsClicked = true;
            }
            else
            {
                RightArm.Opacity = 0;
                LeftArm.Opacity = 0;
                armIsClicked = false;
            }

        }

        private void RightLeg_Click(object sender, RoutedEventArgs e)
        {
            if (!legIsClicked)
            {
                RightLeg.Opacity = 0.29;
                LeftLeg.Opacity = 0.29;
                legIsClicked = true;
            }
            else
            {

                RightLeg.Opacity = 0;
                LeftLeg.Opacity = 0;
                legIsClicked = false;
            }
        }

        private void LeftLeg_Click(object sender, RoutedEventArgs e)
        {
            if (!legIsClicked)
            {
                RightLeg.Opacity = 0.29;
                LeftLeg.Opacity = 0.29;
                legIsClicked = true;
            }
            else
            {

                RightLeg.Opacity = 0;
                LeftLeg.Opacity = 0;
                legIsClicked = false;
            }
        }

        private void Abs_Click(object sender, RoutedEventArgs e)
        {
            if (!absIsClicked)
            {
                Abs.Opacity = 0.29;
                absIsClicked = true;    
            }
            else
            {
                Abs.Opacity = 0;
                absIsClicked = false;
            }
        }

        private void Chest_Click(object sender, RoutedEventArgs e)
        {
            if(!chestIsClicked)
            {
                Chest.Opacity = 0.29;
                chestIsClicked = true;
            }
            else
            {
                Chest.Opacity = 0;
                chestIsClicked = false;
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

   
    }
}
