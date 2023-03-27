
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutKisiCevapDVO")] 

    public  partial class TaahhutKisiCevapDVO : BaseMedulaCevap
    {
        public class TaahhutKisiCevapDVOList : TTObjectCollection<TaahhutKisiCevapDVO> { }
                    
        public class ChildTaahhutKisiCevapDVOCollection : TTObject.TTChildObjectCollection<TaahhutKisiCevapDVO>
        {
            public ChildTaahhutKisiCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutKisiCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreatetaahhutNoDVOsCollection()
        {
            _taahhutNoDVOs = new TaahhutNoDVO.ChildTaahhutNoDVOCollection(this, new Guid("b1e0d868-e935-4b13-ab27-4c7443807824"));
            ((ITTChildObjectCollection)_taahhutNoDVOs).GetChildren();
        }

        protected TaahhutNoDVO.ChildTaahhutNoDVOCollection _taahhutNoDVOs = null;
        public TaahhutNoDVO.ChildTaahhutNoDVOCollection taahhutNoDVOs
        {
            get
            {
                if (_taahhutNoDVOs == null)
                    CreatetaahhutNoDVOsCollection();
                return _taahhutNoDVOs;
            }
        }

        protected TaahhutKisiCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutKisiCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutKisiCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutKisiCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutKisiCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTKISICEVAPDVO", dataRow) { }
        protected TaahhutKisiCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTKISICEVAPDVO", dataRow, isImported) { }
        public TaahhutKisiCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutKisiCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutKisiCevapDVO() : base() { }

    }
}