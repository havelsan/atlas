
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NucMedSelectedTestGrid")] 

    public  partial class NucMedSelectedTestGrid : TTObject
    {
        public class NucMedSelectedTestGridList : TTObjectCollection<NucMedSelectedTestGrid> { }
                    
        public class ChildNucMedSelectedTestGridCollection : TTObject.TTChildObjectCollection<NucMedSelectedTestGrid>
        {
            public ChildNucMedSelectedTestGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNucMedSelectedTestGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected NucMedSelectedTestGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NucMedSelectedTestGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NucMedSelectedTestGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NucMedSelectedTestGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NucMedSelectedTestGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCMEDSELECTEDTESTGRID", dataRow) { }
        protected NucMedSelectedTestGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCMEDSELECTEDTESTGRID", dataRow, isImported) { }
        public NucMedSelectedTestGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NucMedSelectedTestGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NucMedSelectedTestGrid() : base() { }

    }
}