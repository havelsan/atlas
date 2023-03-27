
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralInvoice")] 

    /// <summary>
    /// Hizmet Karşılığı Kurum Faturası
    /// </summary>
    public  partial class GeneralInvoice : AccountAction, IWorkListBaseAction
    {
        public class GeneralInvoiceList : TTObjectCollection<GeneralInvoice> { }
                    
        public class ChildGeneralInvoiceCollection : TTObject.TTChildObjectCollection<GeneralInvoice>
        {
            public ChildGeneralInvoiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralInvoiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GeneralInvoiceReportQuery_Class : TTReportNqlObject 
        {
            public string GroupDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUPDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENTGROUP"].AllPropertyDefs["GROUPDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEPROCEDURE"].AllPropertyDefs["UNITPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEPROCEDURE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GeneralInvoiceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneralInvoiceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneralInvoiceReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GeneralInvoiceReportInfoQuery_Class : TTReportNqlObject 
        {
            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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

            public long? Payerid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Payercitycode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payercityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payeraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payerphone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payertaxoffice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTAXOFFICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXOFFICE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payertaxnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTAXNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICE"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Cashier
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIER"]);
                }
            }

            public GeneralInvoiceReportInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GeneralInvoiceReportInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GeneralInvoiceReportInfoQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetGeneralInvoiceByPayer_Class : TTReportNqlObject 
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

            public GetGeneralInvoiceByPayer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGeneralInvoiceByPayer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGeneralInvoiceByPayer_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("5f0b2f96-5401-4718-b70e-3addcc027852"); } }
    /// <summary>
    /// Faturalandı
    /// </summary>
            public static Guid Invoiced { get { return new Guid("807a361e-03c4-4413-8ff6-c7783219f0e5"); } }
            public static Guid Cancelled { get { return new Guid("06d6a8c3-6dde-49cb-b827-34a7821a06a2"); } }
        }

        public static BindingList<GeneralInvoice.GeneralInvoiceReportQuery_Class> GeneralInvoiceReportQuery(string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICE"].QueryDefs["GeneralInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<GeneralInvoice.GeneralInvoiceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralInvoice.GeneralInvoiceReportQuery_Class> GeneralInvoiceReportQuery(TTObjectContext objectContext, string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICE"].QueryDefs["GeneralInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<GeneralInvoice.GeneralInvoiceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<GeneralInvoice.GeneralInvoiceReportInfoQuery_Class> GeneralInvoiceReportInfoQuery(string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICE"].QueryDefs["GeneralInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<GeneralInvoice.GeneralInvoiceReportInfoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralInvoice.GeneralInvoiceReportInfoQuery_Class> GeneralInvoiceReportInfoQuery(TTObjectContext objectContext, string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICE"].QueryDefs["GeneralInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<GeneralInvoice.GeneralInvoiceReportInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<GeneralInvoice.GetGeneralInvoiceByPayer_Class> GetGeneralInvoiceByPayer(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICE"].QueryDefs["GetGeneralInvoiceByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<GeneralInvoice.GetGeneralInvoiceByPayer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralInvoice.GetGeneralInvoiceByPayer_Class> GetGeneralInvoiceByPayer(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICE"].QueryDefs["GetGeneralInvoiceByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<GeneralInvoice.GetGeneralInvoiceByPayer_Class>(objectContext, queryDef, paramList, pi);
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
    /// GeneralInvoiceDocument ile ilişki
    /// </summary>
        public GeneralInvoiceDocument GeneralInvoiceDocument
        {
            get { return (GeneralInvoiceDocument)((ITTObject)this).GetParent("GENERALINVOICEDOCUMENT"); }
            set { this["GENERALINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum Adı
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CommunityPayer CommunityHealthPayer
        {
            get { return (CommunityPayer)((ITTObject)this).GetParent("COMMUNITYHEALTHPAYER"); }
            set { this["COMMUNITYHEALTHPAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateGeneralInvoiceProceduresCollection()
        {
            _GeneralInvoiceProcedures = new GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection(this, new Guid("eafb49d9-7df3-4aa0-9e66-224edc8e67cf"));
            ((ITTChildObjectCollection)_GeneralInvoiceProcedures).GetChildren();
        }

        protected GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection _GeneralInvoiceProcedures = null;
    /// <summary>
    /// Child collection for GeneralInvoice e ilişki
    /// </summary>
        public GeneralInvoiceProcedure.ChildGeneralInvoiceProcedureCollection GeneralInvoiceProcedures
        {
            get
            {
                if (_GeneralInvoiceProcedures == null)
                    CreateGeneralInvoiceProceduresCollection();
                return _GeneralInvoiceProcedures;
            }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("b99d5a85-9e29-4b77-a6da-32fa3258a7d6"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreateCommunityHealthRequestCollection()
        {
            _CommunityHealthRequest = new CommunityHealthRequest.ChildCommunityHealthRequestCollection(this, new Guid("b11794fa-6123-40a1-b5f8-17a03b67799f"));
            ((ITTChildObjectCollection)_CommunityHealthRequest).GetChildren();
        }

        protected CommunityHealthRequest.ChildCommunityHealthRequestCollection _CommunityHealthRequest = null;
        public CommunityHealthRequest.ChildCommunityHealthRequestCollection CommunityHealthRequest
        {
            get
            {
                if (_CommunityHealthRequest == null)
                    CreateCommunityHealthRequestCollection();
                return _CommunityHealthRequest;
            }
        }

        protected GeneralInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralInvoice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALINVOICE", dataRow) { }
        protected GeneralInvoice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALINVOICE", dataRow, isImported) { }
        public GeneralInvoice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralInvoice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralInvoice() : base() { }

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