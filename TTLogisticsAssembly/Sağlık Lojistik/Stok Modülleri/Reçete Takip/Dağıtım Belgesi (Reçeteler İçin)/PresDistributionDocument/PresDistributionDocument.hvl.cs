
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresDistributionDocument")] 

    /// <summary>
    /// Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresDistributionDocument : DistributionDocument, IAutoDocumentNumber, ICheckStockActionOutDetail, IDistributionDocument, IStockReservation, IStockTransferTransaction, IBasePrescriptionTransaction
    {
        public class PresDistributionDocumentList : TTObjectCollection<PresDistributionDocument> { }
                    
        public class ChildPresDistributionDocumentCollection : TTObject.TTChildObjectCollection<PresDistributionDocument>
        {
            public ChildPresDistributionDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresDistributionDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDestStoreFromPresDistDocument_Class : TTReportNqlObject 
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

            public GetDestStoreFromPresDistDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDestStoreFromPresDistDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDestStoreFromPresDistDocument_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Depo Onay
    /// </summary>
            public static Guid StoreApproval { get { return new Guid("850dafed-651a-41ff-abf0-7ce6db7cdb3b"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("0574ddd2-1e90-49c9-a1c0-95b4372d6a4a"); } }
            public static Guid Cancelled { get { return new Guid("ca01fae2-c930-4a1a-8a1a-122b172e682e"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("07463342-1453-40b6-8183-a923e958d83e"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("15b89c88-52ea-480b-93d4-5be9903b9ea1"); } }
        }

        public static BindingList<PresDistributionDocument.GetDestStoreFromPresDistDocument_Class> GetDestStoreFromPresDistDocument(Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESDISTRIBUTIONDOCUMENT"].QueryDefs["GetDestStoreFromPresDistDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<PresDistributionDocument.GetDestStoreFromPresDistDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PresDistributionDocument.GetDestStoreFromPresDistDocument_Class> GetDestStoreFromPresDistDocument(TTObjectContext objectContext, Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESDISTRIBUTIONDOCUMENT"].QueryDefs["GetDestStoreFromPresDistDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<PresDistributionDocument.GetDestStoreFromPresDistDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresDistributionDocumentMaterials = new PresDistributionDocMaterial.ChildPresDistributionDocMaterialCollection(_StockActionDetails, "PresDistributionDocumentMaterials");
        }

        private PresDistributionDocMaterial.ChildPresDistributionDocMaterialCollection _PresDistributionDocumentMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresDistributionDocMaterial.ChildPresDistributionDocMaterialCollection PresDistributionDocumentMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresDistributionDocumentMaterials;
            }            
        }

        protected PresDistributionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresDistributionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresDistributionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresDistributionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresDistributionDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESDISTRIBUTIONDOCUMENT", dataRow) { }
        protected PresDistributionDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESDISTRIBUTIONDOCUMENT", dataRow, isImported) { }
        public PresDistributionDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresDistributionDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresDistributionDocument() : base() { }

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