using System;
using Xamarin.Forms;
using ListMovies.Service;
using ListMovies.Models;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Linq;
using Plugin.Connectivity;

namespace ListMovies
{
    public partial class MainPage : ContentPage
    {
        FavoriteMovies favoriteMovies;
        public MainPage()
        {
            InitializeComponent();
            Load(null);
            Title = "Favorite Movies";
        }

        public async Task Load(string listId)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                UserDialogs.Instance.Alert("You not have internet connection... Please check!!");
                favoriteMovies = await MoviesService.GetMovietAsyncFromLocal(listId);
            }
            else
            {
                favoriteMovies = await MoviesService.GetMovietAsyncFomServer(listId);
            }

            if (favoriteMovies != null && favoriteMovies.items.Count > 0)
            {
                lv1.ItemsSource = favoriteMovies.items;
                informationLabel.IsVisible = false;
                lv1.IsVisible = true;
            }
            else
            {
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
            if (favoriteMovies.items.Count > 0)
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
        }

        void OnClick(object sender, EventArgs e)
        {
            UserDialogs.Instance.Prompt(new PromptConfig
            {
                Title = "Enter the id of the list to get the movies...",
                InputType = InputType.Number,
                OnAction = async result =>
                {
                    using (UserDialogs.Instance.Loading("Getting data...", null, null, true, MaskType.Clear))
                    {
                        await Load(result.Value);
                    }
                }
            });
        }
    }
}
