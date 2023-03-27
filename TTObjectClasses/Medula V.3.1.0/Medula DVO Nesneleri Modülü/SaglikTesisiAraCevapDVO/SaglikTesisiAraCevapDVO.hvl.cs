
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SaglikTesisiAraCevapDVO")] 

    public  partial class SaglikTesisiAraCevapDVO : BaseMedulaCevap
    {
        public class SaglikTesisiAraCevapDVOList : TTObjectCollection<SaglikTesisiAraCevapDVO> { }
                    
        public class ChildSaglikTesisiAraCevapDVOCollection : TTObject.TTChildObjectCollection<SaglikTesisiAraCevapDVO>
        {
            public ChildSaglikTesisiAraCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSaglikTesisiAraCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreatetesislerCollection()
        {
            _tesisler = new SaglikTesisiListDVO.ChildSaglikTesisiListDVOCollection(this, new Guid("a6970d38-8560-4d04-a5fc-51d29732fedd"));
            ((ITTChildObjectCollection)_tesisler).GetChildren();
        }

        protected SaglikTesisiListDVO.ChildSaglikTesisiListDVOCollection _tesisler = null;
    /// <summary>
    /// Child collection for SaglikTesisiAraCevapDVO-tesisler
    /// </summary>
        public SaglikTesisiListDVO.ChildSaglikTesisiListDVOCollection tesisler
        {
            get
            {
                if (_tesisler == null)
                    CreatetesislerCollection();
                return _tesisler;
            }
        }

        protected SaglikTesisiAraCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SaglikTesisiAraCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SaglikTesisiAraCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SaglikTesisiAraCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SaglikTesisiAraCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAGLIKTESISIARACEVAPDVO", dataRow) { }
        protected SaglikTesisiAraCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAGLIKTESISIARACEVAPDVO", dataRow, isImported) { }
        public SaglikTesisiAraCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SaglikTesisiAraCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SaglikTesisiAraCevapDVO() : base() { }

    }
}