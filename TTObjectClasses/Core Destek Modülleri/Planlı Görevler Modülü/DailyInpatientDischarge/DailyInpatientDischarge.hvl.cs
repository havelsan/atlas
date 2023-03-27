
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyInpatientDischarge")] 

    /// <summary>
    /// Günübirlik Taburcu İşlemleri
    /// </summary>
    public  partial class DailyInpatientDischarge : BaseScheduledTask
    {
        public class DailyInpatientDischargeList : TTObjectCollection<DailyInpatientDischarge> { }
                    
        public class ChildDailyInpatientDischargeCollection : TTObject.TTChildObjectCollection<DailyInpatientDischarge>
        {
            public ChildDailyInpatientDischargeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyInpatientDischargeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected DailyInpatientDischarge(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyInpatientDischarge(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyInpatientDischarge(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyInpatientDischarge(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyInpatientDischarge(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYINPATIENTDISCHARGE", dataRow) { }
        protected DailyInpatientDischarge(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYINPATIENTDISCHARGE", dataRow, isImported) { }
        public DailyInpatientDischarge(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyInpatientDischarge(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyInpatientDischarge() : base() { }

    }
}