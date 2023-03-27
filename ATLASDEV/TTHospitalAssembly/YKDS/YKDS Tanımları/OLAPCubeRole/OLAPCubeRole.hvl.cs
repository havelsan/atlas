
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLAPCubeRole")] 

    public  partial class OLAPCubeRole : BaseOLAPRole
    {
        public class OLAPCubeRoleList : TTObjectCollection<OLAPCubeRole> { }
                    
        public class ChildOLAPCubeRoleCollection : TTObject.TTChildObjectCollection<OLAPCubeRole>
        {
            public ChildOLAPCubeRoleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLAPCubeRoleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// BaseOLAPDefinition
    /// </summary>
        public OLAPCube OLAPCube
        {
            get 
            {   
                if (BaseOLAPDefinition is OLAPCube)
                    return (OLAPCube)BaseOLAPDefinition; 
                return null;
            }            
            set { BaseOLAPDefinition = value; }
        }

        protected OLAPCubeRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLAPCubeRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLAPCubeRole(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLAPCubeRole(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLAPCubeRole(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAPCUBEROLE", dataRow) { }
        protected OLAPCubeRole(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAPCUBEROLE", dataRow, isImported) { }
        public OLAPCubeRole(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLAPCubeRole(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLAPCubeRole() : base() { }

    }
}