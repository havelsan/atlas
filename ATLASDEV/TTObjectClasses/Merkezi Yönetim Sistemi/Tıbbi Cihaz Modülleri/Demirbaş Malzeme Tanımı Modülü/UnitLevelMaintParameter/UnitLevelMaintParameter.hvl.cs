
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnitLevelMaintParameter")] 

    public  partial class UnitLevelMaintParameter : TerminologyManagerDef
    {
        public class UnitLevelMaintParameterList : TTObjectCollection<UnitLevelMaintParameter> { }
                    
        public class ChildUnitLevelMaintParameterCollection : TTObject.TTChildObjectCollection<UnitLevelMaintParameter>
        {
            public ChildUnitLevelMaintParameterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnitLevelMaintParameterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MaintenanceParameterDefinition UnitParameter
        {
            get { return (MaintenanceParameterDefinition)((ITTObject)this).GetParent("UNITPARAMETER"); }
            set { this["UNITPARAMETER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UnitLevelMaintParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnitLevelMaintParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnitLevelMaintParameter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnitLevelMaintParameter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnitLevelMaintParameter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNITLEVELMAINTPARAMETER", dataRow) { }
        protected UnitLevelMaintParameter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNITLEVELMAINTPARAMETER", dataRow, isImported) { }
        public UnitLevelMaintParameter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnitLevelMaintParameter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnitLevelMaintParameter() : base() { }

    }
}