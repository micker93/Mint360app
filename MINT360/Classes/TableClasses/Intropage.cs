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
    public class Intropage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string BackGroundColor { get; set; }
        public string ConnectedCustomerId { get; set; }
        public string CustomerId { get; set; }
        public string IntroBGdesktopLargeImage { get; set; }
        public string IntroBGdesktopSmallImage { get; set; }
        public string InroBGmobileLargeImage { get; set; }
        public string IntroBGmobileSmallImage { get; set; }
        public string IntroPageId { get; set; }
        public string IntroText { get; set; }
        public string IntroTopic { get; set; }
        public string LastChanged { get; set; }
        public string OverlayContentColor { get; set; }
        public string OverlayTransparentlvl { get; set; }
        public string TempateId { get; set; }
        public string IntroLinks { get; set; }


    }
}