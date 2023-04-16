using System;
using System.Collections;
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
        public static string routine_chosen = "";
        public static int exercise_number = 1;
        public struct exercise_info
        {
            public string exercise_name;
            public int exercise_type;  // rep = 0, timed = 1
            public int set_total;
            public int rep_total;
            public List<int> rep_results = new List<int>();

            public exercise_info()
            {
                exercise_name = "";
                exercise_type = 0;
                set_total = 0;
                rep_total = 0;
            }
        }

        public static Dictionary<string, Dictionary<int, exercise_info>> routine_dict = new Dictionary<string, Dictionary<int, exercise_info>>();

        public static Dictionary<string, string> routine_schedule = new Dictionary<string, string>();

        public static List<string> routine_names = new();


        public static void hardcoded_routine_progress()
        {
            int rep_total = 8;
            int set_total = 4;
            Random rnd = new Random();


            string routineName1 = "Glutes Day";
            string routineName2 = "Back Day";
            string routineName3 = "Chest Day";

            //first exercise for Glute Day
            exercise_info Info1 = new exercise_info();
            Info1.exercise_name = "Squats";
            Info1.exercise_type = 0;
            Info1.rep_total = rep_total;
            Info1.set_total = set_total;

            //second exercise for Glute Day
            exercise_info Info2 = new exercise_info();
            Info2.exercise_name = "Lunges";
            Info2.exercise_type = 0;
            Info2.rep_total = rep_total;
            Info2.set_total = set_total;

            //third exercise for Glute Day
            exercise_info Info3 = new exercise_info();
            Info3.exercise_name = "Box Jumps";
            Info3.exercise_type = 0;
            Info3.rep_total = rep_total;
            Info3.set_total = set_total;

            //fourth exercise for Glute Day
            exercise_info Info4 = new exercise_info();
            Info4.exercise_name = "Calf Raises";
            Info4.exercise_type = 0;
            Info4.rep_total = rep_total;
            Info4.set_total = set_total;

            for (int i = 0; i < set_total; i++)
            {
                Info1.rep_results.Add(rnd.Next(0, 9));
                Info2.rep_results.Add(rnd.Next(0, 9));
                Info3.rep_results.Add(rnd.Next(0, 9));
                Info4.rep_results.Add(rnd.Next(0, 9));

            }


            if(! routine_dict.ContainsKey(routineName1))
            {
                routine_dict.Add(routineName1, new Dictionary<int, exercise_info>());

                routine_dict[routineName1].Add(1, Info1);
                routine_dict[routineName1].Add(2, Info2);
                routine_dict[routineName1].Add(3, Info3);
                routine_dict[routineName1].Add(4, Info4);
            }
        }


        public static void Add_routine(string routine_name, string routine_date)
        {
            routine_dict.Add(routine_name, new Dictionary<int, exercise_info>());
            routine_schedule.Add(routine_name, routine_date);
            routine_names.Add(routine_name);
        }

        public static void Remove_routine(string routine_name)
        {
            routine_dict.Remove(routine_name);
            routine_schedule.Remove(routine_name);
        }

        public static void Add_rep_exercise(string routine, int num, string name, int set_total, int rep_total)
        {
            exercise_info Info = new exercise_info();
            Info.exercise_name = name;
            Info.exercise_type = 0;
            Info.rep_total = rep_total;
            Info.set_total = set_total;
            for (int i = 0; i < set_total; i++)
            {
                Info.rep_results.Add(rep_total);
            }
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