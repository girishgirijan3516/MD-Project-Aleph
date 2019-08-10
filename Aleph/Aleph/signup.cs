using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        Button myLogin, mySignup, btnSignup; // buttons
        EditText txtName, txtEmail, txtPassword; // textboxes

        DBHelperClass myDB; //database
        Android.App.AlertDialog.Builder alert; // alert box

        static string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signup);

            // Create your application here
            myLogin = FindViewById<Button>(Resource.Id.btnLogin);
            mySignup = FindViewById<Button>(Resource.Id.btnSignup);

            btnSignup = FindViewById<Button>(Resource.Id.button3); // signup
            txtName = FindViewById<EditText>(Resource.Id.editText); //name
            txtEmail = FindViewById<EditText>(Resource.Id.editText2); //email
            txtPassword = FindViewById<EditText>(Resource.Id.editText3); //password

            alert = new Android.App.AlertDialog.Builder(this); // database
            myDB = new DBHelperClass(this); // alertbox


            myLogin.Click += delegate
            { // Already login button  
              //Intent loginScreen = new Intent(this, typeof(login)); // on success loading login page
              // StartActivity(loginScreen);
                StartActivity(typeof(login));
                OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
            };

            btnSignup.Click += delegate
            {
                alert.SetTitle("Aleph | Error !");
                if (txtName.Text.Trim().Equals("") || txtName.Text.Length < 0 || txtEmail.Text.Trim().Equals("") || txtEmail.Text.Length < 0  || txtPassword.Text.Trim().Equals("") || txtPassword.Text.Length < 0)
                {                    
                    alert.SetMessage("Please fill all fields");
                    alert.SetPositiveButton("OK", alertOKButton);
                    Dialog myDialog = alert.Create();
                    myDialog.Show();
                }
                else if (!re.IsMatch(txtEmail.Text.Trim()))
                {
                    alert.SetMessage("Please enter valid Email address");
                    alert.SetPositiveButton("OK", alertOKButton);
                    Dialog myDialog = alert.Create();
                    myDialog.Show();
                }
                else
                {
                    Boolean f = myDB.insertValue(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim());
                    if (f)
                    {
                        txtName.Text = ""; txtEmail.Text = ""; txtPassword.Text = ""; 
                        alert.SetMessage("Registration successfull!");

                    }
                    else
                    {
                        alert.SetMessage("User already exist!");
                    }
                    alert.SetTitle("Aleph | Information");
                    alert.SetPositiveButton("OK", redirectToLogin);
                    Dialog myDialog = alert.Create();
                    myDialog.Show();
                }
            };

        }
        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)
        {
            //System.Console.WriteLine("OK Button Pressed");
        }
        public void redirectToLogin(object sender, Android.Content.DialogClickEventArgs e)
        {            
            StartActivity(typeof(login));
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
        }
        public override void OnBackPressed()
        {
            StartActivity(typeof(login));
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
        }
    }
}