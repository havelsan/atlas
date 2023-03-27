
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralInvoiceDocument")] 

    public  partial class GeneralInvoiceDocument : AccountDocument
    {
        public class GeneralInvoiceDocumentList : TTObjectCollection<GeneralInvoiceDocument> { }
                    
        public class ChildGeneralInvoiceDocumentCollection : TTObject.TTChildObjectCollection<GeneralInvoiceDocument>
        {
            public ChildGeneralInvoiceDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralInvoiceDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGeneralInvoiceDocumentByPayer_Class : TTReportNqlObject 
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

            public Object Paidprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PAIDPRICE"]);
                }
            }

            public Object Cutoffprice
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CUTOFFPRICE"]);
                }
            }

            public GetGeneralInvoiceDocumentByPayer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGeneralInvoiceDocumentByPayer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGeneralInvoiceDocumentByPayer_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("3a0934f8-ee45-49a7-b609-b8c5e78229b6"); } }
            public static Guid Send { get { return new Guid("048e498f-7ee8-4fd8-8627-fbfb3b251c03"); } }
            public static Guid Cancelled { get { return new Guid("54551c74-4ceb-449a-83fd-3e0210d8594b"); } }
            public static Guid Paid { get { return new Guid("3f3c209a-0754-477f-96b9-75f99ce386e0"); } }
        }

        public static BindingList<GeneralInvoiceDocument> GetByPayerAndStateAndDocumentNo(TTObjectContext objectContext, string PARAMPAYER, string PARAMSTATE, string PARAMDOCNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].QueryDefs["GetByPayerAndStateAndDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMDOCNO", PARAMDOCNO);

            return ((ITTQuery)objectContext).QueryObjects<GeneralInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<GeneralInvoiceDocument> GetByPayerAndDateAndState(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, string PARAMPAYER, string PARAMSTATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].QueryDefs["GetByPayerAndDateAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTATE", PARAMSTATE);

            return ((ITTQuery)objectContext).QueryObjects<GeneralInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<GeneralInvoiceDocument> GetByPayerAndStateAndDocumentNoInterval(TTObjectContext objectContext, string PARAMPAYER, string PARAMSTATE, string PARAMSTARTDOCNO, string PARAMENDDOCNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].QueryDefs["GetByPayerAndStateAndDocumentNoInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMSTARTDOCNO", PARAMSTARTDOCNO);
            paramList.Add("PARAMENDDOCNO", PARAMENDDOCNO);

            return ((ITTQuery)objectContext).QueryObjects<GeneralInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<GeneralInvoiceDocument> GetByDate(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].QueryDefs["GetByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<GeneralInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<GeneralInvoiceDocument> GetByDocumentNo(TTObjectContext objectContext, string DOCUMENTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].QueryDefs["GetByDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCUMENTNO", DOCUMENTNO);

            return ((ITTQuery)objectContext).QueryObjects<GeneralInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<GeneralInvoiceDocument.GetGeneralInvoiceDocumentByPayer_Class> GetGeneralInvoiceDocumentByPayer(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].QueryDefs["GetGeneralInvoiceDocumentByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<GeneralInvoiceDocument.GetGeneralInvoiceDocumentByPayer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<GeneralInvoiceDocument.GetGeneralInvoiceDocumentByPayer_Class> GetGeneralInvoiceDocumentByPayer(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GENERALINVOICEDOCUMENT"].QueryDefs["GetGeneralInvoiceDocumentByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<GeneralInvoiceDocument.GetGeneralInvoiceDocumentByPayer_Class>(objectContext, queryDef, paramList, pi);
        }

        virtual protected void CreateGeneralInvoiceCollection()
        {
            _GeneralInvoice = new GeneralInvoice.ChildGeneralInvoiceCollection(this, new Guid("594e8908-e3fa-428b-a8bb-c70980e08e14"));
            ((ITTChildObjectCollection)_GeneralInvoice).GetChildren();
        }

        protected GeneralInvoice.ChildGeneralInvoiceCollection _GeneralInvoice = null;
    /// <summary>
    /// Child collection for GeneralInvoiceDocument ile ilişki
    /// </summary>
        public GeneralInvoice.ChildGeneralInvoiceCollection GeneralInvoice
        {
            get
            {
                if (_GeneralInvoice == null)
                    CreateGeneralInvoiceCollection();
                return _GeneralInvoice;
            }
        }

        virtual protected void CreateSendingInvoiceDetailsCollection()
        {
            _SendingInvoiceDetails = new SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection(this, new Guid("7f29d6f0-12b8-4f3a-95b0-cadfa293e054"));
            ((ITTChildObjectCollection)_SendingInvoiceDetails).GetChildren();
        }

        protected SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection _SendingInvoiceDetails = null;
    /// <summary>
    /// Child collection for Hizmet Karşılığı Kurum Faturası dökümanı ile ilişki
    /// </summary>
        public SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection SendingInvoiceDetails
        {
            get
            {
                if (_SendingInvoiceDetails == null)
                    CreateSendingInvoiceDetailsCollection();
                return _SendingInvoiceDetails;
            }
        }

        virtual protected void CreateInvoicePaymentPatientListCollection()
        {
            _InvoicePaymentPatientList = new InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection(this, new Guid("65c51e5e-5ca0-4705-a43e-40700f79bb72"));
            ((ITTChildObjectCollection)_InvoicePaymentPatientList).GetChildren();
        }

        protected InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection _InvoicePaymentPatientList = null;
    /// <summary>
    /// Child collection for Hizmet Karşılığı Kurum Fatura Dökümanı ilişkisi
    /// </summary>
        public InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection InvoicePaymentPatientList
        {
            get
            {
                if (_InvoicePaymentPatientList == null)
                    CreateInvoicePaymentPatientListCollection();
                return _InvoicePaymentPatientList;
            }
        }

        virtual protected void CreateCancelledInvoicePatientListCollection()
        {
            _CancelledInvoicePatientList = new CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection(this, new Guid("d3868bf6-7996-4e54-bd28-fdf3637c29e1"));
            ((ITTChildObjectCollection)_CancelledInvoicePatientList).GetChildren();
        }

        protected CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection _CancelledInvoicePatientList = null;
    /// <summary>
    /// Child collection for Hizmet Karşılığı Kurum Fatura Dökümanı ilişkisi
    /// </summary>
        public CancelledInvoicePatientList.ChildCancelledInvoicePatientListCollection CancelledInvoicePatientList
        {
            get
            {
                if (_CancelledInvoicePatientList == null)
                    CreateCancelledInvoicePatientListCollection();
                return _CancelledInvoicePatientList;
            }
        }

        protected GeneralInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralInvoiceDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALINVOICEDOCUMENT", dataRow) { }
        protected GeneralInvoiceDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALINVOICEDOCUMENT", dataRow, isImported) { }
        public GeneralInvoiceDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralInvoiceDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralInvoiceDocument() : base() { }

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