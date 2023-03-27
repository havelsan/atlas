
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporCevapTCKimlikNodanDVO")] 

    public  partial class RaporCevapTCKimlikNodanDVO : BaseMedulaRaporCevap
    {
        public class RaporCevapTCKimlikNodanDVOList : TTObjectCollection<RaporCevapTCKimlikNodanDVO> { }
                    
        public class ChildRaporCevapTCKimlikNodanDVOCollection : TTObject.TTChildObjectCollection<RaporCevapTCKimlikNodanDVO>
        {
            public ChildRaporCevapTCKimlikNodanDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporCevapTCKimlikNodanDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateraporlarCollection()
        {
            _raporlar = new RaporCevapDVO.ChildRaporCevapDVOCollection(this, new Guid("ba94be5d-9bdf-48a8-9e4b-82340e60f589"));
            ((ITTChildObjectCollection)_raporlar).GetChildren();
        }

        protected RaporCevapDVO.ChildRaporCevapDVOCollection _raporlar = null;
        public RaporCevapDVO.ChildRaporCevapDVOCollection raporlar
        {
            get
            {
                if (_raporlar == null)
                    CreateraporlarCollection();
                return _raporlar;
            }
        }

        protected RaporCevapTCKimlikNodanDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporCevapTCKimlikNodanDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporCevapTCKimlikNodanDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporCevapTCKimlikNodanDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporCevapTCKimlikNodanDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORCEVAPTCKIMLIKNODANDVO", dataRow) { }
        protected RaporCevapTCKimlikNodanDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORCEVAPTCKIMLIKNODANDVO", dataRow, isImported) { }
        public RaporCevapTCKimlikNodanDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporCevapTCKimlikNodanDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporCevapTCKimlikNodanDVO() : base() { }

    }
}