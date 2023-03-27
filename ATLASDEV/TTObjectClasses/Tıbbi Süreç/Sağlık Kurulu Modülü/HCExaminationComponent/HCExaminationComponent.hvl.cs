
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCExaminationComponent")] 

    public  partial class HCExaminationComponent : TTObject
    {
        public class HCExaminationComponentList : TTObjectCollection<HCExaminationComponent> { }
                    
        public class ChildHCExaminationComponentCollection : TTObject.TTChildObjectCollection<HCExaminationComponent>
        {
            public ChildHCExaminationComponentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCExaminationComponentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Tedavi Bilgileri
    /// </summary>
        public string TreatmentInfo
        {
            get { return (string)this["TREATMENTINFO"]; }
            set { this["TREATMENTINFO"] = value; }
        }

    /// <summary>
    /// Klinik Bulgular
    /// </summary>
        public string ClinicalInfo
        {
            get { return (string)this["CLINICALINFO"]; }
            set { this["CLINICALINFO"] = value; }
        }

    /// <summary>
    /// Laboratuvar Bulgular
    /// </summary>
        public string LaboratoryInfo
        {
            get { return (string)this["LABORATORYINFO"]; }
            set { this["LABORATORYINFO"] = value; }
        }

    /// <summary>
    /// Radyolojik Bulgular
    /// </summary>
        public string RadiologicalInfo
        {
            get { return (string)this["RADIOLOGICALINFO"]; }
            set { this["RADIOLOGICALINFO"] = value; }
        }

    /// <summary>
    /// Muamele Sayısı
    /// </summary>
        public int? NumberOfProcess
        {
            get { return (int?)this["NUMBEROFPROCESS"]; }
            set { this["NUMBEROFPROCESS"] = value; }
        }

    /// <summary>
    /// Karar Teklifi
    /// </summary>
        public string OfferOfDecision
        {
            get { return (string)this["OFFEROFDECISION"]; }
            set { this["OFFEROFDECISION"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Engel Oarnı
    /// </summary>
        public double? DisabledRatio
        {
            get { return (double?)this["DISABLEDRATIO"]; }
            set { this["DISABLEDRATIO"] = value; }
        }

    /// <summary>
    /// Sağlam
    /// </summary>
        public bool? IsHealthy
        {
            get { return (bool?)this["ISHEALTHY"]; }
            set { this["ISHEALTHY"] = value; }
        }

    /// <summary>
    /// Engelli Raporu Muayene Id
    /// </summary>
        public string EngelliRaporuMuayeneId
        {
            get { return (string)this["ENGELLIRAPORUMUAYENEID"]; }
            set { this["ENGELLIRAPORUMUAYENEID"] = value; }
        }

    /// <summary>
    /// E-Durum Bildirir Kurul Muayene Id
    /// </summary>
        public string EDurumBildirirMuayeneId
        {
            get { return (string)this["EDURUMBILDIRIRMUAYENEID"]; }
            set { this["EDURUMBILDIRIRMUAYENEID"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// E-Engelli Raporu Entegrasyon Nesnesi
    /// </summary>
        public EDisabledReport EDisabledReport
        {
            get { return (EDisabledReport)((ITTObject)this).GetParent("EDISABLEDREPORT"); }
            set { this["EDISABLEDREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// E-Durum Bildirir Kurul Raporu Entegrasyon Nesnesi
    /// </summary>
        public EStatusNotRepCommitteeObj EStatusNotRepCommitteeObj
        {
            get { return (EStatusNotRepCommitteeObj)((ITTObject)this).GetParent("ESTATUSNOTREPCOMMITTEEOBJ"); }
            set { this["ESTATUSNOTREPCOMMITTEEOBJ"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CozgerSpecReqArea CozgerSpecReqArea
        {
            get { return (CozgerSpecReqArea)((ITTObject)this).GetParent("COZGERSPECREQAREA"); }
            set { this["COZGERSPECREQAREA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CozgerSpecReqLevel CozgerSpecReqLevel
        {
            get { return (CozgerSpecReqLevel)((ITTObject)this).GetParent("COZGERSPECREQLEVEL"); }
            set { this["COZGERSPECREQLEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateHCExaminationDisabledRatioCollection()
        {
            _HCExaminationDisabledRatio = new HCExaminationDisabledRatio.ChildHCExaminationDisabledRatioCollection(this, new Guid("3f81f236-1dd5-405c-aa54-6ed6653d5f9d"));
            ((ITTChildObjectCollection)_HCExaminationDisabledRatio).GetChildren();
        }

        protected HCExaminationDisabledRatio.ChildHCExaminationDisabledRatioCollection _HCExaminationDisabledRatio = null;
        public HCExaminationDisabledRatio.ChildHCExaminationDisabledRatioCollection HCExaminationDisabledRatio
        {
            get
            {
                if (_HCExaminationDisabledRatio == null)
                    CreateHCExaminationDisabledRatioCollection();
                return _HCExaminationDisabledRatio;
            }
        }

        virtual protected void CreatePatientExaminationCollection()
        {
            _PatientExamination = new PatientExamination.ChildPatientExaminationCollection(this, new Guid("3525419f-187b-4a9a-825e-b6f8634e17f1"));
            ((ITTChildObjectCollection)_PatientExamination).GetChildren();
        }

        protected PatientExamination.ChildPatientExaminationCollection _PatientExamination = null;
        public PatientExamination.ChildPatientExaminationCollection PatientExamination
        {
            get
            {
                if (_PatientExamination == null)
                    CreatePatientExaminationCollection();
                return _PatientExamination;
            }
        }

        protected HCExaminationComponent(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCExaminationComponent(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCExaminationComponent(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCExaminationComponent(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCExaminationComponent(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCEXAMINATIONCOMPONENT", dataRow) { }
        protected HCExaminationComponent(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCEXAMINATIONCOMPONENT", dataRow, isImported) { }
        public HCExaminationComponent(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCExaminationComponent(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCExaminationComponent() : base() { }

    }
}