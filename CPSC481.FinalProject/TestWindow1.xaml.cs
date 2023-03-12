using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CPSC481.FinalProject
{
    /// <summary>
    /// Interaction logic for TestWindow1.xaml
    /// </summary>
    public partial class TestWindow1 : Window
    {
        public TestWindow1()
        {
            InitializeComponent();
        }

        private void OpenRoutineScreen(object sender, RoutedEventArgs e)
        {

            RoutineStartScreen routineStartScreen = new RoutineStartScreen();
            this.Content = routineStartScreen;
        }

        private void OpenRepScreen(object sender, RoutedEventArgs e)
        {
            ExerciseRepScreen exerciseRepScreen = new ExerciseRepScreen();
            this.Content = exerciseRepScreen;
        }

        private void OpenTimerScreen(object sender, RoutedEventArgs e)
        {
            ExerciseTimerScreen exerciseTimerScreen = new ExerciseTimerScreen();
            this.Content = exerciseTimerScreen;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void OpenDemoScreen(object sender, RoutedEventArgs e)
        {
            DemoExerciseScreen demoExerciseScreen = new DemoExerciseScreen();
            this.Content = demoExerciseScreen;
        }
    }
}
