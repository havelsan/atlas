
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReferToUpperLevel_CommisionMember")] 

    /// <summary>
    /// Üst Kademeye Sevk İşlemi HEK Komisyonu Sekmesi
    /// </summary>
    public  partial class ReferToUpperLevel_CommisionMember : CommisionMember
    {
        public class ReferToUpperLevel_CommisionMemberList : TTObjectCollection<ReferToUpperLevel_CommisionMember> { }
                    
        public class ChildReferToUpperLevel_CommisionMemberCollection : TTObject.TTChildObjectCollection<ReferToUpperLevel_CommisionMember>
        {
            public ChildReferToUpperLevel_CommisionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReferToUpperLevel_CommisionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ReferToUpperLevel ReferToUpperLevel
        {
            get { return (ReferToUpperLevel)((ITTObject)this).GetParent("REFERTOUPPERLEVEL"); }
            set { this["REFERTOUPPERLEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReferToUpperLevel_CommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReferToUpperLevel_CommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReferToUpperLevel_CommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReferToUpperLevel_CommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReferToUpperLevel_CommisionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REFERTOUPPERLEVEL_COMMISIONMEMBER", dataRow) { }
        protected ReferToUpperLevel_CommisionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REFERTOUPPERLEVEL_COMMISIONMEMBER", dataRow, isImported) { }
        public ReferToUpperLevel_CommisionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReferToUpperLevel_CommisionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReferToUpperLevel_CommisionMember() : base() { }

    }
}