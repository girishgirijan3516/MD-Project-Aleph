using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using Android.Database;
using Android.Database.Sqlite;
using Android.App;

namespace Aleph
{
    public class Photo2
    {
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
    }
    public class PhotoAlbum2
    {
        public PhotoAlbum2(Activity context, string userEmail)
        {
            DBHelperClass myDB = new DBHelperClass(context);
            ICursor myresult = myDB.getAllLibraryBooks(userEmail);
            listPhoto = new Photo2[myresult.Count];
            int i = 0;
            while (myresult.MoveToNext())
            {

                listPhoto[i] = new Photo2() { mPhotoID = myresult.GetInt(myresult.GetColumnIndexOrThrow("bookimage")), mCaption = myresult.GetString(myresult.GetColumnIndexOrThrow("bookname")) };
                ++i;
            }

            this.photos1 = listPhoto;
            random = new Random();
        }

        public static Photo2[] listPhoto;
        private Photo2[] photos1;
        Random random;
        
        public int numPhoto
        {
            get
            {
                return photos1.Length;
            }
        }
        public Photo2 this[int i]
        {
            get { return photos1[i]; }
        }
    }
    public class PhotoViewHolder2 : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public PhotoViewHolder2(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}