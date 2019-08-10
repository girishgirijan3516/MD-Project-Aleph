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
    [Activity(Label = "@string/app_name", Icon = "@drawable/logo", MainLauncher = false)]
    public class login : Activity
    {
        Button myLogin, mySignup, my_success_login;
        EditText myUsername, myPassword;

        Android.App.AlertDialog.Builder alert;
        DBHelperClass myDB;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            // Create your application here
            myLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mySignup = FindViewById<Button>(Resource.Id.btnSignup);

            my_success_login = FindViewById<Button>(Resource.Id.btnsuccessLogin); //login
            myUsername = FindViewById<EditText>(Resource.Id.txtEmail); // email id
            myPassword = FindViewById<EditText>(Resource.Id.txtPassword); // password

            myDB = new DBHelperClass(this);
            alert = new Android.App.AlertDialog.Builder(this);


            mySignup.Click += delegate
            { // Already login button  
                //Intent signupScreen = new Intent(this, typeof(signup)); // on success loading signup page
                //StartActivity(signupScreen);
                StartActivity(typeof(signup));
                OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
            };

            my_success_login.Click += delegate
            { // Already login button  
                var user_name = myUsername.Text;
                var user_password = myPassword.Text;

                if (user_name.Trim().Equals("") || user_name.Length < 0 || user_password.Trim().Equals("") || user_password.Length < 0)
                {
                    alert.SetTitle("Aleph | Error");
                    alert.SetMessage("Please fill all fields");
                    alert.SetPositiveButton("OK", alertOKButton);
                    Dialog myDialog = alert.Create();
                    myDialog.Show();
                }
                else
                {
                    bool f = myDB.checkUser(user_name.Trim(), user_password.Trim());
                    if (f)
                    {

                        myUsername.Text = ""; myPassword.Text = "";
                        Intent homeScreen = new Intent(this, typeof(MainActivity)); //                    
                        homeScreen.PutExtra("userName", user_name.Trim());
                        homeScreen.PutExtra("userPassword", user_password.Trim());
                        StartActivity(homeScreen);
                    }
                    else
                    {
                        alert.SetTitle("Aleph | Error");
                        alert.SetMessage("Incorrect email id or password!");
                        alert.SetPositiveButton("OK", alertOKButton);
                        Dialog myDialog = alert.Create();
                        myDialog.Show();
                    }
                }



                
            };
        }
        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)
        {
            //System.Console.WriteLine("OK Button Pressed");
        }
        public override void OnBackPressed()
        {
            //base.OnBackPressed();
            this.FinishAffinity();
        }
    }
}