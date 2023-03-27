
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaahhutCevapDVO")] 

    public  partial class TaahhutCevapDVO : BaseMedulaCevap
    {
        public class TaahhutCevapDVOList : TTObjectCollection<TaahhutCevapDVO> { }
                    
        public class ChildTaahhutCevapDVOCollection : TTObject.TTChildObjectCollection<TaahhutCevapDVO>
        {
            public ChildTaahhutCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaahhutCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public object taahhutCikti
        {
            get { return (object)this["TAAHHUTCIKTI"]; }
            set { this["TAAHHUTCIKTI"] = value; }
        }

        public int? taahhutNo
        {
            get { return (int?)this["TAAHHUTNO"]; }
            set { this["TAAHHUTNO"] = value; }
        }

        protected TaahhutCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaahhutCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaahhutCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaahhutCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaahhutCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAAHHUTCEVAPDVO", dataRow) { }
        protected TaahhutCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAAHHUTCEVAPDVO", dataRow, isImported) { }
        public TaahhutCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaahhutCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaahhutCevapDVO() : base() { }

    }
}