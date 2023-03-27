
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockPrescriptionOutMat")] 

    public  partial class StockPrescriptionOutMat : StockActionDetailOut
    {
        public class StockPrescriptionOutMatList : TTObjectCollection<StockPrescriptionOutMat> { }
                    
        public class ChildStockPrescriptionOutMatCollection : TTObject.TTChildObjectCollection<StockPrescriptionOutMat>
        {
            public ChildStockPrescriptionOutMatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockPrescriptionOutMatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public StockPrescriptionOut StockPrescriptionOut
        {
            get 
            {   
                if (StockAction is StockPrescriptionOut)
                    return (StockPrescriptionOut)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected StockPrescriptionOutMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockPrescriptionOutMat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockPrescriptionOutMat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockPrescriptionOutMat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockPrescriptionOutMat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKPRESCRIPTIONOUTMAT", dataRow) { }
        protected StockPrescriptionOutMat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKPRESCRIPTIONOUTMAT", dataRow, isImported) { }
        public StockPrescriptionOutMat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockPrescriptionOutMat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockPrescriptionOutMat() : base() { }

    }
}