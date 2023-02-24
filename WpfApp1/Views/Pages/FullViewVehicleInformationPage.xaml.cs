using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models.Car;
using WpfApp1.Models.FrameManager;

namespace WpfApp1.Views.Pages
{
    public partial class FullViewVehicleInformationPage : Page
    {
        private Car currentCar;
        public FullViewVehicleInformationPage(Car car)
        {
            InitializeComponent();
            currentCar = car;
            DataContext = currentCar;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if(FrameManager.Frame.CanGoBack)
                FrameManager.Frame.GoBack();
        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.Frame.Navigate(new ReservationPage(currentCar));
        }
    }
}
