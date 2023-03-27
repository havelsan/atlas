
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MealUnit")] 

    /// <summary>
    /// Yemek Birimi
    /// </summary>
    public  partial class MealUnit : TTDefinitionSet
    {
        public class MealUnitList : TTObjectCollection<MealUnit> { }
                    
        public class ChildMealUnitCollection : TTObject.TTChildObjectCollection<MealUnit>
        {
            public ChildMealUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMealUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        virtual protected void CreateMealCollection()
        {
            _Meal = new MLRMeal.ChildMLRMealCollection(this, new Guid("033aab82-2336-42e8-9c36-d7fa4258829e"));
            ((ITTChildObjectCollection)_Meal).GetChildren();
        }

        protected MLRMeal.ChildMLRMealCollection _Meal = null;
    /// <summary>
    /// Child collection for Birimi
    /// </summary>
        public MLRMeal.ChildMLRMealCollection Meal
        {
            get
            {
                if (_Meal == null)
                    CreateMealCollection();
                return _Meal;
            }
        }

        protected MealUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MealUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MealUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MealUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MealUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEALUNIT", dataRow) { }
        protected MealUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEALUNIT", dataRow, isImported) { }
        public MealUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MealUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MealUnit() : base() { }

    }
}