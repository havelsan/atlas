
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrRadiology")] 

    /// <summary>
    /// Radyoloji İstek
    /// </summary>
    public  partial class ehrRadiology : ehrEpisodeAction
    {
        public class ehrRadiologyList : TTObjectCollection<ehrRadiology> { }
                    
        public class ChildehrRadiologyCollection : TTObject.TTChildObjectCollection<ehrRadiology>
        {
            public ChildehrRadiologyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrRadiologyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        protected ehrRadiology(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrRadiology(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrRadiology(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrRadiology(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrRadiology(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRRADIOLOGY", dataRow) { }
        protected ehrRadiology(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRRADIOLOGY", dataRow, isImported) { }
        public ehrRadiology(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrRadiology(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrRadiology() : base() { }

    }
}