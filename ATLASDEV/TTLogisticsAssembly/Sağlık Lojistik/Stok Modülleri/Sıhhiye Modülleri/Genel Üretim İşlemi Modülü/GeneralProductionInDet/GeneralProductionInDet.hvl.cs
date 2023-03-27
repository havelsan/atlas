
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralProductionInDet")] 

    public  partial class GeneralProductionInDet : StockActionDetailIn
    {
        public class GeneralProductionInDetList : TTObjectCollection<GeneralProductionInDet> { }
                    
        public class ChildGeneralProductionInDetCollection : TTObject.TTChildObjectCollection<GeneralProductionInDet>
        {
            public ChildGeneralProductionInDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralProductionInDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected GeneralProductionInDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralProductionInDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralProductionInDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralProductionInDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralProductionInDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALPRODUCTIONINDET", dataRow) { }
        protected GeneralProductionInDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALPRODUCTIONINDET", dataRow, isImported) { }
        public GeneralProductionInDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralProductionInDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralProductionInDet() : base() { }

    }
}