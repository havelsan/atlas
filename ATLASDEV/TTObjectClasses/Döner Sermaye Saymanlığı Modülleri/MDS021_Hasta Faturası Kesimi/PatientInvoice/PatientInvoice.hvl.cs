
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientInvoice")] 

    /// <summary>
    /// Hasta Faturası İşlemi
    /// </summary>
    public  partial class PatientInvoice : EpisodeAccountAction
    {
        public class PatientInvoiceList : TTObjectCollection<PatientInvoice> { }
                    
        public class ChildPatientInvoiceCollection : TTObject.TTChildObjectCollection<PatientInvoice>
        {
            public ChildPatientInvoiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientInvoiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PatientInvoiceReportInfoQuery_Class : TTReportNqlObject 
        {
            public string PatientName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENT"].AllPropertyDefs["PATIENTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? PatientNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENT"].AllPropertyDefs["PATIENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENT"].AllPropertyDefs["TOTALDISCOUNTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episodeobjid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJID"]);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICE"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Specialitycode
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SPECIALITYCODE"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Guid? Cashier
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIER"]);
                }
            }

            public string Evraksayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKSAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Evraktarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVRAKTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PatientInvoiceReportInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PatientInvoiceReportInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PatientInvoiceReportInfoQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PatientInvoiceReportQuery_Class : TTReportNqlObject 
        {
            public string Pricinggroupdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGGROUPDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENTGROUP"].AllPropertyDefs["GROUPDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Day
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DAY"]);
                }
            }

            public string Trxexternalcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXEXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Trxname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRXNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICEDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public PatientInvoiceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PatientInvoiceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PatientInvoiceReportQuery_Class() : base() { }
        }

        public static class States
        {
            public static Guid Invoiced { get { return new Guid("e33ee662-60d5-4264-82d2-3bb5ffe18211"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("88d6ff82-f56b-49b9-a87c-652355adeb81"); } }
            public static Guid New { get { return new Guid("56313131-8cb5-4b12-aea0-8ec6c7cc2096"); } }
        }

        public static BindingList<PatientInvoice.PatientInvoiceReportInfoQuery_Class> PatientInvoiceReportInfoQuery(string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICE"].QueryDefs["PatientInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<PatientInvoice.PatientInvoiceReportInfoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientInvoice.PatientInvoiceReportInfoQuery_Class> PatientInvoiceReportInfoQuery(TTObjectContext objectContext, string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICE"].QueryDefs["PatientInvoiceReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<PatientInvoice.PatientInvoiceReportInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientInvoice.PatientInvoiceReportQuery_Class> PatientInvoiceReportQuery(string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICE"].QueryDefs["PatientInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<PatientInvoice.PatientInvoiceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientInvoice.PatientInvoiceReportQuery_Class> PatientInvoiceReportQuery(TTObjectContext objectContext, string PARAMINVOICEOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTINVOICE"].QueryDefs["PatientInvoiceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMINVOICEOBJID", PARAMINVOICEOBJID);

            return TTReportNqlObject.QueryObjects<PatientInvoice.PatientInvoiceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta Faturası Dökümanıyla İlişki
    /// </summary>
        public PatientInvoiceDocument PatientInvoiceDocument
        {
            get { return (PatientInvoiceDocument)((ITTObject)this).GetParent("PATIENTINVOICEDOCUMENT"); }
            set { this["PATIENTINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("b316dc0e-6d9a-4f8e-a687-c0a3d11ddec1"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreatePatientInvoiceMaterialsCollection()
        {
            _PatientInvoiceMaterials = new PatientInvoiceMaterial.ChildPatientInvoiceMaterialCollection(this, new Guid("d912b26d-a1e6-458d-bfb8-ce4ec6d6ecbf"));
            ((ITTChildObjectCollection)_PatientInvoiceMaterials).GetChildren();
        }

        protected PatientInvoiceMaterial.ChildPatientInvoiceMaterialCollection _PatientInvoiceMaterials = null;
    /// <summary>
    /// Child collection for Hasta Faturası İşlemiyle İlişki
    /// </summary>
        public PatientInvoiceMaterial.ChildPatientInvoiceMaterialCollection PatientInvoiceMaterials
        {
            get
            {
                if (_PatientInvoiceMaterials == null)
                    CreatePatientInvoiceMaterialsCollection();
                return _PatientInvoiceMaterials;
            }
        }

        virtual protected void CreatePatientInvoiceProceduresCollection()
        {
            _PatientInvoiceProcedures = new PatientInvoiceProcedure.ChildPatientInvoiceProcedureCollection(this, new Guid("ab03c5ba-7b8e-4083-9496-daaa2aeb0181"));
            ((ITTChildObjectCollection)_PatientInvoiceProcedures).GetChildren();
        }

        protected PatientInvoiceProcedure.ChildPatientInvoiceProcedureCollection _PatientInvoiceProcedures = null;
    /// <summary>
    /// Child collection for Hasta Faturası İşlemiyle İlişki
    /// </summary>
        public PatientInvoiceProcedure.ChildPatientInvoiceProcedureCollection PatientInvoiceProcedures
        {
            get
            {
                if (_PatientInvoiceProcedures == null)
                    CreatePatientInvoiceProceduresCollection();
                return _PatientInvoiceProcedures;
            }
        }

        protected PatientInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientInvoice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTINVOICE", dataRow) { }
        protected PatientInvoice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTINVOICE", dataRow, isImported) { }
        protected PatientInvoice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientInvoice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientInvoice() : base() { }

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