
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrBaseInpatientAdmission")] 

    /// <summary>
    /// Hasta Yatış
    /// </summary>
    public  partial class ehrBaseInpatientAdmission : ehrEpisodeAction
    {
        public class ehrBaseInpatientAdmissionList : TTObjectCollection<ehrBaseInpatientAdmission> { }
                    
        public class ChildehrBaseInpatientAdmissionCollection : TTObject.TTChildObjectCollection<ehrBaseInpatientAdmission>
        {
            public ChildehrBaseInpatientAdmissionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrBaseInpatientAdmissionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Yatış Sebebi
    /// </summary>
        public string ReasonForInpatientAdmission
        {
            get { return (string)this["REASONFORINPATIENTADMISSION"]; }
            set { this["REASONFORINPATIENTADMISSION"] = value; }
        }

        public object InPatientFolder
        {
            get { return (object)this["INPATIENTFOLDER"]; }
            set { this["INPATIENTFOLDER"] = value; }
        }

        virtual protected void CreateehrInPatientTreatmentClinicApplicationsCollection()
        {
            _ehrInPatientTreatmentClinicApplications = new ehrInPatientTreatmentClinicApplication.ChildehrInPatientTreatmentClinicApplicationCollection(this, new Guid("0dcca6b1-5e40-4652-b2b6-5cfed6522aab"));
            ((ITTChildObjectCollection)_ehrInPatientTreatmentClinicApplications).GetChildren();
        }

        protected ehrInPatientTreatmentClinicApplication.ChildehrInPatientTreatmentClinicApplicationCollection _ehrInPatientTreatmentClinicApplications = null;
    /// <summary>
    /// Child collection for Klinik İşlemlerinin Başlatıldığı İşlem-Klinik İşlemleri
    /// </summary>
        public ehrInPatientTreatmentClinicApplication.ChildehrInPatientTreatmentClinicApplicationCollection ehrInPatientTreatmentClinicApplications
        {
            get
            {
                if (_ehrInPatientTreatmentClinicApplications == null)
                    CreateehrInPatientTreatmentClinicApplicationsCollection();
                return _ehrInPatientTreatmentClinicApplications;
            }
        }

        protected ehrBaseInpatientAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrBaseInpatientAdmission(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrBaseInpatientAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrBaseInpatientAdmission(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrBaseInpatientAdmission(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRBASEINPATIENTADMISSION", dataRow) { }
        protected ehrBaseInpatientAdmission(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRBASEINPATIENTADMISSION", dataRow, isImported) { }
        public ehrBaseInpatientAdmission(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrBaseInpatientAdmission(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrBaseInpatientAdmission() : base() { }

    }
}