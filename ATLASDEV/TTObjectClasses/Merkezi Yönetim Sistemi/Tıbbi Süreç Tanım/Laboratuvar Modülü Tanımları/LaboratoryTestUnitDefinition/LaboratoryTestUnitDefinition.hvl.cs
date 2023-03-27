
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryTestUnitDefinition")] 

    public  partial class LaboratoryTestUnitDefinition : TTDefinitionSet
    {
        public class LaboratoryTestUnitDefinitionList : TTObjectCollection<LaboratoryTestUnitDefinition> { }
                    
        public class ChildLaboratoryTestUnitDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryTestUnitDefinition>
        {
            public ChildLaboratoryTestUnitDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryTestUnitDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Test Birimi
    /// </summary>
        public string TestUnit
        {
            get { return (string)this["TESTUNIT"]; }
            set { this["TESTUNIT"] = value; }
        }

        public string TestUnit_Shadow
        {
            get { return (string)this["TESTUNIT_SHADOW"]; }
        }

        protected LaboratoryTestUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryTestUnitDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryTestUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryTestUnitDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryTestUnitDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYTESTUNITDEFINITION", dataRow) { }
        protected LaboratoryTestUnitDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYTESTUNITDEFINITION", dataRow, isImported) { }
        public LaboratoryTestUnitDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryTestUnitDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryTestUnitDefinition() : base() { }

    }
}