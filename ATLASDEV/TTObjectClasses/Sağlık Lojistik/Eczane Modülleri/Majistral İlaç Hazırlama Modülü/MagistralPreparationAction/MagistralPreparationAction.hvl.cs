
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationAction")] 

    /// <summary>
    /// Majistral İlaç Hazırlama
    /// </summary>
    public  partial class MagistralPreparationAction : StockAction, IStockOutTransaction, ICheckStockActionOutDetail, IStockInTransaction
    {
        public class MagistralPreparationActionList : TTObjectCollection<MagistralPreparationAction> { }
                    
        public class ChildMagistralPreparationActionCollection : TTObject.TTChildObjectCollection<MagistralPreparationAction>
        {
            public ChildMagistralPreparationActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("bdc6af34-d22e-45a9-bfaf-ce1bdeacc1c6"); } }
    /// <summary>
    /// Majistral Hazırlama
    /// </summary>
            public static Guid MagistralPreparation { get { return new Guid("b76ee369-adda-4294-8519-1261e36c6ec7"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("5f7e376b-16b5-4ba6-854f-c349793e51eb"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("9d7b387c-d5c8-4dcd-9520-28fcecb7048f"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("e0f5ef80-9d0c-4547-91a7-cac6ecd699e7"); } }
        }

        public static BindingList<MagistralPreparationAction> GetMagistralDefinition(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPREPARATIONACTION"].QueryDefs["GetMagistralDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<MagistralPreparationAction>(queryDef, paramList);
        }

    /// <summary>
    /// Üretim Miktarı
    /// </summary>
        public double? MagistralAmount
        {
            get { return (double?)this["MAGISTRALAMOUNT"]; }
            set { this["MAGISTRALAMOUNT"] = value; }
        }

    /// <summary>
    /// Sterilizasyon
    /// </summary>
        public bool? Sterilization
        {
            get { return (bool?)this["STERILIZATION"]; }
            set { this["STERILIZATION"] = value; }
        }

    /// <summary>
    /// Nöbet
    /// </summary>
        public bool? NightShift
        {
            get { return (bool?)this["NIGHTSHIFT"]; }
            set { this["NIGHTSHIFT"] = value; }
        }

    /// <summary>
    /// Üretim Miktarı
    /// </summary>
        public double? BeforeMagistralAmount
        {
            get { return (double?)this["BEFOREMAGISTRALAMOUNT"]; }
            set { this["BEFOREMAGISTRALAMOUNT"] = value; }
        }

    /// <summary>
    /// Hacim
    /// </summary>
        public double? Volume
        {
            get { return (double?)this["VOLUME"]; }
            set { this["VOLUME"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? ProducedAmount
        {
            get { return (double?)this["PRODUCEDAMOUNT"]; }
            set { this["PRODUCEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? MagistralPrice
        {
            get { return (double?)this["MAGISTRALPRICE"]; }
            set { this["MAGISTRALPRICE"] = value; }
        }

    /// <summary>
    /// Preperat Türü
    /// </summary>
        public MagistralPreparationType MagistralPreparationType
        {
            get { return (MagistralPreparationType)((ITTObject)this).GetParent("MAGISTRALPREPARATIONTYPE"); }
            set { this["MAGISTRALPREPARATIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Preparat Alt Türü
    /// </summary>
        public MagistralPreparationSubType MagistralPreparationSubType
        {
            get { return (MagistralPreparationSubType)((ITTObject)this).GetParent("MAGISTRALPREPARATIONSUBTYPE"); }
            set { this["MAGISTRALPREPARATIONSUBTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ambalaj
    /// </summary>
        public MagistralPackagingType MagistralPackagingType
        {
            get { return (MagistralPackagingType)((ITTObject)this).GetParent("MAGISTRALPACKAGINGTYPE"); }
            set { this["MAGISTRALPACKAGINGTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Boyut
    /// </summary>
        public MagistralPackagingSubType MagistralPackagingSubType
        {
            get { return (MagistralPackagingSubType)((ITTObject)this).GetParent("MAGISTRALPACKAGINGSUBTYPE"); }
            set { this["MAGISTRALPACKAGINGSUBTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMagistralPreparationDetailsCollection()
        {
            _MagistralPreparationDetails = new MagistralPreparationDetail.ChildMagistralPreparationDetailCollection(this, new Guid("c3e61cc2-08e9-47e7-9318-1e8abd1eb7f4"));
            ((ITTChildObjectCollection)_MagistralPreparationDetails).GetChildren();
        }

        protected MagistralPreparationDetail.ChildMagistralPreparationDetailCollection _MagistralPreparationDetails = null;
        public MagistralPreparationDetail.ChildMagistralPreparationDetailCollection MagistralPreparationDetails
        {
            get
            {
                if (_MagistralPreparationDetails == null)
                    CreateMagistralPreparationDetailsCollection();
                return _MagistralPreparationDetails;
            }
        }

        virtual protected void CreateMagistralPreparationUsedChemicalsCollection()
        {
            _MagistralPreparationUsedChemicals = new MagistralPreparationUsedChemical.ChildMagistralPreparationUsedChemicalCollection(this, new Guid("274cd33a-a457-4900-9de0-eccd89f9ae50"));
            ((ITTChildObjectCollection)_MagistralPreparationUsedChemicals).GetChildren();
        }

        protected MagistralPreparationUsedChemical.ChildMagistralPreparationUsedChemicalCollection _MagistralPreparationUsedChemicals = null;
        public MagistralPreparationUsedChemical.ChildMagistralPreparationUsedChemicalCollection MagistralPreparationUsedChemicals
        {
            get
            {
                if (_MagistralPreparationUsedChemicals == null)
                    CreateMagistralPreparationUsedChemicalsCollection();
                return _MagistralPreparationUsedChemicals;
            }
        }

        virtual protected void CreateMagistralPreparationUsedDrugsCollection()
        {
            _MagistralPreparationUsedDrugs = new MagistralPreparationUsedDrug.ChildMagistralPreparationUsedDrugCollection(this, new Guid("00f4fe68-358e-4b32-b0c0-4b1411ffa2dc"));
            ((ITTChildObjectCollection)_MagistralPreparationUsedDrugs).GetChildren();
        }

        protected MagistralPreparationUsedDrug.ChildMagistralPreparationUsedDrugCollection _MagistralPreparationUsedDrugs = null;
        public MagistralPreparationUsedDrug.ChildMagistralPreparationUsedDrugCollection MagistralPreparationUsedDrugs
        {
            get
            {
                if (_MagistralPreparationUsedDrugs == null)
                    CreateMagistralPreparationUsedDrugsCollection();
                return _MagistralPreparationUsedDrugs;
            }
        }

        virtual protected void CreateMagistralPreparationUsedMaterialsCollection()
        {
            _MagistralPreparationUsedMaterials = new MagistralPreparationUsedMaterial.ChildMagistralPreparationUsedMaterialCollection(this, new Guid("e38749bf-1957-481d-b9b8-5ed577c78aac"));
            ((ITTChildObjectCollection)_MagistralPreparationUsedMaterials).GetChildren();
        }

        protected MagistralPreparationUsedMaterial.ChildMagistralPreparationUsedMaterialCollection _MagistralPreparationUsedMaterials = null;
        public MagistralPreparationUsedMaterial.ChildMagistralPreparationUsedMaterialCollection MagistralPreparationUsedMaterials
        {
            get
            {
                if (_MagistralPreparationUsedMaterials == null)
                    CreateMagistralPreparationUsedMaterialsCollection();
                return _MagistralPreparationUsedMaterials;
            }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _MagistralPreparationUsedDetails = new MagistralPreparationUsedDetail.ChildMagistralPreparationUsedDetailCollection(_StockActionDetails, "MagistralPreparationUsedDetails");
        }

        private MagistralPreparationUsedDetail.ChildMagistralPreparationUsedDetailCollection _MagistralPreparationUsedDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public MagistralPreparationUsedDetail.ChildMagistralPreparationUsedDetailCollection MagistralPreparationUsedDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _MagistralPreparationUsedDetails;
            }            
        }

        protected MagistralPreparationAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONACTION", dataRow) { }
        protected MagistralPreparationAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONACTION", dataRow, isImported) { }
        public MagistralPreparationAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationAction() : base() { }

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