
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResRoomGroup")] 

    /// <summary>
    /// Oda Grup
    /// </summary>
    public  partial class ResRoomGroup : ResSection
    {
        public class ResRoomGroupList : TTObjectCollection<ResRoomGroup> { }
                    
        public class ChildResRoomGroupCollection : TTObject.TTChildObjectCollection<ResRoomGroup>
        {
            public ChildResRoomGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResRoomGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRoomGroupDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Wardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRoomGroupDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRoomGroupDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRoomGroupDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ResRoomGroup_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? Ward
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WARD"]);
                }
            }

            public OLAP_ResRoomGroup_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResRoomGroup_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResRoomGroup_Class() : base() { }
        }

        public static BindingList<ResRoomGroup> GetWithoutIntensiveCareRoomGroup(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].QueryDefs["GetWithoutIntensiveCareRoomGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResRoomGroup>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ResRoomGroup.GetRoomGroupDefinition_Class> GetRoomGroupDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].QueryDefs["GetRoomGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoomGroup.GetRoomGroupDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResRoomGroup.GetRoomGroupDefinition_Class> GetRoomGroupDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].QueryDefs["GetRoomGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoomGroup.GetRoomGroupDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResRoomGroup.OLAP_ResRoomGroup_Class> OLAP_ResRoomGroup(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].QueryDefs["OLAP_ResRoomGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoomGroup.OLAP_ResRoomGroup_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResRoomGroup.OLAP_ResRoomGroup_Class> OLAP_ResRoomGroup(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESROOMGROUP"].QueryDefs["OLAP_ResRoomGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResRoomGroup.OLAP_ResRoomGroup_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yatan Hasta Birimi
    /// </summary>
        public ResWard Ward
        {
            get { return (ResWard)((ITTObject)this).GetParent("WARD"); }
            set { this["WARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRoomsCollection()
        {
            _Rooms = new ResRoom.ChildResRoomCollection(this, new Guid("11538d1f-e98f-4d97-9fd2-958e3496ec61"));
            ((ITTChildObjectCollection)_Rooms).GetChildren();
        }

        protected ResRoom.ChildResRoomCollection _Rooms = null;
    /// <summary>
    /// Child collection for OdaGroup
    /// </summary>
        public ResRoom.ChildResRoomCollection Rooms
        {
            get
            {
                if (_Rooms == null)
                    CreateRoomsCollection();
                return _Rooms;
            }
        }

        protected ResRoomGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResRoomGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResRoomGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResRoomGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResRoomGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESROOMGROUP", dataRow) { }
        protected ResRoomGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESROOMGROUP", dataRow, isImported) { }
        public ResRoomGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResRoomGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResRoomGroup() : base() { }

    }
}