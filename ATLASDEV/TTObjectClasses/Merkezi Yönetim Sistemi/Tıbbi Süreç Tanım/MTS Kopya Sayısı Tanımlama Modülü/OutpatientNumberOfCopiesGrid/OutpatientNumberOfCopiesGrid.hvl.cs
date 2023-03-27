
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OutpatientNumberOfCopiesGrid")] 

    /// <summary>
    /// Ayaktan Kopya Sayıları
    /// </summary>
    public  partial class OutpatientNumberOfCopiesGrid : NumberOfCopiesGrid
    {
        public class OutpatientNumberOfCopiesGridList : TTObjectCollection<OutpatientNumberOfCopiesGrid> { }
                    
        public class ChildOutpatientNumberOfCopiesGridCollection : TTObject.TTChildObjectCollection<OutpatientNumberOfCopiesGrid>
        {
            public ChildOutpatientNumberOfCopiesGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOutpatientNumberOfCopiesGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected OutpatientNumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OutpatientNumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OutpatientNumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OutpatientNumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OutpatientNumberOfCopiesGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OUTPATIENTNUMBEROFCOPIESGRID", dataRow) { }
        protected OutpatientNumberOfCopiesGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OUTPATIENTNUMBEROFCOPIESGRID", dataRow, isImported) { }
        public OutpatientNumberOfCopiesGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OutpatientNumberOfCopiesGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OutpatientNumberOfCopiesGrid() : base() { }

    }
}