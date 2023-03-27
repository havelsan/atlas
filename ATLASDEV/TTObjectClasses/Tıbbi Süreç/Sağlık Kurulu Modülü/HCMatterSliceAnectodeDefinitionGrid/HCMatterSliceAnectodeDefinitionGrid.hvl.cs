
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCMatterSliceAnectodeDefinitionGrid")] 

    public  partial class HCMatterSliceAnectodeDefinitionGrid : TTObject
    {
        public class HCMatterSliceAnectodeDefinitionGridList : TTObjectCollection<HCMatterSliceAnectodeDefinitionGrid> { }
                    
        public class ChildHCMatterSliceAnectodeDefinitionGridCollection : TTObject.TTChildObjectCollection<HCMatterSliceAnectodeDefinitionGrid>
        {
            public ChildHCMatterSliceAnectodeDefinitionGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCMatterSliceAnectodeDefinitionGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public HealthCommitteeWithThreeSpecialist HCWMatterSliceAnectode
        {
            get { return (HealthCommitteeWithThreeSpecialist)((ITTObject)this).GetParent("HCWMATTERSLICEANECTODE"); }
            set { this["HCWMATTERSLICEANECTODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommittee HCMatterSliceAnectode
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HCMATTERSLICEANECTODE"); }
            set { this["HCMATTERSLICEANECTODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommitteeExamination HCEMatterSliceAnectode
        {
            get { return (HealthCommitteeExamination)((ITTObject)this).GetParent("HCEMATTERSLICEANECTODE"); }
            set { this["HCEMATTERSLICEANECTODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Madde/Dilim/Fıkra
    /// </summary>
        public HCMatterSliceAnectodeDefinition MatterSliceAnectodeDef
        {
            get { return (HCMatterSliceAnectodeDefinition)((ITTObject)this).GetParent("MATTERSLICEANECTODEDEF"); }
            set { this["MATTERSLICEANECTODEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommitteeOfProfessors HCPMatterSliceAnectode
        {
            get { return (HealthCommitteeOfProfessors)((ITTObject)this).GetParent("HCPMATTERSLICEANECTODE"); }
            set { this["HCPMATTERSLICEANECTODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCMatterSliceAnectodeDefinitionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCMatterSliceAnectodeDefinitionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCMatterSliceAnectodeDefinitionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCMatterSliceAnectodeDefinitionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCMatterSliceAnectodeDefinitionGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCMATTERSLICEANECTODEDEFINITIONGRID", dataRow) { }
        protected HCMatterSliceAnectodeDefinitionGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCMATTERSLICEANECTODEDEFINITIONGRID", dataRow, isImported) { }
        public HCMatterSliceAnectodeDefinitionGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCMatterSliceAnectodeDefinitionGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCMatterSliceAnectodeDefinitionGrid() : base() { }

    }
}