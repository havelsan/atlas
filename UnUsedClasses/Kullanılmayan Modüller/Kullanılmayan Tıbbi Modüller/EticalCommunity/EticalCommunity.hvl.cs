
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EticalCommunity")] 

    /// <summary>
    /// DE_Etik Kurul Başvuru
    /// </summary>
    public  partial class EticalCommunity : TTObject
    {
        public class EticalCommunityList : TTObjectCollection<EticalCommunity> { }
                    
        public class ChildEticalCommunityCollection : TTObject.TTChildObjectCollection<EticalCommunity>
        {
            public ChildEticalCommunityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEticalCommunityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başvuru Tarihi
    /// </summary>
        public DateTime? ApplicationDate
        {
            get { return (DateTime?)this["APPLICATIONDATE"]; }
            set { this["APPLICATIONDATE"] = value; }
        }

    /// <summary>
    /// Kurul Kararı
    /// </summary>
        public string Decision
        {
            get { return (string)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

        protected EticalCommunity(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EticalCommunity(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EticalCommunity(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EticalCommunity(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EticalCommunity(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETICALCOMMUNITY", dataRow) { }
        protected EticalCommunity(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETICALCOMMUNITY", dataRow, isImported) { }
        public EticalCommunity(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EticalCommunity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EticalCommunity() : base() { }

    }
}