
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalCommittee")] 

    /// <summary>
    /// Tıbbi Kurul İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class MedicalCommittee : EpisodeActionWithDiagnosis, IAppointmentDef
    {
        public class MedicalCommitteeList : TTObjectCollection<MedicalCommittee> { }
                    
        public class ChildMedicalCommitteeCollection : TTObject.TTChildObjectCollection<MedicalCommittee>
        {
            public ChildMedicalCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCurrentMedicalCommittee_Class : TTReportNqlObject 
        {
            public Guid? Mcobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MCOBJECTID"]);
                }
            }

            public Guid? Pobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["POBJECTID"]);
                }
            }

            public string Birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Konu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KONU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITTEE"].AllPropertyDefs["SUBJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Tedaviplani
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIPLANI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITTEE"].AllPropertyDefs["TREATMENTPLAN"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Kurultipi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURULTIPI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITEEDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Dogumyeri
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOGUMYERI"]);
                }
            }

            public GetCurrentMedicalCommittee_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCurrentMedicalCommittee_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCurrentMedicalCommittee_Class() : base() { }
        }

        public static class States
        {
            public static Guid Request { get { return new Guid("35926b5f-097d-4e27-b637-39f1326dfcf4"); } }
            public static Guid Completed { get { return new Guid("7937bf6e-9dcc-4fb4-9ef7-1966af31555c"); } }
            public static Guid Acceptance { get { return new Guid("25f95528-d46e-4650-b10d-b5fb43ce7469"); } }
            public static Guid Appointment { get { return new Guid("b9670b07-b942-4363-b7c8-3bcffe4e7498"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("26abdee5-d339-42bd-8486-84bdc3380a67"); } }
            public static Guid Committee { get { return new Guid("5f649a39-3c67-4a1d-9308-bb2791d672ec"); } }
        }

    /// <summary>
    /// Süreçteki MedicalCommittee object ini get eder
    /// </summary>
        public static BindingList<MedicalCommittee.GetCurrentMedicalCommittee_Class> GetCurrentMedicalCommittee(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITTEE"].QueryDefs["GetCurrentMedicalCommittee"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MedicalCommittee.GetCurrentMedicalCommittee_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Süreçteki MedicalCommittee object ini get eder
    /// </summary>
        public static BindingList<MedicalCommittee.GetCurrentMedicalCommittee_Class> GetCurrentMedicalCommittee(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALCOMMITTEE"].QueryDefs["GetCurrentMedicalCommittee"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MedicalCommittee.GetCurrentMedicalCommittee_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tedavi Planı
    /// </summary>
        public object TreatmentPlan
        {
            get { return (object)this["TREATMENTPLAN"]; }
            set { this["TREATMENTPLAN"] = value; }
        }

    /// <summary>
    /// Konu
    /// </summary>
        public object Subject
        {
            get { return (object)this["SUBJECT"]; }
            set { this["SUBJECT"] = value; }
        }

    /// <summary>
    /// Protokol No
    /// </summary>
        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

    /// <summary>
    /// Toplantı saati
    /// </summary>
        public DateTime? MeetingTime
        {
            get { return (DateTime?)this["MEETINGTIME"]; }
            set { this["MEETINGTIME"] = value; }
        }

    /// <summary>
    /// Toplantı Yeri
    /// </summary>
        public string MeetingRoom
        {
            get { return (string)this["MEETINGROOM"]; }
            set { this["MEETINGROOM"] = value; }
        }

    /// <summary>
    /// Kaynak Listesi
    /// </summary>
        public ResSection Department
        {
            get { return (ResSection)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tıbbi Kurul
    /// </summary>
        public MedicalCommiteeDefinition MedicalCommitteType
        {
            get { return (MedicalCommiteeDefinition)((ITTObject)this).GetParent("MEDICALCOMMITTETYPE"); }
            set { this["MEDICALCOMMITTETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMemberOfMedicalCommitteeCollection()
        {
            _MemberOfMedicalCommittee = new MedicalCommitteeMemberOfMedicalCommitteeGrid.ChildMedicalCommitteeMemberOfMedicalCommitteeGridCollection(this, new Guid("77b7232c-8330-4e00-88a2-547586b6f8e8"));
            ((ITTChildObjectCollection)_MemberOfMedicalCommittee).GetChildren();
        }

        protected MedicalCommitteeMemberOfMedicalCommitteeGrid.ChildMedicalCommitteeMemberOfMedicalCommitteeGridCollection _MemberOfMedicalCommittee = null;
    /// <summary>
    /// Child collection for Kurul Üyeleri
    /// </summary>
        public MedicalCommitteeMemberOfMedicalCommitteeGrid.ChildMedicalCommitteeMemberOfMedicalCommitteeGridCollection MemberOfMedicalCommittee
        {
            get
            {
                if (_MemberOfMedicalCommittee == null)
                    CreateMemberOfMedicalCommitteeCollection();
                return _MemberOfMedicalCommittee;
            }
        }

        override protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new DiagnosisGrid.ChildDiagnosisGridCollection(this, new Guid("23d8fdfa-84a1-471b-bf93-ffc019438291"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected MedicalCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalCommittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALCOMMITTEE", dataRow) { }
        protected MedicalCommittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALCOMMITTEE", dataRow, isImported) { }
        public MedicalCommittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalCommittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalCommittee() : base() { }

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