
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DistributionPlace")] 

    /// <summary>
    /// Dağıtım Yeri
    /// </summary>
    public  partial class DistributionPlace : TTObject
    {
        public class DistributionPlaceList : TTObjectCollection<DistributionPlace> { }
                    
        public class ChildDistributionPlaceCollection : TTObject.TTChildObjectCollection<DistributionPlace>
        {
            public ChildDistributionPlaceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDistributionPlaceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dağıtım satırı
    /// </summary>
        public string DistributionLine
        {
            get { return (string)this["DISTRIBUTIONLINE"]; }
            set { this["DISTRIBUTIONLINE"] = value; }
        }

        public BaseCorrespondence BaseCorrespondence
        {
            get { return (BaseCorrespondence)((ITTObject)this).GetParent("BASECORRESPONDENCE"); }
            set { this["BASECORRESPONDENCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DistributionPlace(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DistributionPlace(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DistributionPlace(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DistributionPlace(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DistributionPlace(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTRIBUTIONPLACE", dataRow) { }
        protected DistributionPlace(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTRIBUTIONPLACE", dataRow, isImported) { }
        public DistributionPlace(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DistributionPlace(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DistributionPlace() : base() { }

    }
}