
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubStoreStockTransfer")] 

    /// <summary>
    /// Depolar Arası Transfer
    /// </summary>
    public  partial class SubStoreStockTransfer : StockAction, IAutoDocumentNumber, ICheckStockActionOutDetail, IDistributionDocument, IStockReservation, IStockTransferTransaction
    {
        public class SubStoreStockTransferList : TTObjectCollection<SubStoreStockTransfer> { }
                    
        public class ChildSubStoreStockTransferCollection : TTObject.TTChildObjectCollection<SubStoreStockTransfer>
        {
            public ChildSubStoreStockTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubStoreStockTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDestSubStoreStockTransfer_Class : TTReportNqlObject 
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDestSubStoreStockTransfer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDestSubStoreStockTransfer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDestSubStoreStockTransfer_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("d248062f-9ea5-4190-a8c9-e1b1b8a5e5a9"); } }
            public static Guid Completed { get { return new Guid("ba8fe9f3-4ac1-4a4b-aa34-738f318dda8e"); } }
            public static Guid New { get { return new Guid("b15d5788-6852-4076-80f4-1d729ab9ba17"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("39b3713c-7637-4ab5-95c9-91c360eb17cc"); } }
    /// <summary>
    /// Depo Onay
    /// </summary>
            public static Guid StoreAppropval { get { return new Guid("8638afa2-0ef3-4a06-a753-caf087764cf7"); } }
        }

    /// <summary>
    /// GetDestSubStoreStockTransfer
    /// </summary>
        public static BindingList<SubStoreStockTransfer.GetDestSubStoreStockTransfer_Class> GetDestSubStoreStockTransfer(Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSTORESTOCKTRANSFER"].QueryDefs["GetDestSubStoreStockTransfer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<SubStoreStockTransfer.GetDestSubStoreStockTransfer_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// GetDestSubStoreStockTransfer
    /// </summary>
        public static BindingList<SubStoreStockTransfer.GetDestSubStoreStockTransfer_Class> GetDestSubStoreStockTransfer(TTObjectContext objectContext, Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUBSTORESTOCKTRANSFER"].QueryDefs["GetDestSubStoreStockTransfer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<SubStoreStockTransfer.GetDestSubStoreStockTransfer_Class>(objectContext, queryDef, paramList, pi);
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _SubStoreStockTransferMaterials = new SubStoreStockTransferMat.ChildSubStoreStockTransferMatCollection(_StockActionDetails, "SubStoreStockTransferMaterials");
        }

        private SubStoreStockTransferMat.ChildSubStoreStockTransferMatCollection _SubStoreStockTransferMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public SubStoreStockTransferMat.ChildSubStoreStockTransferMatCollection SubStoreStockTransferMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _SubStoreStockTransferMaterials;
            }            
        }

        protected SubStoreStockTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubStoreStockTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubStoreStockTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubStoreStockTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubStoreStockTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBSTORESTOCKTRANSFER", dataRow) { }
        protected SubStoreStockTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBSTORESTOCKTRANSFER", dataRow, isImported) { }
        public SubStoreStockTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubStoreStockTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubStoreStockTransfer() : base() { }

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