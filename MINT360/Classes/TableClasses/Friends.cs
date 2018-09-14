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
   public class Friends
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string GuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Picture { get; set; }
        public string UpLoaded { get; set; }
        public string UserType { get; set; }
        public string StandNo { get; set; }
        public string exhibitorlogotype { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


    }
}