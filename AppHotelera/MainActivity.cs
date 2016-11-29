using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using AppHotelera.DB;
using System.IO;

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
            EditText user = FindViewById<EditText>(Resource.Id.logeditTextMail);
            EditText pass = FindViewById<EditText>(Resource.Id.logeditText1);

            breg.Click += delegate { StartActivity(typeof(RegActivity)); };

            button.Click += delegate
            {
                if (validCredentials(user.Text, pass.Text, pathToDatabase))
                {
                    SaveUser(user.Text);
                    StartActivity(typeof(ServicioActivity));
                }else
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("ERROR");
                    alert.SetMessage("USUARIO O CONTRASEÑA INCORRECTOS");
                    alert.SetPositiveButton("ACEPTAR", (senderAlert, args) => {
                        Toast.MakeText(this, "", ToastLength.Short).Show();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();
                }

            };
        }


        bool validCredentials(string user,string pas,string path)
        {
            SQLiteAsyncConnection con = new SQLiteAsyncConnection(path);
            string command = "SELECT password FROM Usuario WHERE correo = '"+ user +"';";
            var passdb  = con.ExecuteScalarAsync<string>(command);

           

            if (pas == passdb.Result)
            {
                return true;
            }
            else { return false; }
              
            
        }


        void SaveUser(string data)
        {
            var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = Path.Combine(path.ToString(), "myfile.txt");

            using (var streamWriter = new StreamWriter(filename,false))
            {
                streamWriter.WriteLine(data);
            }

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

