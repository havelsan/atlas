
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrInPatientPhysicianApplication")] 

    /// <summary>
    /// Klinik Doktor İşlemleri
    /// </summary>
    public  partial class ehrInPatientPhysicianApplication : ehrEpisodeAction, IOAInPatientApplication
    {
        public class ehrInPatientPhysicianApplicationList : TTObjectCollection<ehrInPatientPhysicianApplication> { }
                    
        public class ChildehrInPatientPhysicianApplicationCollection : TTObject.TTChildObjectCollection<ehrInPatientPhysicianApplication>
        {
            public ChildehrInPatientPhysicianApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrInPatientPhysicianApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Fizik Muayene
    /// </summary>
        public object PhysicalExamination
        {
            get { return (object)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Şikayet
    /// </summary>
        public object Complaint
        {
            get { return (object)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

    /// <summary>
    /// Devamlı İlaçlar
    /// </summary>
        public object ContinuousDrugs
        {
            get { return (object)this["CONTINUOUSDRUGS"]; }
            set { this["CONTINUOUSDRUGS"] = value; }
        }

    /// <summary>
    /// Karar ve İşlem
    /// </summary>
        public object DecisionAndAction
        {
            get { return (object)this["DECISIONANDACTION"]; }
            set { this["DECISIONANDACTION"] = value; }
        }

    /// <summary>
    /// Muayene Özeti
    /// </summary>
        public object ExaminationSummary
        {
            get { return (object)this["EXAMINATIONSUMMARY"]; }
            set { this["EXAMINATIONSUMMARY"] = value; }
        }

    /// <summary>
    /// Alışkanlıklar
    /// </summary>
        public object Habits
        {
            get { return (object)this["HABITS"]; }
            set { this["HABITS"] = value; }
        }

    /// <summary>
    /// Hasta Dosyası
    /// </summary>
        public object InPatientFolder
        {
            get { return (object)this["INPATIENTFOLDER"]; }
            set { this["INPATIENTFOLDER"] = value; }
        }

    /// <summary>
    /// Soygeçmiş
    /// </summary>
        public object PatientFamilyHistory
        {
            get { return (object)this["PATIENTFAMILYHISTORY"]; }
            set { this["PATIENTFAMILYHISTORY"] = value; }
        }

    /// <summary>
    /// Sistem Sorgulaması
    /// </summary>
        public object SystemQuery
        {
            get { return (object)this["SYSTEMQUERY"]; }
            set { this["SYSTEMQUERY"] = value; }
        }

    /// <summary>
    /// Özgeçmiş/Soygeçmiş
    /// </summary>
        public object PatientHistory
        {
            get { return (object)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Klinik İşlemleri-Klinik Doktor İşlemleri
    /// </summary>
        public ehrInPatientTreatmentClinicApplication ehrInPatientTreatClinicApp
        {
            get { return (ehrInPatientTreatmentClinicApplication)((ITTObject)this).GetParent("EHRINPATIENTTREATCLINICAPP"); }
            set { this["EHRINPATIENTTREATCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Acil Müdahale-Klinik Doktor İşlemleri
    /// </summary>
        public ehrEmergencyIntervention ehrEmergencyIntervention
        {
            get { return (ehrEmergencyIntervention)((ITTObject)this).GetParent("EHREMERGENCYINTERVENTION"); }
            set { this["EHREMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateehrSubactionMaterialsCollectionViews()
        {
            base.CreateehrSubactionMaterialsCollectionViews();
            _ehrDrugOrders = new ehrDrugOrder.ChildehrDrugOrderCollection(_ehrSubactionMaterials, "ehrDrugOrders");
        }

        private ehrDrugOrder.ChildehrDrugOrderCollection _ehrDrugOrders = null;
    /// <summary>
    /// Malzemeler
    /// </summary>
        public ehrDrugOrder.ChildehrDrugOrderCollection ehrDrugOrders
        {
            get
            {
                if (_ehrSubactionMaterials == null)
                    CreateehrSubactionMaterialsCollection();
                return _ehrDrugOrders;
            }            
        }

        protected ehrInPatientPhysicianApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrInPatientPhysicianApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrInPatientPhysicianApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrInPatientPhysicianApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrInPatientPhysicianApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRINPATIENTPHYSICIANAPPLICATION", dataRow) { }
        protected ehrInPatientPhysicianApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRINPATIENTPHYSICIANAPPLICATION", dataRow, isImported) { }
        public ehrInPatientPhysicianApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrInPatientPhysicianApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrInPatientPhysicianApplication() : base() { }

    }
}