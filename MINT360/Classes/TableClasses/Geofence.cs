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

namespace MINT360.Classes.TableClasses
{
    public class Geofence
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string GeoFeneId { get; set; }
        public string GeoFenceX { get; set; }
        public string GeoFenceY { get; set; }
        public string GeoFenceWidth { get; set; }
        public string GeoFenceHeight { get; set; }
        public string GeoFenceBelongsTO { get; set; }
        public string GeoFenceRef { get; set; }

    }
}