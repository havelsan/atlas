
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CompanionApplication")] 

    /// <summary>
    /// Refakatçi İşlemleri
    /// </summary>
    public  partial class CompanionApplication : EpisodeAction
    {
        public class CompanionApplicationList : TTObjectCollection<CompanionApplication> { }
                    
        public class ChildCompanionApplicationCollection : TTObject.TTChildObjectCollection<CompanionApplication>
        {
            public ChildCompanionApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCompanionApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCompanionApplicationByEpisode_Class : TTReportNqlObject 
        {
            public string CompanionAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["COMPANIONADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CompanionBirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["COMPANIONBIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string CompanionName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["COMPANIONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Companionsex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONSEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? StayingDateCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAYINGDATECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["STAYINGDATECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MedicalReasonForCompanion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICALREASONFORCOMPANION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["MEDICALREASONFORCOMPANION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RelationshipType? Relationship
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIONSHIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["RELATIONSHIP"].DataType;
                    return (RelationshipType?)(int)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["UNIQUEREFNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Servisname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVISNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SERVICE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Protocol
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROTOCOL"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public GetCompanionApplicationByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompanionApplicationByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompanionApplicationByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompanionApplicationBySubEpisode_Class : TTReportNqlObject 
        {
            public string CompanionAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["COMPANIONADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CompanionBirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["COMPANIONBIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string CompanionName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["COMPANIONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Companionsex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONSEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? StayingDateCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAYINGDATECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["STAYINGDATECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetCompanionApplicationBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompanionApplicationBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompanionApplicationBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class CompanionApplicationFormList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string CompanionName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["COMPANIONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Companionsex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONSEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? StayingDateCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAYINGDATECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["STAYINGDATECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DURUMU"]);
                }
            }

            public CompanionApplicationFormList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CompanionApplicationFormList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CompanionApplicationFormList_Class() : base() { }
        }

        [Serializable] 

        public partial class CompanionApplicationFormListByMasterAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string CompanionName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["COMPANIONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Companionsex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONSEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? StayingDateCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAYINGDATECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].AllPropertyDefs["STAYINGDATECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Object Durumu
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DURUMU"]);
                }
            }

            public CompanionApplicationFormListByMasterAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CompanionApplicationFormListByMasterAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CompanionApplicationFormListByMasterAction_Class() : base() { }
        }

        public static class States
        {
            public static Guid Active { get { return new Guid("3d890ec5-141c-451b-88b9-180a46b6b56d"); } }
            public static Guid Cancelled { get { return new Guid("7b3b1548-6438-45b2-b636-b3621c9a3089"); } }
            public static Guid ExCompanion { get { return new Guid("951034de-9c78-4b91-b82f-dc3aa013d8e2"); } }
        }

        public static BindingList<CompanionApplication.GetCompanionApplicationByEpisode_Class> GetCompanionApplicationByEpisode(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].QueryDefs["GetCompanionApplicationByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CompanionApplication.GetCompanionApplicationByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CompanionApplication.GetCompanionApplicationByEpisode_Class> GetCompanionApplicationByEpisode(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].QueryDefs["GetCompanionApplicationByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CompanionApplication.GetCompanionApplicationByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CompanionApplication.GetCompanionApplicationBySubEpisode_Class> GetCompanionApplicationBySubEpisode(string SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].QueryDefs["GetCompanionApplicationBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CompanionApplication.GetCompanionApplicationBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CompanionApplication.GetCompanionApplicationBySubEpisode_Class> GetCompanionApplicationBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].QueryDefs["GetCompanionApplicationBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CompanionApplication.GetCompanionApplicationBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CompanionApplication.CompanionApplicationFormList_Class> CompanionApplicationFormList(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].QueryDefs["CompanionApplicationFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CompanionApplication.CompanionApplicationFormList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CompanionApplication.CompanionApplicationFormList_Class> CompanionApplicationFormList(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].QueryDefs["CompanionApplicationFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<CompanionApplication.CompanionApplicationFormList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CompanionApplication.CompanionApplicationFormListByMasterAction_Class> CompanionApplicationFormListByMasterAction(Guid MASTERACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].QueryDefs["CompanionApplicationFormListByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTION", MASTERACTION);

            return TTReportNqlObject.QueryObjects<CompanionApplication.CompanionApplicationFormListByMasterAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CompanionApplication.CompanionApplicationFormListByMasterAction_Class> CompanionApplicationFormListByMasterAction(TTObjectContext objectContext, Guid MASTERACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPANIONAPPLICATION"].QueryDefs["CompanionApplicationFormListByMasterAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MASTERACTION", MASTERACTION);

            return TTReportNqlObject.QueryObjects<CompanionApplication.CompanionApplicationFormListByMasterAction_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Refakatçi Adresi
    /// </summary>
        public string CompanionAddress
        {
            get { return (string)this["COMPANIONADDRESS"]; }
            set { this["COMPANIONADDRESS"] = value; }
        }

    /// <summary>
    /// Kalacağı Gün Sayısı
    /// </summary>
        public int? StayingDateCount
        {
            get { return (int?)this["STAYINGDATECOUNT"]; }
            set { this["STAYINGDATECOUNT"] = value; }
        }

    /// <summary>
    /// Refakatçi Adı
    /// </summary>
        public string CompanionName
        {
            get { return (string)this["COMPANIONNAME"]; }
            set { this["COMPANIONNAME"] = value; }
        }

    /// <summary>
    /// Refakatçi Doğum Tarihi
    /// </summary>
        public DateTime? CompanionBirthDate
        {
            get { return (DateTime?)this["COMPANIONBIRTHDATE"]; }
            set { this["COMPANIONBIRTHDATE"] = value; }
        }

    /// <summary>
    /// Kalacağı Gün Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Refakatçi Tıbbi Endikasyon Sebebi
    /// </summary>
        public string MedicalReasonForCompanion
        {
            get { return (string)this["MEDICALREASONFORCOMPANION"]; }
            set { this["MEDICALREASONFORCOMPANION"] = value; }
        }

    /// <summary>
    /// Pasaport No
    /// </summary>
        public string PassportNo
        {
            get { return (string)this["PASSPORTNO"]; }
            set { this["PASSPORTNO"] = value; }
        }

    /// <summary>
    /// hastayla Yakınlık Derecesi
    /// </summary>
        public RelationshipType? Relationship
        {
            get { return (RelationshipType?)(int?)this["RELATIONSHIP"]; }
            set { this["RELATIONSHIP"] = value; }
        }

    /// <summary>
    /// T.C. Kimlik No
    /// </summary>
        public long? UniqueRefNo
        {
            get { return (long?)this["UNIQUEREFNO"]; }
            set { this["UNIQUEREFNO"] = value; }
        }

        public SKRSCinsiyet CompanionSex
        {
            get { return (SKRSCinsiyet)((ITTObject)this).GetParent("COMPANIONSEX"); }
            set { this["COMPANIONSEX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta Yatış
    /// </summary>
        public InpatientAdmission InpatientAdmission
        {
            get { return (InpatientAdmission)((ITTObject)this).GetParent("INPATIENTADMISSION"); }
            set { this["INPATIENTADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DietDefinition DietDefinition
        {
            get { return (DietDefinition)((ITTObject)this).GetParent("DIETDEFINITION"); }
            set { this["DIETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientTreatmentClinicApplication InPatientTreatmentClinicApplication
        {
            get 
            {   
                if (MasterAction is InPatientTreatmentClinicApplication)
                    return (InPatientTreatmentClinicApplication)MasterAction; 
                return null;
            }            
            set { MasterAction = value; }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _CompanionProcedures = new CompanionProcedure.ChildCompanionProcedureCollection(_SubactionProcedures, "CompanionProcedures");
        }

        private CompanionProcedure.ChildCompanionProcedureCollection _CompanionProcedures = null;
        public CompanionProcedure.ChildCompanionProcedureCollection CompanionProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _CompanionProcedures;
            }            
        }

        protected CompanionApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CompanionApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CompanionApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CompanionApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CompanionApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMPANIONAPPLICATION", dataRow) { }
        protected CompanionApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMPANIONAPPLICATION", dataRow, isImported) { }
        public CompanionApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CompanionApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CompanionApplication() : base() { }

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