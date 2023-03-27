
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuayeneGirisCevapDVO")] 

    public  partial class MuayeneGirisCevapDVO : BaseMedulaCevap
    {
        public class MuayeneGirisCevapDVOList : TTObjectCollection<MuayeneGirisCevapDVO> { }
                    
        public class ChildMuayeneGirisCevapDVOCollection : TTObject.TTChildObjectCollection<MuayeneGirisCevapDVO>
        {
            public ChildMuayeneGirisCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuayeneGirisCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? muayeneNo
        {
            get { return (long?)this["MUAYENENO"]; }
            set { this["MUAYENENO"] = value; }
        }

        public long? tcKimlikNo
        {
            get { return (long?)this["TCKIMLIKNO"]; }
            set { this["TCKIMLIKNO"] = value; }
        }

        protected MuayeneGirisCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuayeneGirisCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuayeneGirisCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuayeneGirisCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuayeneGirisCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUAYENEGIRISCEVAPDVO", dataRow) { }
        protected MuayeneGirisCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUAYENEGIRISCEVAPDVO", dataRow, isImported) { }
        public MuayeneGirisCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuayeneGirisCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuayeneGirisCevapDVO() : base() { }

    }
}