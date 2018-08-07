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

        public static async Task<FavoriteMovies> GetMovietAsync(string listId)
        {
            var realmDB = Realm.GetInstance();
            var favoriteMovies = realmDB.All<FavoriteMovies>().ToList();
            //var favoriteMovies = realmDB.All<FavoriteMovies>().Where(d => d.id == Int32.Parse(listId)).ToList();

            if (favoriteMovies.Count != 0)
                return favoriteMovies[favoriteMovies.Count - 1];
           else
                return await GetOnApiMoviesAsync(listId);
       
        }

        private static async Task<FavoriteMovies> GetOnApiMoviesAsync(string listId)
        {
            HttpClient client = new HttpClient();
            string url = Helpers.Utils.BASE_URL + listId + Helpers.Utils.COMPLeMENT_URL + Helpers.Utils.API_KEY;
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
    }
}
