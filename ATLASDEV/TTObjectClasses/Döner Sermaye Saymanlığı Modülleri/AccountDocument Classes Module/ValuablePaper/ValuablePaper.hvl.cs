
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ValuablePaper")] 

    /// <summary>
    /// Menkul kıymet tipindeki ödemeleri tutar
    /// </summary>
    public  partial class ValuablePaper : Payment
    {
        public class ValuablePaperList : TTObjectCollection<ValuablePaper> { }
                    
        public class ChildValuablePaperCollection : TTObject.TTChildObjectCollection<ValuablePaper>
        {
            public ChildValuablePaperCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildValuablePaperCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ValuablePaper(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ValuablePaper(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ValuablePaper(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ValuablePaper(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ValuablePaper(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VALUABLEPAPER", dataRow) { }
        protected ValuablePaper(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VALUABLEPAPER", dataRow, isImported) { }
        public ValuablePaper(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ValuablePaper(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ValuablePaper() : base() { }

    }
}