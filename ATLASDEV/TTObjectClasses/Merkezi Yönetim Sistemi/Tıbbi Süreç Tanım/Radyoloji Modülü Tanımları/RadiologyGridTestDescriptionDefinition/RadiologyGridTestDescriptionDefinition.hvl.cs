
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyGridTestDescriptionDefinition")] 

    public  partial class RadiologyGridTestDescriptionDefinition : TTDefinitionSet
    {
        public class RadiologyGridTestDescriptionDefinitionList : TTObjectCollection<RadiologyGridTestDescriptionDefinition> { }
                    
        public class ChildRadiologyGridTestDescriptionDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyGridTestDescriptionDefinition>
        {
            public ChildRadiologyGridTestDescriptionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyGridTestDescriptionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public RadiologyTestDescriptionDefinition TestDescription
        {
            get { return (RadiologyTestDescriptionDefinition)((ITTObject)this).GetParent("TESTDESCRIPTION"); }
            set { this["TESTDESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTestDefinition RadiologyTest
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("RADIOLOGYTEST"); }
            set { this["RADIOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyGridTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyGridTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyGridTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyGridTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyGridTestDescriptionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYGRIDTESTDESCRIPTIONDEFINITION", dataRow) { }
        protected RadiologyGridTestDescriptionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYGRIDTESTDESCRIPTIONDEFINITION", dataRow, isImported) { }
        public RadiologyGridTestDescriptionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyGridTestDescriptionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyGridTestDescriptionDefinition() : base() { }

    }
}