
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChattelDocumentInputWithAccountancy")] 

    public  partial class ChattelDocumentInputWithAccountancy : BaseChattelDocument, IAutoDocumentNumber, IAutoDocumentRecordLog, IStockInTransaction, IChattelDocumentInputWithAccountancy, ICheckStockActionInDetail
    {
        public class ChattelDocumentInputWithAccountancyList : TTObjectCollection<ChattelDocumentInputWithAccountancy> { }
                    
        public class ChildChattelDocumentInputWithAccountancyCollection : TTObject.TTChildObjectCollection<ChattelDocumentInputWithAccountancy>
        {
            public ChildChattelDocumentInputWithAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChattelDocumentInputWithAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class InputDetailsWithAccountancyRQ_Class : TTReportNqlObject 
        {
            public Guid? Stockactionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONOBJECTID"]);
                }
            }

            public Guid? Stockactiondetailobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STOCKACTIONDETAILOBJECTID"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTINPUTDETAILWITHACCOUNTANCY"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? SentAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTINPUTDETAILWITHACCOUNTANCY"].AllPropertyDefs["SENTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Conflictamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CONFLICTAMOUNT"]);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ConflictSubject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFLICTSUBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTINPUTDETAILWITHACCOUNTANCY"].AllPropertyDefs["CONFLICTSUBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public InputDetailsWithAccountancyRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InputDetailsWithAccountancyRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InputDetailsWithAccountancyRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Approved { get { return new Guid("6d828d69-1a19-40dc-b4cc-fce88cafd406"); } }
            public static Guid Cancelled { get { return new Guid("05406160-f4e0-4079-b142-d2763b8ef385"); } }
            public static Guid Completed { get { return new Guid("b74d6c04-3830-4382-93fd-c41c37d6a56d"); } }
            public static Guid New { get { return new Guid("078e7b15-ebf6-4701-bcc4-13576c15a6df"); } }
    /// <summary>
    /// Belge Düzeltme
    /// </summary>
            public static Guid FixDocument { get { return new Guid("6aa310a9-5618-4134-8184-e1434d872f39"); } }
        }

        public static BindingList<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class> InputDetailsWithAccountancyRQ(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTINPUTWITHACCOUNTANCY"].QueryDefs["InputDetailsWithAccountancyRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class> InputDetailsWithAccountancyRQ(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTINPUTWITHACCOUNTANCY"].QueryDefs["InputDetailsWithAccountancyRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentInputWithAccountancy.InputDetailsWithAccountancyRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentInputWithAccountancy> GetSameBaseNumberNQL(TTObjectContext objectContext, Guid TERMID, string BASENUMBER, Guid ACCOUNTANCY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTINPUTWITHACCOUNTANCY"].QueryDefs["GetSameBaseNumberNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);
            paramList.Add("BASENUMBER", BASENUMBER);
            paramList.Add("ACCOUNTANCY", ACCOUNTANCY);

            return ((ITTQuery)objectContext).QueryObjects<ChattelDocumentInputWithAccountancy>(queryDef, paramList);
        }

    /// <summary>
    /// Otomatik Yaratılmış Giriş İse Bağlı Çıkış İşleminin Guid'i
    /// </summary>
        public Guid? ChattelOutDocumentGuid
        {
            get { return (Guid?)this["CHATTELOUTDOCUMENTGUID"]; }
            set { this["CHATTELOUTDOCUMENTGUID"] = value; }
        }

    /// <summary>
    /// MKYS İşlem Kayıt No
    /// </summary>
        public int? ActionRecordNo
        {
            get { return (int?)this["ACTIONRECORDNO"]; }
            set { this["ACTIONRECORDNO"] = value; }
        }

    /// <summary>
    /// İrsaliye Numarası
    /// </summary>
        public string Waybill
        {
            get { return (string)this["WAYBILL"]; }
            set { this["WAYBILL"] = value; }
        }

    /// <summary>
    /// İrsaliye Tarihi
    /// </summary>
        public DateTime? WaybillDate
        {
            get { return (DateTime?)this["WAYBILLDATE"]; }
            set { this["WAYBILLDATE"] = value; }
        }

    /// <summary>
    /// Giriş Türü
    /// </summary>
        public TasinirMalGirisTurEnum? inputWithAccountancyType
        {
            get { return (TasinirMalGirisTurEnum?)(int?)this["INPUTWITHACCOUNTANCYTYPE"]; }
            set { this["INPUTWITHACCOUNTANCYTYPE"] = value; }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ChattelDocumentInputDetailsWithAccountancy = new ChattelDocumentInputDetailWithAccountancy.ChildChattelDocumentInputDetailWithAccountancyCollection(_StockActionDetails, "ChattelDocumentInputDetailsWithAccountancy");
        }

        private ChattelDocumentInputDetailWithAccountancy.ChildChattelDocumentInputDetailWithAccountancyCollection _ChattelDocumentInputDetailsWithAccountancy = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ChattelDocumentInputDetailWithAccountancy.ChildChattelDocumentInputDetailWithAccountancyCollection ChattelDocumentInputDetailsWithAccountancy
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ChattelDocumentInputDetailsWithAccountancy;
            }            
        }

        protected ChattelDocumentInputWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChattelDocumentInputWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChattelDocumentInputWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChattelDocumentInputWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChattelDocumentInputWithAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHATTELDOCUMENTINPUTWITHACCOUNTANCY", dataRow) { }
        protected ChattelDocumentInputWithAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHATTELDOCUMENTINPUTWITHACCOUNTANCY", dataRow, isImported) { }
        public ChattelDocumentInputWithAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChattelDocumentInputWithAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChattelDocumentInputWithAccountancy() : base() { }

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