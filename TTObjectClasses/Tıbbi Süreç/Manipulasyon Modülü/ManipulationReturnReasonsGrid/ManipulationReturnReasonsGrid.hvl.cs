
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManipulationReturnReasonsGrid")] 

    /// <summary>
    /// Manipulasyon İade Nedenleri Gridi
    /// </summary>
    public  partial class ManipulationReturnReasonsGrid : TTObject
    {
        public class ManipulationReturnReasonsGridList : TTObjectCollection<ManipulationReturnReasonsGrid> { }
                    
        public class ChildManipulationReturnReasonsGridCollection : TTObject.TTChildObjectCollection<ManipulationReturnReasonsGrid>
        {
            public ChildManipulationReturnReasonsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManipulationReturnReasonsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İade Nedeni
    /// </summary>
        public string ReturnReason
        {
            get { return (string)this["RETURNREASON"]; }
            set { this["RETURNREASON"] = value; }
        }

    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ReturnDate
        {
            get { return (DateTime?)this["RETURNDATE"]; }
            set { this["RETURNDATE"] = value; }
        }

    /// <summary>
    /// Manipulation_ManipulationReturnReasonsGrid
    /// </summary>
        public Manipulation Manipulation
        {
            get { return (Manipulation)((ITTObject)this).GetParent("MANIPULATION"); }
            set { this["MANIPULATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ManipulationReturnReasonsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManipulationReturnReasonsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManipulationReturnReasonsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManipulationReturnReasonsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManipulationReturnReasonsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANIPULATIONRETURNREASONSGRID", dataRow) { }
        protected ManipulationReturnReasonsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANIPULATIONRETURNREASONSGRID", dataRow, isImported) { }
        public ManipulationReturnReasonsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManipulationReturnReasonsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManipulationReturnReasonsGrid() : base() { }

    }
}