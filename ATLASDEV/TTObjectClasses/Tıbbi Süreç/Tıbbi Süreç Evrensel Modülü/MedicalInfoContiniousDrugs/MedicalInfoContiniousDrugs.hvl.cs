
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalInfoContiniousDrugs")] 

    public  partial class MedicalInfoContiniousDrugs : TTObject
    {
        public class MedicalInfoContiniousDrugsList : TTObjectCollection<MedicalInfoContiniousDrugs> { }
                    
        public class ChildMedicalInfoContiniousDrugsCollection : TTObject.TTChildObjectCollection<MedicalInfoContiniousDrugs>
        {
            public ChildMedicalInfoContiniousDrugsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalInfoContiniousDrugsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DrugDefinition Drug
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUG"); }
            set { this["DRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalInformation MedicalInformation
        {
            get { return (MedicalInformation)((ITTObject)this).GetParent("MEDICALINFORMATION"); }
            set { this["MEDICALINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalInfoContiniousDrugs(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalInfoContiniousDrugs(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalInfoContiniousDrugs(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalInfoContiniousDrugs(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalInfoContiniousDrugs(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALINFOCONTINIOUSDRUGS", dataRow) { }
        protected MedicalInfoContiniousDrugs(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALINFOCONTINIOUSDRUGS", dataRow, isImported) { }
        public MedicalInfoContiniousDrugs(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalInfoContiniousDrugs(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalInfoContiniousDrugs() : base() { }

    }
}