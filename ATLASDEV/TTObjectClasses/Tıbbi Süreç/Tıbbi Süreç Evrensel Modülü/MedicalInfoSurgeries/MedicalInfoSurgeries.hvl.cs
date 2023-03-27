
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalInfoSurgeries")] 

    public  partial class MedicalInfoSurgeries : TTObject
    {
        public class MedicalInfoSurgeriesList : TTObjectCollection<MedicalInfoSurgeries> { }
                    
        public class ChildMedicalInfoSurgeriesCollection : TTObject.TTChildObjectCollection<MedicalInfoSurgeries>
        {
            public ChildMedicalInfoSurgeriesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalInfoSurgeriesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SurgeryDefinition SurgeryDefinition
        {
            get { return (SurgeryDefinition)((ITTObject)this).GetParent("SURGERYDEFINITION"); }
            set { this["SURGERYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MedicalInformation MedicalInformation
        {
            get { return (MedicalInformation)((ITTObject)this).GetParent("MEDICALINFORMATION"); }
            set { this["MEDICALINFORMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalInfoSurgeries(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalInfoSurgeries(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalInfoSurgeries(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalInfoSurgeries(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalInfoSurgeries(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALINFOSURGERIES", dataRow) { }
        protected MedicalInfoSurgeries(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALINFOSURGERIES", dataRow, isImported) { }
        public MedicalInfoSurgeries(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalInfoSurgeries(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalInfoSurgeries() : base() { }

    }
}