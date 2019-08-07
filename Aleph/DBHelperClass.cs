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
        public string createTableQuery = "CREATE TABLE Users (user_id INTEGER PRIMARY KEY AUTOINCREMENT, user_name text NOT NULL, email_id text, password text);";

        SQLiteDatabase connectionObj;
        public DBHelperClass(Context context) : base(context, name: DBName, factory: null, version: 1) //  // Step 5
        {
            myContex = context;
            connectionObj = WritableDatabase;
        }
        public override void OnCreate(SQLiteDatabase db)
        {            
            db.ExecSQL(createTableQuery);    // // Step 7
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }

        //functions
    }
}