
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CourseGrid")] 

    public  partial class CourseGrid : TTObject
    {
        public class CourseGridList : TTObjectCollection<CourseGrid> { }
                    
        public class ChildCourseGridCollection : TTObject.TTChildObjectCollection<CourseGrid>
        {
            public ChildCourseGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCourseGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DietDefinition DietDefinition
        {
            get { return (DietDefinition)((ITTObject)this).GetParent("DIETDEFINITION"); }
            set { this["DIETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CourseDefinition CourseDefinition
        {
            get { return (CourseDefinition)((ITTObject)this).GetParent("COURSEDEFINITION"); }
            set { this["COURSEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CourseGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CourseGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CourseGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CourseGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CourseGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COURSEGRID", dataRow) { }
        protected CourseGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COURSEGRID", dataRow, isImported) { }
        public CourseGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CourseGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CourseGrid() : base() { }

    }
}