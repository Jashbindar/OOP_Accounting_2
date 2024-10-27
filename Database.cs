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

        public async Task<List<UserAccount>> getUserDetail()
        {
            var userAccounts = new List<UserAccount>();
            var collectionRef = database.Collection("User_Transaction");
            var querySnapshot = await collectionRef.GetSnapshotAsync();

            foreach (var document in querySnapshot.Documents)
            {
                // Get main document data
                var data = document.ToDictionary();
                var amount = double.Parse(data["Amount"].ToString());
                var account = new UserAccount(amount);

                // Get subcollections of this document
                var subcollections = await document.Reference.ListCollectionsAsync().ToListAsync();
                foreach (var subcollection in subcollections)
                {
                    var subDocs = await subcollection.GetSnapshotAsync();
                    foreach (var subDoc in subDocs.Documents)
                    {
                        var subData = subDoc.ToDictionary();
                        if (subData.ContainsKey("SubAmount"))
                        {
                            var subAmount = double.Parse(subData["SubAmount"].ToString());
                        }
                    }
                }

                userAccounts.Add(account);
            }
            return userAccounts;
        }

        public async Task<List<UserAccount>> getUserDetailWithSpecificSubcollection(string documentId)
        {
            var userAccounts = new List<UserAccount>();

            // Access specific document
            var docRef = database.Collection("User_Transaction").Document(documentId);

            // Access its specific subcollection
            var subcollectionRef = docRef.Collection("SubTransactions");
            var subDocs = await subcollectionRef.GetSnapshotAsync();

            foreach (var subDoc in subDocs.Documents)
            {
                var subData = subDoc.ToDictionary();
                // Process subcollection data
                if (subData.ContainsKey("Amount"))
                {
                    var amount = double.Parse(subData["Amount"].ToString());
                    var account = new UserAccount(amount);
                    userAccounts.Add(account);
                }
            }
        
            return userAccounts;
        }
    }
}
