using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System.Timers;
using Android.Widget;


namespace MINT360
{
    [Activity(Label = "APIloadingactivity")]
    public class APIloadingactivity : Activity
    {

        ProgressBar progressBar;
        Timer _timer;
        int _countSeconds;
        object _lock = new object();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.apiloadinglayout);
            // Create your application here
            string url = Intent.GetStringExtra("APIurl");
            string urlmodules = Intent.GetStringExtra("APImoduels");
            string urlheader = Intent.GetStringExtra("APIHeader");
            string urlListView = Intent.GetStringExtra("APIListView");


            progressBar = FindViewById<ProgressBar>(Resource.Id.progressbar1);

            progressBar.Max = 100;
            progressBar.Progress = 0;
            
            _timer = new System.Timers.Timer();
            _countSeconds = 100;
            _timer.Enabled = true;
            _timer.Interval = 500;
            _timer.Elapsed += OnTimeEvent;

       

        }

        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            _countSeconds -= 10;

            RunOnUiThread(() =>
            {
                progressBar.IncrementProgressBy(10);
                CheckProgress(progressBar.Progress);
            });
        }

        public void CheckProgress(int progress)
        {
            lock (_lock)
            {
                if (progress >= 10)
                {
                    string url = Intent.GetStringExtra("APIurl");
                    string urlmodules = Intent.GetStringExtra("APImoduels");
                    string urlheader = Intent.GetStringExtra("APIHeader");
                    string urlListView = Intent.GetStringExtra("APIListView");


                    var ValueActivity = new Intent(this, typeof(Eventpageactivity));
                    ValueActivity.PutExtra("APIurl",url );
                    ValueActivity.PutExtra("APImoduels", urlmodules);
                    ValueActivity.PutExtra("APIHeader", urlheader);
                    ValueActivity.PutExtra("APIListView", urlListView);
                    StartActivity(ValueActivity);
                    _timer.Dispose();
                   
                }
            }
        }
    }
}