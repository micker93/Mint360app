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
    public class Pins
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string PinId { get; set; }
        public string PinX { get; set; }
        public string PinY { get; set; }
        public string PinBelongsTo { get; set; }
        public string PinRed { get; set; }

    }
}