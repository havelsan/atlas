
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerAdvancePayment")] 

    /// <summary>
    /// Kurum Avans Tahsilat
    /// </summary>
    public  partial class PayerAdvancePayment : AccountAction, IWorkListBaseAction
    {
        public class PayerAdvancePaymentList : TTObjectCollection<PayerAdvancePayment> { }
                    
        public class ChildPayerAdvancePaymentCollection : TTObject.TTChildObjectCollection<PayerAdvancePayment>
        {
            public ChildPayerAdvancePaymentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerAdvancePaymentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Cancelled { get { return new Guid("18603ae7-5a2c-44c3-9b8a-36e024f53196"); } }
            public static Guid Paid { get { return new Guid("2090ec1d-82ad-4ba1-873d-cbbc4abc8337"); } }
            public static Guid New { get { return new Guid("5adea6f7-c88d-49b9-ab06-dc32efddd42c"); } }
        }

        public static BindingList<PayerAdvancePayment> GetByPayerAndState(TTObjectContext objectContext, string PARAMPAYER, string PARAMSTATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERADVANCEPAYMENT"].QueryDefs["GetByPayerAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPAYER", PARAMPAYER);
            paramList.Add("PARAMSTATE", PARAMSTATE);

            return ((ITTQuery)objectContext).QueryObjects<PayerAdvancePayment>(queryDef, paramList);
        }

    /// <summary>
    /// Kalan Tutar
    /// </summary>
        public Currency? RemainingPrice
        {
            get { return (Currency?)this["REMAININGPRICE"]; }
            set { this["REMAININGPRICE"] = value; }
        }

    /// <summary>
    /// Kurum ile ilişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum Avans Tahsilat Dökümanı ile ilişki
    /// </summary>
        public PayerAdvancePaymentDocument PayerAdvancePaymentDocument
        {
            get { return (PayerAdvancePaymentDocument)((ITTObject)this).GetParent("PAYERADVANCEPAYMENTDOCUMENT"); }
            set { this["PAYERADVANCEPAYMENTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePayerPaymentAdvanceListCollection()
        {
            _PayerPaymentAdvanceList = new PayerPaymentAdvanceList.ChildPayerPaymentAdvanceListCollection(this, new Guid("1f39caf6-d81c-46c8-a89f-2bc57d69c452"));
            ((ITTChildObjectCollection)_PayerPaymentAdvanceList).GetChildren();
        }

        protected PayerPaymentAdvanceList.ChildPayerPaymentAdvanceListCollection _PayerPaymentAdvanceList = null;
    /// <summary>
    /// Child collection for Kurum Avans
    /// </summary>
        public PayerPaymentAdvanceList.ChildPayerPaymentAdvanceListCollection PayerPaymentAdvanceList
        {
            get
            {
                if (_PayerPaymentAdvanceList == null)
                    CreatePayerPaymentAdvanceListCollection();
                return _PayerPaymentAdvanceList;
            }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("48c34a17-01c1-402f-bfd9-c691082a404e"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected PayerAdvancePayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerAdvancePayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerAdvancePayment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerAdvancePayment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerAdvancePayment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERADVANCEPAYMENT", dataRow) { }
        protected PayerAdvancePayment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERADVANCEPAYMENT", dataRow, isImported) { }
        public PayerAdvancePayment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerAdvancePayment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerAdvancePayment() : base() { }

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