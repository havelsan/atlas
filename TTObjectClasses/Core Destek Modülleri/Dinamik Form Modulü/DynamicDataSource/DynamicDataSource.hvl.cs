
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DynamicDataSource")] 

    public  partial class DynamicDataSource : TTObject
    {
        public class DynamicDataSourceList : TTObjectCollection<DynamicDataSource> { }
                    
        public class ChildDynamicDataSourceCollection : TTObject.TTChildObjectCollection<DynamicDataSource>
        {
            public ChildDynamicDataSourceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDynamicDataSourceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public string ApiConfig
        {
            get { return (string)this["APICONFIG"]; }
            set { this["APICONFIG"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public bool? IsActive
        {
            get { return (bool?)this["ISACTIVE"]; }
            set { this["ISACTIVE"] = value; }
        }

        protected DynamicDataSource(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DynamicDataSource(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DynamicDataSource(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DynamicDataSource(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DynamicDataSource(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DYNAMICDATASOURCE", dataRow) { }
        protected DynamicDataSource(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DYNAMICDATASOURCE", dataRow, isImported) { }
        public DynamicDataSource(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DynamicDataSource(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DynamicDataSource() : base() { }

    }
}