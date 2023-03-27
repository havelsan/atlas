
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PlannedActionRequest")] 

    /// <summary>
    /// Planlı İşlem İstek
    /// </summary>
    public  partial class PlannedActionRequest : EpisodeAction
    {
        public class PlannedActionRequestList : TTObjectCollection<PlannedActionRequest> { }
                    
        public class ChildPlannedActionRequestCollection : TTObject.TTChildObjectCollection<PlannedActionRequest>
        {
            public ChildPlannedActionRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPlannedActionRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PlannedActionRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PlannedActionRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PlannedActionRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PlannedActionRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PlannedActionRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PLANNEDACTIONREQUEST", dataRow) { }
        protected PlannedActionRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PLANNEDACTIONREQUEST", dataRow, isImported) { }
        public PlannedActionRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PlannedActionRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PlannedActionRequest() : base() { }

    }
}