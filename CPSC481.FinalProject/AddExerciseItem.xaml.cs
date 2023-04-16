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
    /// Interaction logic for AddExerciseItem.xaml
    /// </summary>
    public partial class AddExerciseItem : UserControl
    {

        private StackPanel parentPanel;

        public AddExerciseItem(StackPanel parent, string exerciseName)
        {
            InitializeComponent();
            this.parentPanel = parent;
            ExerciseNameTextBlock.Text = exerciseName;
        }


        private void ShowDemoInfoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            parentPanel.Children.Remove(this);
        }
    }
}
