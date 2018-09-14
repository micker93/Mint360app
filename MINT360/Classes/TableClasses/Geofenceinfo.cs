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
    public class Geofenceinfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string OtherId { get; set; }
        public string GeoFenceText { get; set; }
        public string GeoFeneTypeId { get; set; }
        public string GeoFenceBodyText { get; set; }
        public string GeoFenceUrlText { get; set; }
        public string Repeating { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}