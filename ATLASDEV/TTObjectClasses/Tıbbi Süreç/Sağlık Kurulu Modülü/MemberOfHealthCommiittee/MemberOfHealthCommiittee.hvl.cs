
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MemberOfHealthCommiittee")] 

    public  partial class MemberOfHealthCommiittee : TTObject
    {
        public class MemberOfHealthCommiitteeList : TTObjectCollection<MemberOfHealthCommiittee> { }
                    
        public class ChildMemberOfHealthCommiitteeCollection : TTObject.TTChildObjectCollection<MemberOfHealthCommiittee>
        {
            public ChildMemberOfHealthCommiitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMemberOfHealthCommiitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInternalRejectedUserByHCID_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFHEALTHCOMMIITTEE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInternalRejectedUserByHCID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInternalRejectedUserByHCID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInternalRejectedUserByHCID_Class() : base() { }
        }

        public static BindingList<MemberOfHealthCommiittee.GetInternalRejectedUserByHCID_Class> GetInternalRejectedUserByHCID(Guid HCID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFHEALTHCOMMIITTEE"].QueryDefs["GetInternalRejectedUserByHCID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HCID", HCID);

            return TTReportNqlObject.QueryObjects<MemberOfHealthCommiittee.GetInternalRejectedUserByHCID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MemberOfHealthCommiittee.GetInternalRejectedUserByHCID_Class> GetInternalRejectedUserByHCID(TTObjectContext objectContext, Guid HCID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFHEALTHCOMMIITTEE"].QueryDefs["GetInternalRejectedUserByHCID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HCID", HCID);

            return TTReportNqlObject.QueryObjects<MemberOfHealthCommiittee.GetInternalRejectedUserByHCID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sağlık Kurulu Üye Tipi
    /// </summary>
        public MemberOfHCTypeEnum? HealthCommitteeType
        {
            get { return (MemberOfHCTypeEnum?)(int?)this["HEALTHCOMMITTEETYPE"]; }
            set { this["HEALTHCOMMITTEETYPE"] = value; }
        }

    /// <summary>
    /// Onay
    /// </summary>
        public bool? Approve
        {
            get { return (bool?)this["APPROVE"]; }
            set { this["APPROVE"] = value; }
        }

    /// <summary>
    /// Red
    /// </summary>
        public bool? Reject
        {
            get { return (bool?)this["REJECT"]; }
            set { this["REJECT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public HealthCommittee HealthCommittee
        {
            get { return (HealthCommittee)((ITTObject)this).GetParent("HEALTHCOMMITTEE"); }
            set { this["HEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser MemberDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("MEMBERDOCTOR"); }
            set { this["MEMBERDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Branşlar
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MemberOfHealthCommiittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MemberOfHealthCommiittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MemberOfHealthCommiittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MemberOfHealthCommiittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MemberOfHealthCommiittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEMBEROFHEALTHCOMMIITTEE", dataRow) { }
        protected MemberOfHealthCommiittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEMBEROFHEALTHCOMMIITTEE", dataRow, isImported) { }
        public MemberOfHealthCommiittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MemberOfHealthCommiittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MemberOfHealthCommiittee() : base() { }

    }
}