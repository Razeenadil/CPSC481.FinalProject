using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AddExerciseItem.xaml
    /// </summary>
    public partial class AddExerciseItem : UserControl
    {

        private AddExercise parentCaller;
        private StackPanel parentPanel;
        public string name;
        private string description;
        private string level;
        private string targetMuscleGroup;
        private string equipment;
        private int exerciseIndex;
        public int reps = 1;
        public int sets = 1;

        public AddExerciseItem(AddExercise parentCaller, StackPanel parentPanel, int exerciseIndex, string name, string description, string level, string targetMuscleGroup, string equipment)
        {
            InitializeComponent();
            this.parentCaller = parentCaller;
            this.parentPanel = parentPanel;
            this.name = name;
            ExerciseNameTextBlock.Text = name;
            this.description = description;
            this.level = level;
            this.equipment = equipment;
            this.targetMuscleGroup = targetMuscleGroup;
            this.exerciseIndex = exerciseIndex;
        }


        private void ShowDemoInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new DemoExerciseScreen(name, description, level, targetMuscleGroup, equipment, parentCaller));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            parentCaller.exerciseList.RemoveAt(exerciseIndex);
            parentPanel.Children.Remove(this);
        }

        private void SetsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SetsTextBox.Text != "")
            {
                Debug.WriteLine(SetsTextBox.Text);

                this.sets = int.Parse(SetsTextBox.Text);
                Debug.WriteLine(this.name + " - reps = " + this.reps);
                Debug.WriteLine(this.name + " - sets = " + this.sets);

            }
        }

        private void RepsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RepsTextBox.Text != "")
            {
                Debug.WriteLine(RepsTextBox.Text);
                this.reps = int.Parse(RepsTextBox.Text);
                Debug.WriteLine(this.name + " - reps = " + this.reps);
                Debug.WriteLine(this.name + " - sets = " + this.sets);

            }

        }
    }
}
