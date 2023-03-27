
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryParticipantDepartment")] 

    public  partial class SurgeryParticipantDepartment : TTObject
    {
        public class SurgeryParticipantDepartmentList : TTObjectCollection<SurgeryParticipantDepartment> { }
                    
        public class ChildSurgeryParticipantDepartmentCollection : TTObject.TTChildObjectCollection<SurgeryParticipantDepartment>
        {
            public ChildSurgeryParticipantDepartmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryParticipantDepartmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Surgery Surgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("SURGERY"); }
            set { this["SURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResDepartment Department
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ek Ameliyat
    /// </summary>
        public SubSurgery SubSurgery
        {
            get { return (SubSurgery)((ITTObject)this).GetParent("SUBSURGERY"); }
            set { this["SUBSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SurgeryParticipantDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryParticipantDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryParticipantDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryParticipantDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryParticipantDepartment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYPARTICIPANTDEPARTMENT", dataRow) { }
        protected SurgeryParticipantDepartment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYPARTICIPANTDEPARTMENT", dataRow, isImported) { }
        public SurgeryParticipantDepartment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryParticipantDepartment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryParticipantDepartment() : base() { }

    }
}