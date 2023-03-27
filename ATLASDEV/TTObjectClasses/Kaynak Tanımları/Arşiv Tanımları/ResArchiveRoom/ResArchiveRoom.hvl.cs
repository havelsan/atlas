
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResArchiveRoom")] 

    /// <summary>
    /// Arşiv Odası Tanımları
    /// </summary>
    public  partial class ResArchiveRoom : ResSection
    {
        public class ResArchiveRoomList : TTObjectCollection<ResArchiveRoom> { }
                    
        public class ChildResArchiveRoomCollection : TTObject.TTChildObjectCollection<ResArchiveRoom>
        {
            public ChildResArchiveRoomCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResArchiveRoomCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetArchiveRoomDefNql_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESARCHIVEROOM"].AllPropertyDefs["NAME"].DataType;
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

            public string Wingname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WINGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDINGWING"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Floorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FLOORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESFLOOR"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetArchiveRoomDefNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetArchiveRoomDefNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetArchiveRoomDefNql_Class() : base() { }
        }

        public static BindingList<ResArchiveRoom.GetArchiveRoomDefNql_Class> GetArchiveRoomDefNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESARCHIVEROOM"].QueryDefs["GetArchiveRoomDefNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResArchiveRoom.GetArchiveRoomDefNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResArchiveRoom.GetArchiveRoomDefNql_Class> GetArchiveRoomDefNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESARCHIVEROOM"].QueryDefs["GetArchiveRoomDefNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResArchiveRoom.GetArchiveRoomDefNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResArchiveRoom> GetArchiveRoomListDef(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESARCHIVEROOM"].QueryDefs["GetArchiveRoomListDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResArchiveRoom>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Bina
    /// </summary>
        public ResBuilding ResBuilding
        {
            get { return (ResBuilding)((ITTObject)this).GetParent("RESBUILDING"); }
            set { this["RESBUILDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kanat
    /// </summary>
        public ResBuildingWing ResBuildingWing
        {
            get { return (ResBuildingWing)((ITTObject)this).GetParent("RESBUILDINGWING"); }
            set { this["RESBUILDINGWING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResCabinetsCollection()
        {
            _ResCabinets = new ResCabinet.ChildResCabinetCollection(this, new Guid("55246fbc-61a9-4c27-b765-b5c419accafd"));
            ((ITTChildObjectCollection)_ResCabinets).GetChildren();
        }

        protected ResCabinet.ChildResCabinetCollection _ResCabinets = null;
    /// <summary>
    /// Child collection for Dolabın bulunduğu oda
    /// </summary>
        public ResCabinet.ChildResCabinetCollection ResCabinets
        {
            get
            {
                if (_ResCabinets == null)
                    CreateResCabinetsCollection();
                return _ResCabinets;
            }
        }

        protected ResArchiveRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResArchiveRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResArchiveRoom(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResArchiveRoom(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResArchiveRoom(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESARCHIVEROOM", dataRow) { }
        protected ResArchiveRoom(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESARCHIVEROOM", dataRow, isImported) { }
        public ResArchiveRoom(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResArchiveRoom(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResArchiveRoom() : base() { }

    }
}