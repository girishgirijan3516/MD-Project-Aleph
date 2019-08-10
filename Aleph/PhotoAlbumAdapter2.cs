﻿using Android.Support.V7.Widget;
using Android.Views;
using System;

namespace Aleph
{
    public class PhotoAlbumAdapter2 : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        public PhotoAlbum2 mPhotoAlbum;
        public PhotoAlbumAdapter2(PhotoAlbum2 photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }
        public override int ItemCount
        {
            get { return mPhotoAlbum.numPhoto; }
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            vh.Image.SetImageResource(mPhotoAlbum[position].mPhotoID);
            vh.Caption.Text = mPhotoAlbum[position].mCaption;
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCard2, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
            return vh;
        }
        private void OnClick(int obj)
        {
            if (ItemClick != null)
                ItemClick(this, obj);
        }
    }
}