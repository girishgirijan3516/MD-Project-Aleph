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
using Android.Database;
using Android.Database.Sqlite; 

namespace Aleph
{
    class DBHelperClass : SQLiteOpenHelper
    {
        Context myContex;        
        public static string DBName = "alephDB.db";

        //create tables
        public string createTableQuery = "CREATE TABLE Users (user_id INTEGER PRIMARY KEY AUTOINCREMENT, user_name text NOT NULL, email_id text, password text);";
        public string createBookquery = "CREATE TABLE Book(book_id INTEGER PRIMARY KEY AUTOINCREMENT, book_name TEXT NOT NULL, book_author TEXT NOT NULL, book_type TEXT NOT NULL, book_summary CHAR(500), book_link CHAR(250),book_image INTEGER(30) NOT NULL, book_date DATETIME DEFAULT CURRENT_TIMESTAMP, book_rate REAL);";

        public string createMyLibrary = "CREATE TABLE myLibrary(email_id text, book_id INTEGER);";

        // insert data
        public static int[] bookImg = {Resource.Drawable.RomeoandJuliet,
        Resource.Drawable.gonewithwind,
        Resource.Drawable.Invisibleman,
        Resource.Drawable.dunwichhorror,
        Resource.Drawable.horseandboy,
        Resource.Drawable.beautyandbeast,
        Resource.Drawable.Venice,
        Resource.Drawable.Forest,
        Resource.Drawable.BleakHouse,
        Resource.Drawable.SenseSensibility
        };
        public string Query1 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('Romeo and Juliet','William Shakespeare','book', 'Written in the mid-1590s, the play is regarded as one of the Bards earliest masterpieces. To make Romeo and Juliet more accessible for the modern reader','https://docs.google.com/document/d/1ZWRu1D1St8UU_GQqR7i57Ioo0ofJKfo0Ef6A39uMrp0/edit?usp=sharing',"+bookImg[0]+",4.5)";
        public string Query2 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('Gone with wind','Margaret Mitchell','book', 'Miss Mitchell paints a broad canvas, an an exciting one. And, in spite of its length, the book moves swiftly and smoothly--a three-decker with all sails set.','https://docs.google.com/document/d/1JaUoQJHT5NG4LFLzaD_cWaD5PNWbcH5Xqqbx3LKYFuA/edit?usp=sharing'," + bookImg[1] + ",3.5)";
        public string Query3 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('The invisible man','Ralph Ellison','book', 'Invisible Man is a novel by Ralph Ellison, published by Random House in 1952. It addresses many of the social and intellectual issues facing African Americans early in the twentieth','https://docs.google.com/document/d/1yeUBWMa3SlRKBTtf-PNZE06XfNgVOaaeR8zL6lVd-oI/edit?usp=sharing'," + bookImg[2] + ",2.5)";
        public string Query4 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('The Dunwich Horror','Daniel Haller','book', 'The Dunwich Horror is a 1970 American independent supernatural horror film from American International Pictures directed by Daniel Haller and produced by Roger Corman.','https://docs.google.com/document/d/1QR0nj6LkscVCefKs6d8uMmX_0z1feWZh2fMHWky5Nao/edit?usp=sharing'," + bookImg[3] + ",2.5)";
        public string Query5 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('The Horse and his Boy','William Shakespeare','book', 'The Horse and His Boy is a novel for children by C. S. Lewis, published by Geoffrey Bles in 1954. Of the seven novels that comprise The Chronicles of Narnia, The Horse and His Boy','https://docs.google.com/document/d/1pQ39FK6b9QmFoszqrqoI7j1pvG83vCgrIGLPFuK0kC4/edit?usp=sharing'," + bookImg[4] + ",4.5)";
        public string Query6 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('Beauty and the Beast','Disney Book Group','audio', 'When Belles father is captured, she takes his place as the fearsome Beasts prisoner. But life in the enchanted castle isnt as terrible as Belle imagines. She makes','https://jk9nj200-a.akamaihd.net/downloads/ringtones/files/mp3/cradles-46382.mp3'," + bookImg[5] + ",4.5)";
        public string Query7 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('The Merchant of Venice Story','Andrew Matthews','audio', 'In Venice, the merchant Antonio borrows money so his friend can woo a beautiful lady. He agrees that if he doesnt repay Shylock the moneylender, Shylock can ','https://jk9nj200-a.akamaihd.net/downloads/ringtones/files/mp3/cradles-46382.mp3'," + bookImg[6] + ",5.0)";
        public string Query8 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('The Forest Cloaked Princess','C. S. Lewis','audio', 'The merchant Antonio borrows money so his friend can woo a beautiful lady. He agrees that if he doesnt repay Shylock the moneylender, Shylock can take a pound of his flesh.','https://jk9nj200-a.akamaihd.net/downloads/ringtones/files/mp3/cradles-46382.mp3'," + bookImg[7] + ",3.5)";
        public string Query9 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('Bleak House','Charles Dicken','audio', 'In this novel Dickens introduced several characters and many sub-plots. Like his other works he presented various actual places and people and imaginatively changed them','https://jk9nj200-a.akamaihd.net/downloads/ringtones/files/mp3/cradles-46382.mp3'," + bookImg[8] + ",3.5)";
        public string Query10 = "INSERT INTO Book(book_name, book_author, book_type, book_summary, book_link, book_image, book_rate) VALUES('Sense and Sensibility','Jane Austen','audio', 'This story of manners describes the lives of the 3 Dashwood sisters, Elinor, Marianne and Margaret. After the death of their father, they have to leave their family estate','https://jk9nj200-a.akamaihd.net/downloads/ringtones/files/mp3/cradles-46382.mp3'," + bookImg[9] + ",4.5)";



        SQLiteDatabase connectionObj;
        public DBHelperClass(Context context) : base(context, name: DBName, factory: null, version: 1) 
        {
            myContex = context;
            connectionObj = WritableDatabase;
        }
        public override void OnCreate(SQLiteDatabase db)
        {            
            db.ExecSQL(createTableQuery); //user
            db.ExecSQL(createBookquery); //
            db.ExecSQL(createMyLibrary);

            db.ExecSQL(Query1);
            db.ExecSQL(Query2);
            db.ExecSQL(Query3);
            db.ExecSQL(Query4);
            db.ExecSQL(Query5);
            db.ExecSQL(Query6);
            db.ExecSQL(Query7);
            db.ExecSQL(Query8);
            db.ExecSQL(Query9);
            db.ExecSQL(Query10);
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }

        //**************functions**********************

        //************** Insert new user | Signup **********************
        public Boolean insertValue(string user_name, string user_email, string user_password)
        {
            string selectQuery = "SELECT * FROM Users WHERE email_id = '" + user_email + "'";
            ICursor myresult = connectionObj.RawQuery(selectQuery, null);
            if (myresult.Count > 0)
                return false;
            else
            {
                string insertQuery = "INSERT INTO Users(user_name, email_id, password)VALUES('" + user_name + "', '" + user_email + "', '" + user_password + "')";
                //System.Console.WriteLine("Insert Query \n  \n" + insertQuery);
                connectionObj.ExecSQL(insertQuery);
                return true;
            }
            
        }
        //************** Check user | Login **********************
        public Boolean checkUser(string email_id, string pass)
        {
            string selectQuery = "SELECT * FROM Users WHERE email_id = '" + email_id + "' and password='" + pass + "'";
            ICursor myresult = connectionObj.RawQuery(selectQuery, null);

            if (myresult.Count > 0)
            {
                /*
                while (myresut.MoveToNext())
                {
                    System.Console.WriteLine("First Name :" + myresut.GetString(myresut.GetColumnIndexOrThrow("first_name")));
                    System.Console.WriteLine("Last Name :" + myresut.GetString(myresut.GetColumnIndexOrThrow("last_name")));
                }*/

                return true;
            }
            else
                return false;
        }
        //get user details
        public string[] getUserDetails(string email_id)
        {
            string[] userDetails = new string[4];
            // userDetails[0] = "Girish";
            string selectQuery = "SELECT * FROM Users WHERE email_id = '" + email_id + "'";
            ICursor myresult = connectionObj.RawQuery(selectQuery, null);
            while (myresult.MoveToNext())
            {
                userDetails[0] = myresult.GetString(myresult.GetColumnIndexOrThrow("user_name"));
                userDetails[1] = myresult.GetString(myresult.GetColumnIndexOrThrow("email_id"));
                userDetails[2] = myresult.GetString(myresult.GetColumnIndexOrThrow("password"));
                
            }
            return userDetails;
        }

        //update user details
        public void updateData(string user_name, string user_email, string user_password)
        {
            string updateQuery = "update Users set user_name = '" + user_name + "',password = '" + user_password + "' where email_id = '" + user_email + "'";
            connectionObj.ExecSQL(updateQuery);
        }

        //get all books
       
        public ICursor getAllBooks()
        {
            string selectQuery = "SELECT * FROM Book order by book_date asc";
            //Console.WriteLine(selectQuery);
            ICursor myresult = connectionObj.RawQuery(selectQuery, null);
            return myresult;
        }
        //get all books

        public ICursor getAllLibraryBooks(string email_id)
        {
            string selectQuery = "select b.book_name as bookname, b.book_image as bookimage from myLibrary l inner join book b on l.book_id = b.book_id where l.email_id = '" + email_id + "'";
            //Console.WriteLine(selectQuery);
            ICursor myresult = connectionObj.RawQuery(selectQuery, null);
            return myresult;
        }

        //get book details
        public string[] getBookInformations(string bookName)
        {
            string[] bookDetails = new string[6];
            string selectQuery = "SELECT * FROM Book WHERE book_name = '" + bookName + "'";
            Console.WriteLine(selectQuery);
            ICursor myresut = connectionObj.RawQuery(selectQuery, null);
            while (myresut.MoveToNext())
            {
                bookDetails[0] = myresut.GetString(myresut.GetColumnIndexOrThrow("book_author"));
                bookDetails[1] = myresut.GetString(myresut.GetColumnIndexOrThrow("book_type"));
                bookDetails[2] = myresut.GetString(myresut.GetColumnIndexOrThrow("book_summary"));
                bookDetails[3] = myresut.GetString(myresut.GetColumnIndexOrThrow("book_rate"));
                bookDetails[4] = myresut.GetString(myresut.GetColumnIndexOrThrow("book_id"));
                bookDetails[5] = myresut.GetString(myresut.GetColumnIndexOrThrow("book_image"));
            }
            return bookDetails;
        }

        //get book url
        public string getBookURL(string bookName)
        {
            string selectQuery = "SELECT book_link FROM Book WHERE book_name = '" + bookName + "'";
            //Console.WriteLine(selectQuery);
            string bookURL = "";
            ICursor myresut = connectionObj.RawQuery(selectQuery, null);
            while (myresut.MoveToNext())
            {
                bookURL = myresut.GetString(myresut.GetColumnIndexOrThrow("book_link"));
            }
            return bookURL;
        }

        // add to library
        public Boolean addToLibrary(string email_id, int book_id)
        {
           string selectQuery = "SELECT * FROM myLibrary WHERE email_id = '" + email_id + "' and book_id = "+ book_id + "";           
            ICursor myresut = connectionObj.RawQuery(selectQuery, null);

            if (myresut.Count > 0)
                return false;
            else
            {
                string insertQuery = "INSERT INTO myLibrary(email_id, book_id)VALUES('" + email_id + "', " + book_id + ")";                
                connectionObj.ExecSQL(insertQuery);
                return true;
            }
        }
        public void removeFromLibrary(string email_id, int book_id)
        {
            string deleteQuery = "delete FROM myLibrary WHERE email_id = '" + email_id + "' and book_id = " + book_id + "";
            connectionObj.ExecSQL(deleteQuery);
        }

        //**************functions**********************

    }
}