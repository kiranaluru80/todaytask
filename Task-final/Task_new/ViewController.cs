    using System;
    using System.Collections.Generic;
    using System.IO;
    using UIKit;
    using static Task_new.NewTablewViewController;

    namespace Task_new
    {
        public partial class ViewController : UIViewController
    {
            private bool DatabaseValue = false;
            private string DatabasePath;
            private List<User> users;
            partial void Button_TouchUpInside(UIButton sender)
            {
                
            var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            DatabasePath = Path.Combine(documentFolder, "Users.db");
                using (var connection = new SQLite.SQLiteConnection(DatabasePath))
                {
                if(DatabaseValue == false) {
                    connection.CreateTable<User>();
                    connection.Insert(new User() { Username = "Task", Firstname = "Task", Lastname = "Task", Password = "Task1", Email = "Task" });
                    DatabaseValue = true;
                }
                    
                    var query = connection.Table<User>();
                    foreach (User user in query)
                    {
                        users.Add(user);
                    }
                if (users.Count == 0)
                {
                    //var documentFolder1 = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    //DatabasePath = Path.Combine(documentFolder1, "Users.db");
                    //using (var connection2 = new SQLite.SQLiteConnection(DatabasePath))
                    //{
                    //  //  connection2.CreateTable<User>();

                    //}
                    //using (var connection1 = new SQLite.SQLiteConnection(DatabasePath))
                    //{
                       
                    //}
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Alret",
                        Message = "No User Available in the Database.Please enter Username as Task and Password as Task1"
                    };
                    alert.AddButton("OK");
                    alert.Show();

                }
                else
                {


                    for (int i = 0; i < users.Count; i++)
                    {
                        if (usernameTxt.Text == users[i].Username && passwordTxt.Text == users[i].Password && usernameTxt.Text == "Task" && passwordTxt.Text == "Task1")
                        {
                            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
                            NewTablewViewController newController = (NewTablewViewController)storyboard.InstantiateViewController("NewTablewViewController");
                            this.NavigationController.PushViewController(newController, true);
                            break;
                        }
                        else
                        {
                            UIAlertView alert = new UIAlertView()
                            {
                                Title = "Alret",
                                Message = "Please enter valid username and password or enter default Username as Task and Password as Task1"
                            };
                            alert.AddButton("OK");
                            alert.Show();
                            break;
                        }
                    }
                }
                }


            }

         
            protected ViewController(IntPtr handle) : base(handle)
            {
                users = new List<User>();
            }
            

            public override void ViewDidLoad()
            {
                base.ViewDidLoad();
                // Perform any additional setup after loading the view, typically from a nib.
            }

            public override void DidReceiveMemoryWarning()
            {
                base.DidReceiveMemoryWarning();
                // Release any cached data, images, etc that aren't in use.
            }
        }
    }
