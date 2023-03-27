
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashierLog")] 

    /// <summary>
    /// Veznenin açılış kapanış izini tutar
    /// </summary>
    public  partial class CashierLog : TTObject
    {
        public class CashierLogList : TTObjectCollection<CashierLog> { }
                    
        public class ChildCashierLogCollection : TTObject.TTChildObjectCollection<CashierLog>
        {
            public ChildCashierLogCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashierLogCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Opened { get { return new Guid("4516112b-c9c5-406a-be85-74b4e9361c2c"); } }
    /// <summary>
    /// Kapalı
    /// </summary>
            public static Guid Closed { get { return new Guid("912f6a78-5f04-4fc7-98b1-b35472114f0e"); } }
    /// <summary>
    /// Teslim Edildi
    /// </summary>
            public static Guid Submitted { get { return new Guid("8409748a-b687-46f8-ad00-f8d215fcb788"); } }
        }

        public static BindingList<CashierLog> GetByLogID(TTObjectContext objectContext, long PARAMLOGID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].QueryDefs["GetByLogID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMLOGID", PARAMLOGID);

            return ((ITTQuery)objectContext).QueryObjects<CashierLog>(queryDef, paramList);
        }

        public static BindingList<CashierLog> GetOpenLogByUserAndCashOffice(TTObjectContext objectContext, string PARAMUSER, string PARAMCASHOFFICE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].QueryDefs["GetOpenLogByUserAndCashOffice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMUSER", PARAMUSER);
            paramList.Add("PARAMCASHOFFICE", PARAMCASHOFFICE);

            return ((ITTQuery)objectContext).QueryObjects<CashierLog>(queryDef, paramList);
        }

        public static BindingList<CashierLog> GetClosedLogs(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHIERLOG"].QueryDefs["GetClosedLogs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<CashierLog>(queryDef, paramList);
        }

    /// <summary>
    /// Açılış kapanış iz numarasıdır
    /// </summary>
        public TTSequence LogID
        {
            get { return GetSequence("LOGID"); }
        }

    /// <summary>
    /// Veznenin kapanış tarihidir
    /// </summary>
        public DateTime? ClosingDate
        {
            get { return (DateTime?)this["CLOSINGDATE"]; }
            set { this["CLOSINGDATE"] = value; }
        }

    /// <summary>
    /// Veznenin açılış tarihidir
    /// </summary>
        public DateTime? OpeningDate
        {
            get { return (DateTime?)this["OPENINGDATE"]; }
            set { this["OPENINGDATE"] = value; }
        }

    /// <summary>
    /// Vezne ile ilişki
    /// </summary>
        public CashOfficeDefinition CashOffice
        {
            get { return (CashOfficeDefinition)((ITTObject)this).GetParent("CASHOFFICE"); }
            set { this["CASHOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanıcı ile ilişki
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCashOfficeClosingCollection()
        {
            _CashOfficeClosing = new CashOfficeClosing.ChildCashOfficeClosingCollection(this, new Guid("3423675e-3a89-4da5-a17d-4a59e1a58912"));
            ((ITTChildObjectCollection)_CashOfficeClosing).GetChildren();
        }

        protected CashOfficeClosing.ChildCashOfficeClosingCollection _CashOfficeClosing = null;
    /// <summary>
    /// Child collection for Veznenin açılış kapanış izi  ilişkisi 
    /// </summary>
        public CashOfficeClosing.ChildCashOfficeClosingCollection CashOfficeClosing
        {
            get
            {
                if (_CashOfficeClosing == null)
                    CreateCashOfficeClosingCollection();
                return _CashOfficeClosing;
            }
        }

        virtual protected void CreateSubmittedCashierLogsCollection()
        {
            _SubmittedCashierLogs = new SubmittedCashierLog.ChildSubmittedCashierLogCollection(this, new Guid("69b974c7-72c0-4b18-a132-1dafc2b061e5"));
            ((ITTChildObjectCollection)_SubmittedCashierLogs).GetChildren();
        }

        protected SubmittedCashierLog.ChildSubmittedCashierLogCollection _SubmittedCashierLogs = null;
    /// <summary>
    /// Child collection for Vezne açılış kapanış iziyle İlişki
    /// </summary>
        public SubmittedCashierLog.ChildSubmittedCashierLogCollection SubmittedCashierLogs
        {
            get
            {
                if (_SubmittedCashierLogs == null)
                    CreateSubmittedCashierLogsCollection();
                return _SubmittedCashierLogs;
            }
        }

        virtual protected void CreateReadyToCollectedInvoicesCollection()
        {
            _ReadyToCollectedInvoices = new ReadyToCollectedInvoice.ChildReadyToCollectedInvoiceCollection(this, new Guid("5358293b-a18b-4a14-bdd1-2eaa5f6dc6fa"));
            ((ITTChildObjectCollection)_ReadyToCollectedInvoices).GetChildren();
        }

        protected ReadyToCollectedInvoice.ChildReadyToCollectedInvoiceCollection _ReadyToCollectedInvoices = null;
        public ReadyToCollectedInvoice.ChildReadyToCollectedInvoiceCollection ReadyToCollectedInvoices
        {
            get
            {
                if (_ReadyToCollectedInvoices == null)
                    CreateReadyToCollectedInvoicesCollection();
                return _ReadyToCollectedInvoices;
            }
        }

        protected CashierLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashierLog(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashierLog(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashierLog(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashierLog(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHIERLOG", dataRow) { }
        protected CashierLog(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHIERLOG", dataRow, isImported) { }
        public CashierLog(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashierLog(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashierLog() : base() { }

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