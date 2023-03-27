
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorkingUnit")] 

    /// <summary>
    /// Çalışılan Bölüm
    /// </summary>
    public  partial class WorkingUnit : TTDefinitionSet
    {
        public class WorkingUnitList : TTObjectCollection<WorkingUnit> { }
                    
        public class ChildWorkingUnitCollection : TTObject.TTChildObjectCollection<WorkingUnit>
        {
            public ChildWorkingUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorkingUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bölüm Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Çalışılan Bölüm Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected WorkingUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorkingUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorkingUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorkingUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorkingUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKINGUNIT", dataRow) { }
        protected WorkingUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKINGUNIT", dataRow, isImported) { }
        public WorkingUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorkingUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorkingUnit() : base() { }

    }
}