
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BondPayment")] 

    /// <summary>
    /// Senet Tahsilat
    /// </summary>
    public  partial class BondPayment : EpisodeAccountAction
    {
        public class BondPaymentList : TTObjectCollection<BondPayment> { }
                    
        public class ChildBondPaymentCollection : TTObject.TTChildObjectCollection<BondPayment>
        {
            public ChildBondPaymentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondPaymentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class BondPaymentReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BONDPAYMENT"].AllPropertyDefs["CASHOFFICENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BONDPAYMENTDOCUMENT"].AllPropertyDefs["PAYEENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BONDPAYMENTDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BONDPAYMENTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
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

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Currency? PaymentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BONDPAYMENT"].AllPropertyDefs["PAYMENTPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public PaymentTypeEnum? PaymentType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BONDPAYMENTDOCUMENT"].AllPropertyDefs["PAYMENTTYPE"].DataType;
                    return (PaymentTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public BondPaymentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public BondPaymentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected BondPaymentReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("d10e709b-fb87-4e56-b79c-25d6e266df53"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("9f129e52-1e68-4b30-9f3e-627b2c8a8fda"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("9343fd41-636e-4c69-84e2-2b4baf27187e"); } }
        }

        public static BindingList<BondPayment.BondPaymentReportQuery_Class> BondPaymentReportQuery(Guid BONDOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BONDPAYMENT"].QueryDefs["BondPaymentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BONDOBJECTID", BONDOBJECTID);

            return TTReportNqlObject.QueryObjects<BondPayment.BondPaymentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BondPayment.BondPaymentReportQuery_Class> BondPaymentReportQuery(TTObjectContext objectContext, Guid BONDOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BONDPAYMENT"].QueryDefs["BondPaymentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BONDOBJECTID", BONDOBJECTID);

            return TTReportNqlObject.QueryObjects<BondPayment.BondPaymentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ödeme Tutarı
    /// </summary>
        public Currency? PaymentPrice
        {
            get { return (Currency?)this["PAYMENTPRICE"]; }
            set { this["PAYMENTPRICE"] = value; }
        }

        public BondPaymentDocument BondPaymentDocument
        {
            get { return (BondPaymentDocument)((ITTObject)this).GetParent("BONDPAYMENTDOCUMENT"); }
            set { this["BONDPAYMENTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBondPaymentDetailsCollection()
        {
            _BondPaymentDetails = new BondPaymentDetail.ChildBondPaymentDetailCollection(this, new Guid("2adbea67-4bb0-4bf9-accd-3f9b3cd37d34"));
            ((ITTChildObjectCollection)_BondPaymentDetails).GetChildren();
        }

        protected BondPaymentDetail.ChildBondPaymentDetailCollection _BondPaymentDetails = null;
        public BondPaymentDetail.ChildBondPaymentDetailCollection BondPaymentDetails
        {
            get
            {
                if (_BondPaymentDetails == null)
                    CreateBondPaymentDetailsCollection();
                return _BondPaymentDetails;
            }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("29ee2c45-5eb1-42d1-bbd4-ce5575ce6987"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        protected BondPayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BondPayment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BondPayment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BondPayment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BondPayment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BONDPAYMENT", dataRow) { }
        protected BondPayment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BONDPAYMENT", dataRow, isImported) { }
        public BondPayment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BondPayment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BondPayment() : base() { }

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