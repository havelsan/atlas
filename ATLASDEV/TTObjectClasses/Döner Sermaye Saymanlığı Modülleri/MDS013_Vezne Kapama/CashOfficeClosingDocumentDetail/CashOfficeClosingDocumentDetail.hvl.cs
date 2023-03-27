
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeClosingDocumentDetail")] 

    /// <summary>
    /// Vezne Kapama Dökümanı Detayı
    /// </summary>
    public  partial class CashOfficeClosingDocumentDetail : AccountDocumentDetail
    {
        public class CashOfficeClosingDocumentDetailList : TTObjectCollection<CashOfficeClosingDocumentDetail> { }
                    
        public class ChildCashOfficeClosingDocumentDetailCollection : TTObject.TTChildObjectCollection<CashOfficeClosingDocumentDetail>
        {
            public ChildCashOfficeClosingDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeClosingDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CashOfficeClosingDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeClosingDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeClosingDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeClosingDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeClosingDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICECLOSINGDOCUMENTDETAIL", dataRow) { }
        protected CashOfficeClosingDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICECLOSINGDOCUMENTDETAIL", dataRow, isImported) { }
        public CashOfficeClosingDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeClosingDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeClosingDocumentDetail() : base() { }

    }
}