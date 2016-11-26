using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;



namespace AppHotelera
{
    [Activity(Label = "AppHotelera", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                EditText bu = FindViewById<EditText>(Resource.Id.editText1);
                string pass = GetString(Resource.String.Password);

                if (pass == bu.Text)
                {
                    StartActivity(typeof(ServicioActivity));
                }

            };
        }


        



    }
    
}

