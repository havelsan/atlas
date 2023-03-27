
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacAraCevapDVO")] 

    public  partial class IlacAraCevapDVO : BaseMedulaCevap
    {
        public class IlacAraCevapDVOList : TTObjectCollection<IlacAraCevapDVO> { }
                    
        public class ChildIlacAraCevapDVOCollection : TTObject.TTChildObjectCollection<IlacAraCevapDVO>
        {
            public ChildIlacAraCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacAraCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateilaclarCollection()
        {
            _ilaclar = new IlacListDVO.ChildIlacListDVOCollection(this, new Guid("e7c8fb33-4384-4e85-b255-53f7ebd3c21f"));
            ((ITTChildObjectCollection)_ilaclar).GetChildren();
        }

        protected IlacListDVO.ChildIlacListDVOCollection _ilaclar = null;
    /// <summary>
    /// Child collection for İlaç Ara Cevap-İlaçlar
    /// </summary>
        public IlacListDVO.ChildIlacListDVOCollection ilaclar
        {
            get
            {
                if (_ilaclar == null)
                    CreateilaclarCollection();
                return _ilaclar;
            }
        }

        protected IlacAraCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacAraCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacAraCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacAraCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacAraCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACARACEVAPDVO", dataRow) { }
        protected IlacAraCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACARACEVAPDVO", dataRow, isImported) { }
        public IlacAraCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacAraCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacAraCevapDVO() : base() { }

    }
}