
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TeshisOkuGirisDVO")] 

    public  partial class TeshisOkuGirisDVO : BaseMedulaObject
    {
        public class TeshisOkuGirisDVOList : TTObjectCollection<TeshisOkuGirisDVO> { }
                    
        public class ChildTeshisOkuGirisDVOCollection : TTObject.TTChildObjectCollection<TeshisOkuGirisDVO>
        {
            public ChildTeshisOkuGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTeshisOkuGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public TeshisOkuCevapDVO teshisOkuCevapDVO
        {
            get { return (TeshisOkuCevapDVO)((ITTObject)this).GetParent("TESHISOKUCEVAPDVO"); }
            set { this["TESHISOKUCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TeshisOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TeshisOkuGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TeshisOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TeshisOkuGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TeshisOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESHISOKUGIRISDVO", dataRow) { }
        protected TeshisOkuGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESHISOKUGIRISDVO", dataRow, isImported) { }
        public TeshisOkuGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TeshisOkuGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TeshisOkuGirisDVO() : base() { }

    }
}