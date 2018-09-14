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
    public class Pictures
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Comment { get; set; }
        public string DateCreated { get; set; }
        public string LargePicture { get; set; }
        public string LastChanged { get; set; }
        [Unique]
        public string PictureId { get; set; }
        public string PictureType { get; set; }
        public string ProjectId { get; set; }
        public string SmallPicture { get; set; }
        public string User { get; set; }
        public string UserId { get; set; }

    }
}