
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProtocolAddingSubEpisode")] 

    public  partial class ProtocolAddingSubEpisode : TTObject
    {
        public class ProtocolAddingSubEpisodeList : TTObjectCollection<ProtocolAddingSubEpisode> { }
                    
        public class ChildProtocolAddingSubEpisodeCollection : TTObject.TTChildObjectCollection<ProtocolAddingSubEpisode>
        {
            public ChildProtocolAddingSubEpisodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProtocolAddingSubEpisodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Eklendi
    /// </summary>
        public bool? Add
        {
            get { return (bool?)this["ADD"]; }
            set { this["ADD"] = value; }
        }

        public Guid? SEObjectId
        {
            get { return (Guid?)this["SEOBJECTID"]; }
            set { this["SEOBJECTID"] = value; }
        }

        public string SEName
        {
            get { return (string)this["SENAME"]; }
            set { this["SENAME"] = value; }
        }

    /// <summary>
    /// Protokol ekleme SubEpisode arasındaki ilişki
    /// </summary>
        public ProtocolAdding ProtocolAdding
        {
            get { return (ProtocolAdding)((ITTObject)this).GetParent("PROTOCOLADDING"); }
            set { this["PROTOCOLADDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProtocolAddingSubEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProtocolAddingSubEpisode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProtocolAddingSubEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProtocolAddingSubEpisode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProtocolAddingSubEpisode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROTOCOLADDINGSUBEPISODE", dataRow) { }
        protected ProtocolAddingSubEpisode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROTOCOLADDINGSUBEPISODE", dataRow, isImported) { }
        public ProtocolAddingSubEpisode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProtocolAddingSubEpisode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProtocolAddingSubEpisode() : base() { }

    }
}