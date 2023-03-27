
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MLRRegimeMeal")] 

    public  partial class MLRRegimeMeal : TTObject
    {
        public class MLRRegimeMealList : TTObjectCollection<MLRRegimeMeal> { }
                    
        public class ChildMLRRegimeMealCollection : TTObject.TTChildObjectCollection<MLRRegimeMeal>
        {
            public ChildMLRRegimeMealCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMLRRegimeMealCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Rejim Yemek Grubu
    /// </summary>
        public MLRRegimeMealGroup RegimeMealGroup
        {
            get { return (MLRRegimeMealGroup)((ITTObject)this).GetParent("REGIMEMEALGROUP"); }
            set { this["REGIMEMEALGROUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yemek
    /// </summary>
        public MLRMeal Meal
        {
            get { return (MLRMeal)((ITTObject)this).GetParent("MEAL"); }
            set { this["MEAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MLRRegimeMeal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MLRRegimeMeal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MLRRegimeMeal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MLRRegimeMeal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MLRRegimeMeal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MLRREGIMEMEAL", dataRow) { }
        protected MLRRegimeMeal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MLRREGIMEMEAL", dataRow, isImported) { }
        public MLRRegimeMeal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MLRRegimeMeal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MLRRegimeMeal() : base() { }

    }
}