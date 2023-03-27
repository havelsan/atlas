
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManipulationDepartmentGrid")] 

    /// <summary>
    /// Manipülasyon Yapılacak Birimler
    /// </summary>
    public  partial class ManipulationDepartmentGrid : TTDefinitionSet
    {
        public class ManipulationDepartmentGridList : TTObjectCollection<ManipulationDepartmentGrid> { }
                    
        public class ChildManipulationDepartmentGridCollection : TTObject.TTChildObjectCollection<ManipulationDepartmentGrid>
        {
            public ChildManipulationDepartmentGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManipulationDepartmentGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Birim(ler)
    /// </summary>
        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SurgeryDefinition ManipulationDefinition
        {
            get { return (SurgeryDefinition)((ITTObject)this).GetParent("MANIPULATIONDEFINITION"); }
            set { this["MANIPULATIONDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManipulationDepartmentGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManipulationDepartmentGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManipulationDepartmentGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManipulationDepartmentGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManipulationDepartmentGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANIPULATIONDEPARTMENTGRID", dataRow) { }
        protected ManipulationDepartmentGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANIPULATIONDEPARTMENTGRID", dataRow, isImported) { }
        public ManipulationDepartmentGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManipulationDepartmentGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManipulationDepartmentGrid() : base() { }

    }
}