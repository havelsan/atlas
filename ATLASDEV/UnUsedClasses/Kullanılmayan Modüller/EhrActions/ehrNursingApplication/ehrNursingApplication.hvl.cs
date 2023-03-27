
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrNursingApplication")] 

    /// <summary>
    /// Hemşirelik Hizmetleri
    /// </summary>
    public  partial class ehrNursingApplication : ehrEpisodeAction, IOAInPatientApplication
    {
        public class ehrNursingApplicationList : TTObjectCollection<ehrNursingApplication> { }
                    
        public class ChildehrNursingApplicationCollection : TTObject.TTChildObjectCollection<ehrNursingApplication>
        {
            public ChildehrNursingApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrNursingApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Klinik İşlemleri-Hemşirelik İşlemleri
    /// </summary>
        public ehrInPatientTreatmentClinicApplication ehrInPatientTreatClinicApp
        {
            get { return (ehrInPatientTreatmentClinicApplication)((ITTObject)this).GetParent("EHRINPATIENTTREATCLINICAPP"); }
            set { this["EHRINPATIENTTREATCLINICAPP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Acil Müdahale-Hemşirelik İşlemleri
    /// </summary>
        public ehrEmergencyIntervention ehrEmergencyIntervention
        {
            get { return (ehrEmergencyIntervention)((ITTObject)this).GetParent("EHREMERGENCYINTERVENTION"); }
            set { this["EHREMERGENCYINTERVENTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateehrSubactionMaterialsCollectionViews()
        {
            base.CreateehrSubactionMaterialsCollectionViews();
            _ehrDrugOrderDetails = new ehrDrugOrderDetail.ChildehrDrugOrderDetailCollection(_ehrSubactionMaterials, "ehrDrugOrderDetails");
        }

        private ehrDrugOrderDetail.ChildehrDrugOrderDetailCollection _ehrDrugOrderDetails = null;
    /// <summary>
    /// Malzemeler
    /// </summary>
        public ehrDrugOrderDetail.ChildehrDrugOrderDetailCollection ehrDrugOrderDetails
        {
            get
            {
                if (_ehrSubactionMaterials == null)
                    CreateehrSubactionMaterialsCollection();
                return _ehrDrugOrderDetails;
            }            
        }

        protected ehrNursingApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrNursingApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrNursingApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrNursingApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrNursingApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRNURSINGAPPLICATION", dataRow) { }
        protected ehrNursingApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRNURSINGAPPLICATION", dataRow, isImported) { }
        public ehrNursingApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrNursingApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrNursingApplication() : base() { }

    }
}