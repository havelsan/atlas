
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PGReasonForAdmissionGrid")] 

    public  partial class PGReasonForAdmissionGrid : TerminologyManagerDef
    {
        public class PGReasonForAdmissionGridList : TTObjectCollection<PGReasonForAdmissionGrid> { }
                    
        public class ChildPGReasonForAdmissionGridCollection : TTObject.TTChildObjectCollection<PGReasonForAdmissionGrid>
        {
            public ChildPGReasonForAdmissionGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPGReasonForAdmissionGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kabul Sebebleri
    /// </summary>
        public AdmissionTypeEnum? ReasonForAdmissionEnum
        {
            get { return (AdmissionTypeEnum?)(int?)this["REASONFORADMISSIONENUM"]; }
            set { this["REASONFORADMISSIONENUM"] = value; }
        }

    /// <summary>
    /// Hasta Grubu-Kabul Sebepleri
    /// </summary>
        public PatientGroupDefinition PatientGroupDefinition
        {
            get { return (PatientGroupDefinition)((ITTObject)this).GetParent("PATIENTGROUPDEFINITION"); }
            set { this["PATIENTGROUPDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PGReasonForAdmissionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PGReasonForAdmissionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PGReasonForAdmissionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PGReasonForAdmissionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PGReasonForAdmissionGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PGREASONFORADMISSIONGRID", dataRow) { }
        protected PGReasonForAdmissionGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PGREASONFORADMISSIONGRID", dataRow, isImported) { }
        public PGReasonForAdmissionGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PGReasonForAdmissionGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PGReasonForAdmissionGrid() : base() { }

    }
}