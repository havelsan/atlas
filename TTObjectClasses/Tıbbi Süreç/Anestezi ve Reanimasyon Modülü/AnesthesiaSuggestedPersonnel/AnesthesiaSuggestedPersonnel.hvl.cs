
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaSuggestedPersonnel")] 

    /// <summary>
    /// Önerilen Anestezi Ekibi
    /// </summary>
    public  partial class AnesthesiaSuggestedPersonnel : BaseAnesthesiaPersonnel
    {
        public class AnesthesiaSuggestedPersonnelList : TTObjectCollection<AnesthesiaSuggestedPersonnel> { }
                    
        public class ChildAnesthesiaSuggestedPersonnelCollection : TTObject.TTChildObjectCollection<AnesthesiaSuggestedPersonnel>
        {
            public ChildAnesthesiaSuggestedPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaSuggestedPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected AnesthesiaSuggestedPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaSuggestedPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaSuggestedPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaSuggestedPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaSuggestedPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIASUGGESTEDPERSONNEL", dataRow) { }
        protected AnesthesiaSuggestedPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIASUGGESTEDPERSONNEL", dataRow, isImported) { }
        public AnesthesiaSuggestedPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaSuggestedPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaSuggestedPersonnel() : base() { }

    }
}