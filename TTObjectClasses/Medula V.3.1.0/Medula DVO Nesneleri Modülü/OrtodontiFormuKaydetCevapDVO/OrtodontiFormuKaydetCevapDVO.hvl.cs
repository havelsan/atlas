
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrtodontiFormuKaydetCevapDVO")] 

    public  partial class OrtodontiFormuKaydetCevapDVO : BaseMedulaCevap
    {
        public class OrtodontiFormuKaydetCevapDVOList : TTObjectCollection<OrtodontiFormuKaydetCevapDVO> { }
                    
        public class ChildOrtodontiFormuKaydetCevapDVOCollection : TTObject.TTChildObjectCollection<OrtodontiFormuKaydetCevapDVO>
        {
            public ChildOrtodontiFormuKaydetCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrtodontiFormuKaydetCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string formNo
        {
            get { return (string)this["FORMNO"]; }
            set { this["FORMNO"] = value; }
        }

        protected OrtodontiFormuKaydetCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrtodontiFormuKaydetCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrtodontiFormuKaydetCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrtodontiFormuKaydetCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrtodontiFormuKaydetCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTODONTIFORMUKAYDETCEVAPDVO", dataRow) { }
        protected OrtodontiFormuKaydetCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTODONTIFORMUKAYDETCEVAPDVO", dataRow, isImported) { }
        public OrtodontiFormuKaydetCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrtodontiFormuKaydetCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrtodontiFormuKaydetCevapDVO() : base() { }

    }
}