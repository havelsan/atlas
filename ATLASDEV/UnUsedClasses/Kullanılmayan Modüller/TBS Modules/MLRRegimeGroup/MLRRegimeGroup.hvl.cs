
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRRegimeGroup")] 

    /// <summary>
    /// DE_Rejim Grubu
    /// </summary>
    public  partial class MLRRegimeGroup : TTObject
    {
        public class MLRRegimeGroupList : TTObjectCollection<MLRRegimeGroup> { }
                    
        public class ChildMLRRegimeGroupCollection : TTObject.TTChildObjectCollection<MLRRegimeGroup>
        {
            public ChildMLRRegimeGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRRegimeGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
            _Meal = new MLRMeal.ChildMLRMealCollection(this, new Guid("dd5da89a-2cdd-461c-ae06-0cfae8db36c5"));
            ((ITTChildObjectCollection)_Meal).GetChildren();
        }

        protected MLRMeal.ChildMLRMealCollection _Meal = null;
    /// <summary>
    /// Child collection for Rejim Grubu
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

        protected MLRRegimeGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRRegimeGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRRegimeGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRRegimeGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRRegimeGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRREGIMEGROUP", dataRow) { }
        protected MLRRegimeGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRREGIMEGROUP", dataRow, isImported) { }
        public MLRRegimeGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRRegimeGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRRegimeGroup() : base() { }

    }
}