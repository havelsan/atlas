
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrtodontiFormuIptalCevapDVO")] 

    public  partial class OrtodontiFormuIptalCevapDVO : BaseMedulaCevap
    {
        public class OrtodontiFormuIptalCevapDVOList : TTObjectCollection<OrtodontiFormuIptalCevapDVO> { }
                    
        public class ChildOrtodontiFormuIptalCevapDVOCollection : TTObject.TTChildObjectCollection<OrtodontiFormuIptalCevapDVO>
        {
            public ChildOrtodontiFormuIptalCevapDVOCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrtodontiFormuIptalCevapDVOCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string formNo
        {
            get { return (string)this["FORMNO"]; }
            set { this["FORMNO"] = value; }
        }

        protected OrtodontiFormuIptalCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrtodontiFormuIptalCevapDVO(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrtodontiFormuIptalCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrtodontiFormuIptalCevapDVO(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrtodontiFormuIptalCevapDVO(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTODONTIFORMUIPTALCEVAPDVO", dataRow) { }
        protected OrtodontiFormuIptalCevapDVO(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTODONTIFORMUIPTALCEVAPDVO", dataRow, isImported) { }
        public OrtodontiFormuIptalCevapDVO(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrtodontiFormuIptalCevapDVO(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrtodontiFormuIptalCevapDVO() : base() { }

    }
}