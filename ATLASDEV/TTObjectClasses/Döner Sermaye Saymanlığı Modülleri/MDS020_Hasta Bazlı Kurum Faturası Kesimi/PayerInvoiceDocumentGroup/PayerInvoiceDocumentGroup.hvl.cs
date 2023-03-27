
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerInvoiceDocumentGroup")] 

    /// <summary>
    /// Kurum Faturası Döküman Grubu
    /// </summary>
    public  partial class PayerInvoiceDocumentGroup : AccountDocumentGroup
    {
        public class PayerInvoiceDocumentGroupList : TTObjectCollection<PayerInvoiceDocumentGroup> { }
                    
        public class ChildPayerInvoiceDocumentGroupCollection : TTObject.TTChildObjectCollection<PayerInvoiceDocumentGroup>
        {
            public ChildPayerInvoiceDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerInvoiceDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        override protected void CreateAccountDocumentDetailsCollectionViews()
        {
            base.CreateAccountDocumentDetailsCollectionViews();
            _PayerInvoiceDocumentDetails = new PayerInvoiceDocumentDetail.ChildPayerInvoiceDocumentDetailCollection(_AccountDocumentDetails, "PayerInvoiceDocumentDetails");
        }

        private PayerInvoiceDocumentDetail.ChildPayerInvoiceDocumentDetailCollection _PayerInvoiceDocumentDetails = null;
        public PayerInvoiceDocumentDetail.ChildPayerInvoiceDocumentDetailCollection PayerInvoiceDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _PayerInvoiceDocumentDetails;
            }            
        }

        protected PayerInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerInvoiceDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerInvoiceDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERINVOICEDOCUMENTGROUP", dataRow) { }
        protected PayerInvoiceDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERINVOICEDOCUMENTGROUP", dataRow, isImported) { }
        public PayerInvoiceDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerInvoiceDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerInvoiceDocumentGroup() : base() { }

    }
}