
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubCashOfficeOperation")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Tahsilat İşlemi
    /// </summary>
    public  partial class SubCashOfficeOperation : AccountAction, IWorkListBaseAction
    {
        public class SubCashOfficeOperationList : TTObjectCollection<SubCashOfficeOperation> { }
                    
        public class ChildSubCashOfficeOperationCollection : TTObject.TTChildObjectCollection<SubCashOfficeOperation>
        {
            public ChildSubCashOfficeOperationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubCashOfficeOperationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ReceiptReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICEOPERATION"].AllPropertyDefs["CASHOFFICENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICERECEIPTDOC"].AllPropertyDefs["PAYEENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICERECEIPTDOC"].AllPropertyDefs["SPECIALNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICERECEIPTDOC"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICERECEIPTDOC"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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

            public string Moneyreceivedtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONEYRECEIVEDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEPAYMENTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public ReceiptReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceiptReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceiptReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ReceiptCreditCardReportQuery_Class : TTReportNqlObject 
        {
            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICEOPERATION"].AllPropertyDefs["CASHOFFICENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICERECEIPTDOC"].AllPropertyDefs["PAYEENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICERECEIPTDOC"].AllPropertyDefs["CREDITCARDSPECIALNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICERECEIPTDOC"].AllPropertyDefs["CREDITCARDDOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICERECEIPTDOC"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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

            public string Moneyreceivedtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONEYRECEIVEDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINCASHOFFICEPAYMENTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public ReceiptCreditCardReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceiptCreditCardReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceiptCreditCardReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("07879c05-a02b-4f01-96b5-4a0b5ed36e5e"); } }
            public static Guid Completed { get { return new Guid("995167f6-406e-4d2d-9049-6076426b39ad"); } }
            public static Guid Cancelled { get { return new Guid("a11a9f86-39a8-4448-8e1f-7fe9111d677e"); } }
        }

        public static BindingList<SubCashOfficeOperation.ReceiptReportQuery_Class> ReceiptReportQuery(string PARAMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICEOPERATION"].QueryDefs["ReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return TTReportNqlObject.QueryObjects<SubCashOfficeOperation.ReceiptReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubCashOfficeOperation.ReceiptReportQuery_Class> ReceiptReportQuery(TTObjectContext objectContext, string PARAMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICEOPERATION"].QueryDefs["ReceiptReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return TTReportNqlObject.QueryObjects<SubCashOfficeOperation.ReceiptReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SubCashOfficeOperation.ReceiptCreditCardReportQuery_Class> ReceiptCreditCardReportQuery(string PARAMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICEOPERATION"].QueryDefs["ReceiptCreditCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return TTReportNqlObject.QueryObjects<SubCashOfficeOperation.ReceiptCreditCardReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SubCashOfficeOperation.ReceiptCreditCardReportQuery_Class> ReceiptCreditCardReportQuery(TTObjectContext objectContext, string PARAMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBCASHOFFICEOPERATION"].QueryDefs["ReceiptCreditCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return TTReportNqlObject.QueryObjects<SubCashOfficeOperation.ReceiptCreditCardReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// SubCashOfficeReceiptDocument ile ilişki
    /// </summary>
        public SubCashOfficeReceiptDoc SubCashOfficeReceiptDocument
        {
            get { return (SubCashOfficeReceiptDoc)((ITTObject)this).GetParent("SUBCASHOFFICERECEIPTDOCUMENT"); }
            set { this["SUBCASHOFFICERECEIPTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("00d0d576-5bc8-41fa-bca6-6c498f5f4736"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected SubCashOfficeOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubCashOfficeOperation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubCashOfficeOperation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubCashOfficeOperation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubCashOfficeOperation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBCASHOFFICEOPERATION", dataRow) { }
        protected SubCashOfficeOperation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBCASHOFFICEOPERATION", dataRow, isImported) { }
        public SubCashOfficeOperation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubCashOfficeOperation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubCashOfficeOperation() : base() { }

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