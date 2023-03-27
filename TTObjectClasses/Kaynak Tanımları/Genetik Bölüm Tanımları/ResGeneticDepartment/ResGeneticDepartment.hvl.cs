
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResGeneticDepartment")] 

    /// <summary>
    /// Genetik Bölüm
    /// </summary>
    public  partial class ResGeneticDepartment : ResSection
    {
        public class ResGeneticDepartmentList : TTObjectCollection<ResGeneticDepartment> { }
                    
        public class ChildResGeneticDepartmentCollection : TTObject.TTChildObjectCollection<ResGeneticDepartment>
        {
            public ChildResGeneticDepartmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResGeneticDepartmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ResGeneticDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResGeneticDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResGeneticDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResGeneticDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResGeneticDepartment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESGENETICDEPARTMENT", dataRow) { }
        protected ResGeneticDepartment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESGENETICDEPARTMENT", dataRow, isImported) { }
        public ResGeneticDepartment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResGeneticDepartment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResGeneticDepartment() : base() { }

    }
}