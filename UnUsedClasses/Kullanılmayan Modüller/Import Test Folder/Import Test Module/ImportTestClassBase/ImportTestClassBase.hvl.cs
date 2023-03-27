
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ImportTestClassBase")] 

    public  partial class ImportTestClassBase : TTObject
    {
        public class ImportTestClassBaseList : TTObjectCollection<ImportTestClassBase> { }
                    
        public class ChildImportTestClassBaseCollection : TTObject.TTChildObjectCollection<ImportTestClassBase>
        {
            public ChildImportTestClassBaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildImportTestClassBaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ImportTestClassBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ImportTestClassBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ImportTestClassBase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ImportTestClassBase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ImportTestClassBase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IMPORTTESTCLASSBASE", dataRow) { }
        protected ImportTestClassBase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IMPORTTESTCLASSBASE", dataRow, isImported) { }
        public ImportTestClassBase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ImportTestClassBase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ImportTestClassBase() : base() { }

    }
}