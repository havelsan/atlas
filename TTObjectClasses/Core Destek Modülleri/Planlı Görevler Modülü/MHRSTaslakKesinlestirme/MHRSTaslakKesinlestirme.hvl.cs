
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSTaslakKesinlestirme")] 

    public  partial class MHRSTaslakKesinlestirme : BaseScheduledTask
    {
        public class MHRSTaslakKesinlestirmeList : TTObjectCollection<MHRSTaslakKesinlestirme> { }
                    
        public class ChildMHRSTaslakKesinlestirmeCollection : TTObject.TTChildObjectCollection<MHRSTaslakKesinlestirme>
        {
            public ChildMHRSTaslakKesinlestirmeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSTaslakKesinlestirmeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MHRSTaslakKesinlestirme(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSTaslakKesinlestirme(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSTaslakKesinlestirme(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSTaslakKesinlestirme(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSTaslakKesinlestirme(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSTASLAKKESINLESTIRME", dataRow) { }
        protected MHRSTaslakKesinlestirme(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSTASLAKKESINLESTIRME", dataRow, isImported) { }
        public MHRSTaslakKesinlestirme(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSTaslakKesinlestirme(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSTaslakKesinlestirme() : base() { }

    }
}