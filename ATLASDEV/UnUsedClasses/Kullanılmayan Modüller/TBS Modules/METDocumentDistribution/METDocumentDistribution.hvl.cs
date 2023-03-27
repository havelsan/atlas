
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METDocumentDistribution")] 

    /// <summary>
    /// Evrak Dağıtım
    /// </summary>
    public  partial class METDocumentDistribution : TTObject
    {
        public class METDocumentDistributionList : TTObjectCollection<METDocumentDistribution> { }
                    
        public class ChildMETDocumentDistributionCollection : TTObject.TTChildObjectCollection<METDocumentDistribution>
        {
            public ChildMETDocumentDistributionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETDocumentDistributionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected METDocumentDistribution(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METDocumentDistribution(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METDocumentDistribution(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METDocumentDistribution(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METDocumentDistribution(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METDOCUMENTDISTRIBUTION", dataRow) { }
        protected METDocumentDistribution(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METDOCUMENTDISTRIBUTION", dataRow, isImported) { }
        public METDocumentDistribution(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METDocumentDistribution(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METDocumentDistribution() : base() { }

    }
}