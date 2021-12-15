using System;
using System.Collections.Generic;
using System.Text;

namespace VKontakte.Model
{
    public class SimpleUserModel : Java.Lang.Object
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo400Orig { get; set; }
    }
}
