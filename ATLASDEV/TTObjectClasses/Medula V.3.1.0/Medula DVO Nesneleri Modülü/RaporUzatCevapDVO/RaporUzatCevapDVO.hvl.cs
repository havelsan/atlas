
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporUzatCevapDVO")] 

    public  partial class RaporUzatCevapDVO : BaseMedulaRaporCevap
    {
        public class RaporUzatCevapDVOList : TTObjectCollection<RaporUzatCevapDVO> { }
                    
        public class ChildRaporUzatCevapDVOCollection : TTObject.TTChildObjectCollection<RaporUzatCevapDVO>
        {
            public ChildRaporUzatCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporUzatCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public IsgoremezlikRaporEkDVO isgoremezlikRaporEk
        {
            get { return (IsgoremezlikRaporEkDVO)((ITTObject)this).GetParent("ISGOREMEZLIKRAPOREK"); }
            set { this["ISGOREMEZLIKRAPOREK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporUzatCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporUzatCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporUzatCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporUzatCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporUzatCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORUZATCEVAPDVO", dataRow) { }
        protected RaporUzatCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORUZATCEVAPDVO", dataRow, isImported) { }
        public RaporUzatCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporUzatCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporUzatCevapDVO() : base() { }

    }
}