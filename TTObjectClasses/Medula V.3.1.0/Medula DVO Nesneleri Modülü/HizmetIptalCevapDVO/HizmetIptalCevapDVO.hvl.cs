
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetIptalCevapDVO")] 

    public  partial class HizmetIptalCevapDVO : BaseMedulaCevap
    {
        public class HizmetIptalCevapDVOList : TTObjectCollection<HizmetIptalCevapDVO> { }
                    
        public class ChildHizmetIptalCevapDVOCollection : TTObject.TTChildObjectCollection<HizmetIptalCevapDVO>
        {
            public ChildHizmetIptalCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetIptalCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected HizmetIptalCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetIptalCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetIptalCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetIptalCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetIptalCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETIPTALCEVAPDVO", dataRow) { }
        protected HizmetIptalCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETIPTALCEVAPDVO", dataRow, isImported) { }
        public HizmetIptalCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetIptalCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetIptalCevapDVO() : base() { }

    }
}