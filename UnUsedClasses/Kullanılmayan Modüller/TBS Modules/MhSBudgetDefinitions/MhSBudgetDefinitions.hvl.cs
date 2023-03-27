
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSBudgetDefinitions")] 

    /// <summary>
    /// Bütçe Tanımlama
    /// </summary>
    public  partial class MhSBudgetDefinitions : TTObject
    {
        public class MhSBudgetDefinitionsList : TTObjectCollection<MhSBudgetDefinitions> { }
                    
        public class ChildMhSBudgetDefinitionsCollection : TTObject.TTChildObjectCollection<MhSBudgetDefinitions>
        {
            public ChildMhSBudgetDefinitionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSBudgetDefinitionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MhSBudgetDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSBudgetDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSBudgetDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSBudgetDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSBudgetDefinitions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSBUDGETDEFINITIONS", dataRow) { }
        protected MhSBudgetDefinitions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSBUDGETDEFINITIONS", dataRow, isImported) { }
        public MhSBudgetDefinitions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSBudgetDefinitions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSBudgetDefinitions() : base() { }

    }
}