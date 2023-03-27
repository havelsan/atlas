using System.ComponentModel.DataAnnotations;

namespace Core.Models.Authentication
{
    public class UserCredentials
    {
        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
    }
}