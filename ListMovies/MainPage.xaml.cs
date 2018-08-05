using Xamarin.Forms;
using ListMovies.Models;
using System.Collections.Generic;
using ListMovies.Service;
using Realms;
using System.Linq;

namespace ListMovies
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Load();
        }

        public async void Load()
        {
            var favoriteMovies = await MoviesService.GetMovietAsync("1313");
            lv1.ItemsSource = favoriteMovies.items;
        }
    }
}
