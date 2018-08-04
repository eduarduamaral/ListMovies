using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Realms;

namespace ListMovies.Models
{
    public class FavoriteMovies:RealmObject
    {
        [PrimaryKey]
        [JsonProperty(PropertyName = "id")]
        public int id{ get; set; }

        [JsonProperty(PropertyName = "created_by")]
        public string cretedBy { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }

        [JsonProperty(PropertyName = "favorite_count")]
        public int favoriteCount { get; set; }

        [JsonProperty(PropertyName = "items")]
        public IList<Movie> items { get; }

        [JsonProperty(PropertyName = "iso_639_1")]
        public string iso_639_1 { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string posterPath { get; set; }

        public FavoriteMovies()
        {
        }
    }
}
