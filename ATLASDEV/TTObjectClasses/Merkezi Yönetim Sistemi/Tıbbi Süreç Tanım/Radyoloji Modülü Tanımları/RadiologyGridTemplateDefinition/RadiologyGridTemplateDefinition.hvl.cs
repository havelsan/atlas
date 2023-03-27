
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyGridTemplateDefinition")] 

    public  partial class RadiologyGridTemplateDefinition : TTDefinitionSet
    {
        public class RadiologyGridTemplateDefinitionList : TTObjectCollection<RadiologyGridTemplateDefinition> { }
                    
        public class ChildRadiologyGridTemplateDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyGridTemplateDefinition>
        {
            public ChildRadiologyGridTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyGridTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public RadiologyTemplateDefinition Template
        {
            get { return (RadiologyTemplateDefinition)((ITTObject)this).GetParent("TEMPLATE"); }
            set { this["TEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTestDefinition RadiologyTest
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("RADIOLOGYTEST"); }
            set { this["RADIOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyGridTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyGridTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyGridTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyGridTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyGridTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYGRIDTEMPLATEDEFINITION", dataRow) { }
        protected RadiologyGridTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYGRIDTEMPLATEDEFINITION", dataRow, isImported) { }
        public RadiologyGridTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyGridTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyGridTemplateDefinition() : base() { }

    }
}