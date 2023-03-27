
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResFloor")] 

    /// <summary>
    /// Kat
    /// </summary>
    public  partial class ResFloor : ResSection
    {
        public class ResFloorList : TTObjectCollection<ResFloor> { }
                    
        public class ChildResFloorCollection : TTObject.TTChildObjectCollection<ResFloor>
        {
            public ChildResFloorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResFloorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFloorDefinition_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESFLOOR"].AllPropertyDefs["NAME"].DataType;
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

            public int? FloorNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FLOORNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESFLOOR"].AllPropertyDefs["FLOORNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public GetFloorDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFloorDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFloorDefinition_Class() : base() { }
        }

        public static BindingList<ResFloor.GetFloorDefinition_Class> GetFloorDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESFLOOR"].QueryDefs["GetFloorDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResFloor.GetFloorDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResFloor.GetFloorDefinition_Class> GetFloorDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESFLOOR"].QueryDefs["GetFloorDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResFloor.GetFloorDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResFloor> GetFloorDefinitionObject(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESFLOOR"].QueryDefs["GetFloorDefinitionObject"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResFloor>(queryDef, paramList, injectionSQL);
        }

        public int? FloorNumber
        {
            get { return (int?)this["FLOORNUMBER"]; }
            set { this["FLOORNUMBER"] = value; }
        }

        public ResBuildingWing ResBuildingWing
        {
            get { return (ResBuildingWing)((ITTObject)this).GetParent("RESBUILDINGWING"); }
            set { this["RESBUILDINGWING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bina
    /// </summary>
        public ResBuilding ResBuilding
        {
            get { return (ResBuilding)((ITTObject)this).GetParent("RESBUILDING"); }
            set { this["RESBUILDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResSectionsCollection()
        {
            _ResSections = new ResSection.ChildResSectionCollection(this, new Guid("5be009c2-7209-45f0-a717-b2d3f07ef17e"));
            ((ITTChildObjectCollection)_ResSections).GetChildren();
        }

        protected ResSection.ChildResSectionCollection _ResSections = null;
        public ResSection.ChildResSectionCollection ResSections
        {
            get
            {
                if (_ResSections == null)
                    CreateResSectionsCollection();
                return _ResSections;
            }
        }

        protected ResFloor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResFloor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResFloor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResFloor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResFloor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESFLOOR", dataRow) { }
        protected ResFloor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESFLOOR", dataRow, isImported) { }
        public ResFloor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResFloor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResFloor() : base() { }

    }
}