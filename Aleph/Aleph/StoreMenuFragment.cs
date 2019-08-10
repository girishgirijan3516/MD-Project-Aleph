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
using Android.Database;
using Android.Database.Sqlite;
using Android.App;
namespace Aleph
{
    public class StoreMenuFragment : Fragment
    {
        Activity myContext;
        ListView listView;
        SearchView mySearch;
        List<BookObject> myBooksList = new List<BookObject>();
        ArrayAdapter myAdapter;

        DBHelperClass myDB;
        public string userEmail;
        public StoreMenuFragment(Activity context, string email_id)
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
            
            View myView = inflater.Inflate(Resource.Layout.storeMenu, container, false);

            listView = myView.FindViewById<ListView>(Resource.Id.myListBooks);
            mySearch = myView.FindViewById<SearchView>(Resource.Id.searchID);
            myDB = new DBHelperClass(myContext);

            ICursor myresult = myDB.getAllBooks();

            while (myresult.MoveToNext())
            {
                myBooksList.Add(new BookObject(myresult.GetInt(myresult.GetColumnIndexOrThrow("book_id")), myresult.GetString(myresult.GetColumnIndexOrThrow("book_name")), myresult.GetString(myresult.GetColumnIndexOrThrow("book_author")), myresult.GetInt(myresult.GetColumnIndexOrThrow("book_image")), myresult.GetDouble(myresult.GetColumnIndexOrThrow("book_rate"))));
            }

            /*    myBooksList.Add(new BookObject(101,"Book 1", "Amith", Resource.Drawable.RomeoandJuliet, 3.5));
            myBooksList.Add(new BookObject(102, "Book 2", "Prasanna", Resource.Drawable.RomeoandJuliet, 4.5));
            myBooksList.Add(new BookObject(103, "Book 3", "Shriya", Resource.Drawable.RomeoandJuliet, 2));
            myBooksList.Add(new BookObject(104, "Book 4", "Raul", Resource.Drawable.RomeoandJuliet, 2.5));
            myBooksList.Add(new BookObject(105, "Book 5", "girish", Resource.Drawable.RomeoandJuliet, 3));*/


            MyCustomAdapter myAdapter = new MyCustomAdapter(myContext, myBooksList);

            listView.Adapter = myAdapter;

            listView.ItemClick += List1_ItemClick;
            mySearch.QueryTextChange += searchUsers;

            return myView;
        }
        private void List1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //System.Console.WriteLine(myBooksList[e.Position].bookName);


            Intent bookScreen = new Intent(myContext, typeof(Book)); // on success loading book page
            bookScreen.PutExtra("bookName", myBooksList[e.Position].bookName);
            bookScreen.PutExtra("userEmailid", userEmail);
            StartActivity(bookScreen);

            /*Intent userScreen = new Intent(this, typeof(User)); // on success loadingsignup page   
            userScreen.PutExtra("email_id", myUsersList[e.Position].email);
            StartActivity(userScreen);*/
        }

        public void searchUsers(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var mySearchValue = e.NewText;
            string temp;
            //System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);


            List<BookObject> tempBooksList = new List<BookObject>();
            for (int i = 0; i < myBooksList.Count; ++i)
            {
                temp = myBooksList[i].bookName.ToLower();
                if (temp.Contains(mySearchValue.ToLower()))
                {
                    tempBooksList.Add(myBooksList[i]);

                }
            }
            if (tempBooksList.Count > 0)
            {
                MyCustomAdapter myAdapter = new MyCustomAdapter(myContext, tempBooksList);
                listView.Adapter = myAdapter;
            }

        }

    }
}