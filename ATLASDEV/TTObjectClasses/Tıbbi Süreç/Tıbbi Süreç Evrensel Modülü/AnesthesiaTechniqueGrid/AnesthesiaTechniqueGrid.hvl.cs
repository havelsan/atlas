
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaTechniqueGrid")] 

    /// <summary>
    /// Anstezi Konsültasyonunda Anestezi Tekniklerini Taşıyan Nesne
    /// </summary>
    public  partial class AnesthesiaTechniqueGrid : TTObject
    {
        public class AnesthesiaTechniqueGridList : TTObjectCollection<AnesthesiaTechniqueGrid> { }
                    
        public class ChildAnesthesiaTechniqueGridCollection : TTObject.TTChildObjectCollection<AnesthesiaTechniqueGrid>
        {
            public ChildAnesthesiaTechniqueGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaTechniqueGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Anstezi Tekniği
    /// </summary>
        public AnesthesiaTechniqueEnum? AnesthesiaTechnique
        {
            get { return (AnesthesiaTechniqueEnum?)(int?)this["ANESTHESIATECHNIQUE"]; }
            set { this["ANESTHESIATECHNIQUE"] = value; }
        }

        protected AnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaTechniqueGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIATECHNIQUEGRID", dataRow) { }
        protected AnesthesiaTechniqueGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIATECHNIQUEGRID", dataRow, isImported) { }
        public AnesthesiaTechniqueGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaTechniqueGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaTechniqueGrid() : base() { }

    }
}