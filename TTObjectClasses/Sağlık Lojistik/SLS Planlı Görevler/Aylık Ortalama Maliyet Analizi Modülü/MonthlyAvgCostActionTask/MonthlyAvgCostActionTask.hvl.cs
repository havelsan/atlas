
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MonthlyAvgCostActionTask")] 

    /// <summary>
    /// Aylık Ortalama Maliyet Analizi
    /// </summary>
    public  partial class MonthlyAvgCostActionTask : BaseScheduledTask
    {
        public class MonthlyAvgCostActionTaskList : TTObjectCollection<MonthlyAvgCostActionTask> { }
                    
        public class ChildMonthlyAvgCostActionTaskCollection : TTObject.TTChildObjectCollection<MonthlyAvgCostActionTask>
        {
            public ChildMonthlyAvgCostActionTaskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMonthlyAvgCostActionTaskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ayın Kaçıncı Gününden İtibaren
    /// </summary>
        public int? DayOfMonthly
        {
            get { return (int?)this["DAYOFMONTHLY"]; }
            set { this["DAYOFMONTHLY"] = value; }
        }

        protected MonthlyAvgCostActionTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MonthlyAvgCostActionTask(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MonthlyAvgCostActionTask(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MonthlyAvgCostActionTask(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MonthlyAvgCostActionTask(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MONTHLYAVGCOSTACTIONTASK", dataRow) { }
        protected MonthlyAvgCostActionTask(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MONTHLYAVGCOSTACTIONTASK", dataRow, isImported) { }
        public MonthlyAvgCostActionTask(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MonthlyAvgCostActionTask(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MonthlyAvgCostActionTask() : base() { }

    }
}