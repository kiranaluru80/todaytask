    using Foundation;
    using System;
    using UIKit;
    using System.Collections.Generic;
    using System.IO;
    using SQLite;

    namespace Task_new
    {
        public partial class NewTablewViewController : UIViewController
        {
            private string DatabasePath;
            private List<User> users;
       // protected UserDetailsaViewController owner;

            public NewTablewViewController (IntPtr handle) : base (handle)
            {
               
                users = new List<User>();
            }
           
            public override void ViewDidLoad()
            {
                base.ViewDidLoad();

            }

             public override void ViewWillAppear(bool animated)
            {
                base.ViewWillAppear(animated);
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DatabasePath = Path.Combine(documentFolder, "Users.db");
                using (var connection = new SQLite.SQLiteConnection(DatabasePath))
                {
                    users = new List<User>();
                    var query = connection.Table<User>();
                    foreach (User user in query)
                    {
                        users.Add(user);
                    }
                    Console.WriteLine("the count in the array is ", users.Count);
                }
            tablewView.Source = new TableSource(users.ToArray(),this.NavigationController);
            }


            public class User
            {
                [PrimaryKey, AutoIncrement]
                public int id
                {
                    get;
                    set;
                }

                public string Username
                {
                    get;
                    set;
                }

                public string Firstname
                {
                    get;
                    set;
                }
                public string Lastname
                {
                    get;
                    set;
                }

                public string Password
                {
                    get;
                    set;
                }
                public string Email
                {
                    get;
                    set;
                }

            }
        }
    }