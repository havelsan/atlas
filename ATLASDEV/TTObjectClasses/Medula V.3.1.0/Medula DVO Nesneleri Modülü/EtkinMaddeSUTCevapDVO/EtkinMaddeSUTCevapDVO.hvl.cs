
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMaddeSUTCevapDVO")] 

    public  partial class EtkinMaddeSUTCevapDVO : BaseMedulaCevap
    {
        public class EtkinMaddeSUTCevapDVOList : TTObjectCollection<EtkinMaddeSUTCevapDVO> { }
                    
        public class ChildEtkinMaddeSUTCevapDVOCollection : TTObject.TTChildObjectCollection<EtkinMaddeSUTCevapDVO>
        {
            public ChildEtkinMaddeSUTCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeSUTCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreatesutKurallariCollection()
        {
            _sutKurallari = new EtkinMaddeSUTKuraliDVO.ChildEtkinMaddeSUTKuraliDVOCollection(this, new Guid("6cf9d808-c8b2-43de-9fc0-0e44e6877919"));
            ((ITTChildObjectCollection)_sutKurallari).GetChildren();
        }

        protected EtkinMaddeSUTKuraliDVO.ChildEtkinMaddeSUTKuraliDVOCollection _sutKurallari = null;
        public EtkinMaddeSUTKuraliDVO.ChildEtkinMaddeSUTKuraliDVOCollection sutKurallari
        {
            get
            {
                if (_sutKurallari == null)
                    CreatesutKurallariCollection();
                return _sutKurallari;
            }
        }

        protected EtkinMaddeSUTCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMaddeSUTCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMaddeSUTCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMaddeSUTCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMaddeSUTCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDESUTCEVAPDVO", dataRow) { }
        protected EtkinMaddeSUTCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDESUTCEVAPDVO", dataRow, isImported) { }
        public EtkinMaddeSUTCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMaddeSUTCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMaddeSUTCevapDVO() : base() { }

    }
}