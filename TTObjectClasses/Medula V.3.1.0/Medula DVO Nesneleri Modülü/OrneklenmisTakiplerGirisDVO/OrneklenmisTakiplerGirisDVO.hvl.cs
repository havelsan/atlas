
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrneklenmisTakiplerGirisDVO")] 

    public  partial class OrneklenmisTakiplerGirisDVO : BaseMedulaObject
    {
        public class OrneklenmisTakiplerGirisDVOList : TTObjectCollection<OrneklenmisTakiplerGirisDVO> { }
                    
        public class ChildOrneklenmisTakiplerGirisDVOCollection : TTObject.TTChildObjectCollection<OrneklenmisTakiplerGirisDVO>
        {
            public ChildOrneklenmisTakiplerGirisDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrneklenmisTakiplerGirisDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Evrak Referans No
    /// </summary>
        public int? evrakId
        {
            get { return (int?)this["EVRAKID"]; }
            set { this["EVRAKID"] = value; }
        }

    /// <summary>
    /// Tesis kodu
    /// </summary>
        public int? tesisKodu
        {
            get { return (int?)this["TESISKODU"]; }
            set { this["TESISKODU"] = value; }
        }

        public OrneklenmisTakiplerCevapDVO orneklenmisTakiplerCevapDVO
        {
            get { return (OrneklenmisTakiplerCevapDVO)((ITTObject)this).GetParent("ORNEKLENMISTAKIPLERCEVAPDVO"); }
            set { this["ORNEKLENMISTAKIPLERCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OrneklenmisTakiplerGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrneklenmisTakiplerGirisDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrneklenmisTakiplerGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrneklenmisTakiplerGirisDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrneklenmisTakiplerGirisDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORNEKLENMISTAKIPLERGIRISDVO", dataRow) { }
        protected OrneklenmisTakiplerGirisDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORNEKLENMISTAKIPLERGIRISDVO", dataRow, isImported) { }
        public OrneklenmisTakiplerGirisDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrneklenmisTakiplerGirisDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrneklenmisTakiplerGirisDVO() : base() { }

    }
}