
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KatilimPayiDVO")] 

    public  partial class KatilimPayiDVO : BaseMedulaObject
    {
        public class KatilimPayiDVOList : TTObjectCollection<KatilimPayiDVO> { }
                    
        public class ChildKatilimPayiDVOCollection : TTObject.TTChildObjectCollection<KatilimPayiDVO>
        {
            public ChildKatilimPayiDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKatilimPayiDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public double? malzemeKatilimTutari
        {
            get { return (double?)this["MALZEMEKATILIMTUTARI"]; }
            set { this["MALZEMEKATILIMTUTARI"] = value; }
        }

        public double? muayeneKatilimTutari
        {
            get { return (double?)this["MUAYENEKATILIMTUTARI"]; }
            set { this["MUAYENEKATILIMTUTARI"] = value; }
        }

        public string takipNo
        {
            get { return (string)this["TAKIPNO"]; }
            set { this["TAKIPNO"] = value; }
        }

        public double? tupBebekKatilimTutari
        {
            get { return (double?)this["TUPBEBEKKATILIMTUTARI"]; }
            set { this["TUPBEBEKKATILIMTUTARI"] = value; }
        }

        public KatilimPayiCevapDVO KatilimPayiCevapDVO
        {
            get { return (KatilimPayiCevapDVO)((ITTObject)this).GetParent("KATILIMPAYICEVAPDVO"); }
            set { this["KATILIMPAYICEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KatilimPayiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KatilimPayiDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KatilimPayiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KatilimPayiDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KatilimPayiDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KATILIMPAYIDVO", dataRow) { }
        protected KatilimPayiDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KATILIMPAYIDVO", dataRow, isImported) { }
        public KatilimPayiDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KatilimPayiDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KatilimPayiDVO() : base() { }

    }
}