﻿using System;
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

        private void OpenRoutineStartScreen(object sender, RoutedEventArgs e)
        {
            //RoutineStartScreen routineStartScreen = new RoutineStartScreen();
            ExerciseScreen exerciseScreen = new ExerciseScreen();
            this.Content = exerciseScreen;//routineStartScreen;
        }
    }
}
