
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPreparationUsedDrug")] 

    /// <summary>
    /// Kullanılan İlaçlar Sekmesi
    /// </summary>
    public  partial class MagistralPreparationUsedDrug : TTObject
    {
        public class MagistralPreparationUsedDrugList : TTObjectCollection<MagistralPreparationUsedDrug> { }
                    
        public class ChildMagistralPreparationUsedDrugCollection : TTObject.TTChildObjectCollection<MagistralPreparationUsedDrug>
        {
            public ChildMagistralPreparationUsedDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPreparationUsedDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public DrugDefinition DrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("DRUGDEFINITION"); }
            set { this["DRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MagistralPreparationAction MagistralPreparationAction
        {
            get { return (MagistralPreparationAction)((ITTObject)this).GetParent("MAGISTRALPREPARATIONACTION"); }
            set { this["MAGISTRALPREPARATIONACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralPreparationUsedDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPreparationUsedDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPreparationUsedDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPreparationUsedDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPreparationUsedDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPREPARATIONUSEDDRUG", dataRow) { }
        protected MagistralPreparationUsedDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPREPARATIONUSEDDRUG", dataRow, isImported) { }
        public MagistralPreparationUsedDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPreparationUsedDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPreparationUsedDrug() : base() { }

    }
}