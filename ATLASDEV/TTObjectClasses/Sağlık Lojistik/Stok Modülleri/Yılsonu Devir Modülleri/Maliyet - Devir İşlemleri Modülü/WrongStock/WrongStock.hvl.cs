
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WrongStock")] 

    public  partial class WrongStock : TTObject
    {
        public class WrongStockList : TTObjectCollection<WrongStock> { }
                    
        public class ChildWrongStockCollection : TTObject.TTChildObjectCollection<WrongStock>
        {
            public ChildWrongStockCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWrongStockCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Olması Gereken Açılış Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public CheckStockCensusAction CheckStockCensusAction
        {
            get { return (CheckStockCensusAction)((ITTObject)this).GetParent("CHECKSTOCKCENSUSACTION"); }
            set { this["CHECKSTOCKCENSUSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected WrongStock(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WrongStock(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WrongStock(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WrongStock(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WrongStock(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WRONGSTOCK", dataRow) { }
        protected WrongStock(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WRONGSTOCK", dataRow, isImported) { }
        public WrongStock(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WrongStock(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WrongStock() : base() { }

    }
}