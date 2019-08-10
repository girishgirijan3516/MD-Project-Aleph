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
    public class HomeMenuFragment : Fragment
    {
        RecyclerView mRecycleView, mRecycleView1;

        PhotoAlbum mPhotoAlbum;
        PhotoAlbum1 mPhotoAlbum1;

        PhotoAlbumAdapter mAdapter;
        PhotoAlbumAdapter1 mAdapter1;
        View myView;
        Activity myContext;
        public string userEmail;
        public HomeMenuFragment(Activity context, string email_id)
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

            myView = inflater.Inflate(Resource.Layout.homeMenu, container, false);

            //popular
            mPhotoAlbum = new PhotoAlbum(myContext);
            mRecycleView = myView.FindViewById<RecyclerView>(Resource.Id.recyclerView);           
            mRecycleView.SetLayoutManager(new LinearLayoutManager(myView.Context, LinearLayoutManager.Horizontal, false));
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);
            mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);
            //

            //recent
            mPhotoAlbum1 = new PhotoAlbum1(myContext);
            mRecycleView1 = myView.FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            mRecycleView1.SetLayoutManager(new LinearLayoutManager(myView.Context, LinearLayoutManager.Horizontal, false));
            mAdapter1 = new PhotoAlbumAdapter1(mPhotoAlbum1);
            mAdapter1.ItemClick += MAdapter_ItemClick1;
            mRecycleView1.SetAdapter(mAdapter1);
            //
            return myView;
        }
        private void MAdapter_ItemClick(object sender, int  e)
        {
            int photoNum = e ;
            //Toast.MakeText(myView.Context, "This is photo number " + mPhotoAlbum[e].mCaption, ToastLength.Short).Show();

            Intent bookScreen = new Intent(myContext, typeof(Book)); // on success loading book page
            bookScreen.PutExtra("bookName", mPhotoAlbum[e].mCaption);
            bookScreen.PutExtra("userEmailid", userEmail);
            StartActivity(bookScreen);

        }

        private void MAdapter_ItemClick1(object sender, int e)
        {
            int photoNum = e ;
            //Toast.MakeText(myView.Context, "This is photo number " + photoNum, ToastLength.Short).Show();
            Intent bookScreen = new Intent(myContext, typeof(Book)); // on success loading book page
            bookScreen.PutExtra("bookName", mPhotoAlbum1[e].mCaption);
            bookScreen.PutExtra("userEmailid", userEmail);
            StartActivity(bookScreen);
        }
    }
}