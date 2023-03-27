
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UsedMaterialWorkStep")] 

    /// <summary>
    /// Yardımcı Atölyelerde Kullanılan Malzemeler
    /// </summary>
    public  partial class UsedMaterialWorkStep : TTObject
    {
        public class UsedMaterialWorkStepList : TTObjectCollection<UsedMaterialWorkStep> { }
                    
        public class ChildUsedMaterialWorkStepCollection : TTObject.TTChildObjectCollection<UsedMaterialWorkStep>
        {
            public ChildUsedMaterialWorkStepCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUsedMaterialWorkStepCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UsedMaterialWorkStep(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UsedMaterialWorkStep(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UsedMaterialWorkStep(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UsedMaterialWorkStep(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UsedMaterialWorkStep(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "USEDMATERIALWORKSTEP", dataRow) { }
        protected UsedMaterialWorkStep(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "USEDMATERIALWORKSTEP", dataRow, isImported) { }
        public UsedMaterialWorkStep(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UsedMaterialWorkStep(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UsedMaterialWorkStep() : base() { }

    }
}