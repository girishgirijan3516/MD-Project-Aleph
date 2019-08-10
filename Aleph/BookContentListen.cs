using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Dyanamitechetan.Vusikview;
using Android.Media;
using static Android.Views.View;
using Android.Views;
using System;
using Java.Lang;
using Java.Util.Concurrent;
using static Android.Media.MediaPlayer;

namespace Aleph
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class BookContentListen : AppCompatActivity, IOnClickListener, IOnTouchListener, IOnBufferingUpdateListener, IOnCompletionListener
    {
        public ImageButton btn_play_pause;
        public SeekBar seekBar;
        public TextView txt_timer;

        public VusikView musicView;

        public MediaPlayer mediaPlayer;
        public int mediaFileLength, realTime;
        public Handler handler = new Handler();

        public void OnBufferingUpdate(MediaPlayer mp, int percent)
        {
            //seekBar.SetOnSeekBarChangeListener(percent);
            seekBar.SecondaryProgress = percent;
        }

        public void OnClick(View v)
        {
            if (v.Id == Resource.Id.btn_play_pause)
            {
                new MP3Play(this).Execute("https://jk9nj200-a.akamaihd.net/downloads/ringtones/files/mp3/cradles-46382.mp3");//direct link
                musicView.Start();
            }
        }

        public void OnCompletion(MediaPlayer mp)
        {
            btn_play_pause.SetImageResource(Resource.Drawable.ic_play);
            musicView.StopNotesFall();
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            if (v.Id == Resource.Id.seekBar)
            {
                if (mediaPlayer.IsPlaying)
                {
                    SeekBar sb = (SeekBar)v;
                    int playPosition = (mediaFileLength / 100) * sb.Progress;
                    mediaPlayer.SeekTo(playPosition);
                }
            }
            return false;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.bookContentListen);
            musicView = FindViewById<VusikView>(Resource.Id.musicView);
            btn_play_pause = FindViewById<ImageButton>(Resource.Id.btn_play_pause);
            btn_play_pause.SetOnClickListener(this);

            seekBar = FindViewById<SeekBar>(Resource.Id.seekBar);
            seekBar.Max = 99; // 100 0-99
            seekBar.SetOnTouchListener(this);

            txt_timer = FindViewById<TextView>(Resource.Id.txt_timer);
            mediaPlayer = new MediaPlayer();
            mediaPlayer.SetOnBufferingUpdateListener(this);
            mediaPlayer.SetOnCompletionListener(this);

        }
    }

    internal class MP3Play : AsyncTask<string, string, string>
    {
        private BookContentListen mainActivity;
        //private ProgressDialog mDialog;       

        public MP3Play(BookContentListen mainActivity)
        {
            this.mainActivity = mainActivity;
        }
        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            /* mDialog = new ProgressDialog(mainActivity.BaseContext);
             mDialog.Window.SetType(WindowManagerTypes.SystemAlert);
             mDialog.SetMessage("Please wait..");
             mDialog.Show();*/
        }
        protected override void OnPostExecute(string result)
        {
            mainActivity.mediaFileLength = mainActivity.realTime = mainActivity.mediaPlayer.Duration;
            if (!mainActivity.mediaPlayer.IsPlaying)
            {
                mainActivity.mediaPlayer.Start();
                mainActivity.btn_play_pause.SetImageResource(Resource.Drawable.ic_pause);
            }
            else
            {
                mainActivity.mediaPlayer.Pause();
                mainActivity.btn_play_pause.SetImageResource(Resource.Drawable.ic_play);
            }
            UpdateSeekBar();
            //mDialog.Dismiss();
        }

        private void UpdateSeekBar()
        {
            mainActivity.seekBar.Progress = ((int)(((float)mainActivity.mediaPlayer.CurrentPosition / mainActivity.mediaFileLength) * 100));
            if (mainActivity.mediaPlayer.IsPlaying)
            {
                Runnable update = new Runnable(() => {
                    UpdateSeekBar();
                    mainActivity.realTime -= 1000; // 1sec
                    UpdateSeekBar();
                    mainActivity.realTime -= 1000; // 1sec
                    //00:00 min:sec
                    mainActivity.txt_timer.Text = $"{TimeUnit.Milliseconds.ToMinutes(mainActivity.realTime)}:{TimeUnit.Milliseconds.ToSeconds(mainActivity.realTime) - TimeUnit.Milliseconds.ToMinutes(mainActivity.realTime)}";

                });
                mainActivity.handler.PostDelayed(update, 1000);
            }
        }

        protected override string RunInBackground(params string[] @params)
        {
            try
            {
                mainActivity.mediaPlayer.SetDataSource(@params[0]);
                mainActivity.mediaPlayer.Prepare();
            }
            catch
            {

            }
            return "";
        }
    }
}