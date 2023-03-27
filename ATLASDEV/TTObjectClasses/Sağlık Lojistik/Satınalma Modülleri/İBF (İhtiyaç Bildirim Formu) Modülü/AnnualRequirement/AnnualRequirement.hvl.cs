
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnualRequirement")] 

    /// <summary>
    /// İhtiyaç Bildirim Formu
    /// </summary>
    public  partial class AnnualRequirement : BasePurchaseAction, IAnnualRequirementWorkList
    {
        public class AnnualRequirementList : TTObjectCollection<AnnualRequirement> { }
                    
        public class ChildAnnualRequirementCollection : TTObject.TTChildObjectCollection<AnnualRequirement>
        {
            public ChildAnnualRequirementCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnualRequirementCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Loj.Şb./İkmal Md.İBF Giriş
    /// </summary>
            public static Guid LogBrIBFRegisrty { get { return new Guid("cbb56d96-d264-4c17-94f1-4ebd16e82fcc"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f8668ab6-f16e-42b9-ab1e-5b0f08fae912"); } }
    /// <summary>
    /// Saymanlık Onay
    /// </summary>
            public static Guid AccountancyApproval { get { return new Guid("0c5246a2-d0ca-49c3-bc69-5ddbe54b80f9"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("d7063ce1-e166-43be-a07c-bfd5a1eaa52f"); } }
    /// <summary>
    /// Başhekim/XXXXXX İnceleme Onay
    /// </summary>
            public static Guid HeadDoctorApproval { get { return new Guid("0c2f497d-8e0f-4130-ad6c-b389317e83b9"); } }
    /// <summary>
    /// Birlik/Loj.Şb.İnceleme Onay
    /// </summary>
            public static Guid LogBrApprove { get { return new Guid("06e6c5fd-3b6b-40e9-8b38-85524f95208a"); } }
    /// <summary>
    /// Bölge XXXXXX / XXXXXX Onay
    /// </summary>
            public static Guid RegionalCommanderApprove { get { return new Guid("29454696-06bf-443c-a893-b59170cbb6a6"); } }
    /// <summary>
    /// Bölge XXXXXX İnceleme Onay
    /// </summary>
            public static Guid RegionalCommandLogBureauApproveForm { get { return new Guid("a9f18988-5c2e-4794-8204-10d5f8ebedf3"); } }
    /// <summary>
    /// İdari Amir
    /// </summary>
            public static Guid AdministrativeChief { get { return new Guid("262749a3-6e99-4aa0-923e-b2582ff75d73"); } }
    /// <summary>
    /// Lojistik Daire İnceleme Onay
    /// </summary>
            public static Guid LDApprove { get { return new Guid("05507c96-341b-4382-b3e5-3746061dbd1e"); } }
            public static Guid TechnicalManager { get { return new Guid("aa46c063-7ce6-4168-8f86-1bde91f1ab0c"); } }
        }

        public static BindingList<AnnualRequirement> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANNUALREQUIREMENT"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<AnnualRequirement>(queryDef, paramList, injectionSQL);
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
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// İstek No
    /// </summary>
        public TTSequence RequestNo
        {
            get { return GetSequence("REQUESTNO"); }
        }

    /// <summary>
    /// Yıl
    /// </summary>
        public int? IBFYear
        {
            get { return (int?)this["IBFYEAR"]; }
            set { this["IBFYEAR"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// İstek Sahibi Saha
    /// </summary>
        public Guid? OwnerSite
        {
            get { return (Guid?)this["OWNERSITE"]; }
            set { this["OWNERSITE"] = value; }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateIBFDemandsCollection()
        {
            _IBFDemands = new IBFDemand.ChildIBFDemandCollection(this, new Guid("a248bfd9-a7f6-45b3-8c28-44c9a85fee3a"));
            ((ITTChildObjectCollection)_IBFDemands).GetChildren();
        }

        protected IBFDemand.ChildIBFDemandCollection _IBFDemands = null;
        public IBFDemand.ChildIBFDemandCollection IBFDemands
        {
            get
            {
                if (_IBFDemands == null)
                    CreateIBFDemandsCollection();
                return _IBFDemands;
            }
        }

        virtual protected void CreateAnnualRequirementDetailsCollectionViews()
        {
            _ARD_SparePartOuts = new ARD_SparePartOut.ChildARD_SparePartOutCollection(_AnnualRequirementDetails, "ARD_SparePartOuts");
            _ARD_VaccineIns = new ARD_VaccineIn.ChildARD_VaccineInCollection(_AnnualRequirementDetails, "ARD_VaccineIns");
            _ARD_VaccineOuts = new ARD_VaccineOut.ChildARD_VaccineOutCollection(_AnnualRequirementDetails, "ARD_VaccineOuts");
            _AnnualRequirementDetailOutOfLists = new AnnualRequirementDetailOutOfList.ChildAnnualRequirementDetailOutOfListCollection(_AnnualRequirementDetails, "AnnualRequirementDetailOutOfLists");
            _AnnualRequirementDetailInLists = new AnnualRequirementDetailInList.ChildAnnualRequirementDetailInListCollection(_AnnualRequirementDetails, "AnnualRequirementDetailInLists");
            _ARD_XXXXXXDrugIns = new ARD_XXXXXXDrugIn.ChildARD_XXXXXXDrugInCollection(_AnnualRequirementDetails, "ARD_XXXXXXDrugIns");
            _ARD_XXXXXXDrugOuts = new ARD_XXXXXXDrugOut.ChildARD_XXXXXXDrugOutCollection(_AnnualRequirementDetails, "ARD_XXXXXXDrugOuts");
            _ARD_KitIns = new ARD_KitIn.ChildARD_KitInCollection(_AnnualRequirementDetails, "ARD_KitIns");
            _ARD_KitOuts = new ARD_KitOut.ChildARD_KitOutCollection(_AnnualRequirementDetails, "ARD_KitOuts");
            _ARD_MarketDrugIns = new ARD_MarketDrugIn.ChildARD_MarketDrugInCollection(_AnnualRequirementDetails, "ARD_MarketDrugIns");
            _ARD_MarketDrugOuts = new ARD_MarketDrugOut.ChildARD_MarketDrugOutCollection(_AnnualRequirementDetails, "ARD_MarketDrugOuts");
            _ARD_MedicalConsIns = new ARD_MedicalConsIn.ChildARD_MedicalConsInCollection(_AnnualRequirementDetails, "ARD_MedicalConsIns");
            _ARD_MedicalConsOuts = new ARD_MedicalConsOut.ChildARD_MedicalConsOutCollection(_AnnualRequirementDetails, "ARD_MedicalConsOuts");
            _ARD_MedicalEquipmentIns = new ARD_MedicalEquipmentIn.ChildARD_MedicalEquipmentInCollection(_AnnualRequirementDetails, "ARD_MedicalEquipmentIns");
            _ARD_MedicalEquipmentOuts = new ARD_MedicalEquipmentOut.ChildARD_MedicalEquipmentOutCollection(_AnnualRequirementDetails, "ARD_MedicalEquipmentOuts");
            _ARD_MilitaryDrugIns = new ARD_MilitaryDrugIn.ChildARD_MilitaryDrugInCollection(_AnnualRequirementDetails, "ARD_MilitaryDrugIns");
            _ARD_MilitaryDrugOuts = new ARD_MilitaryDrugOut.ChildARD_MilitaryDrugOutCollection(_AnnualRequirementDetails, "ARD_MilitaryDrugOuts");
            _ARD_PrintedDocumentIns = new ARD_PrintedDocumentIn.ChildARD_PrintedDocumentInCollection(_AnnualRequirementDetails, "ARD_PrintedDocumentIns");
            _ARD_PrintedDocumentOuts = new ARD_PrintedDocumentOut.ChildARD_PrintedDocumentOutCollection(_AnnualRequirementDetails, "ARD_PrintedDocumentOuts");
            _ARD_SerumIns = new ARD_SerumIn.ChildARD_SerumInCollection(_AnnualRequirementDetails, "ARD_SerumIns");
            _ARD_SerumOuts = new ARD_SerumOut.ChildARD_SerumOutCollection(_AnnualRequirementDetails, "ARD_SerumOuts");
            _ARD_SparePartIns = new ARD_SparePartIn.ChildARD_SparePartInCollection(_AnnualRequirementDetails, "ARD_SparePartIns");
        }

        virtual protected void CreateAnnualRequirementDetailsCollection()
        {
            _AnnualRequirementDetails = new AnnualRequirementDetail.ChildAnnualRequirementDetailCollection(this, new Guid("9a61af12-0987-4ae2-8bb9-b36e0aae2737"));
            CreateAnnualRequirementDetailsCollectionViews();
            ((ITTChildObjectCollection)_AnnualRequirementDetails).GetChildren();
        }

        protected AnnualRequirementDetail.ChildAnnualRequirementDetailCollection _AnnualRequirementDetails = null;
        public AnnualRequirementDetail.ChildAnnualRequirementDetailCollection AnnualRequirementDetails
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _AnnualRequirementDetails;
            }
        }

        private ARD_SparePartOut.ChildARD_SparePartOutCollection _ARD_SparePartOuts = null;
        public ARD_SparePartOut.ChildARD_SparePartOutCollection ARD_SparePartOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_SparePartOuts;
            }            
        }

        private ARD_VaccineIn.ChildARD_VaccineInCollection _ARD_VaccineIns = null;
        public ARD_VaccineIn.ChildARD_VaccineInCollection ARD_VaccineIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_VaccineIns;
            }            
        }

        private ARD_VaccineOut.ChildARD_VaccineOutCollection _ARD_VaccineOuts = null;
        public ARD_VaccineOut.ChildARD_VaccineOutCollection ARD_VaccineOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_VaccineOuts;
            }            
        }

        private AnnualRequirementDetailOutOfList.ChildAnnualRequirementDetailOutOfListCollection _AnnualRequirementDetailOutOfLists = null;
        public AnnualRequirementDetailOutOfList.ChildAnnualRequirementDetailOutOfListCollection AnnualRequirementDetailOutOfLists
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _AnnualRequirementDetailOutOfLists;
            }            
        }

        private AnnualRequirementDetailInList.ChildAnnualRequirementDetailInListCollection _AnnualRequirementDetailInLists = null;
        public AnnualRequirementDetailInList.ChildAnnualRequirementDetailInListCollection AnnualRequirementDetailInLists
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _AnnualRequirementDetailInLists;
            }            
        }

        private ARD_XXXXXXDrugIn.ChildARD_XXXXXXDrugInCollection _ARD_XXXXXXDrugIns = null;
        public ARD_XXXXXXDrugIn.ChildARD_XXXXXXDrugInCollection ARD_XXXXXXDrugIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_XXXXXXDrugIns;
            }            
        }

        private ARD_XXXXXXDrugOut.ChildARD_XXXXXXDrugOutCollection _ARD_XXXXXXDrugOuts = null;
        public ARD_XXXXXXDrugOut.ChildARD_XXXXXXDrugOutCollection ARD_XXXXXXDrugOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_XXXXXXDrugOuts;
            }            
        }

        private ARD_KitIn.ChildARD_KitInCollection _ARD_KitIns = null;
        public ARD_KitIn.ChildARD_KitInCollection ARD_KitIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_KitIns;
            }            
        }

        private ARD_KitOut.ChildARD_KitOutCollection _ARD_KitOuts = null;
        public ARD_KitOut.ChildARD_KitOutCollection ARD_KitOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_KitOuts;
            }            
        }

        private ARD_MarketDrugIn.ChildARD_MarketDrugInCollection _ARD_MarketDrugIns = null;
        public ARD_MarketDrugIn.ChildARD_MarketDrugInCollection ARD_MarketDrugIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_MarketDrugIns;
            }            
        }

        private ARD_MarketDrugOut.ChildARD_MarketDrugOutCollection _ARD_MarketDrugOuts = null;
        public ARD_MarketDrugOut.ChildARD_MarketDrugOutCollection ARD_MarketDrugOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_MarketDrugOuts;
            }            
        }

        private ARD_MedicalConsIn.ChildARD_MedicalConsInCollection _ARD_MedicalConsIns = null;
        public ARD_MedicalConsIn.ChildARD_MedicalConsInCollection ARD_MedicalConsIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_MedicalConsIns;
            }            
        }

        private ARD_MedicalConsOut.ChildARD_MedicalConsOutCollection _ARD_MedicalConsOuts = null;
        public ARD_MedicalConsOut.ChildARD_MedicalConsOutCollection ARD_MedicalConsOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_MedicalConsOuts;
            }            
        }

        private ARD_MedicalEquipmentIn.ChildARD_MedicalEquipmentInCollection _ARD_MedicalEquipmentIns = null;
        public ARD_MedicalEquipmentIn.ChildARD_MedicalEquipmentInCollection ARD_MedicalEquipmentIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_MedicalEquipmentIns;
            }            
        }

        private ARD_MedicalEquipmentOut.ChildARD_MedicalEquipmentOutCollection _ARD_MedicalEquipmentOuts = null;
        public ARD_MedicalEquipmentOut.ChildARD_MedicalEquipmentOutCollection ARD_MedicalEquipmentOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_MedicalEquipmentOuts;
            }            
        }

        private ARD_MilitaryDrugIn.ChildARD_MilitaryDrugInCollection _ARD_MilitaryDrugIns = null;
        public ARD_MilitaryDrugIn.ChildARD_MilitaryDrugInCollection ARD_MilitaryDrugIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_MilitaryDrugIns;
            }            
        }

        private ARD_MilitaryDrugOut.ChildARD_MilitaryDrugOutCollection _ARD_MilitaryDrugOuts = null;
        public ARD_MilitaryDrugOut.ChildARD_MilitaryDrugOutCollection ARD_MilitaryDrugOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_MilitaryDrugOuts;
            }            
        }

        private ARD_PrintedDocumentIn.ChildARD_PrintedDocumentInCollection _ARD_PrintedDocumentIns = null;
        public ARD_PrintedDocumentIn.ChildARD_PrintedDocumentInCollection ARD_PrintedDocumentIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_PrintedDocumentIns;
            }            
        }

        private ARD_PrintedDocumentOut.ChildARD_PrintedDocumentOutCollection _ARD_PrintedDocumentOuts = null;
        public ARD_PrintedDocumentOut.ChildARD_PrintedDocumentOutCollection ARD_PrintedDocumentOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_PrintedDocumentOuts;
            }            
        }

        private ARD_SerumIn.ChildARD_SerumInCollection _ARD_SerumIns = null;
        public ARD_SerumIn.ChildARD_SerumInCollection ARD_SerumIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_SerumIns;
            }            
        }

        private ARD_SerumOut.ChildARD_SerumOutCollection _ARD_SerumOuts = null;
        public ARD_SerumOut.ChildARD_SerumOutCollection ARD_SerumOuts
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_SerumOuts;
            }            
        }

        private ARD_SparePartIn.ChildARD_SparePartInCollection _ARD_SparePartIns = null;
        public ARD_SparePartIn.ChildARD_SparePartInCollection ARD_SparePartIns
        {
            get
            {
                if (_AnnualRequirementDetails == null)
                    CreateAnnualRequirementDetailsCollection();
                return _ARD_SparePartIns;
            }            
        }

        protected AnnualRequirement(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnualRequirement(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnualRequirement(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnualRequirement(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnualRequirement(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNUALREQUIREMENT", dataRow) { }
        protected AnnualRequirement(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNUALREQUIREMENT", dataRow, isImported) { }
        protected AnnualRequirement(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnualRequirement(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnualRequirement() : base() { }

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