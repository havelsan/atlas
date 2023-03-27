
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Notification")] 

    /// <summary>
    /// Bildirim
    /// </summary>
    public  partial class Notification : TTObject
    {
        public class NotificationList : TTObjectCollection<Notification> { }
                    
        public class ChildNotificationCollection : TTObject.TTChildObjectCollection<Notification>
        {
            public ChildNotificationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNotificationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// ActionData (JSON string)
    /// </summary>
        public string ActionData
        {
            get { return (string)this["ACTIONDATA"]; }
            set { this["ACTIONDATA"] = value; }
        }

    /// <summary>
    /// Content
    /// </summary>
        public string Content
        {
            get { return (string)this["CONTENT"]; }
            set { this["CONTENT"] = value; }
        }

    /// <summary>
    /// ContentType
    /// </summary>
        public int? ContentType
        {
            get { return (int?)this["CONTENTTYPE"]; }
            set { this["CONTENTTYPE"] = value; }
        }

    /// <summary>
    /// CreateTime
    /// </summary>
        public DateTime? CreateTime
        {
            get { return (DateTime?)this["CREATETIME"]; }
            set { this["CREATETIME"] = value; }
        }

    /// <summary>
    /// HeaderDefinition
    /// </summary>
        public string HeaderDefinition
        {
            get { return (string)this["HEADERDEFINITION"]; }
            set { this["HEADERDEFINITION"] = value; }
        }

    /// <summary>
    /// SourceType
    /// </summary>
        public int? SourceType
        {
            get { return (int?)this["SOURCETYPE"]; }
            set { this["SOURCETYPE"] = value; }
        }

    /// <summary>
    /// ResUser (Gönderen)
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNotificationUserCollection()
        {
            _NotificationUser = new NotificationUser.ChildNotificationUserCollection(this, new Guid("7299f0d9-d1cf-4738-bf86-35d2312ed55f"));
            ((ITTChildObjectCollection)_NotificationUser).GetChildren();
        }

        protected NotificationUser.ChildNotificationUserCollection _NotificationUser = null;
    /// <summary>
    /// Child collection for Notification
    /// </summary>
        public NotificationUser.ChildNotificationUserCollection NotificationUser
        {
            get
            {
                if (_NotificationUser == null)
                    CreateNotificationUserCollection();
                return _NotificationUser;
            }
        }

        protected Notification(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Notification(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Notification(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Notification(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Notification(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NOTIFICATION", dataRow) { }
        protected Notification(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NOTIFICATION", dataRow, isImported) { }
        public Notification(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Notification(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Notification() : base() { }

    }
}