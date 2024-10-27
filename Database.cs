using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;

namespace OOP_Accounting
{
    internal class Database
    {
        private const string firebase_key = "homework-3-cf323";
        private FirestoreDb database;

        public void initDatabase()
        {
            FirebaseApp.Create();
            database = FirestoreDb.Create(firebase_key);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", firebase_key);
        }

        public async Task saveUserDetail(UserDetail userDetail)
        {
            CollectionReference collectionRef = database.Collection("User_Detail");
            DocumentReference documentRef = database.Document(DateTime.Now.Microsecond.ToString());
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                {   "Email",         userDetail.Email.ToString()    },
                {   "Password",      userDetail.Password.ToString() },
                {   "UserId",        userDetail.UserId.ToString()   },
            };
            Console.WriteLine("User detail with email {0} saved successfully", userDetail.Email);
            await documentRef.SetAsync(user);
        }
    }
}
