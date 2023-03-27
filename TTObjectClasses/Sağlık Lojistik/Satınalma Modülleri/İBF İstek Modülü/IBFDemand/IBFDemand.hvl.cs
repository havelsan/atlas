
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDemand")] 

    /// <summary>
    /// İBF İstek Modülü ana sınıfıdır
    /// </summary>
    public  partial class IBFDemand : BasePurchaseAction, IIBFDemandWorkList
    {
        public class IBFDemandList : TTObjectCollection<IBFDemand> { }
                    
        public class ChildIBFDemandCollection : TTObject.TTChildObjectCollection<IBFDemand>
        {
            public ChildIBFDemandCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDemandCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("2d3cb388-f341-4efa-aa7d-9bd10f0ceead"); } }
    /// <summary>
    /// Klinik Şefi Onayına
    /// </summary>
            public static Guid ClinicApproval { get { return new Guid("7a3fc057-f4b4-4760-aa74-29f7bfd28ccb"); } }
    /// <summary>
    /// Saymanlık Onay
    /// </summary>
            public static Guid AccountancyApproval { get { return new Guid("aad905e7-5664-469c-ae6a-1ec508f408b3"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("a9bdd33c-a7d0-46ed-b469-cf15f8b8a912"); } }
    /// <summary>
    /// Red
    /// </summary>
            public static Guid Rejected { get { return new Guid("bc70059c-136e-4023-9dce-b81107bca7a5"); } }
    /// <summary>
    /// İhtiyaç Tespit Komisyonu
    /// </summary>
            public static Guid RequisiteEvaluationCommision { get { return new Guid("c7cbc44a-5afa-4019-9648-407efe89e46f"); } }
        }

        public static BindingList<IBFDemand> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IBFDEMAND"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<IBFDemand>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<IBFDemand> GetIBFDemandsByTypeAndYear(TTObjectContext objectContext, int IBFTYPE, int IBFYEAR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IBFDEMAND"].QueryDefs["GetIBFDemandsByTypeAndYear"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("IBFTYPE", IBFTYPE);
            paramList.Add("IBFYEAR", IBFYEAR);

            return ((ITTQuery)objectContext).QueryObjects<IBFDemand>(queryDef, paramList);
        }

    /// <summary>
    /// İstek No
    /// </summary>
        public TTSequence RequestNo
        {
            get { return GetSequence("REQUESTNO"); }
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
    /// İBF Türü
    /// </summary>
        public IBFTypeEnum? IBFType
        {
            get { return (IBFTypeEnum?)(int?)this["IBFTYPE"]; }
            set { this["IBFTYPE"] = value; }
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

        public AnnualRequirementItemsDefinition AnnualReqItemsDefinition
        {
            get { return (AnnualRequirementItemsDefinition)((ITTObject)this).GetParent("ANNUALREQITEMSDEFINITION"); }
            set { this["ANNUALREQITEMSDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnnualRequirement AnnualRequirement
        {
            get { return (AnnualRequirement)((ITTObject)this).GetParent("ANNUALREQUIREMENT"); }
            set { this["ANNUALREQUIREMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateIBFBaseDemandDetailsCollectionViews()
        {
            _IBFDet_XXXXXXDrugIns = new IBFDet_XXXXXXDrugIn.ChildIBFDet_XXXXXXDrugInCollection(_IBFBaseDemandDetails, "IBFDet_XXXXXXDrugIns");
            _IBFDet_XXXXXXDrugOuts = new IBFDet_XXXXXXDrugOut.ChildIBFDet_XXXXXXDrugOutCollection(_IBFBaseDemandDetails, "IBFDet_XXXXXXDrugOuts");
            _IBFDet_KitIns = new IBFDet_KitIn.ChildIBFDet_KitInCollection(_IBFBaseDemandDetails, "IBFDet_KitIns");
            _IBFDet_MarketDrugIns = new IBFDet_MarketDrugIn.ChildIBFDet_MarketDrugInCollection(_IBFBaseDemandDetails, "IBFDet_MarketDrugIns");
            _IBFDet_MarketDrugOuts = new IBFDet_MarketDrugOut.ChildIBFDet_MarketDrugOutCollection(_IBFBaseDemandDetails, "IBFDet_MarketDrugOuts");
            _IBFDet_MedicalConsIns = new IBFDet_MedicalConsIn.ChildIBFDet_MedicalConsInCollection(_IBFBaseDemandDetails, "IBFDet_MedicalConsIns");
            _IBFDet_MedicalConsOuts = new IBFDet_MedicalConsOut.ChildIBFDet_MedicalConsOutCollection(_IBFBaseDemandDetails, "IBFDet_MedicalConsOuts");
            _IBFDet_MedicalEquipmentIns = new IBFDet_MedicalEquipmentIn.ChildIBFDet_MedicalEquipmentInCollection(_IBFBaseDemandDetails, "IBFDet_MedicalEquipmentIns");
            _IBFDet_MedicalEquipmentOuts = new IBFDet_MedicalEquipmentOut.ChildIBFDet_MedicalEquipmentOutCollection(_IBFBaseDemandDetails, "IBFDet_MedicalEquipmentOuts");
            _IBFDet_MilitaryDrugIns = new IBFDet_MilitaryDrugIn.ChildIBFDet_MilitaryDrugInCollection(_IBFBaseDemandDetails, "IBFDet_MilitaryDrugIns");
            _IBFDet_MilitaryDrugOuts = new IBFDet_MilitaryDrugOut.ChildIBFDet_MilitaryDrugOutCollection(_IBFBaseDemandDetails, "IBFDet_MilitaryDrugOuts");
            _IBFDet_PrintedDocumentIns = new IBFDet_PrintedDocumentIn.ChildIBFDet_PrintedDocumentInCollection(_IBFBaseDemandDetails, "IBFDet_PrintedDocumentIns");
            _IBFDet_PrintedDocumentOuts = new IBFDet_PrintedDocumentOut.ChildIBFDet_PrintedDocumentOutCollection(_IBFBaseDemandDetails, "IBFDet_PrintedDocumentOuts");
            _IBFDet_SerumIns = new IBFDet_SerumIn.ChildIBFDet_SerumInCollection(_IBFBaseDemandDetails, "IBFDet_SerumIns");
            _IBFDet_SerumOuts = new IBFDet_SerumOut.ChildIBFDet_SerumOutCollection(_IBFBaseDemandDetails, "IBFDet_SerumOuts");
            _IBFDet_SparePartIns = new IBFDet_SparePartIn.ChildIBFDet_SparePartInCollection(_IBFBaseDemandDetails, "IBFDet_SparePartIns");
            _IBFDet_SparePartOuts = new IBFDet_SparePartOut.ChildIBFDet_SparePartOutCollection(_IBFBaseDemandDetails, "IBFDet_SparePartOuts");
            _IBFDet_VaccineIns = new IBFDet_VaccineIn.ChildIBFDet_VaccineInCollection(_IBFBaseDemandDetails, "IBFDet_VaccineIns");
            _IBFDet_VaccineOuts = new IBFDet_VaccineOut.ChildIBFDet_VaccineOutCollection(_IBFBaseDemandDetails, "IBFDet_VaccineOuts");
            _IBFDetDetailIns = new IBFDetDetailIn.ChildIBFDetDetailInCollection(_IBFBaseDemandDetails, "IBFDetDetailIns");
            _IBFDetDetailOuts = new IBFDetDetailOut.ChildIBFDetDetailOutCollection(_IBFBaseDemandDetails, "IBFDetDetailOuts");
            _IBFDet_KitOuts = new IBFDet_KitOut.ChildIBFDet_KitOutCollection(_IBFBaseDemandDetails, "IBFDet_KitOuts");
        }

        virtual protected void CreateIBFBaseDemandDetailsCollection()
        {
            _IBFBaseDemandDetails = new IBFBaseDemandDetail.ChildIBFBaseDemandDetailCollection(this, new Guid("acefe809-d1dd-444b-8a4c-58aa821f65bd"));
            CreateIBFBaseDemandDetailsCollectionViews();
            ((ITTChildObjectCollection)_IBFBaseDemandDetails).GetChildren();
        }

        protected IBFBaseDemandDetail.ChildIBFBaseDemandDetailCollection _IBFBaseDemandDetails = null;
        public IBFBaseDemandDetail.ChildIBFBaseDemandDetailCollection IBFBaseDemandDetails
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFBaseDemandDetails;
            }
        }

        private IBFDet_XXXXXXDrugIn.ChildIBFDet_XXXXXXDrugInCollection _IBFDet_XXXXXXDrugIns = null;
        public IBFDet_XXXXXXDrugIn.ChildIBFDet_XXXXXXDrugInCollection IBFDet_XXXXXXDrugIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_XXXXXXDrugIns;
            }            
        }

        private IBFDet_XXXXXXDrugOut.ChildIBFDet_XXXXXXDrugOutCollection _IBFDet_XXXXXXDrugOuts = null;
        public IBFDet_XXXXXXDrugOut.ChildIBFDet_XXXXXXDrugOutCollection IBFDet_XXXXXXDrugOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_XXXXXXDrugOuts;
            }            
        }

        private IBFDet_KitIn.ChildIBFDet_KitInCollection _IBFDet_KitIns = null;
        public IBFDet_KitIn.ChildIBFDet_KitInCollection IBFDet_KitIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_KitIns;
            }            
        }

        private IBFDet_MarketDrugIn.ChildIBFDet_MarketDrugInCollection _IBFDet_MarketDrugIns = null;
        public IBFDet_MarketDrugIn.ChildIBFDet_MarketDrugInCollection IBFDet_MarketDrugIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_MarketDrugIns;
            }            
        }

        private IBFDet_MarketDrugOut.ChildIBFDet_MarketDrugOutCollection _IBFDet_MarketDrugOuts = null;
        public IBFDet_MarketDrugOut.ChildIBFDet_MarketDrugOutCollection IBFDet_MarketDrugOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_MarketDrugOuts;
            }            
        }

        private IBFDet_MedicalConsIn.ChildIBFDet_MedicalConsInCollection _IBFDet_MedicalConsIns = null;
        public IBFDet_MedicalConsIn.ChildIBFDet_MedicalConsInCollection IBFDet_MedicalConsIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_MedicalConsIns;
            }            
        }

        private IBFDet_MedicalConsOut.ChildIBFDet_MedicalConsOutCollection _IBFDet_MedicalConsOuts = null;
        public IBFDet_MedicalConsOut.ChildIBFDet_MedicalConsOutCollection IBFDet_MedicalConsOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_MedicalConsOuts;
            }            
        }

        private IBFDet_MedicalEquipmentIn.ChildIBFDet_MedicalEquipmentInCollection _IBFDet_MedicalEquipmentIns = null;
        public IBFDet_MedicalEquipmentIn.ChildIBFDet_MedicalEquipmentInCollection IBFDet_MedicalEquipmentIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_MedicalEquipmentIns;
            }            
        }

        private IBFDet_MedicalEquipmentOut.ChildIBFDet_MedicalEquipmentOutCollection _IBFDet_MedicalEquipmentOuts = null;
        public IBFDet_MedicalEquipmentOut.ChildIBFDet_MedicalEquipmentOutCollection IBFDet_MedicalEquipmentOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_MedicalEquipmentOuts;
            }            
        }

        private IBFDet_MilitaryDrugIn.ChildIBFDet_MilitaryDrugInCollection _IBFDet_MilitaryDrugIns = null;
        public IBFDet_MilitaryDrugIn.ChildIBFDet_MilitaryDrugInCollection IBFDet_MilitaryDrugIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_MilitaryDrugIns;
            }            
        }

        private IBFDet_MilitaryDrugOut.ChildIBFDet_MilitaryDrugOutCollection _IBFDet_MilitaryDrugOuts = null;
        public IBFDet_MilitaryDrugOut.ChildIBFDet_MilitaryDrugOutCollection IBFDet_MilitaryDrugOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_MilitaryDrugOuts;
            }            
        }

        private IBFDet_PrintedDocumentIn.ChildIBFDet_PrintedDocumentInCollection _IBFDet_PrintedDocumentIns = null;
        public IBFDet_PrintedDocumentIn.ChildIBFDet_PrintedDocumentInCollection IBFDet_PrintedDocumentIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_PrintedDocumentIns;
            }            
        }

        private IBFDet_PrintedDocumentOut.ChildIBFDet_PrintedDocumentOutCollection _IBFDet_PrintedDocumentOuts = null;
        public IBFDet_PrintedDocumentOut.ChildIBFDet_PrintedDocumentOutCollection IBFDet_PrintedDocumentOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_PrintedDocumentOuts;
            }            
        }

        private IBFDet_SerumIn.ChildIBFDet_SerumInCollection _IBFDet_SerumIns = null;
        public IBFDet_SerumIn.ChildIBFDet_SerumInCollection IBFDet_SerumIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_SerumIns;
            }            
        }

        private IBFDet_SerumOut.ChildIBFDet_SerumOutCollection _IBFDet_SerumOuts = null;
        public IBFDet_SerumOut.ChildIBFDet_SerumOutCollection IBFDet_SerumOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_SerumOuts;
            }            
        }

        private IBFDet_SparePartIn.ChildIBFDet_SparePartInCollection _IBFDet_SparePartIns = null;
        public IBFDet_SparePartIn.ChildIBFDet_SparePartInCollection IBFDet_SparePartIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_SparePartIns;
            }            
        }

        private IBFDet_SparePartOut.ChildIBFDet_SparePartOutCollection _IBFDet_SparePartOuts = null;
        public IBFDet_SparePartOut.ChildIBFDet_SparePartOutCollection IBFDet_SparePartOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_SparePartOuts;
            }            
        }

        private IBFDet_VaccineIn.ChildIBFDet_VaccineInCollection _IBFDet_VaccineIns = null;
        public IBFDet_VaccineIn.ChildIBFDet_VaccineInCollection IBFDet_VaccineIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_VaccineIns;
            }            
        }

        private IBFDet_VaccineOut.ChildIBFDet_VaccineOutCollection _IBFDet_VaccineOuts = null;
        public IBFDet_VaccineOut.ChildIBFDet_VaccineOutCollection IBFDet_VaccineOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_VaccineOuts;
            }            
        }

        private IBFDetDetailIn.ChildIBFDetDetailInCollection _IBFDetDetailIns = null;
        public IBFDetDetailIn.ChildIBFDetDetailInCollection IBFDetDetailIns
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDetDetailIns;
            }            
        }

        private IBFDetDetailOut.ChildIBFDetDetailOutCollection _IBFDetDetailOuts = null;
        public IBFDetDetailOut.ChildIBFDetDetailOutCollection IBFDetDetailOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDetDetailOuts;
            }            
        }

        private IBFDet_KitOut.ChildIBFDet_KitOutCollection _IBFDet_KitOuts = null;
        public IBFDet_KitOut.ChildIBFDet_KitOutCollection IBFDet_KitOuts
        {
            get
            {
                if (_IBFBaseDemandDetails == null)
                    CreateIBFBaseDemandDetailsCollection();
                return _IBFDet_KitOuts;
            }            
        }

        protected IBFDemand(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDemand(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDemand(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDemand(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDemand(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDEMAND", dataRow) { }
        protected IBFDemand(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDEMAND", dataRow, isImported) { }
        public IBFDemand(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDemand(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDemand() : base() { }

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