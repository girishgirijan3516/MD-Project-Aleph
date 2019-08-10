using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using Android.Database;
using Android.Database.Sqlite;
using Android.App;

namespace Aleph
{
    
    public class Photo
    {
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
    }
    public class PhotoAlbum
    {   
        

        
        public PhotoAlbum(Activity context)
        {

            DBHelperClass myDB = new DBHelperClass(context);

            ICursor myresult = myDB.getAllBooks();

            listPhoto = new Photo[myresult.Count];
            int i = 0;
            int a = Resource.Drawable.RomeoandJuliet;
            while (myresult.MoveToNext())
            {
                
                listPhoto[i] = new Photo() { mPhotoID = myresult.GetInt(myresult.GetColumnIndexOrThrow("book_image")), mCaption = myresult.GetString(myresult.GetColumnIndexOrThrow("book_name")) };
                ++i;
            }
            
            this.photos = listPhoto;
            random = new Random();

            
        }

        public static Photo[] listPhoto ;
        
        public Photo[] photos;
        Random random;

        public int numPhoto
        {
            get
            {
                return photos.Length;
            }
        }
        public Photo this[int i]
        {
            get { return photos[i]; }
        }
    }
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public PhotoViewHolder(View itemview, Action<int> listener) : base(itemview)
        {
            Image = itemview.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemview.FindViewById<TextView>(Resource.Id.textView);
            itemview.Click += (sender, e) => listener(base.Position);
        }
    }
}