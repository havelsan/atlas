
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResSurgeryRoom")] 

    /// <summary>
    /// Ameliyat Salonu
    /// </summary>
    public  partial class ResSurgeryRoom : ResSection
    {
        public class ResSurgeryRoomList : TTObjectCollection<ResSurgeryRoom> { }
                    
        public class ChildResSurgeryRoomCollection : TTObject.TTChildObjectCollection<ResSurgeryRoom>
        {
            public ChildResSurgeryRoomCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResSurgeryRoomCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSurgeryRoomDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgerydepartmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDEPARTMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryRoomDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryRoomDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryRoomDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ResSurgeryRoom_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? SurgeryDepartment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SURGERYDEPARTMENT"]);
                }
            }

            public OLAP_ResSurgeryRoom_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResSurgeryRoom_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResSurgeryRoom_Class() : base() { }
        }

        public static BindingList<ResSurgeryRoom.GetSurgeryRoomDefinition_Class> GetSurgeryRoomDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].QueryDefs["GetSurgeryRoomDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryRoom.GetSurgeryRoomDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSurgeryRoom.GetSurgeryRoomDefinition_Class> GetSurgeryRoomDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].QueryDefs["GetSurgeryRoomDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryRoom.GetSurgeryRoomDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSurgeryRoom.OLAP_ResSurgeryRoom_Class> OLAP_ResSurgeryRoom(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].QueryDefs["OLAP_ResSurgeryRoom"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryRoom.OLAP_ResSurgeryRoom_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResSurgeryRoom.OLAP_ResSurgeryRoom_Class> OLAP_ResSurgeryRoom(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].QueryDefs["OLAP_ResSurgeryRoom"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryRoom.OLAP_ResSurgeryRoom_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResSurgeryRoom> GetActiveSurgeryRooms(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].QueryDefs["GetActiveSurgeryRooms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSurgeryRoom>(queryDef, paramList);
        }

    /// <summary>
    /// Ameliyathane
    /// </summary>
        public ResSurgeryDepartment SurgeryDepartment
        {
            get { return (ResSurgeryDepartment)((ITTObject)this).GetParent("SURGERYDEPARTMENT"); }
            set { this["SURGERYDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSurgeryDesksCollection()
        {
            _SurgeryDesks = new ResSurgeryDesk.ChildResSurgeryDeskCollection(this, new Guid("8b0b6e13-4ae3-4f3c-bb1e-43b9c1d7b687"));
            ((ITTChildObjectCollection)_SurgeryDesks).GetChildren();
        }

        protected ResSurgeryDesk.ChildResSurgeryDeskCollection _SurgeryDesks = null;
    /// <summary>
    /// Child collection for Ameliyat Odası
    /// </summary>
        public ResSurgeryDesk.ChildResSurgeryDeskCollection SurgeryDesks
        {
            get
            {
                if (_SurgeryDesks == null)
                    CreateSurgeryDesksCollection();
                return _SurgeryDesks;
            }
        }

        protected ResSurgeryRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResSurgeryRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResSurgeryRoom(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResSurgeryRoom(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResSurgeryRoom(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSURGERYROOM", dataRow) { }
        protected ResSurgeryRoom(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSURGERYROOM", dataRow, isImported) { }
        public ResSurgeryRoom(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResSurgeryRoom(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResSurgeryRoom() : base() { }

    }
}