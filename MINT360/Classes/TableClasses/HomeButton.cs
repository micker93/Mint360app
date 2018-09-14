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
    public class HomeButton
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Column { get; set; }
        public string Image { get; set; }
        public string InfoContentId { get; set; }
        public int ModuleId { get; set; }
        public int Row { get; set; }
    }
}