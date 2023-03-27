
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrInPatientTreatmentClinicApplication")] 

    /// <summary>
    /// Klinik İşlemleri
    /// </summary>
    public  partial class ehrInPatientTreatmentClinicApplication : ehrEpisodeAction, IOAInPatientApplication, IOAInPatientAdmission
    {
        public class ehrInPatientTreatmentClinicApplicationList : TTObjectCollection<ehrInPatientTreatmentClinicApplication> { }
                    
        public class ChildehrInPatientTreatmentClinicApplicationCollection : TTObject.TTChildObjectCollection<ehrInPatientTreatmentClinicApplication>
        {
            public ChildehrInPatientTreatmentClinicApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrInPatientTreatmentClinicApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Klinik Çıkış Tarihi
    /// </summary>
        public DateTime? ClinicDischargeDate
        {
            get { return (DateTime?)this["CLINICDISCHARGEDATE"]; }
            set { this["CLINICDISCHARGEDATE"] = value; }
        }

    /// <summary>
    /// Klinik Yatış Tarihi
    /// </summary>
        public DateTime? ClinicInpatientDate
        {
            get { return (DateTime?)this["CLINICINPATIENTDATE"]; }
            set { this["CLINICINPATIENTDATE"] = value; }
        }

    /// <summary>
    /// Klinik İşlemlerinin Başlatıldığı İşlem-Klinik İşlemleri
    /// </summary>
        public ehrBaseInpatientAdmission ehrBaseInpatientAdmission
        {
            get { return (ehrBaseInpatientAdmission)((ITTObject)this).GetParent("EHRBASEINPATIENTADMISSION"); }
            set { this["EHRBASEINPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateehrNursingApplicationsCollection()
        {
            _ehrNursingApplications = new ehrNursingApplication.ChildehrNursingApplicationCollection(this, new Guid("0bbaadda-db1e-46a9-8273-9666e8d861f1"));
            ((ITTChildObjectCollection)_ehrNursingApplications).GetChildren();
        }

        protected ehrNursingApplication.ChildehrNursingApplicationCollection _ehrNursingApplications = null;
    /// <summary>
    /// Child collection for Klinik İşlemleri-Hemşirelik İşlemleri
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
            _ehrInPatientPhysicianApplications = new ehrInPatientPhysicianApplication.ChildehrInPatientPhysicianApplicationCollection(this, new Guid("d2590ee4-68e3-4976-887f-cbc8f6352a36"));
            ((ITTChildObjectCollection)_ehrInPatientPhysicianApplications).GetChildren();
        }

        protected ehrInPatientPhysicianApplication.ChildehrInPatientPhysicianApplicationCollection _ehrInPatientPhysicianApplications = null;
    /// <summary>
    /// Child collection for Klinik İşlemleri-Klinik Doktor İşlemleri
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

        protected ehrInPatientTreatmentClinicApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrInPatientTreatmentClinicApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrInPatientTreatmentClinicApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrInPatientTreatmentClinicApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrInPatientTreatmentClinicApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRINPATIENTTREATMENTCLINICAPPLICATION", dataRow) { }
        protected ehrInPatientTreatmentClinicApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRINPATIENTTREATMENTCLINICAPPLICATION", dataRow, isImported) { }
        public ehrInPatientTreatmentClinicApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrInPatientTreatmentClinicApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrInPatientTreatmentClinicApplication() : base() { }

    }
}