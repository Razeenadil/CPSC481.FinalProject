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
    /// Interaction logic for RoutineOverviewItem.xaml
    /// </summary>
    public partial class RoutineOverviewItem : UserControl
    {
        private double incompletion_rate;
        private string exercise_name;
        public string ExerciseName
        {
            get { return exercise_name; }
            set
            {
                exercise_name = value;
                this.ExerciseNameText.Text = exercise_name;
            }
        }

        private double completion_rate;
        public double CompletionRate
        {
            get { return completion_rate; }
            set
            {
                completion_rate = value;
                string percentage = string.Format("{0:0.00}", completion_rate * 100);
                this.PercentageText.Text = percentage + "%";
                this.incompletion_rate = 1.0 - completion_rate;
                CreateSlice();
            }
        }
        public RoutineOverviewItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void CreateSlice()
        {
            if (completion_rate >= 0.75)
            {
                CompletionCircle.Fill = new SolidColorBrush(Colors.DarkGreen);
            }
            else if (completion_rate >= 0.5 && completion_rate < 0.75)
            {
                CompletionCircle.Fill = new SolidColorBrush(Color.FromRgb(246,190,0));
            }
            else
            {
                CompletionCircle.Fill = new SolidColorBrush(Colors.Tomato);
            }

            double radAngle = (incompletion_rate * 360);
            Point centerPoint = new Point();
            centerPoint.X = 100;
            centerPoint.Y = 100;

            double radius = 100;

            Point initialPoint = new Point();
            initialPoint.X = 100;
            initialPoint.Y = 0;

            this.PercentageSemiCircle.Fill = new SolidColorBrush(Colors.White);
            this.PercentageSemiCircle.Stroke = new SolidColorBrush(Colors.White);
            this.PercentageSemiCircle.StrokeThickness = 2;

            PathGeometry pathGeometry = new PathGeometry();
            PathFigureCollection pathFigureCollection = new PathFigureCollection();
            PathSegmentCollection sliceSegmentCollection = new PathSegmentCollection();

            //The path figure describes the shape in the slicePath object using geometry
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = centerPoint;//Set the start point to the center of the pie chart

            //Representing the first line of the slice from the centerpoint to the initial point 
            //I.E one length of the slice
            LineSegment firstLineSegment = new LineSegment();
            firstLineSegment.Point = initialPoint;
            sliceSegmentCollection.Add(firstLineSegment);

            //Calculate the next point along the circle that the slice should arc too.
            //Calculate the X and Y coordinates of the next point
            double x = 0;
            double y = 0;
            if (incompletion_rate >= 0 && incompletion_rate <= 0.25)
            {
                radAngle = (90 - radAngle) * (Math.PI / 180);
                x = centerPoint.X + (radius * Math.Cos(radAngle));
                y = centerPoint.Y - (radius * Math.Sin(radAngle));
            }
            else if (incompletion_rate > 0.25 && incompletion_rate <= 0.5)
            {
                radAngle = (radAngle - 90) * (Math.PI / 180);
                x = centerPoint.X + (radius * Math.Cos(radAngle));
                y = centerPoint.Y + (radius * Math.Sin(radAngle));
            }
            else if (incompletion_rate > 0.5 && incompletion_rate < 0.75)
            {
                radAngle = (270 - radAngle) * (Math.PI / 180);
                x = centerPoint.X - (radius * Math.Cos(radAngle));
                y = centerPoint.Y + (radius * Math.Sin(radAngle));
            }
            else if (incompletion_rate >= 0.75 && incompletion_rate < 1)
            {
                radAngle = (radAngle - 270) * (Math.PI / 180);
                x = centerPoint.X - (radius * Math.Cos(radAngle));
                y = centerPoint.Y - (radius * Math.Sin(radAngle));
            }
            else if (incompletion_rate == 1)
            {
                x = 99;
                y = 0;
            }

            Point newPoint = new Point(x, y);

            //Represents the arc segment of the slice
            ArcSegment sliceArcSegment = new ArcSegment();
            if (incompletion_rate > 0.5)
            {
                sliceArcSegment.IsLargeArc = true;
            }
            sliceArcSegment.Point = newPoint;
            sliceArcSegment.SweepDirection = SweepDirection.Clockwise;
            sliceArcSegment.Size = new Size(radius, radius);
            sliceSegmentCollection.Add(sliceArcSegment);

            //Representing the second line of the slice from the second point back to the center
            LineSegment secondLineSegment = new LineSegment();
            secondLineSegment.Point = centerPoint;
            sliceSegmentCollection.Add(secondLineSegment);

            pathFigure.Segments = sliceSegmentCollection;
            pathFigureCollection.Add(pathFigure);
            pathGeometry.Figures = pathFigureCollection;
            this.PercentageSemiCircle.Data = pathGeometry;
        }
        // Source: https://stackoverflow.com/questions/35582078/how-can-i-draw-a-segment-of-a-semi-circle-with-a-consistant-radius-using-an-arcs
    }
}
