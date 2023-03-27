
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChattelDocumentOutputWithAccountancy")] 

    /// <summary>
    /// Taşınır Mal İşlemi Çıkış
    /// </summary>
    public  partial class ChattelDocumentOutputWithAccountancy : BaseChattelDocument, IAutoDocumentRecordLog, IAutoDocumentNumber, IStockOutTransaction, IStockReservation, IChattelDocumentOutputWithAccountancy, ICheckStockActionOutDetail
    {
        public class ChattelDocumentOutputWithAccountancyList : TTObjectCollection<ChattelDocumentOutputWithAccountancy> { }
                    
        public class ChildChattelDocumentOutputWithAccountancyCollection : TTObject.TTChildObjectCollection<ChattelDocumentOutputWithAccountancy>
        {
            public ChildChattelDocumentOutputWithAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChattelDocumentOutputWithAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAccountancyForOutReport_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Id
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ID"]);
                }
            }

            public GetAccountancyForOutReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountancyForOutReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountancyForOutReport_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Approved { get { return new Guid("7a69386a-2cc1-4903-ad5d-a71d08a36eea"); } }
            public static Guid Cancelled { get { return new Guid("2d504a70-db01-4c16-b9bc-fdeb7bead89a"); } }
            public static Guid Completed { get { return new Guid("20b1a0f7-cdb6-4b6e-b819-aba245e7661f"); } }
            public static Guid New { get { return new Guid("2f482725-2fd1-4bf6-aa3d-ac4556e0da92"); } }
        }

        public static BindingList<ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport_Class> GetAccountancyForOutReport(Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTOUTPUTWITHACCOUNTANCY"].QueryDefs["GetAccountancyForOutReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport_Class> GetAccountancyForOutReport(TTObjectContext objectContext, Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHATTELDOCUMENTOUTPUTWITHACCOUNTANCY"].QueryDefs["GetAccountancyForOutReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<ChattelDocumentOutputWithAccountancy.GetAccountancyForOutReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public Guid? MaterialStabilityActionID
        {
            get { return (Guid?)this["MATERIALSTABILITYACTIONID"]; }
            set { this["MATERIALSTABILITYACTIONID"] = value; }
        }

    /// <summary>
    /// Hedef Belge Kayıt Numarası
    /// </summary>
        public string TargetDocumentRecordLogNo
        {
            get { return (string)this["TARGETDOCUMENTRECORDLOGNO"]; }
            set { this["TARGETDOCUMENTRECORDLOGNO"] = value; }
        }

        public Guid? InputDocumentObjectID
        {
            get { return (Guid?)this["INPUTDOCUMENTOBJECTID"]; }
            set { this["INPUTDOCUMENTOBJECTID"] = value; }
        }

    /// <summary>
    /// Çıkış Hareket Türü
    /// </summary>
        public TasinirCikisHareketTurEnum? outputStockMovementType
        {
            get { return (TasinirCikisHareketTurEnum?)(int?)this["OUTPUTSTOCKMOVEMENTTYPE"]; }
            set { this["OUTPUTSTOCKMOVEMENTTYPE"] = value; }
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
    /// Katkı Patı İçerir
    /// </summary>
        public bool? IsContainsContributions
        {
            get { return (bool?)this["ISCONTAINSCONTRIBUTIONS"]; }
            set { this["ISCONTAINSCONTRIBUTIONS"] = value; }
        }

    /// <summary>
    /// Fatura Numarası
    /// </summary>
        public string InvoiceNumberSec
        {
            get { return (string)this["INVOICENUMBERSEC"]; }
            set { this["INVOICENUMBERSEC"] = value; }
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

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ChattelDocumentOutputDetailsWithAccountancy = new ChattelDocumentOutputDetailWithAccountancy.ChildChattelDocumentOutputDetailWithAccountancyCollection(_StockActionDetails, "ChattelDocumentOutputDetailsWithAccountancy");
        }

        private ChattelDocumentOutputDetailWithAccountancy.ChildChattelDocumentOutputDetailWithAccountancyCollection _ChattelDocumentOutputDetailsWithAccountancy = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ChattelDocumentOutputDetailWithAccountancy.ChildChattelDocumentOutputDetailWithAccountancyCollection ChattelDocumentOutputDetailsWithAccountancy
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ChattelDocumentOutputDetailsWithAccountancy;
            }            
        }

        protected ChattelDocumentOutputWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChattelDocumentOutputWithAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChattelDocumentOutputWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChattelDocumentOutputWithAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChattelDocumentOutputWithAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHATTELDOCUMENTOUTPUTWITHACCOUNTANCY", dataRow) { }
        protected ChattelDocumentOutputWithAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHATTELDOCUMENTOUTPUTWITHACCOUNTANCY", dataRow, isImported) { }
        public ChattelDocumentOutputWithAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChattelDocumentOutputWithAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChattelDocumentOutputWithAccountancy() : base() { }

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