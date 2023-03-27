
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoktorAraCevapDVO")] 

    public  partial class DoktorAraCevapDVO : BaseMedulaCevap
    {
        public class DoktorAraCevapDVOList : TTObjectCollection<DoktorAraCevapDVO> { }
                    
        public class ChildDoktorAraCevapDVOCollection : TTObject.TTChildObjectCollection<DoktorAraCevapDVO>
        {
            public ChildDoktorAraCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoktorAraCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreatedoktorlarCollection()
        {
            _doktorlar = new DoktorListDVO.ChildDoktorListDVOCollection(this, new Guid("df05102f-7920-4e37-9d2d-7e82b9896f49"));
            ((ITTChildObjectCollection)_doktorlar).GetChildren();
        }

        protected DoktorListDVO.ChildDoktorListDVOCollection _doktorlar = null;
    /// <summary>
    /// Child collection for Doktor Ara Cevap-Doktorlar
    /// </summary>
        public DoktorListDVO.ChildDoktorListDVOCollection doktorlar
        {
            get
            {
                if (_doktorlar == null)
                    CreatedoktorlarCollection();
                return _doktorlar;
            }
        }

        protected DoktorAraCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoktorAraCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoktorAraCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoktorAraCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoktorAraCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOKTORARACEVAPDVO", dataRow) { }
        protected DoktorAraCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOKTORARACEVAPDVO", dataRow, isImported) { }
        public DoktorAraCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoktorAraCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoktorAraCevapDVO() : base() { }

    }
}