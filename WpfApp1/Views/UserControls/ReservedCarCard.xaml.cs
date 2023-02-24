using System.Windows.Controls;
using WpfApp1.Models.Car;

namespace WpfApp1.Views.UserControls
{
    public partial class ReservedCarCard : UserControl
    {
        public ReservedCarCard(Car car)
        {
            InitializeComponent();
            DataContext = car;
        }
    }
}
