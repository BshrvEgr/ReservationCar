using System.Windows;
using WpfApp1.Models.User;

namespace WpfApp1.Views.Windows
{
    public partial class AuthorizationWindow : Window
    {
        Requests requests = new Requests();
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void AuthorizationWindow_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordText.Password != "" && LoginText.Text != "")
            {
                 User user = requests.GetUser(LoginText.Text, PasswordText.Password);

                if (user.Login != null && user.Password != null)
                {
                    if(user.Login == LoginText.Text && user.Password == PasswordText.Password)
                    {
                        MainWindow window = new MainWindow(user);
                        window.Show();
                        this.Close();
                    }

                    else
                    {
                        ClearFields();
                    }
                }

                else
                {
                    ClearFields();
                }
            }
        }

        private void ClearFields()
        {
            LoginText.Text = "";
            PasswordText.Password = "";
        }
    }
}
