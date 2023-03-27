
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChattelDocumentOutputDetailWithAccountancy")] 

    public  partial class ChattelDocumentOutputDetailWithAccountancy : StockActionDetailOut
    {
        public class ChattelDocumentOutputDetailWithAccountancyList : TTObjectCollection<ChattelDocumentOutputDetailWithAccountancy> { }
                    
        public class ChildChattelDocumentOutputDetailWithAccountancyCollection : TTObject.TTChildObjectCollection<ChattelDocumentOutputDetailWithAccountancy>
        {
            public ChildChattelDocumentOutputDetailWithAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChattelDocumentOutputDetailWithAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ChattelDocOutInvoiceRQ_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKTRANSACTION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public long? VatRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTOUTPUTDETAILWITHACCOUNTANCY"].AllPropertyDefs["VATRATE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public ChattelDocOutInvoiceRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ChattelDocOutInvoiceRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ChattelDocOutInvoiceRQ_Class() : base() { }
        }

        public static BindingList<ChattelDocumentOutputDetailWithAccountancy.ChattelDocOutInvoiceRQ_Class> ChattelDocOutInvoiceRQ(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTOUTPUTDETAILWITHACCOUNTANCY"].QueryDefs["ChattelDocOutInvoiceRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentOutputDetailWithAccountancy.ChattelDocOutInvoiceRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentOutputDetailWithAccountancy.ChattelDocOutInvoiceRQ_Class> ChattelDocOutInvoiceRQ(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTOUTPUTDETAILWITHACCOUNTANCY"].QueryDefs["ChattelDocOutInvoiceRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentOutputDetailWithAccountancy.ChattelDocOutInvoiceRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        virtual protected void CreateManuelReadQRCodesCollection()
        {
            _ManuelReadQRCodes = new ManuelReadQRCode.ChildManuelReadQRCodeCollection(this, new Guid("63c18cf2-92ce-4363-ac67-139bd99ead70"));
            ((ITTChildObjectCollection)_ManuelReadQRCodes).GetChildren();
        }

        protected ManuelReadQRCode.ChildManuelReadQRCodeCollection _ManuelReadQRCodes = null;
        public ManuelReadQRCode.ChildManuelReadQRCodeCollection ManuelReadQRCodes
        {
            get
            {
                if (_ManuelReadQRCodes == null)
                    CreateManuelReadQRCodesCollection();
                return _ManuelReadQRCodes;
            }
        }

        protected ChattelDocumentOutputDetailWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChattelDocumentOutputDetailWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChattelDocumentOutputDetailWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChattelDocumentOutputDetailWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChattelDocumentOutputDetailWithAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHATTELDOCUMENTOUTPUTDETAILWITHACCOUNTANCY", dataRow) { }
        protected ChattelDocumentOutputDetailWithAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHATTELDOCUMENTOUTPUTDETAILWITHACCOUNTANCY", dataRow, isImported) { }
        public ChattelDocumentOutputDetailWithAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChattelDocumentOutputDetailWithAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChattelDocumentOutputDetailWithAccountancy() : base() { }

    }
}