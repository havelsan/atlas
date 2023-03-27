
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResNuclearMedicineDepartment")] 

    /// <summary>
    /// Nükleer Tıp Bölüm
    /// </summary>
    public  partial class ResNuclearMedicineDepartment : ResObservationUnit
    {
        public class ResNuclearMedicineDepartmentList : TTObjectCollection<ResNuclearMedicineDepartment> { }
                    
        public class ChildResNuclearMedicineDepartmentCollection : TTObject.TTChildObjectCollection<ResNuclearMedicineDepartment>
        {
            public ChildResNuclearMedicineDepartmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResNuclearMedicineDepartmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ResNuclearMedicineDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResNuclearMedicineDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResNuclearMedicineDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResNuclearMedicineDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResNuclearMedicineDepartment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESNUCLEARMEDICINEDEPARTMENT", dataRow) { }
        protected ResNuclearMedicineDepartment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESNUCLEARMEDICINEDEPARTMENT", dataRow, isImported) { }
        public ResNuclearMedicineDepartment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResNuclearMedicineDepartment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResNuclearMedicineDepartment() : base() { }

    }
}