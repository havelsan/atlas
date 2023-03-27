
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresCensusFixedMaterialOut")] 

    public  partial class PresCensusFixedMaterialOut : CensusFixedMaterialOut
    {
        public class PresCensusFixedMaterialOutList : TTObjectCollection<PresCensusFixedMaterialOut> { }
                    
        public class ChildPresCensusFixedMaterialOutCollection : TTObject.TTChildObjectCollection<PresCensusFixedMaterialOut>
        {
            public ChildPresCensusFixedMaterialOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresCensusFixedMaterialOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected PresCensusFixedMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresCensusFixedMaterialOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresCensusFixedMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresCensusFixedMaterialOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresCensusFixedMaterialOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCENSUSFIXEDMATERIALOUT", dataRow) { }
        protected PresCensusFixedMaterialOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCENSUSFIXEDMATERIALOUT", dataRow, isImported) { }
        public PresCensusFixedMaterialOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresCensusFixedMaterialOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresCensusFixedMaterialOut() : base() { }

    }
}