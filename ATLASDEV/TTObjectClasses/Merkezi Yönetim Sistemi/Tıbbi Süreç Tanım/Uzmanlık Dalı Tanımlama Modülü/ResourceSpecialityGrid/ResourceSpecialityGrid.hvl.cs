
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResourceSpecialityGrid")] 

    public  partial class ResourceSpecialityGrid : TTObject
    {
        public class ResourceSpecialityGridList : TTObjectCollection<ResourceSpecialityGrid> { }
                    
        public class ChildResourceSpecialityGridCollection : TTObject.TTChildObjectCollection<ResourceSpecialityGrid>
        {
            public ChildResourceSpecialityGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResourceSpecialityGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ResourceSpecialityGrid> GetBySpeciality(TTObjectContext objectContext, Guid SPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOURCESPECIALITYGRID"].QueryDefs["GetBySpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALITY", SPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<ResourceSpecialityGrid>(queryDef, paramList);
        }

    /// <summary>
    /// Ana Uzmanlık Dalı
    /// </summary>
        public bool? MainSpeciality
        {
            get { return (bool?)this["MAINSPECIALITY"]; }
            set { this["MAINSPECIALITY"] = value; }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResourceSpecialityGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResourceSpecialityGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResourceSpecialityGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResourceSpecialityGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResourceSpecialityGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESOURCESPECIALITYGRID", dataRow) { }
        protected ResourceSpecialityGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESOURCESPECIALITYGRID", dataRow, isImported) { }
        public ResourceSpecialityGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResourceSpecialityGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResourceSpecialityGrid() : base() { }

    }
}