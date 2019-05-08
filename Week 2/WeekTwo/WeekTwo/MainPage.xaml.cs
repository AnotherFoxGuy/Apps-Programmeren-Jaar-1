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
        ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

        public MainPage()
        {
            InitializeComponent();

            movies.Add(new Movie
            {
                Title = "The Avengers (2012)",
                Description = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity."
            });
            movies.Add(new Movie
            {
                Title = "The Avengers: Age of Ultron (2015)",
                Description = "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan."
            });
            movies.Add(new Movie
            {
                Title = "The Avengers: Infinity War (2018)",
                Description = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe."
            });
            movies.Add(new Movie
            {
                Title = "The Avengers: End Game (2019)",
                Description = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to undo Thanos' actions and restore order to the universe."
            });

            MovieList.ItemsSource = movies;
        }
    }
}
