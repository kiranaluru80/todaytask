using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Foundation;
using UIKit;
using static Task_new.NewTablewViewController;
//using static Task_new.UserListViewController;

namespace Task_new
{
    public class TableSource : UITableViewSource
    {
        // string[] tablewItems;
        UserDetailsaViewController owner;
        UINavigationController aNav;
        User[] tableItems;
       // private List<User> tableItems;
        string cellIdentifier = "TableCell";

        public TableSource(User[] items,UINavigationController aNav)
        {
            tableItems = items;
            this.aNav = aNav;
          //  this.owner = owner;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
                cell.TextLabel.Text = tableItems[indexPath.Row].Username;

            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Length;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //   UserDetailsaViewController owner;
            User[] data;
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
            UserDetailsaViewController newController = (UserDetailsaViewController)storyboard.InstantiateViewController("UserDetailsaViewController");
            newController.passData(tableItems[indexPath.Row]);
           // newController.data = tableItems[indexPath.Row];
          //  newController.tab(indexPath.Row) = str;
            this.aNav.PushViewController(newController, true);
            tableView.DeselectRow(indexPath, true);

        }
     
    }
}
