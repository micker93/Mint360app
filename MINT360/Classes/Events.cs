using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

//namespace MINT360.Classes
namespace MINT360.Classes.Tablesclasses
{

    public class Events
    {
       
        [Column("Kund-id")]      
        public int ID { get; set; } 
        [Column("AppName"),Unique]
        public string Name { get; set; }
        [Column("Banner"),Unique]
        public string Image { get; set; }
        [Column("ProjectID"),Unique]
        public int ProjectID { get; set; }
        [Column("Bannerisicon")]
        public bool BannerisIcon { get; set; }

        public Events()
        {
            //Tagit bort alla parameters
        }

    }

}