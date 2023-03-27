
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResHospital")] 

    /// <summary>
    /// XXXXXX
    /// </summary>
    public  partial class ResHospital : ResSection
    {
        public class ResHospitalList : TTObjectCollection<ResHospital> { }
                    
        public class ChildResHospitalCollection : TTObject.TTChildObjectCollection<ResHospital>
        {
            public ChildResHospitalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResHospitalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResHospital_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESHOSPITAL"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESHOSPITAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public OLAP_ResHospital_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResHospital_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResHospital_Class() : base() { }
        }

        [Serializable] 

        public partial class VEM_BINA_Class : TTReportNqlObject 
        {
            public Guid? Bina_kodu
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BINA_KODU"]);
                }
            }

            public Object Referans_tablo_adi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["REFERANS_TABLO_ADI"]);
                }
            }

            public string Bina_adi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BINA_ADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESHOSPITAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Bina_adresi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["BINA_ADRESI"]);
                }
            }

            public Object Skrs_kurum_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SKRS_KURUM_KODU"]);
                }
            }

            public Object Ekleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EKLEYEN_KULLANICI_KODU"]);
                }
            }

            public Object Guncelleme_tarihi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEME_TARIHI"]);
                }
            }

            public Object Guncelleyen_kullanici_kodu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GUNCELLEYEN_KULLANICI_KODU"]);
                }
            }

            public VEM_BINA_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VEM_BINA_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VEM_BINA_Class() : base() { }
        }

        public static BindingList<ResHospital.OLAP_ResHospital_Class> OLAP_ResHospital(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHOSPITAL"].QueryDefs["OLAP_ResHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResHospital.OLAP_ResHospital_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResHospital.OLAP_ResHospital_Class> OLAP_ResHospital(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHOSPITAL"].QueryDefs["OLAP_ResHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResHospital.OLAP_ResHospital_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResHospital> GetResHospitals(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHOSPITAL"].QueryDefs["GetResHospitals"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResHospital>(queryDef, paramList);
        }

        public static BindingList<ResHospital.VEM_BINA_Class> VEM_BINA(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHOSPITAL"].QueryDefs["VEM_BINA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResHospital.VEM_BINA_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResHospital.VEM_BINA_Class> VEM_BINA(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESHOSPITAL"].QueryDefs["VEM_BINA"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResHospital.VEM_BINA_Class>(objectContext, queryDef, paramList, pi);
        }

        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSILKodlari SKRSILKodlari
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("SKRSILKODLARI"); }
            set { this["SKRSILKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSIlceKodlari SKRSIlceKodlari
        {
            get { return (SKRSIlceKodlari)((ITTObject)this).GetParent("SKRSILCEKODLARI"); }
            set { this["SKRSILCEKODLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAdministrativeUnitsCollection()
        {
            _AdministrativeUnits = new ResAdministrativeUnit.ChildResAdministrativeUnitCollection(this, new Guid("afb80c29-bcdb-41f7-a4ae-0ee95c2d814c"));
            ((ITTChildObjectCollection)_AdministrativeUnits).GetChildren();
        }

        protected ResAdministrativeUnit.ChildResAdministrativeUnitCollection _AdministrativeUnits = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResAdministrativeUnit.ChildResAdministrativeUnitCollection AdministrativeUnits
        {
            get
            {
                if (_AdministrativeUnits == null)
                    CreateAdministrativeUnitsCollection();
                return _AdministrativeUnits;
            }
        }

        virtual protected void CreateMorguesCollection()
        {
            _Morgues = new ResMorgue.ChildResMorgueCollection(this, new Guid("e3f2ea97-5762-46ca-b01c-2e08e8c9ebcc"));
            ((ITTChildObjectCollection)_Morgues).GetChildren();
        }

        protected ResMorgue.ChildResMorgueCollection _Morgues = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResMorgue.ChildResMorgueCollection Morgues
        {
            get
            {
                if (_Morgues == null)
                    CreateMorguesCollection();
                return _Morgues;
            }
        }

        virtual protected void CreateBuildingsCollection()
        {
            _Buildings = new ResBuilding.ChildResBuildingCollection(this, new Guid("bf26923c-637b-4f1c-b023-6392610b709a"));
            ((ITTChildObjectCollection)_Buildings).GetChildren();
        }

        protected ResBuilding.ChildResBuildingCollection _Buildings = null;
    /// <summary>
    /// Child collection for Bina
    /// </summary>
        public ResBuilding.ChildResBuildingCollection Buildings
        {
            get
            {
                if (_Buildings == null)
                    CreateBuildingsCollection();
                return _Buildings;
            }
        }

        virtual protected void CreateHealthCommitteesCollection()
        {
            _HealthCommittees = new ResHealthCommittee.ChildResHealthCommitteeCollection(this, new Guid("79e411c6-86e8-42a6-9c7b-1bcea833a1f1"));
            ((ITTChildObjectCollection)_HealthCommittees).GetChildren();
        }

        protected ResHealthCommittee.ChildResHealthCommitteeCollection _HealthCommittees = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResHealthCommittee.ChildResHealthCommitteeCollection HealthCommittees
        {
            get
            {
                if (_HealthCommittees == null)
                    CreateHealthCommitteesCollection();
                return _HealthCommittees;
            }
        }

        virtual protected void CreateWardsCollection()
        {
            _Wards = new ResWard.ChildResWardCollection(this, new Guid("7801c127-27aa-4339-88fc-28268a444c48"));
            ((ITTChildObjectCollection)_Wards).GetChildren();
        }

        protected ResWard.ChildResWardCollection _Wards = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResWard.ChildResWardCollection Wards
        {
            get
            {
                if (_Wards == null)
                    CreateWardsCollection();
                return _Wards;
            }
        }

        virtual protected void CreateCommandershipsCollection()
        {
            _Commanderships = new ResCommandership.ChildResCommandershipCollection(this, new Guid("3242a85e-99ae-4f7a-8d2e-6e93bad7bb3a"));
            ((ITTChildObjectCollection)_Commanderships).GetChildren();
        }

        protected ResCommandership.ChildResCommandershipCollection _Commanderships = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResCommandership.ChildResCommandershipCollection Commanderships
        {
            get
            {
                if (_Commanderships == null)
                    CreateCommandershipsCollection();
                return _Commanderships;
            }
        }

        virtual protected void CreateObservationDepartmentsCollection()
        {
            _ObservationDepartments = new ResObservationDepartment.ChildResObservationDepartmentCollection(this, new Guid("80d2849f-f9ad-4b35-b5bf-a1293fe87f60"));
            ((ITTChildObjectCollection)_ObservationDepartments).GetChildren();
        }

        protected ResObservationDepartment.ChildResObservationDepartmentCollection _ObservationDepartments = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResObservationDepartment.ChildResObservationDepartmentCollection ObservationDepartments
        {
            get
            {
                if (_ObservationDepartments == null)
                    CreateObservationDepartmentsCollection();
                return _ObservationDepartments;
            }
        }

        virtual protected void CreateTenderCommisionsCollection()
        {
            _TenderCommisions = new ResTenderCommision.ChildResTenderCommisionCollection(this, new Guid("461aa7c9-f3ab-4bae-a755-b9a50d35fc19"));
            ((ITTChildObjectCollection)_TenderCommisions).GetChildren();
        }

        protected ResTenderCommision.ChildResTenderCommisionCollection _TenderCommisions = null;
        public ResTenderCommision.ChildResTenderCommisionCollection TenderCommisions
        {
            get
            {
                if (_TenderCommisions == null)
                    CreateTenderCommisionsCollection();
                return _TenderCommisions;
            }
        }

        virtual protected void CreatePatientAddmissionUnitsCollection()
        {
            _PatientAddmissionUnits = new ResPatientAddmissionUnit.ChildResPatientAddmissionUnitCollection(this, new Guid("1220bb47-a507-47fe-a5fb-9b495f4d8586"));
            ((ITTChildObjectCollection)_PatientAddmissionUnits).GetChildren();
        }

        protected ResPatientAddmissionUnit.ChildResPatientAddmissionUnitCollection _PatientAddmissionUnits = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResPatientAddmissionUnit.ChildResPatientAddmissionUnitCollection PatientAddmissionUnits
        {
            get
            {
                if (_PatientAddmissionUnits == null)
                    CreatePatientAddmissionUnitsCollection();
                return _PatientAddmissionUnits;
            }
        }

        virtual protected void CreateTreatmentDiagnosisUnitsCollection()
        {
            _TreatmentDiagnosisUnits = new ResTreatmentDiagnosisUnit.ChildResTreatmentDiagnosisUnitCollection(this, new Guid("be9b1662-7418-4d9b-b3b0-ed408580b75a"));
            ((ITTChildObjectCollection)_TreatmentDiagnosisUnits).GetChildren();
        }

        protected ResTreatmentDiagnosisUnit.ChildResTreatmentDiagnosisUnitCollection _TreatmentDiagnosisUnits = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResTreatmentDiagnosisUnit.ChildResTreatmentDiagnosisUnitCollection TreatmentDiagnosisUnits
        {
            get
            {
                if (_TreatmentDiagnosisUnits == null)
                    CreateTreatmentDiagnosisUnitsCollection();
                return _TreatmentDiagnosisUnits;
            }
        }

        virtual protected void CreateDrugStoresCollection()
        {
            _DrugStores = new ResPharmacy.ChildResPharmacyCollection(this, new Guid("28349c4d-afa9-47ec-80a7-fc895c1e0f58"));
            ((ITTChildObjectCollection)_DrugStores).GetChildren();
        }

        protected ResPharmacy.ChildResPharmacyCollection _DrugStores = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResPharmacy.ChildResPharmacyCollection DrugStores
        {
            get
            {
                if (_DrugStores == null)
                    CreateDrugStoresCollection();
                return _DrugStores;
            }
        }

        virtual protected void CreateAccountanciesCollection()
        {
            _Accountancies = new ResAccountancy.ChildResAccountancyCollection(this, new Guid("048f6ad0-8ff0-4a76-9691-ce576a36e09f"));
            ((ITTChildObjectCollection)_Accountancies).GetChildren();
        }

        protected ResAccountancy.ChildResAccountancyCollection _Accountancies = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResAccountancy.ChildResAccountancyCollection Accountancies
        {
            get
            {
                if (_Accountancies == null)
                    CreateAccountanciesCollection();
                return _Accountancies;
            }
        }

        virtual protected void CreateQuarantinesCollection()
        {
            _Quarantines = new ResQuarantine.ChildResQuarantineCollection(this, new Guid("660b18c8-8c24-4cf1-9873-ebf471cb5a42"));
            ((ITTChildObjectCollection)_Quarantines).GetChildren();
        }

        protected ResQuarantine.ChildResQuarantineCollection _Quarantines = null;
    /// <summary>
    /// Child collection for XXXXXX
    /// </summary>
        public ResQuarantine.ChildResQuarantineCollection Quarantines
        {
            get
            {
                if (_Quarantines == null)
                    CreateQuarantinesCollection();
                return _Quarantines;
            }
        }

        virtual protected void CreateFactorySectionsCollection()
        {
            _FactorySections = new ResFactorySection.ChildResFactorySectionCollection(this, new Guid("123057da-d806-4a6e-97c9-1bca3f2b967f"));
            ((ITTChildObjectCollection)_FactorySections).GetChildren();
        }

        protected ResFactorySection.ChildResFactorySectionCollection _FactorySections = null;
    /// <summary>
    /// Child collection for XXXXXX-Fabrika Kısımları
    /// </summary>
        public ResFactorySection.ChildResFactorySectionCollection FactorySections
        {
            get
            {
                if (_FactorySections == null)
                    CreateFactorySectionsCollection();
                return _FactorySections;
            }
        }

        virtual protected void CreateHeaderShipsCollection()
        {
            _HeaderShips = new ResHeaderShip.ChildResHeaderShipCollection(this, new Guid("c7b30e86-ea5f-4608-ac05-d5c9b1f2a716"));
            ((ITTChildObjectCollection)_HeaderShips).GetChildren();
        }

        protected ResHeaderShip.ChildResHeaderShipCollection _HeaderShips = null;
    /// <summary>
    /// Child collection for XXXXXX-Müdürlük
    /// </summary>
        public ResHeaderShip.ChildResHeaderShipCollection HeaderShips
        {
            get
            {
                if (_HeaderShips == null)
                    CreateHeaderShipsCollection();
                return _HeaderShips;
            }
        }

        virtual protected void CreateProductionCentersCollection()
        {
            _ProductionCenters = new ResProductionCenter.ChildResProductionCenterCollection(this, new Guid("77e73337-dd80-423e-b887-0154b1a9f3e8"));
            ((ITTChildObjectCollection)_ProductionCenters).GetChildren();
        }

        protected ResProductionCenter.ChildResProductionCenterCollection _ProductionCenters = null;
    /// <summary>
    /// Child collection for XXXXXX-Üretim Merkezleri
    /// </summary>
        public ResProductionCenter.ChildResProductionCenterCollection ProductionCenters
        {
            get
            {
                if (_ProductionCenters == null)
                    CreateProductionCentersCollection();
                return _ProductionCenters;
            }
        }

        protected ResHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResHospital(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResHospital(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResHospital(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESHOSPITAL", dataRow) { }
        protected ResHospital(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESHOSPITAL", dataRow, isImported) { }
        protected ResHospital(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResHospital(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResHospital() : base() { }

    }
}