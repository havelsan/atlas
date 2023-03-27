
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResLaboratoryDepartment")] 

    /// <summary>
    /// Laboratuvar Bölümü
    /// </summary>
    public  partial class ResLaboratoryDepartment : ResObservationUnit
    {
        public class ResLaboratoryDepartmentList : TTObjectCollection<ResLaboratoryDepartment> { }
                    
        public class ChildResLaboratoryDepartmentCollection : TTObject.TTChildObjectCollection<ResLaboratoryDepartment>
        {
            public ChildResLaboratoryDepartmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResLaboratoryDepartmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MenuDefinition MenuDefinition
        {
            get { return (MenuDefinition)((ITTObject)this).GetParent("MENUDEFINITION"); }
            set { this["MENUDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResLaboratoryDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResLaboratoryDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResLaboratoryDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResLaboratoryDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResLaboratoryDepartment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESLABORATORYDEPARTMENT", dataRow) { }
        protected ResLaboratoryDepartment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESLABORATORYDEPARTMENT", dataRow, isImported) { }
        public ResLaboratoryDepartment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResLaboratoryDepartment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResLaboratoryDepartment() : base() { }

    }
}