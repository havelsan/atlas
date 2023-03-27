
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRRegimeMealGroup")] 

    public  partial class MLRRegimeMealGroup : TTObject
    {
        public class MLRRegimeMealGroupList : TTObjectCollection<MLRRegimeMealGroup> { }
                    
        public class ChildMLRRegimeMealGroupCollection : TTObject.TTChildObjectCollection<MLRRegimeMealGroup>
        {
            public ChildMLRRegimeMealGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRRegimeMealGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Öğün
    /// </summary>
        public RepastEnum? Repast
        {
            get { return (RepastEnum?)(int?)this["REPAST"]; }
            set { this["REPAST"] = value; }
        }

    /// <summary>
    /// Rasyon Rejim Grubu
    /// </summary>
        public MLRRationRegimeGroup RationRegimeGroup
        {
            get { return (MLRRationRegimeGroup)((ITTObject)this).GetParent("RATIONREGIMEGROUP"); }
            set { this["RATIONREGIMEGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yemek Grubu
    /// </summary>
        public MLRMealGroup MealGroup
        {
            get { return (MLRMealGroup)((ITTObject)this).GetParent("MEALGROUP"); }
            set { this["MEALGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRegimeMealsCollection()
        {
            _RegimeMeals = new MLRRegimeMeal.ChildMLRRegimeMealCollection(this, new Guid("9c9970c4-7214-4169-97ee-2b6ef6ffa158"));
            ((ITTChildObjectCollection)_RegimeMeals).GetChildren();
        }

        protected MLRRegimeMeal.ChildMLRRegimeMealCollection _RegimeMeals = null;
    /// <summary>
    /// Child collection for Rejim Yemek Grubu
    /// </summary>
        public MLRRegimeMeal.ChildMLRRegimeMealCollection RegimeMeals
        {
            get
            {
                if (_RegimeMeals == null)
                    CreateRegimeMealsCollection();
                return _RegimeMeals;
            }
        }

        protected MLRRegimeMealGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRRegimeMealGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRRegimeMealGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRRegimeMealGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRRegimeMealGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRREGIMEMEALGROUP", dataRow) { }
        protected MLRRegimeMealGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRREGIMEMEALGROUP", dataRow, isImported) { }
        public MLRRegimeMealGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRRegimeMealGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRRegimeMealGroup() : base() { }

    }
}