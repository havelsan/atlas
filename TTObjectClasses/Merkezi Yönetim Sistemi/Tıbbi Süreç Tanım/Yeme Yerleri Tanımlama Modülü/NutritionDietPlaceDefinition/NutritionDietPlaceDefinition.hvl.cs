
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NutritionDietPlaceDefinition")] 

    /// <summary>
    /// Yeme Yerleri Tanımları
    /// </summary>
    public  partial class NutritionDietPlaceDefinition : TTDefinitionSet
    {
        public class NutritionDietPlaceDefinitionList : TTObjectCollection<NutritionDietPlaceDefinition> { }
                    
        public class ChildNutritionDietPlaceDefinitionCollection : TTObject.TTChildObjectCollection<NutritionDietPlaceDefinition>
        {
            public ChildNutritionDietPlaceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNutritionDietPlaceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNutritionDietPlaceDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Place
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUTRITIONDIETPLACEDEFINITION"].AllPropertyDefs["PLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNutritionDietPlaceDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNutritionDietPlaceDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNutritionDietPlaceDefinition_Class() : base() { }
        }

        public static BindingList<NutritionDietPlaceDefinition.GetNutritionDietPlaceDefinition_Class> GetNutritionDietPlaceDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUTRITIONDIETPLACEDEFINITION"].QueryDefs["GetNutritionDietPlaceDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NutritionDietPlaceDefinition.GetNutritionDietPlaceDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NutritionDietPlaceDefinition.GetNutritionDietPlaceDefinition_Class> GetNutritionDietPlaceDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUTRITIONDIETPLACEDEFINITION"].QueryDefs["GetNutritionDietPlaceDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NutritionDietPlaceDefinition.GetNutritionDietPlaceDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Yeme Yeri
    /// </summary>
        public string Place
        {
            get { return (string)this["PLACE"]; }
            set { this["PLACE"] = value; }
        }

        public string Place_Shadow
        {
            get { return (string)this["PLACE_SHADOW"]; }
        }

        protected NutritionDietPlaceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NutritionDietPlaceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NutritionDietPlaceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NutritionDietPlaceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NutritionDietPlaceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUTRITIONDIETPLACEDEFINITION", dataRow) { }
        protected NutritionDietPlaceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUTRITIONDIETPLACEDEFINITION", dataRow, isImported) { }
        protected NutritionDietPlaceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NutritionDietPlaceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NutritionDietPlaceDefinition() : base() { }

    }
}