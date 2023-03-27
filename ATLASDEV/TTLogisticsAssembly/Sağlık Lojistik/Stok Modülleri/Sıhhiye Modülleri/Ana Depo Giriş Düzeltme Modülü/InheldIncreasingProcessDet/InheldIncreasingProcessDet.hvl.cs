
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InheldIncreasingProcessDet")] 

    /// <summary>
    /// Mevcut Arttırma İşlemi Detay
    /// </summary>
    public  partial class InheldIncreasingProcessDet : EntryCorrectionProcessDet
    {
        public class InheldIncreasingProcessDetList : TTObjectCollection<InheldIncreasingProcessDet> { }
                    
        public class ChildInheldIncreasingProcessDetCollection : TTObject.TTChildObjectCollection<InheldIncreasingProcessDet>
        {
            public ChildInheldIncreasingProcessDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInheldIncreasingProcessDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ana İşlem
    /// </summary>
        public InheldIncreasingProcess InheldIncreasingProcess
        {
            get 
            {   
                if (StockAction is InheldIncreasingProcess)
                    return (InheldIncreasingProcess)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        protected InheldIncreasingProcessDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InheldIncreasingProcessDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InheldIncreasingProcessDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InheldIncreasingProcessDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InheldIncreasingProcessDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INHELDINCREASINGPROCESSDET", dataRow) { }
        protected InheldIncreasingProcessDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INHELDINCREASINGPROCESSDET", dataRow, isImported) { }
        public InheldIncreasingProcessDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InheldIncreasingProcessDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InheldIncreasingProcessDet() : base() { }

    }
}