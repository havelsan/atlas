
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaInvoice")] 

    /// <summary>
    /// Medula Fatura Tutar Oku ve Kayıt
    /// </summary>
    public  partial class MedulaInvoice : TTObject
    {
        public class MedulaInvoiceList : TTObjectCollection<MedulaInvoice> { }
                    
        public class ChildMedulaInvoiceCollection : TTObject.TTChildObjectCollection<MedulaInvoice>
        {
            public ChildMedulaInvoiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaInvoiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCompletedInvoicesByDate_Class : TTReportNqlObject 
        {
            public Object Price
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PRICE"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCompletedInvoicesByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedInvoicesByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedInvoicesByDate_Class() : base() { }
        }

        public static BindingList<MedulaInvoice.GetCompletedInvoicesByDate_Class> GetCompletedInvoicesByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICE"].QueryDefs["GetCompletedInvoicesByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MedulaInvoice.GetCompletedInvoicesByDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedulaInvoice.GetCompletedInvoicesByDate_Class> GetCompletedInvoicesByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULAINVOICE"].QueryDefs["GetCompletedInvoicesByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MedulaInvoice.GetCompletedInvoicesByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Son Güncellenme Tarihi
    /// </summary>
        public DateTime? UpDateLast
        {
            get { return (DateTime?)this["UPDATELAST"]; }
            set { this["UPDATELAST"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public DateTime? InvoiceDate
        {
            get { return (DateTime?)this["INVOICEDATE"]; }
            set { this["INVOICEDATE"] = value; }
        }

    /// <summary>
    /// Fatura Referans Numarası
    /// </summary>
        public TTSequence InvoiceReferenceNo
        {
            get { return GetSequence("INVOICEREFERENCENO"); }
        }

    /// <summary>
    /// Trafik Kazası Ödeme Yüzdesi
    /// </summary>
        public int? TrafficAccidentPayPercent
        {
            get { return (int?)this["TRAFFICACCIDENTPAYPERCENT"]; }
            set { this["TRAFFICACCIDENTPAYPERCENT"] = value; }
        }

    /// <summary>
    /// Sonuç Kodu
    /// </summary>
        public string ResultCode
        {
            get { return (string)this["RESULTCODE"]; }
            set { this["RESULTCODE"] = value; }
        }

    /// <summary>
    /// Sonuç Mesajı
    /// </summary>
        public string ResultMessage
        {
            get { return (string)this["RESULTMESSAGE"]; }
            set { this["RESULTMESSAGE"] = value; }
        }

    /// <summary>
    /// Meduladan Dönen Fatura Teslim Numarası
    /// </summary>
        public string InvoiceDeliveryNo
        {
            get { return (string)this["INVOICEDELIVERYNO"]; }
            set { this["INVOICEDELIVERYNO"] = value; }
        }

    /// <summary>
    /// Meduladan Dönen Fatura Tutarı
    /// </summary>
        public Currency? InvoicePrice
        {
            get { return (Currency?)this["INVOICEPRICE"]; }
            set { this["INVOICEPRICE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public MedulaInvoiceStatusEnum? Status
        {
            get { return (MedulaInvoiceStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

        public SpecialityDefinition GreenCardSendingBranch
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("GREENCARDSENDINGBRANCH"); }
            set { this["GREENCARDSENDINGBRANCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Medula Fatura Dönemi
    /// </summary>
        public MedulaInvoiceTermDefinition MedulaInvoiceTerm
        {
            get { return (MedulaInvoiceTermDefinition)((ITTObject)this).GetParent("MEDULAINVOICETERM"); }
            set { this["MEDULAINVOICETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura Kullanıcısı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedulaInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaInvoice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULAINVOICE", dataRow) { }
        protected MedulaInvoice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULAINVOICE", dataRow, isImported) { }
        public MedulaInvoice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaInvoice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaInvoice() : base() { }

    }
}