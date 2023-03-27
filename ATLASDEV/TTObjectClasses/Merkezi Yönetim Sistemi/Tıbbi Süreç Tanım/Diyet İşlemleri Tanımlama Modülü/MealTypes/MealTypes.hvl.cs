
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MealTypes")] 

    /// <summary>
    /// Öğün Tanımları
    /// </summary>
    public  partial class MealTypes : TTObject
    {
        public class MealTypesList : TTObjectCollection<MealTypes> { }
                    
        public class ChildMealTypesCollection : TTObject.TTChildObjectCollection<MealTypes>
        {
            public ChildMealTypesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMealTypesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MealTypes> GetAllMealTypes(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEALTYPES"].QueryDefs["GetAllMealTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MealTypes>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Sabah
    /// </summary>
        public bool? Breakfast
        {
            get { return (bool?)this["BREAKFAST"]; }
            set { this["BREAKFAST"] = value; }
        }

    /// <summary>
    /// Akşam
    /// </summary>
        public bool? Dinner
        {
            get { return (bool?)this["DINNER"]; }
            set { this["DINNER"] = value; }
        }

    /// <summary>
    /// Öğle
    /// </summary>
        public bool? Lunch
        {
            get { return (bool?)this["LUNCH"]; }
            set { this["LUNCH"] = value; }
        }

    /// <summary>
    /// Gece Kahvaltısı
    /// </summary>
        public bool? NightBreakfast
        {
            get { return (bool?)this["NIGHTBREAKFAST"]; }
            set { this["NIGHTBREAKFAST"] = value; }
        }

    /// <summary>
    /// Ara 1
    /// </summary>
        public bool? Snack1
        {
            get { return (bool?)this["SNACK1"]; }
            set { this["SNACK1"] = value; }
        }

    /// <summary>
    /// Ara 2
    /// </summary>
        public bool? Snack2
        {
            get { return (bool?)this["SNACK2"]; }
            set { this["SNACK2"] = value; }
        }

    /// <summary>
    /// Ara 3
    /// </summary>
        public bool? Snack3
        {
            get { return (bool?)this["SNACK3"]; }
            set { this["SNACK3"] = value; }
        }

        protected MealTypes(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MealTypes(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MealTypes(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MealTypes(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MealTypes(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEALTYPES", dataRow) { }
        protected MealTypes(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEALTYPES", dataRow, isImported) { }
        public MealTypes(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MealTypes(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MealTypes() : base() { }

    }
}