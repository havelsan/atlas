
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseExaminationDetailOut")] 

    public  partial class PurchaseExaminationDetailOut : StockActionDetailOut
    {
        public class PurchaseExaminationDetailOutList : TTObjectCollection<PurchaseExaminationDetailOut> { }
                    
        public class ChildPurchaseExaminationDetailOutCollection : TTObject.TTChildObjectCollection<PurchaseExaminationDetailOut>
        {
            public ChildPurchaseExaminationDetailOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseExaminationDetailOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PurchaseExamination PurchaseExamination
        {
            get 
            {   
                if (StockAction is PurchaseExamination)
                    return (PurchaseExamination)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PurchaseExaminationDetailOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseExaminationDetailOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseExaminationDetailOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseExaminationDetailOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseExaminationDetailOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEEXAMINATIONDETAILOUT", dataRow) { }
        protected PurchaseExaminationDetailOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEEXAMINATIONDETAILOUT", dataRow, isImported) { }
        public PurchaseExaminationDetailOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseExaminationDetailOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseExaminationDetailOut() : base() { }

    }
}