using System;

namespace Task_new
{
    internal class JavaScriptSerializer
    {
        public JavaScriptSerializer()
        {
        }

        internal dynamic Deserialize(NewTablewViewController.User user, Type type)
        {
            return user;
        }
    }
}