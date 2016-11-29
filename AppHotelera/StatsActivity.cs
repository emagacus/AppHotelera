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

namespace AppHotelera
{
    [Activity(Label = "StatsActivity")]
    public class StatsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Stats);

             var e1 = FindViewById<TextView>(Resource.Id.sttextView2nom);

            e1.Text += LoadUser();

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
    }
}