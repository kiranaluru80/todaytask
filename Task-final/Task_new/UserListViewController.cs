using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using SQLite;
using System.IO;

namespace Task_new
{
    public partial class UserListViewController : UITableViewController
    {
        

        public UserListViewController()
        {
            using (var connection = new SQLite.SQLiteConnection(DatabasePath))
            {
                var query = connection.Table<User>();
                foreach (User user in query)
                {
                    users.Add(user);
                    TableView.ReloadData();
                }
            }
            
        }
        private string DatabasePath;
        private List<User> users;
        public UserListViewController (IntPtr handle) : base (handle)
        {
            users = new List<User>();
          
        }

        public class User {
            [PrimaryKey, AutoIncrement]
            public int id {
                get;
                set;
            }

            public string Username {
                get;
                set;
            }

            public string Firstname {
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

        public override void ViewDidLoad()
        {
           // addBtn.Clicked += AddBtn_Clicked; 

            base.ViewDidLoad();

           // TableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            using (var connection = new SQLite.SQLiteConnection(DatabasePath))
            {
                var query = connection.Table<User>();
                foreach (User user in query)
                {
                    users.Add(user);
                    TableView.ReloadData();
                }
            }
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            using (var connection = new SQLite.SQLiteConnection(DatabasePath))
            {
                var query = connection.Table<User>();
                foreach (User user in query) {
                    users.Add(user);
                    TableView.ReloadData();
                } 
            }

        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return 6;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell("user");

            var finaldata = users[indexPath.Row];
            cell.TextLabel.Text = "hhhhhhhh";

            return cell;
        }
    }
}