using System.ComponentModel.DataAnnotations;

namespace Core.Models.Authentication
{
    public class ChangePassword
    {
        public string UserName
        {
            get;
            set;
        }

        public string OldPassword
        {
            get;
            set;
        }
        public string NewPassword
        {
            get;
            set;
        }
        public string ApplyNewPassword
        {
            get;
            set;
        }
    }
}