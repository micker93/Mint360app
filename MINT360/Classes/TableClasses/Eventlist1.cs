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
    public class Eventlist1
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProjectId { get; set; }
        public string Banner { get; set; }
        public string Appname { get; set; }
    }
}