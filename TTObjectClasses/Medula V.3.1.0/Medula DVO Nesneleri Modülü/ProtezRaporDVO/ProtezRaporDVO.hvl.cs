
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtezRaporDVO")] 

    public  partial class ProtezRaporDVO : BaseMedulaObject
    {
        public class ProtezRaporDVOList : TTObjectCollection<ProtezRaporDVO> { }
                    
        public class ChildProtezRaporDVOCollection : TTObject.TTChildObjectCollection<ProtezRaporDVO>
        {
            public ChildProtezRaporDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtezRaporDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public RaporDVO raporDVO
        {
            get { return (RaporDVO)((ITTObject)this).GetParent("RAPORDVO"); }
            set { this["RAPORDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatemalzemelerCollection()
        {
            _malzemeler = new MalzemeBilgisi_RaporDVO.ChildMalzemeBilgisi_RaporDVOCollection(this, new Guid("0b0100a1-5b04-4f41-b6a9-146c8e31c72a"));
            ((ITTChildObjectCollection)_malzemeler).GetChildren();
        }

        protected MalzemeBilgisi_RaporDVO.ChildMalzemeBilgisi_RaporDVOCollection _malzemeler = null;
        public MalzemeBilgisi_RaporDVO.ChildMalzemeBilgisi_RaporDVOCollection malzemeler
        {
            get
            {
                if (_malzemeler == null)
                    CreatemalzemelerCollection();
                return _malzemeler;
            }
        }

        protected ProtezRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtezRaporDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtezRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtezRaporDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtezRaporDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTEZRAPORDVO", dataRow) { }
        protected ProtezRaporDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTEZRAPORDVO", dataRow, isImported) { }
        public ProtezRaporDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtezRaporDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtezRaporDVO() : base() { }

    }
}