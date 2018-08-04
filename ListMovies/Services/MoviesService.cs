using System;
using System.Net.Http;
using Newtonsoft.Json;
using ListMovies.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Realms;
using System.Linq;

namespace ListMovies.Service
{

    public class MoviesService
    {

        public static async Task<FavoriteMovies> GetMovietAsync()
        {
            var realmDB = Realm.GetInstance();

            var favoriteMovies = realmDB.All<FavoriteMovies>().ToList();

            if (favoriteMovies.Count != 0)
            {
                return favoriteMovies[favoriteMovies.Count - 1];
            }
            else
            {
                return await GetOnApiMoviesAsync();
            }
        }

        private static async Task<FavoriteMovies> GetOnApiMoviesAsync()
        {
            // Update port # in the following line.
            HttpClient client = new HttpClient();
            string url = "https://api.themoviedb.org/3/list/1313?language=pt-BR&api_key=1f54bd990f1cdfb230adb312546d765d";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                FavoriteMovies favoriteMovies = JsonConvert.DeserializeObject<FavoriteMovies>(await response.Content.ReadAsStringAsync());
                foreach (var item in favoriteMovies.items)
                {
                    item.posterPath = "https://image.tmdb.org/t/p/w500" + item.posterPath;
                    item.backdropPath = "https://image.tmdb.org/t/p/w500" + item.backdropPath;
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
    }
}
