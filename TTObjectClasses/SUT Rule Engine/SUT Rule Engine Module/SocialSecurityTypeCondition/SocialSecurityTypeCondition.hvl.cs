
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SocialSecurityTypeCondition")] 

    public  partial class SocialSecurityTypeCondition : RuleConditionBase
    {
        public class SocialSecurityTypeConditionList : TTObjectCollection<SocialSecurityTypeCondition> { }
                    
        public class ChildSocialSecurityTypeConditionCollection : TTObject.TTChildObjectCollection<SocialSecurityTypeCondition>
        {
            public ChildSocialSecurityTypeConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSocialSecurityTypeConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kurumu
    /// </summary>
        public DevredilenKurum SocialSecurityType
        {
            get { return (DevredilenKurum)((ITTObject)this).GetParent("SOCIALSECURITYTYPE"); }
            set { this["SOCIALSECURITYTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SocialSecurityTypeCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SocialSecurityTypeCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SocialSecurityTypeCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SocialSecurityTypeCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SocialSecurityTypeCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOCIALSECURITYTYPECONDITION", dataRow) { }
        protected SocialSecurityTypeCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOCIALSECURITYTYPECONDITION", dataRow, isImported) { }
        public SocialSecurityTypeCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SocialSecurityTypeCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SocialSecurityTypeCondition() : base() { }

    }
}