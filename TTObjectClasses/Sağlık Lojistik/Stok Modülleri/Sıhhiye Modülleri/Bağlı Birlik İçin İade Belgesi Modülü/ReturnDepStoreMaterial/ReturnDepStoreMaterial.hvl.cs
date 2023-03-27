
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReturnDepStoreMaterial")] 

    public  partial class ReturnDepStoreMaterial : StockActionDetailOut, IReturnDepStoreMaterial
    {
        public class ReturnDepStoreMaterialList : TTObjectCollection<ReturnDepStoreMaterial> { }
                    
        public class ChildReturnDepStoreMaterialCollection : TTObject.TTChildObjectCollection<ReturnDepStoreMaterial>
        {
            public ChildReturnDepStoreMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReturnDepStoreMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İade Miktarı
    /// </summary>
        public Currency? RequireAmount
        {
            get { return (Currency?)this["REQUIREAMOUNT"]; }
            set { this["REQUIREAMOUNT"] = value; }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public ReturnDepStore ReturnDepStore
        {
            get 
            {   
                if (StockAction is ReturnDepStore)
                    return (ReturnDepStore)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected ReturnDepStoreMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReturnDepStoreMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReturnDepStoreMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReturnDepStoreMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReturnDepStoreMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RETURNDEPSTOREMATERIAL", dataRow) { }
        protected ReturnDepStoreMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RETURNDEPSTOREMATERIAL", dataRow, isImported) { }
        public ReturnDepStoreMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReturnDepStoreMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReturnDepStoreMaterial() : base() { }

    }
}