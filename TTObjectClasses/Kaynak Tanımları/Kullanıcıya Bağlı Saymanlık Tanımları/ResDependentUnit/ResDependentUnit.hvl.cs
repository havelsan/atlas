
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResDependentUnit")] 

    public  partial class ResDependentUnit : ResSection
    {
        public class ResDependentUnitList : TTObjectCollection<ResDependentUnit> { }
                    
        public class ChildResDependentUnitCollection : TTObject.TTChildObjectCollection<ResDependentUnit>
        {
            public ChildResDependentUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResDependentUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResAccountancy Accountancy
        {
            get { return (ResAccountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResDependentUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResDependentUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResDependentUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResDependentUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResDependentUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESDEPENDENTUNIT", dataRow) { }
        protected ResDependentUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESDEPENDENTUNIT", dataRow, isImported) { }
        public ResDependentUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResDependentUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResDependentUnit() : base() { }

    }
}