
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MatchUserParameter")] 

    public  partial class MatchUserParameter : TTObject
    {
        public class MatchUserParameterList : TTObjectCollection<MatchUserParameter> { }
                    
        public class ChildMatchUserParameterCollection : TTObject.TTChildObjectCollection<MatchUserParameter>
        {
            public ChildMatchUserParameterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMatchUserParameterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public FixedAssetParameterMatch FixedAssetParameterMatch
        {
            get { return (FixedAssetParameterMatch)((ITTObject)this).GetParent("FIXEDASSETPARAMETERMATCH"); }
            set { this["FIXEDASSETPARAMETERMATCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceParameterDefinition UserParameter
        {
            get { return (MaintenanceParameterDefinition)((ITTObject)this).GetParent("USERPARAMETER"); }
            set { this["USERPARAMETER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MatchUserParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MatchUserParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MatchUserParameter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MatchUserParameter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MatchUserParameter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATCHUSERPARAMETER", dataRow) { }
        protected MatchUserParameter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATCHUSERPARAMETER", dataRow, isImported) { }
        public MatchUserParameter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MatchUserParameter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MatchUserParameter() : base() { }

    }
}