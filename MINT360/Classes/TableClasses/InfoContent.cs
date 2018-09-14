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
    public class InfoContent
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }
        public string DateChanged { get; set; }
        public string InfoContentId { get; set; }
        public string Topic { get; set; }
        public string ContentType { get; set; }
        public string DocumentLink { get; set; }

  

    }
}