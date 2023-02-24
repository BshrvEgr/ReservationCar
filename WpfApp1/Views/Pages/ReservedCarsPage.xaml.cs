using System.Collections.Generic;
using System.Windows.Controls;
using WpfApp1.Models.Car;
using WpfApp1.Views.UserControls;

namespace WpfApp1.Views.Pages
{
    public partial class ReservedCarsPage : Page
    {
        List<ReservedCarCard> cards = new List<ReservedCarCard>();
        public ReservedCarsPage(List<Car> reservedCars)
        {
            InitializeComponent();

            foreach(var c in reservedCars)
            {
                cards.Add(new ReservedCarCard(c));
            }

            ReservedCarsListView.ItemsSource = cards;
        }
    }
}
