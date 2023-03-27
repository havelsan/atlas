
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResSterilizationDevice")] 

    /// <summary>
    /// Sterilizasyon Cihazları
    /// </summary>
    public  partial class ResSterilizationDevice : ResSection
    {
        public class ResSterilizationDeviceList : TTObjectCollection<ResSterilizationDevice> { }
                    
        public class ChildResSterilizationDeviceCollection : TTObject.TTChildObjectCollection<ResSterilizationDevice>
        {
            public ChildResSterilizationDeviceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResSterilizationDeviceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResSterilizationDevice_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONDEVICE"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONDEVICE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Buildingname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUILDINGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetResSterilizationDevice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResSterilizationDevice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResSterilizationDevice_Class() : base() { }
        }

        public static BindingList<ResSterilizationDevice.GetResSterilizationDevice_Class> GetResSterilizationDevice(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONDEVICE"].QueryDefs["GetResSterilizationDevice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSterilizationDevice.GetResSterilizationDevice_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSterilizationDevice.GetResSterilizationDevice_Class> GetResSterilizationDevice(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONDEVICE"].QueryDefs["GetResSterilizationDevice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSterilizationDevice.GetResSterilizationDevice_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSterilizationDevice> GetAllActiveSterilizationDevice(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONDEVICE"].QueryDefs["GetAllActiveSterilizationDevice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSterilizationDevice>(queryDef, paramList);
        }

        public ResSterilizationUnit ResSterilizationUnit
        {
            get { return (ResSterilizationUnit)((ITTObject)this).GetParent("RESSTERILIZATIONUNIT"); }
            set { this["RESSTERILIZATIONUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResSterilizationDevice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResSterilizationDevice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResSterilizationDevice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResSterilizationDevice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResSterilizationDevice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSTERILIZATIONDEVICE", dataRow) { }
        protected ResSterilizationDevice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSTERILIZATIONDEVICE", dataRow, isImported) { }
        public ResSterilizationDevice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResSterilizationDevice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResSterilizationDevice() : base() { }

    }
}