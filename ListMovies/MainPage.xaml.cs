using System;
using Xamarin.Forms;
using ListMovies.Service;
using ListMovies.Models;
using Acr.UserDialogs;

namespace ListMovies
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Load(null);
            Title = "Filmes Favoritos";
        }

        public async void Load(string listId)
        {
            var favoriteMovies = await MoviesService.GetMovietAsync(listId);
            if(favoriteMovies != null && favoriteMovies.items.Count > 0){
                lv1.ItemsSource = favoriteMovies.items;
            }else{
                //Mostrar stack layout com informações que a lista está vazia
            }
        }


        async void Handle_ItemSelectedAsync(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var movie = e.SelectedItem as Movie;
            await Navigation.PushAsync(new DetailMoviePage(movie));
        }

        void OnClick(object sender, EventArgs e)
        {
            UserDialogs.Instance.Prompt(new PromptConfig
            {
                Title = "Enter the id of the list to get the movies...",
                OnAction = async result =>
                {
                    Load(result.Value);
                }
            });        
        }
    }
}
