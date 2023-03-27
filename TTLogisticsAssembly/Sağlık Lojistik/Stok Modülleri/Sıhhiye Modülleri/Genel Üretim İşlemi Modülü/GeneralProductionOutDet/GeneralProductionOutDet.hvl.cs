
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralProductionOutDet")] 

    public  partial class GeneralProductionOutDet : StockActionDetailOut
    {
        public class GeneralProductionOutDetList : TTObjectCollection<GeneralProductionOutDet> { }
                    
        public class ChildGeneralProductionOutDetCollection : TTObject.TTChildObjectCollection<GeneralProductionOutDet>
        {
            public ChildGeneralProductionOutDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralProductionOutDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public GeneralProductionAction GeneralProductionAction
        {
            get 
            {   
                if (StockAction is GeneralProductionAction)
                    return (GeneralProductionAction)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected GeneralProductionOutDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralProductionOutDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralProductionOutDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralProductionOutDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralProductionOutDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALPRODUCTIONOUTDET", dataRow) { }
        protected GeneralProductionOutDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALPRODUCTIONOUTDET", dataRow, isImported) { }
        public GeneralProductionOutDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralProductionOutDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralProductionOutDet() : base() { }

    }
}