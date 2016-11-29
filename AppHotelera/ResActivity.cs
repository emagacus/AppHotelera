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
    [Activity(Label = "ResActivity")]
    public class ResActivity : ServicioActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "apphoteleradb1.db");
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Restaurant);
            loadHabitacion(pathToDatabase);
            // Create your application here
            Button b1 = FindViewById<Button>(Resource.Id.srbutton1);
            b1.Click += delegate { AddNewAlimento(pathToDatabase); createDialog(); };
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
            var uveh = FindViewById<EditText>(Resource.Id.sreditText1);
            command = "SELECT habitacion FROM Usuario WHERE correo = '" + loadData() + "';";
            uveh.Text += con.ExecuteScalarAsync<string>(command).Result;
        }


        void AddNewAlimento(string path)
        {
            Alimentos val = new Alimentos();
            var hab = FindViewById<EditText>(Resource.Id.sreditText1);
            var date = FindViewById<TimePicker>(Resource.Id.srtimePicker1);
            val.costo = 75;
            val.date = date.ToString();
            val.habitacion = hab.Text;
            val.nombre = "ALIMENTOS";
            val.idemp = 1;


            var db = new SQLiteAsyncConnection(path);
            string comm = "SELECT id FROM Usuario WHERE correo= '" + loadData() + "';";
            val.idcte = db.ExecuteScalarAsync<int>(comm).Result;

            comm = "UPDATE Usuario SET saldo = saldo + " + val.costo + " WHERE correo = '" + loadData() + "';";

            db.ExecuteAsync(comm);

            if (db.InsertAsync(val).Result != 0) { db.UpdateAsync(val); }




        }


    }
}