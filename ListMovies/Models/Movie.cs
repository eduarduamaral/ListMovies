using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Realms;

namespace ListMovies.Models
{
    public class Movie:RealmObject
    {
        [JsonProperty(PropertyName = "vote_average")]
        public float voteAverage { get; set; }

        [JsonProperty(PropertyName = "vote_count")]
        public int voteCount { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "video")]
        public bool video { get; set; }

        [JsonProperty(PropertyName = "media_type")]
        public string mediaType { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string title { get; set; }

        [JsonProperty(PropertyName = "popularity")]
        public float popularity { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string posterPath { get; set; }

        [JsonProperty(PropertyName = "original_language")]
        public string originalLanguage { get; set; }

        [JsonProperty(PropertyName = "original_title")]
        public string originalTitle { get; set; }

        [JsonProperty(PropertyName = "genre_ids")]
        public IList<int> genreIds { get; }

        [JsonProperty(PropertyName = "backdrop_path")]
        public string backdropPath { get; set; }

        [JsonProperty(PropertyName = "adult")]
        public bool adult { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string overview { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string releaseDate { get; set; }

        public Movie()
        {
        }
    }
}
