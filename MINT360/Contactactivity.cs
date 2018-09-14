using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Views;
using Android.Widget;

namespace MINT360
{
    [Activity(Label = "Contactactivity")]
    public class Contactactivity : Activity
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.contact_activity);

           
            TextView textView = FindViewById<TextView>(Resource.Id.TextviewPaul);
            textView.TextFormatted = Html.FromHtml("paul@itmmobile.com");

            TextView textView1 = FindViewById<TextView>(Resource.Id.TextviewThomas);
            textView1.TextFormatted = Html.FromHtml("thomas@itmMobile.com");

            TextView textView2 = FindViewById<TextView>(Resource.Id.TextviewIta);
            textView2.TextFormatted = Html.FromHtml("ita@itmMobile.com");

            TextView textView3 = FindViewById<TextView>(Resource.Id.TextviewRichard);
            textView3.TextFormatted = Html.FromHtml("richard@itmMobile.com");

            TextView textView4 = FindViewById<TextView>(Resource.Id.TextviewKimmo);
            textView4.TextFormatted = Html.FromHtml("kimmo@itmMobile.com");

            TextView textView5 = FindViewById<TextView>(Resource.Id.TextviewMarja);
            textView5.TextFormatted = Html.FromHtml("marja@itmMobile.com");

            TextView textView6 = FindViewById<TextView>(Resource.Id.TextviewLilemor);
            textView6.TextFormatted = Html.FromHtml("lm@itmMobile.com");
            
        }
    }
}