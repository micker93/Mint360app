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
   public class Offerts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Desciprtion { get; set; }
        public string DocumentLink { get; set; }
        public string Image { get; set; }
        public string Interests { get; set; }
        public string LastChanged { get; set; }
        public string Name { get; set; }
        public int OfferId { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }

    }
}