
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NuclearMedicineGridPharmDefinition")] 

    public  partial class NuclearMedicineGridPharmDefinition : TerminologyManagerDef
    {
        public class NuclearMedicineGridPharmDefinitionList : TTObjectCollection<NuclearMedicineGridPharmDefinition> { }
                    
        public class ChildNuclearMedicineGridPharmDefinitionCollection : TTObject.TTChildObjectCollection<NuclearMedicineGridPharmDefinition>
        {
            public ChildNuclearMedicineGridPharmDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNuclearMedicineGridPharmDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Malzeme İlişkisi
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Nükleer Tıp Test Tanımı İlişkisi
    /// </summary>
        public NuclearMedicineTestDefinition NuclearMedicineTestDefinition
        {
            get { return (NuclearMedicineTestDefinition)((ITTObject)this).GetParent("NUCLEARMEDICINETESTDEFINITION"); }
            set { this["NUCLEARMEDICINETESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Radyofarmosötik Malzeme
    /// </summary>
        public RadioPharmaceuticalDefinition RadioPharmaCeuticalMaterial
        {
            get { return (RadioPharmaceuticalDefinition)((ITTObject)this).GetParent("RADIOPHARMACEUTICALMATERIAL"); }
            set { this["RADIOPHARMACEUTICALMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NuclearMedicineGridPharmDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NuclearMedicineGridPharmDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NuclearMedicineGridPharmDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NuclearMedicineGridPharmDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NuclearMedicineGridPharmDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCLEARMEDICINEGRIDPHARMDEFINITION", dataRow) { }
        protected NuclearMedicineGridPharmDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCLEARMEDICINEGRIDPHARMDEFINITION", dataRow, isImported) { }
        public NuclearMedicineGridPharmDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NuclearMedicineGridPharmDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NuclearMedicineGridPharmDefinition() : base() { }

    }
}