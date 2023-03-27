
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ARD_XXXXXXDrugOut")] 

    public  partial class ARD_XXXXXXDrugOut : AnnualRequirementDetailOutOfList
    {
        public class ARD_XXXXXXDrugOutList : TTObjectCollection<ARD_XXXXXXDrugOut> { }
                    
        public class ChildARD_XXXXXXDrugOutCollection : TTObject.TTChildObjectCollection<ARD_XXXXXXDrugOut>
        {
            public ChildARD_XXXXXXDrugOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildARD_XXXXXXDrugOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected ARD_XXXXXXDrugOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ARD_XXXXXXDrugOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ARD_XXXXXXDrugOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ARD_XXXXXXDrugOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ARD_XXXXXXDrugOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARD_XXXXXXDRUGOUT", dataRow) { }
        protected ARD_XXXXXXDrugOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARD_XXXXXXDRUGOUT", dataRow, isImported) { }
        public ARD_XXXXXXDrugOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ARD_XXXXXXDrugOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ARD_XXXXXXDrugOut() : base() { }

    }
}