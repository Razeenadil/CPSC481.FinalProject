using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.ComponentModel;


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



        public DemoVideoPage(string value)
        {
            InitializeComponent();
            this.DataContext = this;

            SetSelection(value);
            navigationIsClicked = false;
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
            mainWindow?.ChangeView(new BodyPartSelectorPage());
        }
    }
}
