
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KatilimPayiCevapDVO")] 

    public  partial class KatilimPayiCevapDVO : BaseMedulaCevap
    {
        public class KatilimPayiCevapDVOList : TTObjectCollection<KatilimPayiCevapDVO> { }
                    
        public class ChildKatilimPayiCevapDVOCollection : TTObject.TTChildObjectCollection<KatilimPayiCevapDVO>
        {
            public ChildKatilimPayiCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKatilimPayiCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? evrakRefNo
        {
            get { return (int?)this["EVRAKREFNO"]; }
            set { this["EVRAKREFNO"] = value; }
        }

        virtual protected void CreatekatilimPaylariCollection()
        {
            _katilimPaylari = new KatilimPayiDVO.ChildKatilimPayiDVOCollection(this, new Guid("e5fb0c08-c075-4757-82bb-02c966d6d948"));
            ((ITTChildObjectCollection)_katilimPaylari).GetChildren();
        }

        protected KatilimPayiDVO.ChildKatilimPayiDVOCollection _katilimPaylari = null;
        public KatilimPayiDVO.ChildKatilimPayiDVOCollection katilimPaylari
        {
            get
            {
                if (_katilimPaylari == null)
                    CreatekatilimPaylariCollection();
                return _katilimPaylari;
            }
        }

        protected KatilimPayiCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KatilimPayiCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KatilimPayiCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KatilimPayiCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KatilimPayiCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KATILIMPAYICEVAPDVO", dataRow) { }
        protected KatilimPayiCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KATILIMPAYICEVAPDVO", dataRow, isImported) { }
        public KatilimPayiCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KatilimPayiCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KatilimPayiCevapDVO() : base() { }

    }
}