
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TeshisOkuCevapDVO")] 

    public  partial class TeshisOkuCevapDVO : BaseMedulaCevap
    {
        public class TeshisOkuCevapDVOList : TTObjectCollection<TeshisOkuCevapDVO> { }
                    
        public class ChildTeshisOkuCevapDVOCollection : TTObject.TTChildObjectCollection<TeshisOkuCevapDVO>
        {
            public ChildTeshisOkuCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTeshisOkuCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateteshislerCollection()
        {
            _teshisler = new TeshisDVO.ChildTeshisDVOCollection(this, new Guid("9ba0d792-b5ba-4a9c-b9d7-db0365ca5503"));
            ((ITTChildObjectCollection)_teshisler).GetChildren();
        }

        protected TeshisDVO.ChildTeshisDVOCollection _teshisler = null;
        public TeshisDVO.ChildTeshisDVOCollection teshisler
        {
            get
            {
                if (_teshisler == null)
                    CreateteshislerCollection();
                return _teshisler;
            }
        }

        protected TeshisOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TeshisOkuCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TeshisOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TeshisOkuCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TeshisOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TESHISOKUCEVAPDVO", dataRow) { }
        protected TeshisOkuCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TESHISOKUCEVAPDVO", dataRow, isImported) { }
        public TeshisOkuCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TeshisOkuCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TeshisOkuCevapDVO() : base() { }

    }
}