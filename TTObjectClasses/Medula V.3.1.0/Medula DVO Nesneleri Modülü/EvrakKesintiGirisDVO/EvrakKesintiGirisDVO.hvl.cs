
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EvrakKesintiGirisDVO")] 

    public  partial class EvrakKesintiGirisDVO : BaseMedulaObject
    {
        public class EvrakKesintiGirisDVOList : TTObjectCollection<EvrakKesintiGirisDVO> { }
                    
        public class ChildEvrakKesintiGirisDVOCollection : TTObject.TTChildObjectCollection<EvrakKesintiGirisDVO>
        {
            public ChildEvrakKesintiGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEvrakKesintiGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tesis kodu
    /// </summary>
        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

        public int? evrakRefNo
        {
            get { return (int?)this["EVRAKREFNO"]; }
            set { this["EVRAKREFNO"] = value; }
        }

        public EvrakKesintiCevapDVO evrakKesintiCevapDVO
        {
            get { return (EvrakKesintiCevapDVO)((ITTObject)this).GetParent("EVRAKKESINTICEVAPDVO"); }
            set { this["EVRAKKESINTICEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EvrakKesintiGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EvrakKesintiGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EvrakKesintiGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EvrakKesintiGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EvrakKesintiGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EVRAKKESINTIGIRISDVO", dataRow) { }
        protected EvrakKesintiGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EVRAKKESINTIGIRISDVO", dataRow, isImported) { }
        public EvrakKesintiGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EvrakKesintiGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EvrakKesintiGirisDVO() : base() { }

    }
}