using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Models.Car;
using WpfApp1.Models.FrameManager;
using WpfApp1.Views.Pages;

namespace WpfApp1.Views.UserControls
{
    public partial class CarCard : UserControl
    {
        private Car currentCar;
        public CarCard(Car car)
        {
            InitializeComponent();
            currentCar = car;
            DataContext = currentCar;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameManager.Frame.Navigate(new FullViewVehicleInformationPage(currentCar));
        }
    }
}
