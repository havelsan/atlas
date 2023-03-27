
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EDisabledReport")] 

    /// <summary>
    /// E - Engelli veya Çözger Rapor Entegrasyonunda kullanılacak nesne
    /// </summary>
    public  partial class EDisabledReport : TTObject
    {
        public class EDisabledReportList : TTObjectCollection<EDisabledReport> { }
                    
        public class ChildEDisabledReportCollection : TTObject.TTChildObjectCollection<EDisabledReport>
        {
            public ChildEDisabledReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEDisabledReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başvuru nedeni
    /// </summary>
        public string ApplicationExplanation
        {
            get { return (string)this["APPLICATIONEXPLANATION"]; }
            set { this["APPLICATIONEXPLANATION"] = value; }
        }

    /// <summary>
    /// Hasta Entegrasyon Id'si
    /// </summary>
        public string PatientAppId
        {
            get { return (string)this["PATIENTAPPID"]; }
            set { this["PATIENTAPPID"] = value; }
        }

    /// <summary>
    /// Müracaat Nedeni
    /// </summary>
        public EngelliRaporuMuracaatNedeniEnum? ApplicationReason
        {
            get { return (EngelliRaporuMuracaatNedeniEnum?)(int?)this["APPLICATIONREASON"]; }
            set { this["APPLICATIONREASON"] = value; }
        }

    /// <summary>
    /// Müracaat Tipi
    /// </summary>
        public EngelliRaporuMuracaatTipiEnum? ApplicationType
        {
            get { return (EngelliRaporuMuracaatTipiEnum?)(int?)this["APPLICATIONTYPE"]; }
            set { this["APPLICATIONTYPE"] = value; }
        }

    /// <summary>
    /// Kurumsal Müracaat Tipleri
    /// </summary>
        public EngelliRaporuKurumsalMuracaatTuruEnum? CorporateApplicationType
        {
            get { return (EngelliRaporuKurumsalMuracaatTuruEnum?)(int?)this["CORPORATEAPPLICATIONTYPE"]; }
            set { this["CORPORATEAPPLICATIONTYPE"] = value; }
        }

    /// <summary>
    /// Kişisel Müracaat Tipi
    /// </summary>
        public EngelliRaporuKisiselMuracaatTuruEnum? PersonalApplicationType
        {
            get { return (EngelliRaporuKisiselMuracaatTuruEnum?)(int?)this["PERSONALAPPLICATIONTYPE"]; }
            set { this["PERSONALAPPLICATIONTYPE"] = value; }
        }

    /// <summary>
    /// Terör Kaza Yaralanma Muracaat Tipi
    /// </summary>
        public EngelliRaporuTerorKazaMuracaatTipiEnum? TerrorAccidentInjuryAppType
        {
            get { return (EngelliRaporuTerorKazaMuracaatTipiEnum?)(int?)this["TERRORACCIDENTINJURYAPPTYPE"]; }
            set { this["TERRORACCIDENTINJURYAPPTYPE"] = value; }
        }

    /// <summary>
    /// Terör Kaza Yaralanma Müracaat Nedeni 
    /// </summary>
        public EngelliRaporuTerorKazaMuracaatNedeniEnum? TerrorAccidentInjuryAppReason
        {
            get { return (EngelliRaporuTerorKazaMuracaatNedeniEnum?)(int?)this["TERRORACCIDENTINJURYAPPREASON"]; }
            set { this["TERRORACCIDENTINJURYAPPREASON"] = value; }
        }

    /// <summary>
    /// Müracaat Kurul Adımı
    /// </summary>
        public EngelliRaporuMuayeneAdimiEnum? ApplicationCouncilSituation
        {
            get { return (EngelliRaporuMuayeneAdimiEnum?)(int?)this["APPLICATIONCOUNCILSITUATION"]; }
            set { this["APPLICATIONCOUNCILSITUATION"] = value; }
        }

    /// <summary>
    /// Çözger Raporu ise bu property true olmalıdır
    /// </summary>
        public bool? IsCozgerReport
        {
            get { return (bool?)this["ISCOZGERREPORT"]; }
            set { this["ISCOZGERREPORT"] = value; }
        }

        virtual protected void CreateHCExaminationComponentCollection()
        {
            _HCExaminationComponent = new HCExaminationComponent.ChildHCExaminationComponentCollection(this, new Guid("0ed3afa9-de2a-4b8d-b9f9-6c9662f47a50"));
            ((ITTChildObjectCollection)_HCExaminationComponent).GetChildren();
        }

        protected HCExaminationComponent.ChildHCExaminationComponentCollection _HCExaminationComponent = null;
    /// <summary>
    /// Child collection for E-Engelli Raporu Entegrasyon Nesnesi
    /// </summary>
        public HCExaminationComponent.ChildHCExaminationComponentCollection HCExaminationComponent
        {
            get
            {
                if (_HCExaminationComponent == null)
                    CreateHCExaminationComponentCollection();
                return _HCExaminationComponent;
            }
        }

        virtual protected void CreatePatientAdmissionCollection()
        {
            _PatientAdmission = new PatientAdmission.ChildPatientAdmissionCollection(this, new Guid("fba8cdec-e029-49b5-b370-cab4d29f98ea"));
            ((ITTChildObjectCollection)_PatientAdmission).GetChildren();
        }

        protected PatientAdmission.ChildPatientAdmissionCollection _PatientAdmission = null;
        public PatientAdmission.ChildPatientAdmissionCollection PatientAdmission
        {
            get
            {
                if (_PatientAdmission == null)
                    CreatePatientAdmissionCollection();
                return _PatientAdmission;
            }
        }

        protected EDisabledReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EDisabledReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EDisabledReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EDisabledReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EDisabledReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EDISABLEDREPORT", dataRow) { }
        protected EDisabledReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EDISABLEDREPORT", dataRow, isImported) { }
        public EDisabledReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EDisabledReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EDisabledReport() : base() { }

    }
}