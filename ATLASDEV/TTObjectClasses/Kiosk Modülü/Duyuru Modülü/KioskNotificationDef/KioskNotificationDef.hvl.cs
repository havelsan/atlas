
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KioskNotificationDef")] 

    /// <summary>
    /// Duyuru Modülü
    /// </summary>
    public  partial class KioskNotificationDef : TerminologyManagerDef
    {
        public class KioskNotificationDefList : TTObjectCollection<KioskNotificationDef> { }
                    
        public class ChildKioskNotificationDefCollection : TTObject.TTChildObjectCollection<KioskNotificationDef>
        {
            public ChildKioskNotificationDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKioskNotificationDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKioskNotificationDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKNOTIFICATIONDEF"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKNOTIFICATIONDEF"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Notification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKNOTIFICATIONDEF"].AllPropertyDefs["NOTIFICATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetKioskNotificationDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKioskNotificationDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKioskNotificationDefList_Class() : base() { }
        }

        public static BindingList<KioskNotificationDef.GetKioskNotificationDefList_Class> GetKioskNotificationDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KIOSKNOTIFICATIONDEF"].QueryDefs["GetKioskNotificationDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KioskNotificationDef.GetKioskNotificationDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KioskNotificationDef.GetKioskNotificationDefList_Class> GetKioskNotificationDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KIOSKNOTIFICATIONDEF"].QueryDefs["GetKioskNotificationDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KioskNotificationDef.GetKioskNotificationDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public string Notification
        {
            get { return (string)this["NOTIFICATION"]; }
            set { this["NOTIFICATION"] = value; }
        }

        virtual protected void CreateKioskNotificationDefsCollection()
        {
            _KioskNotificationDefs = new NotificationDevice.ChildNotificationDeviceCollection(this, new Guid("cc0df792-df35-4e3d-8aa4-1780ddbc5597"));
            ((ITTChildObjectCollection)_KioskNotificationDefs).GetChildren();
        }

        protected NotificationDevice.ChildNotificationDeviceCollection _KioskNotificationDefs = null;
        public NotificationDevice.ChildNotificationDeviceCollection KioskNotificationDefs
        {
            get
            {
                if (_KioskNotificationDefs == null)
                    CreateKioskNotificationDefsCollection();
                return _KioskNotificationDefs;
            }
        }

        protected KioskNotificationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KioskNotificationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KioskNotificationDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KioskNotificationDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KioskNotificationDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KIOSKNOTIFICATIONDEF", dataRow) { }
        protected KioskNotificationDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KIOSKNOTIFICATIONDEF", dataRow, isImported) { }
        public KioskNotificationDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KioskNotificationDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KioskNotificationDef() : base() { }

    }
}