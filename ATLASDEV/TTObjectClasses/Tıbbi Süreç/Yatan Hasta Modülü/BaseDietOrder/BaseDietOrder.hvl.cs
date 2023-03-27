
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDietOrder")] 

    public  partial class BaseDietOrder : PeriodicOrder
    {
        public class BaseDietOrderList : TTObjectCollection<BaseDietOrder> { }
                    
        public class ChildBaseDietOrderCollection : TTObject.TTChildObjectCollection<BaseDietOrder>
        {
            public ChildBaseDietOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDietOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Vt de tutulmayacak(gösterme amaçlı)
    /// </summary>
        public DateTime? PeriodEndTime
        {
            get { return (DateTime?)this["PERIODENDTIME"]; }
            set { this["PERIODENDTIME"] = value; }
        }

        public MealTypes MealType
        {
            get { return (MealTypes)((ITTObject)this).GetParent("MEALTYPE"); }
            set { this["MEALTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseDietOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDietOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDietOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDietOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDietOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDIETORDER", dataRow) { }
        protected BaseDietOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDIETORDER", dataRow, isImported) { }
        public BaseDietOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDietOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDietOrder() : base() { }

    }
}