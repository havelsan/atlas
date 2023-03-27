
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteMemberGrid")] 

    /// <summary>
    /// Üyeler
    /// </summary>
    public  partial class HealthCommitteMemberGrid : TTObject
    {
        public class HealthCommitteMemberGridList : TTObjectCollection<HealthCommitteMemberGrid> { }
                    
        public class ChildHealthCommitteMemberGridCollection : TTObject.TTChildObjectCollection<HealthCommitteMemberGrid>
        {
            public ChildHealthCommitteMemberGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteMemberGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// GetMemberByMemberOfHCDef
    /// </summary>
        public static BindingList<HealthCommitteMemberGrid> GetMemberByMemberOfHCDef(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEMEMBERGRID"].QueryDefs["GetMemberByMemberOfHCDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<HealthCommitteMemberGrid>(queryDef, paramList);
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public string Work
        {
            get { return (string)this["WORK"]; }
            set { this["WORK"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection Unit
        {
            get { return (ResSection)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doktor
    /// </summary>
        public MemberOfHealthCommitteeDefinition MemberOfHealthCommitteeDef
        {
            get { return (MemberOfHealthCommitteeDefinition)((ITTObject)this).GetParent("MEMBEROFHEALTHCOMMITTEEDEF"); }
            set { this["MEMBEROFHEALTHCOMMITTEEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HealthCommitteMemberGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteMemberGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteMemberGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteMemberGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteMemberGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEMEMBERGRID", dataRow) { }
        protected HealthCommitteMemberGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEMEMBERGRID", dataRow, isImported) { }
        public HealthCommitteMemberGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteMemberGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteMemberGrid() : base() { }

    }
}