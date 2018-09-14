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
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ADMINLVId { get; set; }
        public string City { get; set; }
        public string CompanyName{ get; set; }
        public string Country { get; set; }
        public string DateCreated { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string GUID { get; set; }
        public string LastName { get; set; }
        public string LInkinId { get; set; }
        public string NetWorkActivated { get; set; }
        public string PassWord { get; set; }
        public string Phone { get; set; }
        public string StandNo { get; set; }
        public string TestUser { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPicture { get; set; }
        public string UserType { get; set; }
        public string FbUserId { get; set; }
        public string UserFaceBook { get; set; }
        public string UserHomePage { get; set; }
        public string UserTwitter { get; set; }
        public string MyAgenda { get; set; }
        public string UserProfileSettings { get; set; }

    }
}