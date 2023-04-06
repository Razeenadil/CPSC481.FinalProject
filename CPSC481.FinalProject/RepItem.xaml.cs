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
    /// Interaction logic for RepItem.xaml
    /// </summary>
    public partial class RepItem : UserControl
    {
        private int set_number;
        public int SetNumber
        {
            get { return set_number; }
            set 
            { 
                set_number = value;
                this.SetNum.Text = set_number.ToString();
            }
        }
        
        private int reps_done;
        public int RepsDone
        {
            get { return reps_done; }
            set
            {
                reps_done = value;
                this.RepsComplete.Text = this.reps_done.ToString();
            }
        }

        private int total_reps;
        public int TotalReps
        {
            get { return total_reps; }
            set
            {
                total_reps = value;
            }
        }

        public RepItem()
        {
            InitializeComponent();
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (reps_done > 0)
            {
                reps_done--;
                Global_Data.routine_dict[Global_Data.routine_chosen][Global_Data.exercise_number].rep_results[set_number - 1] = reps_done;
                this.RepsComplete.Text = this.reps_done.ToString();
            }
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (reps_done < total_reps)
            {
                reps_done++;
                Global_Data.routine_dict[Global_Data.routine_chosen][Global_Data.exercise_number].rep_results[set_number - 1] = reps_done;
                this.RepsComplete.Text = this.reps_done.ToString();
            }
        }
    }
}
