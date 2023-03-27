
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryCodelessMaterial")] 

    public  partial class SurgeryCodelessMaterial : TerminologyManagerDef
    {
        public class SurgeryCodelessMaterialList : TTObjectCollection<SurgeryCodelessMaterial> { }
                    
        public class ChildSurgeryCodelessMaterialCollection : TTObject.TTChildObjectCollection<SurgeryCodelessMaterial>
        {
            public ChildSurgeryCodelessMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryCodelessMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DPA22FCodelessMaterialDef DPA22FCodelessMaterialDef
        {
            get { return (DPA22FCodelessMaterialDef)((ITTObject)this).GetParent("DPA22FCODELESSMATERIALDEF"); }
            set { this["DPA22FCODELESSMATERIALDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SurgeryDefinition SurgeryDefinition
        {
            get { return (SurgeryDefinition)((ITTObject)this).GetParent("SURGERYDEFINITION"); }
            set { this["SURGERYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SurgeryCodelessMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryCodelessMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryCodelessMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryCodelessMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryCodelessMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYCODELESSMATERIAL", dataRow) { }
        protected SurgeryCodelessMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYCODELESSMATERIAL", dataRow, isImported) { }
        public SurgeryCodelessMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryCodelessMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryCodelessMaterial() : base() { }

    }
}