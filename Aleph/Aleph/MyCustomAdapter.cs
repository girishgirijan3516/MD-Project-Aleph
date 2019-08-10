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

namespace Aleph
{
    class MyCustomAdapter : BaseAdapter<BookObject>
    {

        List<BookObject> bookList;
        Activity mycontext;

        public MyCustomAdapter(Activity context, List<BookObject> userArray)
        {
            mycontext = context;
            bookList = userArray;
        }
        public override BookObject this[int position]
        {

            get { return bookList[position]; }
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return bookList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;
            BookObject myObj = bookList[position];

            if (myView == null)
            {
                myView = mycontext.LayoutInflater.Inflate(Resource.Layout.CellLayout, null);
            }

            myView.FindViewById<TextView>(Resource.Id.bookName).Text = myObj.bookName;
            myView.FindViewById<TextView>(Resource.Id.bookAuthor).Text = myObj.bookAuthor;
            myView.FindViewById<ImageView>(Resource.Id.bookImageId).SetImageResource(myObj.bookUrl);
            myView.FindViewById<TextView>(Resource.Id.RateValue).Text = myObj.bookRating.ToString();
            return myView;
        }


    }
}