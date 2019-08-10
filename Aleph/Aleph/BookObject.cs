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
    class BookObject
    {
        public int bookId;
        public string bookName;
        public string bookAuthor;
        public int bookUrl;
        public double bookRating;


        public BookObject(int book_id, string book_name, string book_author, int book_url, double book_rating)
        {
            bookId = book_id;
            bookName = book_name;
            bookAuthor = book_author;
            bookUrl = book_url;
            bookRating = book_rating;
        }

    }
}