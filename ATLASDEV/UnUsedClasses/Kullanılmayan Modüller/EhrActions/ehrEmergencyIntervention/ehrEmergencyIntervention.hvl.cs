
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrEmergencyIntervention")] 

    /// <summary>
    /// Acil Hasta Müdahale
    /// </summary>
    public  partial class ehrEmergencyIntervention : ehrEpisodeAction, IOAExamination
    {
        public class ehrEmergencyInterventionList : TTObjectCollection<ehrEmergencyIntervention> { }
                    
        public class ChildehrEmergencyInterventionCollection : TTObject.TTChildObjectCollection<ehrEmergencyIntervention>
        {
            public ChildehrEmergencyInterventionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrEmergencyInterventionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Travmalı
    /// </summary>
        public bool? IsTraumaticPatient
        {
            get { return (bool?)this["ISTRAUMATICPATIENT"]; }
            set { this["ISTRAUMATICPATIENT"] = value; }
        }

    /// <summary>
    /// Şikayeti
    /// </summary>
        public object Complaint
        {
            get { return (object)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

        public object PatientFolder
        {
            get { return (object)this["PATIENTFOLDER"]; }
            set { this["PATIENTFOLDER"] = value; }
        }

    /// <summary>
    /// Çıkış Tarihi
    /// </summary>
        public DateTime? DischargeTime
        {
            get { return (DateTime?)this["DISCHARGETIME"]; }
            set { this["DISCHARGETIME"] = value; }
        }

    /// <summary>
    /// Giriş Tarihi
    /// </summary>
        public DateTime? EnteranceTime
        {
            get { return (DateTime?)this["ENTERANCETIME"]; }
            set { this["ENTERANCETIME"] = value; }
        }

        virtual protected void CreateehrNursingApplicationsCollection()
        {
            _ehrNursingApplications = new ehrNursingApplication.ChildehrNursingApplicationCollection(this, new Guid("b7414b80-bfbe-4221-8aea-76697b49257c"));
            ((ITTChildObjectCollection)_ehrNursingApplications).GetChildren();
        }

        protected ehrNursingApplication.ChildehrNursingApplicationCollection _ehrNursingApplications = null;
    /// <summary>
    /// Child collection for Acil Müdahale-Hemşirelik İşlemleri
    /// </summary>
        public ehrNursingApplication.ChildehrNursingApplicationCollection ehrNursingApplications
        {
            get
            {
                if (_ehrNursingApplications == null)
                    CreateehrNursingApplicationsCollection();
                return _ehrNursingApplications;
            }
        }

        virtual protected void CreateehrInPatientPhysicianApplicationsCollection()
        {
            _ehrInPatientPhysicianApplications = new ehrInPatientPhysicianApplication.ChildehrInPatientPhysicianApplicationCollection(this, new Guid("72e7a936-6d07-4c01-9dd1-67c06c16cc7b"));
            ((ITTChildObjectCollection)_ehrInPatientPhysicianApplications).GetChildren();
        }

        protected ehrInPatientPhysicianApplication.ChildehrInPatientPhysicianApplicationCollection _ehrInPatientPhysicianApplications = null;
    /// <summary>
    /// Child collection for Acil Müdahale-Klinik Doktor İşlemleri
    /// </summary>
        public ehrInPatientPhysicianApplication.ChildehrInPatientPhysicianApplicationCollection ehrInPatientPhysicianApplications
        {
            get
            {
                if (_ehrInPatientPhysicianApplications == null)
                    CreateehrInPatientPhysicianApplicationsCollection();
                return _ehrInPatientPhysicianApplications;
            }
        }

        virtual protected void CreateehrPatientExaminationsCollection()
        {
            _ehrPatientExaminations = new ehrPatientExamination.ChildehrPatientExaminationCollection(this, new Guid("9eb32085-5351-4531-a423-4724b3c09264"));
            ((ITTChildObjectCollection)_ehrPatientExaminations).GetChildren();
        }

        protected ehrPatientExamination.ChildehrPatientExaminationCollection _ehrPatientExaminations = null;
    /// <summary>
    /// Child collection for Acil Müdahale-Hasta Muayenesi
    /// </summary>
        public ehrPatientExamination.ChildehrPatientExaminationCollection ehrPatientExaminations
        {
            get
            {
                if (_ehrPatientExaminations == null)
                    CreateehrPatientExaminationsCollection();
                return _ehrPatientExaminations;
            }
        }

        protected ehrEmergencyIntervention(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrEmergencyIntervention(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrEmergencyIntervention(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrEmergencyIntervention(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrEmergencyIntervention(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHREMERGENCYINTERVENTION", dataRow) { }
        protected ehrEmergencyIntervention(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHREMERGENCYINTERVENTION", dataRow, isImported) { }
        public ehrEmergencyIntervention(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrEmergencyIntervention(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrEmergencyIntervention() : base() { }

    }
}