
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyGridDepartmentDefinition")] 

    public  partial class RadiologyGridDepartmentDefinition : TTDefinitionSet
    {
        public class RadiologyGridDepartmentDefinitionList : TTObjectCollection<RadiologyGridDepartmentDefinition> { }
                    
        public class ChildRadiologyGridDepartmentDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyGridDepartmentDefinition>
        {
            public ChildRadiologyGridDepartmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyGridDepartmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<RadiologyGridDepartmentDefinition> GetRadGridDepartments(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYGRIDDEPARTMENTDEFINITION"].QueryDefs["GetRadGridDepartments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RadiologyGridDepartmentDefinition>(queryDef, paramList, injectionSQL);
        }

        public ResRadiologyDepartment Department
        {
            get { return (ResRadiologyDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RadiologyTestDefinition RadiologyTest
        {
            get { return (RadiologyTestDefinition)((ITTObject)this).GetParent("RADIOLOGYTEST"); }
            set { this["RADIOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RadiologyGridDepartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyGridDepartmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyGridDepartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyGridDepartmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyGridDepartmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYGRIDDEPARTMENTDEFINITION", dataRow) { }
        protected RadiologyGridDepartmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYGRIDDEPARTMENTDEFINITION", dataRow, isImported) { }
        public RadiologyGridDepartmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyGridDepartmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyGridDepartmentDefinition() : base() { }

    }
}