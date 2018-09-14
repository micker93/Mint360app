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
    public class Senionlabdata
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string DataDate { get; set; }
        public string Name { get; set; }
        public string VenueId { get; set; }
        public string MapVersionId { get; set; }
        public string MapId { get; set; }
        public string CustomerId { get; set; }
        public string Floors { get; set; }

    }
}