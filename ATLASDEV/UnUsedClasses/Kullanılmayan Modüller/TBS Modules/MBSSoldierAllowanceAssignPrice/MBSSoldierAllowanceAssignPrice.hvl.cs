
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSSoldierAllowanceAssignPrice")] 

    public  partial class MBSSoldierAllowanceAssignPrice : MBSAssignPrice
    {
        public class MBSSoldierAllowanceAssignPriceList : TTObjectCollection<MBSSoldierAllowanceAssignPrice> { }
                    
        public class ChildMBSSoldierAllowanceAssignPriceCollection : TTObject.TTChildObjectCollection<MBSSoldierAllowanceAssignPrice>
        {
            public ChildMBSSoldierAllowanceAssignPriceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSSoldierAllowanceAssignPriceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MBSSoldierAllowanceAssignPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSSoldierAllowanceAssignPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSSoldierAllowanceAssignPrice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSSoldierAllowanceAssignPrice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSSoldierAllowanceAssignPrice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSSOLDIERALLOWANCEASSIGNPRICE", dataRow) { }
        protected MBSSoldierAllowanceAssignPrice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSSOLDIERALLOWANCEASSIGNPRICE", dataRow, isImported) { }
        public MBSSoldierAllowanceAssignPrice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSSoldierAllowanceAssignPrice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSSoldierAllowanceAssignPrice() : base() { }

    }
}