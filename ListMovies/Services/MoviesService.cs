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
            // Update port # in the following line.
            HttpClient client = new HttpClient();
            string url = "https://api.themoviedb.org/3/list/1313?language=pt-BR&api_key=1f54bd990f1cdfb230adb312546d765d";
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string result = await client.GetStringAsync(url);
            //if (result.IsSuccessStatusCode)
            //{ 


            FavoriteMovies favoriteMovies = JsonConvert.DeserializeObject<FavoriteMovies>(result);
            var realmDB = Realm.GetInstance();

            realmDB.Write(() => {
                realmDB.Add(favoriteMovies, true);
            });

            return favoriteMovies;

        }
    }
}
