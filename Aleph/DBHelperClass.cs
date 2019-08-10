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
        public string createBookquery = "CREATE TABLE Book(book_id INTEGER PRIMARY KEY AUTOINCREMENT, book_name TEXT NOT NULL, book_author TEXT NOT NULL, book_type TEXT NOT NULL, book_summary CHAR(200), book_link CHAR(150),book_image TEXT NOT NULL, book_date DATETIME DEFAULT CURRENT_TIMESTAMP, book_rate REAL);";



        // insert data

        public string insertBook1Query = "";

        SQLiteDatabase connectionObj;
        public DBHelperClass(Context context) : base(context, name: DBName, factory: null, version: 1) 
        {
            myContex = context;
            connectionObj = WritableDatabase;
        }
        public override void OnCreate(SQLiteDatabase db)
        {            
            db.ExecSQL(createTableQuery); //user
            db.ExecSQL(createBookquery); //book
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

        //**************functions**********************

    }
}