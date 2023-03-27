using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class UserOption
    {
        public Guid ObjectId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public Guid? OptionValue { get; set; }
        public QuestionTypeEnum? QuestionType { get; set; }
        public UserOptionType? OptionType { get; set; }
        public Guid? ResUserRef { get; set; }

        #region Parent Relations
        public virtual ResUser ResUser { get; set; }
        #endregion Parent Relations
    }
}