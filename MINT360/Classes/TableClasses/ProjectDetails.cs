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
    public class ProjectDetails
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string FacebookFanPage { get; set; }
        public string Location { get; set; }
        public string ProjectDuration { get; set; }
        public string ProjectName { get; set; }
        public string Google { get; set; }
        public string Login { get; set; }
        public string PageTemplate { get; set; }
        public string TemplateId { get; set; }
        public string Update { get; set; }
    }
}