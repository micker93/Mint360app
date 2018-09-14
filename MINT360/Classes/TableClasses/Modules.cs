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
  public class Modules
    {
        
        public int Id { get; set; }
        public string Color { get; set; }
        public string MenuName { get; set; }
        [Unique]
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string Sorting { get; set; }
        public string StyleClass { get; set; }
        public string Icon { get; set; }

    }
}