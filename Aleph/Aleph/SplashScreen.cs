using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Felipecsl.GifImageViewLib;

namespace Aleph
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/logo", MainLauncher = true)]
    public class SplashScreen : AppCompatActivity
    {
        private GifImageView gifImageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);

            // Create your application here
            gifImageView = FindViewById<GifImageView>(Resource.Id.gifImageView);
            // progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);

            Stream input = Assets.Open("Splash.gif");
            byte[] bytes = ConvertFileToByteArray(input);
            gifImageView.SetBytes(bytes);
            gifImageView.StartAnimation();

            //Wait for 3 seconds and start new Activity
            Timer timer = new Timer();
            timer.Interval = 15000;
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {            
            StartActivity(typeof(login));
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
        }

        private byte[] ConvertFileToByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}