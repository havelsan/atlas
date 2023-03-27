
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MemberOfMedicalCommitteeDefinition")] 

    /// <summary>
    /// Tıbbi Kurul Heyet Teşkili Tanımlama
    /// </summary>
    public  partial class MemberOfMedicalCommitteeDefinition : TTDefinitionSet
    {
        public class MemberOfMedicalCommitteeDefinitionList : TTObjectCollection<MemberOfMedicalCommitteeDefinition> { }
                    
        public class ChildMemberOfMedicalCommitteeDefinitionCollection : TTObject.TTChildObjectCollection<MemberOfMedicalCommitteeDefinition>
        {
            public ChildMemberOfMedicalCommitteeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMemberOfMedicalCommitteeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMemberOfMedicalCommitteeDefinition_Class : TTReportNqlObject 
        {
            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFMEDICALCOMMITTEEDEFINITION"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFMEDICALCOMMITTEEDEFINITION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMemberOfMedicalCommitteeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMemberOfMedicalCommitteeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMemberOfMedicalCommitteeDefinition_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("327426d7-63ff-40a6-9530-6b68c5980ca4"); } }
            public static Guid Completed { get { return new Guid("0d1f37cc-9e21-41aa-8014-d7bdf99b298a"); } }
        }

        public static BindingList<MemberOfMedicalCommitteeDefinition.GetMemberOfMedicalCommitteeDefinition_Class> GetMemberOfMedicalCommitteeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFMEDICALCOMMITTEEDEFINITION"].QueryDefs["GetMemberOfMedicalCommitteeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MemberOfMedicalCommitteeDefinition.GetMemberOfMedicalCommitteeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MemberOfMedicalCommitteeDefinition.GetMemberOfMedicalCommitteeDefinition_Class> GetMemberOfMedicalCommitteeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFMEDICALCOMMITTEEDEFINITION"].QueryDefs["GetMemberOfMedicalCommitteeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MemberOfMedicalCommitteeDefinition.GetMemberOfMedicalCommitteeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Tıbbi Kurul Heyet Teşkili Tanımlamalarını Tıbbi Kurul tanımına göre getirir.
    /// </summary>
        public static BindingList<MemberOfMedicalCommitteeDefinition> GetMemberOfMCDefinitionByType(TTObjectContext objectContext, string TYPEID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEMBEROFMEDICALCOMMITTEEDEFINITION"].QueryDefs["GetMemberOfMCDefinitionByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TYPEID", TYPEID);

            return ((ITTQuery)objectContext).QueryObjects<MemberOfMedicalCommitteeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Komite Türü
    /// </summary>
        public MedicalCommiteeDefinition MedicalCommitteeType
        {
            get { return (MedicalCommiteeDefinition)((ITTObject)this).GetParent("MEDICALCOMMITTEETYPE"); }
            set { this["MEDICALCOMMITTEETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMembersCollection()
        {
            _Members = new MedicalCommiteeMember.ChildMedicalCommiteeMemberCollection(this, new Guid("72f14f31-3c6d-424e-87d3-ab3eead1d97c"));
            ((ITTChildObjectCollection)_Members).GetChildren();
        }

        protected MedicalCommiteeMember.ChildMedicalCommiteeMemberCollection _Members = null;
        public MedicalCommiteeMember.ChildMedicalCommiteeMemberCollection Members
        {
            get
            {
                if (_Members == null)
                    CreateMembersCollection();
                return _Members;
            }
        }

        protected MemberOfMedicalCommitteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MemberOfMedicalCommitteeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MemberOfMedicalCommitteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MemberOfMedicalCommitteeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MemberOfMedicalCommitteeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEMBEROFMEDICALCOMMITTEEDEFINITION", dataRow) { }
        protected MemberOfMedicalCommitteeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEMBEROFMEDICALCOMMITTEEDEFINITION", dataRow, isImported) { }
        protected MemberOfMedicalCommitteeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MemberOfMedicalCommitteeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MemberOfMedicalCommitteeDefinition() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}