
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryRepeatReasonDefinition")] 

    /// <summary>
    /// Laboratuvar Tekrar Neden Tanımı
    /// </summary>
    public  partial class LaboratoryRepeatReasonDefinition : TTDefinitionSet
    {
        public class LaboratoryRepeatReasonDefinitionList : TTObjectCollection<LaboratoryRepeatReasonDefinition> { }
                    
        public class ChildLaboratoryRepeatReasonDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryRepeatReasonDefinition>
        {
            public ChildLaboratoryRepeatReasonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryRepeatReasonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected LaboratoryRepeatReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryRepeatReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryRepeatReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryRepeatReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryRepeatReasonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYREPEATREASONDEFINITION", dataRow) { }
        protected LaboratoryRepeatReasonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYREPEATREASONDEFINITION", dataRow, isImported) { }
        public LaboratoryRepeatReasonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryRepeatReasonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryRepeatReasonDefinition() : base() { }

    }
}