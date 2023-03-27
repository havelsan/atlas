
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Debenture")] 

    /// <summary>
    /// Senet ödeme tipi
    /// </summary>
    public  partial class Debenture : Payment
    {
        public class DebentureList : TTObjectCollection<Debenture> { }
                    
        public class ChildDebentureCollection : TTObject.TTChildObjectCollection<Debenture>
        {
            public ChildDebentureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DebentureReportQuery_Class : TTReportNqlObject 
        {
            public long? No
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].AllPropertyDefs["NO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].AllPropertyDefs["DUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Guarantor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GUARANTOR"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODEACCOUNTACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DebentureReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DebentureReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DebentureReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ffc48d43-3822-4438-bf38-129022dd7066"); } }
    /// <summary>
    /// Ödeme Emri
    /// </summary>
            public static Guid PaymentOder { get { return new Guid("d7f96731-0f1b-451d-a9c3-5999a166b97d"); } }
    /// <summary>
    /// İcra Emri
    /// </summary>
            public static Guid ExecutionOrder { get { return new Guid("4ba85a4c-6569-4d1f-bbfa-42f1a3523d8e"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("84baeea8-437a-48bd-a9fd-ebac60d38d2b"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("227c8a8e-ab54-4264-a5f2-e376f2e52a9b"); } }
        }

        public static BindingList<Debenture> GetByExecutionDateAndState(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, string PARAMSTATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].QueryDefs["GetByExecutionDateAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMSTATE", PARAMSTATE);

            return ((ITTQuery)objectContext).QueryObjects<Debenture>(queryDef, paramList);
        }

        public static BindingList<Debenture> GetByDebentureNo(TTObjectContext objectContext, long PARAMDEBENTURENO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].QueryDefs["GetByDebentureNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBENTURENO", PARAMDEBENTURENO);

            return ((ITTQuery)objectContext).QueryObjects<Debenture>(queryDef, paramList);
        }

        public static BindingList<Debenture> GetByPaymentOrderDateAndState(TTObjectContext objectContext, DateTime PARAMSTARTDATE, DateTime PARAMENDDATE, string PARAMSTATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].QueryDefs["GetByPaymentOrderDateAndState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMSTARTDATE", PARAMSTARTDATE);
            paramList.Add("PARAMENDDATE", PARAMENDDATE);
            paramList.Add("PARAMSTATE", PARAMSTATE);

            return ((ITTQuery)objectContext).QueryObjects<Debenture>(queryDef, paramList);
        }

        public static BindingList<Debenture.DebentureReportQuery_Class> DebentureReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].QueryDefs["DebentureReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Debenture.DebentureReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Debenture.DebentureReportQuery_Class> DebentureReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].QueryDefs["DebentureReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Debenture.DebentureReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Debenture> GetByObjectID(TTObjectContext objectContext, string PARAMOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTURE"].QueryDefs["GetByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Debenture>(queryDef, paramList);
        }

    /// <summary>
    /// Ödeme Tarihi
    /// </summary>
        public DateTime? DueDate
        {
            get { return (DateTime?)this["DUEDATE"]; }
            set { this["DUEDATE"] = value; }
        }

    /// <summary>
    /// Ödeme Emri Tarihi
    /// </summary>
        public DateTime? PaymentOrderDate
        {
            get { return (DateTime?)this["PAYMENTORDERDATE"]; }
            set { this["PAYMENTORDERDATE"] = value; }
        }

    /// <summary>
    /// Muhakemat Tarihi
    /// </summary>
        public DateTime? ExecutionDate
        {
            get { return (DateTime?)this["EXECUTIONDATE"]; }
            set { this["EXECUTIONDATE"] = value; }
        }

    /// <summary>
    /// Senet numarasi
    /// </summary>
        public long? No
        {
            get { return (long?)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Senet Düzeltme ile relation
    /// </summary>
        public DebentureCorrection DebentureCorrection
        {
            get { return (DebentureCorrection)((ITTObject)this).GetParent("DEBENTURECORRECTION"); }
            set { this["DEBENTURECORRECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Garantöre ilişki
    /// </summary>
        public DebentureGuarantor Guarantor
        {
            get { return (DebentureGuarantor)((ITTObject)this).GetParent("GUARANTOR"); }
            set { this["GUARANTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// murat silinecek
    /// </summary>
        public DebentureFollowExecutionList ExecutionList
        {
            get { return (DebentureFollowExecutionList)((ITTObject)this).GetParent("EXECUTIONLIST"); }
            set { this["EXECUTIONLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// murat silinecek
    /// </summary>
        public DebentureFollowPaymentOrderList PaymentOrderList
        {
            get { return (DebentureFollowPaymentOrderList)((ITTObject)this).GetParent("PAYMENTORDERLIST"); }
            set { this["PAYMENTORDERLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDebentureFollowExecutionListCollection()
        {
            _DebentureFollowExecutionList = new DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection(this, new Guid("5fe493d6-2c49-4235-b4d0-2bfdd03cfaac"));
            ((ITTChildObjectCollection)_DebentureFollowExecutionList).GetChildren();
        }

        protected DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection _DebentureFollowExecutionList = null;
    /// <summary>
    /// Child collection for Senetle İlişkisi
    /// </summary>
        public DebentureFollowExecutionList.ChildDebentureFollowExecutionListCollection DebentureFollowExecutionList
        {
            get
            {
                if (_DebentureFollowExecutionList == null)
                    CreateDebentureFollowExecutionListCollection();
                return _DebentureFollowExecutionList;
            }
        }

        virtual protected void CreateDebenturePaymentPatientDebenturesCollection()
        {
            _DebenturePaymentPatientDebentures = new DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection(this, new Guid("7a73caf0-df24-4363-ac64-91f3bc0eff9c"));
            ((ITTChildObjectCollection)_DebenturePaymentPatientDebentures).GetChildren();
        }

        protected DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection _DebenturePaymentPatientDebentures = null;
    /// <summary>
    /// Child collection for Senetle İlişki
    /// </summary>
        public DebenturePaymentPatientDebentures.ChildDebenturePaymentPatientDebenturesCollection DebenturePaymentPatientDebentures
        {
            get
            {
                if (_DebenturePaymentPatientDebentures == null)
                    CreateDebenturePaymentPatientDebenturesCollection();
                return _DebenturePaymentPatientDebentures;
            }
        }

        virtual protected void CreateDebentureFollowPaymentOrderListCollection()
        {
            _DebentureFollowPaymentOrderList = new DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection(this, new Guid("b3aabfee-5ab2-4436-9102-80be5db7a4ba"));
            ((ITTChildObjectCollection)_DebentureFollowPaymentOrderList).GetChildren();
        }

        protected DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection _DebentureFollowPaymentOrderList = null;
    /// <summary>
    /// Child collection for Senetle İlişkisi
    /// </summary>
        public DebentureFollowPaymentOrderList.ChildDebentureFollowPaymentOrderListCollection DebentureFollowPaymentOrderList
        {
            get
            {
                if (_DebentureFollowPaymentOrderList == null)
                    CreateDebentureFollowPaymentOrderListCollection();
                return _DebentureFollowPaymentOrderList;
            }
        }

        virtual protected void CreatePatientDebenturesCollection()
        {
            _PatientDebentures = new DebentureGuarantorCorrectionPatientDebentures.ChildDebentureGuarantorCorrectionPatientDebenturesCollection(this, new Guid("ad482c57-63e6-422f-af1c-f0409b7569dd"));
            ((ITTChildObjectCollection)_PatientDebentures).GetChildren();
        }

        protected DebentureGuarantorCorrectionPatientDebentures.ChildDebentureGuarantorCorrectionPatientDebenturesCollection _PatientDebentures = null;
    /// <summary>
    /// Child collection for Senet ile ilişki
    /// </summary>
        public DebentureGuarantorCorrectionPatientDebentures.ChildDebentureGuarantorCorrectionPatientDebenturesCollection PatientDebentures
        {
            get
            {
                if (_PatientDebentures == null)
                    CreatePatientDebenturesCollection();
                return _PatientDebentures;
            }
        }

        protected Debenture(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Debenture(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Debenture(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Debenture(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Debenture(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTURE", dataRow) { }
        protected Debenture(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTURE", dataRow, isImported) { }
        public Debenture(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Debenture(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Debenture() : base() { }

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