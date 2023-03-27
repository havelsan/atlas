
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CollectedInvoiceDocument")] 

    /// <summary>
    /// Toplu Fatura Dökümanı
    /// </summary>
    public  partial class CollectedInvoiceDocument : AccountDocument
    {
        public class CollectedInvoiceDocumentList : TTObjectCollection<CollectedInvoiceDocument> { }
                    
        public class ChildCollectedInvoiceDocumentCollection : TTObject.TTChildObjectCollection<CollectedInvoiceDocument>
        {
            public ChildCollectedInvoiceDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCollectedInvoiceDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("cfabb6e8-e26b-4cf9-9604-10035df4642f"); } }
            public static Guid Cancelled { get { return new Guid("d588f5bb-1316-4419-b92d-204d1e12bf35"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("84aa39b2-e3ac-4275-8f69-88188c463986"); } }
            public static Guid Send { get { return new Guid("c5ed60df-bf28-450e-bcc3-8a924c36ce40"); } }
        }

        public static BindingList<CollectedInvoiceDocument> GetByDate(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].QueryDefs["GetByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<CollectedInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<CollectedInvoiceDocument> GetByPayerAndDateAndState(TTObjectContext objectContext, string PARAMPAYER, DateTime PARAMSTARTDATE, string PARAMSTATE, DateTime PARAMENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].QueryDefs["GetByPayerAndDateAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<CollectedInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<CollectedInvoiceDocument> GetByPayerAndStateAndDocumentNoInterval(TTObjectContext objectContext, string PARAMSTATE, string PARAMPAYER, string PARAMSTARTDOCNO, string PARAMENDDOCNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].QueryDefs["GetByPayerAndStateAndDocumentNoInterval"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTARTDOCNO", PARAMSTARTDOCNO);
            paramList.Add("PARAMENDDOCNO", PARAMENDDOCNO);

            return ((ITTQuery)objectContext).QueryObjects<CollectedInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<CollectedInvoiceDocument> GetByPayerAndStateAndDocumentNo(TTObjectContext objectContext, string PARAMSTATE, string PARAMDOCNO, string PARAMPAYER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].QueryDefs["GetByPayerAndStateAndDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTATE", PARAMSTATE);
            paramList.Add("PARAMDOCNO", PARAMDOCNO);
            paramList.Add("PARAMPAYER", PARAMPAYER);

            return ((ITTQuery)objectContext).QueryObjects<CollectedInvoiceDocument>(queryDef, paramList);
        }

        public static BindingList<CollectedInvoiceDocument> CheckRepeatedDocumentNo(TTObjectContext objectContext, string PARAMDOCNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COLLECTEDINVOICEDOCUMENT"].QueryDefs["CheckRepeatedDocumentNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDOCNO", PARAMDOCNO);

            return ((ITTQuery)objectContext).QueryObjects<CollectedInvoiceDocument>(queryDef, paramList);
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
    /// Kurumla İlişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInvoicePaymentPatientListCollection()
        {
            _InvoicePaymentPatientList = new InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection(this, new Guid("2dc5b29a-fa3a-4efa-8a87-ad8b8a0d5195"));
            ((ITTChildObjectCollection)_InvoicePaymentPatientList).GetChildren();
        }

        protected InvoicePaymentPatientList.ChildInvoicePaymentPatientListCollection _InvoicePaymentPatientList = null;
    /// <summary>
    /// Child collection for Toplu Fatura Dökümanı ilişkisi
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

        virtual protected void CreateCollectedInvoiceCollection()
        {
            _CollectedInvoice = new CollectedInvoice.ChildCollectedInvoiceCollection(this, new Guid("88eaf832-ef4f-434c-806f-fb615b4bb9e8"));
            ((ITTChildObjectCollection)_CollectedInvoice).GetChildren();
        }

        protected CollectedInvoice.ChildCollectedInvoiceCollection _CollectedInvoice = null;
    /// <summary>
    /// Child collection for Toplu Fatura Dökümanıyla İlişki
    /// </summary>
        public CollectedInvoice.ChildCollectedInvoiceCollection CollectedInvoice
        {
            get
            {
                if (_CollectedInvoice == null)
                    CreateCollectedInvoiceCollection();
                return _CollectedInvoice;
            }
        }

        virtual protected void CreateSendingInvoiceDetailsCollection()
        {
            _SendingInvoiceDetails = new SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection(this, new Guid("9eeb69f9-afbe-4d5d-a927-9d8507fe876e"));
            ((ITTChildObjectCollection)_SendingInvoiceDetails).GetChildren();
        }

        protected SendingInvoiceDetails.ChildSendingInvoiceDetailsCollection _SendingInvoiceDetails = null;
    /// <summary>
    /// Child collection for Toplu Fatura dökümanı ile ilişki
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

        protected CollectedInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CollectedInvoiceDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CollectedInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CollectedInvoiceDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CollectedInvoiceDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COLLECTEDINVOICEDOCUMENT", dataRow) { }
        protected CollectedInvoiceDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COLLECTEDINVOICEDOCUMENT", dataRow, isImported) { }
        public CollectedInvoiceDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CollectedInvoiceDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CollectedInvoiceDocument() : base() { }

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