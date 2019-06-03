using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Week5;

namespace Week5
{
    public partial class MainPage : ContentPage
    {
        Connection connection = new Connection();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Interval_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DisplayInterval.Text = Interval.Value.ToString();
        }

        private void SendInterval_Clicked(object sender, EventArgs e)
        {
            if (connection.CheckValidIpAddress(IpEntry.Text))
            {
                connection.SetConnection(IpEntry.Text, 8000);
                UpdateInterval();
            }
        }

        private void UpdateInterval()
        {
            connection.OpenConnection();
            connection.ReciveData(Interval.Value.ToString() + ";");
            connection.CloseConnection();
        }
    }
}
