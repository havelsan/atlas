
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CloseToNewOldEpisodes")] 

    public  partial class CloseToNewOldEpisodes : BaseScheduledTask
    {
        public class CloseToNewOldEpisodesList : TTObjectCollection<CloseToNewOldEpisodes> { }
                    
        public class ChildCloseToNewOldEpisodesCollection : TTObject.TTChildObjectCollection<CloseToNewOldEpisodes>
        {
            public ChildCloseToNewOldEpisodesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCloseToNewOldEpisodesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected CloseToNewOldEpisodes(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CloseToNewOldEpisodes(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CloseToNewOldEpisodes(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CloseToNewOldEpisodes(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CloseToNewOldEpisodes(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CLOSETONEWOLDEPISODES", dataRow) { }
        protected CloseToNewOldEpisodes(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CLOSETONEWOLDEPISODES", dataRow, isImported) { }
        public CloseToNewOldEpisodes(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CloseToNewOldEpisodes(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CloseToNewOldEpisodes() : base() { }

    }
}