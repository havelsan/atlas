
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ARD_XXXXXXDrugIn")] 

    public  partial class ARD_XXXXXXDrugIn : AnnualRequirementDetailInList
    {
        public class ARD_XXXXXXDrugInList : TTObjectCollection<ARD_XXXXXXDrugIn> { }
                    
        public class ChildARD_XXXXXXDrugInCollection : TTObject.TTChildObjectCollection<ARD_XXXXXXDrugIn>
        {
            public ChildARD_XXXXXXDrugInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildARD_XXXXXXDrugInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d9fc1811-1f02-4d91-905e-96cb589bd920"); } }
            public static Guid New { get { return new Guid("b598888e-7eef-48fb-9f95-495cae2a77ca"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("81b0c9a7-849c-4b52-b4b8-acd19a2615c8"); } }
        }

    /// <summary>
    /// Formüle Esas Ambalaj Şekli
    /// </summary>
        public Guid? FormulaPurchaseItemUnitType
        {
            get { return (Guid?)this["FORMULAPURCHASEITEMUNITTYPE"]; }
            set { this["FORMULAPURCHASEITEMUNITTYPE"] = value; }
        }

        protected ARD_XXXXXXDrugIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ARD_XXXXXXDrugIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ARD_XXXXXXDrugIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ARD_XXXXXXDrugIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ARD_XXXXXXDrugIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARD_XXXXXXDRUGIN", dataRow) { }
        protected ARD_XXXXXXDrugIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARD_XXXXXXDRUGIN", dataRow, isImported) { }
        public ARD_XXXXXXDrugIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ARD_XXXXXXDrugIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ARD_XXXXXXDrugIn() : base() { }

    }
}