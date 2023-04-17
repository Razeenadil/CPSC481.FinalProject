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
    /// Interaction logic for ProgressPageWeekly.xaml
    /// </summary>
    public partial class ProgressPageWeekly : Page
    {
        private bool navigationIsClicked;
        public event PropertyChangedEventHandler PropertyChanged;
        private List<string> data = new();
        private string? comboBoxSelection;

        public ProgressPageWeekly()
        {
            InitializeComponent();
            this.DataContext = this;
            navigationIsClicked = false;

            string initial = "Back Day";
            routineCombo.Text = initial;
            comboBoxSelection = initial;

            data.Add("Glutes Day");
            data.Add("Back Day");
            data.Add("Chest Day");
            routineCombo.ItemsSource = data;

            comboBoxSelection = Global_Data.routine_names[2];

            GenerateOverview();            
        }

        private void GenerateOverview()
        {
            for (int i = 1; i <= Global_Data.routine_dict[Global_Data.routine_chosen].Count; i++)
            {
                // check type of exercise
                if (Global_Data.routine_dict[Global_Data.routine_chosen][i].exercise_type == 0)
                {
                    double total_reps = Global_Data.routine_dict[Global_Data.routine_chosen][i].set_total * Global_Data.routine_dict[Global_Data.routine_chosen][i].rep_total;
                    double reps_done = 0;
                    foreach (int reps in Global_Data.routine_dict[Global_Data.routine_chosen][i].rep_results)
                    {
                        reps_done += reps;
                    }

                    double completion_rate = (double)(reps_done / total_reps);

                    if (completion_rate >= 0.75)
                    {
                        ExerciseData.Children.Add(new OverviewItem()
                        {
                            ExerciseName = i.ToString() + ". " + Global_Data.routine_dict[Global_Data.routine_chosen][i].exercise_name,
                            CompletionRate = completion_rate
                        });
                        //Message.Text = "good job";
                    }
                    else
                    {
                        ExerciseData.Children.Add(new OverviewItem()
                        {
                            ExerciseName = i.ToString() + ". " + Global_Data.routine_dict[Global_Data.routine_chosen][i].exercise_name,
                            CompletionRate = completion_rate
                        });
                        //Message.Text = "needs improvement";
                    }
                }
                else if (Global_Data.routine_dict[Global_Data.routine_chosen][i].exercise_type == 1)
                {
                    double total_time = 30;
                    double time_elapse = Global_Data.routine_dict[Global_Data.routine_chosen][i].rep_results[0];
                    double completion_rate = (double)(time_elapse / total_time);
                    if (completion_rate >= 0.75)
                    {
                        ExerciseData.Children.Add(new OverviewItem()
                        {
                            ExerciseName = i.ToString() + ". " + Global_Data.routine_dict[Global_Data.routine_chosen][i].exercise_name,
                            CompletionRate = completion_rate
                        });
                        //Message.Text = "good job";
                    }
                    else
                    {
                        ExerciseData.Children.Add(new OverviewItem()
                        {
                            ExerciseName = i.ToString() + ". " + Global_Data.routine_dict[Global_Data.routine_chosen][i].exercise_name,
                            CompletionRate = completion_rate
                        });
                        //Message.Text = "needs improvement";
                    }
                }
            }
        }




        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

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
                ellipseHack2.Visibility = Visibility.Visible;
                ellipseHack3.Visibility = Visibility.Visible;


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
                ellipseHack2.Visibility= Visibility.Hidden;
                ellipseHack3.Visibility= Visibility.Hidden;



                navigationIsClicked = false;
            }

        }


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
            mainWindow?.ChangeView(new LandingScreen());
        }

        private void routineCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxSelection = routineCombo.SelectedItem.ToString();
            Global_Data.routine_chosen = "Week-Ender";
            GenerateOverview();
        }
    }
}
