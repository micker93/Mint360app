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
    public class Notifications
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string NotificationId { get; set; }
        public string Type { get; set; }
        public string Alert { get; set; }
        public string TypeId { get; set; }


    }
}