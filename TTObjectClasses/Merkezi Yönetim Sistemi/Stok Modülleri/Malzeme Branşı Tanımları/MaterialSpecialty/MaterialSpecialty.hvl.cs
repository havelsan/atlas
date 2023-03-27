
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialSpecialty")] 

    public  partial class MaterialSpecialty : TTDefinitionSet
    {
        public class MaterialSpecialtyList : TTObjectCollection<MaterialSpecialty> { }
                    
        public class ChildMaterialSpecialtyCollection : TTObject.TTChildObjectCollection<MaterialSpecialty>
        {
            public ChildMaterialSpecialtyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialSpecialtyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaterialSpecialtyDef MaterialSpecialtyDefinition
        {
            get { return (MaterialSpecialtyDef)((ITTObject)this).GetParent("MATERIALSPECIALTYDEFINITION"); }
            set { this["MATERIALSPECIALTYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialSpecialty(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialSpecialty(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialSpecialty(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialSpecialty(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialSpecialty(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALSPECIALTY", dataRow) { }
        protected MaterialSpecialty(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALSPECIALTY", dataRow, isImported) { }
        public MaterialSpecialty(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialSpecialty(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialSpecialty() : base() { }

    }
}