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
            List<Movie> listaFilmes = new List<Movie>();
            var realmDB = Realm.GetInstance();
            List<FavoriteMovies> x = realmDB.All<FavoriteMovies>().ToList();
            listaFilmes = x[0].items.ToList();
            lv1.ItemsSource = listaFilmes;
        }

        public async void metodoTest()
        {
            var teste = await MoviesService.GetMovietAsync();
        }
    }
}
