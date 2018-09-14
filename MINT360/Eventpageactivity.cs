using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Org.Json;
using MINT360.Classes.TableClasses;
using FFImageLoading.Views;
using FFImageLoading;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using MINT360.Classes;
using SQLite;
using System.IO;

namespace MINT360
{
    [Activity(Label = "Eventpageactivity")]
    public class Eventpageactivity : AppCompatActivity
    {

         //all globlar variablers
       
        DrawerLayout drawerLayout;
        private ProgressBar spinner;
        NavigationView navigationView;
        Button signinbutton;

       
        string GetImage = "";
        string GetColor = "";
        

        ListView LV;

        //lists that will go in to SQLite
        List<Modules> ModulesList = new List<Modules>();
        List<Intropage> IntroPageList = new List<Intropage>();
        List<Eventlist1>eventlist1List= new List<Eventlist1>();
        List<ProjectTextLabel> projectTextLabelsList = new List<ProjectTextLabel>();
        List<HomeButton> HomeButtonList = new List<HomeButton>();
        List<InfoContent> infocontentlist = new List<InfoContent>();
        List<BackgGroundAndButton> BaBLisr = new List<BackgGroundAndButton>();
        List<Agenda> AgendaList = new List<Agenda>();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.eventpageactivity_layout);

            //creates the progressbar more coming...
            spinner = new ProgressBar(this);
            spinner.Visibility = ViewStates.Visible;


            //some variables and declareation
            string url = Intent.GetStringExtra("APIurl");
            string urlmodules = Intent.GetStringExtra("APImoduels");
            string urlheader = Intent.GetStringExtra("APIHeader");
            string urlListView = Intent.GetStringExtra("APIListView");
            
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            ImageView imageViewas = (ImageView)FindViewById(Resource.Id.Imageview);

            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.baseline_menu_24);
            
            //Calls the JSonValue method which will handle the api request and display it
            JsonValue jv = await Fetchdata(url);
            JsonValue jvmodules = await FetchdataModules(urlmodules);
            JsonValue jvheader = await FetchDataHeader(urlheader);

            spinner.Visibility = ViewStates.Gone;
            LinearLayout linearLayout =(LinearLayout)FindViewById(Resource.Id.LoginLayout);
            linearLayout.SetBackgroundColor(Android.Graphics.Color.LightGray);
        }

        void itemclick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //This takes the content that is in the ListView  and sends it to EventListActivity.
            var select = AgendaList[e.Position].EventId;
            var agendadesc = AgendaList[e.Position].Description;
            var agendashortname = AgendaList[e.Position].ShortName;
            var agendalocaion = AgendaList[e.Position].Location;
            var agendastart = AgendaList[e.Position].StartTime;
            var agendaend = AgendaList[e.Position].EndTime;
            var ValueActivity = new Intent(this, typeof(EventListActivity));

            

            ValueActivity.PutExtra("description",agendadesc);
            ValueActivity.PutExtra("Shortname", agendashortname);
            ValueActivity.PutExtra("location", agendalocaion);
            ValueActivity.PutExtra("starttime", agendastart);
            ValueActivity.PutExtra("endtime", agendaend);
            ValueActivity.PutExtra("Color", GetColor);
            StartActivity(ValueActivity);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {           

            MenuInflater.Inflate(Resource.Menu.toolbar_menu, menu);           
            return base.OnCreateOptionsMenu(menu);
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            //If statment that does something when you press the menu icons.
            if (item.ItemId==Android.Resource.Id.Home)
            {

                drawerLayout = (DrawerLayout)FindViewById(Resource.Id.drawer_layout);
                drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                drawerLayout.CloseDrawer(Android.Support.V4.View.GravityCompat.End);
                
            }
             else if (item.ItemId == Resource.Id.menu_account)
            {
                
                drawerLayout = (DrawerLayout)FindViewById(Resource.Id.drawer_layout);
                drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.End);
                drawerLayout.CloseDrawer(Android.Support.V4.View.GravityCompat.Start);
            }

         
            return base.OnOptionsItemSelected(item);
        }


        public async Task<JsonValue> Fetchdata(string url)
        {
            TextView textViewbuisness= (TextView)FindViewById(Resource.Id.BuisnesscardTextView);
            TextView textViewmyagenda= (TextView)FindViewById(Resource.Id.MyAgendaTextView);
            TextView textViewNotifi= (TextView)FindViewById(Resource.Id.NOtificationsTextView);
            TextView textViewuserNotes= (TextView)FindViewById(Resource.Id.UserNoteTextView);
            TextView textViewSeassion = (TextView)FindViewById(Resource.Id.SessaionNotesTextView);
            TextView textViewmessage = (TextView)FindViewById(Resource.Id.MessageTextView);
            signinbutton = (Button)FindViewById(Resource.Id.Signin_button);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            string buttoncolor = "";
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mintdata.db3");
            var db = new SQLiteAsyncConnection(dbPath);
            var EventList1Table = db.Table<Eventlist1>();
            var IntroPageTable = db.Table<Intropage>();
            var ProjectTextLable = db.Table<ProjectTextLabel>();

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

                        //declares the appropriate class and inserts it to the list then to SQLite.

                        Eventlist1 evlist = new Eventlist1()
                        {
                            Id=parentObject.GetInt("CustomerID"),
                            ProjectId = parentObject.GetString("ProjectID"),
                            Appname = parentObject.GetString("ProjectName"),
                        };
                        eventlist1List.Add(evlist);
                        await db.InsertOrReplaceAsync(evlist);

                        Intropage intropage = new Intropage()
                        {
                            BackGroundColor = parentObject.GetString("ThemeColor"),
                            Id = parentObject.GetInt("CustomerID"),
                            CustomerId=parentObject.GetString("CustomerID"),
                        };
                        IntroPageList.Add(intropage);
                        await db.InsertOrReplaceAsync(intropage);

                        //From the url that this method gets it will look for ProjectTextLabel array and get the data and display it.
                        JSONArray jsonArray = parentObject.OptJSONArray("ProjectTextLabel");

                        for (int i = 0; i < jsonArray.Length(); i++)
                        {

                            JSONObject jsonObject = jsonArray.GetJSONObject(i);

                            ProjectTextLabel projectTextLabel = new ProjectTextLabel
                            {
                                tabletextid = jsonObject.GetInt("TextLableID"),
                                lable = jsonObject.GetString("Lable")
                            }; 
                           
                            if (projectTextLabel.tabletextid == 61)
                            {
                                signinbutton.Text = projectTextLabel.lable;
                            }
                            if (projectTextLabel.tabletextid == 8)
                            {
                                textViewmessage.Text = projectTextLabel.lable;
                            }
                            if (projectTextLabel.tabletextid == 26)
                            {
                                textViewSeassion.Text = projectTextLabel.lable;
                            }
                            if (projectTextLabel.tabletextid == 27)
                            {
                                textViewuserNotes.Text = projectTextLabel.lable;
                            }
                            if (projectTextLabel.tabletextid == 28)
                            {
                                textViewNotifi.Text = projectTextLabel.lable;
                            }
                            if (projectTextLabel.tabletextid == 1)
                            {
                                textViewmyagenda.Text = projectTextLabel.lable;
                            }
                            if (projectTextLabel.tabletextid == 9)
                            {
                                textViewbuisness.Text = projectTextLabel.lable;
                            }
                             
                        }
                        // The color to the "Sign in" button 
                        buttoncolor = parentObject.GetString("ThemeSecondColor");
                        signinbutton.SetBackgroundColor(Android.Graphics.Color.ParseColor("#" + buttoncolor));

                      
                        //gets the  ProjectName from api and  display it in menu and ThemeColor
                        SetSupportActionBar(toolbar);
                        SupportActionBar.Title = evlist.Appname;
                        toolbar.SetBackgroundColor(Android.Graphics.Color.ParseColor("#" + intropage.BackGroundColor));
                        GetColor = intropage.BackGroundColor;
                        // Return the JSON document:
                        return url;
                    }
                }
            }

            catch (Exception)
            {
               
                return null;

            }

        }

        public async Task<JsonValue> FetchdataModules(string url)
        {

            navigationView = (NavigationView)FindViewById(Resource.Id.nav_view);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mintdata.db3");
            var db = new SQLiteAsyncConnection(dbPath);
            var MOdulesTable = db.Table<Modules>();

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
                        JSONArray ja = new JSONArray(jsonDoc.ToString());

                        for (int i = 0; i < ja.Length(); i++)
                        {

                            JSONObject jo = ja.GetJSONObject(i);

                            Modules modules = new Modules
                            {
                                
                                ModuleId =jo.GetString("ModuleID"),
                                Color= jo.GetString("CustomMenuColor"),
                                Icon=jo.GetString("Icon"),
                                ModuleName=jo.GetString("ModuleName"),
                                Sorting=jo.GetString("Sorting")

                            };

                            navigationView.Menu.Add(modules.ModuleName);
                              
                            ModulesList.Add(modules);
                            await db.InsertOrReplaceAsync(modules);
                        }
                        Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                        // Return the JSON document:
                        return url;
                    }
                }
            }

            catch (Exception)
            {
  
                return null;

            }

        }


        public async Task<JsonValue> FetchDataHeader(string url)
        {
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.ListLinearLayout);
            GridLayout gridLayout = FindViewById<GridLayout>(Resource.Id.viewLayout);
            ImageView imageViewas = (ImageView)FindViewById(Resource.Id.Imageview);
            navigationView = (NavigationView)FindViewById(Resource.Id.nav_view);
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mintdata.db3");
            var db = new SQLiteAsyncConnection(dbPath);
            var HomeButtonTalbe = db.Table<HomeButton>();
            var InfoContentTable = db.Table<InfoContent>();
            var IntroPageTable = db.Table<Intropage>();
            var BackgroundNADBUttonTABLE = db.Table<BackgGroundAndButton>();

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
                        JSONArray ja = new JSONArray(jsonDoc.ToString());

                        for (int i = 0; i < ja.Length(); i++)
                        {

                            JSONObject jo = ja.GetJSONObject(i);

                            BackgGroundAndButton BaB = new BackgGroundAndButton
                            {
                                image=jo.GetString("BackgroundImg"),
                                IsTrueORfalse=jo.GetBoolean("ButtonInterface"),
                            };

                            BaBLisr.Add(BaB);
                            await db.InsertOrReplaceAsync(BaB);

                            InfoContent infoContent = new InfoContent
                            {
                                Content=jo.GetString("ContentText"), 
                            };

                            infocontentlist.Add(infoContent);
                            await db.InsertOrReplaceAsync(infoContent);

                            Intropage intropage = new Intropage
                            {
                                LastChanged=jo.GetString("LastChanged"),
                            };

                            IntroPageList.Add(intropage);
                            await db.InsertOrReplaceAsync(intropage);
                           
 
                            //Convert the Base64 from the api to and image and sets the image to the imageview
                            GetImage = BaB.image;
                            byte[] imgdata = Convert.FromBase64String(GetImage);
                            var imageBitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imgdata, 0, imgdata.Length);
                            imageViewas.SetImageBitmap(imageBitmap);

                            //Check if buttoninterfece is false or true
                            if (BaB.IsTrueORfalse == false)
                            {
                                //Create listview 

                                string urlListView = Intent.GetStringExtra("APIListView");
                                JsonValue CreateList = await FetchListView(urlListView);

                            }

                            else

                            {
                                //Creates imagebuttons
                                JSONArray jsonArray = ja.GetJSONObject(0).GetJSONArray("Buttons");
                                //Hides the linearlayout with the Listview
                                linearLayout.Visibility = ViewStates.Gone;


                                for (int init = 0; init < jsonArray.Length(); init++)
                                {

                                    JSONObject jsonObject = jsonArray.GetJSONObject(init);

                                    HomeButton homeButton = new HomeButton
                                    {
                                        Column = jsonObject.GetInt("Column"),
                                        Image = jsonObject.GetString("Image"),
                                        InfoContentId = jsonObject.GetString("InfoContentID"),
                                        ModuleId = jsonObject.GetInt("ModuleID"),
                                        Row = jsonObject.GetInt("Row"),
                                    };

                                    HomeButtonList.Add(homeButton);
                                    await db.InsertOrReplaceAsync(homeButton);

                                    GridLayout.LayoutParams paramms = new GridLayout.LayoutParams();
                                    paramms.RowSpec = GridLayout.InvokeSpec(GridLayout.Undefined, 1f);
                                    paramms.ColumnSpec = GridLayout.InvokeSpec(GridLayout.Undefined, 1f);

                                    var buttons = new ImageButton(this);
                                    buttons.LayoutParameters = paramms;
                                    buttons.SetScaleType(ImageButton.ScaleType.FitXy);
                                    byte[] buttonimg = Convert.FromBase64String(homeButton.Image);
                                    var buttonimagemap = Android.Graphics.BitmapFactory.DecodeByteArray(buttonimg, 0, buttonimg.Length);
                                    buttons.SetImageBitmap(buttonimagemap);
                                    gridLayout.AddView(buttons);

                                    //Displays the ModuleID when a imagebutton is pressed.
                                    buttons.Click += delegate
                                    {

                                        Toast.MakeText(this,"ModuleId: "+homeButton.ModuleId.ToString(),ToastLength.Long).Show();

                                    };

                                }

                            }

                        }

                        // Return the JSON document: 
                        Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                        return url;
                    }
                }
            }

            catch (Exception)
            {
                
                return null;

            }
        }

  
        public async Task<JsonValue> FetchListView(string url)
        {
            GridLayout gridLayout = FindViewById<GridLayout>(Resource.Id.viewLayout);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.ListLinearLayout);

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
                        JSONArray ja = new JSONArray(jsonDoc.ToString());

                        for (int y = 0; y < ja.Length(); y++)
                        {
                            JSONArray jarray = ja.OptJSONArray(y);

                            for (int i = 0; i < jarray.Length(); i++)
                            {

                                JSONObject jo = jarray.GetJSONObject(i);

                                Agenda agenda = new Agenda
                                {
                                    ShortName = jo.GetString("ShortName"),
                                    StartTime = jo.GetString("StartTime"),
                                    EndTime = jo.GetString("EndTime"),
                                    Location = jo.GetString("Location"),
                                    EventId = jo.GetString("EventID"),
                                    Description = jo.GetString("Description"),
                                    Speakers = jo.GetString("Speakers"),
                                    SpeakerNames = jo.GetString("SpeakerNames"),
                                };

                                AgendaList.Add(agenda);
                            }
                        }

                        LV = new ListView(this);
                        LV.Adapter = new ListViewEvents(this, AgendaList);
                        linearLayout.AddView(LV);

                        LV.ItemClick += itemclick;

                        Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());
                        // Return the JSON document:
                        return url;
                       
                    }                
                } 
            }

            catch (Exception)
            {
                Toast.MakeText(this,"Couldnt find a list",ToastLength.Long).Show();
                return null;
            }

        }

    }
}