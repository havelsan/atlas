
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChattelDocumentDistribution")] 

    public  partial class ChattelDocumentDistribution : TTObject
    {
        public class ChattelDocumentDistributionList : TTObjectCollection<ChattelDocumentDistribution> { }
                    
        public class ChildChattelDocumentDistributionCollection : TTObject.TTChildObjectCollection<ChattelDocumentDistribution>
        {
            public ChildChattelDocumentDistributionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChattelDocumentDistributionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dağıtım Miktarı
    /// </summary>
        public Currency? DistributionAmount
        {
            get { return (Currency?)this["DISTRIBUTIONAMOUNT"]; }
            set { this["DISTRIBUTIONAMOUNT"] = value; }
        }

        public DemandDetail DemandDetail
        {
            get { return (DemandDetail)((ITTObject)this).GetParent("DEMANDDETAIL"); }
            set { this["DEMANDDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ChattelDocumentWithPurchase ChattelDocumentWithPurchase
        {
            get { return (ChattelDocumentWithPurchase)((ITTObject)this).GetParent("CHATTELDOCUMENTWITHPURCHASE"); }
            set { this["CHATTELDOCUMENTWITHPURCHASE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ChattelDocumentDetailWithPurchase ChattelDocDetailWithPurchase
        {
            get { return (ChattelDocumentDetailWithPurchase)((ITTObject)this).GetParent("CHATTELDOCDETAILWITHPURCHASE"); }
            set { this["CHATTELDOCDETAILWITHPURCHASE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ChattelDocumentDistribution(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChattelDocumentDistribution(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChattelDocumentDistribution(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChattelDocumentDistribution(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChattelDocumentDistribution(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHATTELDOCUMENTDISTRIBUTION", dataRow) { }
        protected ChattelDocumentDistribution(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHATTELDOCUMENTDISTRIBUTION", dataRow, isImported) { }
        public ChattelDocumentDistribution(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChattelDocumentDistribution(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChattelDocumentDistribution() : base() { }

    }
}