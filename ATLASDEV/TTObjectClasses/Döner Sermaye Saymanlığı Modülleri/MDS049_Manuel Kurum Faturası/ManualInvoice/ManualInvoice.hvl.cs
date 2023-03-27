
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManualInvoice")] 

    /// <summary>
    /// Manuel Kurum Faturası
    /// </summary>
    public  partial class ManualInvoice : AccountAction, IWorkListBaseAction
    {
        public class ManualInvoiceList : TTObjectCollection<ManualInvoice> { }
                    
        public class ChildManualInvoiceCollection : TTObject.TTChildObjectCollection<ManualInvoice>
        {
            public ChildManualInvoiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManualInvoiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetManualInvoiceByPayer_Class : TTReportNqlObject 
        {
            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totalprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                }
            }

            public Object Patientcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCOUNT"]);
                }
            }

            public GetManualInvoiceByPayer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetManualInvoiceByPayer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetManualInvoiceByPayer_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProceduresByMedulaInvoice_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Procedure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEPROCEDURE"].AllPropertyDefs["PROCEDURE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEPROCEDURE"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEPROCEDURE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetProceduresByMedulaInvoice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProceduresByMedulaInvoice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProceduresByMedulaInvoice_Class() : base() { }
        }

        [Serializable] 

        public partial class ManualInvoiceReportInfoQuery_Class : TTReportNqlObject 
        {
            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SendingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["SENDINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string SendingNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDINGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["SENDINGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["PATIENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccountantName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["ACCOUNTANTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccountantTitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANTTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["ACCOUNTANTTITLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Payercode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payercity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Accountantname1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANTNAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["ACCOUNTANTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Accountanttitle1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANTTITLE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["ACCOUNTANTTITLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? KDVRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KDVRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["KDVRATE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public ManualInvoiceReportInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ManualInvoiceReportInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ManualInvoiceReportInfoQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("3921f8bd-eb7b-4172-ab0e-fe5e4b0b813e"); } }
            public static Guid Invoiced { get { return new Guid("8c0f442e-ecbe-44ce-bf6a-d20cc7bfabdb"); } }
            public static Guid Cancelled { get { return new Guid("7a2db06e-1e64-429c-9bed-8022e2ca382b"); } }
        }

        public static BindingList<ManualInvoice.GetManualInvoiceByPayer_Class> GetManualInvoiceByPayer(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].QueryDefs["GetManualInvoiceByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<ManualInvoice.GetManualInvoiceByPayer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ManualInvoice.GetManualInvoiceByPayer_Class> GetManualInvoiceByPayer(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].QueryDefs["GetManualInvoiceByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<ManualInvoice.GetManualInvoiceByPayer_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ManualInvoice.GetProceduresByMedulaInvoice_Class> GetProceduresByMedulaInvoice(string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].QueryDefs["GetProceduresByMedulaInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<ManualInvoice.GetProceduresByMedulaInvoice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ManualInvoice.GetProceduresByMedulaInvoice_Class> GetProceduresByMedulaInvoice(TTObjectContext objectContext, string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].QueryDefs["GetProceduresByMedulaInvoice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<ManualInvoice.GetProceduresByMedulaInvoice_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ManualInvoice.ManualInvoiceReportInfoQuery_Class> ManualInvoiceReportInfoQuery(string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].QueryDefs["ManualInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<ManualInvoice.ManualInvoiceReportInfoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ManualInvoice.ManualInvoiceReportInfoQuery_Class> ManualInvoiceReportInfoQuery(TTObjectContext objectContext, string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICE"].QueryDefs["ManualInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<ManualInvoice.ManualInvoiceReportInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sevk Numarası
    /// </summary>
        public string SendingNo
        {
            get { return (string)this["SENDINGNO"]; }
            set { this["SENDINGNO"] = value; }
        }

    /// <summary>
    /// Döse İşletme Müdürü Adı
    /// </summary>
        public string AccountantName
        {
            get { return (string)this["ACCOUNTANTNAME"]; }
            set { this["ACCOUNTANTNAME"] = value; }
        }

    /// <summary>
    /// Döse İşletme Müdürü Ünvanı
    /// </summary>
        public string AccountantTitle
        {
            get { return (string)this["ACCOUNTANTTITLE"]; }
            set { this["ACCOUNTANTTITLE"] = value; }
        }

    /// <summary>
    /// KDV Oranı(%)
    /// </summary>
        public int? KDVRate
        {
            get { return (int?)this["KDVRATE"]; }
            set { this["KDVRATE"] = value; }
        }

    /// <summary>
    /// Kdv siz toplam tutar
    /// </summary>
        public Currency? TotalPriceWithoutKDV
        {
            get { return (Currency?)this["TOTALPRICEWITHOUTKDV"]; }
            set { this["TOTALPRICEWITHOUTKDV"] = value; }
        }

    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

    /// <summary>
    /// Sevk Tarihi
    /// </summary>
        public DateTime? SendingDate
        {
            get { return (DateTime?)this["SENDINGDATE"]; }
            set { this["SENDINGDATE"] = value; }
        }

    /// <summary>
    /// ManualInvoiceDocument ile ilişki
    /// </summary>
        public ManualInvoiceDocument ManualInvoiceDocument
        {
            get { return (ManualInvoiceDocument)((ITTObject)this).GetParent("MANUALINVOICEDOCUMENT"); }
            set { this["MANUALINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum Adı
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("06b70fa9-d6cd-4066-9f0a-fd7d166a1090"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreateManualInvoiceProceduresCollection()
        {
            _ManualInvoiceProcedures = new ManualInvoiceProcedure.ChildManualInvoiceProcedureCollection(this, new Guid("a78f3bdd-24fd-4938-bc4a-ae57ddff6848"));
            ((ITTChildObjectCollection)_ManualInvoiceProcedures).GetChildren();
        }

        protected ManualInvoiceProcedure.ChildManualInvoiceProcedureCollection _ManualInvoiceProcedures = null;
    /// <summary>
    /// Child collection for ManualInvoice ile ilişki
    /// </summary>
        public ManualInvoiceProcedure.ChildManualInvoiceProcedureCollection ManualInvoiceProcedures
        {
            get
            {
                if (_ManualInvoiceProcedures == null)
                    CreateManualInvoiceProceduresCollection();
                return _ManualInvoiceProcedures;
            }
        }

        protected ManualInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManualInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManualInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManualInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManualInvoice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANUALINVOICE", dataRow) { }
        protected ManualInvoice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANUALINVOICE", dataRow, isImported) { }
        public ManualInvoice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManualInvoice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManualInvoice() : base() { }

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