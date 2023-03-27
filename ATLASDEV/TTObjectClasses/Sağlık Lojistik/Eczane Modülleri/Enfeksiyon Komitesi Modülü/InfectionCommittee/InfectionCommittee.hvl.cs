
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InfectionCommittee")] 

    /// <summary>
    /// Enfeksiyon Komitesi
    /// </summary>
    public  partial class InfectionCommittee : EpisodeAction, IWorkListEpisodeAction
    {
        public class InfectionCommitteeList : TTObjectCollection<InfectionCommittee> { }
                    
        public class ChildInfectionCommitteeCollection : TTObject.TTChildObjectCollection<InfectionCommittee>
        {
            public ChildInfectionCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfectionCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetActiveInfectionComApprovel_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public DateTime? PlannedStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEEDETAIL"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetActiveInfectionComApprovel_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveInfectionComApprovel_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveInfectionComApprovel_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveInfectionComApprovelByMat_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public DateTime? PlannedStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEEDETAIL"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetActiveInfectionComApprovelByMat_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveInfectionComApprovelByMat_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveInfectionComApprovelByMat_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveInfectionComByDrugOrder_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetActiveInfectionComByDrugOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveInfectionComByDrugOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveInfectionComByDrugOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class InfectionCommitteeWorkListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public DateTime? Islem_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEM_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Adsoyad
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["ADSOYAD"]);
                }
            }

            public string Kabul_no
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABUL_NO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Tc_kimlik_no
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TC_KIMLIK_NO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Servis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yatak_servis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAK_SERVIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Oda
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yatak
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATAK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Doktor
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOKTOR"]);
                }
            }

            public DateTime? Yatis_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATIS_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTTREATMENTCLINICAPPLICATION"].AllPropertyDefs["CLINICINPATIENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public InfectionCommitteeWorkListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InfectionCommitteeWorkListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InfectionCommitteeWorkListNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("0f6725bb-6cd7-41d6-b8d0-cfb2b2761bd8"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("c5933b40-3491-4ae2-b0b4-f329488b96b1"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("bc831ce7-3d56-469a-b3fe-15fc57f1ee03"); } }
        }

    /// <summary>
    /// Aktif Enfeksiyon Onayları
    /// </summary>
        public static BindingList<InfectionCommittee.GetActiveInfectionComApprovel_Class> GetActiveInfectionComApprovel(Guid SUBEPISODE, DateTime CURRENTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].QueryDefs["GetActiveInfectionComApprovel"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("CURRENTDATE", CURRENTDATE);

            return TTReportNqlObject.QueryObjects<InfectionCommittee.GetActiveInfectionComApprovel_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Aktif Enfeksiyon Onayları
    /// </summary>
        public static BindingList<InfectionCommittee.GetActiveInfectionComApprovel_Class> GetActiveInfectionComApprovel(TTObjectContext objectContext, Guid SUBEPISODE, DateTime CURRENTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].QueryDefs["GetActiveInfectionComApprovel"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("CURRENTDATE", CURRENTDATE);

            return TTReportNqlObject.QueryObjects<InfectionCommittee.GetActiveInfectionComApprovel_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InfectionCommittee.GetActiveInfectionComApprovelByMat_Class> GetActiveInfectionComApprovelByMat(Guid SUBEPISODE, DateTime ENDDATE, Guid MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].QueryDefs["GetActiveInfectionComApprovelByMat"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<InfectionCommittee.GetActiveInfectionComApprovelByMat_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InfectionCommittee.GetActiveInfectionComApprovelByMat_Class> GetActiveInfectionComApprovelByMat(TTObjectContext objectContext, Guid SUBEPISODE, DateTime ENDDATE, Guid MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].QueryDefs["GetActiveInfectionComApprovelByMat"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<InfectionCommittee.GetActiveInfectionComApprovelByMat_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InfectionCommittee.GetActiveInfectionComByDrugOrder_Class> GetActiveInfectionComByDrugOrder(Guid DRUGORDERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].QueryDefs["GetActiveInfectionComByDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDERID", DRUGORDERID);

            return TTReportNqlObject.QueryObjects<InfectionCommittee.GetActiveInfectionComByDrugOrder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InfectionCommittee.GetActiveInfectionComByDrugOrder_Class> GetActiveInfectionComByDrugOrder(TTObjectContext objectContext, Guid DRUGORDERID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].QueryDefs["GetActiveInfectionComByDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDERID", DRUGORDERID);

            return TTReportNqlObject.QueryObjects<InfectionCommittee.GetActiveInfectionComByDrugOrder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InfectionCommittee.InfectionCommitteeWorkListNQL_Class> InfectionCommitteeWorkListNQL(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].QueryDefs["InfectionCommitteeWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InfectionCommittee.InfectionCommitteeWorkListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InfectionCommittee.InfectionCommitteeWorkListNQL_Class> InfectionCommitteeWorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INFECTIONCOMMITTEE"].QueryDefs["InfectionCommitteeWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<InfectionCommittee.InfectionCommitteeWorkListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İptal Nedeni
    /// </summary>
        public string CancelReason
        {
            get { return (string)this["CANCELREASON"]; }
            set { this["CANCELREASON"] = value; }
        }

        public InPatientPhysicianApplication InPatientPhysicianApplication
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIANAPPLICATION"); }
            set { this["INPATIENTPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInfectionCommitteeDetailsCollection()
        {
            _InfectionCommitteeDetails = new InfectionCommitteeDetail.ChildInfectionCommitteeDetailCollection(this, new Guid("5ab21281-aac1-49c2-91b0-26298aab97da"));
            ((ITTChildObjectCollection)_InfectionCommitteeDetails).GetChildren();
        }

        protected InfectionCommitteeDetail.ChildInfectionCommitteeDetailCollection _InfectionCommitteeDetails = null;
        public InfectionCommitteeDetail.ChildInfectionCommitteeDetailCollection InfectionCommitteeDetails
        {
            get
            {
                if (_InfectionCommitteeDetails == null)
                    CreateInfectionCommitteeDetailsCollection();
                return _InfectionCommitteeDetails;
            }
        }

        protected InfectionCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InfectionCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InfectionCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InfectionCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InfectionCommittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFECTIONCOMMITTEE", dataRow) { }
        protected InfectionCommittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFECTIONCOMMITTEE", dataRow, isImported) { }
        public InfectionCommittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InfectionCommittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InfectionCommittee() : base() { }

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