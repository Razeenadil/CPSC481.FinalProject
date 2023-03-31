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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            this.DataContext = this;

        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(usernameTB.Text))
            {
                usernameTB.BorderBrush = new SolidColorBrush(Colors.Red);
                usernameTB.BorderThickness = new Thickness(3, 3, 3, 3);
            }
            else
            {
                usernameTB.BorderBrush = new SolidColorBrush(Colors.Black);
            }

            if(string.IsNullOrEmpty(passwordTB.Password.ToString()))
            {
                passwordTB.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordTB.BorderThickness = new Thickness(3, 3, 3, 3);
            }
            else
            {
                passwordTB.BorderBrush = new SolidColorBrush(Colors.Black);

            }

            if (!string.IsNullOrEmpty(usernameTB.Text) && !string.IsNullOrEmpty(passwordTB.Password.ToString()))
            {
                if(usernameTB.Text == "admin" && passwordTB.Password.ToString() == "admin")
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new LandingScreen());
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect!", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


          
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Registeration());
        }

        private void Guest_Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new LandingScreen());
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Welcome());
        }
    }
}
