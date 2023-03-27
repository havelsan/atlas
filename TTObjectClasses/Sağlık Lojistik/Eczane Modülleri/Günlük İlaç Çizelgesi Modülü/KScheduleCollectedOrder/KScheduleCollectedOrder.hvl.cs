
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KScheduleCollectedOrder")] 

    /// <summary>
    /// K Cizelgesi ile İlaç order Relation
    /// </summary>
    public  partial class KScheduleCollectedOrder : TTObject
    {
        public class KScheduleCollectedOrderList : TTObjectCollection<KScheduleCollectedOrder> { }
                    
        public class ChildKScheduleCollectedOrderCollection : TTObject.TTChildObjectCollection<KScheduleCollectedOrder>
        {
            public ChildKScheduleCollectedOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKScheduleCollectedOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateDrugOrderDetailsCollection()
        {
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(this, new Guid("6b5d6ef9-49f9-4021-ae33-bf5c7d85b6a1"));
            ((ITTChildObjectCollection)_DrugOrderDetails).GetChildren();
        }

        protected DrugOrderDetail.ChildDrugOrderDetailCollection _DrugOrderDetails = null;
        public DrugOrderDetail.ChildDrugOrderDetailCollection DrugOrderDetails
        {
            get
            {
                if (_DrugOrderDetails == null)
                    CreateDrugOrderDetailsCollection();
                return _DrugOrderDetails;
            }
        }

        protected KScheduleCollectedOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KScheduleCollectedOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KScheduleCollectedOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KScheduleCollectedOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KScheduleCollectedOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KSCHEDULECOLLECTEDORDER", dataRow) { }
        protected KScheduleCollectedOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KSCHEDULECOLLECTEDORDER", dataRow, isImported) { }
        public KScheduleCollectedOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KScheduleCollectedOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KScheduleCollectedOrder() : base() { }

    }
}