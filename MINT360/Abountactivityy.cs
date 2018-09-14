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
    [Activity(Label = "Abountactivityy")]
    public class Abountactivityy : Activity
    {
        TextView textView;
        ScrollView scrollView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.about_layout);

            scrollView = (ScrollView)FindViewById(Resource.Id.scrollView1);
            scrollView.Focusable = false;

            // Create your application here
            textView = (TextView)FindViewById(Resource.Id.Contenttext);
            string ITMOBILE = "<p><a href='http://www.itmmobile.com'>ITM MOBILE </a></p>";

            
            textView.Clickable = true;
            textView.TextFormatted = Html.FromHtml(ITMOBILE);
            textView.MovementMethod = LinkMovementMethod.Instance;
            
            textView.Text = ITMOBILE + "is a solution driven,moden event technology and mobile app development company\n\n " +
                    "Our team is committed to making participants LOVE YOUR EVENT APP and making staying connected easy and fund\n\n" +
                    "In Partnership with our clients, ITM Mobile creates innovative Event Technology and Mobile App solutions. We are also the offical event operator of Brightbox experiential SmartPhone Charging Stations.\n\n" +
                    "Our PASSION:\n"+ 
                    "Connecting people with relevant contacts,content and resources\n\n" +
                    "Our Business:\n"+
                    "Innovative Event Technology and Mobile App Development\n\n"+
                    "Our Commitment:\n"+
                    "Create and deliver great apps,great results!\n\n" +
                    "EVENT APPS ANYONE CAN AFFORD\n\n"+
                    "SUBMIT REP " + "marked MINT 360 to get your own customized Event App hosted withing the MINT 360 container app. Starting at only $500 per event for up to 1,000 attendees.\n"+
                    "To TEST and see how it works: Enter code 0046 and start DEMO version of an ITM Mobile App Experience.\n\n" +
                    "WHY AN EVENT APP\n\n"+
                    "1. Better overall event experience and participant satisfacction\n"+
                    "2. Increased event revenues via app monetization\n"+
                    "3. Improved communications and opportunities for engagement\n"+
                    "4. Encanced participant interaction\n\n"+
                    "WHY ITM MOBILE\n\n"+
                    "ITM Mobile offers the choices of:\n\n"+
                    "1.Affordable DIY event apps\n"+
                    "2. Custom branded apps\n"+
                    "3. Highly custom deceloped apps\n"+
                    "4. All-in-one event technology solutions\n"+
                    "5. Integration with 3rd party soft-and hard-ware\n"+
                    "6. Innovative solutions including indoor positioning, navigation & location based marketing\n\n"+
                    "Contact our saes Team " + "to discuss your needs and to learn more about how one of out Conference and Event apps can benefit your buisness.";
           
        }
    }
}