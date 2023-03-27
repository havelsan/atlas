
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryTestSubTypeDefinition")] 

    /// <summary>
    /// Laboratuvar Tetkik Alt Tür Tanımları
    /// </summary>
    public  partial class LaboratoryTestSubTypeDefinition : TTDefinitionSet
    {
        public class LaboratoryTestSubTypeDefinitionList : TTObjectCollection<LaboratoryTestSubTypeDefinition> { }
                    
        public class ChildLaboratoryTestSubTypeDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryTestSubTypeDefinition>
        {
            public ChildLaboratoryTestSubTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryTestSubTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tetkik Alt Tür Adı
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

        protected LaboratoryTestSubTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryTestSubTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryTestSubTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryTestSubTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryTestSubTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYTESTSUBTYPEDEFINITION", dataRow) { }
        protected LaboratoryTestSubTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYTESTSUBTYPEDEFINITION", dataRow, isImported) { }
        public LaboratoryTestSubTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryTestSubTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryTestSubTypeDefinition() : base() { }

    }
}