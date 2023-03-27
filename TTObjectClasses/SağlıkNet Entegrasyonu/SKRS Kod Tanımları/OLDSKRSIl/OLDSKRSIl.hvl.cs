
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OLDSKRSIl")] 

    /// <summary>
    /// 5bc508fa-782a-4d75-831f-34948e350e72
    /// </summary>
    public  partial class OLDSKRSIl : BaseSKRSDefinition
    {
        public class OLDSKRSIlList : TTObjectCollection<OLDSKRSIl> { }
                    
        public class ChildOLDSKRSIlCollection : TTObject.TTChildObjectCollection<OLDSKRSIl>
        {
            public ChildOLDSKRSIlCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOLDSKRSIlCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected OLDSKRSIl(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OLDSKRSIl(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OLDSKRSIl(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OLDSKRSIl(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OLDSKRSIl(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLDSKRSIL", dataRow) { }
        protected OLDSKRSIl(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLDSKRSIL", dataRow, isImported) { }
        public OLDSKRSIl(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OLDSKRSIl(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OLDSKRSIl() : base() { }

    }
}