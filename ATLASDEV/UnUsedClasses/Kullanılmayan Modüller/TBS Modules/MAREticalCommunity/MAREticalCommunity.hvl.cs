
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MAREticalCommunity")] 

    /// <summary>
    /// DE_Etik Kurul Başvuru
    /// </summary>
    public  partial class MAREticalCommunity : TTObject
    {
        public class MAREticalCommunityList : TTObjectCollection<MAREticalCommunity> { }
                    
        public class ChildMAREticalCommunityCollection : TTObject.TTChildObjectCollection<MAREticalCommunity>
        {
            public ChildMAREticalCommunityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMAREticalCommunityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected MAREticalCommunity(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MAREticalCommunity(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MAREticalCommunity(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MAREticalCommunity(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MAREticalCommunity(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARETICALCOMMUNITY", dataRow) { }
        protected MAREticalCommunity(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARETICALCOMMUNITY", dataRow, isImported) { }
        public MAREticalCommunity(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MAREticalCommunity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MAREticalCommunity() : base() { }

    }
}