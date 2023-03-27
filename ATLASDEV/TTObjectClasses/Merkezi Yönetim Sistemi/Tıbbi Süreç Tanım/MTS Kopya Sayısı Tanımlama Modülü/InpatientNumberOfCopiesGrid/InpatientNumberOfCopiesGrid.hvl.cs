
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientNumberOfCopiesGrid")] 

    /// <summary>
    /// Yatan Kopya Sayıları
    /// </summary>
    public  partial class InpatientNumberOfCopiesGrid : NumberOfCopiesGrid
    {
        public class InpatientNumberOfCopiesGridList : TTObjectCollection<InpatientNumberOfCopiesGrid> { }
                    
        public class ChildInpatientNumberOfCopiesGridCollection : TTObject.TTChildObjectCollection<InpatientNumberOfCopiesGrid>
        {
            public ChildInpatientNumberOfCopiesGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientNumberOfCopiesGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected InpatientNumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientNumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientNumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientNumberOfCopiesGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientNumberOfCopiesGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTNUMBEROFCOPIESGRID", dataRow) { }
        protected InpatientNumberOfCopiesGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTNUMBEROFCOPIESGRID", dataRow, isImported) { }
        protected InpatientNumberOfCopiesGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientNumberOfCopiesGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientNumberOfCopiesGrid() : base() { }

    }
}