
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ArchiveFileLocation")] 

    /// <summary>
    /// Dosya Lokasyonları
    /// </summary>
    public  partial class ArchiveFileLocation : ResSection
    {
        public class ArchiveFileLocationList : TTObjectCollection<ArchiveFileLocation> { }
                    
        public class ChildArchiveFileLocationCollection : TTObject.TTChildObjectCollection<ArchiveFileLocation>
        {
            public ChildArchiveFileLocationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildArchiveFileLocationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected ArchiveFileLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ArchiveFileLocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ArchiveFileLocation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ArchiveFileLocation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ArchiveFileLocation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARCHIVEFILELOCATION", dataRow) { }
        protected ArchiveFileLocation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARCHIVEFILELOCATION", dataRow, isImported) { }
        public ArchiveFileLocation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ArchiveFileLocation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ArchiveFileLocation() : base() { }

    }
}