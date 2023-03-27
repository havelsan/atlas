
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseNutritionDiet")] 

    /// <summary>
    /// Ana Beslenme ve Diyet Sekmesi
    /// </summary>
    public  partial class BaseNutritionDiet : SubActionProcedure
    {
        public class BaseNutritionDietList : TTObjectCollection<BaseNutritionDiet> { }
                    
        public class ChildBaseNutritionDietCollection : TTObject.TTChildObjectCollection<BaseNutritionDiet>
        {
            public ChildBaseNutritionDietCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseNutritionDietCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

    /// <summary>
    /// Beslenme
    /// </summary>
        public string DietDescription
        {
            get { return (string)this["DIETDESCRIPTION"]; }
            set { this["DIETDESCRIPTION"] = value; }
        }

        public NutritionDietAction NutritionDietAction
        {
            get { return (NutritionDietAction)((ITTObject)this).GetParent("NUTRITIONDIETACTION"); }
            set { this["NUTRITIONDIETACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseNutritionDiet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseNutritionDiet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseNutritionDiet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseNutritionDiet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseNutritionDiet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASENUTRITIONDIET", dataRow) { }
        protected BaseNutritionDiet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASENUTRITIONDIET", dataRow, isImported) { }
        public BaseNutritionDiet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseNutritionDiet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseNutritionDiet() : base() { }

    }
}