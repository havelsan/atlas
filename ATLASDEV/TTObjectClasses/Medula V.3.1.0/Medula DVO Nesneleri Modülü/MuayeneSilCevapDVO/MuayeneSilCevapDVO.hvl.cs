
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuayeneSilCevapDVO")] 

    public  partial class MuayeneSilCevapDVO : BaseMedulaCevap
    {
        public class MuayeneSilCevapDVOList : TTObjectCollection<MuayeneSilCevapDVO> { }
                    
        public class ChildMuayeneSilCevapDVOCollection : TTObject.TTChildObjectCollection<MuayeneSilCevapDVO>
        {
            public ChildMuayeneSilCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuayeneSilCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MuayeneSilCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuayeneSilCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuayeneSilCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuayeneSilCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuayeneSilCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUAYENESILCEVAPDVO", dataRow) { }
        protected MuayeneSilCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUAYENESILCEVAPDVO", dataRow, isImported) { }
        public MuayeneSilCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuayeneSilCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuayeneSilCevapDVO() : base() { }

    }
}