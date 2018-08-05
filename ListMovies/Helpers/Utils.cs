using System;
namespace ListMovies.Helpers
{
    public static class Utils
    {
        public static readonly string API_KEY = "1f54bd990f1cdfb230adb312546d765d";
        public static readonly string BASE_URL = "https://api.themoviedb.org/3/list/";
        public static readonly string COMPLeMENT_URL = "?language=pt-BR&api_key=";
        public static readonly string IMAGE_URL = "https://image.tmdb.org/t/p";
        public static readonly string BACKDROP_SIZE = "/w500";
        public static readonly string POSTER_SIZE = "/w300";
    }
}
