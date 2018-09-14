using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using FFImageLoading.Views;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using MINT360.Classes;
using Org.Json;
using Java.Net;
using Java.IO;
using SQLite;
using System.IO;
using MINT360.Classes.Tablesclasses;

namespace MINT360
{
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity

    {

        ListView lv;
        List<Events> events = new List<Events>();
        CreateEventDatabase cb;
        private ProgressBar spinner;
        TextView textView;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Result_layout);
            // Create your application here          
            
            //get the url from the MainActivity
            string url = Intent.GetStringExtra("APIurl");
            int id = Intent.GetIntExtra("ID", 0);

            textView = (TextView)FindViewById(Resource.Id.textviwprogress);

            spinner = (ProgressBar)FindViewById(Resource.Id.progressBar);
            spinner.Visibility = ViewStates.Visible;

            //Calls the JSonValue method which will handle the api request and display it
            JsonValue jv = await Fetchdata(url);

            spinner.Visibility = ViewStates.Gone;
            textView.Text = null;

            //simple itemlick to the listview
            lv.ItemClick += lv_Itemclick;
        
        }

        void lv_Itemclick(object sender, AdapterView.ItemClickEventArgs e)
        {

            //Takes the ProjetID of the item on the Listview and sends it over to Eventpageactivity with some other API variables.
            var select = events[e.Position].ProjectID;
            string api = "https://api.itmmobile.com/projects/" + select;
            string apimodules =  api+"/projectModules?base64={base64}";
            string apiHeader = api+"/contents";
            string apiListView = "https://api.itmmobile.com/projects/"+select+"/events";
        

            var ValueActivity = new Intent(this, typeof(Eventpageactivity));
            ValueActivity.PutExtra("APIurl", api);
            ValueActivity.PutExtra("APImoduels", apimodules);
            ValueActivity.PutExtra("APIHeader",apiHeader);
            ValueActivity.PutExtra("APIListView",apiListView);
            StartActivity(ValueActivity);

        }



        public async Task<JsonValue> Fetchdata(string url)
        {

     
            lv = (ListView)FindViewById(Resource.Id.listView1);
            int id = Intent.GetIntExtra("ID",46);
            cb = new CreateEventDatabase();
            var Tables = cb.Table();

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            try
            {
                // Send the request to the server and wait for the response:
                using (WebResponse response = await request.GetResponseAsync())
                {
                    // Get a stream representation of the HTTP web response:
                    using (System.IO.Stream stream = response.GetResponseStream())
                    {

                        JsonValue jsonDoc = await Task.Run(() => JsonObject.Load(stream));

                        JSONObject parentObject = new JSONObject(jsonDoc.ToString());
                        JSONArray jsonArray = parentObject.OptJSONArray("Apps");

                        for (int i = 0; i < jsonArray.Length(); i++)
                        {

                            JSONObject jsonObject = jsonArray.GetJSONObject(i);

                            //Declares the Class Events and inserts the respons from the api to the class variables.
                            //this structure of the method will be used as the standard in the other activity where a class will 
                            //take the api response and add it to the view.
                            Events eventData = new Events()
                            {

                                ID = int.Parse(id.ToString()),
                                Name = jsonObject.GetString("ProjectName"),
                                Image = jsonObject.GetString("Banner"),
                                ProjectID = jsonObject.GetInt("ProjectID"),
                                BannerisIcon = jsonObject.GetBoolean("BannerIsIcon")

                            };
                            //add the class to and List
                            events.Add(eventData);
                            //Insert the list to SQLite
                            cb.InsertIntoTable(eventData);
                        }
                                                                 
                         lv.Adapter = new CustomListAdapter(this, events);
                       
                        // Return the JSON document:
                        return url;
                    }
                }
            }
            
            catch (Exception)
            {
                //Writes out a toast if id is wrong and goes back to MainActivity
               
                Toast.MakeText(this, "Kunde inte hitta Id: " + id.ToString(), ToastLength.Long).Show();
                var ValueActivity = new Intent(this, typeof(MainActivity));
                StartActivity(ValueActivity);
                return null;

            }

        }

     }
}      


    
