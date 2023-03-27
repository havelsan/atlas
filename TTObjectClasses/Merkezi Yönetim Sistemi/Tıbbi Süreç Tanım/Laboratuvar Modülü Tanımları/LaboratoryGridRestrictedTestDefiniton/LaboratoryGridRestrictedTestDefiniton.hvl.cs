
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryGridRestrictedTestDefiniton")] 

    public  partial class LaboratoryGridRestrictedTestDefiniton : TTDefinitionSet
    {
        public class LaboratoryGridRestrictedTestDefinitonList : TTObjectCollection<LaboratoryGridRestrictedTestDefiniton> { }
                    
        public class ChildLaboratoryGridRestrictedTestDefinitonCollection : TTObject.TTChildObjectCollection<LaboratoryGridRestrictedTestDefiniton>
        {
            public ChildLaboratoryGridRestrictedTestDefinitonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryGridRestrictedTestDefinitonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTestDefinition
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTESTDEFINITION"); }
            set { this["LABORATORYTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Test Tanımı İlişkisi
    /// </summary>
        public LaboratoryTestDefinition LaboratoryTest
        {
            get { return (LaboratoryTestDefinition)((ITTObject)this).GetParent("LABORATORYTEST"); }
            set { this["LABORATORYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LaboratoryGridRestrictedTestDefiniton(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryGridRestrictedTestDefiniton(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryGridRestrictedTestDefiniton(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryGridRestrictedTestDefiniton(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryGridRestrictedTestDefiniton(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYGRIDRESTRICTEDTESTDEFINITON", dataRow) { }
        protected LaboratoryGridRestrictedTestDefiniton(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYGRIDRESTRICTEDTESTDEFINITON", dataRow, isImported) { }
        public LaboratoryGridRestrictedTestDefiniton(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryGridRestrictedTestDefiniton(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryGridRestrictedTestDefiniton() : base() { }

    }
}