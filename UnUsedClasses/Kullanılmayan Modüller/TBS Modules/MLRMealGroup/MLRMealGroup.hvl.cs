
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRMealGroup")] 

    /// <summary>
    /// DLR006_Yemek Grubu
    /// </summary>
    public  partial class MLRMealGroup : TTObject
    {
        public class MLRMealGroupList : TTObjectCollection<MLRMealGroup> { }
                    
        public class ChildMLRMealGroupCollection : TTObject.TTChildObjectCollection<MLRMealGroup>
        {
            public ChildMLRMealGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRMealGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateMealCollection()
        {
            _Meal = new MLRMeal.ChildMLRMealCollection(this, new Guid("1abe3f74-f945-44b5-8551-43c91a0b55af"));
            ((ITTChildObjectCollection)_Meal).GetChildren();
        }

        protected MLRMeal.ChildMLRMealCollection _Meal = null;
    /// <summary>
    /// Child collection for Yemek Grubu
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

        protected MLRMealGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRMealGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRMealGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRMealGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRMealGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRMEALGROUP", dataRow) { }
        protected MLRMealGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRMEALGROUP", dataRow, isImported) { }
        public MLRMealGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRMealGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRMealGroup() : base() { }

    }
}