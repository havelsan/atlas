
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SubStoreConsumptionDetail")] 

    /// <summary>
    /// Depodan Sarf İşleminde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class SubStoreConsumptionDetail : StockActionDetailOut
    {
        public class SubStoreConsumptionDetailList : TTObjectCollection<SubStoreConsumptionDetail> { }
                    
        public class ChildSubStoreConsumptionDetailCollection : TTObject.TTChildObjectCollection<SubStoreConsumptionDetail>
        {
            public ChildSubStoreConsumptionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSubStoreConsumptionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public SubStoreConsumptionAction SubStoreConsumptionAction
        {
            get 
            {   
                if (StockAction is SubStoreConsumptionAction)
                    return (SubStoreConsumptionAction)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected SubStoreConsumptionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SubStoreConsumptionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SubStoreConsumptionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SubStoreConsumptionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SubStoreConsumptionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUBSTORECONSUMPTIONDETAIL", dataRow) { }
        protected SubStoreConsumptionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUBSTORECONSUMPTIONDETAIL", dataRow, isImported) { }
        public SubStoreConsumptionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SubStoreConsumptionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SubStoreConsumptionDetail() : base() { }

    }
}