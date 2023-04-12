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
    /// Interaction logic for RoutineItem.xaml
    /// </summary>
    public partial class RoutineItem : UserControl
    {
        private string routine_name;
        public string RoutineName
        {
            get { return routine_name; }
            set
            { 
                routine_name = value;
                this.Routine_Name.Text = routine_name;
            }
        }

        private string routine_date;
        public string RoutineDate
        {
            get { return routine_date; }
            set
            {
                routine_date = value;
                this.Routine_Date.Text = routine_date;
            }
        }

        public RoutineItem()
        {
            InitializeComponent();
        }

        private void Routine_Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            Global_Data.routine_chosen = routine_name;
            mainWindow?.ChangeView(new RoutineStartScreen());
        }
    }
}
