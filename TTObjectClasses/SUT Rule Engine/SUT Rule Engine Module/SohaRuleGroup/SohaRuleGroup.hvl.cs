
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SohaRuleGroup")] 

    /// <summary>
    /// SUT Kural Grubu
    /// </summary>
    public  partial class SohaRuleGroup : TTObject
    {
        public class SohaRuleGroupList : TTObjectCollection<SohaRuleGroup> { }
                    
        public class ChildSohaRuleGroupCollection : TTObject.TTChildObjectCollection<SohaRuleGroup>
        {
            public ChildSohaRuleGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSohaRuleGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kural Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kural Grup Tipi
    /// </summary>
        public SohaRuleGroupEnum? RuleGroupType
        {
            get { return (SohaRuleGroupEnum?)(int?)this["RULEGROUPTYPE"]; }
            set { this["RULEGROUPTYPE"] = value; }
        }

        protected SohaRuleGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SohaRuleGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SohaRuleGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SohaRuleGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SohaRuleGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOHARULEGROUP", dataRow) { }
        protected SohaRuleGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOHARULEGROUP", dataRow, isImported) { }
        public SohaRuleGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SohaRuleGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SohaRuleGroup() : base() { }

    }
}