
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KioskDeviceDefinition")] 

    /// <summary>
    /// Kiosk Cihaz Tanımı
    /// </summary>
    public  partial class KioskDeviceDefinition : TerminologyManagerDef
    {
        public class KioskDeviceDefinitionList : TTObjectCollection<KioskDeviceDefinition> { }
                    
        public class ChildKioskDeviceDefinitionCollection : TTObject.TTChildObjectCollection<KioskDeviceDefinition>
        {
            public ChildKioskDeviceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKioskDeviceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKioskDeviceDefinitionList_Class : TTReportNqlObject 
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

            public bool? HasPatientAdmission
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASPATIENTADMISSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKDEVICEDEFINITION"].AllPropertyDefs["HASPATIENTADMISSION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasMernisVerification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASMERNISVERIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKDEVICEDEFINITION"].AllPropertyDefs["HASMERNISVERIFICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasPatientResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASPATIENTRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKDEVICEDEFINITION"].AllPropertyDefs["HASPATIENTRESULT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasAppointmentAvailable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASAPPOINTMENTAVAILABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKDEVICEDEFINITION"].AllPropertyDefs["HASAPPOINTMENTAVAILABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DeviceCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["KIOSKDEVICEDEFINITION"].AllPropertyDefs["DEVICECODE"].DataType;
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

            public Guid? ResUser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESUSER"]);
                }
            }

            public GetKioskDeviceDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKioskDeviceDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKioskDeviceDefinitionList_Class() : base() { }
        }

        public static BindingList<KioskDeviceDefinition.GetKioskDeviceDefinitionList_Class> GetKioskDeviceDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KIOSKDEVICEDEFINITION"].QueryDefs["GetKioskDeviceDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KioskDeviceDefinition.GetKioskDeviceDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KioskDeviceDefinition.GetKioskDeviceDefinitionList_Class> GetKioskDeviceDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KIOSKDEVICEDEFINITION"].QueryDefs["GetKioskDeviceDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<KioskDeviceDefinition.GetKioskDeviceDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string DeviceName
        {
            get { return (string)this["DEVICENAME"]; }
            set { this["DEVICENAME"] = value; }
        }

        public bool? HasPatientAdmission
        {
            get { return (bool?)this["HASPATIENTADMISSION"]; }
            set { this["HASPATIENTADMISSION"] = value; }
        }

        public bool? HasMernisVerification
        {
            get { return (bool?)this["HASMERNISVERIFICATION"]; }
            set { this["HASMERNISVERIFICATION"] = value; }
        }

        public bool? HasPatientResult
        {
            get { return (bool?)this["HASPATIENTRESULT"]; }
            set { this["HASPATIENTRESULT"] = value; }
        }

        public string DeviceCode
        {
            get { return (string)this["DEVICECODE"]; }
            set { this["DEVICECODE"] = value; }
        }

        public bool? HasAppointmentAvailable
        {
            get { return (bool?)this["HASAPPOINTMENTAVAILABLE"]; }
            set { this["HASAPPOINTMENTAVAILABLE"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateKioskDeviceDefinitionsCollection()
        {
            _KioskDeviceDefinitions = new NotificationDevice.ChildNotificationDeviceCollection(this, new Guid("dc9fb94a-7748-410d-8b05-8e457a599b66"));
            ((ITTChildObjectCollection)_KioskDeviceDefinitions).GetChildren();
        }

        protected NotificationDevice.ChildNotificationDeviceCollection _KioskDeviceDefinitions = null;
        public NotificationDevice.ChildNotificationDeviceCollection KioskDeviceDefinitions
        {
            get
            {
                if (_KioskDeviceDefinitions == null)
                    CreateKioskDeviceDefinitionsCollection();
                return _KioskDeviceDefinitions;
            }
        }

        protected KioskDeviceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KioskDeviceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KioskDeviceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KioskDeviceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KioskDeviceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KIOSKDEVICEDEFINITION", dataRow) { }
        protected KioskDeviceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KIOSKDEVICEDEFINITION", dataRow, isImported) { }
        public KioskDeviceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KioskDeviceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KioskDeviceDefinition() : base() { }

    }
}