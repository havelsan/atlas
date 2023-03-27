
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectedInvoiceResourceList")] 

    /// <summary>
    /// Toplu Fatura Kaynak Listesi
    /// </summary>
    public  partial class CollectedInvoiceResourceList : TTObject
    {
        public class CollectedInvoiceResourceListList : TTObjectCollection<CollectedInvoiceResourceList> { }
                    
        public class ChildCollectedInvoiceResourceListCollection : TTObject.TTChildObjectCollection<CollectedInvoiceResourceList>
        {
            public ChildCollectedInvoiceResourceListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectedInvoiceResourceListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bölümlerle İlişki
    /// </summary>
        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Toplu Fatura İşlemiyle İlişki
    /// </summary>
        public CollectedInvoice CollectedInvoice
        {
            get { return (CollectedInvoice)((ITTObject)this).GetParent("COLLECTEDINVOICE"); }
            set { this["COLLECTEDINVOICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CollectedInvoiceResourceList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectedInvoiceResourceList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectedInvoiceResourceList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectedInvoiceResourceList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectedInvoiceResourceList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTEDINVOICERESOURCELIST", dataRow) { }
        protected CollectedInvoiceResourceList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTEDINVOICERESOURCELIST", dataRow, isImported) { }
        public CollectedInvoiceResourceList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectedInvoiceResourceList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectedInvoiceResourceList() : base() { }

    }
}