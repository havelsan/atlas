
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebenturePayment")] 

    /// <summary>
    /// Senet Tahsilat
    /// </summary>
    public  partial class DebenturePayment : EpisodeAccountAction
    {
        public class DebenturePaymentList : TTObjectCollection<DebenturePayment> { }
                    
        public class ChildDebenturePaymentCollection : TTObject.TTChildObjectCollection<DebenturePayment>
        {
            public ChildDebenturePaymentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebenturePaymentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DebPaymentReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENT"].AllPropertyDefs["CASHOFFICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PayeeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SpecialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENTDOCUMENT"].AllPropertyDefs["SPECIALNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Cashpayment
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CASHPAYMENT"]);
                }
            }

            public DebPaymentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DebPaymentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DebPaymentReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class DebPaymentReportDetQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalDiscountPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALDISCOUNTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? VATPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VATPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["VATPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTDETAIL"].AllPropertyDefs["TOTALDISCOUNTEDPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DebPaymentReportDetQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DebPaymentReportDetQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DebPaymentReportDetQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class DebPaymentCrCardReportQuery_Class : TTReportNqlObject 
        {
            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENT"].AllPropertyDefs["CASHOFFICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PayeeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CreditCardSpecialNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDSPECIALNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENTDOCUMENT"].AllPropertyDefs["CREDITCARDSPECIALNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string CreditCardDocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREDITCARDDOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENTDOCUMENT"].AllPropertyDefs["CREDITCARDDOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Creditcardpayment
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CREDITCARDPAYMENT"]);
                }
            }

            public Object Cardowner
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CARDOWNER"]);
                }
            }

            public DebPaymentCrCardReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DebPaymentCrCardReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DebPaymentCrCardReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("b727a5df-940f-4a2e-817a-0d5a64b60326"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("f252e382-541e-43ad-acb8-100aaf0704e6"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("62bd491d-ea49-49a6-8cea-f684754fdd23"); } }
        }

        public static BindingList<DebenturePayment.DebPaymentReportQuery_Class> DebPaymentReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENT"].QueryDefs["DebPaymentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<DebenturePayment.DebPaymentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DebenturePayment.DebPaymentReportQuery_Class> DebPaymentReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENT"].QueryDefs["DebPaymentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<DebenturePayment.DebPaymentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DebenturePayment.DebPaymentReportDetQuery_Class> DebPaymentReportDetQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENT"].QueryDefs["DebPaymentReportDetQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<DebenturePayment.DebPaymentReportDetQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DebenturePayment.DebPaymentReportDetQuery_Class> DebPaymentReportDetQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENT"].QueryDefs["DebPaymentReportDetQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<DebenturePayment.DebPaymentReportDetQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DebenturePayment.DebPaymentCrCardReportQuery_Class> DebPaymentCrCardReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENT"].QueryDefs["DebPaymentCrCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<DebenturePayment.DebPaymentCrCardReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DebenturePayment.DebPaymentCrCardReportQuery_Class> DebPaymentCrCardReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREPAYMENT"].QueryDefs["DebPaymentCrCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<DebenturePayment.DebPaymentCrCardReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ödeme Tutarı
    /// </summary>
        public Currency? PaymentPrice
        {
            get { return (Currency?)this["PAYMENTPRICE"]; }
            set { this["PAYMENTPRICE"] = value; }
        }

    /// <summary>
    /// Senet Tahsilat Dökümanıyla İlişkisi
    /// </summary>
        public DebenturePaymentDocument DebenturePaymentDocument
        {
            get { return (DebenturePaymentDocument)((ITTObject)this).GetParent("DEBENTUREPAYMENTDOCUMENT"); }
            set { this["DEBENTUREPAYMENTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("a3a08efa-4d60-4256-b523-36b43fe7963f"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreatePatientDebenturesCollection()
        {
            _PatientDebentures = new DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection(this, new Guid("5de8ea74-07c2-4a7c-92dd-8bbb972a9c2e"));
            ((ITTChildObjectCollection)_PatientDebentures).GetChildren();
        }

        protected DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection _PatientDebentures = null;
    /// <summary>
    /// Child collection for Senet Tahsilat İşlemiyle İlişki
    /// </summary>
        public DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection PatientDebentures
        {
            get
            {
                if (_PatientDebentures == null)
                    CreatePatientDebenturesCollection();
                return _PatientDebentures;
            }
        }

        protected DebenturePayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebenturePayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebenturePayment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebenturePayment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebenturePayment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREPAYMENT", dataRow) { }
        protected DebenturePayment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREPAYMENT", dataRow, isImported) { }
        public DebenturePayment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebenturePayment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebenturePayment() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}