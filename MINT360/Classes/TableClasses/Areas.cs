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
   public class Areas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string PinId { get; set; }
        public string Xaxel { get; set; }
        public string Yaxel { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string PinBelongsTo { get; set; }

    }
}