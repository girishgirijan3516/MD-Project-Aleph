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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class Book : Activity
    {
        TextView bookName, bookauthor, rateValue, booksum;
        Button btnRead, btnAddLibrary;
        string Book_name, userEmail;
        int bookId;
        DBHelperClass myDB;
        Android.App.AlertDialog.Builder alert;
        ImageView bookImg;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Book);
            myDB = new DBHelperClass(this);
            alert = new Android.App.AlertDialog.Builder(this);
            btnRead = FindViewById<Button>(Resource.Id.btn_read);
            btnAddLibrary = FindViewById<Button>(Resource.Id.btn_add_library);

            bookName = FindViewById<TextView>(Resource.Id.bookName);
            bookauthor = FindViewById<TextView>(Resource.Id.bookAuthor);
            rateValue = FindViewById<TextView>(Resource.Id.RateValue);
            booksum = FindViewById<TextView>(Resource.Id.bookSum);
            bookImg = FindViewById<ImageView>(Resource.Id.bookImageId);

            Book_name = Intent.GetStringExtra("bookName");
            userEmail = Intent.GetStringExtra("userEmailid");
            bookName.Text = Book_name;

            string[] bookDetails = myDB.getBookInformations(Book_name);

            bookauthor.Text = bookDetails[0];
            booksum.Text = bookDetails[2];
            var type_book = bookDetails[1];
            rateValue.Text = bookDetails[3];
            bookId = System.Convert.ToInt32(bookDetails[4]);
            bookImg.SetBackgroundResource(System.Convert.ToInt32(bookDetails[5]));
            if (type_book == "book") 
            {
                btnRead.Click += ReadBook;
                btnRead.Text = "Read";
            }
            else
            {
                btnRead.Click += ListenBook;
                btnRead.Text = "Listen";
            }

            btnAddLibrary.Click += AddLibraryBook;


        }
        public void AddLibraryBook(object sender, EventArgs e)
        {
            bool f = myDB.addToLibrary(userEmail, bookId);

            if (f)
            {
                alert.SetTitle("Aleph | Infromation !");
                alert.SetMessage("Book Added to Library");
            }
            else
            {
                alert.SetTitle("Aleph | Infromation !");
                alert.SetMessage("Book Already exist in Library");
            }
            alert.SetPositiveButton("OK", alertOKButton);
            Dialog myDialog = alert.Create();
            myDialog.Show();
        }
        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)
        {
            //System.Console.WriteLine("OK Button Pressed");
        }

        public void ReadBook(object sender, EventArgs e)
        {
            Intent bookContentScreen = new Intent(this, typeof(BookContent)); // on success loading book page
            bookContentScreen.PutExtra("bookName", bookName.Text);
            StartActivity(bookContentScreen);
        }
        public void ListenBook(object sender, EventArgs e)
        {
            Intent bookContentListenScreen = new Intent(this, typeof(BookContentListen)); // on success loading book page
            bookContentListenScreen.PutExtra("bookName", bookName.Text);
            StartActivity(bookContentListenScreen);
        }
        public override void OnBackPressed()
        {
            StartActivity(typeof(MainActivity));
            OverridePendingTransition(Resource.Animation.fade_in, Resource.Animation.fade_out);
        }
    }
}