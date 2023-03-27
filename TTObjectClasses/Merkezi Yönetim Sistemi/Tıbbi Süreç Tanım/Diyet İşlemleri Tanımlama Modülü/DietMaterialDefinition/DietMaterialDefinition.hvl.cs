
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DietMaterialDefinition")] 

    /// <summary>
    /// Diyet Malzeme Tanımları
    /// </summary>
    public  partial class DietMaterialDefinition : TerminologyManagerDef
    {
        public class DietMaterialDefinitionList : TTObjectCollection<DietMaterialDefinition> { }
                    
        public class ChildDietMaterialDefinitionCollection : TTObject.TTChildObjectCollection<DietMaterialDefinition>
        {
            public ChildDietMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDietMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDietMaterialDefinition_Class : TTReportNqlObject 
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

            public string MaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETMATERIALDEFINITION"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Vitamins
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VITAMINS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETMATERIALDEFINITION"].AllPropertyDefs["VITAMINS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDietMaterialDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDietMaterialDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDietMaterialDefinition_Class() : base() { }
        }

        public static BindingList<DietMaterialDefinition.GetDietMaterialDefinition_Class> GetDietMaterialDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETMATERIALDEFINITION"].QueryDefs["GetDietMaterialDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietMaterialDefinition.GetDietMaterialDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietMaterialDefinition.GetDietMaterialDefinition_Class> GetDietMaterialDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETMATERIALDEFINITION"].QueryDefs["GetDietMaterialDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DietMaterialDefinition.GetDietMaterialDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DietMaterialDefinition> GetDietMaterialDefinitions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIETMATERIALDEFINITION"].QueryDefs["GetDietMaterialDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DietMaterialDefinition>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Malzeme Adı
    /// </summary>
        public string MaterialName
        {
            get { return (string)this["MATERIALNAME"]; }
            set { this["MATERIALNAME"] = value; }
        }

    /// <summary>
    /// İçerdiği Vitaminler
    /// </summary>
        public string Vitamins
        {
            get { return (string)this["VITAMINS"]; }
            set { this["VITAMINS"] = value; }
        }

        virtual protected void CreatevCollection()
        {
            _v = new DietMaterialGrid.ChildDietMaterialGridCollection(this, new Guid("608ca074-a509-40f2-9c06-a6b432c8f70b"));
            ((ITTChildObjectCollection)_v).GetChildren();
        }

        protected DietMaterialGrid.ChildDietMaterialGridCollection _v = null;
        public DietMaterialGrid.ChildDietMaterialGridCollection v
        {
            get
            {
                if (_v == null)
                    CreatevCollection();
                return _v;
            }
        }

        protected DietMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DietMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DietMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DietMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DietMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIETMATERIALDEFINITION", dataRow) { }
        protected DietMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIETMATERIALDEFINITION", dataRow, isImported) { }
        public DietMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DietMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DietMaterialDefinition() : base() { }

    }
}