
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryAppointmentProc")] 

    /// <summary>
    /// Ameliyat Randevusu Hizmetleri
    /// </summary>
    public  partial class SurgeryAppointmentProc : TTObject
    {
        public class SurgeryAppointmentProcList : TTObjectCollection<SurgeryAppointmentProc> { }
                    
        public class ChildSurgeryAppointmentProcCollection : TTObject.TTChildObjectCollection<SurgeryAppointmentProc>
        {
            public ChildSurgeryAppointmentProcCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryAppointmentProcCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SurgeryAppointment SurgeryAppointment
        {
            get { return (SurgeryAppointment)((ITTObject)this).GetParent("SURGERYAPPOINTMENT"); }
            set { this["SURGERYAPPOINTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SurgeryAppointmentProc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryAppointmentProc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryAppointmentProc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryAppointmentProc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryAppointmentProc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYAPPOINTMENTPROC", dataRow) { }
        protected SurgeryAppointmentProc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYAPPOINTMENTPROC", dataRow, isImported) { }
        public SurgeryAppointmentProc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryAppointmentProc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryAppointmentProc() : base() { }

    }
}