
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HemodialysisOrder")] 

    /// <summary>
    /// Diyaliz Emrinin Verildiği Nesnedir.
    /// </summary>
    public  partial class HemodialysisOrder : PlannedAction, IWorkListEpisodeAction, IPlanPlannedAction
    {
        public class HemodialysisOrderList : TTObjectCollection<HemodialysisOrder> { }
                    
        public class ChildHemodialysisOrderCollection : TTObject.TTChildObjectCollection<HemodialysisOrder>
        {
            public ChildHemodialysisOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHemodialysisOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHemodialysisOrderNewPlanForWorkList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
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

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Archivenumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARCHIVENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? YUPASSNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Admissiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISREQUEST"].AllPropertyDefs["HEMODIALYSISREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetHemodialysisOrderNewPlanForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHemodialysisOrderNewPlanForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHemodialysisOrderNewPlanForWorkList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHemodialysisOrderForWorkList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
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

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissionnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Archivenumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARCHIVENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? YUPASSNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Admissiondate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISREQUEST"].AllPropertyDefs["HEMODIALYSISREQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetHemodialysisOrderForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHemodialysisOrderForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHemodialysisOrderForWorkList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHemodialysisOrderList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
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

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? DialysisFrequency
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DIALYSISFREQUENCY"]);
                }
            }

            public int? Duration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].AllPropertyDefs["DURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Information
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].AllPropertyDefs["INFORMATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsWeekendInclude
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISWEEKENDINCLUDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].AllPropertyDefs["ISWEEKENDINCLUDE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? PackageProcedure
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PACKAGEPROCEDURE"]);
                }
            }

            public int? SessionCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].AllPropertyDefs["SESSIONCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? SessionDayRange
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONDAYRANGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].AllPropertyDefs["SESSIONDAYRANGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PeriodUnitTypeEnum? SessionDayRangeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SESSIONDAYRANGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].AllPropertyDefs["SESSIONDAYRANGETYPE"].DataType;
                    return (PeriodUnitTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? TreatmentEquipment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTEQUIPMENT"]);
                }
            }

            public DateTime? TreatmentStartDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENTSTARTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].AllPropertyDefs["TREATMENTSTARTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHemodialysisOrderList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHemodialysisOrderList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHemodialysisOrderList_Class() : base() { }
        }

        public static class States
        {
            public static Guid Plan { get { return new Guid("9cbd167b-16e8-4f29-a736-cca479be8f01"); } }
            public static Guid Request { get { return new Guid("4f23396e-2d48-4aa4-8a8e-c45b02313167"); } }
            public static Guid Cancelled { get { return new Guid("0edb55d4-afca-4b73-87fa-857f9e70e5b2"); } }
            public static Guid Completed { get { return new Guid("806f0a29-2eca-41b4-9dfa-e69657be71c6"); } }
            public static Guid Aborted { get { return new Guid("c6b96bc6-1c9f-422d-a45f-aa98a021ec0b"); } }
            public static Guid Therapy { get { return new Guid("4af42518-ca11-47e3-96b4-e1297d7231c2"); } }
        }

        public static BindingList<HemodialysisOrder> GetMySiblingObjectsForAppointment(TTObjectContext objectContext, string EPISODE, string CURRENTOBJECT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].QueryDefs["GetMySiblingObjectsForAppointment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("CURRENTOBJECT", CURRENTOBJECT);

            return ((ITTQuery)objectContext).QueryObjects<HemodialysisOrder>(queryDef, paramList);
        }

        public static BindingList<HemodialysisOrder.GetHemodialysisOrderNewPlanForWorkList_Class> GetHemodialysisOrderNewPlanForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].QueryDefs["GetHemodialysisOrderNewPlanForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HemodialysisOrder.GetHemodialysisOrderNewPlanForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HemodialysisOrder.GetHemodialysisOrderNewPlanForWorkList_Class> GetHemodialysisOrderNewPlanForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].QueryDefs["GetHemodialysisOrderNewPlanForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HemodialysisOrder.GetHemodialysisOrderNewPlanForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HemodialysisOrder.GetHemodialysisOrderForWorkList_Class> GetHemodialysisOrderForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].QueryDefs["GetHemodialysisOrderForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HemodialysisOrder.GetHemodialysisOrderForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HemodialysisOrder.GetHemodialysisOrderForWorkList_Class> GetHemodialysisOrderForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].QueryDefs["GetHemodialysisOrderForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HemodialysisOrder.GetHemodialysisOrderForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HemodialysisOrder.GetHemodialysisOrderList_Class> GetHemodialysisOrderList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].QueryDefs["GetHemodialysisOrderList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HemodialysisOrder.GetHemodialysisOrderList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HemodialysisOrder.GetHemodialysisOrderList_Class> GetHemodialysisOrderList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEMODIALYSISORDER"].QueryDefs["GetHemodialysisOrderList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HemodialysisOrder.GetHemodialysisOrderList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Haftasonu Dahil
    /// </summary>
        public bool? IsWeekendInclude
        {
            get { return (bool?)this["ISWEEKENDINCLUDE"]; }
            set { this["ISWEEKENDINCLUDE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Information
        {
            get { return (string)this["INFORMATION"]; }
            set { this["INFORMATION"] = value; }
        }

    /// <summary>
    /// Seans Gün Aralığı
    /// </summary>
        public int? SessionDayRange
        {
            get { return (int?)this["SESSIONDAYRANGE"]; }
            set { this["SESSIONDAYRANGE"] = value; }
        }

    /// <summary>
    /// Seans Gün Aralığı Tipi
    /// </summary>
        public PeriodUnitTypeEnum? SessionDayRangeType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["SESSIONDAYRANGETYPE"]; }
            set { this["SESSIONDAYRANGETYPE"] = value; }
        }

    /// <summary>
    /// Seans Sayısı
    /// </summary>
        public int? SessionCount
        {
            get { return (int?)this["SESSIONCOUNT"]; }
            set { this["SESSIONCOUNT"] = value; }
        }

    /// <summary>
    /// Hemodiyaliz Raporları
    /// </summary>
        public HemodialysisReports HemodialysisReports
        {
            get { return (HemodialysisReports)((ITTObject)this).GetParent("HEMODIALYSISREPORTS"); }
            set { this["HEMODIALYSISREPORTS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Diyalize Girme Sıklığı
    /// </summary>
        public SKRSDiyalizeGirmeSikligi DialysisFrequency
        {
            get { return (SKRSDiyalizeGirmeSikligi)((ITTObject)this).GetParent("DIALYSISFREQUENCY"); }
            set { this["DIALYSISFREQUENCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paket Hizmet
    /// </summary>
        public PackageProcedureDefinition PackageProcedure
        {
            get { return (PackageProcedureDefinition)((ITTObject)this).GetParent("PACKAGEPROCEDURE"); }
            set { this["PACKAGEPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tedavi Cihazı
    /// </summary>
        public ResEquipment TreatmentEquipment
        {
            get { return (ResEquipment)((ITTObject)this).GetParent("TREATMENTEQUIPMENT"); }
            set { this["TREATMENTEQUIPMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Seans Birimi
    /// </summary>
        public ResTreatmentDiagnosisUnit TreatmentDiagnosisUnit
        {
            get { return (ResTreatmentDiagnosisUnit)((ITTObject)this).GetParent("TREATMENTDIAGNOSISUNIT"); }
            set { this["TREATMENTDIAGNOSISUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hemodiyaliz Emirleri 
    /// </summary>
        public HemodialysisRequest HemodialysisRequest
        {
            get { return (HemodialysisRequest)((ITTObject)this).GetParent("HEMODIALYSISREQUEST"); }
            set { this["HEMODIALYSISREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateOrderDetailsCollectionViews()
        {
            base.CreateOrderDetailsCollectionViews();
            _HemodialysisOrderDetails = new HemodialysisOrderDetail.ChildHemodialysisOrderDetailCollection(_OrderDetails, "HemodialysisOrderDetails");
        }

        private HemodialysisOrderDetail.ChildHemodialysisOrderDetailCollection _HemodialysisOrderDetails = null;
        public HemodialysisOrderDetail.ChildHemodialysisOrderDetailCollection HemodialysisOrderDetails
        {
            get
            {
                if (_OrderDetails == null)
                    CreateOrderDetailsCollection();
                return _HemodialysisOrderDetails;
            }            
        }

        protected HemodialysisOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HemodialysisOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HemodialysisOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HemodialysisOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HemodialysisOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEMODIALYSISORDER", dataRow) { }
        protected HemodialysisOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEMODIALYSISORDER", dataRow, isImported) { }
        public HemodialysisOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HemodialysisOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HemodialysisOrder() : base() { }

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