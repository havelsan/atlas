
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBPurchaseProject")] 

    /// <summary>
    /// Lojistik İkmal Faliyetleri modülü temel sınıfıdır
    /// </summary>
    public  partial class LBPurchaseProject : BasePurchaseAction, ILBPurchaseProjectWorkList
    {
        public class LBPurchaseProjectList : TTObjectCollection<LBPurchaseProject> { }
                    
        public class ChildLBPurchaseProjectCollection : TTObject.TTChildObjectCollection<LBPurchaseProject>
        {
            public ChildLBPurchaseProjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBPurchaseProjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Dosya Kapat
    /// </summary>
            public static Guid Completed { get { return new Guid("5ed06adc-a864-4b62-8b24-6c12173c808d"); } }
    /// <summary>
    /// Amir Onayı
    /// </summary>
            public static Guid Approve { get { return new Guid("37ba0350-a437-4a9c-bddc-e5f0e45d39dc"); } }
    /// <summary>
    /// Proje İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("8ede745b-ecf2-4e05-a601-c4fb3044c8f8"); } }
    /// <summary>
    /// Kurmay Başkanı Onayı
    /// </summary>
            public static Guid PresidentApprove { get { return new Guid("6ecea5a1-579d-490f-9e8c-94dfa7a90b29"); } }
    /// <summary>
    /// Proje Kayıt
    /// </summary>
            public static Guid Analyse { get { return new Guid("0d7a9bd1-5433-4d72-9357-f99fd653d1b6"); } }
        }

        public static BindingList<LBPurchaseProject> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LBPURCHASEPROJECT"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<LBPurchaseProject>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Proje No
    /// </summary>
        public TTSequence PurchaseProjectNo
        {
            get { return GetSequence("PURCHASEPROJECTNO"); }
        }

    /// <summary>
    /// EYS No
    /// </summary>
        public string EYSNo
        {
            get { return (string)this["EYSNO"]; }
            set { this["EYSNO"] = value; }
        }

    /// <summary>
    /// İBF Türü
    /// </summary>
        public IBFTypeEnum? IBFType
        {
            get { return (IBFTypeEnum?)(int?)this["IBFTYPE"]; }
            set { this["IBFTYPE"] = value; }
        }

    /// <summary>
    /// İBF Yılı
    /// </summary>
        public int? IBFYear
        {
            get { return (int?)this["IBFYEAR"]; }
            set { this["IBFYEAR"] = value; }
        }

        virtual protected void CreateLBPurchaseProjectDetailInListsCollectionViews()
        {
            _LBD_XXXXXXDrugIns = new LBD_XXXXXXDrugIn.ChildLBD_XXXXXXDrugInCollection(_LBPurchaseProjectDetailInLists, "LBD_XXXXXXDrugIns");
            _LBD_KitIns = new LBD_KitIn.ChildLBD_KitInCollection(_LBPurchaseProjectDetailInLists, "LBD_KitIns");
            _LBD_MarketDrugIns = new LBD_MarketDrugIn.ChildLBD_MarketDrugInCollection(_LBPurchaseProjectDetailInLists, "LBD_MarketDrugIns");
            _LBD_MedicalConsIns = new LBD_MedicalConsIn.ChildLBD_MedicalConsInCollection(_LBPurchaseProjectDetailInLists, "LBD_MedicalConsIns");
            _LBD_MedicalEquipmentIns = new LBD_MedicalEquipmentIn.ChildLBD_MedicalEquipmentInCollection(_LBPurchaseProjectDetailInLists, "LBD_MedicalEquipmentIns");
            _LBD_MilitaryDrugIns = new LBD_MilitaryDrugIn.ChildLBD_MilitaryDrugInCollection(_LBPurchaseProjectDetailInLists, "LBD_MilitaryDrugIns");
            _LBD_PrintedDocumentIns = new LBD_PrintedDocumentIn.ChildLBD_PrintedDocumentInCollection(_LBPurchaseProjectDetailInLists, "LBD_PrintedDocumentIns");
            _LBD_SerumIns = new LBD_SerumIn.ChildLBD_SerumInCollection(_LBPurchaseProjectDetailInLists, "LBD_SerumIns");
            _LBD_SpareIns = new LBD_SpareIn.ChildLBD_SpareInCollection(_LBPurchaseProjectDetailInLists, "LBD_SpareIns");
            _LBD_VaccineIns = new LBD_VaccineIn.ChildLBD_VaccineInCollection(_LBPurchaseProjectDetailInLists, "LBD_VaccineIns");
        }

        virtual protected void CreateLBPurchaseProjectDetailInListsCollection()
        {
            _LBPurchaseProjectDetailInLists = new LBPurchaseProjectDetailInList.ChildLBPurchaseProjectDetailInListCollection(this, new Guid("012278c6-7cae-490b-a13a-6fe3ce6d9d02"));
            CreateLBPurchaseProjectDetailInListsCollectionViews();
            ((ITTChildObjectCollection)_LBPurchaseProjectDetailInLists).GetChildren();
        }

        protected LBPurchaseProjectDetailInList.ChildLBPurchaseProjectDetailInListCollection _LBPurchaseProjectDetailInLists = null;
        public LBPurchaseProjectDetailInList.ChildLBPurchaseProjectDetailInListCollection LBPurchaseProjectDetailInLists
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBPurchaseProjectDetailInLists;
            }
        }

        private LBD_XXXXXXDrugIn.ChildLBD_XXXXXXDrugInCollection _LBD_XXXXXXDrugIns = null;
        public LBD_XXXXXXDrugIn.ChildLBD_XXXXXXDrugInCollection LBD_XXXXXXDrugIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_XXXXXXDrugIns;
            }            
        }

        private LBD_KitIn.ChildLBD_KitInCollection _LBD_KitIns = null;
        public LBD_KitIn.ChildLBD_KitInCollection LBD_KitIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_KitIns;
            }            
        }

        private LBD_MarketDrugIn.ChildLBD_MarketDrugInCollection _LBD_MarketDrugIns = null;
        public LBD_MarketDrugIn.ChildLBD_MarketDrugInCollection LBD_MarketDrugIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_MarketDrugIns;
            }            
        }

        private LBD_MedicalConsIn.ChildLBD_MedicalConsInCollection _LBD_MedicalConsIns = null;
        public LBD_MedicalConsIn.ChildLBD_MedicalConsInCollection LBD_MedicalConsIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_MedicalConsIns;
            }            
        }

        private LBD_MedicalEquipmentIn.ChildLBD_MedicalEquipmentInCollection _LBD_MedicalEquipmentIns = null;
        public LBD_MedicalEquipmentIn.ChildLBD_MedicalEquipmentInCollection LBD_MedicalEquipmentIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_MedicalEquipmentIns;
            }            
        }

        private LBD_MilitaryDrugIn.ChildLBD_MilitaryDrugInCollection _LBD_MilitaryDrugIns = null;
        public LBD_MilitaryDrugIn.ChildLBD_MilitaryDrugInCollection LBD_MilitaryDrugIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_MilitaryDrugIns;
            }            
        }

        private LBD_PrintedDocumentIn.ChildLBD_PrintedDocumentInCollection _LBD_PrintedDocumentIns = null;
        public LBD_PrintedDocumentIn.ChildLBD_PrintedDocumentInCollection LBD_PrintedDocumentIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_PrintedDocumentIns;
            }            
        }

        private LBD_SerumIn.ChildLBD_SerumInCollection _LBD_SerumIns = null;
        public LBD_SerumIn.ChildLBD_SerumInCollection LBD_SerumIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_SerumIns;
            }            
        }

        private LBD_SpareIn.ChildLBD_SpareInCollection _LBD_SpareIns = null;
        public LBD_SpareIn.ChildLBD_SpareInCollection LBD_SpareIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_SpareIns;
            }            
        }

        private LBD_VaccineIn.ChildLBD_VaccineInCollection _LBD_VaccineIns = null;
        public LBD_VaccineIn.ChildLBD_VaccineInCollection LBD_VaccineIns
        {
            get
            {
                if (_LBPurchaseProjectDetailInLists == null)
                    CreateLBPurchaseProjectDetailInListsCollection();
                return _LBD_VaccineIns;
            }            
        }

        virtual protected void CreateLBPurchaseProjectDetailOutOfListsCollectionViews()
        {
            _LBD_XXXXXXDrugOuts = new LBD_XXXXXXDrugOut.ChildLBD_XXXXXXDrugOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_XXXXXXDrugOuts");
            _LBD_KitOuts = new LBD_KitOut.ChildLBD_KitOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_KitOuts");
            _LBD_MarketDrugOuts = new LBD_MarketDrugOut.ChildLBD_MarketDrugOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_MarketDrugOuts");
            _LBD_MedicalConsOuts = new LBD_MedicalConsOut.ChildLBD_MedicalConsOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_MedicalConsOuts");
            _LBD_MedicalEquipmentOuts = new LBD_MedicalEquipmentOut.ChildLBD_MedicalEquipmentOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_MedicalEquipmentOuts");
            _LBD_MilitaryDrugOuts = new LBD_MilitaryDrugOut.ChildLBD_MilitaryDrugOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_MilitaryDrugOuts");
            _LBD_PrintedDocumentOuts = new LBD_PrintedDocumentOut.ChildLBD_PrintedDocumentOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_PrintedDocumentOuts");
            _LBD_SerumOuts = new LBD_SerumOut.ChildLBD_SerumOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_SerumOuts");
            _LBD_SpareOuts = new LBD_SpareOut.ChildLBD_SpareOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_SpareOuts");
            _LBD_VaccineOuts = new LBD_VaccineOut.ChildLBD_VaccineOutCollection(_LBPurchaseProjectDetailOutOfLists, "LBD_VaccineOuts");
        }

        virtual protected void CreateLBPurchaseProjectDetailOutOfListsCollection()
        {
            _LBPurchaseProjectDetailOutOfLists = new LBPurchaseProjectDetailOutOfList.ChildLBPurchaseProjectDetailOutOfListCollection(this, new Guid("e761b277-fb97-458c-a7e5-d93370875428"));
            CreateLBPurchaseProjectDetailOutOfListsCollectionViews();
            ((ITTChildObjectCollection)_LBPurchaseProjectDetailOutOfLists).GetChildren();
        }

        protected LBPurchaseProjectDetailOutOfList.ChildLBPurchaseProjectDetailOutOfListCollection _LBPurchaseProjectDetailOutOfLists = null;
        public LBPurchaseProjectDetailOutOfList.ChildLBPurchaseProjectDetailOutOfListCollection LBPurchaseProjectDetailOutOfLists
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBPurchaseProjectDetailOutOfLists;
            }
        }

        private LBD_XXXXXXDrugOut.ChildLBD_XXXXXXDrugOutCollection _LBD_XXXXXXDrugOuts = null;
        public LBD_XXXXXXDrugOut.ChildLBD_XXXXXXDrugOutCollection LBD_XXXXXXDrugOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_XXXXXXDrugOuts;
            }            
        }

        private LBD_KitOut.ChildLBD_KitOutCollection _LBD_KitOuts = null;
        public LBD_KitOut.ChildLBD_KitOutCollection LBD_KitOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_KitOuts;
            }            
        }

        private LBD_MarketDrugOut.ChildLBD_MarketDrugOutCollection _LBD_MarketDrugOuts = null;
        public LBD_MarketDrugOut.ChildLBD_MarketDrugOutCollection LBD_MarketDrugOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_MarketDrugOuts;
            }            
        }

        private LBD_MedicalConsOut.ChildLBD_MedicalConsOutCollection _LBD_MedicalConsOuts = null;
        public LBD_MedicalConsOut.ChildLBD_MedicalConsOutCollection LBD_MedicalConsOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_MedicalConsOuts;
            }            
        }

        private LBD_MedicalEquipmentOut.ChildLBD_MedicalEquipmentOutCollection _LBD_MedicalEquipmentOuts = null;
        public LBD_MedicalEquipmentOut.ChildLBD_MedicalEquipmentOutCollection LBD_MedicalEquipmentOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_MedicalEquipmentOuts;
            }            
        }

        private LBD_MilitaryDrugOut.ChildLBD_MilitaryDrugOutCollection _LBD_MilitaryDrugOuts = null;
        public LBD_MilitaryDrugOut.ChildLBD_MilitaryDrugOutCollection LBD_MilitaryDrugOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_MilitaryDrugOuts;
            }            
        }

        private LBD_PrintedDocumentOut.ChildLBD_PrintedDocumentOutCollection _LBD_PrintedDocumentOuts = null;
        public LBD_PrintedDocumentOut.ChildLBD_PrintedDocumentOutCollection LBD_PrintedDocumentOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_PrintedDocumentOuts;
            }            
        }

        private LBD_SerumOut.ChildLBD_SerumOutCollection _LBD_SerumOuts = null;
        public LBD_SerumOut.ChildLBD_SerumOutCollection LBD_SerumOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_SerumOuts;
            }            
        }

        private LBD_SpareOut.ChildLBD_SpareOutCollection _LBD_SpareOuts = null;
        public LBD_SpareOut.ChildLBD_SpareOutCollection LBD_SpareOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_SpareOuts;
            }            
        }

        private LBD_VaccineOut.ChildLBD_VaccineOutCollection _LBD_VaccineOuts = null;
        public LBD_VaccineOut.ChildLBD_VaccineOutCollection LBD_VaccineOuts
        {
            get
            {
                if (_LBPurchaseProjectDetailOutOfLists == null)
                    CreateLBPurchaseProjectDetailOutOfListsCollection();
                return _LBD_VaccineOuts;
            }            
        }

        protected LBPurchaseProject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBPurchaseProject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBPurchaseProject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBPurchaseProject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBPurchaseProject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBPURCHASEPROJECT", dataRow) { }
        protected LBPurchaseProject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBPURCHASEPROJECT", dataRow, isImported) { }
        public LBPurchaseProject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBPurchaseProject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBPurchaseProject() : base() { }

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