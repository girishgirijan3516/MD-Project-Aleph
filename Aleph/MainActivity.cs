using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Aleph
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]    
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;
        Android.App.AlertDialog.Builder alert;

        HomeMenuFragment f1;
        MyLibraryMenuFragment f2;
        StoreMenuFragment f3;
        AboutusFragment f4;

        string userName, userPass;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            alert = new Android.App.AlertDialog.Builder(this);
            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            userName = Intent.GetStringExtra("userName");
            userPass = Intent.GetStringExtra("userPassword");

            f1 = new HomeMenuFragment(this, userName);
            f2 = new MyLibraryMenuFragment(this, userName);
            f3 = new StoreMenuFragment(this, userName);
            f4 = new AboutusFragment(this, userName);
            setFragment(f1);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    //textMessage.SetText(Resource.String.title_home);
                    setFragment(f1);
                    return true;
                case Resource.Id.navigation_library:
                    //textMessage.SetText(Resource.String.title_dashboard);
                    setFragment(f2);
                    return true;
                case Resource.Id.navigation_store:
                    //textMessage.SetText(Resource.String.title_notifications);
                    setFragment(f3);
                    return true;
                case Resource.Id.navigation_about:
                    //textMessage.SetText(Resource.String.title_notifications);
                    setFragment(f4);
                    return true;
            }
            return false;
        }

        public void setFragment(Fragment fragment)
        {
            //FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
            //fragmentTransaction.replace(Resource.Id.frameLayout1, fragment);
            //fragmentTransaction.commit();


            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.Replace(Resource.Id.frameLayout1, fragment);
            fragmentTransaction.Commit();

        }

        public override void OnBackPressed()
        {
            alert.SetTitle("Sign out");
            alert.SetMessage("Are you sure you would like to sign out?");
            alert.SetPositiveButton("SignOut", signoutButton);
            alert.SetNegativeButton("Cancel", cancelButton);
            Dialog myDialog = alert.Create();
            myDialog.Show();
            
            
        }
        public void cancelButton(object sender, Android.Content.DialogClickEventArgs e)
        {
        }
        public void signoutButton(object sender, Android.Content.DialogClickEventArgs e)
        {
            //base.OnBackPressed();
            //this.FinishAffinity();
            StartActivity(typeof(login));
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
        }

        //ActionBar
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.user_signout)
            {
                //Toast.MakeText(this, "Signout clicked", ToastLength.Short).Show();
                alert.SetTitle("Sign out");
                alert.SetMessage("Are you sure you would like to sign out?");
                alert.SetPositiveButton("SignOut", signoutButton);
                alert.SetNegativeButton("Cancel", cancelButton);
                Dialog myDialog = alert.Create();
                myDialog.Show();
                return true;
            }
            else if (id == Resource.Id.user_aboutAleph)
            {
                //Toast.MakeText(this, "About us clicked", ToastLength.Short).Show();

                StartActivity(typeof(AboutAleph));
                OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);

                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        //ActionBar
    }
}

