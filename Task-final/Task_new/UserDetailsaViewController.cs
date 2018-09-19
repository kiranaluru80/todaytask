using Foundation;
using System;
using UIKit;
using static Task_new.NewTablewViewController;
using Newtonsoft.Json;

namespace Task_new
{
    public partial class UserDetailsaViewController : UIViewController
    {
        NSString main;

        Task_new.NewTablewViewController.User data;
       // User[] data;
        public UserDetailsaViewController(NSString str)
        {
            
        }

        public UserDetailsaViewController (IntPtr handle) : base (handle)
        {
            
        }


        public override void ViewWillAppear(bool animated)
        {
          
            base.ViewWillAppear(animated);
        }

        internal void passData(User user)
        {
            data = user;

            Console.WriteLine("fuck", user.Firstname);
         
            this.View.BackgroundColor = UIColor.White;
             
            UILabel lable = new UILabel();
            lable.Frame = new CoreGraphics.CGRect(100, 140, 250, 40);
            lable.Text = "Username is  " + user.Username;
            this.Add(lable);

            UILabel lable1 = new UILabel();
            lable1.Frame = new CoreGraphics.CGRect(100, 180, 250, 40);
            lable1.Text = "Firstname is " + user.Firstname;
            this.Add(lable1);




        }
    }
}