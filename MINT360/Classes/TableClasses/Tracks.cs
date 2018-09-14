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
    public class Tracks
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public int TrackId { get; set; }

    }
}