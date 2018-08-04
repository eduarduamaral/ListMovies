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
            metodoTest();
        }

        public async void metodoTest()
        {
            var favoriteMovies = await MoviesService.GetMovietAsync();

            lv1.ItemsSource = favoriteMovies.items;
        }
    }
}
