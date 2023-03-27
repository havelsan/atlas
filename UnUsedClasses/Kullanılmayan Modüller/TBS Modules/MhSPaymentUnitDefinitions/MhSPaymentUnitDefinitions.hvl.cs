
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSPaymentUnitDefinitions")] 

    /// <summary>
    /// Birim Tanımlama
    /// </summary>
    public  partial class MhSPaymentUnitDefinitions : TTObject
    {
        public class MhSPaymentUnitDefinitionsList : TTObjectCollection<MhSPaymentUnitDefinitions> { }
                    
        public class ChildMhSPaymentUnitDefinitionsCollection : TTObject.TTChildObjectCollection<MhSPaymentUnitDefinitions>
        {
            public ChildMhSPaymentUnitDefinitionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSPaymentUnitDefinitionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected MhSPaymentUnitDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSPaymentUnitDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSPaymentUnitDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSPaymentUnitDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSPaymentUnitDefinitions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSPAYMENTUNITDEFINITIONS", dataRow) { }
        protected MhSPaymentUnitDefinitions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSPAYMENTUNITDEFINITIONS", dataRow, isImported) { }
        public MhSPaymentUnitDefinitions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSPaymentUnitDefinitions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSPaymentUnitDefinitions() : base() { }

    }
}