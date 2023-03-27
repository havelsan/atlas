
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainCashOfficeOperation")] 

    /// <summary>
    /// Vezne Tahsilat İşlemi
    /// </summary>
    public  partial class MainCashOfficeOperation : AccountAction, IWorkListBaseAction
    {
        public class MainCashOfficeOperationList : TTObjectCollection<MainCashOfficeOperation> { }
                    
        public class ChildMainCashOfficeOperationCollection : TTObject.TTChildObjectCollection<MainCashOfficeOperation>
        {
            public ChildMainCashOfficeOperationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainCashOfficeOperationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CashOfficeReceiptDocumentReportQuery_Class : TTReportNqlObject 
        {
            public string PayeeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PayeeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["PAYEEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PayeeUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEEUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["PAYEEUNIQUEREFNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payeephone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["PHONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Moneyreceivedtypename
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONEYRECEIVEDTYPENAME"]);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["SPECIALNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public PaymentTypeEnum? PaymentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["PAYMENTTYPE"].DataType;
                    return (PaymentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CashOfficeReceiptDocumentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CashOfficeReceiptDocumentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CashOfficeReceiptDocumentReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ChattelReceiptReportQuery_Class : TTReportNqlObject 
        {
            public string PayeeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PayeeAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYEEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["PAYEEADDRESS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Moneyreceivedtypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONEYRECEIVEDTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEPAYMENTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["SPECIALNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public ChattelReceiptReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ChattelReceiptReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ChattelReceiptReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCashOfficeOpsByDateAndType_Class : TTReportNqlObject 
        {
            public DateTime? Veznealinditarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VEZNEALINDITARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Tahsilatturu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TAHSILATTURU"]);
                }
            }

            public string Uniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["PAYEEUNIQUEREFNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Alindino
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALINDINO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Tahsilattutari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAHSILATTUTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICERECEIPTDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetCashOfficeOpsByDateAndType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCashOfficeOpsByDateAndType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCashOfficeOpsByDateAndType_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fcf04714-61e6-414d-96d6-734e14765285"); } }
            public static Guid New { get { return new Guid("12a77590-ff12-4b23-9d9b-528a524fa9a1"); } }
            public static Guid Completed { get { return new Guid("416de941-d53c-4bec-914e-bc8de1ba1b0d"); } }
        }

        public static BindingList<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class> CashOfficeReceiptDocumentReportQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].QueryDefs["CashOfficeReceiptDocumentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class> CashOfficeReceiptDocumentReportQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].QueryDefs["CashOfficeReceiptDocumentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MainCashOfficeOperation.ChattelReceiptReportQuery_Class> ChattelReceiptReportQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].QueryDefs["ChattelReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<MainCashOfficeOperation.ChattelReceiptReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MainCashOfficeOperation.ChattelReceiptReportQuery_Class> ChattelReceiptReportQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].QueryDefs["ChattelReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<MainCashOfficeOperation.ChattelReceiptReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MainCashOfficeOperation.GetCashOfficeOpsByDateAndType_Class> GetCashOfficeOpsByDateAndType(DateTime STARTDATE, DateTime ENDDATE, IList<string> TYPE, int TYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].QueryDefs["GetCashOfficeOpsByDateAndType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("TYPE", TYPE);
            paramList.Add("TYPECONTROL", TYPECONTROL);

            return TTReportNqlObject.QueryObjects<MainCashOfficeOperation.GetCashOfficeOpsByDateAndType_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MainCashOfficeOperation.GetCashOfficeOpsByDateAndType_Class> GetCashOfficeOpsByDateAndType(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> TYPE, int TYPECONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEOPERATION"].QueryDefs["GetCashOfficeOpsByDateAndType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("TYPE", TYPE);
            paramList.Add("TYPECONTROL", TYPECONTROL);

            return TTReportNqlObject.QueryObjects<MainCashOfficeOperation.GetCashOfficeOpsByDateAndType_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Vezne Tahsilat Alındısı İlişkisi
    /// </summary>
        public CashOfficeReceiptDocument CashOfficeReceiptDocument
        {
            get { return (CashOfficeReceiptDocument)((ITTObject)this).GetParent("CASHOFFICERECEIPTDOCUMENT"); }
            set { this["CASHOFFICERECEIPTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("a35e7d98-0b3c-47a6-a4a2-ba817d1a898d"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreateSubmittedCashierLogsCollection()
        {
            _SubmittedCashierLogs = new SubmittedCashierLog.ChildSubmittedCashierLogCollection(this, new Guid("ef2e6616-6ab1-49c1-8781-93e3cb0940c0"));
            ((ITTChildObjectCollection)_SubmittedCashierLogs).GetChildren();
        }

        protected SubmittedCashierLog.ChildSubmittedCashierLogCollection _SubmittedCashierLogs = null;
    /// <summary>
    /// Child collection for Vezne Tahsilat İşlemiyle İlişki
    /// </summary>
        public SubmittedCashierLog.ChildSubmittedCashierLogCollection SubmittedCashierLogs
        {
            get
            {
                if (_SubmittedCashierLogs == null)
                    CreateSubmittedCashierLogsCollection();
                return _SubmittedCashierLogs;
            }
        }

        protected MainCashOfficeOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainCashOfficeOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainCashOfficeOperation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainCashOfficeOperation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainCashOfficeOperation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINCASHOFFICEOPERATION", dataRow) { }
        protected MainCashOfficeOperation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINCASHOFFICEOPERATION", dataRow, isImported) { }
        public MainCashOfficeOperation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainCashOfficeOperation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainCashOfficeOperation() : base() { }

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