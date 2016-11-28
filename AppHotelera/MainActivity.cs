using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using AppHotelera.DB;

namespace AppHotelera
{
    [Activity(Label = "AppHotelera", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "apphoteleradb1.db");




            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);
            createDatabase(pathToDatabase);


            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button breg = FindViewById<Button>(Resource.Id.buttonReg);

            breg.Click += delegate { StartActivity(typeof(RegActivity)); };

            button.Click += delegate
            {
               
                    StartActivity(typeof(ServicioActivity));
               

            };
        }




        private string createDatabase(string path)
        {
            try
            {
                var connection = new SQLiteAsyncConnection(path);
                {
                    connection.CreateTableAsync<Usuario>();
                    connection.CreateTableAsync<Empleado>();
                    connection.CreateTableAsync<Valet>();
                    connection.CreateTableAsync<Maid>();
                    connection.CreateTableAsync<Alimentos>();
                    return "Database created";
                }
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }







    }

}

