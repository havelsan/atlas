
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManualInvoiceDocument")] 

    public  partial class ManualInvoiceDocument : AccountDocument
    {
        public class ManualInvoiceDocumentList : TTObjectCollection<ManualInvoiceDocument> { }
                    
        public class ChildManualInvoiceDocumentCollection : TTObject.TTChildObjectCollection<ManualInvoiceDocument>
        {
            public ChildManualInvoiceDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManualInvoiceDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetManualInvoiceDocumentByPayer_Class : TTReportNqlObject 
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

            public GetManualInvoiceDocumentByPayer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetManualInvoiceDocumentByPayer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetManualInvoiceDocumentByPayer_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("3b877778-6eee-4a89-a9eb-fac81f24c3a9"); } }
            public static Guid Paid { get { return new Guid("ec045239-aebf-4f35-a400-039d678cc457"); } }
            public static Guid Send { get { return new Guid("383eff8c-cf1f-41cb-b222-bcf56bf13291"); } }
            public static Guid Cancelled { get { return new Guid("f7ba5a42-1900-4da9-b6f8-0ccc545ceee4"); } }
        }

        public static BindingList<ManualInvoiceDocument> GetByPayerAndDateAndState(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, string PARAMPAYER, string PARAMSTATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEDOCUMENT"].QueryDefs["GetByPayerAndDateAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTATE", PARAMSTATE);

            return ((ITTQuery)objectContext).QueryObjects<ManualInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<ManualInvoiceDocument> GetByPayerAndStateAndDocumentNo(TTObjectContext objectContext, string PARAMPAYER, string PARAMSTATE, string PARAMDOCNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEDOCUMENT"].QueryDefs["GetByPayerAndStateAndDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMDOCNO", PARAMDOCNO);

            return ((ITTQuery)objectContext).QueryObjects<ManualInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<ManualInvoiceDocument> GetByPayerAndStateAndDocumentNoInterval(TTObjectContext objectContext, string PARAMPAYER, string PARAMSTATE, string PARAMSTARTDOCNO, string PARAMENDDOCNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEDOCUMENT"].QueryDefs["GetByPayerAndStateAndDocumentNoInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMSTARTDOCNO", PARAMSTARTDOCNO);
            paramList.Add("PARAMENDDOCNO", PARAMENDDOCNO);

            return ((ITTQuery)objectContext).QueryObjects<ManualInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<ManualInvoiceDocument.GetManualInvoiceDocumentByPayer_Class> GetManualInvoiceDocumentByPayer(DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEDOCUMENT"].QueryDefs["GetManualInvoiceDocumentByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<ManualInvoiceDocument.GetManualInvoiceDocumentByPayer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ManualInvoiceDocument.GetManualInvoiceDocumentByPayer_Class> GetManualInvoiceDocumentByPayer(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<string> PAYER, int PAYERFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MANUALINVOICEDOCUMENT"].QueryDefs["GetManualInvoiceDocumentByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("PAYER", PAYER);
            paramList.Add("PAYERFLAG", PAYERFLAG);

            return TTReportNqlObject.QueryObjects<ManualInvoiceDocument.GetManualInvoiceDocumentByPayer_Class>(objectContext, queryDef, paramList, pi);
        }

        virtual protected void CreateManualInvoiceCollection()
        {
            _ManualInvoice = new ManualInvoice.ChildManualInvoiceCollection(this, new Guid("9ded74b6-5c40-4430-9b17-a1648950957c"));
            ((ITTChildObjectCollection)_ManualInvoice).GetChildren();
        }

        protected ManualInvoice.ChildManualInvoiceCollection _ManualInvoice = null;
    /// <summary>
    /// Child collection for ManualInvoiceDocument ile ilişki
    /// </summary>
        public ManualInvoice.ChildManualInvoiceCollection ManualInvoice
        {
            get
            {
                if (_ManualInvoice == null)
                    CreateManualInvoiceCollection();
                return _ManualInvoice;
            }
        }

        virtual protected void CreateInvoicePaymentPatientListCollection()
        {
            _InvoicePaymentPatientList = new InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection(this, new Guid("09c154b4-4d59-4b92-953e-afa78f63e6d1"));
            ((ITTChildObjectCollection)_InvoicePaymentPatientList).GetChildren();
        }

        protected InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection _InvoicePaymentPatientList = null;
    /// <summary>
    /// Child collection for Manuel Kurum Faturası Dökümanı ile ilişki
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

        protected ManualInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManualInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManualInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManualInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManualInvoiceDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANUALINVOICEDOCUMENT", dataRow) { }
        protected ManualInvoiceDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANUALINVOICEDOCUMENT", dataRow, isImported) { }
        public ManualInvoiceDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManualInvoiceDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManualInvoiceDocument() : base() { }

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