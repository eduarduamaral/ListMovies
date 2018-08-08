using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Realms;

namespace ListMovies.Models
{
    public class Genre
    {
        public Dictionary<int, string> dictGenres = new Dictionary<int, string>()
        {
            {12, "Adventure"},
            {28, "Action"},
            {16, "Animation"},
            {35, "Comedy"},
            {80, "Crime"},
            {99, "Documentary"},
            {18, "Drama"},
            {10751, "Family"},
            {14, "Fantasy"},
            {36, "History"},
            {27, "Horror"},
            {10402, "Music"},
            {9648, "Mystery"},
            {10749, "Romance"},
            {878, "Science Fiction"},
            {10770, "TV Movie"},
            {53, "Thriller"},
            {10752, "War"},
            {37, "Western"}
        };
    }
}