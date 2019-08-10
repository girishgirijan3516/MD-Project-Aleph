 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace Aleph
{
    [Activity(Label = "BookContent")]
    public class BookContent : Activity
    {
        WebView webView;

        string Book_name;
        DBHelperClass myDB;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.bookContent);

            Book_name = Intent.GetStringExtra("bookName");
            myDB = new DBHelperClass(this);

            string bookURL = myDB.getBookURL(Book_name);


            webView = FindViewById<WebView>(Resource.Id.webView);
            webView.SetWebViewClient(new WebViewClient());

            WebSettings webSettings = webView.Settings;
            webSettings.JavaScriptEnabled = true;
            webView.LoadUrl(bookURL);

        }
    }
    internal class ExtendWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }
    }
}