
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientOnVacation")] 

    /// <summary>
    /// İzinli Hasta Çıkış Bilgileri
    /// </summary>
    public  partial class PatientOnVacation : TTObject
    {
        public class PatientOnVacationList : TTObjectCollection<PatientOnVacation> { }
                    
        public class ChildPatientOnVacationCollection : TTObject.TTChildObjectCollection<PatientOnVacation>
        {
            public ChildPatientOnVacationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientOnVacationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetVacationInfoByPhysician_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RelativesName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVESNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["RELATIVESNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelativesPhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVESPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["RELATIVESPHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetVacationInfoByPhysician_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVacationInfoByPhysician_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVacationInfoByPhysician_Class() : base() { }
        }

        [Serializable] 

        public partial class GetVacationInfoList_Class : TTReportNqlObject 
        {
            public string Bed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Room
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Tedavigordugu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIGORDUGU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yattigiklinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
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

            public string Doktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string VacationAdress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VACATIONADRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["VACATIONADRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelativesName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVESNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["RELATIVESNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelativesPhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVESPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["RELATIVESPHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetVacationInfoList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVacationInfoList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVacationInfoList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetVacationByDateAndPatient_Class : TTReportNqlObject 
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? DayCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAYCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["DAYCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string RelativesPhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVESPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["RELATIVESPHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string VacationAdress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VACATIONADRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["VACATIONADRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelativesName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVESNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["RELATIVESNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetVacationByDateAndPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVacationByDateAndPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVacationByDateAndPatient_Class() : base() { }
        }

        [Serializable] 

        public partial class GetVacationInfoByID_Class : TTReportNqlObject 
        {
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

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Tedavigordugu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIGORDUGU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yattigiklinik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGIKLINIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
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

            public string Doktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string VacationAdress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VACATIONADRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["VACATIONADRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelativesName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVESNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["RELATIVESNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelativesPhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATIVESPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].AllPropertyDefs["RELATIVESPHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetVacationInfoByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVacationInfoByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVacationInfoByID_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İzin girişi yapıldı
    /// </summary>
            public static Guid OnVacation { get { return new Guid("136902bc-e6e5-4b0d-8fbb-280e14e1f4fa"); } }
            public static Guid VacationFinish { get { return new Guid("b8518f15-174d-49b9-9edd-38fbbed00fbc"); } }
            public static Guid Cancelled { get { return new Guid("976286f5-cb74-4532-8fbf-81c54b3cad27"); } }
        }

        public static BindingList<PatientOnVacation.GetVacationInfoByPhysician_Class> GetVacationInfoByPhysician(Guid INPATIENTPHYSICIANAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationInfoByPhysician"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYSICIANAPPLICATION", INPATIENTPHYSICIANAPPLICATION);

            return TTReportNqlObject.QueryObjects<PatientOnVacation.GetVacationInfoByPhysician_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientOnVacation.GetVacationInfoByPhysician_Class> GetVacationInfoByPhysician(TTObjectContext objectContext, Guid INPATIENTPHYSICIANAPPLICATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationInfoByPhysician"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYSICIANAPPLICATION", INPATIENTPHYSICIANAPPLICATION);

            return TTReportNqlObject.QueryObjects<PatientOnVacation.GetVacationInfoByPhysician_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientOnVacation> GetVacationInfoByPatient(TTObjectContext objectContext, string PATIENT, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationInfoByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<PatientOnVacation>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<PatientOnVacation.GetVacationInfoList_Class> GetVacationInfoList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationInfoList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientOnVacation.GetVacationInfoList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientOnVacation.GetVacationInfoList_Class> GetVacationInfoList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationInfoList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientOnVacation.GetVacationInfoList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientOnVacation.GetVacationByDateAndPatient_Class> GetVacationByDateAndPatient(DateTime Date, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationByDateAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", Date);
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PatientOnVacation.GetVacationByDateAndPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientOnVacation.GetVacationByDateAndPatient_Class> GetVacationByDateAndPatient(TTObjectContext objectContext, DateTime Date, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationByDateAndPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", Date);
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PatientOnVacation.GetVacationByDateAndPatient_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PatientOnVacation.GetVacationInfoByID_Class> GetVacationInfoByID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationInfoByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientOnVacation.GetVacationInfoByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PatientOnVacation.GetVacationInfoByID_Class> GetVacationInfoByID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTONVACATION"].QueryDefs["GetVacationInfoByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PatientOnVacation.GetVacationInfoByID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İzin Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// İzin Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Gün Sayısı
    /// </summary>
        public int? DayCount
        {
            get { return (int?)this["DAYCOUNT"]; }
            set { this["DAYCOUNT"] = value; }
        }

    /// <summary>
    /// Yakının Telefon Numarası
    /// </summary>
        public string RelativesPhoneNumber
        {
            get { return (string)this["RELATIVESPHONENUMBER"]; }
            set { this["RELATIVESPHONENUMBER"] = value; }
        }

    /// <summary>
    /// İzni Geçireceği Adres
    /// </summary>
        public string VacationAdress
        {
            get { return (string)this["VACATIONADRESS"]; }
            set { this["VACATIONADRESS"] = value; }
        }

    /// <summary>
    /// Yakınının Adı
    /// </summary>
        public string RelativesName
        {
            get { return (string)this["RELATIVESNAME"]; }
            set { this["RELATIVESNAME"] = value; }
        }

        public ResUser ApproveDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("APPROVEDOCTOR"); }
            set { this["APPROVEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InPatientPhysicianApplication InpatientPhysician
        {
            get { return (InPatientPhysicianApplication)((ITTObject)this).GetParent("INPATIENTPHYSICIAN"); }
            set { this["INPATIENTPHYSICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientOnVacation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientOnVacation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientOnVacation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientOnVacation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientOnVacation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTONVACATION", dataRow) { }
        protected PatientOnVacation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTONVACATION", dataRow, isImported) { }
        public PatientOnVacation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientOnVacation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientOnVacation() : base() { }

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