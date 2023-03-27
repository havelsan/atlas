
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLAPMenuRole")] 

    public  partial class OLAPMenuRole : BaseOLAPRole
    {
        public class OLAPMenuRoleList : TTObjectCollection<OLAPMenuRole> { }
                    
        public class ChildOLAPMenuRoleCollection : TTObject.TTChildObjectCollection<OLAPMenuRole>
        {
            public ChildOLAPMenuRoleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLAPMenuRoleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// BaseOLAPDefinition
    /// </summary>
        public OLAPMenu OLAPMenu
        {
            get 
            {   
                if (BaseOLAPDefinition is OLAPMenu)
                    return (OLAPMenu)BaseOLAPDefinition; 
                return null;
            }            
            set { BaseOLAPDefinition = value; }
        }

        protected OLAPMenuRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLAPMenuRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLAPMenuRole(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLAPMenuRole(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLAPMenuRole(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAPMENUROLE", dataRow) { }
        protected OLAPMenuRole(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAPMENUROLE", dataRow, isImported) { }
        public OLAPMenuRole(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLAPMenuRole(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLAPMenuRole() : base() { }

    }
}