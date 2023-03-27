
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CokluOzelDurum")] 

    public  partial class CokluOzelDurum : TTObject
    {
        public class CokluOzelDurumList : TTObjectCollection<CokluOzelDurum> { }
                    
        public class ChildCokluOzelDurumCollection : TTObject.TTChildObjectCollection<CokluOzelDurum>
        {
            public ChildCokluOzelDurumCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCokluOzelDurumCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseBedProcedure BaseBedProcedure
        {
            get { return (BaseBedProcedure)((ITTObject)this).GetParent("BASEBEDPROCEDURE"); }
            set { this["BASEBEDPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PlannedMedicalActionOrderDetail PlannedMedicalActionOD
        {
            get { return (PlannedMedicalActionOrderDetail)((ITTObject)this).GetParent("PLANNEDMEDICALACTIONOD"); }
            set { this["PLANNEDMEDICALACTIONOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BloodBankBloodProducts BloodBankBloodProducts
        {
            get { return (BloodBankBloodProducts)((ITTObject)this).GetParent("BLOODBANKBLOODPRODUCTS"); }
            set { this["BLOODBANKBLOODPRODUCTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Genetic Çoklu Özel Durum
    /// </summary>
        public Genetic Genetic
        {
            get { return (Genetic)((ITTObject)this).GetParent("GENETIC"); }
            set { this["GENETIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// NuclearMedicine Çoklu Özel Durum
    /// </summary>
        public NuclearMedicine NuclearMedicine
        {
            get { return (NuclearMedicine)((ITTObject)this).GetParent("NUCLEARMEDICINE"); }
            set { this["NUCLEARMEDICINE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// RadiologyTest Çoklu Özel Durum
    /// </summary>
        public RadiologyTest RadiologyTest
        {
            get { return (RadiologyTest)((ITTObject)this).GetParent("RADIOLOGYTEST"); }
            set { this["RADIOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PathologyTest Çoklu Özel Durum
    /// </summary>
        public Pathology PathologyTest
        {
            get { return (Pathology)((ITTObject)this).GetParent("PATHOLOGYTEST"); }
            set { this["PATHOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PhysiotherapyOrder Çoklu Özel Durum
    /// </summary>
        public PhysiotherapyOrder PhysiotherapyOrder
        {
            get { return (PhysiotherapyOrder)((ITTObject)this).GetParent("PHYSIOTHERAPYORDER"); }
            set { this["PHYSIOTHERAPYORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ExternalProcedureRequest Çoklu Özel Durum
    /// </summary>
        public ExternalProcedureRequest ExternalProcedureRequest
        {
            get { return (ExternalProcedureRequest)((ITTObject)this).GetParent("EXTERNALPROCEDUREREQUEST"); }
            set { this["EXTERNALPROCEDUREREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// FollowUpExamination Çoklu Özel Durum
    /// </summary>
        public FollowUpExamination FollowUpExamination
        {
            get { return (FollowUpExamination)((ITTObject)this).GetParent("FOLLOWUPEXAMINATION"); }
            set { this["FOLLOWUPEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PatientExamination Çoklu Özel Durum
    /// </summary>
        public PatientExamination PatientExamination
        {
            get { return (PatientExamination)((ITTObject)this).GetParent("PATIENTEXAMINATION"); }
            set { this["PATIENTEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DialysisOrderDetail DialysisOrderDetail
        {
            get { return (DialysisOrderDetail)((ITTObject)this).GetParent("DIALYSISORDERDETAIL"); }
            set { this["DIALYSISORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OrthesisProsthesisProcedure OrthesisProsthesisProcedure
        {
            get { return (OrthesisProsthesisProcedure)((ITTObject)this).GetParent("ORTHESISPROSTHESISPROCEDURE"); }
            set { this["ORTHESISPROSTHESISPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountTransaction AccountTransaction
        {
            get { return (AccountTransaction)((ITTObject)this).GetParent("ACCOUNTTRANSACTION"); }
            set { this["ACCOUNTTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HyperbarikOxygenTreatmentOrderDetail HyperbarikOxygenTreatmentOD
        {
            get { return (HyperbarikOxygenTreatmentOrderDetail)((ITTObject)this).GetParent("HYPERBARIKOXYGENTREATMENTOD"); }
            set { this["HYPERBARIKOXYGENTREATMENTOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication InPatientTreatmentClinicApp
        {
            get { return (InPatientTreatmentClinicApplication)((ITTObject)this).GetParent("INPATIENTTREATMENTCLINICAPP"); }
            set { this["INPATIENTTREATMENTCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratory Procedure Çoklu Özel Durum
    /// </summary>
        public LaboratoryProcedure LaboratoryProcedure
        {
            get { return (LaboratoryProcedure)((ITTObject)this).GetParent("LABORATORYPROCEDURE"); }
            set { this["LABORATORYPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PhysiotherapyOrderDetail CokluOzelDurum
    /// </summary>
        public PhysiotherapyOrderDetail PhysiotherapyOrderDetail
        {
            get { return (PhysiotherapyOrderDetail)((ITTObject)this).GetParent("PHYSIOTHERAPYORDERDETAIL"); }
            set { this["PHYSIOTHERAPYORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseSurgeryAndManipulationProcedure BaseSurAndManProcedure
        {
            get { return (BaseSurgeryAndManipulationProcedure)((ITTObject)this).GetParent("BASESURANDMANPROCEDURE"); }
            set { this["BASESURANDMANPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StoneBreakUpRequest StoneBreakUpRequest
        {
            get { return (StoneBreakUpRequest)((ITTObject)this).GetParent("STONEBREAKUPREQUEST"); }
            set { this["STONEBREAKUPREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseTreatmentMaterial BaseTreatmentMaterial
        {
            get { return (BaseTreatmentMaterial)((ITTObject)this).GetParent("BASETREATMENTMATERIAL"); }
            set { this["BASETREATMENTMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Çoklu Özel Durum
    /// </summary>
        public SEPDiagnosis SEPDiagnosis
        {
            get { return (SEPDiagnosis)((ITTObject)this).GetParent("SEPDIAGNOSIS"); }
            set { this["SEPDIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Consultation Çoklu Özel Durum
    /// </summary>
        public Consultation Consultation
        {
            get { return (Consultation)((ITTObject)this).GetParent("CONSULTATION"); }
            set { this["CONSULTATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CokluOzelDurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CokluOzelDurum(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CokluOzelDurum(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CokluOzelDurum(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CokluOzelDurum(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COKLUOZELDURUM", dataRow) { }
        protected CokluOzelDurum(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COKLUOZELDURUM", dataRow, isImported) { }
        public CokluOzelDurum(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CokluOzelDurum(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CokluOzelDurum() : base() { }

    }
}