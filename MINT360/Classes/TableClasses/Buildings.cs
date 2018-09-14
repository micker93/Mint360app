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
    public class Buildings
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string BuildingId { get; set; }
        public string BuilingName { get; set; }



    }
}