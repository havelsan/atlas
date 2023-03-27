
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="METDistribution")] 

    /// <summary>
    /// Dağıtım
    /// </summary>
    public  partial class METDistribution : TTObject
    {
        public class METDistributionList : TTObjectCollection<METDistribution> { }
                    
        public class ChildMETDistributionCollection : TTObject.TTChildObjectCollection<METDistribution>
        {
            public ChildMETDistributionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMETDistributionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public METDocument Document
        {
            get { return (METDocument)((ITTObject)this).GetParent("DOCUMENT"); }
            set { this["DOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected METDistribution(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected METDistribution(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected METDistribution(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected METDistribution(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected METDistribution(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "METDISTRIBUTION", dataRow) { }
        protected METDistribution(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "METDISTRIBUTION", dataRow, isImported) { }
        public METDistribution(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public METDistribution(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public METDistribution() : base() { }

    }
}