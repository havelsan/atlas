
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RedecisionOldReportsMatterSliceAnectodeGrid")] 

    /// <summary>
    /// Madde Dilim Fıkra
    /// </summary>
    public  partial class RedecisionOldReportsMatterSliceAnectodeGrid : MatterSliceAnectodeGrid
    {
        public class RedecisionOldReportsMatterSliceAnectodeGridList : TTObjectCollection<RedecisionOldReportsMatterSliceAnectodeGrid> { }
                    
        public class ChildRedecisionOldReportsMatterSliceAnectodeGridCollection : TTObject.TTChildObjectCollection<RedecisionOldReportsMatterSliceAnectodeGrid>
        {
            public ChildRedecisionOldReportsMatterSliceAnectodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRedecisionOldReportsMatterSliceAnectodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected RedecisionOldReportsMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RedecisionOldReportsMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RedecisionOldReportsMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RedecisionOldReportsMatterSliceAnectodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RedecisionOldReportsMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REDECISIONOLDREPORTSMATTERSLICEANECTODEGRID", dataRow) { }
        protected RedecisionOldReportsMatterSliceAnectodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REDECISIONOLDREPORTSMATTERSLICEANECTODEGRID", dataRow, isImported) { }
        public RedecisionOldReportsMatterSliceAnectodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RedecisionOldReportsMatterSliceAnectodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RedecisionOldReportsMatterSliceAnectodeGrid() : base() { }

    }
}