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
    class ProjectTextLabel
    {

        public int Id { get; set; }
        public int tabletextid { get; set; }
        public string lable { get; set; }
    }
}