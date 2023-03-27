
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutOkuDVO")] 

    public  partial class TaahhutOkuDVO : BaseMedulaObject
    {
        public class TaahhutOkuDVOList : TTObjectCollection<TaahhutOkuDVO> { }
                    
        public class ChildTaahhutOkuDVOCollection : TTObject.TTChildObjectCollection<TaahhutOkuDVO>
        {
            public ChildTaahhutOkuDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutOkuDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? saglikTesisKodu
        {
            get { return (int?)this["SAGLIKTESISKODU"]; }
            set { this["SAGLIKTESISKODU"] = value; }
        }

        public int? taahhutNo
        {
            get { return (int?)this["TAAHHUTNO"]; }
            set { this["TAAHHUTNO"] = value; }
        }

        public TaahhutCevapDVO taahhutCevapDVO
        {
            get { return (TaahhutCevapDVO)((ITTObject)this).GetParent("TAAHHUTCEVAPDVO"); }
            set { this["TAAHHUTCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaahhutOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutOkuDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutOkuDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutOkuDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTOKUDVO", dataRow) { }
        protected TaahhutOkuDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTOKUDVO", dataRow, isImported) { }
        public TaahhutOkuDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutOkuDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutOkuDVO() : base() { }

    }
}