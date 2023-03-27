
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeFolderContent")] 

    /// <summary>
    /// Dosya İçeriği
    /// </summary>
    public  partial class EpisodeFolderContent : TTObject
    {
        public class EpisodeFolderContentList : TTObjectCollection<EpisodeFolderContent> { }
                    
        public class ChildEpisodeFolderContentCollection : TTObject.TTChildObjectCollection<EpisodeFolderContent>
        {
            public ChildEpisodeFolderContentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeFolderContentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Durum
    /// </summary>
        public EpisodeFolderContentStatusEnum? FolderContentStatus
        {
            get { return (EpisodeFolderContentStatusEnum?)(int?)this["FOLDERCONTENTSTATUS"]; }
            set { this["FOLDERCONTENTSTATUS"] = value; }
        }

    /// <summary>
    /// Cilt İçerik
    /// </summary>
        public PatientFolderContentDefinition File
        {
            get { return (PatientFolderContentDefinition)((ITTObject)this).GetParent("FILE"); }
            set { this["FILE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dosya İçeriği
    /// </summary>
        public EpisodeFolder EpisodeFolder
        {
            get { return (EpisodeFolder)((ITTObject)this).GetParent("EPISODEFOLDER"); }
            set { this["EPISODEFOLDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EpisodeFolderContent(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeFolderContent(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeFolderContent(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeFolderContent(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeFolderContent(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEFOLDERCONTENT", dataRow) { }
        protected EpisodeFolderContent(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEFOLDERCONTENT", dataRow, isImported) { }
        public EpisodeFolderContent(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeFolderContent(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeFolderContent() : base() { }

    }
}