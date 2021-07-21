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

namespace Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool signedIn = false;
        public MainWindow()
        {
            InitializeComponent();
            User.CreateValidUser("simo026q", "simonchristensen03@gmail.com", "eqq67awk");
            DataGridUsers.ItemsSource = User.Users;
        }
        // Button sign in
        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string inputUsername = SigninUsername.Text;
            string inputPassword = SigninPassword.Password;
            SigninUsername.Text = "";
            SigninPassword.Password = "";
            if (ValidateField(inputUsername) && ValidateField(inputPassword))
            {
                if (User.ValidateLogin(inputUsername, inputPassword))
                {
                    signedIn = true;
                    TabUsers.Visibility = Visibility.Visible;
                    MessageBox.Show(String.Format("Signed In as: {0}", inputUsername), "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Wrong log in :(", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty field(s)", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Button sign up
        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            string inputUsername = SignupUsername.Text;
            string inputEmail = SignupEmail.Text;
            string inputPassword = SignupPassword.Password;
            SignupUsername.Text = "";
            SignupEmail.Text = "";
            SignupPassword.Password = "";
            if (ValidateField(inputUsername) && ValidateField(inputPassword))
            {
                MessageBoxResult confirm = MessageBox.Show(String.Format("Are you sure you want to create: {0}", inputUsername), "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (confirm == MessageBoxResult.Yes)
                {
                    User.CreateValidUser(inputUsername, inputEmail, inputPassword);
                }
            }
        }
        // Check if the field is empty
        public bool ValidateField(string field)
        {
            return (field != "");
        }
    }
}
