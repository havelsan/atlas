
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MatchUnitParameter")] 

    public  partial class MatchUnitParameter : TTObject
    {
        public class MatchUnitParameterList : TTObjectCollection<MatchUnitParameter> { }
                    
        public class ChildMatchUnitParameterCollection : TTObject.TTChildObjectCollection<MatchUnitParameter>
        {
            public ChildMatchUnitParameterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMatchUnitParameterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public FixedAssetParameterMatch FixedAssetParameterMatch
        {
            get { return (FixedAssetParameterMatch)((ITTObject)this).GetParent("FIXEDASSETPARAMETERMATCH"); }
            set { this["FIXEDASSETPARAMETERMATCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceParameterDefinition UnitParameter
        {
            get { return (MaintenanceParameterDefinition)((ITTObject)this).GetParent("UNITPARAMETER"); }
            set { this["UNITPARAMETER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MatchUnitParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MatchUnitParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MatchUnitParameter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MatchUnitParameter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MatchUnitParameter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATCHUNITPARAMETER", dataRow) { }
        protected MatchUnitParameter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATCHUNITPARAMETER", dataRow, isImported) { }
        public MatchUnitParameter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MatchUnitParameter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MatchUnitParameter() : base() { }

    }
}