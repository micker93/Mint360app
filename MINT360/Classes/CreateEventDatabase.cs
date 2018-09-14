using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MINT360.Classes.TableClasses;
using MINT360.Classes.Tablesclasses;
using SQLite;

namespace MINT360.Classes
{
   public class CreateEventDatabase
    {

        string dbPath = Path.Combine(
        System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
        "mintdata.db3");


        //Creates all the tables in SQLite that the app will use. 
        //This method is in the MainActivity and is the first thing tha app done when the user starts.

        public bool createdatabase()
        {
            try
            {
                var db = new SQLiteAsyncConnection(dbPath);

                db.CreateTableAsync<Events>();
                db.CreateTableAsync<Eventlist1>();
                db.CreateTableAsync<InfoContent>();
                db.CreateTableAsync<ProjectID>();
                db.CreateTableAsync<ProjectDetails>();
                db.CreateTableAsync<Agenda>();
                db.CreateTableAsync<User>();
                db.CreateTableAsync<Myagenda>();
                db.CreateTableAsync<Userprofilesettings>();
                db.CreateTableAsync<Users>();
                db.CreateTableAsync<Interests>();
                db.CreateTableAsync<Message>();
                db.CreateTableAsync<Friends>();
                db.CreateTableAsync<Buildings>();
                db.CreateTableAsync<Floorplan>();
                db.CreateTableAsync<Pins>();
                db.CreateTableAsync<Pinsinfo>();
                db.CreateTableAsync<Pictures>();
                db.CreateTableAsync<Modules>();
                db.CreateTableAsync<Categories>();
                db.CreateTableAsync<Intropage>();
                db.CreateTableAsync<Notes>();
                db.CreateTableAsync<Usernotes>();
                db.CreateTableAsync<Geofence>();
                db.CreateTableAsync<Geofenceinfo>();
                db.CreateTableAsync<Ibeacons>();
                db.CreateTableAsync<Ibeaconsinfo>();
                db.CreateTableAsync<Notification>();
                db.CreateTableAsync<Pushnotifications>();
                db.CreateTableAsync<Senionlabdata>();
                db.CreateTableAsync<Selfietickets>();
                db.CreateTableAsync<Guides>();
                db.CreateTableAsync<Tracks>();
                db.CreateTableAsync<Offerts>();
                db.CreateTableAsync<HomeButton>();
                db.CreateTableAsync<Gamepic>();
                db.CreateTableAsync<Areas>();
                db.CreateTableAsync<Areasinfo>();
                db.CreateTableAsync<BackgGroundAndButton>();


                return true;                   
                
            }

            catch (SQLiteException ex)

            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
                
            }
            
        }


        public bool InsertIntoTable(Events eventData)
        {
            try
            {
                var db = new SQLiteAsyncConnection(dbPath);
                {
                    db.InsertOrReplaceAsync(eventData);
                    return true;
                }
                        
            }

            catch (SQLiteException ex)

            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

 
       
        public bool Updatedata(Events eventData)
        {

            try
            {

                var connection = new SQLiteConnection(dbPath);
                

                    connection.Query<Events>("UPDATE EventData set Name=?, Image=?, ProjectID=? Where ID=?", eventData.Name, eventData.Image, eventData.ProjectID, eventData.ID);
                    return true;

                
            }
            catch (SQLiteException ex)

            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }

        }

        public bool GetprimaryID(int id)
        {

            try
            {

                var connection = new SQLiteAsyncConnection(dbPath);
                

                    connection.GetAsync<Events>(id);
                    return true;

                
            }
            catch (SQLiteException ex)

            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public string Table()
        {
            try
            {
                var connection = new SQLiteConnection(dbPath);
                

                    connection.Table<Events>();
                    return "All tables";

                

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx,",ex.Message);
                return "";
            }
        }

       }
    }