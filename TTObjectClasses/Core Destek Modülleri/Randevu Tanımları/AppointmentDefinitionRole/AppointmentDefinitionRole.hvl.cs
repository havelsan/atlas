
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AppointmentDefinitionRole")] 

    public  partial class AppointmentDefinitionRole : TTObject
    {
        public class AppointmentDefinitionRoleList : TTObjectCollection<AppointmentDefinitionRole> { }
                    
        public class ChildAppointmentDefinitionRoleCollection : TTObject.TTChildObjectCollection<AppointmentDefinitionRole>
        {
            public ChildAppointmentDefinitionRoleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAppointmentDefinitionRoleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rol ID
    /// </summary>
        public string RoleID
        {
            get { return (string)this["ROLEID"]; }
            set { this["ROLEID"] = value; }
        }

    /// <summary>
    /// Yetki
    /// </summary>
        public AppointmentRightTypeEnum? RightType
        {
            get { return (AppointmentRightTypeEnum?)(int?)this["RIGHTTYPE"]; }
            set { this["RIGHTTYPE"] = value; }
        }

    /// <summary>
    /// Kafa randevusunu randevu tipine göre yapabilecek roller tanımlanır.
    /// </summary>
        public AppointmentDefinition AppointmentDefinition
        {
            get { return (AppointmentDefinition)((ITTObject)this).GetParent("APPOINTMENTDEFINITION"); }
            set { this["APPOINTMENTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AppointmentDefinitionRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AppointmentDefinitionRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AppointmentDefinitionRole(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AppointmentDefinitionRole(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AppointmentDefinitionRole(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APPOINTMENTDEFINITIONROLE", dataRow) { }
        protected AppointmentDefinitionRole(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APPOINTMENTDEFINITIONROLE", dataRow, isImported) { }
        public AppointmentDefinitionRole(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AppointmentDefinitionRole(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AppointmentDefinitionRole() : base() { }

    }
}