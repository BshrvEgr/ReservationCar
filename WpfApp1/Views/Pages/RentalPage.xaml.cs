using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WpfApp1.Models.Car;
using WpfApp1.Views.UserControls;

namespace WpfApp1.Views
{
    public partial class RentalPage : Page
    {
        Requests requests = new Requests();
        List<Car> cars;
        ObservableCollection<CarCard> cards = new ObservableCollection<CarCard>();
        public RentalPage()
        {
            InitializeComponent();
            cars = requests.GetAllFreeCars();
            foreach (var c in cars)
            {
                cards.Add(new CarCard(c));
            }

            CarCardsListView.ItemsSource = cards;
        }
    }
}
