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
    /// Interaction logic for RoutineStartScreen.xaml
    /// </summary>
    public partial class RoutineStartScreen : Page
    {
        int num_of_exercises = 1;
        public RoutineStartScreen()
        {
            InitializeComponent();
            List<ExerciseItem> exercises = new List<ExerciseItem>();
            exercises.Add(new ExerciseItem() { Num = num_of_exercises++, Name = "Knee-To-Chest"});
            exercises.Add(new ExerciseItem() { Num = num_of_exercises++, Name = "Seated Spinal Twist" });
            exercises.Add(new ExerciseItem() { Num = num_of_exercises++, Name = "Cat Stretch" });

            icRoutineList.ItemsSource = exercises;
        }

        private void StartRoutine(object sender, RoutedEventArgs e)
        {
            
        }
    }

    public class ExerciseItem
    {
        public int Num { get; set; }
        public string? Name { get; set; }
    }
}
