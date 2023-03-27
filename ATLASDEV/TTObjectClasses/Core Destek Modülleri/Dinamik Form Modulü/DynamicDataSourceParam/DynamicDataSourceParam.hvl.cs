
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicDataSourceParam")] 

    public  partial class DynamicDataSourceParam : TTObject
    {
        public class DynamicDataSourceParamList : TTObjectCollection<DynamicDataSourceParam> { }
                    
        public class ChildDynamicDataSourceParamCollection : TTObject.TTChildObjectCollection<DynamicDataSourceParam>
        {
            public ChildDynamicDataSourceParamCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicDataSourceParamCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string ParamKey
        {
            get { return (string)this["PARAMKEY"]; }
            set { this["PARAMKEY"] = value; }
        }

        public DynamicDataSource DynamicDataSource
        {
            get { return (DynamicDataSource)((ITTObject)this).GetParent("DYNAMICDATASOURCE"); }
            set { this["DYNAMICDATASOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DynamicDataSourceParam(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicDataSourceParam(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicDataSourceParam(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicDataSourceParam(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicDataSourceParam(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICDATASOURCEPARAM", dataRow) { }
        protected DynamicDataSourceParam(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICDATASOURCEPARAM", dataRow, isImported) { }
        public DynamicDataSourceParam(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicDataSourceParam(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicDataSourceParam() : base() { }

    }
}