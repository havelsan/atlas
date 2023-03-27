
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaAndReanimationSuggestedTechniqueGrid")] 

    /// <summary>
    /// Anestezi ve Reanimasyon İşleminde Önerilen Anestezi Tekniklerini Taşıyan Nesne
    /// </summary>
    public  partial class AnesthesiaAndReanimationSuggestedTechniqueGrid : AnesthesiaTechniqueGrid
    {
        public class AnesthesiaAndReanimationSuggestedTechniqueGridList : TTObjectCollection<AnesthesiaAndReanimationSuggestedTechniqueGrid> { }
                    
        public class ChildAnesthesiaAndReanimationSuggestedTechniqueGridCollection : TTObject.TTChildObjectCollection<AnesthesiaAndReanimationSuggestedTechniqueGrid>
        {
            public ChildAnesthesiaAndReanimationSuggestedTechniqueGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaAndReanimationSuggestedTechniqueGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected AnesthesiaAndReanimationSuggestedTechniqueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaAndReanimationSuggestedTechniqueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaAndReanimationSuggestedTechniqueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaAndReanimationSuggestedTechniqueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaAndReanimationSuggestedTechniqueGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIAANDREANIMATIONSUGGESTEDTECHNIQUEGRID", dataRow) { }
        protected AnesthesiaAndReanimationSuggestedTechniqueGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIAANDREANIMATIONSUGGESTEDTECHNIQUEGRID", dataRow, isImported) { }
        public AnesthesiaAndReanimationSuggestedTechniqueGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaAndReanimationSuggestedTechniqueGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaAndReanimationSuggestedTechniqueGrid() : base() { }

    }
}