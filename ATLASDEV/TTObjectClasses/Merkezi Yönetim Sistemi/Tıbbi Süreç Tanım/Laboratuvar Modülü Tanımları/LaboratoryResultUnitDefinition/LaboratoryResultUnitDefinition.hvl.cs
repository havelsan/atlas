
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryResultUnitDefinition")] 

    /// <summary>
    /// Laboratuvar Sonuç Birim Tanımı
    /// </summary>
    public  partial class LaboratoryResultUnitDefinition : TTDefinitionSet
    {
        public class LaboratoryResultUnitDefinitionList : TTObjectCollection<LaboratoryResultUnitDefinition> { }
                    
        public class ChildLaboratoryResultUnitDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryResultUnitDefinition>
        {
            public ChildLaboratoryResultUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryResultUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sonuç Birim Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected LaboratoryResultUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryResultUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryResultUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryResultUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryResultUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYRESULTUNITDEFINITION", dataRow) { }
        protected LaboratoryResultUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYRESULTUNITDEFINITION", dataRow, isImported) { }
        public LaboratoryResultUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryResultUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryResultUnitDefinition() : base() { }

    }
}