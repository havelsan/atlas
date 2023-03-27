
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLAPQueryRole")] 

    public  partial class OLAPQueryRole : BaseOLAPRole
    {
        public class OLAPQueryRoleList : TTObjectCollection<OLAPQueryRole> { }
                    
        public class ChildOLAPQueryRoleCollection : TTObject.TTChildObjectCollection<OLAPQueryRole>
        {
            public ChildOLAPQueryRoleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLAPQueryRoleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// BaseOLAPDefinition
    /// </summary>
        public OLAPQuery OLAPQuery
        {
            get 
            {   
                if (BaseOLAPDefinition is OLAPQuery)
                    return (OLAPQuery)BaseOLAPDefinition; 
                return null;
            }            
            set { BaseOLAPDefinition = value; }
        }

        protected OLAPQueryRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLAPQueryRole(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLAPQueryRole(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLAPQueryRole(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLAPQueryRole(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAPQUERYROLE", dataRow) { }
        protected OLAPQueryRole(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAPQUERYROLE", dataRow, isImported) { }
        public OLAPQueryRole(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLAPQueryRole(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLAPQueryRole() : base() { }

    }
}