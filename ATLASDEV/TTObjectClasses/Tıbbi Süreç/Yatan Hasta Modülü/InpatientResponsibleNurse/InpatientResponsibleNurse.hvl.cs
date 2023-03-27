
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientResponsibleNurse")] 

    /// <summary>
    /// Yatan Hasta İşlemleri Hemşireler Sekmesi
    /// </summary>
    public  partial class InpatientResponsibleNurse : TTObject
    {
        public class InpatientResponsibleNurseList : TTObjectCollection<InpatientResponsibleNurse> { }
                    
        public class ChildInpatientResponsibleNurseCollection : TTObject.TTChildObjectCollection<InpatientResponsibleNurse>
        {
            public ChildInpatientResponsibleNurseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientResponsibleNurseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DateTime? SDateTime
        {
            get { return (DateTime?)this["SDATETIME"]; }
            set { this["SDATETIME"] = value; }
        }

        public ResUser Nurse
        {
            get { return (ResUser)((ITTObject)this).GetParent("NURSE"); }
            set { this["NURSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication InPatientTreatmentClinicApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("INPATIENTTREATMENTCLINICAPP"); }
            set { this["INPATIENTTREATMENTCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientResponsibleNurse(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientResponsibleNurse(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientResponsibleNurse(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientResponsibleNurse(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientResponsibleNurse(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTRESPONSIBLENURSE", dataRow) { }
        protected InpatientResponsibleNurse(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTRESPONSIBLENURSE", dataRow, isImported) { }
        public InpatientResponsibleNurse(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientResponsibleNurse(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientResponsibleNurse() : base() { }

    }
}