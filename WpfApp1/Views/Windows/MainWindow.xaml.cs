using System.Windows;
using WpfApp1.Models.FrameManager;
using WpfApp1.Models.User;
using WpfApp1.Views;
using WpfApp1.Views.Pages;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Requests request = new Requests();
        public static User currentUser;
        public MainWindow(User user)
        {
            InitializeComponent();

            currentUser = user;

            FrameManager.Frame = MainFrame;
            FrameManager.Frame.Navigate(new MainPage());
        }
        private void GoProfile_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new ProfilePage(currentUser));
        }

        private void GoMarket_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new RentalPage());
        }

        private void GoMenu_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new MainPage());
        }

        private void GoMyReservedCars_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new ReservedCarsPage(request.GetReservedCars(currentUser)));
        }
    }
}
