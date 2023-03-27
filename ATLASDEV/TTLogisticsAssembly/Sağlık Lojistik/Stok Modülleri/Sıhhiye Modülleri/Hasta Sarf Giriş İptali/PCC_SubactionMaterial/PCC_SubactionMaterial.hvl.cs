
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PCC_SubactionMaterial")] 

    public  partial class PCC_SubactionMaterial : TTObject
    {
        public class PCC_SubactionMaterialList : TTObjectCollection<PCC_SubactionMaterial> { }
                    
        public class ChildPCC_SubactionMaterialCollection : TTObject.TTChildObjectCollection<PCC_SubactionMaterial>
        {
            public ChildPCC_SubactionMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPCC_SubactionMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string EpisodeProtocolNo_Desc
        {
            get { return (string)this["EPISODEPROTOCOLNO_DESC"]; }
            set { this["EPISODEPROTOCOLNO_DESC"] = value; }
        }

    /// <summary>
    /// İptal
    /// </summary>
        public bool? DetailCancel
        {
            get { return (bool?)this["DETAILCANCEL"]; }
            set { this["DETAILCANCEL"] = value; }
        }

        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PatientConsumptionCancel PatientConsumptionCancel
        {
            get { return (PatientConsumptionCancel)((ITTObject)this).GetParent("PATIENTCONSUMPTIONCANCEL"); }
            set { this["PATIENTCONSUMPTIONCANCEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PCC_SubactionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PCC_SubactionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PCC_SubactionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PCC_SubactionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PCC_SubactionMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PCC_SUBACTIONMATERIAL", dataRow) { }
        protected PCC_SubactionMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PCC_SUBACTIONMATERIAL", dataRow, isImported) { }
        public PCC_SubactionMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PCC_SubactionMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PCC_SubactionMaterial() : base() { }

    }
}