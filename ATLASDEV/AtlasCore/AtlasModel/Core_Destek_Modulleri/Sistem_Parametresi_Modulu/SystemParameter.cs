using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SystemParameter
    {
        public Guid ObjectId { get; set; }
        public string Value { get; set; }
        public SystemParameterSubTypeEnum? SubType { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool? IsEncrypted { get; set; }
        public int? CacheDurationInMinutes { get; set; }

        #region Base Object Navigation Property
        public virtual TerminologyManagerDef TerminologyManagerDef { get; set; }
        #endregion Base Object Navigation Property
    }
}