
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipAraCevapDVO")] 

    public  partial class TakipAraCevapDVO : BaseMedulaCevap
    {
        public class TakipAraCevapDVOList : TTObjectCollection<TakipAraCevapDVO> { }
                    
        public class ChildTakipAraCevapDVOCollection : TTObject.TTChildObjectCollection<TakipAraCevapDVO>
        {
            public ChildTakipAraCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipAraCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreatetakiplerCollection()
        {
            _takipler = new TakipDVO.ChildTakipDVOCollection(this, new Guid("1dca3d35-5706-478d-9d8b-bbeb9a143a01"));
            ((ITTChildObjectCollection)_takipler).GetChildren();
        }

        protected TakipDVO.ChildTakipDVOCollection _takipler = null;
    /// <summary>
    /// Child collection for Takip Ara Cevap-Takipler
    /// </summary>
        public TakipDVO.ChildTakipDVOCollection takipler
        {
            get
            {
                if (_takipler == null)
                    CreatetakiplerCollection();
                return _takipler;
            }
        }

        protected TakipAraCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipAraCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipAraCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipAraCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipAraCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPARACEVAPDVO", dataRow) { }
        protected TakipAraCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPARACEVAPDVO", dataRow, isImported) { }
        public TakipAraCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipAraCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipAraCevapDVO() : base() { }

    }
}