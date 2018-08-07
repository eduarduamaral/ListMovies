using System;
using System.Collections.Generic;
using ListMovies.Models;
using Xamarin.Forms;

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
                if(i < movie.genreIds.Count - 1){
                    aux = aux + movie.genreIds[i].ToString() + ", ";
                }
                else
                {
                    aux = aux + movie.genreIds[i].ToString();
                }
            }
            genres.Text = "Genres " + aux;
        }
    }
}
