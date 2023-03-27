
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MemberOfHealthCommitteeDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Heyet Tanımları
    /// </summary>
    public  partial class MemberOfHealthCommitteeDefinition : TTDefinitionSet
    {
        public class MemberOfHealthCommitteeDefinitionList : TTObjectCollection<MemberOfHealthCommitteeDefinition> { }
                    
        public class ChildMemberOfHealthCommitteeDefinitionCollection : TTObject.TTChildObjectCollection<MemberOfHealthCommitteeDefinition>
        {
            public ChildMemberOfHealthCommitteeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMemberOfHealthCommitteeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMemberOfHealthCommitteeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? GroupNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFHEALTHCOMMITTEEDEFINITION"].AllPropertyDefs["GROUPNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

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

            public string CommitteeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMITTEENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFHEALTHCOMMITTEEDEFINITION"].AllPropertyDefs["COMMITTEENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMemberOfHealthCommitteeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMemberOfHealthCommitteeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMemberOfHealthCommitteeDefinition_Class() : base() { }
        }

        public static BindingList<MemberOfHealthCommitteeDefinition.GetMemberOfHealthCommitteeDefinition_Class> GetMemberOfHealthCommitteeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFHEALTHCOMMITTEEDEFINITION"].QueryDefs["GetMemberOfHealthCommitteeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MemberOfHealthCommitteeDefinition.GetMemberOfHealthCommitteeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MemberOfHealthCommitteeDefinition.GetMemberOfHealthCommitteeDefinition_Class> GetMemberOfHealthCommitteeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFHEALTHCOMMITTEEDEFINITION"].QueryDefs["GetMemberOfHealthCommitteeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MemberOfHealthCommitteeDefinition.GetMemberOfHealthCommitteeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MemberOfHealthCommitteeDefinition> GetMemberDefinitions(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFHEALTHCOMMITTEEDEFINITION"].QueryDefs["GetMemberDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MemberOfHealthCommitteeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Grup No
    /// </summary>
        public TTSequence GroupNo
        {
            get { return GetSequence("GROUPNO"); }
        }

    /// <summary>
    /// Sağlık Kurulunun türünü belirtir.
    /// </summary>
        public HealthCommitteeTypeEnum? CommitteeType
        {
            get { return (HealthCommitteeTypeEnum?)(int?)this["COMMITTEETYPE"]; }
            set { this["COMMITTEETYPE"] = value; }
        }

    /// <summary>
    /// Heyet Adı
    /// </summary>
        public string CommitteeName
        {
            get { return (string)this["COMMITTEENAME"]; }
            set { this["COMMITTEENAME"] = value; }
        }

    /// <summary>
    /// Sağlık Kurulu Başkanı
    /// </summary>
        public ResUser MasterOfHealthCommittee2
        {
            get { return (ResUser)((ITTObject)this).GetParent("MASTEROFHEALTHCOMMITTEE2"); }
            set { this["MASTEROFHEALTHCOMMITTEE2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Baştabip / Baştabip Yardımcısı
    /// </summary>
        public ResUser MasterOfHealthCommittee
        {
            get { return (ResUser)((ITTObject)this).GetParent("MASTEROFHEALTHCOMMITTEE"); }
            set { this["MASTEROFHEALTHCOMMITTEE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMembersCollection()
        {
            _Members = new HealthCommitteMemberGrid.ChildHealthCommitteMemberGridCollection(this, new Guid("6192d679-740b-45fa-8935-a1c9ef631e03"));
            ((ITTChildObjectCollection)_Members).GetChildren();
        }

        protected HealthCommitteMemberGrid.ChildHealthCommitteMemberGridCollection _Members = null;
    /// <summary>
    /// Child collection for Doktor
    /// </summary>
        public HealthCommitteMemberGrid.ChildHealthCommitteMemberGridCollection Members
        {
            get
            {
                if (_Members == null)
                    CreateMembersCollection();
                return _Members;
            }
        }

        virtual protected void CreateHCAddtionalReportsCollection()
        {
            _HCAddtionalReports = new HealthCommitteeAdditionalReport.ChildHealthCommitteeAdditionalReportCollection(this, new Guid("0aed551c-486e-4245-a862-40680304cc52"));
            ((ITTChildObjectCollection)_HCAddtionalReports).GetChildren();
        }

        protected HealthCommitteeAdditionalReport.ChildHealthCommitteeAdditionalReportCollection _HCAddtionalReports = null;
    /// <summary>
    /// Child collection for Heyet Teşkili
    /// </summary>
        public HealthCommitteeAdditionalReport.ChildHealthCommitteeAdditionalReportCollection HCAddtionalReports
        {
            get
            {
                if (_HCAddtionalReports == null)
                    CreateHCAddtionalReportsCollection();
                return _HCAddtionalReports;
            }
        }

        protected MemberOfHealthCommitteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MemberOfHealthCommitteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MemberOfHealthCommitteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MemberOfHealthCommitteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MemberOfHealthCommitteeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEMBEROFHEALTHCOMMITTEEDEFINITION", dataRow) { }
        protected MemberOfHealthCommitteeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEMBEROFHEALTHCOMMITTEEDEFINITION", dataRow, isImported) { }
        public MemberOfHealthCommitteeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MemberOfHealthCommitteeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MemberOfHealthCommitteeDefinition() : base() { }

    }
}