
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerInvoicePayment")] 

    /// <summary>
    /// Fatura Tahsilat
    /// </summary>
    public  partial class PayerInvoicePayment : AccountAction
    {
        public class PayerInvoicePaymentList : TTObjectCollection<PayerInvoicePayment> { }
                    
        public class ChildPayerInvoicePaymentCollection : TTObject.TTChildObjectCollection<PayerInvoicePayment>
        {
            public ChildPayerInvoicePaymentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerInvoicePaymentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByInjection_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string DecountNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECOUNTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKDECOUNT"].AllPropertyDefs["DECOUNTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DecountDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECOUNTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKDECOUNT"].AllPropertyDefs["DECOUNTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Deduction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEDUCTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENT"].AllPropertyDefs["DEDUCTION"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Statedisplaytext
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATEDISPLAYTEXT"]);
                }
            }

            public GetByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByInjection_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("39ffbf5b-29b4-4d1b-bdf6-a6a149698f73"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f151bb8b-cc39-4c24-be77-dc51ebaae92c"); } }
        }

        public static BindingList<PayerInvoicePayment.GetByInjection_Class> GetByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENT"].QueryDefs["GetByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerInvoicePayment.GetByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerInvoicePayment.GetByInjection_Class> GetByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEPAYMENT"].QueryDefs["GetByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerInvoicePayment.GetByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kesinti Tutarı
    /// </summary>
        public Currency? Deduction
        {
            get { return (Currency?)this["DEDUCTION"]; }
            set { this["DEDUCTION"] = value; }
        }

        public string CancelDescription
        {
            get { return (string)this["CANCELDESCRIPTION"]; }
            set { this["CANCELDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Banka Dekontu
    /// </summary>
        public BankDecount BankDecount
        {
            get { return (BankDecount)((ITTObject)this).GetParent("BANKDECOUNT"); }
            set { this["BANKDECOUNT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePIPDetailsCollection()
        {
            _PIPDetails = new PayerInvoicePaymentDetail.ChildPayerInvoicePaymentDetailCollection(this, new Guid("9da3fd8c-316c-443b-a0e2-d7acf2d65c33"));
            ((ITTChildObjectCollection)_PIPDetails).GetChildren();
        }

        protected PayerInvoicePaymentDetail.ChildPayerInvoicePaymentDetailCollection _PIPDetails = null;
        public PayerInvoicePaymentDetail.ChildPayerInvoicePaymentDetailCollection PIPDetails
        {
            get
            {
                if (_PIPDetails == null)
                    CreatePIPDetailsCollection();
                return _PIPDetails;
            }
        }

        protected PayerInvoicePayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerInvoicePayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerInvoicePayment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerInvoicePayment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerInvoicePayment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERINVOICEPAYMENT", dataRow) { }
        protected PayerInvoicePayment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERINVOICEPAYMENT", dataRow, isImported) { }
        public PayerInvoicePayment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerInvoicePayment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerInvoicePayment() : base() { }

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