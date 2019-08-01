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
    [Activity(Label = "@string/app_name", Icon = "@drawable/logo", MainLauncher = true)]
    public class login : Activity
    {
        Button myLogin, mySignup, my_success_login;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            // Create your application here
            myLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mySignup = FindViewById<Button>(Resource.Id.btnSignup);
            my_success_login = FindViewById<Button>(Resource.Id.btnsuccessLogin);

            mySignup.Click += delegate
            { // Already login button  
                //Intent signupScreen = new Intent(this, typeof(signup)); // on success loading signup page
                //StartActivity(signupScreen);
                StartActivity(typeof(signup));
                OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
            };

            my_success_login.Click += delegate
            { // Already login button  
                Intent signupScreen = new Intent(this, typeof(MainActivity)); // 
                StartActivity(signupScreen);
            };
        }
    }
}