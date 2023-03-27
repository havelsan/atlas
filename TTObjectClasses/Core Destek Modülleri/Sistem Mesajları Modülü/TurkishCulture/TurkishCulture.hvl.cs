
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TurkishCulture")] 

    public  partial class TurkishCulture : BaseCulture
    {
        public class TurkishCultureList : TTObjectCollection<TurkishCulture> { }
                    
        public class ChildTurkishCultureCollection : TTObject.TTChildObjectCollection<TurkishCulture>
        {
            public ChildTurkishCultureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTurkishCultureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected TurkishCulture(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TurkishCulture(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TurkishCulture(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TurkishCulture(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TurkishCulture(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TURKISHCULTURE", dataRow) { }
        protected TurkishCulture(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TURKISHCULTURE", dataRow, isImported) { }
        public TurkishCulture(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TurkishCulture(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TurkishCulture() : base() { }

    }
}