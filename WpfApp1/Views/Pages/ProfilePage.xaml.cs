using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models.User;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private User currentUser;
        public ProfilePage(User user)
        {
            InitializeComponent();
            currentUser = user;
            DataContext = currentUser;
            ShowPasswordText.Text = "Hidden";
        }

        private void ShowOrHidePassword_Click(object sender, RoutedEventArgs e)
        {
            if (ShowPasswordText.Text == "Hidden")
                ShowPasswordText.Text = currentUser.Password;

            else
                ShowPasswordText.Text = "Hidden";
        }
    }
}
