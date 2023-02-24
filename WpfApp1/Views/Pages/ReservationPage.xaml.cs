using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models.Car;
using WpfApp1.Models.FrameManager;

namespace WpfApp1.Views.Pages
{
    public partial class ReservationPage : Page
    {
        private Requests request = new Requests();
        private Car currentCar;
        public ReservationPage(Car car)
        {
            InitializeComponent();
            currentCar = car;
        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = Convert.ToDateTime(StartDatePicker.SelectedDate.Value.Date.ToShortDateString());
            DateTime endDate = Convert.ToDateTime(EndDatePicker.SelectedDate.Value.Date.ToShortDateString());

            if((startDate.Date >= DateTime.Now.Date) && startDate.Date < endDate.Date)
            {
                if(MessageBox.Show($"Вы уверены, что хотите бронировать {currentCar.Passport.CarBrand} {currentCar.Passport.CarName}" +
                    $" на {startDate.Date.ToString("d")} по {endDate.Date.ToString("d")}?", "Вопрос",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    float totalPrice = PriceCounting(startDate, endDate, currentCar);
                    PriceText.Text = Convert.ToString(totalPrice);
                    request.CarBooking(MainWindow.currentUser, currentCar, totalPrice, startDate, endDate);
                    MessageBox.Show($"{currentCar.Passport.CarBrand} {currentCar.Passport.CarName} успешно бронирован!" +
                        $" Приходите по адресу: ул. имени генерала Карбышева, 95а " +
                        $"{startDate.Date.ToString("d")} числа и оплатите аренду на сумму: {totalPrice} рублей.");
                    FrameManager.Frame.Navigate(new MainPage());
                }
            }

            else
            {
                ClearDatePickers();
            }
        }

        private float PriceCounting(DateTime startDate, DateTime endDate, Car car) => (endDate.Day - startDate.Day) * car.PricePerDay;

        private void ClearDatePickers()
        {
            StartDatePicker.Text = null;
            EndDatePicker.Text = null;
        }
    }
}
