
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PTSActionDetail")] 

    public  partial class PTSActionDetail : StockActionDetailIn
    {
        public class PTSActionDetailList : TTObjectCollection<PTSActionDetail> { }
                    
        public class ChildPTSActionDetailCollection : TTObject.TTChildObjectCollection<PTSActionDetail>
        {
            public ChildPTSActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPTSActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PTSAction PTSAction
        {
            get 
            {   
                if (StockAction is PTSAction)
                    return (PTSAction)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PTSActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PTSActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PTSActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PTSActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PTSActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PTSACTIONDETAIL", dataRow) { }
        protected PTSActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PTSACTIONDETAIL", dataRow, isImported) { }
        public PTSActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PTSActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PTSActionDetail() : base() { }

    }
}