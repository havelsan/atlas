using System;
using System.Collections.Generic;
using TTStorageManager.Security;

namespace Infrastructure.Models
{
    public class LoginResult
    {
        public List<String> Views
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public TTUser User
        {
            get;
            set;
        }
    }
}