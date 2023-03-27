
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridBoundedTestDefinition")] 

    public  partial class LaboratoryGridBoundedTestDefinition : TTDefinitionSet
    {
        public class LaboratoryGridBoundedTestDefinitionList : TTObjectCollection<LaboratoryGridBoundedTestDefinition> { }
                    
        public class ChildLaboratoryGridBoundedTestDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryGridBoundedTestDefinition>
        {
            public ChildLaboratoryGridBoundedTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridBoundedTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Laboratuvar Test Tanım İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Test Tanım İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTest
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTEST"); }
            set { this["LABORATORYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridBoundedTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridBoundedTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridBoundedTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridBoundedTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridBoundedTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDBOUNDEDTESTDEFINITION", dataRow) { }
        protected LaboratoryGridBoundedTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDBOUNDEDTESTDEFINITION", dataRow, isImported) { }
        public LaboratoryGridBoundedTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridBoundedTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridBoundedTestDefinition() : base() { }

    }
}