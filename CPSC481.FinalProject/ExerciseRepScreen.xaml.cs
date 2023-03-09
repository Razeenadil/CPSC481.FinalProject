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
    /// Interaction logic for ExerciseRepScreen.xaml
    /// </summary>
    public partial class ExerciseRepScreen : Page
    {
        int numOfSets = 0;
        public ExerciseRepScreen()
        {
            InitializeComponent();

            List<ExerciseSetAndRepCount> setAndRepCount = new List<ExerciseSetAndRepCount>();
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 6 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 6 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 8 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 8 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 8 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 10 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 10 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 10 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 5 });
            setAndRepCount.Add(new ExerciseSetAndRepCount() { SetCount = ++numOfSets, RepCount = 5 });

            setRepListBox.ItemsSource = setAndRepCount;
        }
    }

    public class ExerciseSetAndRepCount
    {
        public int SetCount { get; set; }
        public int RepCount { get; set; }
    }
}
