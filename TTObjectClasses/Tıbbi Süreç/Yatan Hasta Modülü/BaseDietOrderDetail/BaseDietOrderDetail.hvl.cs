
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDietOrderDetail")] 

    public  partial class BaseDietOrderDetail : PeriodicOrderDetail
    {
        public class BaseDietOrderDetailList : TTObjectCollection<BaseDietOrderDetail> { }
                    
        public class ChildBaseDietOrderDetailCollection : TTObject.TTChildObjectCollection<BaseDietOrderDetail>
        {
            public ChildBaseDietOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDietOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public MealTypes MealType
        {
            get { return (MealTypes)((ITTObject)this).GetParent("MEALTYPE"); }
            set { this["MEALTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseDietOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDietOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDietOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDietOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDietOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDIETORDERDETAIL", dataRow) { }
        protected BaseDietOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDIETORDERDETAIL", dataRow, isImported) { }
        public BaseDietOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDietOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDietOrderDetail() : base() { }

    }
}