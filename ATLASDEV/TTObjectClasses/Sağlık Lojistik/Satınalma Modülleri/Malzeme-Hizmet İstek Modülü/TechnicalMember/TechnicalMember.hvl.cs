
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TechnicalMember")] 

    /// <summary>
    /// Teknik Üye
    /// </summary>
    public  partial class TechnicalMember : CommisionMember
    {
        public class TechnicalMemberList : TTObjectCollection<TechnicalMember> { }
                    
        public class ChildTechnicalMemberCollection : TTObject.TTChildObjectCollection<TechnicalMember>
        {
            public ChildTechnicalMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTechnicalMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Demand Demand
        {
            get { return (Demand)((ITTObject)this).GetParent("DEMAND"); }
            set { this["DEMAND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TechnicalMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TechnicalMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TechnicalMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TechnicalMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TechnicalMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TECHNICALMEMBER", dataRow) { }
        protected TechnicalMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TECHNICALMEMBER", dataRow, isImported) { }
        public TechnicalMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TechnicalMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TechnicalMember() : base() { }

    }
}