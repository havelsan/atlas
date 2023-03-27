
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralReceipt")] 

    /// <summary>
    /// Hizmet Karşılığı Muhasebe Yetkilisi Mutemedi Alındısı
    /// </summary>
    public  partial class GeneralReceipt : AccountAction, IWorkListBaseAction
    {
        public class GeneralReceiptList : TTObjectCollection<GeneralReceipt> { }
                    
        public class ChildGeneralReceiptCollection : TTObject.TTChildObjectCollection<GeneralReceipt>
        {
            public ChildGeneralReceiptCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralReceiptCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GeneralReceiptReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPT"].AllPropertyDefs["CASHOFFICENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPTDOCUMENT"].AllPropertyDefs["SPECIALNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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

            public Guid? CurrencyType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENCYTYPE"]);
                }
            }

            public GeneralReceiptReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneralReceiptReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneralReceiptReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GeneralReceiptDetailsQuery_Class : TTReportNqlObject 
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

            public GeneralReceiptDetailsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneralReceiptDetailsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneralReceiptDetailsQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GeneralReceiptCreditCardReportQuery_Class : TTReportNqlObject 
        {
            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPT"].AllPropertyDefs["CASHOFFICENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPTDOCUMENT"].AllPropertyDefs["CREDITCARDSPECIALNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPTDOCUMENT"].AllPropertyDefs["CREDITCARDDOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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

            public GeneralReceiptCreditCardReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneralReceiptCreditCardReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneralReceiptCreditCardReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("a9a6e69f-8007-4526-a3cd-4962af105f9c"); } }
            public static Guid Completed { get { return new Guid("6726f227-9303-4fa1-93a0-b80d6965dc9a"); } }
            public static Guid Cancelled { get { return new Guid("965832a9-dbe9-4972-bb3a-3f1dc336d44e"); } }
        }

        public static BindingList<GeneralReceipt.GeneralReceiptReportQuery_Class> GeneralReceiptReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPT"].QueryDefs["GeneralReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralReceipt.GeneralReceiptReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralReceipt.GeneralReceiptReportQuery_Class> GeneralReceiptReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPT"].QueryDefs["GeneralReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralReceipt.GeneralReceiptReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<GeneralReceipt.GeneralReceiptDetailsQuery_Class> GeneralReceiptDetailsQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPT"].QueryDefs["GeneralReceiptDetailsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralReceipt.GeneralReceiptDetailsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralReceipt.GeneralReceiptDetailsQuery_Class> GeneralReceiptDetailsQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPT"].QueryDefs["GeneralReceiptDetailsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralReceipt.GeneralReceiptDetailsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<GeneralReceipt.GeneralReceiptCreditCardReportQuery_Class> GeneralReceiptCreditCardReportQuery(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPT"].QueryDefs["GeneralReceiptCreditCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralReceipt.GeneralReceiptCreditCardReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralReceipt.GeneralReceiptCreditCardReportQuery_Class> GeneralReceiptCreditCardReportQuery(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALRECEIPT"].QueryDefs["GeneralReceiptCreditCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<GeneralReceipt.GeneralReceiptCreditCardReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Toplam Ödeme
    /// </summary>
        public Currency? TotalPayment
        {
            get { return (Currency?)this["TOTALPAYMENT"]; }
            set { this["TOTALPAYMENT"] = value; }
        }

    /// <summary>
    /// Hizmetler entagrasyon ile hazır mı geliyor?
    /// </summary>
        public bool? IsIntegration
        {
            get { return (bool?)this["ISINTEGRATION"]; }
            set { this["ISINTEGRATION"] = value; }
        }

    /// <summary>
    /// GeneralReceiptDocument ile ilişki
    /// </summary>
        public GeneralReceiptDocument GeneralReceiptDocument
        {
            get { return (GeneralReceiptDocument)((ITTObject)this).GetParent("GENERALRECEIPTDOCUMENT"); }
            set { this["GENERALRECEIPTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateGeneralReceiptProceduresCollection()
        {
            _GeneralReceiptProcedures = new GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection(this, new Guid("33a584d0-6d23-4193-9206-8bdc675ff8f1"));
            ((ITTChildObjectCollection)_GeneralReceiptProcedures).GetChildren();
        }

        protected GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection _GeneralReceiptProcedures = null;
    /// <summary>
    /// Child collection for GeneralReceipt e ilişki
    /// </summary>
        public GeneralReceiptProcedure.ChildGeneralReceiptProcedureCollection GeneralReceiptProcedures
        {
            get
            {
                if (_GeneralReceiptProcedures == null)
                    CreateGeneralReceiptProceduresCollection();
                return _GeneralReceiptProcedures;
            }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("434ab2b7-a716-4d6b-9f48-92e8469f64b7"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected GeneralReceipt(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralReceipt(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralReceipt(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralReceipt(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralReceipt(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALRECEIPT", dataRow) { }
        protected GeneralReceipt(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALRECEIPT", dataRow, isImported) { }
        public GeneralReceipt(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralReceipt(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralReceipt() : base() { }

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