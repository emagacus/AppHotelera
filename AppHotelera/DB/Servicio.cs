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
using SQLite;

namespace AppHotelera.DB
{
    class Servicio
    {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal costo { get; set; }
        public string date { get; set; }
        public int idemp { get; set; }
        public int idcte { get; set; }

       
    }
}