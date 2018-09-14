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
   public class Messages
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string DateCreated { get; set; }
        public string DateRead { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FromUserId { get; set; }
        public string Message { get; set; }
        [Unique]
        public string MessageId { get; set; }
        public string MessageType { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string ToUserId { get; set; }
        public string UserPicture { get; set; }



    }
}