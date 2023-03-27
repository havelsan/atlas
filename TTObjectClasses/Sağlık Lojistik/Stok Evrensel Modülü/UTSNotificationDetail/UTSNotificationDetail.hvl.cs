
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UTSNotificationDetail")] 

    public  partial class UTSNotificationDetail : TTObject
    {
        public class UTSNotificationDetailList : TTObjectCollection<UTSNotificationDetail> { }
                    
        public class ChildUTSNotificationDetailCollection : TTObject.TTChildObjectCollection<UTSNotificationDetail>
        {
            public ChildUTSNotificationDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUTSNotificationDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Unsuccessful { get { return new Guid("493bcdaa-08d3-4ca2-930b-70eb94328fc4"); } }
            public static Guid Successful { get { return new Guid("5100f344-1f24-4440-945b-3c8b568d0066"); } }
            public static Guid Cancelled { get { return new Guid("fd1c9da9-8e42-46d0-9ca8-8097f8433503"); } }
        }

        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public string NotificationID
        {
            get { return (string)this["NOTIFICATIONID"]; }
            set { this["NOTIFICATIONID"] = value; }
        }

        public UTSNotificationTypeEnum? NotificationType
        {
            get { return (UTSNotificationTypeEnum?)(int?)this["NOTIFICATIONTYPE"]; }
            set { this["NOTIFICATIONTYPE"] = value; }
        }

        public DateTime? NotificationDate
        {
            get { return (DateTime?)this["NOTIFICATIONDATE"]; }
            set { this["NOTIFICATIONDATE"] = value; }
        }

        public StockTransaction StockTransaction
        {
            get { return (StockTransaction)((ITTObject)this).GetParent("STOCKTRANSACTION"); }
            set { this["STOCKTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountTransactionsCollection()
        {
            _AccountTransactions = new AccountTransaction.ChildAccountTransactionCollection(this, new Guid("7293cc5a-da7a-46bc-9167-443f2300db6e"));
            ((ITTChildObjectCollection)_AccountTransactions).GetChildren();
        }

        protected AccountTransaction.ChildAccountTransactionCollection _AccountTransactions = null;
        public AccountTransaction.ChildAccountTransactionCollection AccountTransactions
        {
            get
            {
                if (_AccountTransactions == null)
                    CreateAccountTransactionsCollection();
                return _AccountTransactions;
            }
        }

        protected UTSNotificationDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UTSNotificationDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UTSNotificationDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UTSNotificationDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UTSNotificationDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UTSNOTIFICATIONDETAIL", dataRow) { }
        protected UTSNotificationDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UTSNOTIFICATIONDETAIL", dataRow, isImported) { }
        public UTSNotificationDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UTSNotificationDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UTSNotificationDetail() : base() { }

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