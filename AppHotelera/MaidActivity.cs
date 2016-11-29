using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;
using AppHotelera.DB;

namespace AppHotelera
{
    [Activity(Label = "MaidActivity")]
    public class MaidActivity : ServicioActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "apphoteleradb1.db");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ServLimpieza);

            loadHabitacion(pathToDatabase);
            // Create your application here

        Button b1 = FindViewById<Button>(Resource.Id.slbutton1);

            b1.Click += delegate { createDialog(); };

        }

        string loadData()
        {
            var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = Path.Combine(path.ToString(), "myfile.txt");
            string auto;

            using (var streamRdr = new StreamReader(filename))
            {
                auto = streamRdr.ReadLine();
            }

            return auto;
        }

        void loadHabitacion(string path)
        {
            SQLiteAsyncConnection con = new SQLiteAsyncConnection(path);
            string command;
            var uveh = FindViewById<TextView>(Resource.Id.sltextView1);
            command = "SELECT habitacion FROM Usuario WHERE correo = '" + loadData() + "';";
            uveh.Text += con.ExecuteScalarAsync<string>(command).Result;
        }



    }
}