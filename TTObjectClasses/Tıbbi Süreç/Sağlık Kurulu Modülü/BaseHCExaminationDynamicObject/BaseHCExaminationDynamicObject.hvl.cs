
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseHCExaminationDynamicObject")] 

    /// <summary>
    /// Sağlık Kurulu Dinamik Ek Alanlar
    /// </summary>
    public  partial class BaseHCExaminationDynamicObject : TTObject
    {
        public class BaseHCExaminationDynamicObjectList : TTObjectCollection<BaseHCExaminationDynamicObject> { }
                    
        public class ChildBaseHCExaminationDynamicObjectCollection : TTObject.TTChildObjectCollection<BaseHCExaminationDynamicObject>
        {
            public ChildBaseHCExaminationDynamicObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseHCExaminationDynamicObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PatientExamination PatientExamination
        {
            get { return (PatientExamination)((ITTObject)this).GetParent("PATIENTEXAMINATION"); }
            set { this["PATIENTEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseHCExaminationDynamicObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseHCExaminationDynamicObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseHCExaminationDynamicObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseHCExaminationDynamicObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseHCExaminationDynamicObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEHCEXAMINATIONDYNAMICOBJECT", dataRow) { }
        protected BaseHCExaminationDynamicObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEHCEXAMINATIONDYNAMICOBJECT", dataRow, isImported) { }
        public BaseHCExaminationDynamicObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseHCExaminationDynamicObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseHCExaminationDynamicObject() : base() { }

    }
}