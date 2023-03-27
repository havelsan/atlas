
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ENabiz")] 

    public  partial class ENabiz : TTObject
    {
        public class ENabizList : TTObjectCollection<ENabiz> { }
                    
        public class ChildENabizCollection : TTObject.TTChildObjectCollection<ENabiz>
        {
            public ChildENabizCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildENabizCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? PackageID
        {
            get { return (int?)this["PACKAGEID"]; }
            set { this["PACKAGEID"] = value; }
        }

        public string PackageName
        {
            get { return (string)this["PACKAGENAME"]; }
            set { this["PACKAGENAME"] = value; }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ENabiz(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ENabiz(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ENabiz(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ENABIZ", dataRow) { }
        protected ENabiz(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ENABIZ", dataRow, isImported) { }
        public ENabiz(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ENabiz(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ENabiz() : base() { }

    }
}