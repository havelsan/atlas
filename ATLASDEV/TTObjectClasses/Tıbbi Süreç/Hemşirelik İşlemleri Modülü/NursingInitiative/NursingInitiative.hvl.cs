
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingInitiative")] 

    public  partial class NursingInitiative : TTObject
    {
        public class NursingInitiativeList : TTObjectCollection<NursingInitiative> { }
                    
        public class ChildNursingInitiativeCollection : TTObject.TTChildObjectCollection<NursingInitiative>
        {
            public ChildNursingInitiativeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingInitiativeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public NursingInitiativeDefinition NursingInitiatives
        {
            get { return (NursingInitiativeDefinition)((ITTObject)this).GetParent("NURSINGINITIATIVES"); }
            set { this["NURSINGINITIATIVES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingPainScale NursingPainScale
        {
            get { return (NursingPainScale)((ITTObject)this).GetParent("NURSINGPAINSCALE"); }
            set { this["NURSINGPAINSCALE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingInitiative(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingInitiative(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingInitiative(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingInitiative(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingInitiative(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGINITIATIVE", dataRow) { }
        protected NursingInitiative(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGINITIATIVE", dataRow, isImported) { }
        public NursingInitiative(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingInitiative(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingInitiative() : base() { }

    }
}