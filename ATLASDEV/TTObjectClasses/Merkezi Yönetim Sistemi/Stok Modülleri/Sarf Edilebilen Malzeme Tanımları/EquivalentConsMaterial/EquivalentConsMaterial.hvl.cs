
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EquivalentConsMaterial")] 

    public  partial class EquivalentConsMaterial : TTObject
    {
        public class EquivalentConsMaterialList : TTObjectCollection<EquivalentConsMaterial> { }
                    
        public class ChildEquivalentConsMaterialCollection : TTObject.TTChildObjectCollection<EquivalentConsMaterial>
        {
            public ChildEquivalentConsMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEquivalentConsMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ConsumableMaterialDefinition ConsumableMaterialDefinition
        {
            get { return (ConsumableMaterialDefinition)((ITTObject)this).GetParent("CONSUMABLEMATERIALDEFINITION"); }
            set { this["CONSUMABLEMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ConsumableMaterialDefinition EquivalentMaterial
        {
            get { return (ConsumableMaterialDefinition)((ITTObject)this).GetParent("EQUIVALENTMATERIAL"); }
            set { this["EQUIVALENTMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EquivalentConsMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EquivalentConsMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EquivalentConsMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EquivalentConsMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EquivalentConsMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EQUIVALENTCONSMATERIAL", dataRow) { }
        protected EquivalentConsMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EQUIVALENTCONSMATERIAL", dataRow, isImported) { }
        public EquivalentConsMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EquivalentConsMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EquivalentConsMaterial() : base() { }

    }
}