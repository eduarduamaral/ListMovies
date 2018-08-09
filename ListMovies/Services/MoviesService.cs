using Realms;
using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using ListMovies.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ListMovies.Service
{

    public class MoviesService
    {

        public static async Task<FavoriteMovies> GetMovietAsyncFomServer(string listId)
        {
            var realmDB = Realm.GetInstance();
            if (listId != null){
                return await GetOnApiMoviesAsync(listId);
            }else{
                return null;
            }
        }

        public static async Task<FavoriteMovies> GetMovietAsyncFromLocal (string listId)
        {
            var realmDB = Realm.GetInstance();
            if (listId == null)
            {
                var favoriteMovies = realmDB.All<FavoriteMovies>().ToList();
                if (favoriteMovies.Count != 0)
                {
                    return favoriteMovies[favoriteMovies.Count - 1];
                }
                else
                {
                    return null;
                }
            }else{
                return null;
            }
        }

        private static async Task<FavoriteMovies> GetOnApiMoviesAsync(string listId)
        {
            HttpClient client = new HttpClient();
            string url = Helpers.Utils.BASE_URL_LIST + listId + Helpers.Utils.COMPLEMENT_URL + Helpers.Utils.API_KEY;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                FavoriteMovies favoriteMovies = JsonConvert.DeserializeObject<FavoriteMovies>(await response.Content.ReadAsStringAsync());
                foreach (var item in favoriteMovies.items)
                {
                    item.posterPath = Helpers.Utils.IMAGE_URL + Helpers.Utils.POSTER_SIZE + item.posterPath;
                    item.backdropPath = Helpers.Utils.IMAGE_URL + Helpers.Utils.BACKDROP_SIZE + item.backdropPath;
                }

                var realmDB = Realm.GetInstance();

                realmDB.Write(() => { 
                    realmDB.Add(favoriteMovies, true);
                });

                return favoriteMovies;
            }
            else
            {
                new Exception("Erro - Status Code: " + response.StatusCode + "Houve um problema ao obter a lista de filmes");
                return null;
            }    
        }

        //private static async Task<Genre> GetOnApiGenresAsync(){
        //    HttpClient client = new HttpClient();
        //    string url = Helpers.Utils.BASE_URL_GENRE + Helpers.Utils.API_KEY;
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = await client.GetAsync(url);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        Genre genres = JsonConvert.DeserializeObject<Genre>(await response.Content.ReadAsStringAsync());

        //        var realmDB = Realm.GetInstance();

        //        realmDB.Write(() => {
        //            realmDB.Add(genres, true);
        //        });

        //        return genres;
        //    }
        //    else
        //    {
        //        new Exception("Erro - Status Code: " + response.StatusCode + "Houve um problema ao obter os generos");
        //        return null;
        //    }  
        //}

    }
}
