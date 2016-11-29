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
using AppHotelera.DB;
using SQLite;

namespace AppHotelera
{
	[Activity(Label = "RegActivity")]
	public class RegActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registro);
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "apphoteleradb1.db");
            var a = FindViewById<Button>(Resource.Id.RegbuttonOK);

            var unom = FindViewById<EditText>(Resource.Id.Regnombre);
            var ucorreo = FindViewById<EditText>(Resource.Id.Regcorreo);
            var uhab = FindViewById<EditText>(Resource.Id.RegHab);
            var uauto = FindViewById<EditText>(Resource.Id.RegVehiculo);
            var up = FindViewById<EditText>(Resource.Id.RegPass);
            var upc = FindViewById<EditText>(Resource.Id.REgpassconfirm);

            a.Click += delegate 
            {
                if (up.Text == upc.Text)
                {
                    Usuario user = new Usuario();
                    user.nombre = unom.Text;
                    user.password = up.Text;
                    user.correo = ucorreo.Text;
                    user.habitacion = uhab.Text;
                    user.vehiculo = uauto.Text;
                    user.saldo = 0;

                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("USUARIO");
                    alert.SetMessage(addUsuario(pathToDatabase,user));
                    alert.SetPositiveButton("ACEPTAR", (senderAlert, args) => {
                        Toast.MakeText(this, " ", ToastLength.Short).Show();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();
                                  
                    this.Finish();
                    
                }
                else
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("ERROR");
                    alert.SetMessage("CONTRASEÑAS NO COINCIDEN");
                    alert.SetPositiveButton("ACEPTAR", (senderAlert, args) => {
                        Toast.MakeText(this, "LAS CONTRASEÑAS NO COINCIDEN!", ToastLength.Short).Show();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();

                }

            };

            // Create your application here
        }


        string addUsuario(string path,Usuario data)
        {
            try
            {
                var db = new SQLiteAsyncConnection(path);
                if (db.InsertAsync(data).Result != 0)
                    db.UpdateAsync(data);


                return "USUARIO AGREGADO";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }






    }
}