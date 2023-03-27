
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ImportTestChildClass")] 

    public  partial class ImportTestChildClass : TTObject
    {
        public class ImportTestChildClassList : TTObjectCollection<ImportTestChildClass> { }
                    
        public class ChildImportTestChildClassCollection : TTObject.TTChildObjectCollection<ImportTestChildClass>
        {
            public ChildImportTestChildClassCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildImportTestChildClassCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public ImportTestClass ImportTestClass
        {
            get { return (ImportTestClass)((ITTObject)this).GetParent("IMPORTTESTCLASS"); }
            set { this["IMPORTTESTCLASS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ImportTestChildClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ImportTestChildClass(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ImportTestChildClass(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ImportTestChildClass(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ImportTestChildClass(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IMPORTTESTCHILDCLASS", dataRow) { }
        protected ImportTestChildClass(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IMPORTTESTCHILDCLASS", dataRow, isImported) { }
        public ImportTestChildClass(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ImportTestChildClass(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ImportTestChildClass() : base() { }

    }
}