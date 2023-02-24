using System;
using System.Windows.Controls;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            if (DateTime.Now.Hour >= 21 && DateTime.Now.Minute > 0)
                IsOpenText.Text = "Откроется в 9:00";

            else
                IsOpenText.Text = "Закроется в 21:00";
        }
    }
}
