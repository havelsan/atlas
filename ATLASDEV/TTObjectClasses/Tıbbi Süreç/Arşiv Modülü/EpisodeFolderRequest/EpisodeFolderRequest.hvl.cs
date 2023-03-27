
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeFolderRequest")] 

    public  partial class EpisodeFolderRequest : TTObject
    {
        public class EpisodeFolderRequestList : TTObjectCollection<EpisodeFolderRequest> { }
                    
        public class ChildEpisodeFolderRequestCollection : TTObject.TTChildObjectCollection<EpisodeFolderRequest>
        {
            public ChildEpisodeFolderRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeFolderRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İstek Yapılan Folder
    /// </summary>
        public EpisodeFolder EpisodeFolder
        {
            get { return (EpisodeFolder)((ITTObject)this).GetParent("EPISODEFOLDER"); }
            set { this["EPISODEFOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ArchiveRequest ArchiveRequest
        {
            get { return (ArchiveRequest)((ITTObject)this).GetParent("ARCHIVEREQUEST"); }
            set { this["ARCHIVEREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EpisodeFolderRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeFolderRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeFolderRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeFolderRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeFolderRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEFOLDERREQUEST", dataRow) { }
        protected EpisodeFolderRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEFOLDERREQUEST", dataRow, isImported) { }
        public EpisodeFolderRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeFolderRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeFolderRequest() : base() { }

    }
}