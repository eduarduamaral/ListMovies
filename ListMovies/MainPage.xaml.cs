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
            if (listId != null)
            {
                var favoriteMovies = await MoviesService.GetMovietAsync(listId);
                lv1.ItemsSource = favoriteMovies.items;
            }
            else
            {
                var favoriteMovies = await MoviesService.GetMovietAsync("1313");
                lv1.ItemsSource = favoriteMovies.items;
            }

        }


        async void Handle_ItemSelectedAsync(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var movie = e.SelectedItem as Movie;
            await Navigation.PushAsync(new DetailMoviePage(movie));
        }

        void OnClick(object sender, EventArgs e)
        {
            //ToolbarItem tbi = (ToolbarItem)sender;
            //this.DisplayAlert("Selected!", tbi.Text, "OK");
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
