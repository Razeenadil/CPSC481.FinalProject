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
    /// Interaction logic for Registeration.xaml
    /// </summary>
    public partial class Registeration : Page
    {
      
        public Registeration()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Login());
        }



        private void Create_Account_Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(usernameTB.Text))
            {
                usernameTB.BorderBrush = new SolidColorBrush(Colors.Red);
                usernameTB.BorderThickness = new Thickness(3, 3, 3, 3);
            }
            else 
            {                
                usernameTB.BorderBrush = new SolidColorBrush(Colors.Black);
                usernameTB.BorderThickness = new Thickness(1, 1, 1, 1);
            }

            if (string.IsNullOrEmpty(emailTB.Text.ToString()))
            {
                emailTB.BorderBrush = new SolidColorBrush(Colors.Red);
                emailTB.BorderThickness = new Thickness(3, 3, 3, 3);
            }
            else
            {
                emailTB.BorderBrush = new SolidColorBrush(Colors.Black);
                emailTB.BorderThickness = new Thickness(1, 1, 1, 1);
            }

            if (string.IsNullOrEmpty(passwordTB.Password.ToString()))
            {
                passwordTB.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordTB.BorderThickness = new Thickness(3, 3, 3, 3);
            }
            else
            {
                passwordTB.BorderBrush = new SolidColorBrush(Colors.Black);
                passwordTB.BorderThickness = new Thickness(1, 1, 1, 1);
            }

            if (termsCheckbox.IsChecked == false)
            {
                termsCheckbox.BorderBrush = new SolidColorBrush(Colors.Red);
                termsCheckbox.BorderThickness = new Thickness(3, 3, 3, 3);
            }
            else
            {
                termsCheckbox.BorderBrush = new SolidColorBrush(Colors.Black);
                termsCheckbox.BorderThickness = new Thickness(1, 1, 1, 1);
            }

            if (!string.IsNullOrEmpty(usernameTB.Text) && !string.IsNullOrEmpty(emailTB.Text) && !string.IsNullOrEmpty(passwordTB.Password.ToString()) && termsCheckbox.IsChecked == true)
            {

                MessageBox.Show("Your account has been successfully created!", "Account Created", MessageBoxButton.OK, MessageBoxImage.Information);

                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new Login());
            }
        }

        private void Have_Account_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Login());
        }
    }

 

}
