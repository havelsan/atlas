
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResSurgeryDepartment")] 

    /// <summary>
    /// Ameliyathane
    /// </summary>
    public  partial class ResSurgeryDepartment : ResSection
    {
        public class ResSurgeryDepartmentList : TTObjectCollection<ResSurgeryDepartment> { }
                    
        public class ChildResSurgeryDepartmentCollection : TTObject.TTChildObjectCollection<ResSurgeryDepartment>
        {
            public ChildResSurgeryDepartmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResSurgeryDepartmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSurgeryDepartmentDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Departmentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSurgeryDepartmentDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurgeryDepartmentDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurgeryDepartmentDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ResSurgeryDepartment_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public OLAP_ResSurgeryDepartment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResSurgeryDepartment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResSurgeryDepartment_Class() : base() { }
        }

        public static BindingList<ResSurgeryDepartment> GetActiveSurgeryDepartments(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].QueryDefs["GetActiveSurgeryDepartments"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSurgeryDepartment>(queryDef, paramList);
        }

        public static BindingList<ResSurgeryDepartment.GetSurgeryDepartmentDefinition_Class> GetSurgeryDepartmentDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].QueryDefs["GetSurgeryDepartmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryDepartment.GetSurgeryDepartmentDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSurgeryDepartment.GetSurgeryDepartmentDefinition_Class> GetSurgeryDepartmentDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].QueryDefs["GetSurgeryDepartmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryDepartment.GetSurgeryDepartmentDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSurgeryDepartment.OLAP_ResSurgeryDepartment_Class> OLAP_ResSurgeryDepartment(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].QueryDefs["OLAP_ResSurgeryDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryDepartment.OLAP_ResSurgeryDepartment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResSurgeryDepartment.OLAP_ResSurgeryDepartment_Class> OLAP_ResSurgeryDepartment(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDEPARTMENT"].QueryDefs["OLAP_ResSurgeryDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSurgeryDepartment.OLAP_ResSurgeryDepartment_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bölüm
    /// </summary>
        public ResDepartment Department
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSurgeryRoomsCollection()
        {
            _SurgeryRooms = new ResSurgeryRoom.ChildResSurgeryRoomCollection(this, new Guid("192bf204-eb86-4540-a593-385d21dbb05e"));
            ((ITTChildObjectCollection)_SurgeryRooms).GetChildren();
        }

        protected ResSurgeryRoom.ChildResSurgeryRoomCollection _SurgeryRooms = null;
    /// <summary>
    /// Child collection for Ameliyathane
    /// </summary>
        public ResSurgeryRoom.ChildResSurgeryRoomCollection SurgeryRooms
        {
            get
            {
                if (_SurgeryRooms == null)
                    CreateSurgeryRoomsCollection();
                return _SurgeryRooms;
            }
        }

        protected ResSurgeryDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResSurgeryDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResSurgeryDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResSurgeryDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResSurgeryDepartment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSURGERYDEPARTMENT", dataRow) { }
        protected ResSurgeryDepartment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSURGERYDEPARTMENT", dataRow, isImported) { }
        public ResSurgeryDepartment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResSurgeryDepartment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResSurgeryDepartment() : base() { }

    }
}