using System;
using TTObjectClasses;

namespace Core.Models
{
    public partial class SystemParameter
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public SystemParameterSubTypeEnum? SubType
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int ? CacheDurationInMinutes
        {
            get;
            set;
        }

        public bool ? IsEncrypted
        {
            get;
            set;
        }
    }
}