
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMaddeOkuCevapDVO")] 

    public  partial class EtkinMaddeOkuCevapDVO : BaseMedulaCevap
    {
        public class EtkinMaddeOkuCevapDVOList : TTObjectCollection<EtkinMaddeOkuCevapDVO> { }
                    
        public class ChildEtkinMaddeOkuCevapDVOCollection : TTObject.TTChildObjectCollection<EtkinMaddeOkuCevapDVO>
        {
            public ChildEtkinMaddeOkuCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeOkuCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateetkinMaddelerCollection()
        {
            _etkinMaddeler = new EtkinMaddeDVO.ChildEtkinMaddeDVOCollection(this, new Guid("d417ee66-fa09-4f2e-859e-6776ea859514"));
            ((ITTChildObjectCollection)_etkinMaddeler).GetChildren();
        }

        protected EtkinMaddeDVO.ChildEtkinMaddeDVOCollection _etkinMaddeler = null;
        public EtkinMaddeDVO.ChildEtkinMaddeDVOCollection etkinMaddeler
        {
            get
            {
                if (_etkinMaddeler == null)
                    CreateetkinMaddelerCollection();
                return _etkinMaddeler;
            }
        }

        protected EtkinMaddeOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMaddeOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMaddeOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMaddeOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMaddeOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDEOKUCEVAPDVO", dataRow) { }
        protected EtkinMaddeOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDEOKUCEVAPDVO", dataRow, isImported) { }
        public EtkinMaddeOkuCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMaddeOkuCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMaddeOkuCevapDVO() : base() { }

    }
}