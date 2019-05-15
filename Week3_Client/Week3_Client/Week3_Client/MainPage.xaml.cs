using Xamarin.Forms;
using System.Timers;
using System;

namespace Week3_Client
{
    public partial class MainPage : ContentPage
    {
        Client client;
        int Itest = 0;

        public MainPage()
        {
            InitializeComponent();
            client = new Client();
            SetTimer();
        }
        private void SetTimer()
        {
            SomeText.Text = "Timer Started";
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                Itest++;
                test.Text = $"I: {Itest}";
                client.OpenConnection();
                Tempature.Text = $"Temp: {client.ReciveData()}";
                client.CloseConnection();

                return true; // return true to repeat counting, false to stop timer
            });
        }
    }
}
