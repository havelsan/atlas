
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyGridRestrictedTestDefinition")] 

    public  partial class RadiologyGridRestrictedTestDefinition : TTDefinitionSet
    {
        public class RadiologyGridRestrictedTestDefinitionList : TTObjectCollection<RadiologyGridRestrictedTestDefinition> { }
                    
        public class ChildRadiologyGridRestrictedTestDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyGridRestrictedTestDefinition>
        {
            public ChildRadiologyGridRestrictedTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyGridRestrictedTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public RadiologyTestDefinition Test
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("TEST"); }
            set { this["TEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTestDefinition RadiologyTestDefinition
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("RADIOLOGYTESTDEFINITION"); }
            set { this["RADIOLOGYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyGridRestrictedTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyGridRestrictedTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyGridRestrictedTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyGridRestrictedTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyGridRestrictedTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYGRIDRESTRICTEDTESTDEFINITION", dataRow) { }
        protected RadiologyGridRestrictedTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYGRIDRESTRICTEDTESTDEFINITION", dataRow, isImported) { }
        public RadiologyGridRestrictedTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyGridRestrictedTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyGridRestrictedTestDefinition() : base() { }

    }
}