
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresCensusFixedMaterialIn")] 

    public  partial class PresCensusFixedMaterialIn : CensusFixedMaterialIn
    {
        public class PresCensusFixedMaterialInList : TTObjectCollection<PresCensusFixedMaterialIn> { }
                    
        public class ChildPresCensusFixedMaterialInCollection : TTObject.TTChildObjectCollection<PresCensusFixedMaterialIn>
        {
            public ChildPresCensusFixedMaterialInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresCensusFixedMaterialInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresCensusFixed PresCensusFixed
        {
            get 
            {   
                if (StockAction is PresCensusFixed)
                    return (PresCensusFixed)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected PresCensusFixedMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresCensusFixedMaterialIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresCensusFixedMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresCensusFixedMaterialIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresCensusFixedMaterialIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCENSUSFIXEDMATERIALIN", dataRow) { }
        protected PresCensusFixedMaterialIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCENSUSFIXEDMATERIALIN", dataRow, isImported) { }
        public PresCensusFixedMaterialIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresCensusFixedMaterialIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresCensusFixedMaterialIn() : base() { }

    }
}