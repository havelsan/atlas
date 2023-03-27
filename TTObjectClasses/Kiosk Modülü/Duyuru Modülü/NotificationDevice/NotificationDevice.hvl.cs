
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NotificationDevice")] 

    public  partial class NotificationDevice : TTObject
    {
        public class NotificationDeviceList : TTObjectCollection<NotificationDevice> { }
                    
        public class ChildNotificationDeviceCollection : TTObject.TTChildObjectCollection<NotificationDevice>
        {
            public ChildNotificationDeviceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNotificationDeviceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDeviceForNotification_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string DeviceName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKDEVICEDEFINITION"].AllPropertyDefs["DEVICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Deviceobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEVICEOBJECTID"]);
                }
            }

            public GetDeviceForNotification_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDeviceForNotification_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDeviceForNotification_Class() : base() { }
        }

        public static BindingList<NotificationDevice.GetDeviceForNotification_Class> GetDeviceForNotification(Guid NOTIFICATIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NOTIFICATIONDEVICE"].QueryDefs["GetDeviceForNotification"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NOTIFICATIONOBJECTID", NOTIFICATIONOBJECTID);

            return TTReportNqlObject.QueryObjects<NotificationDevice.GetDeviceForNotification_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NotificationDevice.GetDeviceForNotification_Class> GetDeviceForNotification(TTObjectContext objectContext, Guid NOTIFICATIONOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NOTIFICATIONDEVICE"].QueryDefs["GetDeviceForNotification"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NOTIFICATIONOBJECTID", NOTIFICATIONOBJECTID);

            return TTReportNqlObject.QueryObjects<NotificationDevice.GetDeviceForNotification_Class>(objectContext, queryDef, paramList, pi);
        }

        public KioskDeviceDefinition Device
        {
            get { return (KioskDeviceDefinition)((ITTObject)this).GetParent("DEVICE"); }
            set { this["DEVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KioskNotificationDef Notification
        {
            get { return (KioskNotificationDef)((ITTObject)this).GetParent("NOTIFICATION"); }
            set { this["NOTIFICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NotificationDevice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NotificationDevice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NotificationDevice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NotificationDevice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NotificationDevice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NOTIFICATIONDEVICE", dataRow) { }
        protected NotificationDevice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NOTIFICATIONDEVICE", dataRow, isImported) { }
        public NotificationDevice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NotificationDevice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NotificationDevice() : base() { }

    }
}