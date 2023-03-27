
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryBacteriaDefinition")] 

    public  partial class LaboratoryBacteriaDefinition : TTDefinitionSet
    {
        public class LaboratoryBacteriaDefinitionList : TTObjectCollection<LaboratoryBacteriaDefinition> { }
                    
        public class ChildLaboratoryBacteriaDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryBacteriaDefinition>
        {
            public ChildLaboratoryBacteriaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryBacteriaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Bakteri Grubu İlişkisi
    /// </summary>
        public LaboratoryBacteriaGroupDefinition BacteriaGroup
        {
            get { return (LaboratoryBacteriaGroupDefinition)((ITTObject)this).GetParent("BACTERIAGROUP"); }
            set { this["BACTERIAGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryBacteriaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryBacteriaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryBacteriaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryBacteriaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryBacteriaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYBACTERIADEFINITION", dataRow) { }
        protected LaboratoryBacteriaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYBACTERIADEFINITION", dataRow, isImported) { }
        public LaboratoryBacteriaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryBacteriaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryBacteriaDefinition() : base() { }

    }
}