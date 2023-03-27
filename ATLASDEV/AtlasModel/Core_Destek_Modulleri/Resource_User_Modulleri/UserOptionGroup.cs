using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserOptionGroup
    {
        public Guid ObjectId { get; set; }
        public UserOptionType? UserOptionType { get; set; }
        public UserOptionGroupType? UserOptionGroupType { get; set; }
    }
}