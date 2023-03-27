
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOrderIntroduction")] 

    /// <summary>
    /// İlaç Direktifi Giriş
    /// </summary>
    public  partial class DrugOrderIntroduction : EpisodeActionWithDiagnosis
    {
        public class DrugOrderIntroductionList : TTObjectCollection<DrugOrderIntroduction> { }
                    
        public class ChildDrugOrderIntroductionCollection : TTObject.TTChildObjectCollection<DrugOrderIntroduction>
        {
            public ChildDrugOrderIntroductionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOrderIntroductionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("16b17360-e7a6-422e-80c8-708d922eb490"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("dd8442ce-de95-4869-8ea1-5dbe7f5be4c1"); } }
    /// <summary>
    /// Elektronik İmza ile Tamamlandı
    /// </summary>
            public static Guid CompletedWithSign { get { return new Guid("c1f3e608-6dad-4c8f-948f-28aa72c78d65"); } }
        }

    /// <summary>
    /// Sadece Barkodlular
    /// </summary>
        public bool? IsBarcode
        {
            get { return (bool?)this["ISBARCODE"]; }
            set { this["ISBARCODE"] = value; }
        }

    /// <summary>
    /// E Reçete Şifresi 
    /// </summary>
        public string ERecetePassword
        {
            get { return (string)this["ERECETEPASSWORD"]; }
            set { this["ERECETEPASSWORD"] = value; }
        }

    /// <summary>
    /// Bir Daha Sorma Kullanıcı Bilgilerine Kaydet
    /// </summary>
        public bool? IsRepeated
        {
            get { return (bool?)this["ISREPEATED"]; }
            set { this["ISREPEATED"] = value; }
        }

    /// <summary>
    /// Reçete Açk.
    /// </summary>
        public string DrugDescription
        {
            get { return (string)this["DRUGDESCRIPTION"]; }
            set { this["DRUGDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Sadece Mevcutlu İlaçlar
    /// </summary>
        public bool? IsInheldDrug
        {
            get { return (bool?)this["ISINHELDDRUG"]; }
            set { this["ISINHELDDRUG"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Rutin Gün
    /// </summary>
        public double? RoutineDay
        {
            get { return (double?)this["ROUTINEDAY"]; }
            set { this["ROUTINEDAY"] = value; }
        }

    /// <summary>
    /// Rutin Doz
    /// </summary>
        public double? RoutineDose
        {
            get { return (double?)this["ROUTINEDOSE"]; }
            set { this["ROUTINEDOSE"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public double? Dose
        {
            get { return (double?)this["DOSE"]; }
            set { this["DOSE"] = value; }
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
    /// Birim
    /// </summary>
        public string Unit
        {
            get { return (string)this["UNIT"]; }
            set { this["UNIT"] = value; }
        }

    /// <summary>
    /// Rutin Değerleri Kullan
    /// </summary>
        public bool? UseRoutineValue
        {
            get { return (bool?)this["USEROUTINEVALUE"]; }
            set { this["USEROUTINEVALUE"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public double? OrderDose
        {
            get { return (double?)this["ORDERDOSE"]; }
            set { this["ORDERDOSE"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public double? OrderFrequency
        {
            get { return (double?)this["ORDERFREQUENCY"]; }
            set { this["ORDERFREQUENCY"] = value; }
        }

    /// <summary>
    /// Gün
    /// </summary>
        public double? OrderDay
        {
            get { return (double?)this["ORDERDAY"]; }
            set { this["ORDERDAY"] = value; }
        }

    /// <summary>
    /// İlaç
    /// </summary>
        public string DrugName
        {
            get { return (string)this["DRUGNAME"]; }
            set { this["DRUGNAME"] = value; }
        }

    /// <summary>
    /// DrugObjectID
    /// </summary>
        public Guid? DrugObjectID
        {
            get { return (Guid?)this["DRUGOBJECTID"]; }
            set { this["DRUGOBJECTID"] = value; }
        }

    /// <summary>
    /// Maksimum Doz
    /// </summary>
        public double? MaxDose
        {
            get { return (double?)this["MAXDOSE"]; }
            set { this["MAXDOSE"] = value; }
        }

    /// <summary>
    /// Maksimum Gün
    /// </summary>
        public double? MaxDoseDay
        {
            get { return (double?)this["MAXDOSEDAY"]; }
            set { this["MAXDOSEDAY"] = value; }
        }

    /// <summary>
    /// Hasta Yanında Getirdi
    /// </summary>
        public bool? PatientOwnDrug
        {
            get { return (bool?)this["PATIENTOWNDRUG"]; }
            set { this["PATIENTOWNDRUG"] = value; }
        }

    /// <summary>
    /// Otomatik Arama
    /// </summary>
        public bool? AutoSearch
        {
            get { return (bool?)this["AUTOSEARCH"]; }
            set { this["AUTOSEARCH"] = value; }
        }

    /// <summary>
    /// Kullanım Şekli
    /// </summary>
        public DrugUsageTypeEnum? DrugUsageType
        {
            get { return (DrugUsageTypeEnum?)(int?)this["DRUGUSAGETYPE"]; }
            set { this["DRUGUSAGETYPE"] = value; }
        }

        public bool? CheckFavoriteDrug
        {
            get { return (bool?)this["CHECKFAVORITEDRUG"]; }
            set { this["CHECKFAVORITEDRUG"] = value; }
        }

    /// <summary>
    /// Uygulama Başlangıç Zamanı
    /// </summary>
        public DateTime? PlannedStartTime
        {
            get { return (DateTime?)this["PLANNEDSTARTTIME"]; }
            set { this["PLANNEDSTARTTIME"] = value; }
        }

    /// <summary>
    /// Konsültasyon Order
    /// </summary>
        public bool? IsConsultaitonOrder
        {
            get { return (bool?)this["ISCONSULTAITONORDER"]; }
            set { this["ISCONSULTAITONORDER"] = value; }
        }

    /// <summary>
    /// Reçete Açk. Türü
    /// </summary>
        public DescriptionTypeEnum? DrugDescriptionType
        {
            get { return (DescriptionTypeEnum?)(int?)this["DRUGDESCRIPTIONTYPE"]; }
            set { this["DRUGDESCRIPTIONTYPE"] = value; }
        }

    /// <summary>
    /// Şablon
    /// </summary>
        public bool? IsTemplate
        {
            get { return (bool?)this["ISTEMPLATE"]; }
            set { this["ISTEMPLATE"] = value; }
        }

    /// <summary>
    /// Şablon İsmi
    /// </summary>
        public string TemplateDescription
        {
            get { return (string)this["TEMPLATEDESCRIPTION"]; }
            set { this["TEMPLATEDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Acil İlaç
    /// </summary>
        public bool? IsImmediate
        {
            get { return (bool?)this["ISIMMEDIATE"]; }
            set { this["ISIMMEDIATE"] = value; }
        }

        public DrugOrderTypeEnum? DrugOrderType
        {
            get { return (DrugOrderTypeEnum?)(int?)this["DRUGORDERTYPE"]; }
            set { this["DRUGORDERTYPE"] = value; }
        }

    /// <summary>
    /// Kullanım Periyot Birimi
    /// </summary>
        public PeriodUnitTypeEnum? PeriodUnitType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["PERIODUNITTYPE"]; }
            set { this["PERIODUNITTYPE"] = value; }
        }

    /// <summary>
    /// Paket Adedi
    /// </summary>
        public double? PackageAmount
        {
            get { return (double?)this["PACKAGEAMOUNT"]; }
            set { this["PACKAGEAMOUNT"] = value; }
        }

    /// <summary>
    /// Lüzum Halinde
    /// </summary>
        public bool? CaseOfNeed
        {
            get { return (bool?)this["CASEOFNEED"]; }
            set { this["CASEOFNEED"] = value; }
        }

        public InPatientPhysicianApplication ActiveInPatientPhysicianApp
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("ACTIVEINPATIENTPHYSICIANAPP"); }
            set { this["ACTIVEINPATIENTPHYSICIANAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDrugOrderIntroductionDetailsCollection()
        {
            _DrugOrderIntroductionDetails = new DrugOrderIntroductionDet.ChildDrugOrderIntroductionDetCollection(this, new Guid("a035445d-fb06-4b10-8cb2-f7c9151b2123"));
            ((ITTChildObjectCollection)_DrugOrderIntroductionDetails).GetChildren();
        }

        protected DrugOrderIntroductionDet.ChildDrugOrderIntroductionDetCollection _DrugOrderIntroductionDetails = null;
        public DrugOrderIntroductionDet.ChildDrugOrderIntroductionDetCollection DrugOrderIntroductionDetails
        {
            get
            {
                if (_DrugOrderIntroductionDetails == null)
                    CreateDrugOrderIntroductionDetailsCollection();
                return _DrugOrderIntroductionDetails;
            }
        }

        virtual protected void CreateOldDrugOrdersCollection()
        {
            _OldDrugOrders = new OldDrugOrder.ChildOldDrugOrderCollection(this, new Guid("f1bbbcb1-267d-44ef-bde5-3b72692c573b"));
            ((ITTChildObjectCollection)_OldDrugOrders).GetChildren();
        }

        protected OldDrugOrder.ChildOldDrugOrderCollection _OldDrugOrders = null;
        public OldDrugOrder.ChildOldDrugOrderCollection OldDrugOrders
        {
            get
            {
                if (_OldDrugOrders == null)
                    CreateOldDrugOrdersCollection();
                return _OldDrugOrders;
            }
        }

        virtual protected void CreateInpatientPresDetailsCollection()
        {
            _InpatientPresDetails = new InpatientPresDetail.ChildInpatientPresDetailCollection(this, new Guid("e462a591-e280-4820-8971-19b2a0121ceb"));
            ((ITTChildObjectCollection)_InpatientPresDetails).GetChildren();
        }

        protected InpatientPresDetail.ChildInpatientPresDetailCollection _InpatientPresDetails = null;
        public InpatientPresDetail.ChildInpatientPresDetailCollection InpatientPresDetails
        {
            get
            {
                if (_InpatientPresDetails == null)
                    CreateInpatientPresDetailsCollection();
                return _InpatientPresDetails;
            }
        }

        virtual protected void CreateDiagnosisForPrescriptionsCollection()
        {
            _DiagnosisForPrescriptions = new DiagnosisForPresc.ChildDiagnosisForPrescCollection(this, new Guid("ca761823-7e94-475b-a38c-6879d3429137"));
            ((ITTChildObjectCollection)_DiagnosisForPrescriptions).GetChildren();
        }

        protected DiagnosisForPresc.ChildDiagnosisForPrescCollection _DiagnosisForPrescriptions = null;
        public DiagnosisForPresc.ChildDiagnosisForPrescCollection DiagnosisForPrescriptions
        {
            get
            {
                if (_DiagnosisForPrescriptions == null)
                    CreateDiagnosisForPrescriptionsCollection();
                return _DiagnosisForPrescriptions;
            }
        }

        virtual protected void CreateDiagnosisForSPTSesCollection()
        {
            _DiagnosisForSPTSes = new DiagnosisForSPTS.ChildDiagnosisForSPTSCollection(this, new Guid("7e3aa4a2-f501-477c-9991-a4e3a8f1ec68"));
            ((ITTChildObjectCollection)_DiagnosisForSPTSes).GetChildren();
        }

        protected DiagnosisForSPTS.ChildDiagnosisForSPTSCollection _DiagnosisForSPTSes = null;
        public DiagnosisForSPTS.ChildDiagnosisForSPTSCollection DiagnosisForSPTSes
        {
            get
            {
                if (_DiagnosisForSPTSes == null)
                    CreateDiagnosisForSPTSesCollection();
                return _DiagnosisForSPTSes;
            }
        }

        virtual protected void CreateOutpatientPresDetailsCollection()
        {
            _OutpatientPresDetails = new OutpatientPresDetail.ChildOutpatientPresDetailCollection(this, new Guid("0bc1398f-1288-46f9-99c2-aa6c8d7015d2"));
            ((ITTChildObjectCollection)_OutpatientPresDetails).GetChildren();
        }

        protected OutpatientPresDetail.ChildOutpatientPresDetailCollection _OutpatientPresDetails = null;
        public OutpatientPresDetail.ChildOutpatientPresDetailCollection OutpatientPresDetails
        {
            get
            {
                if (_OutpatientPresDetails == null)
                    CreateOutpatientPresDetailsCollection();
                return _OutpatientPresDetails;
            }
        }

        protected DrugOrderIntroduction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOrderIntroduction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOrderIntroduction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOrderIntroduction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOrderIntroduction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGORDERINTRODUCTION", dataRow) { }
        protected DrugOrderIntroduction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGORDERINTRODUCTION", dataRow, isImported) { }
        public DrugOrderIntroduction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOrderIntroduction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOrderIntroduction() : base() { }

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