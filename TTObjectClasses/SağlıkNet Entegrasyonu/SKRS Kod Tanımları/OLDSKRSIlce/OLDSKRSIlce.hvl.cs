
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLDSKRSIlce")] 

    /// <summary>
    /// 96184a9e-537c-4a70-8b3a-27a7a170355b
    /// </summary>
    public  partial class OLDSKRSIlce : BaseSKRSDefinition
    {
        public class OLDSKRSIlceList : TTObjectCollection<OLDSKRSIlce> { }
                    
        public class ChildOLDSKRSIlceCollection : TTObject.TTChildObjectCollection<OLDSKRSIlce>
        {
            public ChildOLDSKRSIlceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLDSKRSIlceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public string ADI
        {
            get { return (string)this["ADI"]; }
            set { this["ADI"] = value; }
        }

        public int? KODU
        {
            get { return (int?)this["KODU"]; }
            set { this["KODU"] = value; }
        }

        public int? ILKODU
        {
            get { return (int?)this["ILKODU"]; }
            set { this["ILKODU"] = value; }
        }

        protected OLDSKRSIlce(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLDSKRSIlce(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLDSKRSIlce(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLDSKRSIlce(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLDSKRSIlce(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLDSKRSILCE", dataRow) { }
        protected OLDSKRSIlce(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLDSKRSILCE", dataRow, isImported) { }
        public OLDSKRSIlce(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLDSKRSIlce(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLDSKRSIlce() : base() { }

    }
}