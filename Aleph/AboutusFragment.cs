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

namespace Aleph
{
    public class AboutusFragment : Fragment
    {
        public string userEmail;
        Activity myContext;
        public string[] userDetails;

        Android.App.AlertDialog.Builder alert;
        DBHelperClass myDB;

        EditText myUserName, myEmailId, myPassword, myCPassword;
        Button btnUpdate;
        TextView welcomeNote;

        public AboutusFragment(Activity context, string email_id)
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
            View myView = inflater.Inflate(Resource.Layout.layout1, container, false);

            myDB = new DBHelperClass(myContext);
            alert = new Android.App.AlertDialog.Builder(myContext);
            userDetails = myDB.getUserDetails(userEmail);

            btnUpdate = myView.FindViewById<Button>(Resource.Id.btn_update);
            myUserName = myView.FindViewById<EditText>(Resource.Id.txt_Name);
            myEmailId = myView.FindViewById<EditText>(Resource.Id.txt_Email);
            myPassword = myView.FindViewById<EditText>(Resource.Id.txt_Password);
            myCPassword = myView.FindViewById<EditText>(Resource.Id.txt_Cpassword);
            welcomeNote = myView.FindViewById<TextView>(Resource.Id.txtUserName);

            myUserName.Text = userDetails[0];
            myEmailId.Text = userDetails[1];
            myPassword.Text = userDetails[2];
            myCPassword.Text = userDetails[2];
            welcomeNote.Text = "Hey ! "+ userDetails[0];

            btnUpdate.Click += delegate
            {
                if (myUserName.Text.Trim().Equals("") || myUserName.Text.Length < 0 || myPassword.Text.Trim().Equals("") || myPassword.Text.Length < 0 || myCPassword.Text.Trim().Equals("") || myCPassword.Text.Length < 0)
                {
                    alert.SetTitle("Aleph | Error");
                    alert.SetMessage("Please fill all fields");
                    alert.SetPositiveButton("OK", alertOKButton);
                    Dialog myDialog = alert.Create();
                    myDialog.Show();
                }
                else if (myPassword.Text.Trim() != myCPassword.Text.Trim())
                {
                    alert.SetTitle("Aleph | Error");
                    alert.SetMessage("Passwords are not matching");
                    alert.SetPositiveButton("OK", alertOKButton);
                    Dialog myDialog = alert.Create();
                    myDialog.Show();
                }
                else
                {
                    myDB.updateData(myUserName.Text.Trim(), myEmailId.Text.Trim(), myPassword.Text.Trim());
                    alert.SetTitle("Aleph | Information");
                    alert.SetMessage("Information Updated Successfully");
                    alert.SetPositiveButton("OK", alertSuccessButton);
                    Dialog myDialog = alert.Create();
                    myDialog.Show();
                }
            };


            return myView;
        }
        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)
        {
            //System.Console.WriteLine("OK Button Pressed");
        }
        public void alertSuccessButton(object sender, Android.Content.DialogClickEventArgs e)
        {
            //System.Console.WriteLine("OK Button Pressed");
            AboutusFragment f1 = new AboutusFragment(myContext, myEmailId.Text.Trim());
            setFragment(f1);
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
    }
}