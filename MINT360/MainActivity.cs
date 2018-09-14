using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using Newtonsoft.Json;
using Org.Json;
using System;
using System.IO;
using System.Json;
using System.Net;
using System.Threading.Tasks;
using FFImageLoading.Views;
using System.Collections.Generic;
using System.Text;
using MINT360.Classes;
using Android.Content.PM;
using SQLite;
using Android.Text;

namespace MINT360
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]

    public class MainActivity : Activity
    {
       
        EditText editText;
        Button button;
        Button Contactbutton;
        Button Aboutbutton;

        protected override  void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
           
            //First thing is to create the whole database with this class.
            CreateEventDatabase db = new CreateEventDatabase();
            db.createdatabase();

            editText = (EditText)FindViewById(Resource.Id.Input_Edittext);
            button = (Button)FindViewById(Resource.Id.Send_Button);
            Contactbutton = (Button)FindViewById(Resource.Id.Contact_Button);
            Aboutbutton = (Button)FindViewById(Resource.Id.About_Button);


            //Button click with a if statment that checks if the inputfield is empty. Also a filter that allows maximum 4 characters to the editText. 
            //The url gets the ID that the user writes in the editText and inserts it to the url.
            //also the id that the user types in will be sent as a int to the next Activity.

            editText.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(4) });
            button.Click += (sender,e) =>
            {
                int id = 0;

                if (editText.Text == "")
                {
                    Toast.MakeText(this, "Vänligen skriv in ett giltigt Id!", ToastLength.Long).Show();
                }
                else
                {
                    //api url edittext= the id
                    string url = "https://api.itmmobile.com/customers/" + editText.Text.TrimEnd() + "/apps?base64={base64}";
                    id = int.Parse(editText.Text);

                    var ValueActivity = new Intent(this, typeof(ResultActivity));
                    ValueActivity.PutExtra("APIurl", url);
                    ValueActivity.PutExtra("ID", id);

                    StartActivity(ValueActivity);

                }
            };

            //Two methods that takes the user to a new Acitvity

            Contactbutton.SetTextColor(Android.Graphics.Color.White);
            Contactbutton.SetBackgroundColor(Android.Graphics.Color.ParseColor("#000000"));
            Contactbutton.Click += (sender, e) =>
             {
                 var ValueActivity = new Intent(this, typeof(Contactactivity));
                 StartActivity(ValueActivity);

             };

            Aboutbutton.SetTextColor(Android.Graphics.Color.White);
            Aboutbutton.SetBackgroundColor(Android.Graphics.Color.ParseColor("#000000"));
            Aboutbutton.Click += (sermder, e) =>
            {
                var ValueActivity = new Intent(this, typeof(Abountactivityy));
                StartActivity(ValueActivity);
            };

            
        }       
        
    }
}
