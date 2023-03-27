
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalConsultationDepartment")] 

    public  partial class DentalConsultationDepartment : TTObject
    {
        public class DentalConsultationDepartmentList : TTObjectCollection<DentalConsultationDepartment> { }
                    
        public class ChildDentalConsultationDepartmentCollection : TTObject.TTChildObjectCollection<DentalConsultationDepartment>
        {
            public ChildDentalConsultationDepartmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalConsultationDepartmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalConsultationRequest DentalConsultationRequest
        {
            get { return (DentalConsultationRequest)((ITTObject)this).GetParent("DENTALCONSULTATIONREQUEST"); }
            set { this["DENTALCONSULTATIONREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalConsultationDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalConsultationDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalConsultationDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalConsultationDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalConsultationDepartment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALCONSULTATIONDEPARTMENT", dataRow) { }
        protected DentalConsultationDepartment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALCONSULTATIONDEPARTMENT", dataRow, isImported) { }
        public DentalConsultationDepartment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalConsultationDepartment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalConsultationDepartment() : base() { }

    }
}