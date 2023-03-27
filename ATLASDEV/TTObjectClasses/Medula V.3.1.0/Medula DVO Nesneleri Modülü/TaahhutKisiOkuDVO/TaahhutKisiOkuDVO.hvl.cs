
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutKisiOkuDVO")] 

    public  partial class TaahhutKisiOkuDVO : BaseMedulaObject
    {
        public class TaahhutKisiOkuDVOList : TTObjectCollection<TaahhutKisiOkuDVO> { }
                    
        public class ChildTaahhutKisiOkuDVOCollection : TTObject.TTChildObjectCollection<TaahhutKisiOkuDVO>
        {
            public ChildTaahhutKisiOkuDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutKisiOkuDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public long? tcKimlikNo
        {
            get { return (long?)this["TCKIMLIKNO"]; }
            set { this["TCKIMLIKNO"] = value; }
        }

        public TaahhutKisiCevapDVO taahhutKisiCevapDVO
        {
            get { return (TaahhutKisiCevapDVO)((ITTObject)this).GetParent("TAAHHUTKISICEVAPDVO"); }
            set { this["TAAHHUTKISICEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaahhutKisiOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutKisiOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutKisiOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutKisiOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutKisiOkuDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTKISIOKUDVO", dataRow) { }
        protected TaahhutKisiOkuDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTKISIOKUDVO", dataRow, isImported) { }
        public TaahhutKisiOkuDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutKisiOkuDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutKisiOkuDVO() : base() { }

    }
}