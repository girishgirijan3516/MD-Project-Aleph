using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using Android.Database;
using Android.Database.Sqlite;
using Android.App;

namespace Aleph
{
    public class Photo1
    {
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
    }
    public class PhotoAlbum1
    {
        public PhotoAlbum1(Activity context)
        {
            DBHelperClass myDB = new DBHelperClass(context);
            ICursor myresult = myDB.getAllBooks();
            listPhoto = new Photo1[myresult.Count];
            int i = 0;
            while (myresult.MoveToNext())
            {

                listPhoto[i] = new Photo1() { mPhotoID = myresult.GetInt(myresult.GetColumnIndexOrThrow("book_image")), mCaption = myresult.GetString(myresult.GetColumnIndexOrThrow("book_name")) };
                ++i;
            }

            this.photos1 = listPhoto;
            random = new Random();
        }
        public static Photo1[] listPhoto;
        private Photo1[] photos1;
        Random random;
        
        public int numPhoto
        {
            get
            {
                return photos1.Length;
            }
        }
        public Photo1 this[int i]
        {
            get { return photos1[i]; }
        }
    }
    public class PhotoViewHolder1 : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public PhotoViewHolder1(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}