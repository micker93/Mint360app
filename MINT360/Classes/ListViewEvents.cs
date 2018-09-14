using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Icu.Text;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Sql;
using MINT360.Classes.TableClasses;

namespace MINT360.Classes
{
   public class ListViewEvents:BaseAdapter<Agenda>
    {
        Activity context;
        List<Agenda> list;

        public ListViewEvents(Activity _context, List<Agenda> _list)
               : base()
        {
            context = _context;
            list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Agenda this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.EventItemslistviewlayout, parent, false);

            Agenda item = this[position];

            string substart="";
            string subend="";

            try
            {
                //gets the Starttime from the class Agenda and removes certain chars and then converts it to milliseconds.
                string cleanstart = Regex.Replace(item.StartTime, @"[/Date\(/)]", string.Empty).Trim().TrimEnd().TrimStart();
                substart = cleanstart.Substring(0, cleanstart.LastIndexOf("+"));
                DateTime startdate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                startdate = startdate.AddMilliseconds(Convert.ToDouble(substart));

                //gets the Endtime from the class Agenda and removes certain chars and then converts it to milliseconds.
                string cleanend = Regex.Replace(item.EndTime, @"[/Date\(/)]", string.Empty).Trim().TrimEnd().TrimStart();
                subend = cleanend.Substring(0, cleanend.LastIndexOf("+"));
                DateTime enddate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                enddate = enddate.AddMilliseconds(Convert.ToDouble(subend));

                var Textview1 = view.FindViewById<TextView>(Resource.Id.textview_starttime);
                Textview1.Text = startdate.ToString("HH:mm");

                var Textview2 = view.FindViewById<TextView>(Resource.Id.textview_endtimeanddate);
                Textview2.Text = enddate.ToString(); ;

                var Textview3 = view.FindViewById<TextView>(Resource.Id.textview_shortname);
                Textview3.Text = item.ShortName;

                var Textview4 = view.FindViewById<TextView>(Resource.Id.textview_location);
                Textview4.Text = item.Location;
            }
           catch (Exception e)
            {
                var Textview1 = view.FindViewById<TextView>(Resource.Id.textview_starttime);
                Textview1.Text =item.StartTime;

                var Textview2 = view.FindViewById<TextView>(Resource.Id.textview_endtimeanddate);
                Textview2.Text = item.EndTime;

                var Textview3 = view.FindViewById<TextView>(Resource.Id.textview_shortname);
                Textview3.Text = item.ShortName;

                var Textview4 = view.FindViewById<TextView>(Resource.Id.textview_location);
                Textview4.Text = item.Location;
            }
            return view;
          
        }
    }
}