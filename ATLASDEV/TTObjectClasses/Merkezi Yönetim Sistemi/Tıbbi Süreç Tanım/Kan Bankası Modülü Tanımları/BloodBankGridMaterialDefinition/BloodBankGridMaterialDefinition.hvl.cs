
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BloodBankGridMaterialDefinition")] 

    public  partial class BloodBankGridMaterialDefinition : TTDefinitionSet
    {
        public class BloodBankGridMaterialDefinitionList : TTObjectCollection<BloodBankGridMaterialDefinition> { }
                    
        public class ChildBloodBankGridMaterialDefinitionCollection : TTObject.TTChildObjectCollection<BloodBankGridMaterialDefinition>
        {
            public ChildBloodBankGridMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBloodBankGridMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kan Bnakası Test Tanım İlişkisi
    /// </summary>
        public BloodBankTestDefinition BloodBankTestDefinition
        {
            get { return (BloodBankTestDefinition)((ITTObject)this).GetParent("BLOODBANKTESTDEFINITION"); }
            set { this["BLOODBANKTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Malzeme İlişkisi
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BloodBankGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BloodBankGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BloodBankGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BloodBankGridMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BloodBankGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BLOODBANKGRIDMATERIALDEFINITION", dataRow) { }
        protected BloodBankGridMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BLOODBANKGRIDMATERIALDEFINITION", dataRow, isImported) { }
        public BloodBankGridMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BloodBankGridMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BloodBankGridMaterialDefinition() : base() { }

    }
}