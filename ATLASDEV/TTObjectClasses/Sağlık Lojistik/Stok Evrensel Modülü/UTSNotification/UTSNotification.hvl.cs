
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UTSNotification")] 

    public  partial class UTSNotification : TTObject
    {
        public class UTSNotificationList : TTObjectCollection<UTSNotification> { }
                    
        public class ChildUTSNotificationCollection : TTObject.TTChildObjectCollection<UTSNotification>
        {
            public ChildUTSNotificationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUTSNotificationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Active { get { return new Guid("7415427b-665a-4d29-864c-4ab3b9a66a2c"); } }
            public static Guid Cancelled { get { return new Guid("b6879c26-1044-4d34-a738-b1cc273d91de"); } }
        }

        public static BindingList<UTSNotification> GetNotification(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UTSNOTIFICATION"].QueryDefs["GetNotification"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<UTSNotification>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<UTSNotification> GetUTSNotificationByBarkodeNo(TTObjectContext objectContext, string BARCODENO, long SENDINGORGNO, string DOCUMENTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UTSNOTIFICATION"].QueryDefs["GetUTSNotificationByBarkodeNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BARCODENO", BARCODENO);
            paramList.Add("SENDINGORGNO", SENDINGORGNO);
            paramList.Add("DOCUMENTNO", DOCUMENTNO);

            return ((ITTQuery)objectContext).QueryObjects<UTSNotification>(queryDef, paramList);
        }

        public static BindingList<UTSNotification> GetUTSNotificationByIncomingDeliveryNotifID(TTObjectContext objectContext, string VID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UTSNOTIFICATION"].QueryDefs["GetUTSNotificationByIncomingDeliveryNotifID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("VID", VID);

            return ((ITTQuery)objectContext).QueryObjects<UTSNotification>(queryDef, paramList);
        }

        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

        public string ProductBarcodeNo
        {
            get { return (string)this["PRODUCTBARCODENO"]; }
            set { this["PRODUCTBARCODENO"] = value; }
        }

        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
        }

        public string IncomingDeliveryNotifID
        {
            get { return (string)this["INCOMINGDELIVERYNOTIFID"]; }
            set { this["INCOMINGDELIVERYNOTIFID"] = value; }
        }

    /// <summary>
    /// Belge No.
    /// </summary>
        public string DocumentNo
        {
            get { return (string)this["DOCUMENTNO"]; }
            set { this["DOCUMENTNO"] = value; }
        }

        public long? SendingOrganizationNo
        {
            get { return (long?)this["SENDINGORGANIZATIONNO"]; }
            set { this["SENDINGORGANIZATIONNO"] = value; }
        }

        public long? ProducerImporterCompanyNo
        {
            get { return (long?)this["PRODUCERIMPORTERCOMPANYNO"]; }
            set { this["PRODUCERIMPORTERCOMPANYNO"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockActionDetailCollection()
        {
            _StockActionDetail = new StockActionDetail.ChildStockActionDetailCollection(this, new Guid("ebe6b0b1-5b67-44c7-bee7-3a56b84cb2f6"));
            ((ITTChildObjectCollection)_StockActionDetail).GetChildren();
        }

        protected StockActionDetail.ChildStockActionDetailCollection _StockActionDetail = null;
        public StockActionDetail.ChildStockActionDetailCollection StockActionDetail
        {
            get
            {
                if (_StockActionDetail == null)
                    CreateStockActionDetailCollection();
                return _StockActionDetail;
            }
        }

        protected UTSNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UTSNotification(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UTSNotification(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UTSNotification(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UTSNotification(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UTSNOTIFICATION", dataRow) { }
        protected UTSNotification(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UTSNOTIFICATION", dataRow, isImported) { }
        public UTSNotification(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UTSNotification(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UTSNotification() : base() { }

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