
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialCodeGrid")] 

    /// <summary>
    /// Malzeme Kodları
    /// </summary>
    public  partial class MaterialCodeGrid : TTObject
    {
        public class MaterialCodeGridList : TTObjectCollection<MaterialCodeGrid> { }
                    
        public class ChildMaterialCodeGridCollection : TTObject.TTChildObjectCollection<MaterialCodeGrid>
        {
            public ChildMaterialCodeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialCodeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSetMaterialByMaterialCode_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string MaterialCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALCODEGRID"].AllPropertyDefs["MATERIALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSetMaterialByMaterialCode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSetMaterialByMaterialCode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSetMaterialByMaterialCode_Class() : base() { }
        }

        public static BindingList<MaterialCodeGrid.GetSetMaterialByMaterialCode_Class> GetSetMaterialByMaterialCode(string MATERIALCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALCODEGRID"].QueryDefs["GetSetMaterialByMaterialCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALCODE", MATERIALCODE);

            return TTReportNqlObject.QueryObjects<MaterialCodeGrid.GetSetMaterialByMaterialCode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialCodeGrid.GetSetMaterialByMaterialCode_Class> GetSetMaterialByMaterialCode(TTObjectContext objectContext, string MATERIALCODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALCODEGRID"].QueryDefs["GetSetMaterialByMaterialCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALCODE", MATERIALCODE);

            return TTReportNqlObject.QueryObjects<MaterialCodeGrid.GetSetMaterialByMaterialCode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Malzeme Kodu
    /// </summary>
        public string MaterialCode
        {
            get { return (string)this["MATERIALCODE"]; }
            set { this["MATERIALCODE"] = value; }
        }

        protected MaterialCodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialCodeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialCodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialCodeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialCodeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALCODEGRID", dataRow) { }
        protected MaterialCodeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALCODEGRID", dataRow, isImported) { }
        public MaterialCodeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialCodeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialCodeGrid() : base() { }

    }
}