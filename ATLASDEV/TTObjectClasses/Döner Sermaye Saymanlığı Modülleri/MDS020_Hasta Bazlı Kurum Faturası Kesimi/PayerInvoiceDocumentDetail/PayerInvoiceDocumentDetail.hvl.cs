
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerInvoiceDocumentDetail")] 

    /// <summary>
    /// Kurum Faturası Döküman Detayı
    /// </summary>
    public  partial class PayerInvoiceDocumentDetail : AccountDocumentDetail
    {
        public class PayerInvoiceDocumentDetailList : TTObjectCollection<PayerInvoiceDocumentDetail> { }
                    
        public class ChildPayerInvoiceDocumentDetailCollection : TTObject.TTChildObjectCollection<PayerInvoiceDocumentDetail>
        {
            public ChildPayerInvoiceDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerInvoiceDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetPayerInvoiceDocumentDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountedPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTEDPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].AllPropertyDefs["TOTALDISCOUNTEDPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? ProcedureObject
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREOBJECT"]);
                }
            }

            public Object Ptype
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PTYPE"]);
                }
            }

            public OLAP_GetPayerInvoiceDocumentDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPayerInvoiceDocumentDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPayerInvoiceDocumentDetail_Class() : base() { }
        }

        public static BindingList<PayerInvoiceDocumentDetail.OLAP_GetPayerInvoiceDocumentDetail_Class> OLAP_GetPayerInvoiceDocumentDetail(string DOCUMENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].QueryDefs["OLAP_GetPayerInvoiceDocumentDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTID", DOCUMENTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocumentDetail.OLAP_GetPayerInvoiceDocumentDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerInvoiceDocumentDetail.OLAP_GetPayerInvoiceDocumentDetail_Class> OLAP_GetPayerInvoiceDocumentDetail(TTObjectContext objectContext, string DOCUMENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENTDETAIL"].QueryDefs["OLAP_GetPayerInvoiceDocumentDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTID", DOCUMENTID);

            return TTReportNqlObject.QueryObjects<PayerInvoiceDocumentDetail.OLAP_GetPayerInvoiceDocumentDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        protected PayerInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerInvoiceDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerInvoiceDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERINVOICEDOCUMENTDETAIL", dataRow) { }
        protected PayerInvoiceDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERINVOICEDOCUMENTDETAIL", dataRow, isImported) { }
        public PayerInvoiceDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerInvoiceDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerInvoiceDocumentDetail() : base() { }

    }
}