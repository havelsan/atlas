
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PharmacySourceMilitaryUnit")] 

    public  partial class PharmacySourceMilitaryUnit : TTObject
    {
        public class PharmacySourceMilitaryUnitList : TTObjectCollection<PharmacySourceMilitaryUnit> { }
                    
        public class ChildPharmacySourceMilitaryUnitCollection : TTObject.TTChildObjectCollection<PharmacySourceMilitaryUnit>
        {
            public ChildPharmacySourceMilitaryUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPharmacySourceMilitaryUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PharmacySourceDefinition PharmacySourceDefinition
        {
            get { return (PharmacySourceDefinition)((ITTObject)this).GetParent("PHARMACYSOURCEDEFINITION"); }
            set { this["PHARMACYSOURCEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PharmacySourceMilitaryUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PharmacySourceMilitaryUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PharmacySourceMilitaryUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PharmacySourceMilitaryUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PharmacySourceMilitaryUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHARMACYSOURCEMILITARYUNIT", dataRow) { }
        protected PharmacySourceMilitaryUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHARMACYSOURCEMILITARYUNIT", dataRow, isImported) { }
        public PharmacySourceMilitaryUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PharmacySourceMilitaryUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PharmacySourceMilitaryUnit() : base() { }

    }
}