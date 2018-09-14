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

namespace MINT360.Classes
{
    public class Selfietickets
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Url { get; set; }
        [Unique]
        public string Type { get; set; }
    }
}