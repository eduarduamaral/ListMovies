using System;
using Xamarin.Forms;
using ListMovies.Service;
using ListMovies.Models;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Linq;

namespace ListMovies
{
    public partial class MainPage : ContentPage
    {
        FavoriteMovies favoriteMovies;
        public MainPage()
        {
            InitializeComponent();
            Load(null);
            Title = "Filmes Favoritos";
        }

        public async Task Load(string listId)
        {
            favoriteMovies = await MoviesService.GetMovietAsync(listId);
            if(favoriteMovies != null && favoriteMovies.items.Count > 0){
                lv1.ItemsSource = favoriteMovies.items;
                informationLabel.IsVisible = false;
                lv1.IsVisible = true;
            }else{
                informationLabel.IsVisible = true;
                lv1.IsVisible = false;
            }
        }


        async void Handle_ItemSelectedAsync(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var movie = e.SelectedItem as Movie;
            await Navigation.PushAsync(new DetailMoviePage(movie));
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                lv1.ItemsSource = favoriteMovies.items;
            }
            else
            {
                var texto = MovieSearchBar.Text;
                lv1.ItemsSource = favoriteMovies.items.Where(x => x.title.ToLower().Contains(texto.ToLower()));
            }
        }

        void OnClick(object sender, EventArgs e)
        {
            UserDialogs.Instance.Prompt(new PromptConfig
            {
                Title = "Enter the id of the list to get the movies...",
                InputType = InputType.Number,
                OnAction = async result =>
                {
                    //UserDialogs.Instance.Loading("Getting data...");
                    await Load(result.Value);
                    //UserDialogs.Instance.HideLoading();
                }
            });
        }
    }
}
