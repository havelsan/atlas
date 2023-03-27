
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EStatusNotRepCommitteeObj")] 

    /// <summary>
    /// E-Durum Bildirir Sağlık Kurulu Rapor Entegrasyonu için kullanılacak nesne,
    /// </summary>
    public  partial class EStatusNotRepCommitteeObj : TTObject
    {
        public class EStatusNotRepCommitteeObjList : TTObjectCollection<EStatusNotRepCommitteeObj> { }
                    
        public class ChildEStatusNotRepCommitteeObjCollection : TTObject.TTChildObjectCollection<EStatusNotRepCommitteeObj>
        {
            public ChildEStatusNotRepCommitteeObjCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEStatusNotRepCommitteeObjCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public EDurumBildirirKurulAppStatus? ApplicationCouncilSituation
        {
            get { return (EDurumBildirirKurulAppStatus?)(int?)this["APPLICATIONCOUNCILSITUATION"]; }
            set { this["APPLICATIONCOUNCILSITUATION"] = value; }
        }

        public EDurumBildirirKurulAppType? ApplicationType
        {
            get { return (EDurumBildirirKurulAppType?)(int?)this["APPLICATIONTYPE"]; }
            set { this["APPLICATIONTYPE"] = value; }
        }

    /// <summary>
    /// Başvuru Entegrasyon ID
    /// </summary>
        public string PatientApplicationID
        {
            get { return (string)this["PATIENTAPPLICATIONID"]; }
            set { this["PATIENTAPPLICATIONID"] = value; }
        }

        virtual protected void CreateHCExaminationComponentCollection()
        {
            _HCExaminationComponent = new HCExaminationComponent.ChildHCExaminationComponentCollection(this, new Guid("7b452121-7092-4f86-b9ac-268cd7e850e0"));
            ((ITTChildObjectCollection)_HCExaminationComponent).GetChildren();
        }

        protected HCExaminationComponent.ChildHCExaminationComponentCollection _HCExaminationComponent = null;
    /// <summary>
    /// Child collection for E-Durum Bildirir Kurul Raporu Entegrasyon Nesnesi
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
            _PatientAdmission = new PatientAdmission.ChildPatientAdmissionCollection(this, new Guid("789e5ff7-1a9c-4d7d-8162-c4795fd956cd"));
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

        protected EStatusNotRepCommitteeObj(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EStatusNotRepCommitteeObj(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EStatusNotRepCommitteeObj(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EStatusNotRepCommitteeObj(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EStatusNotRepCommitteeObj(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ESTATUSNOTREPCOMMITTEEOBJ", dataRow) { }
        protected EStatusNotRepCommitteeObj(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ESTATUSNOTREPCOMMITTEEOBJ", dataRow, isImported) { }
        public EStatusNotRepCommitteeObj(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EStatusNotRepCommitteeObj(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EStatusNotRepCommitteeObj() : base() { }

    }
}