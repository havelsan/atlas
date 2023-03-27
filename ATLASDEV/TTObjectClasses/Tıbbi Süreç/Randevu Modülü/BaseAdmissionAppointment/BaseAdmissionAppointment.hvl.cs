
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseAdmissionAppointment")] 

    public  partial class BaseAdmissionAppointment : BaseAction, IWorkListAppointment
    {
        public class BaseAdmissionAppointmentList : TTObjectCollection<BaseAdmissionAppointment> { }
                    
        public class ChildBaseAdmissionAppointmentCollection : TTObject.TTChildObjectCollection<BaseAdmissionAppointment>
        {
            public ChildBaseAdmissionAppointmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseAdmissionAppointmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlemi Başlatan Birimin Tutulduğu Alan
    /// </summary>
        public ResSection FromResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("FROMRESOURCE"); }
            set { this["FROMRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource MasterResource
        {
            get { return (Resource)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public Patient SelectedPatient
        {
            get { return (Patient)((ITTObject)this).GetParent("SELECTEDPATIENT"); }
            set { this["SELECTEDPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Randevu Türü
    /// </summary>
        public AppointmentDefinition AppointmentDefinition
        {
            get { return (AppointmentDefinition)((ITTObject)this).GetParent("APPOINTMENTDEFINITION"); }
            set { this["APPOINTMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseAdmissionAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseAdmissionAppointment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseAdmissionAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseAdmissionAppointment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseAdmissionAppointment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEADMISSIONAPPOINTMENT", dataRow) { }
        protected BaseAdmissionAppointment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEADMISSIONAPPOINTMENT", dataRow, isImported) { }
        public BaseAdmissionAppointment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseAdmissionAppointment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseAdmissionAppointment() : base() { }

    }
}