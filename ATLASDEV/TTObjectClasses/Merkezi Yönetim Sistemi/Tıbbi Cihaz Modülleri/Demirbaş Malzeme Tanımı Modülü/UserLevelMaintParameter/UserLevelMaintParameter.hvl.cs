
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UserLevelMaintParameter")] 

    public  partial class UserLevelMaintParameter : TerminologyManagerDef
    {
        public class UserLevelMaintParameterList : TTObjectCollection<UserLevelMaintParameter> { }
                    
        public class ChildUserLevelMaintParameterCollection : TTObject.TTChildObjectCollection<UserLevelMaintParameter>
        {
            public ChildUserLevelMaintParameterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUserLevelMaintParameterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MaintenanceParameterDefinition UserParameter
        {
            get { return (MaintenanceParameterDefinition)((ITTObject)this).GetParent("USERPARAMETER"); }
            set { this["USERPARAMETER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UserLevelMaintParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UserLevelMaintParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UserLevelMaintParameter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UserLevelMaintParameter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UserLevelMaintParameter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USERLEVELMAINTPARAMETER", dataRow) { }
        protected UserLevelMaintParameter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USERLEVELMAINTPARAMETER", dataRow, isImported) { }
        public UserLevelMaintParameter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UserLevelMaintParameter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UserLevelMaintParameter() : base() { }

    }
}