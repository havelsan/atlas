
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResLaboratoryEquipment")] 

    /// <summary>
    /// Laboratuvar Cihazı
    /// </summary>
    public  partial class ResLaboratoryEquipment : ResEquipment
    {
        public class ResLaboratoryEquipmentList : TTObjectCollection<ResLaboratoryEquipment> { }
                    
        public class ChildResLaboratoryEquipmentCollection : TTObject.TTChildObjectCollection<ResLaboratoryEquipment>
        {
            public ChildResLaboratoryEquipmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResLaboratoryEquipmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ResLaboratoryEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResLaboratoryEquipment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResLaboratoryEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResLaboratoryEquipment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResLaboratoryEquipment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESLABORATORYEQUIPMENT", dataRow) { }
        protected ResLaboratoryEquipment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESLABORATORYEQUIPMENT", dataRow, isImported) { }
        public ResLaboratoryEquipment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResLaboratoryEquipment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResLaboratoryEquipment() : base() { }

    }
}