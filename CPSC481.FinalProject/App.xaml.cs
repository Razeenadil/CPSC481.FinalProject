using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CPSC481.FinalProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

    // On button click from view routine screen, remember to set the routine chosen
    public static class Global_Data
    {
        public static string routine_chosen = "My Routine!";
        public static int exercise_number = 1;
        public struct exercise_info
        {
            public string exercise_name;
            public int exercise_type;  // rep = 0, timed = 1
            public int set_count;
            public int rep_count;
            public int set_total;
            public int rep_total;

            public exercise_info()
            {
                exercise_name = "";
                exercise_type = 0;
                set_count = 0;
                rep_count = 0;
                set_total = 0;
                rep_total = 0;
            }
        }

        public static Dictionary<string, Dictionary<int, exercise_info>> routine_dict = new Dictionary<string, Dictionary<int, exercise_info>>();

        public static void Add_routine(string routine_name)
        {
            routine_dict.Add(routine_name, new Dictionary<int, exercise_info>());
        }

        public static void Remove_routine(string routine_name)
        {
            routine_dict.Remove(routine_name);
        }

        public static void Add_rep_exercise(string routine, int num, string name, int set_total, int rep_total)
        {
            exercise_info Info = new exercise_info();
            Info.exercise_name = name;
            Info.exercise_type = 0;
            Info.rep_count = rep_total;
            Info.rep_total = rep_total;
            Info.set_total = set_total;
            routine_dict[routine].Add(num, Info);
        }

        public static void Add_timed_exercise(string routine, int num, string name)
        {
            exercise_info Info = new exercise_info();
            Info.exercise_name = name;
            Info.exercise_type = 1;
            routine_dict[routine].Add(num, Info);
        }

        public static void Remove_exercise(string routine, int num)
        {
            routine_dict[routine].Remove(num);
        }
    }
}
