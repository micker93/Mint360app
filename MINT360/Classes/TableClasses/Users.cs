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
   public class Users
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Address { get; set; }
        public string AutoMatch { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string Desciption { get; set; }
        public string DocumentLink { get; set; }
        public string Email { get; set; }
        public string exhibitorlogotype { get; set; }
        public string FbUserId { get; set; }
        public string FirstName { get; set; }
        public string Grade { get; set; }
        public string LastName { get; set; }
        public string LinkedInId { get; set; }
        public string LinkedInPage { get; set; }
        public string LogoType { get; set; }
        public string MapLocations { get; set; }
        public string NetWorkActivated { get; set; }
        public string PassWord { get; set; }
        public string Phone { get; set; }
        public string Procent { get; set; }
        public string Roles { get; set; }
        public string StandNo { get; set; }
        public string Title { get; set; }
        public string UserFaceboo { get; set; }
        public string UserHomepage { get; set; }
        [Unique]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPictures { get; set; }
        public string UserProfileSetting { get; set; }
        public string UserTwitter { get; set; }
        public string Usstate { get; set; }
        public string ZipCode { get; set; }
        public string UserType { get; set; }
        public string UserFriends { get; set; }
        public string Address2 { get; set; }
        public string PhoneAreaCode { get; set; }
        public string SortOrder { get; set; }
        public string GripId { get; set; }


    }
}