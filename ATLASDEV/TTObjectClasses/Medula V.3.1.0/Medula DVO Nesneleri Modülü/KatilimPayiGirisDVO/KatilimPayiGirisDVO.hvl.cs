
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KatilimPayiGirisDVO")] 

    public  partial class KatilimPayiGirisDVO : BaseMedulaObject
    {
        public class KatilimPayiGirisDVOList : TTObjectCollection<KatilimPayiGirisDVO> { }
                    
        public class ChildKatilimPayiGirisDVOCollection : TTObject.TTChildObjectCollection<KatilimPayiGirisDVO>
        {
            public ChildKatilimPayiGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKatilimPayiGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tesis Kodu
    /// </summary>
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public int? evrakRefNo
        {
            get { return (int?)this["EVRAKREFNO"]; }
            set { this["EVRAKREFNO"] = value; }
        }

        public KatilimPayiCevapDVO katilimPayiCevapDVO
        {
            get { return (KatilimPayiCevapDVO)((ITTObject)this).GetParent("KATILIMPAYICEVAPDVO"); }
            set { this["KATILIMPAYICEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KatilimPayiGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KatilimPayiGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KatilimPayiGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KatilimPayiGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KatilimPayiGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KATILIMPAYIGIRISDVO", dataRow) { }
        protected KatilimPayiGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KATILIMPAYIGIRISDVO", dataRow, isImported) { }
        public KatilimPayiGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KatilimPayiGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KatilimPayiGirisDVO() : base() { }

    }
}