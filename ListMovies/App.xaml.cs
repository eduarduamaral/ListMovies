using System;
using System.IO;
//using ListMovies.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ListMovies
{
    public partial class App : Application
    {
        //static ListMoviesDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //public static ListMoviesDatabase Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new ListMoviesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
        //        }
        //        return database;
        //    }
        //}
    }
}
