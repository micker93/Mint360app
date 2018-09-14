using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MINT360
{
    [Activity(Label = "EventListActivity")]
    public class EventListActivity : Activity
    {
        TextView textviewdate;
        TextView Location;
        TextView ShortName;
        TextView Desription;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListViewEvent);
            
            // Create your application here
            // Try Catch that will takes the strings from the Eventpageactivity and insert them to the page.

            try
            {
                string ThemeColor = Intent.GetStringExtra("Color");
                string starttime = Intent.GetStringExtra("starttime");
                string endtime = Intent.GetStringExtra("endtime");
                string location = Intent.GetStringExtra("location");
                string shortname = Intent.GetStringExtra("Shortname");
                string desc = Intent.GetStringExtra("description");

                string cleanstart = Regex.Replace(starttime, @"[/Date\(/)]", string.Empty).Trim().TrimEnd().TrimStart();
                string substart = cleanstart.Substring(0, cleanstart.LastIndexOf("+"));
                DateTime startdate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                startdate = startdate.AddMilliseconds(Convert.ToDouble(substart));

                string cleanend = Regex.Replace(endtime, @"[/Date\(/)]", string.Empty).Trim().TrimEnd().TrimStart();
                string subend = cleanend.Substring(0, cleanend.LastIndexOf("+"));
                DateTime enddate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                enddate = enddate.AddMilliseconds(Convert.ToDouble(subend));

                textviewdate = (TextView)FindViewById(Resource.Id.startandendtimetextview);
                Location = (TextView)FindViewById(Resource.Id.locationtextview);
                ShortName = (TextView)FindViewById(Resource.Id.ShortnameTextView);
                Desription = (TextView)FindViewById(Resource.Id.DescriptionTextView);
                var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarList);

                textviewdate.Text = startdate.ToString("HH:mm") + "-" +"\n" +enddate.ToString("MM/dd/yyyy");
                Location.Text = location;

                ShortName.Text = shortname;
                ShortName.SetTextColor(Android.Graphics.Color.ParseColor("#" + ThemeColor));

                Desription.Text = desc;
                toolbar.SetBackgroundColor(Android.Graphics.Color.ParseColor("#" + ThemeColor));
            }
            catch (Exception)
            {
                
            }
        }
    }
}