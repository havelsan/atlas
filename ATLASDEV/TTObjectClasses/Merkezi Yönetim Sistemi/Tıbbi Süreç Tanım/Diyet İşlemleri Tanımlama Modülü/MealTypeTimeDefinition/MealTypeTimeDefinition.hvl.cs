
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MealTypeTimeDefinition")] 

    /// <summary>
    /// Diyet Öğün Zamanları
    /// </summary>
    public  partial class MealTypeTimeDefinition : TerminologyManagerDef
    {
        public class MealTypeTimeDefinitionList : TTObjectCollection<MealTypeTimeDefinition> { }
                    
        public class ChildMealTypeTimeDefinitionCollection : TTObject.TTChildObjectCollection<MealTypeTimeDefinition>
        {
            public ChildMealTypeTimeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMealTypeTimeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMealTypeTimeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? Breakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].AllPropertyDefs["BREAKFAST"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Lunch
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LUNCH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].AllPropertyDefs["LUNCH"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Dinner
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DINNER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].AllPropertyDefs["DINNER"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? NightBreakfast
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NIGHTBREAKFAST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].AllPropertyDefs["NIGHTBREAKFAST"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Snack1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].AllPropertyDefs["SNACK1"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Snack2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].AllPropertyDefs["SNACK2"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Snack3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNACK3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].AllPropertyDefs["SNACK3"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetMealTypeTimeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMealTypeTimeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMealTypeTimeDefinitionList_Class() : base() { }
        }

        public static BindingList<MealTypeTimeDefinition.GetMealTypeTimeDefinitionList_Class> GetMealTypeTimeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].QueryDefs["GetMealTypeTimeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MealTypeTimeDefinition.GetMealTypeTimeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MealTypeTimeDefinition.GetMealTypeTimeDefinitionList_Class> GetMealTypeTimeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEALTYPETIMEDEFINITION"].QueryDefs["GetMealTypeTimeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MealTypeTimeDefinition.GetMealTypeTimeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public DateTime? Lunch
        {
            get { return (DateTime?)this["LUNCH"]; }
            set { this["LUNCH"] = value; }
        }

        public DateTime? Breakfast
        {
            get { return (DateTime?)this["BREAKFAST"]; }
            set { this["BREAKFAST"] = value; }
        }

        public DateTime? Dinner
        {
            get { return (DateTime?)this["DINNER"]; }
            set { this["DINNER"] = value; }
        }

        public DateTime? NightBreakfast
        {
            get { return (DateTime?)this["NIGHTBREAKFAST"]; }
            set { this["NIGHTBREAKFAST"] = value; }
        }

        public DateTime? Snack1
        {
            get { return (DateTime?)this["SNACK1"]; }
            set { this["SNACK1"] = value; }
        }

        public DateTime? Snack2
        {
            get { return (DateTime?)this["SNACK2"]; }
            set { this["SNACK2"] = value; }
        }

        public DateTime? Snack3
        {
            get { return (DateTime?)this["SNACK3"]; }
            set { this["SNACK3"] = value; }
        }

        protected MealTypeTimeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MealTypeTimeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MealTypeTimeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MealTypeTimeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MealTypeTimeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEALTYPETIMEDEFINITION", dataRow) { }
        protected MealTypeTimeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEALTYPETIMEDEFINITION", dataRow, isImported) { }
        public MealTypeTimeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MealTypeTimeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MealTypeTimeDefinition() : base() { }

    }
}