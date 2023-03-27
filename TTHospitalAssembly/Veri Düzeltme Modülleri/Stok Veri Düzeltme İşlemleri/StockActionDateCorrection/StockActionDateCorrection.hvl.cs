
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockActionDateCorrection")] 

    /// <summary>
    /// Belge Tarihi Güncelleme (Devir için)
    /// </summary>
    public  partial class StockActionDateCorrection : BaseDataCorrection, IWorkListBaseAction
    {
        public class StockActionDateCorrectionList : TTObjectCollection<StockActionDateCorrection> { }
                    
        public class ChildStockActionDateCorrectionCollection : TTObject.TTChildObjectCollection<StockActionDateCorrection>
        {
            public ChildStockActionDateCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockActionDateCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("1dc224ff-5605-4c7d-b63e-d8a79f144291"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("c99cfbe5-0896-4001-b415-0db6d766a711"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("165dd7de-5626-4111-a4dd-2ebfd0a0e0d0"); } }
        }

    /// <summary>
    /// Önceki Devir Muvakkat
    /// </summary>
        public Currency? OldStockCensusConsigned
        {
            get { return (Currency?)this["OLDSTOCKCENSUSCONSIGNED"]; }
            set { this["OLDSTOCKCENSUSCONSIGNED"] = value; }
        }

    /// <summary>
    /// Önceki Devir Mevcut
    /// </summary>
        public Currency? OldStockCensusInheld
        {
            get { return (Currency?)this["OLDSTOCKCENSUSINHELD"]; }
            set { this["OLDSTOCKCENSUSINHELD"] = value; }
        }

    /// <summary>
    /// Yapılan Değişiklikler
    /// </summary>
        public string UpdateLog
        {
            get { return (string)this["UPDATELOG"]; }
            set { this["UPDATELOG"] = value; }
        }

    /// <summary>
    /// Güncellenecek İşlem Tarihi
    /// </summary>
        public DateTime? ChangeTransactionDate
        {
            get { return (DateTime?)this["CHANGETRANSACTIONDATE"]; }
            set { this["CHANGETRANSACTIONDATE"] = value; }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountingTerm AccountingTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("ACCOUNTINGTERM"); }
            set { this["ACCOUNTINGTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDateCorrectionDetailsCollection()
        {
            _DateCorrectionDetails = new DateCorrectionDetail.ChildDateCorrectionDetailCollection(this, new Guid("a67b35db-6f98-4105-88fe-f7e96e0405fe"));
            ((ITTChildObjectCollection)_DateCorrectionDetails).GetChildren();
        }

        protected DateCorrectionDetail.ChildDateCorrectionDetailCollection _DateCorrectionDetails = null;
        public DateCorrectionDetail.ChildDateCorrectionDetailCollection DateCorrectionDetails
        {
            get
            {
                if (_DateCorrectionDetails == null)
                    CreateDateCorrectionDetailsCollection();
                return _DateCorrectionDetails;
            }
        }

        protected StockActionDateCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockActionDateCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockActionDateCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockActionDateCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockActionDateCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKACTIONDATECORRECTION", dataRow) { }
        protected StockActionDateCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKACTIONDATECORRECTION", dataRow, isImported) { }
        public StockActionDateCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockActionDateCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockActionDateCorrection() : base() { }

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