
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResBuildingWing")] 

    /// <summary>
    /// Kanat
    /// </summary>
    public  partial class ResBuildingWing : ResSection
    {
        public class ResBuildingWingList : TTObjectCollection<ResBuildingWing> { }
                    
        public class ChildResBuildingWingCollection : TTObject.TTChildObjectCollection<ResBuildingWing>
        {
            public ChildResBuildingWingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResBuildingWingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWingDefinitionNql_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDINGWING"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetWingDefinitionNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWingDefinitionNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWingDefinitionNql_Class() : base() { }
        }

        public static BindingList<ResBuildingWing.GetWingDefinitionNql_Class> GetWingDefinitionNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDINGWING"].QueryDefs["GetWingDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBuildingWing.GetWingDefinitionNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBuildingWing.GetWingDefinitionNql_Class> GetWingDefinitionNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDINGWING"].QueryDefs["GetWingDefinitionNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBuildingWing.GetWingDefinitionNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBuildingWing> GetWingDefinitionObject(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDINGWING"].QueryDefs["GetWingDefinitionObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResBuildingWing>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Bina
    /// </summary>
        public ResBuilding ResBuilding
        {
            get { return (ResBuilding)((ITTObject)this).GetParent("RESBUILDING"); }
            set { this["RESBUILDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResFloorsCollection()
        {
            _ResFloors = new ResFloor.ChildResFloorCollection(this, new Guid("cd2ec5cf-3b75-4737-83e3-7b94d4825173"));
            ((ITTChildObjectCollection)_ResFloors).GetChildren();
        }

        protected ResFloor.ChildResFloorCollection _ResFloors = null;
        public ResFloor.ChildResFloorCollection ResFloors
        {
            get
            {
                if (_ResFloors == null)
                    CreateResFloorsCollection();
                return _ResFloors;
            }
        }

        protected ResBuildingWing(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResBuildingWing(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResBuildingWing(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResBuildingWing(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResBuildingWing(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESBUILDINGWING", dataRow) { }
        protected ResBuildingWing(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESBUILDINGWING", dataRow, isImported) { }
        public ResBuildingWing(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResBuildingWing(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResBuildingWing() : base() { }

    }
}