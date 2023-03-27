
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectAdvisor")] 

    public  partial class ProjectAdvisor : TTObject
    {
        public class ProjectAdvisorList : TTObjectCollection<ProjectAdvisor> { }
                    
        public class ChildProjectAdvisorCollection : TTObject.TTChildObjectCollection<ProjectAdvisor>
        {
            public ChildProjectAdvisorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectAdvisorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ResUser ArgeProjectAdvisor
        {
            get { return (ResUser)((ITTObject)this).GetParent("ARGEPROJECTADVISOR"); }
            set { this["ARGEPROJECTADVISOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ArgeProject ArgeProject
        {
            get { return (ArgeProject)((ITTObject)this).GetParent("ARGEPROJECT"); }
            set { this["ARGEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProjectAdvisor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectAdvisor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectAdvisor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectAdvisor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectAdvisor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTADVISOR", dataRow) { }
        protected ProjectAdvisor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTADVISOR", dataRow, isImported) { }
        public ProjectAdvisor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectAdvisor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectAdvisor() : base() { }

    }
}