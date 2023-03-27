
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProjectManager")] 

    /// <summary>
    /// DE_Proje Yöneticisi
    /// </summary>
    public  partial class ProjectManager : TTObject
    {
        public class ProjectManagerList : TTObjectCollection<ProjectManager> { }
                    
        public class ChildProjectManagerCollection : TTObject.TTChildObjectCollection<ProjectManager>
        {
            public ChildProjectManagerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProjectManagerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Biyografi
    /// </summary>
        public string CV
        {
            get { return (string)this["CV"]; }
            set { this["CV"] = value; }
        }

        protected ProjectManager(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProjectManager(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProjectManager(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProjectManager(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProjectManager(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROJECTMANAGER", dataRow) { }
        protected ProjectManager(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROJECTMANAGER", dataRow, isImported) { }
        public ProjectManager(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProjectManager(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProjectManager() : base() { }

    }
}