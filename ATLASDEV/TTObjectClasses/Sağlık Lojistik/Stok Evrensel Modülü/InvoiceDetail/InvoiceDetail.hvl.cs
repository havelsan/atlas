
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceDetail")] 

    public  partial class InvoiceDetail : TTObject
    {
        public class InvoiceDetailList : TTObjectCollection<InvoiceDetail> { }
                    
        public class ChildInvoiceDetailCollection : TTObject.TTChildObjectCollection<InvoiceDetail>
        {
            public ChildInvoiceDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İhale Kayıt No /Alım No
    /// </summary>
        public string RegistrationAuctionNo
        {
            get { return (string)this["REGISTRATIONAUCTIONNO"]; }
            set { this["REGISTRATIONAUCTIONNO"] = value; }
        }

    /// <summary>
    /// İhale Kesinleşme Tarihi
    /// </summary>
        public DateTime? AuctionDate
        {
            get { return (DateTime?)this["AUCTIONDATE"]; }
            set { this["AUCTIONDATE"] = value; }
        }

    /// <summary>
    /// Fatura Fotografı
    /// </summary>
        public object InvoicePicture
        {
            get { return (object)this["INVOICEPICTURE"]; }
            set { this["INVOICEPICTURE"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public DateTime? InvoiceDate
        {
            get { return (DateTime?)this["INVOICEDATE"]; }
            set { this["INVOICEDATE"] = value; }
        }

        public StockActionDetail StockActionDetail
        {
            get { return (StockActionDetail)((ITTObject)this).GetParent("STOCKACTIONDETAIL"); }
            set { this["STOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InvoiceDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEDETAIL", dataRow) { }
        protected InvoiceDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEDETAIL", dataRow, isImported) { }
        public InvoiceDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceDetail() : base() { }

    }
}