
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalResarchProcedur")] 

    public  partial class MedicalResarchProcedur : TTObject
    {
        public class MedicalResarchProcedurList : TTObjectCollection<MedicalResarchProcedur> { }
                    
        public class ChildMedicalResarchProcedurCollection : TTObject.TTChildObjectCollection<MedicalResarchProcedur>
        {
            public ChildMedicalResarchProcedurCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalResarchProcedurCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalResarch MedicalResarch
        {
            get { return (MedicalResarch)((ITTObject)this).GetParent("MEDICALRESARCH"); }
            set { this["MEDICALRESARCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalResarchProcedur(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalResarchProcedur(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalResarchProcedur(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalResarchProcedur(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalResarchProcedur(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALRESARCHPROCEDUR", dataRow) { }
        protected MedicalResarchProcedur(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALRESARCHPROCEDUR", dataRow, isImported) { }
        public MedicalResarchProcedur(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalResarchProcedur(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalResarchProcedur() : base() { }

    }
}