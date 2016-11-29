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

namespace AppHotelera
{
    [Activity(Label = "StatsActivity")]
    public class StatsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "apphoteleradb1.db");


            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Stats);

             var e1 = FindViewById<TextView>(Resource.Id.sttextView3corre);

            e1.Text += LoadUser();

            LoadUserData(pathToDatabase);

            // Create your application here
        }


        string LoadUser()
        {
            string result;
            var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = Path.Combine(path.ToString(), "myfile.txt");
            
            using (var streamRdr = new StreamReader(filename))
            {
                result = streamRdr.ReadLine();
            }

            return result;
        }



        void LoadUserData(string path)
        {
            SQLiteAsyncConnection con = new SQLiteAsyncConnection(path);
            string command;
            string user = LoadUser();
            var uname = FindViewById<TextView>(Resource.Id.sttextView2nom);
            command = "SELECT nombre FROM Usuario WHERE correo = '" + user + "';";
            uname.Text += con.ExecuteScalarAsync<string>(command).Result;

            var uhab = FindViewById<TextView>(Resource.Id.sttextView4hab);
            command = "SELECT habitacion FROM Usuario WHERE correo = '" + user + "';";
            uhab.Text += con.ExecuteScalarAsync<string>(command).Result;

            var uveh = FindViewById<TextView>(Resource.Id.sttextView5veh);
            command = "SELECT vehiculo FROM Usuario WHERE correo = '" + user + "';";
            uveh.Text += con.ExecuteScalarAsync<string>(command).Result;

            var uSaldo = FindViewById<TextView>(Resource.Id.sttextView6saldo);
            command = "SELECT saldo FROM Usuario WHERE correo = '" + user + "';";
            uSaldo.Text += con.ExecuteScalarAsync<Decimal>(command).Result.ToString();

            var uId = FindViewById<TextView>(Resource.Id.sttextView1id);
            command = "SELECT id FROM Usuario WHERE correo = '" + user + "';";
            uId.Text += con.ExecuteScalarAsync<int>(command).Result.ToString();


        }
    }
}