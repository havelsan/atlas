
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrBaseTreatmentMaterial")] 

    /// <summary>
    /// Malzeme Sarf
    /// </summary>
    public  partial class ehrBaseTreatmentMaterial : ehrSubactionMaterial
    {
        public class ehrBaseTreatmentMaterialList : TTObjectCollection<ehrBaseTreatmentMaterial> { }
                    
        public class ChildehrBaseTreatmentMaterialCollection : TTObject.TTChildObjectCollection<ehrBaseTreatmentMaterial>
        {
            public ChildehrBaseTreatmentMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrBaseTreatmentMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

        protected ehrBaseTreatmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrBaseTreatmentMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrBaseTreatmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrBaseTreatmentMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrBaseTreatmentMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRBASETREATMENTMATERIAL", dataRow) { }
        protected ehrBaseTreatmentMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRBASETREATMENTMATERIAL", dataRow, isImported) { }
        public ehrBaseTreatmentMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrBaseTreatmentMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrBaseTreatmentMaterial() : base() { }

    }
}