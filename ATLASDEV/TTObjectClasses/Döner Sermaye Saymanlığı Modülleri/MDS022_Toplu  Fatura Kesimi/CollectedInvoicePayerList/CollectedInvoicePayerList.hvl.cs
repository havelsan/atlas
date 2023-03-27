
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectedInvoicePayerList")] 

    /// <summary>
    /// Toplu Fatura Kurum Listesi
    /// </summary>
    public  partial class CollectedInvoicePayerList : TTObject
    {
        public class CollectedInvoicePayerListList : TTObjectCollection<CollectedInvoicePayerList> { }
                    
        public class ChildCollectedInvoicePayerListCollection : TTObject.TTChildObjectCollection<CollectedInvoicePayerList>
        {
            public ChildCollectedInvoicePayerListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectedInvoicePayerListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kurumla İlişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Toplu Fatura İşlemiyle İlişki
    /// </summary>
        public CollectedInvoice CollectedInvoice
        {
            get { return (CollectedInvoice)((ITTObject)this).GetParent("COLLECTEDINVOICE"); }
            set { this["COLLECTEDINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CollectedInvoicePayerList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectedInvoicePayerList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectedInvoicePayerList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectedInvoicePayerList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectedInvoicePayerList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTEDINVOICEPAYERLIST", dataRow) { }
        protected CollectedInvoicePayerList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTEDINVOICEPAYERLIST", dataRow, isImported) { }
        public CollectedInvoicePayerList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectedInvoicePayerList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectedInvoicePayerList() : base() { }

    }
}