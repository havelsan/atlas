
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ImportTestParent")] 

    public  partial class ImportTestParent : TTObject
    {
        public class ImportTestParentList : TTObjectCollection<ImportTestParent> { }
                    
        public class ChildImportTestParentCollection : TTObject.TTChildObjectCollection<ImportTestParent>
        {
            public ChildImportTestParentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildImportTestParentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ImportTestParent> ImportTestParentQuery(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IMPORTTESTPARENT"].QueryDefs["ImportTestParentQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ImportTestParent>(queryDef, paramList, injectionSQL);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected ImportTestParent(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ImportTestParent(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ImportTestParent(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ImportTestParent(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ImportTestParent(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IMPORTTESTPARENT", dataRow) { }
        protected ImportTestParent(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IMPORTTESTPARENT", dataRow, isImported) { }
        public ImportTestParent(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ImportTestParent(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ImportTestParent() : base() { }

    }
}