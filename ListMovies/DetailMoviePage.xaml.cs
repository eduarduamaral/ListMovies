using System;
using Xamarin.Forms;
using ListMovies.Models;

namespace ListMovies
{
    public partial class DetailMoviePage : ContentPage
    {
        public DetailMoviePage(Movie movie)
        {
            InitializeComponent();
            UpdateDetainPage(movie);
            Title = movie.title;
        }

        private void UpdateDetainPage(Movie movie){
            imgMovie.Source = new UriImageSource
            {
                Uri = new Uri(movie.backdropPath),
                CachingEnabled = true,
                CacheValidity = new TimeSpan(5, 0, 0, 0)
            };
            overview.Text = "Overview: " + movie.overview;
            voteCount.Text = movie.voteCount.ToString();
            voteAverage.Text = movie.voteAverage.ToString();
            releaseDate.Text = movie.releaseDate.ToString();
            originalLanguage.Text = movie.originalLanguage.ToString();
            originalTitle.Text = "Titulo Original: " + movie.originalTitle;
            //FIXME Se Houver tempo obter as strings dos generos do servidor
            string aux = "";

            for (int i = 0; i < movie.genreIds.Count; i++)
            {
                var genre = new Genre();

                if(i < movie.genreIds.Count - 1){
                    aux = aux + genre.dictGenres[movie.genreIds[i]];
                    aux = aux + ", ";
                    //aux = aux + movie.genreIds[i].ToString() + ", ";
                }
                else
                {
                    aux = aux + genre.dictGenres[movie.genreIds[i]];
                    aux = aux + ".";
                    //aux = realmDB.All<Genre>().Where(d => d.Id == movie.genreIds[i]).ToString();
                    //aux = aux + movie.genreIds[i].ToString();
                }
            }
            genres.Text = "Genres: " + aux;
        }
    }
}
