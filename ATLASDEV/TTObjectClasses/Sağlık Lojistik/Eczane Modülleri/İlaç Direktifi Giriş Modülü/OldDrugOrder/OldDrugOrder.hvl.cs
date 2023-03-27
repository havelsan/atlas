
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OldDrugOrder")] 

    public  partial class OldDrugOrder : TTObject
    {
        public class OldDrugOrderList : TTObjectCollection<OldDrugOrder> { }
                    
        public class ChildOldDrugOrderCollection : TTObject.TTChildObjectCollection<OldDrugOrder>
        {
            public ChildOldDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOldDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DrugOrder DrugOrder
        {
            get { return (DrugOrder)((ITTObject)this).GetParent("DRUGORDER"); }
            set { this["DRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderIntroduction DrugOrderIntroduction
        {
            get { return (DrugOrderIntroduction)((ITTObject)this).GetParent("DRUGORDERINTRODUCTION"); }
            set { this["DRUGORDERINTRODUCTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OldDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OldDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OldDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OldDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OldDrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLDDRUGORDER", dataRow) { }
        protected OldDrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLDDRUGORDER", dataRow, isImported) { }
        public OldDrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OldDrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OldDrugOrder() : base() { }

    }
}