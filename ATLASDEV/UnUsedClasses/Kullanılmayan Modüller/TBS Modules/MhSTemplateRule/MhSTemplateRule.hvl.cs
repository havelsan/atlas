
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSTemplateRule")] 

    public  partial class MhSTemplateRule : TTObject
    {
        public class MhSTemplateRuleList : TTObjectCollection<MhSTemplateRule> { }
                    
        public class ChildMhSTemplateRuleCollection : TTObject.TTChildObjectCollection<MhSTemplateRule>
        {
            public ChildMhSTemplateRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSTemplateRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Validation
    /// </summary>
        public string ValidationRule
        {
            get { return (string)this["VALIDATIONRULE"]; }
            set { this["VALIDATIONRULE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kurallar
    /// </summary>
        public MhSTemplate Template
        {
            get { return (MhSTemplate)((ITTObject)this).GetParent("TEMPLATE"); }
            set { this["TEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSTemplateRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSTemplateRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSTemplateRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSTemplateRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSTemplateRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSTEMPLATERULE", dataRow) { }
        protected MhSTemplateRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSTEMPLATERULE", dataRow, isImported) { }
        public MhSTemplateRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSTemplateRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSTemplateRule() : base() { }

    }
}