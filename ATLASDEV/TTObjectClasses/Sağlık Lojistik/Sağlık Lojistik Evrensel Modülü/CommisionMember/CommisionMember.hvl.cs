
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommisionMember")] 

    public  partial class CommisionMember : TTObject
    {
        public class CommisionMemberList : TTObjectCollection<CommisionMember> { }
                    
        public class ChildCommisionMemberCollection : TTObject.TTChildObjectCollection<CommisionMember>
        {
            public ChildCommisionMemberCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommisionMemberCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Görevi
    /// </summary>
        public CommisionMemberDutyEnum? MemberDuty
        {
            get { return (CommisionMemberDutyEnum?)(int?)this["MEMBERDUTY"]; }
            set { this["MEMBERDUTY"] = value; }
        }

    /// <summary>
    /// AsilYedek
    /// </summary>
        public bool? PrimeBackup
        {
            get { return (bool?)this["PRIMEBACKUP"]; }
            set { this["PRIMEBACKUP"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? CommisionOrderNo
        {
            get { return (int?)this["COMMISIONORDERNO"]; }
            set { this["COMMISIONORDERNO"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string NameString
        {
            get { return (string)this["NAMESTRING"]; }
            set { this["NAMESTRING"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommisionMember(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommisionMember(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommisionMember(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMISIONMEMBER", dataRow) { }
        protected CommisionMember(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMISIONMEMBER", dataRow, isImported) { }
        public CommisionMember(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommisionMember(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommisionMember() : base() { }

    }
}