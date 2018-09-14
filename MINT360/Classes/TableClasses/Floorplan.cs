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
   public class Floorplan
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string FloorPlanId { get; set; }
        public string FloorPlanName { get; set; }
        public string FloorPlanimage { get; set; }
        public string FloorPlanDefault { get; set; }
        public string FloorPlanBelongsTo { get; set; }
        public string SenionLab { get; set; }

    }
}