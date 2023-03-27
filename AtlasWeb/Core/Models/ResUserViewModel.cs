using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class ResUserViewModel
    {
        public Guid? ObjectID
        {
            get;
            set;
        }

        public string LogonName
        {
            get;
            set;
        }

        public DateTime? DateOfJoin
        {
            get;
            set;
        }

        public string Work
        {
            get;
            set;
        }

        public string WorkPlace
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public Guid? Person
        {
            get;
            set;
        }
    }
}