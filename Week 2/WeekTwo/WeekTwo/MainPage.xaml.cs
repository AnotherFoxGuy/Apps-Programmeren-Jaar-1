using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeekTwo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        DatabaseManager _databaseManager;
        public MainPage()
        {
            InitializeComponent();
            _databaseManager = new DatabaseManager();
            MovieList.ItemsSource = _databaseManager.GetAllMovies();
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (!_databaseManager.DoesMovieExist(MovieTitle.Text))
            {
                DisplayAlert("Bestaat niet!", "Controleer de titel", "OK");
                return;
            }

            _databaseManager.DeleteMovie(MovieTitle.Text);
            MovieList.ItemsSource = _databaseManager.GetAllMovies();
            MovieTitle.Text = "";
            MovieDescription.Text = "";
            MovieImage.Text = "";

        }
        private void AddUpdateButton_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(MovieTitle.Text))
            {
                DisplayAlert("Verplicht veld!", "Voer een titelnaam in", "OK");
                return;
            }
            else if (String.IsNullOrEmpty(MovieDescription.Text))
            {
                DisplayAlert("Verplicht veld!", "Voeg een omschrijving toe", "OK");
                return;
            }
            else if (String.IsNullOrEmpty(MovieImage.Text))
            {
                DisplayAlert("Verplicht veld!", "Voer een afbeeldingnaam in", "OK");
                return;
            }

            _databaseManager.AddOrUpdateMovie(MovieTitle.Text, MovieDescription.Text, MovieImage.Text);
            MovieList.ItemsSource = _databaseManager.GetAllMovies();
            MovieTitle.Text = "";
            MovieDescription.Text = "";
            MovieImage.Text = "";
            
        }

        private void MovieList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMovie = e.SelectedItem as Movie;

            if (selectedMovie == null)
                return;

            MovieTitle.Text = selectedMovie.Title;
            MovieDescription.Text = selectedMovie.Description;
            MovieImage.Text = selectedMovie.ImageSource;
        }
    }
}
