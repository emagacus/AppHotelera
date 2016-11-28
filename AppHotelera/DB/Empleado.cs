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
    class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public int tipo { get; set; }
    }
}