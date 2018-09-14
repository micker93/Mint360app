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
    public class Pushnotifications
    {
        [PrimaryKey, AutoIncrement]
        public int PId { get; set; }
        [Unique]
        public string Id { get; set; }
        public string DateCreated { get; set; }
        public string Message { get; set; }
        public string Topic { get; set; }

    }
}