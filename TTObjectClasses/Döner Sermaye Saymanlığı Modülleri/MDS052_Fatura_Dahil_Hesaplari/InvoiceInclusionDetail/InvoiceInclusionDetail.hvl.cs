
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceInclusionDetail")] 

    /// <summary>
    /// Fatura Dahillik Detay Tanımları
    /// </summary>
    public  partial class InvoiceInclusionDetail : TTDefinitionSet
    {
        public class InvoiceInclusionDetailList : TTObjectCollection<InvoiceInclusionDetail> { }
                    
        public class ChildInvoiceInclusionDetailCollection : TTObject.TTChildObjectCollection<InvoiceInclusionDetail>
        {
            public ChildInvoiceInclusionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceInclusionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceInclusionDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONDETAIL"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public InvoiceInclusionDetailTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONDETAIL"].AllPropertyDefs["TYPE"].DataType;
                    return (InvoiceInclusionDetailTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONDETAIL"].AllPropertyDefs["VALUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetInvoiceInclusionDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceInclusionDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceInclusionDetail_Class() : base() { }
        }

        public static BindingList<InvoiceInclusionDetail.GetInvoiceInclusionDetail_Class> GetInvoiceInclusionDetail(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONDETAIL"].QueryDefs["GetInvoiceInclusionDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceInclusionDetail.GetInvoiceInclusionDetail_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceInclusionDetail.GetInvoiceInclusionDetail_Class> GetInvoiceInclusionDetail(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONDETAIL"].QueryDefs["GetInvoiceInclusionDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceInclusionDetail.GetInvoiceInclusionDetail_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tip
    /// </summary>
        public InvoiceInclusionDetailTypeEnum? Type
        {
            get { return (InvoiceInclusionDetailTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Değer
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        virtual protected void CreateIIMDetailsCollection()
        {
            _IIMDetails = new IIMDetail.ChildIIMDetailCollection(this, new Guid("220c5056-a132-42da-9af2-039949ed4b61"));
            ((ITTChildObjectCollection)_IIMDetails).GetChildren();
        }

        protected IIMDetail.ChildIIMDetailCollection _IIMDetails = null;
    /// <summary>
    /// Child collection for Kural Detay Bilgisi
    /// </summary>
        public IIMDetail.ChildIIMDetailCollection IIMDetails
        {
            get
            {
                if (_IIMDetails == null)
                    CreateIIMDetailsCollection();
                return _IIMDetails;
            }
        }

        protected InvoiceInclusionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceInclusionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceInclusionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceInclusionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceInclusionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEINCLUSIONDETAIL", dataRow) { }
        protected InvoiceInclusionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEINCLUSIONDETAIL", dataRow, isImported) { }
        public InvoiceInclusionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceInclusionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceInclusionDetail() : base() { }

    }
}