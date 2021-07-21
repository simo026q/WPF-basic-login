using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Login
{
    public class User
    {
        // List of all the users
        public static List<User> Users { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        private string Password;
        public User(string username, string email, string password)
        {
            if (ValidateEmail(email)) Email = email;
            else Email = "";
            Username = username.ToLower();
            Password = password;
            if (Users == null) Users = new List<User>();
        }
        // Creates and validates a new user
        public static bool CreateValidUser(string username, string email, string password)
        {
            if (Users == null) Users = new List<User>();
            bool valid = true;
            username = username.ToLower();
            if (username == "" || password == "")
            {
                valid = false;
                MessageBox.Show("The username or/and password field is empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return valid;
            }
            if (password.Length < 8)
            {
                valid = false;
                MessageBox.Show("Password does not meet the requirements. The password must be at least 8 characters!", "Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return valid;
            }
            // If the email and username has not been used before
            foreach (User user in Users)
            {
                if (user.Username == username || (user.Email == email && user.Email != ""))
                {
                    valid = false;
                    MessageBox.Show("The username or email is already in use!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return valid;
                }
            }
            // If the email is not valid
            if (!ValidateEmail(email)) email = "";
            if (valid)
            {
                User user = new User(username, email, password);
                Users.Add(user);
            }
            return valid;
        }
        // Set the users password
        public void SetPassword(string newPassword)
        {
            if (newPassword != "")
            {
                Password = newPassword;
            }
        }
        // Check if the username/email and password is valid
        public static bool ValidateLogin(string username, string password)
        {
            bool valid = false;
            foreach (User user in Users)
            {
                if ((user.Username == username || (user.Email == username && user.Email != "")) && user.Password == password)
                {
                    valid = true;
                    continue;
                }
            }
            return valid;
        }
        // Check if a email is in the valid format
        public static bool ValidateEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
