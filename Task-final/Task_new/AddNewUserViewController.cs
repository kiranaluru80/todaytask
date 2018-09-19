    using Foundation;
    using System;
    using UIKit;
    using System.IO;
    using SQLite;
    using System.Text.RegularExpressions;
using static Task_new.NewTablewViewController;

namespace Task_new
    {
        public partial class AddNewUserViewController : UIViewController
        {
            private string DatabasePath;
            public bool IsAlphaNumeric(String strToCheck)             {                 Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");                 return !objAlphaNumericPattern.IsMatch(strToCheck);             } 
            void SaveButton_Clicked(object sender, EventArgs e)
            {
                    if (username.Text.Length > 5 && username.Text.Length < 12 || firstname.Text.Length > 5 && firstname.Text.Length < 12 || lastname.Text.Length > 5 && lastname.Text.Length < 12)
                    {
                        if (IsAlphaNumeric(passsord.Text) == true)
                        {
                            using (var connection = new SQLite.SQLiteConnection(DatabasePath))
                            {
                                connection.Insert(new User() { Username = username.Text, Firstname = firstname.Text, Lastname = lastname.Text, Password = passsord.Text, Email = email.Text });
                            }
                            NavigationController.PopViewController(true);
                        }
                        else
                        {
                            UIAlertView alert = new UIAlertView()
                            {
                                Title = "Alret",
                                Message = "Passwords must consist of a mixture of lowercase letters and numerical digits only, with at least one of each"
                            };
                            alert.AddButton("OK");
                            alert.Show();
                        }
                    }
                    else
                    {
                        UIAlertView alert = new UIAlertView()
                        {
                            Title = "Alret",
                            Message = "User Name should be 5 to 12 charecters only"
                        };
                        alert.AddButton("OK");
                        alert.Show();
                    }

            }

            public AddNewUserViewController (IntPtr handle) : base (handle)
            {
               
            }
          
            public override void ViewDidLoad()
            {
                base.ViewDidLoad();
                saveButton.Clicked += SaveButton_Clicked;
                var documentFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                DatabasePath = Path.Combine(documentFolder, "Users.db");

               
            }
        }
    }