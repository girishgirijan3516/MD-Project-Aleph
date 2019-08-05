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
    [Activity(Label = "signup")]
    public class signup : Activity
    {
        Button myLogin, mySignup;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signup);

            // Create your application here
            myLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mySignup = FindViewById<Button>(Resource.Id.btnSignup);

            myLogin.Click += delegate
            { // Already login button  
              //Intent loginScreen = new Intent(this, typeof(login)); // on success loading login page
              // StartActivity(loginScreen);
                StartActivity(typeof(login));
                OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
            };
        }
        public override void OnBackPressed()
        {
            StartActivity(typeof(login));
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
        }
    }
}