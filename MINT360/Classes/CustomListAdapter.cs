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
using FFImageLoading;
using FFImageLoading.Views;
using MINT360.Classes.Tablesclasses;

namespace MINT360.Classes
{

    public class ViewHolder : Java.Lang.Object
    {
        public ImageViewAsync Banner { get; set; }
    }

   public class CustomListAdapter : BaseAdapter<Events>
    {
        Activity context;
        List<Events> list;

        public CustomListAdapter(Activity _context, List<Events> _list)
            : base()
        {
            context = _context;
            list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Events this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.item_layout, parent, false);

            Events item = this[position];

            var imageViewas = view.FindViewById<ImageViewAsync>(Resource.Id.Imageviewlisr);
            ImageService.Instance.LoadUrl(item.Image).Into(imageViewas);

        
            return view;

        }
    }
}