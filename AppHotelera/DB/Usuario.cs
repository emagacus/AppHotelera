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
    class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public decimal saldo { get; set; }
        public string correo { get; set; }
        public string habitacion { get; set; }
        public string vehiculo { get; set; }
    }
}