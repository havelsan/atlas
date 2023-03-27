
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaAndReanimation")] 

    /// <summary>
    /// Anestezi ve Reanimasyon İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class AnesthesiaAndReanimation : EpisodeActionWithDiagnosis, IReasonOfReject, IAllocateSpeciality, IWorkListEpisodeAction, IAppointmentWithoutResources, IStockOutCancel
    {
        public class AnesthesiaAndReanimationList : TTObjectCollection<AnesthesiaAndReanimation> { }
                    
        public class ChildAnesthesiaAndReanimationCollection : TTObject.TTChildObjectCollection<AnesthesiaAndReanimation>
        {
            public ChildAnesthesiaAndReanimationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaAndReanimationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class AnesthesiaReportNQL_Class : TTReportNqlObject 
        {
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

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object AnesthesiaReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIAREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIAREPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? AnesthesiaReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIAREPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIAREPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? AnesthesiaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIAREPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DiplomaNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIPLOMANO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["DIPLOMANO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EmploymentRecordID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Speciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public AnesthesiaReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public AnesthesiaReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected AnesthesiaReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetAnesthesiaOfSurgery_Class : TTReportNqlObject 
        {
            public AnesthesiaTechniqueEnum? AnesthesiaTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIATECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIATECHNIQUE"].DataType;
                    return (AnesthesiaTechniqueEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetAnesthesiaOfSurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetAnesthesiaOfSurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetAnesthesiaOfSurgery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAnesthesiaAndReanimationForWL_Class : TTReportNqlObject 
        {
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Prioritystatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRIORITYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AnesthesiaStartDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIASTARTDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIASTARTDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AnesthesiaEndDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIAENDDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIAENDDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AnesthesiaReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIAREPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["ANESTHESIAREPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Anesthesiarequestdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIAREQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientnamesurname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAMESURNAME"]);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Object Episodeactionname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["EPISODEACTIONNAME"]);
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

            public string Surgerydepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Inpatientclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgeryroom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surgerydesk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURGERYDESK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSURGERYDESK"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Operator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Anesthesist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANESTHESIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissiontype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Telno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientClassTypeEnum? Hastaturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? Basvuruturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Oncelikdurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONCELIKDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAnesthesiaAndReanimationForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAnesthesiaAndReanimationForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAnesthesiaAndReanimationForWL_Class() : base() { }
        }

        public static class States
        {
            public static Guid Request { get { return new Guid("f5b3acd3-7244-4374-9f6f-127a44855c25"); } }
            public static Guid AnesthesiaReport { get { return new Guid("299e2829-8d0e-451f-99a7-4a93a97cedf6"); } }
            public static Guid SurgeryAnestesia { get { return new Guid("19951b61-fcf0-4343-9757-9c628fe8469d"); } }
            public static Guid AnesthesiaExpend { get { return new Guid("80047dd3-2c82-498a-9578-3cd79159d5b2"); } }
    /// <summary>
    /// İşlem İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ea87693e-b01c-44ea-b66b-333481adf4d6"); } }
            public static Guid Completed { get { return new Guid("fcf70b67-2c6b-4053-841d-40b0a588ee5e"); } }
            public static Guid ReturnedToDoctor { get { return new Guid("9eb04171-20a9-4091-8686-99ab5183f39a"); } }
            public static Guid RequestAcception { get { return new Guid("8b6fed16-96a6-4a1f-ae94-bacdcc6d8093"); } }
        }

    /// <summary>
    /// d4042d56-ef64-4325-bab9-174598696132
    /// </summary>
        public static BindingList<AnesthesiaAndReanimation.AnesthesiaReportNQL_Class> AnesthesiaReportNQL(string ANESTHESIA, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].QueryDefs["AnesthesiaReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ANESTHESIA", ANESTHESIA);

            return TTReportNqlObject.QueryObjects<AnesthesiaAndReanimation.AnesthesiaReportNQL_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// d4042d56-ef64-4325-bab9-174598696132
    /// </summary>
        public static BindingList<AnesthesiaAndReanimation.AnesthesiaReportNQL_Class> AnesthesiaReportNQL(TTObjectContext objectContext, string ANESTHESIA, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].QueryDefs["AnesthesiaReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ANESTHESIA", ANESTHESIA);

            return TTReportNqlObject.QueryObjects<AnesthesiaAndReanimation.AnesthesiaReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaAndReanimation.OLAP_GetAnesthesiaOfSurgery_Class> OLAP_GetAnesthesiaOfSurgery(string SURGERYID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].QueryDefs["OLAP_GetAnesthesiaOfSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERYID", SURGERYID);

            return TTReportNqlObject.QueryObjects<AnesthesiaAndReanimation.OLAP_GetAnesthesiaOfSurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaAndReanimation.OLAP_GetAnesthesiaOfSurgery_Class> OLAP_GetAnesthesiaOfSurgery(TTObjectContext objectContext, string SURGERYID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].QueryDefs["OLAP_GetAnesthesiaOfSurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERYID", SURGERYID);

            return TTReportNqlObject.QueryObjects<AnesthesiaAndReanimation.OLAP_GetAnesthesiaOfSurgery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaAndReanimation> GetByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<AnesthesiaAndReanimation>(queryDef, paramList);
        }

        public static BindingList<AnesthesiaAndReanimation.GetAnesthesiaAndReanimationForWL_Class> GetAnesthesiaAndReanimationForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].QueryDefs["GetAnesthesiaAndReanimationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnesthesiaAndReanimation.GetAnesthesiaAndReanimationForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnesthesiaAndReanimation.GetAnesthesiaAndReanimationForWL_Class> GetAnesthesiaAndReanimationForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAANDREANIMATION"].QueryDefs["GetAnesthesiaAndReanimationForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AnesthesiaAndReanimation.GetAnesthesiaAndReanimationForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Anestezi Uygulama Tarihi
    /// </summary>
        public DateTime? PlannedAnesthesiaDate
        {
            get { return (DateTime?)this["PLANNEDANESTHESIADATE"]; }
            set { this["PLANNEDANESTHESIADATE"] = value; }
        }

    /// <summary>
    /// Anestezi Başlama Tarihi
    /// </summary>
        public DateTime? AnesthesiaStartDateTime
        {
            get { return (DateTime?)this["ANESTHESIASTARTDATETIME"]; }
            set { this["ANESTHESIASTARTDATETIME"] = value; }
        }

    /// <summary>
    /// Anestezi Raporu
    /// </summary>
        public object AnesthesiaReport
        {
            get { return (object)this["ANESTHESIAREPORT"]; }
            set { this["ANESTHESIAREPORT"] = value; }
        }

    /// <summary>
    /// Anestezi Bitiş Tarihi
    /// </summary>
        public DateTime? AnesthesiaEndDateTime
        {
            get { return (DateTime?)this["ANESTHESIAENDDATETIME"]; }
            set { this["ANESTHESIAENDDATETIME"] = value; }
        }

    /// <summary>
    /// ASA
    /// </summary>
        public AnesthesiaASATypeEnum? ASAType
        {
            get { return (AnesthesiaASATypeEnum?)(int?)this["ASATYPE"]; }
            set { this["ASATYPE"] = value; }
        }

    /// <summary>
    /// Anestezi Rapor Tarihi
    /// </summary>
        public DateTime? AnesthesiaReportDate
        {
            get { return (DateTime?)this["ANESTHESIAREPORTDATE"]; }
            set { this["ANESTHESIAREPORTDATE"] = value; }
        }

    /// <summary>
    /// Anestezi Rapor No
    /// </summary>
        public TTSequence AnesthesiaReportNo
        {
            get { return GetSequence("ANESTHESIAREPORTNO"); }
        }

    /// <summary>
    /// İstek Notu
    /// </summary>
        public string RequestNote
        {
            get { return (string)this["REQUESTNOTE"]; }
            set { this["REQUESTNOTE"] = value; }
        }

    /// <summary>
    /// Anestezi Tekniği
    /// </summary>
        public AnesthesiaTechniqueEnum? AnesthesiaTechnique
        {
            get { return (AnesthesiaTechniqueEnum?)(int?)this["ANESTHESIATECHNIQUE"]; }
            set { this["ANESTHESIATECHNIQUE"] = value; }
        }

        public bool? IsTreatmentMaterialEmpty
        {
            get { return (bool?)this["ISTREATMENTMATERIALEMPTY"]; }
            set { this["ISTREATMENTMATERIALEMPTY"] = value; }
        }

        public TTSequence ProtocolNo
        {
            get { return GetSequence("PROTOCOLNO"); }
        }

        public bool? CancelledBySurgery
        {
            get { return (bool?)this["CANCELLEDBYSURGERY"]; }
            set { this["CANCELLEDBYSURGERY"] = value; }
        }

    /// <summary>
    /// Anestezi  Notu
    /// </summary>
        public object AnesthesiaNote
        {
            get { return (object)this["ANESTHESIANOTE"]; }
            set { this["ANESTHESIANOTE"] = value; }
        }

    /// <summary>
    /// Aydınlatılmış Onam Formu Verildi
    /// </summary>
        public bool? IsPatientApprovalFormGiven
        {
            get { return (bool?)this["ISPATIENTAPPROVALFORMGIVEN"]; }
            set { this["ISPATIENTAPPROVALFORMGIVEN"] = value; }
        }

    /// <summary>
    /// Anestezi yapan doktorun diploma tescil numarası.
    /// </summary>
        public string drAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

        public bool? HasComplication
        {
            get { return (bool?)this["HASCOMPLICATION"]; }
            set { this["HASCOMPLICATION"] = value; }
        }

        public string ComplicationDescription
        {
            get { return (string)this["COMPLICATIONDESCRIPTION"]; }
            set { this["COMPLICATIONDESCRIPTION"] = value; }
        }

    /// <summary>
    /// ASA Skoru
    /// </summary>
        public AnesthesiaASAScoreEnum? ASAScore
        {
            get { return (AnesthesiaASAScoreEnum?)(int?)this["ASASCORE"]; }
            set { this["ASASCORE"] = value; }
        }

    /// <summary>
    /// Yara Sınıfı
    /// </summary>
        public AnesthesiaScarEnum? ScarType
        {
            get { return (AnesthesiaScarEnum?)(int?)this["SCARTYPE"]; }
            set { this["SCARTYPE"] = value; }
        }

    /// <summary>
    /// Laparoskopi/Endoskopi
    /// </summary>
        public AnesthesiaLaparoscopyEnum? Laparoscopy
        {
            get { return (AnesthesiaLaparoscopyEnum?)(int?)this["LAPAROSCOPY"]; }
            set { this["LAPAROSCOPY"] = value; }
        }

        public Surgery MainSurgery
        {
            get { return (Surgery)((ITTObject)this).GetParent("MAINSURGERY"); }
            set { this["MAINSURGERY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Anestezi OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Yapan 2. Doktor
    /// </summary>
        public ResUser ProcedureDoctor2
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR2"); }
            set { this["PROCEDUREDOCTOR2"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRequestedProcedureCollection()
        {
            _RequestedProcedure = new AnesthesiaAndReanimationRequestedProcedure.ChildAnesthesiaAndReanimationRequestedProcedureCollection(this, new Guid("406fb718-fd87-418e-854e-0a4807b30c46"));
            ((ITTChildObjectCollection)_RequestedProcedure).GetChildren();
        }

        protected AnesthesiaAndReanimationRequestedProcedure.ChildAnesthesiaAndReanimationRequestedProcedureCollection _RequestedProcedure = null;
    /// <summary>
    /// Child collection for Anestezi Gerektiren İşlem
    /// </summary>
        public AnesthesiaAndReanimationRequestedProcedure.ChildAnesthesiaAndReanimationRequestedProcedureCollection RequestedProcedure
        {
            get
            {
                if (_RequestedProcedure == null)
                    CreateRequestedProcedureCollection();
                return _RequestedProcedure;
            }
        }

        virtual protected void CreateSurgeriesCollection()
        {
            _Surgeries = new Surgery.ChildSurgeryCollection(this, new Guid("2a317f85-7172-4d6c-bd0b-2bb3d342e472"));
            ((ITTChildObjectCollection)_Surgeries).GetChildren();
        }

        protected Surgery.ChildSurgeryCollection _Surgeries = null;
    /// <summary>
    /// Child collection for Anestezi ve Reanimasyon İşlemi
    /// </summary>
        public Surgery.ChildSurgeryCollection Surgeries
        {
            get
            {
                if (_Surgeries == null)
                    CreateSurgeriesCollection();
                return _Surgeries;
            }
        }

        virtual protected void CreateAnesthesiaPersonnelsCollection()
        {
            _AnesthesiaPersonnels = new AnesthesiaPersonnel.ChildAnesthesiaPersonnelCollection(this, new Guid("ba463619-72bc-41a9-af61-4cedd0b4cccb"));
            ((ITTChildObjectCollection)_AnesthesiaPersonnels).GetChildren();
        }

        protected AnesthesiaPersonnel.ChildAnesthesiaPersonnelCollection _AnesthesiaPersonnels = null;
    /// <summary>
    /// Child collection for Anestezi Ekibi
    /// </summary>
        public AnesthesiaPersonnel.ChildAnesthesiaPersonnelCollection AnesthesiaPersonnels
        {
            get
            {
                if (_AnesthesiaPersonnels == null)
                    CreateAnesthesiaPersonnelsCollection();
                return _AnesthesiaPersonnels;
            }
        }

        virtual protected void CreateProcedureOrdersCollection()
        {
            _ProcedureOrders = new ProcedureOrder.ChildProcedureOrderCollection(this, new Guid("ab12c8eb-ecc4-4ae4-a6ee-3cf8ba30dbd4"));
            ((ITTChildObjectCollection)_ProcedureOrders).GetChildren();
        }

        protected ProcedureOrder.ChildProcedureOrderCollection _ProcedureOrders = null;
    /// <summary>
    /// Child collection for Anestezi ve Reanimasyon
    /// </summary>
        public ProcedureOrder.ChildProcedureOrderCollection ProcedureOrders
        {
            get
            {
                if (_ProcedureOrders == null)
                    CreateProcedureOrdersCollection();
                return _ProcedureOrders;
            }
        }

        virtual protected void CreateIntensiveCareAfterSurgeriesCollection()
        {
            _IntensiveCareAfterSurgeries = new IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection(this, new Guid("5d0f00ee-ec02-4a58-991e-589378f0fafc"));
            ((ITTChildObjectCollection)_IntensiveCareAfterSurgeries).GetChildren();
        }

        protected IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection _IntensiveCareAfterSurgeries = null;
        public IntensiveCareAfterSurgery.ChildIntensiveCareAfterSurgeryCollection IntensiveCareAfterSurgeries
        {
            get
            {
                if (_IntensiveCareAfterSurgeries == null)
                    CreateIntensiveCareAfterSurgeriesCollection();
                return _IntensiveCareAfterSurgeries;
            }
        }

        virtual protected void CreateAnesthesiaResponsibleDoctorsCollection()
        {
            _AnesthesiaResponsibleDoctors = new AnesthesiaResponsibleDoctor.ChildAnesthesiaResponsibleDoctorCollection(this, new Guid("34133944-6373-4512-a878-7e4027767dda"));
            ((ITTChildObjectCollection)_AnesthesiaResponsibleDoctors).GetChildren();
        }

        protected AnesthesiaResponsibleDoctor.ChildAnesthesiaResponsibleDoctorCollection _AnesthesiaResponsibleDoctors = null;
        public AnesthesiaResponsibleDoctor.ChildAnesthesiaResponsibleDoctorCollection AnesthesiaResponsibleDoctors
        {
            get
            {
                if (_AnesthesiaResponsibleDoctors == null)
                    CreateAnesthesiaResponsibleDoctorsCollection();
                return _AnesthesiaResponsibleDoctors;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _AnaesthesiaAndReanimationAnesthesiaProcedures = new AnesthesiaProcedure.ChildAnesthesiaProcedureCollection(_SubactionProcedures, "AnaesthesiaAndReanimationAnesthesiaProcedures");
        }

        private AnesthesiaProcedure.ChildAnesthesiaProcedureCollection _AnaesthesiaAndReanimationAnesthesiaProcedures = null;
        public AnesthesiaProcedure.ChildAnesthesiaProcedureCollection AnaesthesiaAndReanimationAnesthesiaProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _AnaesthesiaAndReanimationAnesthesiaProcedures;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _AnestheAndReaniTreatMatrials = new AnesthesiaAndReanimationTreatmentMaterial.ChildAnesthesiaAndReanimationTreatmentMaterialCollection(_TreatmentMaterials, "AnestheAndReaniTreatMatrials");
        }

        private AnesthesiaAndReanimationTreatmentMaterial.ChildAnesthesiaAndReanimationTreatmentMaterialCollection _AnestheAndReaniTreatMatrials = null;
        public AnesthesiaAndReanimationTreatmentMaterial.ChildAnesthesiaAndReanimationTreatmentMaterialCollection AnestheAndReaniTreatMatrials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _AnestheAndReaniTreatMatrials;
            }            
        }

        protected AnesthesiaAndReanimation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaAndReanimation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaAndReanimation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaAndReanimation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaAndReanimation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIAANDREANIMATION", dataRow) { }
        protected AnesthesiaAndReanimation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIAANDREANIMATION", dataRow, isImported) { }
        public AnesthesiaAndReanimation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaAndReanimation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaAndReanimation() : base() { }

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