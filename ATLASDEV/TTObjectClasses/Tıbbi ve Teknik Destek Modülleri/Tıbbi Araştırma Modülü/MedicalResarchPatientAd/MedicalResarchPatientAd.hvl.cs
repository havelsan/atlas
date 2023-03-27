
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalResarchPatientAd")] 

    /// <summary>
    /// Tıbbi Araştırma Hasta Kayıt
    /// </summary>
    public  partial class MedicalResarchPatientAd : PatientAdmission
    {
        public class MedicalResarchPatientAdList : TTObjectCollection<MedicalResarchPatientAd> { }
                    
        public class ChildMedicalResarchPatientAdCollection : TTObject.TTChildObjectCollection<MedicalResarchPatientAd>
        {
            public ChildMedicalResarchPatientAdCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalResarchPatientAdCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

        public MedicalResarch MedicalResarch
        {
            get { return (MedicalResarch)((ITTObject)this).GetParent("MEDICALRESARCH"); }
            set { this["MEDICALRESARCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalResarchPatientAd(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalResarchPatientAd(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalResarchPatientAd(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalResarchPatientAd(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalResarchPatientAd(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALRESARCHPATIENTAD", dataRow) { }
        protected MedicalResarchPatientAd(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALRESARCHPATIENTAD", dataRow, isImported) { }
        public MedicalResarchPatientAd(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalResarchPatientAd(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalResarchPatientAd() : base() { }

    }
}