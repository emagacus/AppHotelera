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
    [Activity(Label = "ValetParking")]
    public class ValetParking : ServicioActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "apphoteleradb1.db");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ValetParking);
            loadDataVehiculo(pathToDatabase);

            Button b1 = FindViewById<Button>(Resource.Id.buttonOKPV);
            b1.Click += delegate {
                AddNewValet(pathToDatabase);
                createDialog(); };

        }

        void loadDataVehiculo(string path)
        {
            SQLiteAsyncConnection con = new SQLiteAsyncConnection(path);
            string command;
            var uveh = FindViewById<TextView>(Resource.Id.vpeditText1);
            command = "SELECT vehiculo FROM Usuario WHERE correo = '" + loadData() + "';";
             uveh.Text += con.ExecuteScalarAsync<string>(command).Result;

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

        void AddNewValet(string path)
        {
            Valet val=new Valet();
            var auto = FindViewById<EditText>(Resource.Id.vpeditText1);
            var date = FindViewById<TimePicker>(Resource.Id.vptimePicker1);
            val.costo = 45;
            val.date = date.ToString();
            val.vehiculo = auto.Text;
            val.nombre = "Valet Parking";
            val.idemp = 1;


            var db = new SQLiteAsyncConnection(path);
            string comm = "SELECT id FROM Usuario WHERE correo= '" + loadData() + "';";
            val.idcte = db.ExecuteScalarAsync<int>(comm).Result;

            comm = "UPDATE Usuario SET saldo = saldo + " + val.costo + " WHERE correo = '" + loadData() + "';";

            db.ExecuteAsync(comm);

            if (db.InsertAsync(val).Result != 0) { db.UpdateAsync(val);}
             
               


        }



    }
}