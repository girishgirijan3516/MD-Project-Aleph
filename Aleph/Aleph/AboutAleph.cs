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
    [Activity(Label = "AboutAleph")]
    public class AboutAleph : Activity
    {
        TextView aboutAleph;
        Button btnOk;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.aboutAleph);
            // Create your application here
            aboutAleph = FindViewById<TextView>(Resource.Id.lb_Name);
            //btnOk = FindViewById<Button>(Resource.Id.btn_ok);
            aboutAleph.Text = "Aleph by Classicly unlocks a world of public domain content, allowing you to acquire the great books of human history. Letters of leaders, the collected works of geniuses, the finest Victorian novels, the plays of Shakespeare, the philosophy of Seneca and Marcus Aurelius, the autobiographies of Benjamin Franklin and Andrew Carnegie. It's all here, along with tens of thousands of other literature. Read with no limits for free!";

            /*btnOk.Click += delegate
            {
                
            };*/

        }
    }
}