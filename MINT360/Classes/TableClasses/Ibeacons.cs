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
    public class Ibeacons
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string IbeaconsID { get; set; }
        public string IbeaconProximityUUID { get; set; }
        public string IbeaconsBelongsTo { get; set; }
        public string IbeaconsRef { get; set; }
        public string IbeaconsMajor { get; set; }
        public string IbeaconsMinor { get; set; }
        public string ZoneRadius { get; set; }
        public string ZoneBufferNumber { get; set; }


    }
}