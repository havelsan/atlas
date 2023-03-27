
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EthicCommisionClaim")] 

    public  partial class EthicCommisionClaim : TTObject
    {
        public class EthicCommisionClaimList : TTObjectCollection<EthicCommisionClaim> { }
                    
        public class ChildEthicCommisionClaimCollection : TTObject.TTChildObjectCollection<EthicCommisionClaim>
        {
            public ChildEthicCommisionClaimCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEthicCommisionClaimCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string EthicCommAddInfo
        {
            get { return (string)this["ETHICCOMMADDINFO"]; }
            set { this["ETHICCOMMADDINFO"] = value; }
        }

        public DateTime? EthicCommAddDate
        {
            get { return (DateTime?)this["ETHICCOMMADDDATE"]; }
            set { this["ETHICCOMMADDDATE"] = value; }
        }

        virtual protected void CreateProjectEthicCommClaimCollection()
        {
            _ProjectEthicCommClaim = new ArgeProject.ChildArgeProjectCollection(this, new Guid("6544ea85-9c1c-486f-b0cc-8056838e3b2b"));
            ((ITTChildObjectCollection)_ProjectEthicCommClaim).GetChildren();
        }

        protected ArgeProject.ChildArgeProjectCollection _ProjectEthicCommClaim = null;
        public ArgeProject.ChildArgeProjectCollection ProjectEthicCommClaim
        {
            get
            {
                if (_ProjectEthicCommClaim == null)
                    CreateProjectEthicCommClaimCollection();
                return _ProjectEthicCommClaim;
            }
        }

        protected EthicCommisionClaim(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EthicCommisionClaim(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EthicCommisionClaim(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EthicCommisionClaim(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EthicCommisionClaim(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETHICCOMMISIONCLAIM", dataRow) { }
        protected EthicCommisionClaim(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETHICCOMMISIONCLAIM", dataRow, isImported) { }
        public EthicCommisionClaim(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EthicCommisionClaim(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EthicCommisionClaim() : base() { }

    }
}