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
    public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string AdminLvId { get; set; }
        public int Weekday { get; set; }
        public string SpeakerNames { get; set; }
        public string Categories { get; set; }
        public string Description { get; set; }
        public string EndTime { get; set; }
        [Unique]
        public string EventId { get; set; }
        public string Interest { get; set; }
        public string Location { get; set; }
        public string LongName { get; set; }
        public string ProjectId { get; set; }
        public string ShortName { get; set; }
        public string Speakers { get; set; }
        public string StartTime { get; set; }
        public string LatLong { get; set; }
        public string CategoryName { get; set; }
        public string PollWebLink { get; set; }
        public string AutoMatch { get; set; }
        public string Procent { get; set; }
        public string DocumentLink { get; set; }
        public string MapLocation { get; set; }
        public string Address { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Registered { get; set; }
        public string ShowOnDashboard { get; set; }
        public int ShowCheckIn { get; set; }
        public string Tracks { get; set; }





    }
}