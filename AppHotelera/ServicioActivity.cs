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

namespace AppHotelera
{
    [Activity(Label = "ServicioActivity")]
    public class ServicioActivity : Activity
    {

        int id;
        string name;
        string descripcion;
        decimal costo;
        int idCte;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);
            Button b1 = FindViewById<Button>(Resource.Id.button2);
            Button bmaid = FindViewById<Button>(Resource.Id.button3);
            Button bres = FindViewById<Button>(Resource.Id.button1);
            Button bstats = FindViewById<Button>(Resource.Id.MenStatbutton4);

            b1.Click += delegate { StartActivity(typeof(ValetParking));};
            bstats.Click += delegate { StartActivity(typeof(StatsActivity)); };
            bmaid.Click += delegate { StartActivity(typeof(MaidActivity)); };
            bres.Click += delegate { StartActivity(typeof(ResActivity)); };
            // Create your application here
        }


     

        public void createDialog()
        {


            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Servicio");
            alert.SetMessage("SU SERVICIO SE HA AGREGADO!");
            alert.SetPositiveButton("ACEPTAR", (senderAlert, args) => {
                Toast.MakeText(this, "Servicio Agregado!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();


        }


    }
}