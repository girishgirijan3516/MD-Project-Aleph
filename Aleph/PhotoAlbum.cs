using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;

namespace Aleph
{
    public class Photo
    {
        public int mPhotoID { get; set; }
        public string mCaption { get; set; }
    }
    public class PhotoAlbum
    {
        static Photo[] listPhoto =
        {
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 1"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 2"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 3"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 4"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 5"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 6"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 7"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 8"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 9"},
            new Photo() {mPhotoID = Resource.Drawable.RomeoandJuliet, mCaption = "Book 10"},
        };
        private Photo[] photos;
        Random random;
        public PhotoAlbum()
        {
            this.photos = listPhoto;
            random = new Random();
        }
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