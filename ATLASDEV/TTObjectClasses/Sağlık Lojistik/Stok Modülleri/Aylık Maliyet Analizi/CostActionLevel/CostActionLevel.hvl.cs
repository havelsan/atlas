
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CostActionLevel")] 

    /// <summary>
    /// Aylık  Devir Detayları Durumları Sekmesi
    /// </summary>
    public  partial class CostActionLevel : TTObject
    {
        public class CostActionLevelList : TTObjectCollection<CostActionLevel> { }
                    
        public class ChildCostActionLevelCollection : TTObject.TTChildObjectCollection<CostActionLevel>
        {
            public ChildCostActionLevelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCostActionLevelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mevcut
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public CostActionMaterial CostActionMaterial
        {
            get { return (CostActionMaterial)((ITTObject)this).GetParent("COSTACTIONMATERIAL"); }
            set { this["COSTACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockLevelType StockLevelType
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("STOCKLEVELTYPE"); }
            set { this["STOCKLEVELTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CostActionLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CostActionLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CostActionLevel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CostActionLevel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CostActionLevel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COSTACTIONLEVEL", dataRow) { }
        protected CostActionLevel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COSTACTIONLEVEL", dataRow, isImported) { }
        public CostActionLevel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CostActionLevel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CostActionLevel() : base() { }

    }
}