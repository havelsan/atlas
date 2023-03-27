
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoicePosting")] 

    /// <summary>
    /// Fatura Gönderme İşlemi
    /// </summary>
    public  partial class InvoicePosting : AccountAction, IWorkListBaseAction
    {
        public class InvoicePostingList : TTObjectCollection<InvoicePosting> { }
                    
        public class ChildInvoicePostingCollection : TTObject.TTChildObjectCollection<InvoicePosting>
        {
            public ChildInvoicePostingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoicePostingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class InvoicePostingListReportQuery_Class : TTReportNqlObject 
        {
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

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Patientno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public InvoicePostingListReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoicePostingListReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoicePostingListReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class InvoicePostingPreReportQuery_Class : TTReportNqlObject 
        {
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PostingNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POSTINGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].AllPropertyDefs["POSTINGNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Invoiceamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICEAMOUNT"]);
                }
            }

            public Object Totalinvoiceprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINVOICEPRICE"]);
                }
            }

            public InvoicePostingPreReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoicePostingPreReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoicePostingPreReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class InvoicePostingPayerQuery_Class : TTReportNqlObject 
        {
            public Guid? Payerobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYEROBJECTID"]);
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PostingNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POSTINGNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].AllPropertyDefs["POSTINGNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Invoiceamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INVOICEAMOUNT"]);
                }
            }

            public Object Totalinvoiceprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALINVOICEPRICE"]);
                }
            }

            public InvoicePostingPayerQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoicePostingPayerQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoicePostingPayerQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class InvoicePostingListQuery_Class : TTReportNqlObject 
        {
            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Patientno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public InvoicePostingListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoicePostingListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoicePostingListQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid InvoicePosted { get { return new Guid("bc46eed6-44b3-41f3-8cad-122b4fc35eaf"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("564c90f8-0b78-4e22-a51a-6b301cefe810"); } }
            public static Guid New { get { return new Guid("b82e8007-fc75-4adb-aaf9-9395a8914931"); } }
        }

        public static BindingList<InvoicePosting.InvoicePostingListReportQuery_Class> InvoicePostingListReportQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].QueryDefs["InvoicePostingListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<InvoicePosting.InvoicePostingListReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoicePosting.InvoicePostingListReportQuery_Class> InvoicePostingListReportQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].QueryDefs["InvoicePostingListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<InvoicePosting.InvoicePostingListReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoicePosting.InvoicePostingPreReportQuery_Class> InvoicePostingPreReportQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].QueryDefs["InvoicePostingPreReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<InvoicePosting.InvoicePostingPreReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoicePosting.InvoicePostingPreReportQuery_Class> InvoicePostingPreReportQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].QueryDefs["InvoicePostingPreReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<InvoicePosting.InvoicePostingPreReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoicePosting.InvoicePostingPayerQuery_Class> InvoicePostingPayerQuery(string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].QueryDefs["InvoicePostingPayerQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<InvoicePosting.InvoicePostingPayerQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoicePosting.InvoicePostingPayerQuery_Class> InvoicePostingPayerQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].QueryDefs["InvoicePostingPayerQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);

            return TTReportNqlObject.QueryObjects<InvoicePosting.InvoicePostingPayerQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoicePosting.InvoicePostingListQuery_Class> InvoicePostingListQuery(string PARAMDEBFOLOBJID, string PARAMPAYEROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].QueryDefs["InvoicePostingListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);
            paramList.Add("PARAMPAYEROBJECTID", PARAMPAYEROBJECTID);

            return TTReportNqlObject.QueryObjects<InvoicePosting.InvoicePostingListQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoicePosting.InvoicePostingListQuery_Class> InvoicePostingListQuery(TTObjectContext objectContext, string PARAMDEBFOLOBJID, string PARAMPAYEROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEPOSTING"].QueryDefs["InvoicePostingListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBFOLOBJID", PARAMDEBFOLOBJID);
            paramList.Add("PARAMPAYEROBJECTID", PARAMPAYEROBJECTID);

            return TTReportNqlObject.QueryObjects<InvoicePosting.InvoicePostingListQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Fatura Tipi
    /// </summary>
        public InvoicePostingInvoiceTypeEnum? InvoiceType
        {
            get { return (InvoicePostingInvoiceTypeEnum?)(int?)this["INVOICETYPE"]; }
            set { this["INVOICETYPE"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi (Bitiş)
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Fatura No (Başlangıç)
    /// </summary>
        public string InvoiceDocumentNoStart
        {
            get { return (string)this["INVOICEDOCUMENTNOSTART"]; }
            set { this["INVOICEDOCUMENTNOSTART"] = value; }
        }

    /// <summary>
    /// Gönderi Numarası
    /// </summary>
        public string PostingNumber
        {
            get { return (string)this["POSTINGNUMBER"]; }
            set { this["POSTINGNUMBER"] = value; }
        }

    /// <summary>
    /// Kurum Bitiş Kodu
    /// </summary>
        public long? PayerCodeStart
        {
            get { return (long?)this["PAYERCODESTART"]; }
            set { this["PAYERCODESTART"] = value; }
        }

    /// <summary>
    /// Kurum Bitiş Kodu
    /// </summary>
        public long? PayerCodeEnd
        {
            get { return (long?)this["PAYERCODEEND"]; }
            set { this["PAYERCODEEND"] = value; }
        }

    /// <summary>
    /// Hastanın Durumu
    /// </summary>
        public InvoicePostingPatientStatusEnum? PatientStatus
        {
            get { return (InvoicePostingPatientStatusEnum?)(int?)this["PATIENTSTATUS"]; }
            set { this["PATIENTSTATUS"] = value; }
        }

    /// <summary>
    /// Fatura Tarihi (Başlangıç)
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Fatura No (Bitiş)
    /// </summary>
        public string InvoiceDocumentNoEnd
        {
            get { return (string)this["INVOICEDOCUMENTNOEND"]; }
            set { this["INVOICEDOCUMENTNOEND"] = value; }
        }

    /// <summary>
    /// Kurumla İlişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInvoicePostDetailsCollection()
        {
            _InvoicePostDetails = new InvoicePostDetail.ChildInvoicePostDetailCollection(this, new Guid("3bf7508f-57da-4b62-bcc0-e2d246880696"));
            ((ITTChildObjectCollection)_InvoicePostDetails).GetChildren();
        }

        protected InvoicePostDetail.ChildInvoicePostDetailCollection _InvoicePostDetails = null;
    /// <summary>
    /// Child collection for Fatura Göndermeyle İlişki
    /// </summary>
        public InvoicePostDetail.ChildInvoicePostDetailCollection InvoicePostDetails
        {
            get
            {
                if (_InvoicePostDetails == null)
                    CreateInvoicePostDetailsCollection();
                return _InvoicePostDetails;
            }
        }

        protected InvoicePosting(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoicePosting(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoicePosting(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoicePosting(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoicePosting(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEPOSTING", dataRow) { }
        protected InvoicePosting(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEPOSTING", dataRow, isImported) { }
        public InvoicePosting(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoicePosting(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoicePosting() : base() { }

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