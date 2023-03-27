
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporSorguDVO")] 

    public  partial class RaporSorguDVO : BaseMedulaRaporObject
    {
        public class RaporSorguDVOList : TTObjectCollection<RaporSorguDVO> { }
                    
        public class ChildRaporSorguDVOCollection : TTObject.TTChildObjectCollection<RaporSorguDVO>
        {
            public ChildRaporSorguDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporSorguDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rapor Cevap
    /// </summary>
        public RaporCevapDVO raporCevapDVO
        {
            get { return (RaporCevapDVO)((ITTObject)this).GetParent("RAPORCEVAPDVO"); }
            set { this["RAPORCEVAPDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RaporOkuDVO raporBilgisi
        {
            get { return (RaporOkuDVO)((ITTObject)this).GetParent("RAPORBILGISI"); }
            set { this["RAPORBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporSorguDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporSorguDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporSorguDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporSorguDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporSorguDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORSORGUDVO", dataRow) { }
        protected RaporSorguDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORSORGUDVO", dataRow, isImported) { }
        public RaporSorguDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporSorguDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporSorguDVO() : base() { }

    }
}