
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainStoreStockTransfer")] 

    /// <summary>
    /// Ana Depolar Arası Transfer
    /// </summary>
    public  partial class MainStoreStockTransfer : BaseChattelDocument, IAutoDocumentNumber, ICheckStockActionOutDetail, IStockReservation, IStockTransferTransaction, IMainStoreStockTransfer, IAutoDocumentRecordLog
    {
        public class MainStoreStockTransferList : TTObjectCollection<MainStoreStockTransfer> { }
                    
        public class ChildMainStoreStockTransferCollection : TTObject.TTChildObjectCollection<MainStoreStockTransfer>
        {
            public ChildMainStoreStockTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainStoreStockTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDestStoreForTransfer_Class : TTReportNqlObject 
        {
            public string Destinationstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
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

            public GetDestStoreForTransfer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDestStoreForTransfer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDestStoreForTransfer_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("4a98d95b-35f9-442c-9d5e-53eb37641844"); } }
            public static Guid Completed { get { return new Guid("0476c5d5-cd95-4315-b6d5-a4e58ef84b1e"); } }
            public static Guid New { get { return new Guid("e4be177c-d5bb-4990-a11d-8b55978af96f"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("44ba5aeb-b165-44aa-8935-15688ffeab2c"); } }
    /// <summary>
    /// Depo Onay
    /// </summary>
            public static Guid StoreAppropval { get { return new Guid("4e770ddc-1399-4a4b-b645-999cb0f3cc9b"); } }
        }

    /// <summary>
    /// GetDestStoreForTransfer
    /// </summary>
        public static BindingList<MainStoreStockTransfer.GetDestStoreForTransfer_Class> GetDestStoreForTransfer(Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSTORESTOCKTRANSFER"].QueryDefs["GetDestStoreForTransfer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<MainStoreStockTransfer.GetDestStoreForTransfer_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// GetDestStoreForTransfer
    /// </summary>
        public static BindingList<MainStoreStockTransfer.GetDestStoreForTransfer_Class> GetDestStoreForTransfer(TTObjectContext objectContext, Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINSTORESTOCKTRANSFER"].QueryDefs["GetDestStoreForTransfer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<MainStoreStockTransfer.GetDestStoreForTransfer_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// MKYS Giriş Kontrol 
    /// </summary>
        public bool? InMkysControl
        {
            get { return (bool?)this["INMKYSCONTROL"]; }
            set { this["INMKYSCONTROL"] = value; }
        }

    /// <summary>
    /// MKYS Çıkış Kontrol 
    /// </summary>
        public bool? OutMkysControl
        {
            get { return (bool?)this["OUTMKYSCONTROL"]; }
            set { this["OUTMKYSCONTROL"] = value; }
        }

        public int? MKYS_AyniyatMakbuzIDGiris
        {
            get { return (int?)this["MKYS_AYNIYATMAKBUZIDGIRIS"]; }
            set { this["MKYS_AYNIYATMAKBUZIDGIRIS"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _MainStoreStockTransferMats = new MainStoreStockTransferMat.ChildMainStoreStockTransferMatCollection(_StockActionDetails, "MainStoreStockTransferMats");
        }

        private MainStoreStockTransferMat.ChildMainStoreStockTransferMatCollection _MainStoreStockTransferMats = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public MainStoreStockTransferMat.ChildMainStoreStockTransferMatCollection MainStoreStockTransferMats
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _MainStoreStockTransferMats;
            }            
        }

        protected MainStoreStockTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainStoreStockTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainStoreStockTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainStoreStockTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainStoreStockTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINSTORESTOCKTRANSFER", dataRow) { }
        protected MainStoreStockTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINSTORESTOCKTRANSFER", dataRow, isImported) { }
        public MainStoreStockTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainStoreStockTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainStoreStockTransfer() : base() { }

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