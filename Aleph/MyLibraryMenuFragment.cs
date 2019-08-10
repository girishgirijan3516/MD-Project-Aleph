using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Aleph
{
    public class MyLibraryMenuFragment : Fragment
    {
        RecyclerView mRecycleView;
        PhotoAlbum2 mPhotoAlbum;
        PhotoAlbumAdapter2 mAdapter;
        View myView;
        RecyclerView.LayoutManager mLayoutManager;

        Activity myContext;
        public string userEmail;
        public MyLibraryMenuFragment(Activity context, string email_id)
        {
            userEmail = email_id;
            myContext = context;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            //return base.OnCreateView(inflater, container, savedInstanceState);
            myView = inflater.Inflate(Resource.Layout.myLibraryMenu, container, false);

            //popular
            mPhotoAlbum = new PhotoAlbum2(myContext, userEmail);
            mRecycleView = myView.FindViewById<RecyclerView>(Resource.Id.recyclerView2);
            //mRecycleView.SetLayoutManager(new LinearLayoutManager(myView.Context, LinearLayoutManager.Horizontal, false));
            mLayoutManager = new LinearLayoutManager(myView.Context);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mAdapter = new PhotoAlbumAdapter2(mPhotoAlbum);
            mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);


            return myView;
        }
        private void MAdapter_ItemClick(object sender, int e)
        {
            int photoNum = e;
            //Toast.MakeText(myView.Context, "This is photo number " + photoNum, ToastLength.Short).Show();

            Intent bookScreen = new Intent(myContext, typeof(LibraryBook)); // on success loading book page
            bookScreen.PutExtra("bookName", mPhotoAlbum[e].mCaption);
            bookScreen.PutExtra("userEmailid", userEmail);
            StartActivity(bookScreen);
        }

    }
}