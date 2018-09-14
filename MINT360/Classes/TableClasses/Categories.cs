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
    public class Categories
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string EventId { get; set; }
        public string EventInfoCategoryId { get; set; }

    }
}