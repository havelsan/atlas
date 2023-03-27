
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SiteRemoteMethodDefCustomization")] 

    public  partial class SiteRemoteMethodDefCustomization : TTDefinitionSet
    {
        public class SiteRemoteMethodDefCustomizationList : TTObjectCollection<SiteRemoteMethodDefCustomization> { }
                    
        public class ChildSiteRemoteMethodDefCustomizationCollection : TTObject.TTChildObjectCollection<SiteRemoteMethodDefCustomization>
        {
            public ChildSiteRemoteMethodDefCustomizationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSiteRemoteMethodDefCustomizationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? KeepDays
        {
            get { return (int?)this["KEEPDAYS"]; }
            set { this["KEEPDAYS"] = value; }
        }

        public Guid? RemoteMethodDefID
        {
            get { return (Guid?)this["REMOTEMETHODDEFID"]; }
            set { this["REMOTEMETHODDEFID"] = value; }
        }

        public string RemoteMethodDefName
        {
            get { return (string)this["REMOTEMETHODDEFNAME"]; }
            set { this["REMOTEMETHODDEFNAME"] = value; }
        }

        public bool? IsSendingStartStop
        {
            get { return (bool?)this["ISSENDINGSTARTSTOP"]; }
            set { this["ISSENDINGSTARTSTOP"] = value; }
        }

        public bool? IsKeepCompleted
        {
            get { return (bool?)this["ISKEEPCOMPLETED"]; }
            set { this["ISKEEPCOMPLETED"] = value; }
        }

        public DateTime? SendingStartTime
        {
            get { return (DateTime?)this["SENDINGSTARTTIME"]; }
            set { this["SENDINGSTARTTIME"] = value; }
        }

        public DateTime? SendingEndTime
        {
            get { return (DateTime?)this["SENDINGENDTIME"]; }
            set { this["SENDINGENDTIME"] = value; }
        }

        public SiteMessageQueueCustomization SiteMessageQueueCustomization
        {
            get { return (SiteMessageQueueCustomization)((ITTObject)this).GetParent("SITEMESSAGEQUEUECUSTOMIZATION"); }
            set { this["SITEMESSAGEQUEUECUSTOMIZATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SiteRemoteMethodDefCustomization(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SiteRemoteMethodDefCustomization(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SiteRemoteMethodDefCustomization(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SiteRemoteMethodDefCustomization(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SiteRemoteMethodDefCustomization(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SITEREMOTEMETHODDEFCUSTOMIZATION", dataRow) { }
        protected SiteRemoteMethodDefCustomization(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SITEREMOTEMETHODDEFCUSTOMIZATION", dataRow, isImported) { }
        public SiteRemoteMethodDefCustomization(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SiteRemoteMethodDefCustomization(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SiteRemoteMethodDefCustomization() : base() { }

    }
}