
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChildGrowthStandards")] 

    /// <summary>
    /// Çocuk Gelişim Standartları
    /// </summary>
    public  partial class ChildGrowthStandards : SpecialityBasedObject
    {
        public class ChildGrowthStandardsList : TTObjectCollection<ChildGrowthStandards> { }
                    
        public class ChildChildGrowthStandardsCollection : TTObject.TTChildObjectCollection<ChildGrowthStandards>
        {
            public ChildChildGrowthStandardsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChildGrowthStandardsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PatientExamination PatientExamination
        {
            get { return (PatientExamination)((ITTObject)this).GetParent("PATIENTEXAMINATION"); }
            set { this["PATIENTEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ChildGrowthStandards(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChildGrowthStandards(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChildGrowthStandards(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChildGrowthStandards(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChildGrowthStandards(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHILDGROWTHSTANDARDS", dataRow) { }
        protected ChildGrowthStandards(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHILDGROWTHSTANDARDS", dataRow, isImported) { }
        public ChildGrowthStandards(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChildGrowthStandards(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChildGrowthStandards() : base() { }

    }
}