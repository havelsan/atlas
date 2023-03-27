
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryBranchDefinition")] 

    public  partial class SurgeryBranchDefinition : TTDefinitionSet
    {
        public class SurgeryBranchDefinitionList : TTObjectCollection<SurgeryBranchDefinition> { }
                    
        public class ChildSurgeryBranchDefinitionCollection : TTObject.TTChildObjectCollection<SurgeryBranchDefinition>
        {
            public ChildSurgeryBranchDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryBranchDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ameliyat Branş İlişkisi
    /// </summary>
        public SurgeryDefinition Surgery
        {
            get { return (SurgeryDefinition)((ITTObject)this).GetParent("SURGERY"); }
            set { this["SURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Branş Listesi
    /// </summary>
        public SpecialityDefinition SpecialityDefinition
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITYDEFINITION"); }
            set { this["SPECIALITYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SurgeryBranchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryBranchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryBranchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryBranchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryBranchDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYBRANCHDEFINITION", dataRow) { }
        protected SurgeryBranchDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYBRANCHDEFINITION", dataRow, isImported) { }
        public SurgeryBranchDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryBranchDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryBranchDefinition() : base() { }

    }
}