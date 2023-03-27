
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoicePostDetail")] 

    /// <summary>
    /// Fatura Gönderme Detayları
    /// </summary>
    public  partial class InvoicePostDetail : TTObject
    {
        public class InvoicePostDetailList : TTObjectCollection<InvoicePostDetail> { }
                    
        public class ChildInvoicePostDetailCollection : TTObject.TTChildObjectCollection<InvoicePostDetail>
        {
            public ChildInvoicePostDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoicePostDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gönder
    /// </summary>
        public bool? Send
        {
            get { return (bool?)this["SEND"]; }
            set { this["SEND"] = value; }
        }

    /// <summary>
    /// Kurum Faturası Dökümanıyla İlişki
    /// </summary>
        public PayerInvoiceDocument PayerInvoiceDocument
        {
            get { return (PayerInvoiceDocument)((ITTObject)this).GetParent("PAYERINVOICEDOCUMENT"); }
            set { this["PAYERINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura Göndermeyle İlişki
    /// </summary>
        public InvoicePosting InvoicePosting
        {
            get { return (InvoicePosting)((ITTObject)this).GetParent("INVOICEPOSTING"); }
            set { this["INVOICEPOSTING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InvoicePostDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoicePostDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoicePostDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoicePostDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoicePostDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEPOSTDETAIL", dataRow) { }
        protected InvoicePostDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEPOSTDETAIL", dataRow, isImported) { }
        public InvoicePostDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoicePostDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoicePostDetail() : base() { }

    }
}