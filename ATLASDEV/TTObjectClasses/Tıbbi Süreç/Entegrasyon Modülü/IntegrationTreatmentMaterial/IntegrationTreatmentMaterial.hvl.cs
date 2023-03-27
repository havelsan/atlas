
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntegrationTreatmentMaterial")] 

    /// <summary>
    /// Entegrasyon Malzemeleri
    /// </summary>
    public  partial class IntegrationTreatmentMaterial : BaseTreatmentMaterial
    {
        public class IntegrationTreatmentMaterialList : TTObjectCollection<IntegrationTreatmentMaterial> { }
                    
        public class ChildIntegrationTreatmentMaterialCollection : TTObject.TTChildObjectCollection<IntegrationTreatmentMaterial>
        {
            public ChildIntegrationTreatmentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntegrationTreatmentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("992adf01-83e6-4cfd-8b2d-b4e5ec7c6ce9"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("5b5b0e4f-bc4f-46dc-b5c8-6b64c3add14c"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ca1c1c02-0674-47ad-ae79-e1bb1503065d"); } }
        }

        public EpisodeActionWithDiagnosis IntegrationEpisodeAction
        {
            get 
            {   
                if (EpisodeAction is EpisodeActionWithDiagnosis)
                    return (EpisodeActionWithDiagnosis)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected IntegrationTreatmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntegrationTreatmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntegrationTreatmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntegrationTreatmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntegrationTreatmentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTEGRATIONTREATMENTMATERIAL", dataRow) { }
        protected IntegrationTreatmentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTEGRATIONTREATMENTMATERIAL", dataRow, isImported) { }
        public IntegrationTreatmentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntegrationTreatmentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntegrationTreatmentMaterial() : base() { }

    }
}