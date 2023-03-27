
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuayeneSilGirisDVO")] 

    public  partial class MuayeneSilGirisDVO : BaseMedulaObject
    {
        public class MuayeneSilGirisDVOList : TTObjectCollection<MuayeneSilGirisDVO> { }
                    
        public class ChildMuayeneSilGirisDVOCollection : TTObject.TTChildObjectCollection<MuayeneSilGirisDVO>
        {
            public ChildMuayeneSilGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuayeneSilGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? referansNo
        {
            get { return (long?)this["REFERANSNO"]; }
            set { this["REFERANSNO"] = value; }
        }

        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

        public MuayeneSilCevapDVO muayeneSilCevapDVO
        {
            get { return (MuayeneSilCevapDVO)((ITTObject)this).GetParent("MUAYENESILCEVAPDVO"); }
            set { this["MUAYENESILCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MuayeneSilGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuayeneSilGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuayeneSilGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuayeneSilGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuayeneSilGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUAYENESILGIRISDVO", dataRow) { }
        protected MuayeneSilGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUAYENESILGIRISDVO", dataRow, isImported) { }
        public MuayeneSilGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuayeneSilGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuayeneSilGirisDVO() : base() { }

    }
}