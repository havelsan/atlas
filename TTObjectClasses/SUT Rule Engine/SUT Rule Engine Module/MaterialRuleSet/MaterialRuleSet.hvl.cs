
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialRuleSet")] 

    public  partial class MaterialRuleSet : TTObject
    {
        public class MaterialRuleSetList : TTObjectCollection<MaterialRuleSet> { }
                    
        public class ChildMaterialRuleSetCollection : TTObject.TTChildObjectCollection<MaterialRuleSet>
        {
            public ChildMaterialRuleSetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialRuleSetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Malzeme-Malzeme Kural Setleri
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Seti-Malzeme Kural Setleri
    /// </summary>
        public RuleSet RuleSet
        {
            get { return (RuleSet)((ITTObject)this).GetParent("RULESET"); }
            set { this["RULESET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialRuleSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialRuleSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialRuleSet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialRuleSet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialRuleSet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALRULESET", dataRow) { }
        protected MaterialRuleSet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALRULESET", dataRow, isImported) { }
        public MaterialRuleSet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialRuleSet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialRuleSet() : base() { }

    }
}