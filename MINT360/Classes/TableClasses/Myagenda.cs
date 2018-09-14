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
   public class Myagenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string MyEvents { get; set; }
        public int WeekDay { get; set; }
        public string Categories { get; set; }
        public string Description { get; set; }
        public string EndTime { get; set; }
        public string EventId { get; set; }
        public string Interests { get; set; }
        public string Location { get; set; }
        public string LongName { get; set; }
        public string ProjectId { get; set; }
        public string ShortName { get; set; }
        public string Speakers { get; set; }
        public string StartTime { get; set; }
        public string LatLong { get; set; }
        public string CategoryName { get; set; }
        public string DocumentLink { get; set; }
    }
}