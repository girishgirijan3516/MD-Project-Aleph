using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace Aleph
{
    public class Photo1
    {
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
    }
    public class PhotoAlbum1
    {
        static Photo1[] listPhoto =
        {
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 01"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 02"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 03"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 04"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 05"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 06"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 07"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 08"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 09"},
            new Photo1() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 010"},
        };
        private Photo1[] photos1;
        Random random;
        public PhotoAlbum1()
        {
            this.photos1 = listPhoto;
            random = new Random();
        }
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