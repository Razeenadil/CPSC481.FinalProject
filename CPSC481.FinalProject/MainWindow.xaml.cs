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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool NavigationIsClicked;
        public MainWindow()
        {
            InitializeComponent();
            NavigationIsClicked = false;
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            if(! NavigationIsClicked)
            {
                InfoButton.Visibility = Visibility.Visible;
                DemoButton.Visibility = Visibility.Visible;
                ProgressButton.Visibility = Visibility.Visible;
                RoutineButton.Visibility = Visibility.Visible;
                NavigationIsClicked = true;
            }
            else
            {
                InfoButton.Visibility = Visibility.Hidden;
                DemoButton.Visibility = Visibility.Hidden;
                ProgressButton.Visibility = Visibility.Hidden;
                RoutineButton.Visibility = Visibility.Hidden;
                NavigationIsClicked = false;
            }
        
        }

        private void OpenOccurence(object sender, RoutedEventArgs e)
        {
            RoutineOccurence routineOccurence= new RoutineOccurence();
            this.Content = routineOccurence;
        }
    }
}
